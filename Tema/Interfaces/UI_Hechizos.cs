using Bot_Dofus_Retro.DarkUI.Controls;
using Bot_Dofus_Retro.DarkUI.Docking;
using Bot_Dofus_Retro.Otros;
using Bot_Dofus_Retro.Otros.Game.Personaje.Hechizos;
using System;
using System.Drawing;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2023 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Tema.Interfaces
{
    public partial class UI_Hechizos : DarkDocument
    {
        private Cuenta cuenta;

        public UI_Hechizos(Cuenta _cuenta, string nombre, Bitmap icono)
        {
            InitializeComponent();
            Icon = icono;
            DockText = nombre;
            cuenta = _cuenta;

            cuenta.juego.personaje.hechizos_actualizados += actualizar_Agregar_Lista_Hechizos;
        }

        private void actualizar_Agregar_Lista_Hechizos()
        {
            ListView_hechizos.BeginInvoke((Action)(() =>
            {
                ListView_hechizos.Items.Clear();
                string formato_hechizo = string.Empty;

                foreach (Hechizo spell in cuenta.juego.personaje.hechizos.Values)
                {
                    formato_hechizo = $"{spell.id} | {spell.nombre} | {spell.nivel}";
                    ListView_hechizos.Items.Add(new DarkListItem(formato_hechizo));
                }

            }));
        }
    }
}
