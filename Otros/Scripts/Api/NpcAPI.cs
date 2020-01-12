using Bot_Dofus_Retro.Otros.Scripts.Acciones.Npc;
using Bot_Dofus_Retro.Otros.Scripts.Manejadores;
using MoonSharp.Interpreter;
using System;
using System.Linq;

namespace Bot_Dofus_Retro.Otros.Scripts.Api
{
    [MoonSharpUserData]
    public class NpcAPI : IDisposable
    {
        private Cuenta cuenta;
        private ManejadorAcciones manejador_acciones;
        private bool disposed;

        public NpcAPI(Cuenta _cuenta, ManejadorAcciones _manejador_acciones)
        {
            cuenta = _cuenta;
            manejador_acciones = _manejador_acciones;
        }

        public bool npcBanco(int npc_id, short respuesta_id)
        {
            if (npc_id > 0 && cuenta.juego.mapa.get_Npcs().FirstOrDefault(n => n.modelo_id == npc_id) == null)
                return false;

            manejador_acciones.enqueue_Accion(new NpcBanco(npc_id, respuesta_id), true);
            return true;
        }

        public bool hablarNpc(int npc_id)
        {
            if (npc_id > 0 && cuenta.juego.mapa.get_Npcs().FirstOrDefault(n => n.modelo_id == npc_id) == null)
                return false;

            manejador_acciones.enqueue_Accion(new IniciarDialogo(npc_id), true);
            return true;
        }

        public void responder(short respuesta_id) => manejador_acciones.enqueue_Accion(new ResponderDialogo(respuesta_id), true);
        public void cerrar(short respuesta_id) => manejador_acciones.enqueue_Accion(new CerrarDialogo(), true);

        #region Zona Dispose
        ~NpcAPI() => Dispose(false);
        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                cuenta = null;
                manejador_acciones = null;
                disposed = true;
            }
        }
        #endregion
    }
}
