using System;
using System.Collections.Generic;
using System.Linq;

namespace Bot_Dofus_Retro.Comun.Network
{
    public class Ping
    {
        private readonly List<int> latencia;
        private const int maximas_latencias = 50;
        private int ticks;

        public Ping()
        {
            latencia = new List<int>();
            ticks = 0;
        }

        public int get_Total_Pings() => latencia.Count();
        public void set_ticks() => ticks = Environment.TickCount;
        public int get_maximas_latencias() => maximas_latencias;

        public int get_Promedio_Latencia()
        {
            if (latencia.Count == 0)
                return 0;

            int latencia_total = latencia.Aggregate(0, (actual, latencia) => actual + latencia);
            return latencia_total / latencia.Count;
        }

        public void set_Agregar_Latencia()
        {
            int _ticks = Environment.TickCount;

            if (ticks == 0) return;

            latencia.Add(_ticks - ticks);
            ticks = 0;

            if (latencia.Count > maximas_latencias)
                latencia.RemoveAt(0);
        }
    }
}
