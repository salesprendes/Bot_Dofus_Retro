/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/
namespace Bot_Dofus_Retro.Otros.Mapas.Movimiento.Mapas
{
    internal class DuracionAnimacion
    {
        public int lineal { get; private set; }
        public int horizontal { get; private set; }
        public int vertical { get; private set; }

        public DuracionAnimacion(int _lineal, int _horizontal, int _vertical)
        {
            lineal = _lineal;
            horizontal = _horizontal;
            vertical = _vertical;
        }
    }
}
