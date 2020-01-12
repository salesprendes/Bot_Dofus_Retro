using Bot_Dofus_Retro.Utilidades.Criptografia;
using System.IO;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
	Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Utilidades.Configuracion
{
    public class CuentaConf
    {
        public string nombre_cuenta { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string servidor { get; set; } = string.Empty;
        public string nombre_personaje { get; set; } = string.Empty;

        public CuentaConf(string _nombre_cuenta, string _password, string _servidor, string _nombre_personaje)
        {
            nombre_cuenta = _nombre_cuenta;
            password = _password;
            servidor = _servidor;
            nombre_personaje = _nombre_personaje;
        }

        public void guardar_Cuenta(BinaryWriter bw, string pass_encriptacion)
        {
            bw.Write(nombre_cuenta);
            bw.Write(AESEncriptacion.Encriptar(password, pass_encriptacion));
            bw.Write(servidor);
            bw.Write(nombre_personaje);
        }

        public static CuentaConf cargar_Cuenta(BinaryReader br, string pass_encriptacion)
        {
            try
            {
                return new CuentaConf(br.ReadString(), AESEncriptacion.Desencriptar(br.ReadString(), pass_encriptacion), br.ReadString(), br.ReadString());
            }
            catch
            {
                return null;
            }
        }

        public string get_Servidor_Nombre(int _servidor_id)
        {
            switch (_servidor_id)
            {
                case 601:
                    return "Eratz";

                case 602:
                    return "Henual";

                case 603:
                    return "Nabur";

                case 604:
                    return "Arty";

                case 605:
                    return "Algata";

                case 606:
                    return "Hogmeiser";

                case 607:
                    return "Droopica";

                case 608:
                    return "Ayuto";

                case 609:
                    return "Bilby";

                case 610:
                    return "Clustus";

                case 611:
                    return "Sinserrin";
            }

            return string.Empty;
        }
    }
}
