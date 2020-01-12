using Bot_Dofus_Retro.Utilidades.Configuracion;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
	Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Tema.Forms
{
    public partial class Opciones : Form
    {
        public Opciones()
        {
            InitializeComponent();

            checkBox_mensajes_debug.Checked = GlobalConf.mostrar_mensajes_debug;
            textBox_ip_servidor.Text = GlobalConf.ip_conexion;
            textBox_puerto_servidor.Text = GlobalConf.puerto_conexion.ToString();
            textBox_version.Text = GlobalConf.version_dofus;
            textBox_peso_core.Text = GlobalConf.peso_core.ToString();
            textBox_peso_loader.Text = GlobalConf.peso_loader.ToString();
        }

        private void boton_opciones_guardar_Click(object sender, EventArgs e)
        {
            if (!IPAddress.TryParse(textBox_ip_servidor.Text, out IPAddress ip))
            {
                textBox_ip_servidor.BackColor = Color.Red;
                return;
            }

            if (!short.TryParse(textBox_puerto_servidor.Text, out short puerto))
            {
                textBox_puerto_servidor.BackColor = Color.Red;
                return;
            }

            if (!int.TryParse(textBox_peso_core.Text, out int peso_core))
            {
                textBox_peso_core.BackColor = Color.Red;
                return;
            }

            if (!int.TryParse(textBox_peso_loader.Text, out int peso_loader))
            {
                textBox_peso_loader.BackColor = Color.Red;
                return;
            }

            GlobalConf.mostrar_mensajes_debug = checkBox_mensajes_debug.Checked;
            GlobalConf.ip_conexion = ip.ToString();
            GlobalConf.puerto_conexion = puerto;
            GlobalConf.peso_core = peso_core;
            GlobalConf.peso_loader = peso_loader;
            GlobalConf.guardar();
            Close();
        }
    }
}
