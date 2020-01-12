using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Utilidades.Configuracion
{
    public static class GlobalConf
    {
        private static List<CuentaConf> lista_cuentas = new List<CuentaConf>();
        private static readonly string ruta_archivo_cuentas = Path.Combine(Directory.GetCurrentDirectory(), "cuentas.bot");
        public static bool mostrar_mensajes_debug { get; set; } = false;
        public static string ip_conexion = "34.251.172.139", version_dofus = "1.30.14";
        public static short puerto_conexion = 443;
        public static int peso_core = 2528660, peso_loader = 2362079;

        public static void cargar()
        {
            if (!File.Exists(ruta_archivo_cuentas))
                return;

            lista_cuentas.Clear();
            using (BinaryReader br = new BinaryReader(File.Open(ruta_archivo_cuentas, FileMode.Open)))
            {
                int registros_totales = br.ReadInt32();

                for (int i = 0; i < registros_totales; i++)
                    lista_cuentas.Add(CuentaConf.cargar_Cuenta(br));

                mostrar_mensajes_debug = br.ReadBoolean();
                ip_conexion = br.ReadString();
                puerto_conexion = br.ReadInt16();
                peso_core = br.ReadInt32();
                peso_loader = br.ReadInt32();
            }
        }

        public static void guardar()
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(ruta_archivo_cuentas, FileMode.Create)))
            {
                bw.Write(lista_cuentas.Count);
                lista_cuentas.ForEach(a => a.guardar_Cuenta(bw));
                bw.Write(mostrar_mensajes_debug);
                bw.Write(ip_conexion);
                bw.Write(puerto_conexion);
                bw.Write(peso_core);
                bw.Write(peso_loader);
            }
        }

        public static void agregar_Cuenta(string nombre_cuenta, string password, string servidor, string nombre_personaje) => lista_cuentas.Add(new CuentaConf(nombre_cuenta, password, servidor, nombre_personaje));
        public static void eliminar_Cuenta(CuentaConf cuenta_conf) => lista_cuentas.Remove(cuenta_conf);
        public static CuentaConf get_Cuenta(string nombre_cuenta) => lista_cuentas.FirstOrDefault(cuenta => cuenta.nombre_cuenta == nombre_cuenta);
        public static CuentaConf get_Cuenta(int cuenta_index) => lista_cuentas.ElementAt(cuenta_index);
        public static List<CuentaConf> get_Cuentas() => lista_cuentas;
    }
}
