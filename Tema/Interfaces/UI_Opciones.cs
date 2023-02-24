using Bot_Dofus_Retro.DarkUI.Docking;
using Bot_Dofus_Retro.Otros;
using System.Drawing;

namespace Bot_Dofus_Retro.Tema.Interfaces
{
    public partial class UI_Opciones : DarkDocument
    {
        private Cuenta cuenta;

        public UI_Opciones(Cuenta _cuenta, string nombre, Bitmap icono)
        {
            InitializeComponent();
            cuenta = _cuenta;
            Icon = icono;
            DockText = nombre;
            refrescar_Configuracion();
        }

        private void refrescar_Configuracion()
        {
            numericUp_regeneracion1.Value = cuenta.pelea_extension.configuracion.iniciar_regeneracion;
            numericUp_regeneracion2.Value = cuenta.pelea_extension.configuracion.detener_regeneracion;
        }

        private void numericUp_regeneracion1_ValueChanged(object sender, System.EventArgs e)
        {
            cuenta.pelea_extension.configuracion.iniciar_regeneracion = (byte)numericUp_regeneracion1.Value;
            cuenta.pelea_extension.configuracion.guardar();
        }

        private void numericUp_regeneracion2_ValueChanged(object sender, System.EventArgs e)
        {
            cuenta.pelea_extension.configuracion.detener_regeneracion = (byte)numericUp_regeneracion2.Value;
            cuenta.pelea_extension.configuracion.guardar();
        }
    }
}
