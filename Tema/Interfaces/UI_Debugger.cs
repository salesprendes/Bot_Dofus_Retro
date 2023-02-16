using Bot_Dofus_Retro.Otros;
using System;
using System.Drawing;
using Bot_Dofus_Retro.DarkUI.Docking;
using Bot_Dofus_Retro.DarkUI.Controls;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2023 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Tema.Interfaces
{
    public partial class UI_Debugger : DarkDocument
    {
        private Cuenta cuenta;

        public UI_Debugger(Cuenta _cuenta, string nombre, Bitmap icono)
        {
            InitializeComponent();
            cuenta = _cuenta;
            DockText = nombre;
            Icon = icono;
            cargar_Eventos_Cuenta();
        }

        public void get_paquete_Recibido(string paquete)
        {
            agregar_Nuevo_Paquete(paquete, false);
        }

        public void get_paquete_Enviado(string paquete)
        {
            agregar_Nuevo_Paquete(paquete, true);
        }

        private void cargar_Eventos_Cuenta()
        {
            cuenta.conexion.paquete_recibido += get_paquete_Recibido;
            cuenta.conexion.paquete_enviado += get_paquete_Enviado;
        }

        private void agregar_Nuevo_Paquete(string paquete, bool enviado)
        {
            if (!checkbox_debugger.Checked)
                return;

            try
            {
                BeginInvoke((Action)(() =>
                {
                    paquete = (paquete.Length > 90 ? paquete.Substring(0, 90) : paquete);
                    if (ListView_paquete.Items.Count == 100)
                        ListView_paquete.Items.RemoveAt(0);

                    string formato_paquete = $"[{DateTime.Now.ToString("HH:mm")}] | {paquete} | {(enviado ? "Enviado" : "Recibido")}";
                    ListView_paquete.Items.Add(new DarkListItem(formato_paquete));
                }));
            }
            catch { }
        }

        private void button_limpiar_logs_debugger_Click(object sender, EventArgs e) => ListView_paquete.Items.Clear();
    }
}
