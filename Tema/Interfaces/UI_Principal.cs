using Bot_Dofus_Retro.Otros;
using Bot_Dofus_Retro.Otros.Enums;
using Bot_Dofus_Retro.Otros.Game.Personaje;
using Bot_Dofus_Retro.Tema.Forms;
using Bot_Dofus_Retro.Utilidades.Extensiones;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Bot_Dofus_Retro.DarkUI.Docking;

namespace Bot_Dofus_Retro.Tema.Interfaces
{
    public partial class UI_Principal : DarkDocument
    {
        private Cuenta cuenta;
        private string nombre_cuenta;

        public UI_Principal(Cuenta _cuenta)
        {
            InitializeComponent();
            cuenta = _cuenta;
            nombre_cuenta = cuenta.configuracion.nombre_cuenta;
            DockText = nombre_cuenta;

            darkDockPanel_principal.AddContent(new UI_Chat(cuenta, "Consola", Properties.Resources.terminal));
            darkDockPanel_principal.AddContent(new UI_Debugger(cuenta, "Debugger", Properties.Resources.debugger));
        }

        private void UI_Principal_Load(object sender, EventArgs e) => cargar_Eventos_Cuenta();

        private async void desconectarOconectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (botonEstadoToolStripMenuItem.Text.Equals("Conectar"))
                await cuenta.conectar();
            else if (botonEstadoToolStripMenuItem.Text.Equals("Desconectar"))
                cuenta.desconectar();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Principal.cuentas_cargadas.ContainsKey(nombre_cuenta))
            {
                if (cuenta.tiene_grupo && cuenta.es_lider_grupo)
                    cuenta.grupo.Dispose();
                else if (cuenta.tiene_grupo)
                    cuenta.grupo.eliminar_Miembro(cuenta);

                cuenta.Dispose();
                Principal.cuentas_cargadas[nombre_cuenta].Close();
                Principal.cuentas_cargadas.Remove(nombre_cuenta);
            }
        }

        private async void conectar_Cuenta()
        {
            if (!IsHandleCreated)
                return;

            if (cuenta.es_lider_grupo && cuenta.tiene_grupo)
                await cuenta.grupo.conectar_Cuentas();

            List<DarkDockContent> contenidos = darkDockPanel_principal.ActiveGroup.GetContents();
            BeginInvoke((Action)(() =>
            {
                for (int i = 2; i < contenidos.Count; i++)
                {
                    DarkDockContent test = contenidos[i];
                    darkDockPanel_principal.RemoveContent(test);
                }
                botonEstadoToolStripMenuItem.Text = "Desconectar";
            }));
        }

        private void desconectar_Cuenta()
        {
            if (!IsHandleCreated)
                return;

            List<DarkDockContent> contenidos = darkDockPanel_principal.ActiveGroup.GetContents();

            BeginInvoke((Action)(() =>
            {
                for (int i = 2; i < contenidos.Count; i++)
                {
                    DarkDockContent test = contenidos[i];
                    test.Enabled = false;
                }

                cargarScriptToolStripMenuItem.Enabled = false;
                botonEstadoToolStripMenuItem.Text = "Conectar";
            }));
        }

        private void eventos_Estados_Cuenta()
        {
            switch (cuenta.Estado_Cuenta)
            {
                case EstadoCuenta.DESCONECTADO:
                    Icon = Properties.Resources.desconectado;
                    break;

                case EstadoCuenta.CONECTANDO:
                    Icon = Properties.Resources.conexion;
                    break;

                default:
                    Icon = Properties.Resources.conectado;
                    break;
            }

            BeginInvoke((Action)(() =>
            {
                if (Principal.cuentas_cargadas.ContainsKey(nombre_cuenta))
                    estadoPersonaje.Text = $"Estado: {cuenta.Estado_Cuenta.cadena_Amigable()}";
            }));
        }

        private void servidor_Seleccionado()
        {
            darkDockPanel_principal.BeginInvoke((Action)(() =>
            {
                darkDockPanel_principal.AddContent(new UI_TabPersonaje(cuenta, "Personaje", Properties.Resources.perfil_default));
                darkDockPanel_principal.AddContent(new UI_Inventario(cuenta, "Inventario", Properties.Resources.inventario));
            }));
        }

        private void personaje_Seleccionado()
        {
            darkDockPanel_principal.BeginInvoke((Action)(() =>
            {
                darkDockPanel_principal.AddContent(new UI_Mapa(cuenta, "Mapa", Properties.Resources.icono_mapa));
                darkDockPanel_principal.AddContent(new UI_Pelea(cuenta, "Combates", Properties.Resources.icono_pelea));
                darkDockPanel_principal.AddContent(new UI_Opciones(cuenta, "Opciones", Properties.Resources.icono_ajustes));
            }));

            BeginInvoke((Action)(() =>
            {
                cargarScriptToolStripMenuItem.Enabled = true;
            }));
        }

        private void caracteristicas_Actualizadas()
        {
            BeginInvoke((Action)(() =>
            {
                PersonajeJuego personaje = cuenta.juego.personaje;

                progresBar_vitalidad.valor_Maximo = personaje.caracteristicas.vitalidad_maxima;
                progresBar_vitalidad.Valor = personaje.caracteristicas.vitalidad_actual;
                progresBar_energia.valor_Maximo = personaje.caracteristicas.maxima_energia;
                progresBar_energia.Valor = personaje.caracteristicas.energia_actual;
                progresBar_experiencia.Text = personaje.nivel.ToString();
                progresBar_experiencia.Valor = personaje.porcentaje_experiencia;
                label_kamas_principal.Text = personaje.kamas.ToString("0,0");
            }));
        }

        private void pods_Actualizados()
        {
            BeginInvoke((Action)(() =>
            {
                progresBar_pods.valor_Maximo = cuenta.juego.personaje.inventario.pods_maximos;
                progresBar_pods.Valor = cuenta.juego.personaje.inventario.pods_actuales;
            }));
        }

        private void evento_Scripts_Cargado(string nombre)
        {
            cuenta.logger.log_informacion("SCRIPT", $"'{nombre}' cargado.");
            BeginInvoke((Action)(() =>
            {
                ScriptTituloStripMenuItem.Text = $"{(nombre.Length > 15 ? nombre.Substring(0, 15) : nombre)}";
                iniciarScriptToolStripMenuItem.Enabled = true;
            }));
        }

        private void evento_Scripts_Iniciado()
        {
            cuenta.logger.log_informacion("SCRIPT", "Iniciado");
            BeginInvoke((Action)(() =>
            {
                cargarScriptToolStripMenuItem.Enabled = false;
                iniciarScriptToolStripMenuItem.Image = Properties.Resources.boton_stop;
            }));
        }

        private void evento_Scripts_Detenido(string motivo)
        {
            if (string.IsNullOrEmpty(motivo))
                cuenta.logger.log_informacion("SCRIPT", "Detenido");
            else
                cuenta.logger.log_informacion("SCRIPT", $"Detenido {motivo}");

            BeginInvoke((Action)(() =>
            {
                iniciarScriptToolStripMenuItem.Image = Properties.Resources.boton_play;
                cargarScriptToolStripMenuItem.Enabled = true;
                ScriptTituloStripMenuItem.Text = "-";
            }));
        }

        private void cargar_Eventos_Cuenta()
        {
            cuenta.cuenta_conectada += conectar_Cuenta;
            cuenta.cuenta_desconectada += desconectar_Cuenta;
            cuenta.estado_cuenta += eventos_Estados_Cuenta;

            cuenta.script.evento_script_cargado += evento_Scripts_Cargado;
            cuenta.script.evento_script_iniciado += evento_Scripts_Iniciado;
            cuenta.script.evento_script_detenido += evento_Scripts_Detenido;

            cuenta.juego.personaje.caracteristicas_actualizadas += caracteristicas_Actualizadas;
            cuenta.juego.personaje.pods_actualizados += pods_Actualizados;
            cuenta.juego.personaje.servidor_seleccionado += servidor_Seleccionado;
            cuenta.juego.personaje.personaje_seleccionado += personaje_Seleccionado;
        }

        private void cargarScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "Selecciona el script para el bot";
                    ofd.Filter = "Extension (.lua) | *.lua";

                    if (ofd.ShowDialog() == DialogResult.OK)
                        cuenta.script.get_Desde_Archivo(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                cuenta.logger.log_Error("SCRIPT", ex.Message);
            }
        }

        private void iniciarScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cuenta.script.activado)
                cuenta.script.detener_Script();
            else
                cuenta.script.activar_Script();
        }
    }
}
