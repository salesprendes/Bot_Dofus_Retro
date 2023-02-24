using Bot_Dofus_Retro.Comun.Frames.Transporte;
using Bot_Dofus_Retro.Comun.Network;
using System.Threading.Tasks;

namespace Bot_Dofus_Retro.Comun.Frames.Juego
{
    public class ChatFrame : Frame
    {
        [PaqueteAtributo("cC+")]
        public Task get_Agregar_Canal(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.juego.personaje.agregar_Canal_Personaje(paquete.Substring(3)));

        [PaqueteAtributo("cC-")]
        public Task get_Eliminar_Canal(ClienteTcp cliente, string paquete) => Task.Run(() => cliente.cuenta.juego.personaje.eliminar_Canal_Personaje(paquete.Substring(3)));

        [PaqueteAtributo("cMK")]
        public Task get_Mensajes_Chat(ClienteTcp cliente, string paquete) => Task.Run(() =>
        {
            string[] separador = paquete.Substring(3).Split('|');
            string canal = string.Empty;

            switch (separador[0])
            {
                case "?":
                    canal = "RECLUTAMIENTO";
                    break;

                case ":":
                    canal = "COMERCIO";
                    break;

                case "e":
                    canal = "EVENTO";
                    break;

                case "i":
                    canal = "INFORMACIÓN";
                    break;

                case "#":
                    canal = "EQUIPO";
                    break;

                case "$":
                    canal = "GRUPO";
                    break;

                case "%":
                    canal = "GREMIO";
                    break;

                case "F":
                    cliente.cuenta.logger.log_privado("RECIBIDO-PRIVADO", separador[2] + ": " + separador[3]);
                    break;

                case "T":
                    cliente.cuenta.logger.log_privado("ENVIADO-PRIVADO", separador[2] + ": " + separador[3]);
                    break;

                case "*":
                default:
                    canal = "GENERAL";
                    break;
            }

            if (!canal.Equals(string.Empty))
                cliente.cuenta.logger.log_normal(canal, separador[2] + ": " + separador[3]);
        });
    }
}
