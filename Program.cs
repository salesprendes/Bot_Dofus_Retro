using Bot_Dofus_Retro.Comun.Frames.Transporte;
using Bot_Dofus_Retro.Otros.Game.Personaje.Hechizos;
using Bot_Dofus_Retro.Otros.Mapas.Interactivo;
using Bot_Dofus_Retro.Otros.Scripts.Manejadores;
using Bot_Dofus_Retro.Tema.Forms;
using Bot_Dofus_Retro.Utilidades.Configuracion;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

/*
    Este archivo es parte del proyecto Bot Dofus Retro
    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Task.Run(() =>
            {
                GlobalConf.cargar();
                LuaManejadorScript.inicializar_Funciones();
                XElement.Parse(Properties.Resources.interactivos).Descendants("SKILL").ToList().ForEach(i => new ObjetoInteractivoModelo(i.Element("nombre").Value, i.Element("gfx").Value, bool.Parse(i.Element("caminable").Value), i.Element("habilidades").Value, bool.Parse(i.Element("recolectable").Value)));
                PaqueteRecibido.Inicializar();
            }).ContinueWith(t =>
            {
                XElement.Parse(Properties.Resources.lista_hechizos).Descendants("HECHIZO").ToList().ForEach(mapa =>
                {
                    Hechizo hechizo = new Hechizo(short.Parse(mapa.Attribute("ID").Value), mapa.Element("NOMBRE").Value);

                    mapa.Descendants("NIVEL").ToList().ForEach(stats =>
                    {
                        HechizoStats hechizo_stats = new HechizoStats
                        {
                            coste_pa = byte.Parse(stats.Attribute("COSTE_PA").Value),
                            alcanze_minimo = byte.Parse(stats.Attribute("RANGO_MINIMO").Value),
                            alcanze_maximo = byte.Parse(stats.Attribute("RANGO_MAXIMO").Value),

                            es_lanzado_linea = bool.Parse(stats.Attribute("LANZ_EN_LINEA").Value),
                            es_lanzado_con_vision = bool.Parse(stats.Attribute("NECESITA_VISION").Value),
                            necesita_celda_libre = bool.Parse(stats.Attribute("NECESITA_CELDA_LIBRE").Value),
                            es_alcanze_modificable = bool.Parse(stats.Attribute("RANGO_MODIFICABLE").Value),

                            lanzamientos_por_turno = byte.Parse(stats.Attribute("MAX_LANZ_POR_TURNO").Value),
                            lanzamientos_por_objetivo = byte.Parse(stats.Attribute("MAX_LANZ_POR_OBJETIVO").Value),
                            intervalo = byte.Parse(stats.Attribute("COOLDOWN").Value)
                        };

                        stats.Descendants("EFECTO").ToList().ForEach(efecto => hechizo_stats.agregar_efecto(new HechizoEfecto(int.Parse(efecto.Attribute("TIPO").Value), Zonas.analizar(efecto.Attribute("ZONA").Value)), bool.Parse(efecto.Attribute("ES_CRITICO").Value)));
                        hechizo.get_Agregar_Hechizo_Stats(byte.Parse(stats.Attribute("NIVEL").Value), hechizo_stats);
                    });
                });
            }).Wait();

            Application.Run(new Principal());
        }
    }
}