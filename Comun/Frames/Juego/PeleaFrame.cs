using Bot_Dofus_Retro.Comun.Frames.Transporte;
using Bot_Dofus_Retro.Comun.Network;
using Bot_Dofus_Retro.Otros;
using Bot_Dofus_Retro.Otros.Mapas;
using Bot_Dofus_Retro.Otros.Peleas;
using Bot_Dofus_Retro.Otros.Peleas.Enums;
using Bot_Dofus_Retro.Otros.Peleas.Peleadores;
using Bot_Dofus_Retro.Utilidades.Criptografia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Comun.Frames.Juego
{
    public class PeleaFrame : Frame
    {
        [PaqueteAtributo("GP")]
        public Task get_Combate_Celdas_Posicion(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            Cuenta cuenta = cliente.cuenta;
            Mapa mapa = cuenta.juego.mapa;
            Pelea pelea = cuenta.juego.pelea;

            if (!cuenta.esta_Luchando() || pelea.estado_pelea != 2)
                return;

            await Task.Delay(1000);

            if (cuenta.pelea_extension.configuracion.posicionamiento != PosicionamientoInicioPelea.INMOVIL)
            {
                string[] _loc3 = paquete.Substring(2).Split('|');
                List<Celda> celdas_preparacion = new List<Celda>();

                for (int a = 0; a < _loc3[0].Length; a += 2)
                    celdas_preparacion.Add(mapa.get_Celda_Id((short)((Hash.get_Hash(_loc3[0][a]) << 6) + Hash.get_Hash(_loc3[0][a + 1]))));

                List<Celda> celdas_preparacion_disponibles = celdas_preparacion.Except(cuenta.juego.pelea.get_Aliados.Select(aliado => aliado.celda)).ToList();

                /** la posicion es aleatoria pero el paquete GP siempre aparecera primero el team donde esta el pj **/
                short celda_posicion = pelea.get_Celda_Mas_Cercana_O_Lejana(cuenta.pelea_extension.configuracion.posicionamiento == PosicionamientoInicioPelea.CERCA_DE_ENEMIGOS, celdas_preparacion_disponibles);

                if (celda_posicion != pelea.jugador_luchador.celda.id)
                {
                    await cliente.enviar_Paquete_Async("Gp" + celda_posicion, true);
                    await Task.Delay(300);
                }
            }

            if (cuenta.pelea_extension.configuracion.desactivar_espectador)
                await cliente.enviar_Paquete_Async("fS");

            await Task.Delay(300);

            if (cuenta.puede_utilizar_dragopavo)
            {
                if (cuenta.pelea_extension.configuracion.utilizar_dragopavo && !cuenta.juego.personaje.esta_utilizando_dragopavo)
                {
                    await cliente.enviar_Paquete_Async("Rr");
                    cuenta.juego.personaje.esta_utilizando_dragopavo = true;
                }
            }

            if (cuenta.tiene_grupo && cuenta.es_lider_grupo)
            {
                await cuenta.grupo.get_Esperar_Miembros_Unirse_Pelea();

                if (pelea.pelea_iniciada)
                    return;
            }

            await Task.Delay(300);
            await cliente.enviar_Paquete_Async("GR1");//boton listo
        });

        [PaqueteAtributo("GICE")]
        public Task get_Error_Cambiar_Pos_Pelea(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            if (!cliente.cuenta.esta_Luchando())
                return;

            cliente.cuenta.logger.log_Error("PELEA", "Error al mover el personaje en la preparación del combate");
        });

        [PaqueteAtributo("GIC")]
        public Task get_Cambiar_Pos_Pelea(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            if (!cliente.cuenta.esta_Luchando())
                return;

            Cuenta cuenta = cliente.cuenta;
            string[] separador_posiciones = paquete.Substring(4).Split('|');
            int id_entidad;
            short celda;
            Luchadores luchador;
            Mapa mapa = cuenta.juego.mapa;

            foreach (string posicion in separador_posiciones)
            {
                id_entidad = int.Parse(posicion.Split(';')[0]);
                celda = short.Parse(posicion.Split(';')[1]);

                luchador = cuenta.juego.pelea.get_Luchador_Por_Id(id_entidad);
                if (luchador != null)
                    luchador.celda = mapa.get_Celda_Id(celda);
            }
        });

        [PaqueteAtributo("GTM")]
        public Task get_Combate_Info_Stats(ClienteTcp cliente, string paquete) => Task.Factory.StartNew(() =>
        {
            Cuenta cuenta = cliente.cuenta;
            if (!cuenta.esta_Luchando())
                return;

            string[] monstruos = paquete.Substring(4).Split('|');
            Mapa mapa = cliente.cuenta.juego.mapa;

            foreach (string monstruo in monstruos)
            {
                string[] _loc6_ = monstruo.Split(';');
                int id = int.Parse(_loc6_[0]);
                Luchadores luchador = cuenta.juego.pelea.get_Luchador_Por_Id(id);

                if (_loc6_.Length > 0 && luchador != null)
                {
                    bool esta_vivo = _loc6_[1].Equals("0");
                    if (esta_vivo)
                    {
                        int vida_actual = int.Parse(_loc6_[2]);
                        byte pa = byte.Parse(_loc6_[3]);
                        byte pm = byte.Parse(_loc6_[4]);
                        short celda = short.Parse(_loc6_[5]);
                        int vida_maxima = int.Parse(_loc6_[7]);

                        if (celda > 0)//son espectadores
                        {
                            luchador.vida_actual = vida_actual;
                            luchador.vida_maxima = vida_maxima;
                            luchador.pa = pa;
                            luchador.pm = pm;
                            luchador.celda = mapa.get_Celda_Id(celda);
                        }
                    }
                    luchador.esta_vivo = esta_vivo;
                }
            }
        }, TaskCreationOptions.LongRunning);

        [PaqueteAtributo("GTR")]
        public Task get_Combate_Turno_Listo(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            Cuenta cuenta = cliente.cuenta;
            int id = int.Parse(paquete.Substring(3));

            if (cuenta.juego.personaje.id == id)
                cuenta.juego.pelea.get_Turno_Acabado();

            await Task.Delay(200);
            await cliente.enviar_Paquete_Async("GT");
        });

        [PaqueteAtributo("GJK")]
        public Task get_Unirse_Pelea(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            //GJK - estado|boton_cancelar|mostrar_botones|espectador|tiempo|tipo_pelea
            string[] separador = paquete.Substring(3).Split('|');
            byte estado_pelea = byte.Parse(separador[0]);
            cliente.cuenta.juego.pelea.get_Combate_Creado(estado_pelea);
        });

        [PaqueteAtributo("GS")]
        public Task get_Comienzo_Pelea(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.juego.pelea.get_Combate_Iniciado());

        [PaqueteAtributo("GTS")]
        public Task get_Combate_Inicio_Turno(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            Cuenta cuenta = cliente.cuenta;
            string[] separador = paquete.Substring(3).Split('|');
            int id = int.Parse(separador[0]);

            if (cuenta.juego.personaje.id == id)
                cuenta.juego.pelea.get_Turno_Iniciado();
        });

        [PaqueteAtributo("GE")]
        public Task get_Combate_Finalizado(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            cliente.cuenta.juego.pelea.get_Combate_Acabado();
            await cliente.enviar_Paquete_Async("GC1");
        });
    }
}
