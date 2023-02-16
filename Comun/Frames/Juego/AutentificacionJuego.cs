using Bot_Dofus_Retro.Comun.Frames.Transporte;
using Bot_Dofus_Retro.Comun.Network;
using Bot_Dofus_Retro.Otros;
using System.Threading.Tasks;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2023 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Comun.Frames.Juego
{
    public class AutentificacionJuego : Frame
    {
        [PaqueteAtributo("AXEf")]
        public Task get_Error_Servidor_Completo_No_Abonado(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            cliente.cuenta.logger.log_Error("Login", "Servidor completo y el acesso no esta disponible para cuentas sin abonar.");
            cliente.cuenta.desconectar();
        });

        [PaqueteAtributo("M030")]
        public Task get_Error_Streaming(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            cliente.cuenta.logger.log_Error("Login", "Conexión rechazada. No se te ha podido autentificar para este servidor porque tu conexión ha caducado. Asegúrate de cortar las descargas, así como la música o los vídeos en difusión continua (streaming), para mejorar la calidad y la velocidad de tu conexión.");
            cliente.cuenta.desconectar();
        });

        [PaqueteAtributo("M031")]
        public Task get_Error_Red(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            cliente.cuenta.logger.log_Error("Login", "Conexión rechazada. El servidor del juego no ha recibido las informaciones de autentificación necesarias tras tu identificación. Por favor, vuelve a intentarlo otra vez y, si el problema persiste, contacta con tu administrador de redes o con tu servidor de acceso a Internet. Se trata de un problema de re-dirección debido a una mala configuración DNS.");
            cliente.cuenta.desconectar();
        });

        [PaqueteAtributo("M032")]
        public Task get_Error_Flood_Conexion(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_Error("Login", "Para no ocasionar molestias al resto de jugadores, espera %1 segundos antes de volver a conectarte."));

        [PaqueteAtributo("M132")]
        public Task get_Tiempo_Espera_Pelea(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            Cuenta cuenta = cliente.cuenta;
            string[] separador = paquete.Substring(1).Split('|');
            int delay = int.Parse(separador[1]);

            cuenta.logger.log_Error("SERVIDOR", $"Esperando {delay} segundos para continuar el juego");
        });
    }
}
