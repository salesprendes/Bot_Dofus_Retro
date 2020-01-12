using Bot_Dofus_Retro.Otros.Mapas;

namespace Bot_Dofus_Retro.Otros.Peleas.Peleadores
{
    public class Luchadores
    {
        public int id { get; set; }
        public Celda celda { get; set; }
        public byte equipo { get; set; }
        public bool esta_vivo { get; set; }
        public int vida_actual { get; set; }
        public int vida_maxima { get; set; }
        public byte pa { get; set; }
        public byte pm { get; set; }
        public int id_invocador { get; set; }
        public bool es_invocacion { get; set; }
        public int porcentaje_vida => (int)((double)vida_actual / vida_maxima) / 100;

        public Luchadores(int _id, bool _esta_vivo, int _vida_actual, byte _pa, byte _pm, Celda _celda, int _vida_maxima, byte _equipo, int _id_invocador, bool _es_invocacion)
        {
            id = _id;
            esta_vivo = _esta_vivo;
            vida_actual = _vida_actual;
            pa = _pa;
            pm = _pm;
            celda = _celda;
            vida_maxima = _vida_maxima;
            equipo = _equipo;
            id_invocador = _id_invocador;
            es_invocacion = _es_invocacion;
        }

        public void get_Actualizar_Puntos_Pelea(int _id_accion, string _valor)
        {
            switch (_id_accion)
            {
                /** Perdida de vida **/
                case 100:
                    byte vida_perdida = byte.Parse(_valor.Substring(1));
                    vida_actual -= vida_perdida;
                break;

                /** Ganancia de vida **/
                case 108:
                case 110:
                    byte vida_ganada = byte.Parse(_valor);
                    vida_actual += vida_ganada;
                    if (vida_actual > vida_maxima)
                        vida_actual = vida_maxima;
                break;

                /** Perdida de PA **/
                case 101:
                case 102:
                case 168:
                    byte pa_perdidos = byte.Parse(_valor.Substring(1));
                    pa -= pa_perdidos;
                break;

                case 120://Ganancia de pa
                    byte pa_ganados = byte.Parse(_valor);
                    pa += pa_ganados;
                break;

                /** Perdida de PM **/
                case 127:
                case 77:
                case 129:
                case 169:
                    byte pm_perdidos = byte.Parse(_valor.Substring(1));
                    pm -= pm_perdidos;
                break;

                /** Ganancia de PM **/
                case 78:
                case 128:
                    byte pm_ganados = byte.Parse(_valor);
                    pm += pm_ganados;
                break;
            }
        }
    }
}
