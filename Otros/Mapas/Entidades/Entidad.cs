using System;

namespace Bot_Dofus_Retro.Otros.Mapas.Entidades
{
    public interface Entidad : IDisposable
    {
        int id { get; set; }
        Celda celda { get; set; }
    }
}