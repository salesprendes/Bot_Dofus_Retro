using Bot_Dofus_Retro.Comun.Frames.Transporte;
using Bot_Dofus_Retro.Comun.Network;
using Bot_Dofus_Retro.Otros;
using Bot_Dofus_Retro.Otros.Enums;
using Bot_Dofus_Retro.Otros.Game.Personaje;
using Bot_Dofus_Retro.Otros.Mapas.Entidades;
using Bot_Dofus_Retro.Utilidades.Configuracion;
using Bot_Dofus_Retro.Utilidades.Criptografia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Comun.Frames.Juego
{
    public class PersonajeFrame : Frame
    {
        [PaqueteAtributo("As")]
        public Task get_Stats_Actualizados(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            cliente.cuenta.juego.personaje.actualizar_Caracteristicas(paquete);
            await cliente.enviar_Paquete_Async("BD");
        });

        [PaqueteAtributo("SL")]
        public Task get_Lista_Hechizos(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            if (!paquete[2].Equals('o'))
                cliente.cuenta.juego.personaje.actualizar_Hechizos(paquete.Substring(2));
        });

        [PaqueteAtributo("Ow")]
        public Task get_Actualizacion_Pods(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            string[] pods = paquete.Substring(2).Split('|');
            short pods_actuales = short.Parse(pods[0]);
            short pods_maximos = short.Parse(pods[1]);
            PersonajeJuego personaje = cliente.cuenta.juego.personaje;

            personaje.inventario.pods_actuales = pods_actuales;
            personaje.inventario.pods_maximos = pods_maximos;
            cliente.cuenta.juego.personaje.evento_Pods_Actualizados();
        });

        [PaqueteAtributo("DV")]
        public Task get_Cerrar_Dialogo(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            Cuenta cuenta = cliente.cuenta;

            switch (cuenta.Estado_Cuenta)
            {
                case EstadoCuenta.ALMACENAMIENTO:
                    cuenta.juego.personaje.inventario.evento_Almacenamiento_Abierto();
                    break;

                case EstadoCuenta.DIALOGANDO:
                    cuenta.juego.npcs.get_Cerrar_Dialogo();
                break;
            }
        });

        [PaqueteAtributo("EV")]
        public Task get_Ventana_Cerrada(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            Cuenta cuenta = cliente.cuenta;

            if (cuenta.Estado_Cuenta == EstadoCuenta.ALMACENAMIENTO)
            {
                cuenta.Estado_Cuenta = EstadoCuenta.CONECTADO_INACTIVO;
                cuenta.juego.personaje.inventario.evento_Almacenamiento_Cerrado();
            }
        });

        [PaqueteAtributo("JS")]
        public Task get_Skills_Oficio(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.juego.personaje.oficios.get_Actualizar_Skills_Oficio(paquete));

        [PaqueteAtributo("JX")]
        public Task get_Experiencia_Oficio(ClienteTcp cliente, string paquete) => Task.Run(async () => await cliente.cuenta.juego.personaje.oficios.get_Actualizar_Experiencia_oficio(paquete));

        [PaqueteAtributo("Re")]
        public Task get_Datos_Montura(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.puede_utilizar_dragopavo = true);

        [PaqueteAtributo("OAKO")]
        public Task get_Aparecer_Objeto(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.juego.personaje.inventario.agregar_Objetos(paquete.Substring(4)));

        [PaqueteAtributo("OR")]
        public Task get_Eliminar_Objeto(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.juego.personaje.inventario.eliminar_Objeto(uint.Parse(paquete.Substring(2)), 1, false));

        [PaqueteAtributo("OQ")]
        public Task get_Modificar_Cantidad_Objeto(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.juego.personaje.inventario.modificar_Objetos(paquete.Substring(2)));

        [PaqueteAtributo("ECK")]
        public Task get_Intercambio_Ventana_Abierta(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.Estado_Cuenta = EstadoCuenta.ALMACENAMIENTO);

        [PaqueteAtributo("PIK")]
        public Task get_Peticion_Grupo(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            Cuenta cuenta = cliente.cuenta;
            string nombre_invitador = paquete.Substring(3).Split('|')[0];

            if (nombre_invitador.Equals(cuenta.juego.personaje.nombre))
                return;

            if (cuenta.tiene_grupo)
            {
                cuenta.grupo.get_Esta_En_Grupo(nombre_invitador);
                await cliente.enviar_Paquete_Async("PA");
            }
            else
                await cliente.enviar_Paquete_Async("PR");

            cliente.cuenta.logger.log_informacion("Grupo", $"Nueva invitación de grupo del personaje: {nombre_invitador}");
        });

        [PaqueteAtributo("PCK")]
        public Task get_Grupo_Aceptado(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            cliente.cuenta.juego.personaje.en_grupo = true;
            cliente.cuenta.logger.log_informacion("GRUPO", "Grupo aceptado");
        });

        [PaqueteAtributo("PV")]
        public Task get_Grupo_Abandonado(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            cliente.cuenta.juego.personaje.en_grupo = false;
            cliente.cuenta.logger.log_informacion("GRUPO", "Grupo abandonado");
        });

        [PaqueteAtributo("AN")]
        public Task get_Nuevo_Nivel(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            Cuenta cuenta = cliente.cuenta;
            short nivel = short.Parse(paquete.Substring(2));
            StatsBoosteables stat_boost = cuenta.pelea_extension.configuracion.stat_boost;

            if (stat_boost != StatsBoosteables.NINGUNO)
                cuenta.juego.personaje.get_Auto_Boostear_Caracteristicas(stat_boost);

            cuenta.logger.log_informacion("DOFUS", $"El personaje ha subido al nivel {nivel}");
        });

        [PaqueteAtributo("ERK")]
        public Task get_Peticion_Intercambio(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            cliente.cuenta.logger.log_informacion("INFORMACIÓN", "Invitación de intercambio recibida, rechazando");
            await cliente.enviar_Paquete_Async("EV", true);
        });

        [PaqueteAtributo("ILS")]
        public Task get_Tiempo_Regenerado(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            paquete = paquete.Substring(3);
            int tiempo = int.Parse(paquete);
            Cuenta cuenta = cliente.cuenta;
            PersonajeJuego personaje = cuenta.juego.personaje;

            personaje.timer_regeneracion.Change(Timeout.Infinite, Timeout.Infinite);
            personaje.timer_regeneracion.Change(tiempo, tiempo);

            cuenta.logger.log_informacion("DOFUS", $"Tú personaje recupera 1 pdv cada {tiempo / 1000} segundos");
        });

        [PaqueteAtributo("ILF")]
        public Task get_Cantidad_Vida_Regenerada(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            paquete = paquete.Substring(3);
            int vida = int.Parse(paquete);
            Cuenta cuenta = cliente.cuenta;
            PersonajeJuego personaje = cuenta.juego.personaje;

            personaje.caracteristicas.vitalidad_actual += vida;
            cuenta.logger.log_informacion("DOFUS", $"Has recuperado {vida} puntos de vida");
        });

        [PaqueteAtributo("eUK")]
        public Task get_Emote_Recibido(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            string[] separador = paquete.Substring(3).Split('|');
            int id = int.Parse(separador[0]), emote_id = int.Parse(separador[1]);
            Cuenta cuenta = cliente.cuenta;

            if (cuenta.juego.personaje.id != id)
                return;

            if (emote_id == 1 && cuenta.Estado_Cuenta != EstadoCuenta.REGENERANDO)
                cuenta.Estado_Cuenta = EstadoCuenta.REGENERANDO;
            else if (emote_id == 0 && cuenta.Estado_Cuenta == EstadoCuenta.REGENERANDO)
                cuenta.Estado_Cuenta = EstadoCuenta.CONECTADO_INACTIVO;
        });

        [PaqueteAtributo("Bp")]
        public Task get_Ping_Promedio(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.enviar_Paquete($"Bp{cliente.get_Promedio_Pings()}|{cliente.get_Total_Pings()}|50"));

        [PaqueteAtributo("pong")]
        public Task get_Ping_Pong(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_informacion("DOFUS", $"Ping: {cliente.get_Actual_Ping()} ms"));

        [PaqueteAtributo("AR")]
        public Task get_Restricciones(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            int restriccion = Base36.decodificar(paquete.Substring(2));
            cliente.cuenta.juego.personaje.derechos.set_Derechos(restriccion);
        });

        [PaqueteAtributo("BC")]
        public Task get_Verificar_Archivo(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            string[] separador = paquete.Substring(2).Split(';');
            int id = int.Parse(separador[0]), bytes = -1;
            string archivo = separador[1];

            if (archivo.Contains("core.swf"))
                bytes = GlobalConf.peso_core;
            else if (archivo.Contains("loader.swf"))
                bytes = GlobalConf.peso_loader;

            await cliente.enviar_Paquete_Async($"BC{id};{bytes}", false);
            cliente.cuenta.logger.log_Error("ANTI-BOT", $"Se ha revisado el archivo: {archivo}");
        });

        [PaqueteAtributo("GCK")]
        public Task get_Crear_Pantalla_Juego(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.Estado_Cuenta = EstadoCuenta.CONECTADO_INACTIVO);
    }
}
