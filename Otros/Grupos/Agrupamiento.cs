using Bot_Dofus_Retro.Otros.Game.Entidades.Manejadores.Movimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot_Dofus_Retro.Otros.Grupos
{
    public class Agrupamiento : IDisposable
    {
        private Grupo grupo;
        private List<Cuenta> miembros_perdidos;
        private int lider_posicion_x => grupo.lider.juego.mapa.x;
        private int lider_posicion_y => grupo.lider.juego.mapa.y;
        private bool disposed;

        public Agrupamiento(Grupo _grupo) => grupo = _grupo;

        public async Task get_Agrupar_Miembros()
        {
            List<Cuenta> _miembros_perdidos = grupo.miembros.Where(m => !m.juego.mapa.esta_En_Mapa(grupo.lider.juego.mapa.id)).ToList();
            if (_miembros_perdidos.Count == 0)
                return;

            miembros_perdidos = _miembros_perdidos;

            Task[] agrupaciones = new Task[miembros_perdidos.Count];
            for (int i = 0; i < miembros_perdidos.Count; i++)
                agrupaciones[i] = get_Agrupar_Miembro_Perdido(miembros_perdidos[i]);

            await Task.WhenAll(agrupaciones);
        }

        private async Task get_Agrupar_Miembro_Perdido(Cuenta miembro_perdido)
        {
            TaskCompletionSource<bool> tcs = null;

            async void evento_Mapa_Cambiado()
            {
                await Task.Delay(1500);
                tcs.SetResult(true);
            }

            miembro_perdido.juego.mapa.mapa_actualizado += evento_Mapa_Cambiado;

            while (grupo.lider.script.activado && !miembro_perdido.juego.mapa.esta_En_Mapa(grupo.lider.juego.mapa.id))
            {
                tcs = new TaskCompletionSource<bool>();
                get_Mover_Miembro_Perdido(miembro_perdido);
                await tcs.Task;
            }

            miembro_perdido.juego.mapa.mapa_actualizado -= evento_Mapa_Cambiado;
        }

        private void get_Mover_Miembro_Perdido(Cuenta miembro_perdido)
        {
            MapaTeleportCeldas direccion = MapaTeleportCeldas.NINGUNO;

            if (lider_posicion_y < miembro_perdido.juego.mapa.y)
                direccion = MapaTeleportCeldas.ARRIBA;

            else if (lider_posicion_y > miembro_perdido.juego.mapa.y)
                direccion = MapaTeleportCeldas.ABAJO;

            else if (lider_posicion_x < miembro_perdido.juego.mapa.x)
                direccion = MapaTeleportCeldas.IZQUIERDA;

            else if (lider_posicion_x > miembro_perdido.juego.mapa.x)
                direccion = MapaTeleportCeldas.DERECHA;

            if (direccion != MapaTeleportCeldas.NINGUNO)
                miembro_perdido.juego.manejador.movimientos.get_Cambiar_Mapa(direccion);
        }

        #region Zona Dispose
        public void Dispose() => Dispose(true);
        ~Agrupamiento() => Dispose(false);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                grupo = null;
                miembros_perdidos?.Clear();
                miembros_perdidos = null;

                disposed = true;
            }
        }
        #endregion
    }
}
