using Bot_Dofus_Retro.Utilidades.Criptografia;
using System.IO;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2023 Alvaro Prendes — Todos los derechos reservados.
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

        public void guardar_Cuenta(BinaryWriter bw)
        {
            bw.Write(nombre_cuenta);
            bw.Write(AESEncriptacion.Encriptar(password, "$AideMu$"));
            bw.Write(servidor);
            bw.Write(nombre_personaje);
        }

        public static CuentaConf cargar_Cuenta(BinaryReader br)
        {
            try
            {
                return new CuentaConf(br.ReadString(), AESEncriptacion.Desencriptar(br.ReadString(), "$AideMu$"), br.ReadString(), br.ReadString());
            }
            catch
            {
                return null;
            }
        }

        public string get_Servidor_Nombre(int servidor_id)
        {
            switch (servidor_id)
            {
                case 601:
                    return "Eratz";

                case 602:
                    return "Henual";

                case 612:
                    return "Bun";

                case 613:
                    return "Crail";

                case 614:
                    return "Gálgarion";
            }

            return string.Empty;
        }
    }
}
