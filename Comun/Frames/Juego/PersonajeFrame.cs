using Bot_Dofus_Retro.Comun.Frames.Transporte;
using Bot_Dofus_Retro.Comun.Network;
using Bot_Dofus_Retro.Otros;
using Bot_Dofus_Retro.Otros.Enums;
using Bot_Dofus_Retro.Otros.Game.Personaje;
using Bot_Dofus_Retro.Utilidades.Configuracion;
using Bot_Dofus_Retro.Utilidades.Criptografia;
using System.Threading;
using System.Threading.Tasks;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2023 Alvaro Prendes — Todos los derechos reservados.
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
            await cliente.enviar_Paquete_Async("Ir742;556;0");//envia informaciones pantalla
            await cliente.enviar_Paquete_Async("BD");
            cliente.cuenta.juego.personaje.actualizar_Caracteristicas(paquete);
        });

        [PaqueteAtributo("PIK")]
        public Task get_Peticion_Grupo(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            cliente.cuenta.logger.log_informacion("Grupo", $"Nueva invitación de grupo del personaje: {paquete.Substring(3).Split('|')[0]}");
            await cliente.enviar_Paquete_Async("PR");
            cliente.cuenta.logger.log_informacion("Grupo", "Petición rechazada");
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

        [PaqueteAtributo("PCK")]
        public Task get_Grupo_Aceptado(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            cliente.cuenta.logger.log_Error("GRUPO", "Grupo aceptado");
            cliente.cuenta.juego.personaje.en_grupo = true;
        });

        [PaqueteAtributo("PV")]
        public Task get_Grupo_Abandonado(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            cliente.cuenta.logger.log_informacion("GRUPO", "Grupo abandonado");
            cliente.cuenta.juego.personaje.en_grupo = false;
        });

        [PaqueteAtributo("ERK")]
        public Task get_Peticion_Intercambio(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            cliente.cuenta.logger.log_informacion("INFORMACIÓN", "Invitación de intercambio recibida, rechazando");
            await cliente.enviar_Paquete_Async("EV");
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
        public Task get_Cantidad_Vida_Regenerada(ClienteTcp cliente, string paquete) => Task.Run(()=>
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
        public Task get_Ping_Promedio(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            Ping ping = cliente.ping;

            await cliente.enviar_Paquete_Async($"Bp{ping.get_Promedio_Latencia()}|{ping.get_Total_Pings()}|{ping.get_latencias_totales()}");
        });

        [PaqueteAtributo("pong")]
        public Task get_Ping_Pong(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_informacion("DOFUS", $"Ping: {cliente.ping.get_Promedio_Latencia()} ms"));

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

            await cliente.enviar_Paquete_Async($"BC{id};{bytes}");
            cliente.cuenta.logger.log_Error("ANTI-BOT", $"Se ha revisado el archivo: {archivo}");
        });

        [PaqueteAtributo("gJR")]
        public void get_Rechazar_Invitacion_Gremio(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            Cuenta cuenta = cliente.cuenta;
            cuenta.logger.log_informacion("PERSONAJE", "Invitación al gremio rechazada");
            await cliente.enviar_Paquete_Async("gJE");
        });


        /**
         * var _loc2_ = new Object();
         * var _loc3_ = this.api["\x1e\x18\x06"]["\x1b\x17\x0f"];
         * var _loc4_ = this.api["\x1e\x18\x06"]["\x13\x1a"];
         * var _loc5_ = [_loc3_["\x1b\x04"],_loc3_["\x1b\x03"],
         * _loc3_["\x1b\x02"],_loc3_.AP,_loc3_["\r\x06"],
         * _loc3_["\r\x05"],_loc3_["\x07\x11"],_loc3_["\x07\x10"],
         * _loc3_["\x07\x0f"],_loc3_["\x07\x0e"],_loc3_["\x07\b"],
         * _loc3_["\x07\x05"],_loc3_["\x07\x04"],_loc3_["\x06\x1c"],
         * _loc3_["\x06\x12"],_loc3_["\x06\n"],_loc3_["\x06\t"],
         * _loc3_["\x06\b"],_loc3_["\x06\x06"],_loc3_.canUseObject,
         * _loc3_["\x04\t"],_loc3_["\x04\b"],_loc3_.color1,_loc3_.color2,_loc3_.color3,_loc3_["\x1e\x1b\x05"],
         * _loc3_["\x1e\x19\x16"],_loc3_["\x1e\x19\x0b"],_loc3_["\x1e\x19\x02"],_loc3_["\x1e\x15\n"],
         * _loc3_["\x1e\x0f\x16"],_loc3_["\x1e\x0f\x15"],_loc3_["\x1e\n\x1b"],_loc3_["\x1e\n\x15"],
         * _loc3_.Guild,_loc3_.huntMatchmakingStatus,_loc3_.ID,_loc3_["\x1d\x12\x1d"],_loc3_.inParty,
         * _loc3_["\x1d\x11\x1d"],_loc3_["\x1d\x11\x1c"],_loc3_["\x1d\x10\x0b"],_loc3_["\x1d\x0f\x16"],
         * _loc3_.isCurrentSpellForced,_loc3_.isHuntMatchmakingActive(),_loc3_["\x1d\r\x1d"],_loc3_["\x1d\r\x0f"],
         * _loc3_["\x1d\r\t"],_loc3_["\x1d\r\b"],_loc3_["\x1d\x0b\n"],_loc3_["\x1d\b\x19"],_loc3_.LP,
         * _loc3_["\x1d\x05\x06"],_loc3_["\x1d\x03\x02"],_loc3_["\x1d\x02\x1b"],_loc3_["\x1c\x1c\x12"],_loc3_.MP,
         * _loc3_["\x1c\x19\x18"],_loc3_["\x1b\x13\t"],_loc3_["\x1b\x0e\x16"],_loc3_.Sex,_loc3_.subscriber,
         * _loc3_["\x1a\x10\x15"],_loc3_["\x1a\x04\x15"],_loc3_["\x1a\x04\x14"],_loc3_["\x1a\x03\x11"],
         * _loc3_["\x1a\x03\x10"],_loc3_["\x1a\x02\x17"],_loc3_["\x1a\x02\x16"],_loc3_["\x1a\x02\x15"],
         * _loc3_.zaapToken];
        **/
        [PaqueteAtributo("HT")]
        public void get_TelemetryCallback(ClienteTcp cliente, string paquete) => Task.Run(async () =>
        {
            Cuenta cuenta = cliente.cuenta;
            await cliente.enviar_Paquete_Async("HTSt^md^kd^r`hr^o`r^dmbnqd+^l`hr^st^dr^c");//no legit
        });

    }
}
