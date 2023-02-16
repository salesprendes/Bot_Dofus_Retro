using System;
using System.Collections.Generic;
using System.Linq;

namespace Bot_Dofus_Retro.Comun.Network
{
    public class Ping
    {
        private List<int> pings { get; set; }
        private int ticks;

        public Ping()
        {
            pings = new List<int>(50);
            ticks = 0;
        }

        public int get_Total_Pings() => pings.Count();
        public int get_Actual_Ping() => Environment.TickCount - ticks;

        public int get_Promedio_Pings()
        {
            int total_pings = 0, contador = 0;
            while (contador < pings.Count)
            {
                total_pings += pings[contador];
                contador++;
            }
            return total_pings / pings.Count;
        }

        public void set_Actualizar()
        {
            pings.Add(get_Actual_Ping());
            if (pings.Count > 48)
                pings.Clear();
        }
    }
}
