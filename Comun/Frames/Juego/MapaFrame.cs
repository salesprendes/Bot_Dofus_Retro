using Bot_Dofus_Retro.Comun.Frames.Transporte;
using Bot_Dofus_Retro.Comun.Network;
using Bot_Dofus_Retro.Otros;
using Bot_Dofus_Retro.Otros.Enums;
using Bot_Dofus_Retro.Otros.Game.Entidades.Manejadores.Recolecciones;
using Bot_Dofus_Retro.Otros.Game.Personaje;
using Bot_Dofus_Retro.Otros.Mapas;
using Bot_Dofus_Retro.Otros.Mapas.Entidades;
using Bot_Dofus_Retro.Otros.Peleas;
using Bot_Dofus_Retro.Otros.Peleas.Peleadores;
using Bot_Dofus_Retro.Utilidades.Configuracion;
using Bot_Dofus_Retro.Utilidades.Criptografia;
using System;
using System.Threading.Tasks;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Comun.Frames.Juego
{
    public class MapaFrame : Frame
    {
        [PaqueteAtributo("GM")]
        public Task get_Movimientos_Personajes(ClienteTcp cliente, string paquete) => Task.Factory.StartNew(async () =>
        {
            Cuenta cuenta = cliente.cuenta;
            Mapa mapa = cuenta.juego.mapa;
            string[] separador_jugadores = paquete.Substring(3).Split('|'), informaciones;
            string nombre_template, tipo;
            int id;

            while (!mapa.mapa_cargado)
                await Task.Delay(100);

            foreach (string jugador in separador_jugadores)
            {
                if (jugador.Length < 1)
                    continue;

                if (jugador[0].Equals('+'))
                {
                    informaciones = jugador.Substring(1).Split(';');
                    Celda celda = mapa.get_Celda_Id(short.Parse(informaciones[0]));
                    Pelea pelea = cuenta.juego.pelea;
                    id = int.Parse(informaciones[3]);
                    nombre_template = informaciones[4];
                    tipo = informaciones[5];

                    if (tipo.Contains(","))
                        tipo = tipo.Split(',')[0];

                    switch (int.Parse(tipo))
                    {
                        case -1://Criatura
                        case -2://Monstruo
                            if (!cuenta.esta_Luchando())
                                return;

                            int vida_monstruo = int.Parse(informaciones[12]);
                            byte pa_monstruo = byte.Parse(informaciones[13]);
                            byte pm_monstruo = byte.Parse(informaciones[14]);
                            byte equipo_monstruo;

                            if (informaciones.Length > 18)
                                equipo_monstruo = byte.Parse(informaciones[22]);
                            else
                                equipo_monstruo = byte.Parse(informaciones[15]);

                            pelea.get_Agregar_Luchador(new Luchadores(id, true, vida_monstruo, pa_monstruo, pm_monstruo, celda, vida_monstruo, equipo_monstruo, 0, false));
                            break;

                        case -3://Grupo de Monstruos
                            string[] templates = nombre_template.Split(',');
                            string[] niveles = informaciones[7].Split(',');

                            Monstruos monstruo = new Monstruos(id, int.Parse(templates[0]), celda, int.Parse(niveles[0]));
                            monstruo.lider_grupo = monstruo;

                            for (int m = 1; m < templates.Length; ++m)
                                monstruo.moobs_dentro_grupo.Add(new Monstruos(id, int.Parse(templates[m]), celda, int.Parse(niveles[m])));

                            mapa.entidades.TryAdd(id, monstruo);
                            break;

                        case -4://NPC'S
                            mapa.entidades.TryAdd(id, new Npc(id, int.Parse(nombre_template), celda));
                            break;

                        case -5:// Mercantes
                            mapa.entidades.TryAdd(id, new Mercantes(id, celda));
                            break;

                        case -6:// Recaudadores
                            if (cuenta.esta_Luchando())
                            {
                                byte vida_recaudador = byte.Parse(informaciones[9]);
                                byte pa_recaudador = byte.Parse(informaciones[9]);
                                byte pm_recaudador = byte.Parse(informaciones[10]);
                                byte equipo_recaudador = byte.Parse(informaciones[18]);

                                pelea.get_Agregar_Luchador(new Luchadores(id, true, vida_recaudador, pa_recaudador, pm_recaudador, celda, vida_recaudador, equipo_recaudador, 0, false));
                            }
                            break;

                        case -7:
                        case -8:
                        case -9:
                        case -10:
                            break;

                        default:// jugadores
                            if (cuenta.esta_Luchando())
                            {
                                int vida = int.Parse(informaciones[14]);
                                byte pa = byte.Parse(informaciones[15]);
                                byte pm = byte.Parse(informaciones[16]);
                                byte equipo = byte.Parse(informaciones[24]);
                                pelea.get_Agregar_Luchador(new Luchadores(id, true, vida, pa, pm, celda, vida, equipo, 0, false));
                            }
                            else
                            {
                                if (cuenta.juego.personaje.id == id)
                                {
                                    cuenta.juego.personaje.celda = celda;
                                    cuenta.juego.personaje.restricciones.set_Restricciones(int.Parse(informaciones[18]));
                                }
                                else
                                    mapa.entidades.TryAdd(id, new Personajes(id, nombre_template, byte.Parse(informaciones[7].ToString()), celda, int.Parse(informaciones[18])));
                            }
                            break;
                    }
                }

                if (jugador[0].Equals('-'))
                {
                    if (!cuenta.esta_Luchando())
                    {
                        id = int.Parse(jugador.Substring(1));
                        mapa.entidades.TryRemove(id, out Entidad entidad);
                        mapa.get_Entidad_Actualizada();

                        if (GlobalConf.mostrar_mensajes_debug)
                            cuenta.logger.log_informacion("DEBUG", $"Entidad {entidad.id} en la celda {entidad.celda.id} eliminada");
                    }
                }
            }
        }, TaskCreationOptions.LongRunning);

        [PaqueteAtributo("GAF")]
        public Task get_Finalizar_Accion(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            Cuenta cuenta = cliente.cuenta;
            string[] separador = paquete.Substring(3).Split('|');
            int id_accion = int.Parse(separador[0]), id_personaje = int.Parse(separador[1]);

            if (cuenta.juego.personaje.id == id_personaje)
            {
                await cliente.cuenta.conexion.enviar_Paquete_Async("GKK" + id_accion);

                if (cuenta.esta_Luchando())
                {
                    await Task.Delay(200);
                    await cuenta.pelea_extension.get_Procesar_Accion_Finalizada();
                }
            }
        });

        [PaqueteAtributo("GAS")]
        public void get_Iniciar_Accion(ClienteTcp cliente, string paquete) { }

        [PaqueteAtributo("GA")]
        public Task get_Accion(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            string[] separador = paquete.Substring(2).Split(';');
            int id_accion = int.Parse(separador[1]);
            int id_entidad = int.Parse(separador[2]);
            Cuenta cuenta = cliente.cuenta;
            PersonajeJuego personaje = cuenta.juego.personaje;
            Celda celda;
            Mapa mapa = cuenta.juego.mapa;
            Pelea pelea = cuenta.juego.pelea;
            Luchadores luchador = pelea.get_Luchador_Por_Id(id_entidad);

            switch (id_accion)
            {
                case 0:
                    switch (cuenta.Estado_Cuenta)
                    {
                        case EstadoCuenta.MOVIMIENTO:
                            await cuenta.juego.manejador.movimientos.evento_Movimiento_Finalizado(null, 0, false);
                        break;

                        case EstadoCuenta.LUCHANDO:
                            await cuenta.pelea_extension.get_Procesar_Accion_Sin_Lanzar_Hechizo();
                        break;
                    }
                break;

                case 1:
                    celda = mapa.get_Celda_Id(Hash.get_Celda_Id_Desde_hash(separador[3].Substring(separador[3].Length - 2)));
                    byte.TryParse(separador[0], out byte tipo_gkk_movimiento);

                    if (cuenta.esta_Luchando() && luchador != null)
                        luchador.celda = celda;

                    if (id_entidad == personaje.id && celda.id > 0 && personaje.celda.id != celda.id)
                        await cuenta.juego.manejador.movimientos.evento_Movimiento_Finalizado(celda, tipo_gkk_movimiento, true);
                    else if (mapa.entidades.TryGetValue(id_entidad, out Entidad entidad))
                        entidad.celda = celda;

                    mapa.get_Entidad_Actualizada();
                    if (GlobalConf.mostrar_mensajes_debug)
                        cuenta.logger.log_informacion("DEBUG", "Movimiento finalizado de una entidad, casilla: " + celda.id);
                break;

                case 4:
                    separador = separador[3].Split(',');
                    celda = mapa.get_Celda_Id(short.Parse(separador[1]));

                    if (cuenta.esta_Luchando() && luchador != null)
                    {
                        luchador.celda = celda;
                    }
                    else if (id_entidad == personaje.id && personaje.celda.id != celda.id)
                    {
                        personaje.celda = celda;
                        await cuenta.conexion.enviar_Paquete_Async("GKK1");
                    }

                    mapa.get_Entidad_Actualizada();
                    cuenta.juego.manejador.movimientos.movimiento_Actualizado(true);
                break;

                case 5:
                    if (!cuenta.esta_Luchando())
                        return;

                    byte.TryParse(separador[0], out byte gkk);
                    separador = separador[3].Split(',');
                    luchador = pelea.get_Luchador_Por_Id(int.Parse(separador[0]));

                    if (luchador != null)
                        luchador.celda = mapa.get_Celda_Id(short.Parse(separador[1]));

                    await cuenta.conexion.enviar_Paquete_Async($"GKK{gkk}");
                break;

                /** Modificación puntos de pelea **/
                case 100:
                case 108:
                case 110:
                case 127:
                case 129:
                case 128:
                case 78:
                case 169:
                case 101:
                case 102:
                case 111:
                case 120:
                case 168:
                    if (!cuenta.esta_Luchando() || luchador == null)
                        return;

                    string[] _loc43_ = separador[3].Split(',');

                    luchador.get_Actualizar_Puntos_Pelea(id_accion, _loc43_[1]);
                break;

                case 103:
                    if (!cuenta.esta_Luchando())
                        return;

                    int id_muerto = int.Parse(separador[3]);
                    luchador = pelea.get_Luchador_Por_Id(id_muerto);

                    if (luchador != null)
                    {
                        luchador.vida_actual = 0;
                        luchador.esta_vivo = false;
                    }

                    if (GlobalConf.mostrar_mensajes_debug)
                        cuenta.logger.log_informacion("DEBUG", "Ha muerto un enemigo");
                break;

                case 151://obstaculos invisibles
                    if (!cuenta.esta_Luchando() || luchador == null)
                        return;

                    cuenta.logger.log_Error("PELEA", "No es posible realizar esta acción por culpa de un obstáculo invisible.");
                    if (luchador.id == personaje.id)
                    {
                        await Task.Delay(1000);
                        await cuenta.pelea_extension.get_Procesar_Accion_Sin_Lanzar_Hechizo();
                    }
                break;

                /** Efecto de invocacion **/
                case 180:
                case 181:
                    celda = mapa.get_Celda_Id(short.Parse(separador[3].Substring(1)));
                    short id_luchador = short.Parse(separador[6]);
                    short vida = short.Parse(separador[15]);
                    byte pa = byte.Parse(separador[16]);
                    byte pm = byte.Parse(separador[17]);
                    byte equipo;

                    if (separador.Length > 19)
                        equipo = byte.Parse(separador[25]);
                    else
                        equipo = byte.Parse(separador[18]);

                    pelea.get_Agregar_Luchador(new Luchadores(id_luchador, true, vida, pa, pm, celda, vida, equipo, id_luchador, true));
                break;

                case 300: //hechizo lanzado con exito
                    if (!cuenta.esta_Luchando() || id_entidad != personaje.id)
                        return;

                    short hechizo_id = short.Parse(separador[3].Split(',')[0]);
                    short celda_id = short.Parse(separador[3].Split(',')[1]);
                    pelea.actualizar_Hechizo_Exito(hechizo_id, celda_id);
                break;

                case 302://fallo crítico
                    if (!cuenta.esta_Luchando() || id_entidad != personaje.id)
                        return;

                    await cuenta.pelea_extension.get_Procesar_Accion_Sin_Lanzar_Hechizo();
                break;

                case 501:
                    int tiempo_recoleccion = int.Parse(separador[3].Split(',')[1]);
                    celda = mapa.get_Celda_Id(short.Parse(separador[3].Split(',')[0]));
                    byte tipo_gkk_recoleccion = byte.Parse(separador[0]);

                    await cuenta.juego.manejador.recoleccion.evento_Recoleccion_Iniciada(id_entidad, tiempo_recoleccion, celda.id, tipo_gkk_recoleccion);
                break;

                case 900:
                    await cuenta.conexion.enviar_Paquete_Async("GA902" + id_entidad, true);
                    cuenta.logger.log_informacion("INFORMACIÓN", "Desafio del personaje id: " + id_entidad + " cancelado");
                break;

                case 905:
                    cuenta.Estado_Cuenta = EstadoCuenta.LUCHANDO;
                    cuenta.juego.pelea.get_Nueva_Espada_Combate(id_entidad);
                break;
            }
        });

        [PaqueteAtributo("GDF")]
        public Task get_Estado_Interactivo(ClienteTcp cliente, string paquete) => Task.Factory.StartNew(() =>
        {
            foreach (string interactivo in paquete.Substring(4).Split('|'))
            {
                string[] separador = interactivo.Split(';');
                Cuenta cuenta = cliente.cuenta;
                short celda_id = short.Parse(separador[0]);
                byte estado = byte.Parse(separador[1]);

                switch (estado)
                {
                    case 2:
                        cuenta.juego.mapa.interactivos[celda_id].es_utilizable = false;
                        break;

                    case 3:
                        if (cuenta.juego.mapa.interactivos.TryGetValue(celda_id, out var celda_interactivo))
                            celda_interactivo.es_utilizable = false;

                        if (cuenta.esta_Recolectando())
                            cuenta.juego.manejador.recoleccion.evento_Recoleccion_Acabada(RecoleccionResultado.RECOLECTADO, celda_id);
                        else
                            cuenta.juego.manejador.recoleccion.evento_Recoleccion_Acabada(RecoleccionResultado.ROBADO, celda_id);
                    break;

                    case 4:// reaparece asi se fuerza el cambio de mapa 
                        cuenta.juego.mapa.interactivos[celda_id].es_utilizable = false;
                    break;
                }
            }
        }, TaskCreationOptions.LongRunning);

        [PaqueteAtributo("GDM")]
        public Task get_Nuevo_Mapa(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            cliente.cuenta.juego.mapa.get_Actualizar_Mapa(paquete.Substring(4));
            await cliente.enviar_Paquete_Async("GI");
        });

        [PaqueteAtributo("GDK")]
        public Task get_Mapa_Cambiado(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.juego.mapa.get_Mapa_Cambiado());

        [PaqueteAtributo("GV")]
        public Task get_Reiniciar_Pantalla(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.enviar_Paquete("GC1"));
    }
}
