/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Otros.Game.Personaje.Stats
{
    public class StatsBase : IEliminable
    {
        public int base_personaje { get; set; }
        public int equipamiento { get; set; }
        public int dones { get; set; }
        public int boost { get; set; }

        public StatsBase(int _base_personaje) => base_personaje = _base_personaje;
        public StatsBase(int _base_personaje, int _equipamiento, int _dones, int _boost) => actualizar_Stats(_base_personaje, _equipamiento, _dones, _boost);
        public int total_stats => base_personaje + equipamiento + dones + boost;

        public void actualizar_Stats(int _base_personaje, int _equipamiento, int _dones, int _boost)
        {
            base_personaje = _base_personaje;
            equipamiento = _equipamiento;
            dones = _dones;
            boost = _boost;
        }

        public void limpiar()
        {
            base_personaje = 0;
            equipamiento = 0;
            dones = 0;
            boost = 0;
        }
    }
}
