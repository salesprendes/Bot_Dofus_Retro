using Bot_Dofus_Retro.DarkUI.Controls;
using Bot_Dofus_Retro.DarkUI.Docking;
using Bot_Dofus_Retro.Otros;
using Bot_Dofus_Retro.Otros.Game.Personaje.Oficios;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Bot_Dofus_Retro.Tema.Interfaces
{
    public partial class UI_Oficios : DarkDocument
    {
        private Cuenta cuenta;

        public UI_Oficios() => InitializeComponent();

        private void UI_Oficios_Load(object sender, EventArgs e)
        {
            set_DoubleBuffered(dataGridView_oficios);
        }

        public void set_Cuenta(Cuenta _cuenta)
        {
            cuenta = _cuenta;
            cuenta.juego.personaje.oficios.oficios_actualizados += personaje_Oficios_Actualizados;
        }

        private void personaje_Oficios_Actualizados()
        {
            BeginInvoke((Action)(() =>
            {
                dataGridView_oficios.Rows.Clear();
                foreach (Oficio oficio in cuenta.juego.personaje.oficios.oficios)
                    dataGridView_oficios.Rows.Add(new object[] { oficio.id, oficio.nombre, oficio.nivel, oficio.experiencia_actual + "/" + oficio.experiencia_siguiente_nivel, oficio.get_Experiencia_Porcentaje + "%" });

                ListView_skills.Items.Clear();
                foreach (SkillsOficio skill in cuenta.juego.personaje.oficios.get_Skills_Disponibles())
                {
                    DarkListItem item = new DarkListItem(skill.interactivo_modelo.nombre);
                    ListView_skills.Items.Add(item);
                }
            }));
        }

        public static void set_DoubleBuffered(Control control) => typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, control, new object[] { true });
    }
}
