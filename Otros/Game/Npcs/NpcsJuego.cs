using Bot_Dofus_Retro.Otros.Enums;
using Bot_Dofus_Retro.Otros.Mapas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bot_Dofus_Retro.Otros.Game.Npcs
{
    public class NpcsJuego : IDisposable
    {
        private Cuenta cuenta;
        private sbyte npc_id { get; set; }
        private short pregunta { get; set; }
        private List<short> respuestas { get; set; }
        private bool disposed;

        public event Action respuestas_recibidas;
        public event Action dialogo_acabado;

        public NpcsJuego(Cuenta _cuenta) => cuenta = _cuenta;

        public bool utilizar(int id)
        {
            if (cuenta.esta_ocupado || !cuenta.juego.personaje.derechos.PUEDE_DIALOGAR_NPC)
                return false;

            Npc npc = null;
            IEnumerable<Npc> npcs = cuenta.juego.mapa.get_Npcs();

            if (id < 0)
            {
                int index = (id * -1) - 1;

                if (npcs.Count() <= index)
                    return false;

                npc = npcs.ElementAt(index);
            }
            else
                npc = npcs.FirstOrDefault(n => n.modelo_id == id);

            if (npc == null)
                return false;

            cuenta.conexion.enviar("DC" + npc.id).Wait();
            return true;
        }

        public bool responder(short respuesta_id)
        {
            if (!cuenta.esta_Dialogando())
                return false;

            if (respuesta_id < 0)
            {
                int index = (respuesta_id * -1) - 1;

                if (respuestas.Count <= index)
                    return false;

                respuesta_id = respuestas[index];
            }

            if (respuestas.Contains(respuesta_id))
            {
                cuenta.conexion.enviar("DR" + pregunta + "|" + respuesta_id).Wait();
                return true;
            }

            return false;
        }

        public void get_Dialogo_Creado(sbyte _npc_id)
        {
            npc_id = _npc_id;
            cuenta.Estado_Cuenta = EstadoCuenta.DIALOGANDO;
        }

        public void get_Respuestas_Recibidas(short _pregunta, List<short> _respuestas)
        {
            if (!cuenta.esta_Dialogando())
                return;

            pregunta = _pregunta;
            respuestas = _respuestas;
            respuestas_recibidas?.Invoke();
        }

        public void get_Cerrar_Dialogo()
        {
            if (!cuenta.esta_Dialogando())
                return;

            respuestas.Clear();
            respuestas = null;
            cuenta.Estado_Cuenta = EstadoCuenta.CONECTADO_INACTIVO;
            dialogo_acabado?.Invoke();
        }

        #region Zona Dispose
        ~NpcsJuego() => Dispose(false);
        public void Dispose() => Dispose(true);

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                cuenta = null;
                respuestas?.Clear();
                respuestas = null;
                disposed = true;
            }
        }
        #endregion
    }
}
