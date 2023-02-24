using Bot_Dofus_Retro.Otros.Game.Entidades.Manejadores.Movimientos;
using Bot_Dofus_Retro.Otros.Mapas;
using Bot_Dofus_Retro.Otros.Mapas.Interactivo;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bot_Dofus_Retro.Otros.Game.Entidades.Manejadores.Interactivos
{
    public class Interactivo : IDisposable
    {
        private int habilidad;
        private Cuenta cuenta;
        private Mapa mapa;
        private ObjetoInteractivo interactivo_utilizado;

        public event Action<bool> fin_interactivo;
        private bool disposed;

        public Interactivo(Cuenta _cuenta, Mapa _mapa, Movimiento movimiento)
        {
            cuenta = _cuenta;
            mapa = _mapa;
            movimiento.movimiento_finalizado += evento_Movimiento_Finalizado;
        }

        public bool get_Utilizar_Interactivo(int _celda_id, int _habilidad = -1)
        {
            ObjetoInteractivo interactivo = mapa.get_Interactivo(_celda_id);

            if (interactivo == null || !interactivo.es_utilizable)
                return false;

            return get_Mover_Utilizar_Ineractivo(interactivo, interactivo.celda, _habilidad);
        }

        public bool get_Mover_Utilizar_Ineractivo(ObjetoInteractivo interactivo, Celda celda, int _habilidad)
        {
            if (cuenta.esta_ocupado || interactivo_utilizado != null)
                return false;

            if (interactivo == null || !interactivo.es_utilizable)
                return false;

            interactivo_utilizado = interactivo;
            habilidad = _habilidad;

            switch (cuenta.juego.manejador.movimientos.get_Mover_A_Celda(celda, mapa.celdas_ocupadas(), true, 1))
            {
                case ResultadoMovimientos.EXITO:
                    return true;

                case ResultadoMovimientos.MISMA_CELDA:
                    get_Utilizar_Elemento();
                    return true;

                default:
                    limpiar();
                    return false;
            }
        }

        private void evento_Movimiento_Finalizado(bool correcto)
        {
            if (interactivo_utilizado == null)
                return;

            if (correcto)
                get_Utilizar_Elemento();
        }

        private void get_Utilizar_Elemento() => Task.Run(async () =>
        {
            if (interactivo_utilizado == null)
                return;

            if (habilidad < 0)//metodo negativo
            {
                int index = (habilidad * -1) - 1;

                if (interactivo_utilizado.modelo.habilidades.Count() <= index)
                {
                    get_Finalizar_Interactivo(false);
                    return;
                }

                habilidad = interactivo_utilizado.modelo.habilidades[index];
            }

            await cuenta.conexion.enviar($"GA500{interactivo_utilizado.celda.id};{habilidad}");
        });

        private void get_Finalizar_Interactivo(bool success)
        {
            limpiar();
            fin_interactivo?.Invoke(success);
        }

        public void limpiar()
        {
            interactivo_utilizado = null;
            habilidad = 0;
        }

        #region Zona Dispose
        public void Dispose() => Dispose(true);
        ~Interactivo() => Dispose(false);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                interactivo_utilizado = null;
                cuenta = null;

                disposed = true;
            }
        }
        #endregion
    }
}
