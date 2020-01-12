using Bot_Dofus_Retro.Otros;
using System.Drawing;
using Bot_Dofus_Retro.DarkUI.Docking;

namespace Bot_Dofus_Retro.Tema.Interfaces
{
    public partial class UI_TabPersonaje : DarkDocument
    {
        public UI_TabPersonaje(Cuenta cuenta, string nombre, Bitmap icono)
        {
            InitializeComponent();
            Icon = icono;
            DockText = nombre;

            dockPanel_UI.AddContent(new UI_Personaje(cuenta, "Características", Properties.Resources.caracteristicas));
            dockPanel_UI.AddContent(new UI_Hechizos(cuenta, "Hechizos", Properties.Resources.hechizos));
        }
    }
}
