using Bot_Dofus_Retro.Comun.Frames.Transporte;
using Bot_Dofus_Retro.Comun.Network;
using System.Text;
using System.Threading.Tasks;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Comun.Frames.Autentificacion
{
    class AutentificacionLogin : Frame
    {
        [PaqueteAtributo("AlEf")]
        public Task get_Error_Datos(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_Error("LOGIN", "Conexión rechazada. Nombre de cuenta o contraseña incorrectos."));

        [PaqueteAtributo("AlEa")]
        public Task get_Error_Ya_Conectado(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_Error("LOGIN", "Ya conectado. Inténtalo de nuevo."));

        [PaqueteAtributo("AlEv")]
        public Task get_Error_Version(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_Error("LOGIN", "La versión %1 de Dofus que tienes instalada no es compatible con este servidor. Para poder jugar, instala la versión %2. El cliente DOFUS se va a cerrar."));

        [PaqueteAtributo("AlEb")]
        public Task get_Error_Baneado(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_Error("LOGIN", "Conexión rechazada. Tu cuenta ha sido baneada."));

        [PaqueteAtributo("AlEd")]
        public Task get_Error_Conectado(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_Error("LOGIN", "Esta cuenta ya está conectada a un servidor de juego. Por favor, inténtalo de nuevo."));

        [PaqueteAtributo("AlEk")]
        public Task get_Error_Baneado_Tiempo(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            string[] informacion_ban = paquete.Substring(3).Split('|');
            int dias = int.Parse(informacion_ban[0].Substring(1)), horas = int.Parse(informacion_ban[1]), minutos = int.Parse(informacion_ban[2]);
            StringBuilder mensaje = new StringBuilder().Append("Tu cuenta estará inválida durante ");

            if (dias > 0)
                mensaje.Append(dias + " días");
            if (horas > 0)
                mensaje.Append(horas + " con horas");
            if (minutos > 0)
                mensaje.Append(minutos + " y minutos");

            cliente.cuenta.logger.log_Error("LOGIN", mensaje.ToString());
        });

        [PaqueteAtributo("M013")]
        public Task get_Error_Servidor_Mantenimiento(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_Error("LOGIN", "El servidor esta en mantenimiento"));
    }
}
