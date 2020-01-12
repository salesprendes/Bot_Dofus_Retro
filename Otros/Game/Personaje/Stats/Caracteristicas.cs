/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Otros.Game.Personaje.Stats
{
    public class Caracteristicas : IEliminable
    {
        public double experiencia_actual { get; set; }
        public double experiencia_minima_nivel { get; set; }
        public double experiencia_siguiente_nivel { get; set; }
        public int energia_actual { get; set; }
        public int maxima_energia { get; set; }
        public int vitalidad_actual { get; set; }
        public int vitalidad_maxima { get; set; }
        public StatsBase iniciativa { get; set; }
        public StatsBase prospeccion { get; set; }
        public StatsBase puntos_accion { get; set; }
        public StatsBase puntos_movimiento { get; set; }
        public StatsBase vitalidad { get; set; }
        public StatsBase sabiduria { get; set; }
        public StatsBase fuerza { get; set; }
        public StatsBase inteligencia { get; set; }
        public StatsBase suerte { get; set; }
        public StatsBase agilidad { get; set; }
        public StatsBase alcanze { get; set; }
        public StatsBase criaturas_invocables { get; set; }
        public int porcentaje_vida => vitalidad_maxima == 0 ? 0 : (int)((double)vitalidad_actual / vitalidad_maxima * 100);

        public Caracteristicas()
        {
            iniciativa = new StatsBase(0, 0, 0, 0);
            prospeccion = new StatsBase(0, 0, 0, 0);
            puntos_accion = new StatsBase(0, 0, 0, 0);
            puntos_movimiento = new StatsBase(0, 0, 0, 0);
            vitalidad = new StatsBase(0, 0, 0, 0);
            sabiduria = new StatsBase(0, 0, 0, 0);
            fuerza = new StatsBase(0, 0, 0, 0);
            inteligencia = new StatsBase(0, 0, 0, 0);
            suerte = new StatsBase(0, 0, 0, 0);
            agilidad = new StatsBase(0, 0, 0, 0);
            alcanze = new StatsBase(0, 0, 0, 0);
            criaturas_invocables = new StatsBase(0, 0, 0, 0);
        }

        public void limpiar()
        {
            experiencia_actual = 0;
            experiencia_minima_nivel = 0;
            experiencia_siguiente_nivel = 0;
            energia_actual = 0;
            maxima_energia = 0;
            vitalidad_actual = 0;
            vitalidad_maxima = 0;

            iniciativa.limpiar();
            prospeccion.limpiar();
            puntos_accion.limpiar();
            puntos_movimiento.limpiar();
            vitalidad.limpiar();
            sabiduria.limpiar();
            fuerza.limpiar();
            inteligencia.limpiar();
            suerte.limpiar();
            agilidad.limpiar();
            alcanze.limpiar();
            criaturas_invocables.limpiar();
        }
    }
}
