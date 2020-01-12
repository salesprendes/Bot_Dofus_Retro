/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

using Bot_Dofus_Retro.Otros.Enums;

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

		public int get_Capital_Necesario_Boost_Stats(byte id_raza, StatsBoosteables id_stat)
		{
			switch (id_stat)
			{
				case StatsBoosteables.VITALIDAD://Vitalidad
					return 1;

				case StatsBoosteables.SABIDURIA://Sabiduria
					return 3;

				case StatsBoosteables.FUERZA://Fuerza
					switch (id_raza)
					{
						case 1:
							if (fuerza.base_personaje < 50)
								return 2;
							if (fuerza.base_personaje < 150)
								return 3;
							if (fuerza.base_personaje < 250)
								return 4;
							return 5;

						case 11:
							return 3;

						case 5:
							if (fuerza.base_personaje < 50)
								return 2;
							if (fuerza.base_personaje < 150)
								return 3;
							if (fuerza.base_personaje < 250)
								return 4;
							return 5;

						case 4:
							if (fuerza.base_personaje < 100)
								return 1;
							if (fuerza.base_personaje < 200)
								return 2;
							if (fuerza.base_personaje < 300)
								return 3;
							if (fuerza.base_personaje < 400)
								return 4;
							return 5;

						case 2:
							if (fuerza.base_personaje < 50)
								return 2;
							if (fuerza.base_personaje < 150)
								return 3;
							if (fuerza.base_personaje < 250)
								return 4;
							return 5;

						case 7:
							if (fuerza.base_personaje < 50)
								return 2;
							if (fuerza.base_personaje < 150)
								return 3;
							if (fuerza.base_personaje < 250)
								return 4;
							return 5;

						case 12:
							if (fuerza.base_personaje < 50)
								return 1;
							if (fuerza.base_personaje < 200)
								return 2;
							return 3;

						case 10:
							if (fuerza.base_personaje < 50)
								return 1;
							if (fuerza.base_personaje < 250)
								return 2;
							if (fuerza.base_personaje < 300)
								return 3;
							if (fuerza.base_personaje < 400)
								return 4;
							return 5;

						case 9:
							if (fuerza.base_personaje < 50)
								return 1;
							if (fuerza.base_personaje < 150)
								return 2;
							if (fuerza.base_personaje < 250)
								return 3;
							if (fuerza.base_personaje < 350)
								return 4;
							return 5;

						case 3:
							if (fuerza.base_personaje < 50)
								return 1;
							if (fuerza.base_personaje < 150)
								return 2;
							if (fuerza.base_personaje < 250)
								return 3;
							if (fuerza.base_personaje < 350)
								return 4;
							return 5;

						case 6:
							if (fuerza.base_personaje < 100)
								return 1;
							if (fuerza.base_personaje < 200)
								return 2;
							if (fuerza.base_personaje < 300)
								return 3;
							if (fuerza.base_personaje < 400)
								return 4;
							return 5;

						case 8:
							if (fuerza.base_personaje < 100)
								return 1;
							if (fuerza.base_personaje < 200)
								return 2;
							if (fuerza.base_personaje < 300)
								return 3;
							if (fuerza.base_personaje < 400)
								return 4;
							return 5;

					}
					break;

				case StatsBoosteables.SUERTE://Suerte
					switch (id_raza)
					{
						case 1:
							if (suerte.base_personaje < 20)
								return 1;
							if (suerte.base_personaje < 40)
								return 2;
							if (suerte.base_personaje < 60)
								return 3;
							if (suerte.base_personaje < 80)
								return 4;
							return 5;

						case 5:
							if (suerte.base_personaje < 20)
								return 1;
							if (suerte.base_personaje < 40)
								return 2;
							if (suerte.base_personaje < 60)
								return 3;
							if (suerte.base_personaje < 80)
								return 4;
							return 5;

						case 11:
							return 3;

						case 4:
							if (suerte.base_personaje < 20)
								return 1;
							if (suerte.base_personaje < 40)
								return 2;
							if (suerte.base_personaje < 60)
								return 3;
							if (suerte.base_personaje < 80)
								return 4;
							return 5;

						case 10:
							if (suerte.base_personaje < 100)
								return 1;
							if (suerte.base_personaje < 200)
								return 2;
							if (suerte.base_personaje < 300)
								return 3;
							if (suerte.base_personaje < 400)
								return 4;
							return 5;

						case 12:
							if (suerte.base_personaje < 50)
								return 1;
							if (suerte.base_personaje < 200)
								return 2;
							return 3;

						case 8:
							if (suerte.base_personaje < 20)
								return 1;
							if (suerte.base_personaje < 40)
								return 2;
							if (suerte.base_personaje < 60)
								return 3;
							if (suerte.base_personaje < 80)
								return 4;
							return 5;

						case 3:
							if (suerte.base_personaje < 100)
								return 1;
							if (suerte.base_personaje < 150)
								return 2;
							if (suerte.base_personaje < 230)
								return 3;
							if (suerte.base_personaje < 330)
								return 4;
							return 5;

						case 2:
							if (suerte.base_personaje < 100)
								return 1;
							if (suerte.base_personaje < 200)
								return 2;
							if (suerte.base_personaje < 300)
								return 3;
							if (suerte.base_personaje < 400)
								return 4;
							return 5;

						case 6:
							if (suerte.base_personaje < 20)
								return 1;
							if (suerte.base_personaje < 40)
								return 2;
							if (suerte.base_personaje < 60)
								return 3;
							if (suerte.base_personaje < 80)
								return 4;
							return 5;

						case 7:
							if (suerte.base_personaje < 20)
								return 1;
							if (suerte.base_personaje < 40)
								return 2;
							if (suerte.base_personaje < 60)
								return 3;
							if (suerte.base_personaje < 80)
								return 4;
							return 5;

						case 9:
							if (suerte.base_personaje < 20)
								return 1;
							if (suerte.base_personaje < 40)
								return 2;
							if (suerte.base_personaje < 60)
								return 3;
							if (suerte.base_personaje < 80)
								return 4;
							return 5;
					}
					break;

				case StatsBoosteables.AGILIDAD://Agilidad
					switch (id_raza)
					{
						case 1:
							if (agilidad.base_personaje < 20)
								return 1;
							if (agilidad.base_personaje < 40)
								return 2;
							if (agilidad.base_personaje < 60)
								return 3;
							if (agilidad.base_personaje < 80)
								return 4;
							return 5;

						case 5:
							if (agilidad.base_personaje < 20)
								return 1;
							if (agilidad.base_personaje < 40)
								return 2;
							if (agilidad.base_personaje < 60)
								return 3;
							if (agilidad.base_personaje < 80)
								return 4;
							return 5;

						case 11:
							return 3;

						case 4:
							if (agilidad.base_personaje < 100)
								return 1;
							if (agilidad.base_personaje < 200)
								return 2;
							if (agilidad.base_personaje < 300)
								return 3;
							if (agilidad.base_personaje < 400)
								return 4;
							return 5;

						case 10:
							if (agilidad.base_personaje < 20)
								return 1;
							if (agilidad.base_personaje < 40)
								return 2;
							if (agilidad.base_personaje < 60)
								return 3;
							if (agilidad.base_personaje < 80)
								return 4;
							return 5;

						case 12:
							if (agilidad.base_personaje < 50)
								return 1;
							if (agilidad.base_personaje < 200)
								return 2;
							return 3;

						case 7:
							if (agilidad.base_personaje < 20)
								return 1;
							if (agilidad.base_personaje < 40)
								return 2;
							if (agilidad.base_personaje < 60)
								return 3;
							if (agilidad.base_personaje < 80)
								return 4;
							return 5;

						case 8:
							if (agilidad.base_personaje < 20)
								return 1;
							if (agilidad.base_personaje < 40)
								return 2;
							if (agilidad.base_personaje < 60)
								return 3;
							if (agilidad.base_personaje < 80)
								return 4;
							return 5;

						case 3:
							if (agilidad.base_personaje < 20)
								return 1;
							if (agilidad.base_personaje < 40)
								return 2;
							if (agilidad.base_personaje < 60)
								return 3;
							if (agilidad.base_personaje < 80)
								return 4;
							return 5;

						case 6:
							if (agilidad.base_personaje < 50)
								return 1;
							if (agilidad.base_personaje < 100)
								return 2;
							if (agilidad.base_personaje < 150)
								return 3;
							if (agilidad.base_personaje < 200)
								return 4;
							return 5;

						case 9:
							if (agilidad.base_personaje < 50)
								return 1;
							if (agilidad.base_personaje < 100)
								return 2;
							if (agilidad.base_personaje < 150)
								return 3;
							if (agilidad.base_personaje < 200)
								return 4;
							return 5;

						case 2:
							if (agilidad.base_personaje < 20)
								return 1;
							if (agilidad.base_personaje < 40)
								return 2;
							if (agilidad.base_personaje < 60)
								return 3;
							if (agilidad.base_personaje < 80)
								return 4;
							return 5;
					}
					break;

				case StatsBoosteables.INTELIGENCIA://Inteligencia
					switch (id_raza)
					{
						case 5:
							if (inteligencia.base_personaje < 100)
								return 1;
							if (inteligencia.base_personaje < 200)
								return 2;
							if (inteligencia.base_personaje < 300)
								return 3;
							if (inteligencia.base_personaje < 400)
								return 4;
							return 5;

						case 1:
							if (inteligencia.base_personaje < 100)
								return 1;
							if (inteligencia.base_personaje < 200)
								return 2;
							if (inteligencia.base_personaje < 300)
								return 3;
							if (inteligencia.base_personaje < 400)
								return 4;
							return 5;

						case 11:
							return 3;

						case 4:
							if (inteligencia.base_personaje < 50)
								return 2;
							if (inteligencia.base_personaje < 150)
								return 3;
							if (inteligencia.base_personaje < 250)
								return 4;
							return 5;

						case 10:
							if (inteligencia.base_personaje < 100)
								return 1;
							if (inteligencia.base_personaje < 200)
								return 2;
							if (inteligencia.base_personaje < 300)
								return 3;
							if (inteligencia.base_personaje < 400)
								return 4;
							return 5;

						case 3:
							if (inteligencia.base_personaje < 20)
								return 1;
							if (inteligencia.base_personaje < 60)
								return 2;
							if (inteligencia.base_personaje < 100)
								return 3;
							if (inteligencia.base_personaje < 140)
								return 4;
							return 5;

						case 12:
							if (inteligencia.base_personaje < 50)
								return 1;
							if (inteligencia.base_personaje < 200)
								return 2;
							return 3;

						case 8:
							if (inteligencia.base_personaje < 20)
								return 1;
							if (inteligencia.base_personaje < 40)
								return 2;
							if (inteligencia.base_personaje < 60)
								return 3;
							if (inteligencia.base_personaje < 80)
								return 4;
							return 5;

						case 7:
							if (inteligencia.base_personaje < 100)
								return 1;
							if (inteligencia.base_personaje < 200)
								return 2;
							if (inteligencia.base_personaje < 300)
								return 3;
							if (inteligencia.base_personaje < 400)
								return 4;
							return 5;

						case 9:
							if (inteligencia.base_personaje < 50)
								return 1;
							if (inteligencia.base_personaje < 150)
								return 2;
							if (inteligencia.base_personaje < 250)
								return 3;
							if (inteligencia.base_personaje < 350)
								return 4;
							return 5;

						case 2:
							if (inteligencia.base_personaje < 100)
								return 1;
							if (inteligencia.base_personaje < 200)
								return 2;
							if (inteligencia.base_personaje < 300)
								return 3;
							if (inteligencia.base_personaje < 400)
								return 4;
							return 5;

						case 6:
							if (inteligencia.base_personaje < 20)
								return 1;
							if (inteligencia.base_personaje < 40)
								return 2;
							if (inteligencia.base_personaje < 60)
								return 3;
							if (inteligencia.base_personaje < 80)
								return 4;
							return 5;
					}
					break;
			}
			return 5;
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
