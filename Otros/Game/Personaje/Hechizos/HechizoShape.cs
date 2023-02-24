using Bot_Dofus_Retro.Otros.Mapas;
using System.Collections.Generic;

namespace Bot_Dofus_Retro.Otros.Game.Personaje.Hechizos
{
    public class HechizoShape
    {
        public static IEnumerable<Celda> Get_Lista_Celdas_Rango_Hechizo(Celda celda, HechizoStats hechizo_stats, Mapa mapa, int rango_adicional = 0)
        {
            int rango_maximo = hechizo_stats.alcanze_maximo + (hechizo_stats.es_alcanze_modificable ? rango_adicional : 0);

            if (hechizo_stats.es_lanzado_linea)
                return Shaper.Cruz(celda.x, celda.y, hechizo_stats.alcanze_minimo, rango_maximo, mapa);
            else
                return Shaper.Anillo(celda.x, celda.y, hechizo_stats.alcanze_minimo, rango_maximo, mapa);
        }

        public static List<Celda> get_Celdas_Afectadas_Area(Mapa mapa, HechizoStats hechizo_stats, Celda celda_jugador, Celda celda_objetivo)
        {
            List<Celda> zona = new List<Celda>();
            Zonas efecto = hechizo_stats.efectos_normales[0].zona_efecto;
            ShaperEntry shaper = Shaper.ShaperMap[efecto.tipo];

            if (shaper == null)
            {
                zona.Add(celda_objetivo);
                return zona;
            }

            int x = 0, y = 0;
            if (shaper.tiene_direccion)//lanzados en diagonal, linea recta
            {
                x = celda_objetivo.x == celda_jugador.x ? 0 : celda_objetivo.x > celda_jugador.x ? 1 : -1;
                y = celda_objetivo.y == celda_jugador.y ? 0 : celda_objetivo.y > celda_jugador.y ? 1 : -1;
            }

            IEnumerable<Celda> rango_celdas = shaper.Fn(celda_objetivo.x, celda_objetivo.y, 0, efecto.tamano, mapa, x, y);

            foreach (Celda celda in rango_celdas)
            {
                if (!zona.Contains(celda) && celda.es_Caminable())
                    zona.Add(celda);
            }

            return zona;
        }
    }
}
