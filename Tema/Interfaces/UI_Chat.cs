using Bot_Dofus_Retro.DarkUI.Controls;
using Bot_Dofus_Retro.DarkUI.Docking;
using Bot_Dofus_Retro.Otros;
using Bot_Dofus_Retro.Otros.Enums;
using Bot_Dofus_Retro.Utilidades.Logs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bot_Dofus_Retro.Tema.Interfaces
{
    public partial class UI_Chat : DarkDocument
    {
        private Cuenta cuenta;

        public UI_Chat(Cuenta _cuenta, string nombre, Bitmap icono)
        {
            InitializeComponent();
            cuenta = _cuenta;
            DockText = nombre;
            Icon = icono;
            get_Lista_Canales();
        }

        private void get_Lista_Canales()
        {
            comboBox_lista_canales.Items.Add(new DarkDropdownItem("General"));
            comboBox_lista_canales.Items.Add(new DarkDropdownItem("Reclutamiento"));
            comboBox_lista_canales.Items.Add(new DarkDropdownItem("Comercio"));
            comboBox_lista_canales.Items.Add(new DarkDropdownItem("Mensaje privado"));
            comboBox_lista_canales.SelectedItem = comboBox_lista_canales.Items[0];
        }

        private void UI_Chat_Load(object sender, EventArgs e)
        {
            escribir_mensaje($"[{DateTime.Now.ToString("HH:mm:ss")}] -> [INFORMACIÓN] Bot creado por Alvaro, http://www.salesprendes.com versión: {Application.ProductVersion}", LogTipos.ERROR.ToString("X"));
            escribir_mensaje($"[{DateTime.Now.ToString("HH:mm:ss")}] -> SI PAGASTE POR EL BOT, TE ESTAFARON", LogTipos.ERROR.ToString("X"));
            cargar_Eventos_Cuenta();

            if (cuenta.tiene_grupo)
                escribir_mensaje("[" + DateTime.Now.ToString("HH:mm:ss") + "] -> El líder del grupo es: " + cuenta.grupo.lider.configuracion.nombre_cuenta, LogTipos.ERROR.ToString("X"));
        }

        private void personaje_Seleccionado() => BeginInvoke((Action)(() =>
        {
            tableLayoutPanel_inferiores_chat.Enabled = true;
            tableLayout_Canales.Enabled = true;

            canal_informaciones.Checked = cuenta.juego.personaje.canales.Contains("i");
            canal_general.Checked = cuenta.juego.personaje.canales.Contains("*");
            canal_privado.Checked = cuenta.juego.personaje.canales.Contains("#");
            canal_gremio.Checked = cuenta.juego.personaje.canales.Contains("%");
            canal_alineamiento.Checked = cuenta.juego.personaje.canales.Contains("!");
            canal_reclutamiento.Checked = cuenta.juego.personaje.canales.Contains("?");
            canal_comercio.Checked = cuenta.juego.personaje.canales.Contains(":");
            canal_incarnam.Checked = cuenta.juego.personaje.canales.Contains("^");
        }));

        private void cargar_Eventos_Cuenta()
        {
            cuenta.logger.log_evento += (mensaje, color) => escribir_mensaje(mensaje.ToString(), color);
            cuenta.conexion.socket_informacion += get_Mensajes_Socket_Informacion;
            cuenta.juego.personaje.personaje_seleccionado += personaje_Seleccionado;
        }

        private void get_Mensajes_Socket_Informacion(object error) => escribir_mensaje("[" + DateTime.Now.ToString("HH:mm:ss") + "] [Conexión] " + error, LogTipos.PELIGRO.ToString("X"));

        private void escribir_mensaje(string mensaje, string color)
        {
            if (!IsHandleCreated)
                return;

            textbox_logs.BeginInvoke((Action)(() =>
            {
                textbox_logs.Select(textbox_logs.TextLength, 0);
                textbox_logs.SelectionColor = ColorTranslator.FromHtml("#" + color);
                textbox_logs.AppendText(mensaje + Environment.NewLine);
                textbox_logs.ScrollToCaret();
            }));
        }

        private void canal_Chat_Click(object sender, EventArgs e)
        {
            if (cuenta?.Estado_Cuenta != EstadoCuenta.DESCONECTADO && cuenta?.Estado_Cuenta != EstadoCuenta.CONECTANDO)
            {
                string[] canales = { "i", "*", "#$p", "%", "!", "?", ":", "^" };
                CheckBox control = sender as CheckBox;
                
                cuenta.conexion.enviar_Paquete((control.Checked ? "cC+" : "cC-") + canales[control.TabIndex]);
            }
        }

        private void button_limpiar_consola_Click(object sender, EventArgs e) => textbox_logs.Clear();

        private void textBox_enviar_consola_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || textBox_enviar_consola.TextLength <= 0)
                return;

            switch (textBox_enviar_consola.Text.ToUpper())
            {
                case "/MAPID":
                    escribir_mensaje(cuenta.juego.mapa.id.ToString(), "0040FF");
                    break;

                case "/CELLID":
                    escribir_mensaje(cuenta.juego.personaje.celda.id.ToString(), "0040FF");
                    break;

                case "/PING":
                    if (cuenta.Estado_Cuenta != EstadoCuenta.DESCONECTADO)
                        cuenta.conexion.enviar_Paquete("ping", true);
                break;

                default:
                    switch (comboBox_lista_canales.SelectedItem.Text)
                    {
                        case "General":
                            cuenta.conexion.enviar_Paquete("BM*|" + textBox_enviar_consola.Text + "|", true);
                        break;

                        case "Reclutamiento":
                            cuenta.conexion.enviar_Paquete("BM?|" + textBox_enviar_consola.Text + "|", true);
                        break;

                        case "Comercio":
                            cuenta.conexion.enviar_Paquete("BM:|" + textBox_enviar_consola.Text + "|", true);
                       break;

                        case "Mensaje privado":
                            cuenta.conexion.enviar_Paquete("BM" + textBox_nombre_privado.Text + "|" + textBox_enviar_consola.Text + "|", true);
                        break;
                    }
                    break;
            }

            e.Handled = true;
            e.SuppressKeyPress = true;
            textBox_nombre_privado.Clear();
            textBox_enviar_consola.Clear();
        }

        private void comboBox_lista_canales_SelectedItemChanged(object sender, EventArgs e)
        {
            DarkDropdownList control = sender as DarkDropdownList;
            textBox_nombre_privado.Enabled = control.SelectedItem.Text.Equals("Mensaje privado");
        }
    }
}
