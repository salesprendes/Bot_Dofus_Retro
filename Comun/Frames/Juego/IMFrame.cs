using Bot_Dofus_Retro.Comun.Frames.Transporte;
using Bot_Dofus_Retro.Comun.Network;
using System.Threading.Tasks;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Comun.Frames.Juego
{
    public class IMFrame : Frame
    {
        [PaqueteAtributo("Im189")]
        public Task get_Bienvenida_Dofus(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_Error("DOFUS", "¡Bienvenido(a) a DOFUS, el Mundo de los Doce! Atención: Está prohibido comunicar tu usuario de cuenta y tu contraseña."));

        [PaqueteAtributo("Im039")]
        public Task get_Espectador_Desactivado(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_informacion("COMBATE", "El modo Espectador está desactivado."));

        [PaqueteAtributo("Im040")]
        public Task get_Espectador_Activado(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_informacion("COMBATE", "El modo Espectador está activado."));

        [PaqueteAtributo("Im0152")]
        public Task get_Ultima_Conexion_IP(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            string mensaje = paquete.Split(';')[1];
            cliente.cuenta.logger.log_informacion("DOFUS", "Última conexión a tu cuenta realizada el " + mensaje.Split('~')[0] + "/" + mensaje.Split('~')[1] + "/" + mensaje.Split('~')[2] + " a las " + mensaje.Split('~')[3] + ":" + mensaje.Split('~')[4] + " mediante la dirección IP " + mensaje.Split('~')[5]);
        });

        [PaqueteAtributo("Im0153")]
        public Task get_Nueva_Conexion_IP(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_informacion("DOFUS", "Tu dirección IP actual es " + paquete.Substring(3).Split(';')[1]));

        [PaqueteAtributo("Im020")]
        public Task get_Abrir_Cofre_Perder_Kamas(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_informacion("DOFUS", "Has tenido que dar " + paquete.Split(';')[1] + " kamas para poder acceder a este cofre."));

        [PaqueteAtributo("Im025")]
        public Task get_Mascota_Feliz(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_informacion("DOFUS", "¡Tu mascota está muy contenta de volver a verte!"));

        [PaqueteAtributo("Im0157")]
        public Task get_Chat_Difusion(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_informacion("DOFUS", "Este canal no tiene la difusión accesible más que a los abonados de nivel " + paquete.Split(';')[1]));

        [PaqueteAtributo("Im037")]
        public Task get_Modo_Away_Dofus(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_informacion("DOFUS", "Desde ahora serás considerado como ausente."));

        [PaqueteAtributo("Im06")]
        public Task get_Zaap_Posicion_Guardada(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_informacion("DOFUS", "Posición guardada."));

        [PaqueteAtributo("Im112")]
        public Task get_Pods_Llenos(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_Error("DOFUS", "Estás demasiado cargado. Tira algunos objetos para poder moverte."));

        [PaqueteAtributo("Im1170")]
        public Task get_Error_Alcanze_Hchizo(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            string mensaje = paquete.Split(';')[1];
            cliente.cuenta.logger.log_Error("DOFUS", $"Imposible lanzar el hechizo: Tienes {mensaje.Split('~')[0]} PA disponible(s) ¡Pero necesitas {mensaje.Split('~')[1]} para poder lanzar este hechizo!");
        });

        [PaqueteAtributo("Im1171")]
        public Task get_Error_Alcanze_Hechizo(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            string mensaje = paquete.Split(';')[1];
            cliente.cuenta.logger.log_Error("DOFUS", $"Imposible lanzar el hechizo: Tienes un alcance de {mensaje.Split('~')[0]} a {mensaje.Split('~')[1]} ¡Pero estás apuntando a {mensaje.Split('~')[2]}!");
        });

        [PaqueteAtributo("Im1175")]
        public Task get_Error_Lanzar_Hechizo(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.logger.log_Error("DOFUS", "Imposible lanzar el hechizo actualmente."));
    }
}
