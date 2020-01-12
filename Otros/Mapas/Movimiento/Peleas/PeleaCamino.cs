using System.Collections.Generic;

namespace Bot_Dofus_Retro.Otros.Mapas.Movimiento.Peleas
{
    public class PeleaCamino
    {
        public List<short> celdas_accesibles { get; set; }
        public List<short> celdas_inalcanzables { get; set; }
        public Dictionary<short, int> mapa_celdas_alcanzables { get; set; }
        public Dictionary<short, int> mapa_celdas_inalcanzable { get; set; }
    }
}
