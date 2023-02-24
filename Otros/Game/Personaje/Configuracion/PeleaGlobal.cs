using Bot_Dofus_Retro.Otros.Peleas.Enums;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Bot_Dofus_Retro.Otros.Game.Personaje.Configuracion
{
    public class PeleaGlobal : IDisposable
    {
        private Cuenta cuenta;
        public ObservableCollection<PeleaHechizos> hechizos { get; private set; }
        public bool desactivar_espectador { get; set; }
        public Tactica tactica { get; set; }
        public byte iniciar_regeneracion { get; set; }
        public byte detener_regeneracion { get; set; }
        public bool ignorar_invocaciones { get; set; }
        public bool utilizar_regeneracion { get; set; }
        public bool utilizar_dragopavo { get; set; }
        public PosicionamientoInicioPelea posicionamiento { get; set; }
        private bool disposed;

        private string carpeta_configuracion => $"cuentas/{cuenta.configuracion.nombre_cuenta}";
        private string archivo_configuracion => Path.Combine(carpeta_configuracion, $"{cuenta.juego.personaje.nombre}.config");

        public PeleaGlobal(Cuenta _cuenta)
        {
            cuenta = _cuenta;
            hechizos = new ObservableCollection<PeleaHechizos>();
        }

        public void guardar()
        {
            Directory.CreateDirectory(carpeta_configuracion);

            using (BinaryWriter bw = new BinaryWriter(File.Open(archivo_configuracion, FileMode.Create)))
            {
                bw.Write((byte)tactica);
                bw.Write((byte)posicionamiento);
                bw.Write(desactivar_espectador);
                bw.Write(iniciar_regeneracion);
                bw.Write(detener_regeneracion);
                bw.Write(utilizar_regeneracion);
                bw.Write(utilizar_dragopavo);
                bw.Write(ignorar_invocaciones);


                bw.Write((byte)hechizos.Count);
                for (int i = 0; i < hechizos.Count; i++)
                    hechizos[i].guardar(bw);
            }
        }

        public void cargar()
        {
            if (!File.Exists(archivo_configuracion))
            {
                get_Perfil_Defecto();
                return;
            }

            using (BinaryReader br = new BinaryReader(File.Open(archivo_configuracion, FileMode.Open)))
            {
                tactica = (Tactica)br.ReadByte();
                posicionamiento = (PosicionamientoInicioPelea)br.ReadByte();
                desactivar_espectador = br.ReadBoolean();
                iniciar_regeneracion = br.ReadByte();
                detener_regeneracion = br.ReadByte();
                utilizar_regeneracion = br.ReadBoolean();
                utilizar_dragopavo = br.ReadBoolean();
                ignorar_invocaciones = br.ReadBoolean();

                hechizos.Clear();
                byte c = br.ReadByte();
                for (int i = 0; i < c; i++)
                    hechizos.Add(PeleaHechizos.cargar(br));
            }
        }

        private void get_Perfil_Defecto()
        {
            desactivar_espectador = false;
            tactica = Tactica.AGRESIVA;
            posicionamiento = PosicionamientoInicioPelea.CERCA_DE_ENEMIGOS;
            iniciar_regeneracion = 50;
            detener_regeneracion = 100;
            ignorar_invocaciones = true;
            utilizar_dragopavo = false;
            utilizar_regeneracion = true;
        }

        #region Zona Dispose
        public void Dispose() => Dispose(true);
        ~PeleaGlobal() => Dispose(false);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                hechizos.Clear();
                hechizos = null;
                cuenta = null;
                disposed = true;
            }
        }
        #endregion
    }
}
