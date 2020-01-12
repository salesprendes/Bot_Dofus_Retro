using Bot_Dofus_Retro.Otros.Game.Entidades.Manejadores.Interactivos;
using Bot_Dofus_Retro.Otros.Game.Entidades.Manejadores.Movimientos;
using Bot_Dofus_Retro.Otros.Game.Entidades.Manejadores.Recolecciones;
using Bot_Dofus_Retro.Otros.Game.Personaje;
using Bot_Dofus_Retro.Otros.Mapas;
using System;

namespace Bot_Dofus_Retro.Otros.Game.Entidades.Manejadores
{
    public class Manejador : IEliminable, IDisposable
    {
        public Movimiento movimientos { get; private set; }
        public Recoleccion recoleccion { get; private set; }
        public Interactivo interactivos { get; private set; }
        private bool disposed;

        public Manejador(Cuenta cuenta, Mapa mapa, PersonajeJuego personaje)
        {
            movimientos = new Movimiento(cuenta, mapa, personaje);
            recoleccion = new Recoleccion(cuenta, movimientos, mapa);
            interactivos = new Interactivo(cuenta, mapa, movimientos);
        }

        public void limpiar()
        {
            movimientos.limpiar();
            recoleccion.limpiar();
            interactivos.limpiar();
        }

        #region Zona Dispose
        ~Manejador() => Dispose(false);
        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                movimientos.Dispose();
            }

            movimientos = null;
            disposed = true;
        }
        #endregion
    }
}
