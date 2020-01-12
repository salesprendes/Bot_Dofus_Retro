using Bot_Dofus_Retro.Otros.Game.Entidades.Manejadores;
using Bot_Dofus_Retro.Otros.Game.Npcs;
using Bot_Dofus_Retro.Otros.Game.Personaje;
using Bot_Dofus_Retro.Otros.Game.Servidor;
using Bot_Dofus_Retro.Otros.Mapas;
using Bot_Dofus_Retro.Otros.Peleas;
using System;

namespace Bot_Dofus_Retro.Otros.Game
{
    public class Juego : IEliminable, IDisposable
    {
        public ServidorJuego servidor { get; private set; }
        public Mapa mapa { get; private set; }
        public PersonajeJuego personaje { get; private set; }
        public Manejador manejador { get; private set; }
        public Pelea pelea { get; private set; }
        public NpcsJuego npcs { get; private set; }
        private bool disposed;

        internal Juego(Cuenta cuenta)
        {
            servidor = new ServidorJuego();
            mapa = new Mapa(cuenta);
            personaje = new PersonajeJuego(cuenta);
            manejador = new Manejador(cuenta, mapa, personaje);
            pelea = new Pelea(cuenta);
            npcs = new NpcsJuego(cuenta);
        }

        #region Zona Dispose
        ~Juego() => Dispose(false);
        public void Dispose() => Dispose(true);

        public void limpiar()
        {
            mapa.limpiar();
            manejador.limpiar();
            pelea.limpiar();
            personaje.limpiar();
            servidor.limpiar();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    mapa.Dispose();
                    personaje.Dispose();
                    manejador.Dispose();
                    pelea.Dispose();
                    servidor.Dispose();
                    npcs.Dispose();
                }

                servidor = null;
                mapa = null;
                personaje = null;
                manejador = null;
                pelea = null;
                npcs = null;
                disposed = true;
            }
        }
        #endregion
    }
}
