using Bot_Dofus_Retro.Otros.Scripts.Acciones;
using Bot_Dofus_Retro.Tema.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bot_Dofus_Retro.Otros.Grupos
{
    public class Grupo : IDisposable
    {
        private Agrupamiento agrupamiento;
        private Dictionary<Cuenta, ManualResetEvent> cuentas_acabadas;

        public Cuenta lider { get; private set; }
        public ObservableCollection<Cuenta> miembros { get; private set; }
        private bool disposed;

        public Grupo(Cuenta _lider)
        {
            agrupamiento = new Agrupamiento(this);
            cuentas_acabadas = new Dictionary<Cuenta, ManualResetEvent>();
            lider = _lider;
            miembros = new ObservableCollection<Cuenta>();

            lider.grupo = this;
            lider.juego.pelea.pelea_id_recibida += id_Nueva_Pelea_Recibida;
        }

        public void agregar_Miembro(Cuenta miembro)
        {
            if (miembros.Count > 7)//0-6 (miembros), 1 lider
                return;

            miembro.grupo = this;
            miembros.Add(miembro);
            cuentas_acabadas.Add(miembro, new ManualResetEvent(false));
            miembro.script.manejar_acciones.evento_accion_normal += miembro_Acciones_Acabadas;
        }

        public void eliminar_Miembro(Cuenta miembro) => miembros.Remove(miembro);
        public Task conectar_Cuentas() => Task.Run(() => miembros.ToList().ForEach(async miembro => await miembro.conectar()));
        public void desconectar_Cuentas() => miembros.ToList().ForEach(miembro => miembro.desconectar());

        #region Acciones
        public void enqueue_Acciones_Miembros(AccionesScript accion, bool iniciar_dequeue = false)
        {
            if (accion is PeleasAccion)
            {
                foreach (Cuenta miembro in miembros)
                    cuentas_acabadas[miembro].Set();

                return;
            }

            foreach (Cuenta miembro in miembros)
                miembro.script.manejar_acciones.enqueue_Accion(accion, iniciar_dequeue);

            if (iniciar_dequeue)
            {
                for (int i = 0; i < miembros.Count; i++)
                    cuentas_acabadas[miembros[i]].Reset();
            }
        }

        public void get_Limpiar_Acciones_Miembros()
        {
            foreach (Cuenta miembro in miembros)
            {
                miembro.juego.manejador.recoleccion.get_Cancelar_Interactivo();
                miembro.script.manejar_acciones.get_Borrar_Todo();
            }
        }

        public async Task get_Grupo_Necesita_Regruparse()
        {
            if (miembros.All(m => m.juego.mapa.esta_En_Mapa(lider.juego.mapa.id)))
                return;

            lider.logger.log_informacion("GRUPO", "Los bots están separados, empezando a juntarlos en el mismo mapa");
            await agrupamiento.get_Agrupar_Miembros();
            lider.logger.log_informacion("GRUPO", "Todos los integrantes del grupo están juntos en el mismo mapa.");
        }

        public async Task get_Comprobaciones_Script()
        {
            Task[] verificaciones = new Task[miembros.Count + 1];
            verificaciones[0] = lider.script.aplicar_Comprobaciones();

            for (int i = 0; i < miembros.Count; i++)
                verificaciones[i + 1] = miembros[i].script.aplicar_Comprobaciones();

            await Task.WhenAll(verificaciones);
        }

        public async Task get_Esperar_Miembros_Unirse_Pelea()
        {
            while (miembros.Any(m => !m.esta_Luchando()) && !lider.juego.pelea.pelea_iniciada)
            {
                lider.logger.log_informacion("GRUPO", "Esperando a que los miembros del grupo se unan a la pelea");
                await Task.Delay(1000);
            }
        }

        public async Task get_Esperar_Miembros_Conectados()
        {
            while (miembros.Any(m => !m.esta_Conectado()))
            {
                lider.logger.log_informacion("GRUPO", "Esperando a la conexion de los miembros del grupo");
                await Task.Delay(1000);
            }
        }

        public void get_Invitar_Grupo_Miembros()
        {
            foreach (Cuenta miembro in miembros)
            {
                if (lider == miembro)
                    continue;

                if (miembro.juego.personaje.en_grupo)
                    continue;

                lider.conexion.enviar_Paquete($"PI{miembro.juego.personaje.nombre}");
            }
        }

        public void get_Miembros_Unirse_Pelea()
        {
            if (!lider.esta_Luchando())
                return;

            foreach(Cuenta miembro in miembros)
            {
                if (miembro.esta_Luchando())
                    continue;

                miembro.conexion.enviar_Paquete($"GA903{lider.juego.personaje.id};{lider.juego.pelea.id_pelea}");
            }
        }

        public bool get_Esta_En_Grupo(string nombre) => miembros.Any(miembro => miembro.juego.personaje.nombre.Equals(nombre));
        private void id_Nueva_Pelea_Recibida() => get_Miembros_Unirse_Pelea();
        public bool get_Grupo_Esta_ocupado() => lider.esta_ocupado || miembros.Any(m => m.esta_ocupado);
        public void esperar_Acciones_Terminadas() => WaitHandle.WaitAll(cuentas_acabadas.Values.ToArray());

        private void miembro_Acciones_Acabadas(Cuenta _cuenta, bool mapa_cambiado)
        {
            _cuenta.logger.log_informacion("GRUPO", "Acciones acabadas");
            cuentas_acabadas[_cuenta].Set();
        }
        #endregion

        #region Zona Dispose
        public void Dispose() => Dispose(true);
        ~Grupo() => Dispose(false);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    agrupamiento.Dispose();
                    lider.Dispose();

                    miembros.ToList().ForEach(miembro =>
                    {
                        string nombre_cuenta = miembro.configuracion.nombre_cuenta;
                        Principal.cuentas_cargadas[nombre_cuenta].Close();
                        Principal.cuentas_cargadas.Remove(nombre_cuenta);

                        miembro.Dispose();
                    });
                }

                agrupamiento = null;
                cuentas_acabadas.Clear();
                cuentas_acabadas = null;
                miembros.Clear();
                miembros = null;
                lider = null;

                disposed = true;
            }
        }
        #endregion
    }
}