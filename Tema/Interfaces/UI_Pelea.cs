using Bot_Dofus_Retro.Otros;
using Bot_Dofus_Retro.Otros.Game.Entidades.Manejadores.Movimientos;
using Bot_Dofus_Retro.Otros.Game.Personaje.Configuracion;
using Bot_Dofus_Retro.Otros.Game.Personaje.Hechizos;
using Bot_Dofus_Retro.Otros.Mapas;
using Bot_Dofus_Retro.Otros.Mapas.Entidades;
using Bot_Dofus_Retro.Otros.Peleas.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bot_Dofus_Retro.DarkUI.Docking;

namespace Bot_Dofus_Retro.Tema.Interfaces
{
    public partial class UI_Pelea : DarkDocument
    {
        private Cuenta cuenta;

        public UI_Pelea(Cuenta _cuenta, string nombre, Bitmap icono)
        {
            InitializeComponent();
            cuenta = _cuenta;
            Icon = icono;
            DockText = nombre;
            cuenta.juego.personaje.hechizos_actualizados += actualizar_Agregar_Lista_Hechizos;
            refrescar_Configuracion();
            ordenar_ListView(listView_hechizos_pelea);
        }

        private void UI_Pelea_Load(object sender, EventArgs e)
        {
            if (comboBox_lista_hechizos.Items.Count == 0)
                actualizar_Agregar_Lista_Hechizos();
        }

        private void actualizar_Agregar_Lista_Hechizos()
        {
            BeginInvoke((Action)(() =>
            {
                comboBox_lista_hechizos.DisplayMember = "nombre";
                comboBox_lista_hechizos.ValueMember = "id";
                comboBox_lista_hechizos.DataSource = cuenta.juego.personaje.hechizos.Values.ToList();
                comboBox_lista_hechizos.SelectedIndex = 0;
            }));
        }

        private void refrescar_Configuracion()
        {
            comboBox_focus_hechizo.SelectedIndex = 0;
            checkbox_espectadores.Checked = cuenta.pelea_extension.configuracion.desactivar_espectador;

            if (cuenta.puede_utilizar_dragopavo)
                checkBox_utilizar_dragopavo.Checked = cuenta.pelea_extension.configuracion.utilizar_dragopavo;
            else
                checkBox_utilizar_dragopavo.Enabled = false;

            checkBox_ignorar_invocaciones.Checked = cuenta.pelea_extension.configuracion.ignorar_invocaciones;
            comboBox_lista_tactica.SelectedIndex = (byte)cuenta.pelea_extension.configuracion.tactica;
            comboBox_lista_posicionamiento.SelectedIndex = (byte)cuenta.pelea_extension.configuracion.posicionamiento;
            comboBox_modo_lanzamiento.SelectedIndex = 0;
            comboBox_distancia_enemigo.SelectedIndex = 0;
            comboBox_distancia_operador.SelectedIndex = 0;
            refrescar_Lista_Hechizos();
        }

        private void refrescar_Lista_Hechizos()
        {
            listView_hechizos_pelea.Items.Clear();
            List<PeleaHechizos> lista_hechizos = cuenta.pelea_extension.configuracion.hechizos.ToList();

            foreach (PeleaHechizos hechizo in lista_hechizos)
            {
                listView_hechizos_pelea.Items.Add(hechizo.id.ToString()).SubItems.AddRange(new string[]
                {
                    hechizo.nombre,
                    hechizo.focus.ToString(),
                    hechizo.lanzamientos_x_turno.ToString(),
                    hechizo.metodo_lanzamiento.ToString(),
                    hechizo.metodo_distancia.ToString(),
                    hechizo.metodo_distancia == MetodoDistanciaLanzamiento.NINGUNO ? "-" : (hechizo.distancia_operador ? "=>" : "<="),
                    hechizo.distancia_minima.ToString()
                });
            }
        }

        private void button_agregar_hechizo_Click(object sender, EventArgs e)
        {
            Hechizo hechizo = comboBox_lista_hechizos.SelectedItem as Hechizo;

            HechizoFocus focus = (HechizoFocus)comboBox_focus_hechizo.SelectedIndex;
            MetodoLanzamiento metodo_lanzamiento = (MetodoLanzamiento)comboBox_modo_lanzamiento.SelectedIndex;
            byte lanzamientos_turnos = Convert.ToByte(numeric_lanzamientos_turno.Value);
            MetodoDistanciaLanzamiento metodo_distancia = (MetodoDistanciaLanzamiento)comboBox_distancia_enemigo.SelectedIndex;
            bool operador = comboBox_distancia_operador.SelectedItem.Equals("=>");
            byte distancia = metodo_distancia == MetodoDistanciaLanzamiento.NINGUNO ? Convert.ToByte(0) : Convert.ToByte(numeric_distancia.Value);
            bool es_AOE = checkBox_AOE.Checked;
            bool necesita_piedra = checkBox_piedra_equipada.Checked;

            cuenta.pelea_extension.configuracion.hechizos.Add(new PeleaHechizos(hechizo.id, hechizo.nombre, focus, metodo_lanzamiento, lanzamientos_turnos, metodo_distancia, operador, distancia, es_AOE, necesita_piedra));
            cuenta.pelea_extension.configuracion.guardar();
            refrescar_Lista_Hechizos();
            ordenar_ListView(listView_hechizos_pelea);
        }

        private void button_subir_hechizo_Click(object sender, EventArgs e)
        {
            if (listView_hechizos_pelea.FocusedItem == null || listView_hechizos_pelea.FocusedItem.Index == 0)
                return;

            ObservableCollection<PeleaHechizos> hechizos = cuenta.pelea_extension.configuracion.hechizos;
            PeleaHechizos temporal = hechizos[listView_hechizos_pelea.FocusedItem.Index - 1];

            hechizos[listView_hechizos_pelea.FocusedItem.Index - 1] = hechizos[listView_hechizos_pelea.FocusedItem.Index];
            hechizos[listView_hechizos_pelea.FocusedItem.Index] = temporal;
            cuenta.pelea_extension.configuracion.guardar();
            refrescar_Lista_Hechizos();
        }

        private void button_bajar_hechizo_Click(object sender, EventArgs e)
        {
            if (listView_hechizos_pelea.FocusedItem == null || listView_hechizos_pelea.FocusedItem.Index == listView_hechizos_pelea.Items.Count - 1)
                return;

            ObservableCollection<PeleaHechizos> hechizos = cuenta.pelea_extension.configuracion.hechizos;
            PeleaHechizos temporal = hechizos[listView_hechizos_pelea.FocusedItem.Index + 1];

            hechizos[listView_hechizos_pelea.FocusedItem.Index + 1] = hechizos[listView_hechizos_pelea.FocusedItem.Index];
            hechizos[listView_hechizos_pelea.FocusedItem.Index] = temporal;
            cuenta.pelea_extension.configuracion.guardar();
            refrescar_Lista_Hechizos();
        }

        private void comenzar_combate_aleatorio_Click(object sender, EventArgs e)
        {
            if (!cuenta.juego.personaje.derechos.PUEDE_ATACAR)
                return;

            List<Monstruos> monstruos = cuenta.juego.mapa.get_Monstruos();

            if (monstruos.Count > 0)
            {
                Celda celda_actual = cuenta.juego.personaje.celda, celda_monstruo_destino = monstruos[0].celda;

                if (celda_actual.id != celda_monstruo_destino.id & celda_monstruo_destino.id > 0)
                {
                    cuenta.logger.log_informacion("UI_PELEAS", "Monstruo encontrado en la casilla " + celda_monstruo_destino.id);
                    
                    switch (cuenta.juego.manejador.movimientos.get_Mover_A_Celda(celda_monstruo_destino, new List<Celda>()))
                    {
                        case ResultadoMovimientos.EXITO:
                            cuenta.logger.log_informacion("UI_PELEA", "Desplazando para comenzar el combate");
                        break;

                        case ResultadoMovimientos.MISMA_CELDA:
                        case ResultadoMovimientos.FALLO:
                        case ResultadoMovimientos.PATHFINDING_ERROR:
                        break;
                    }
                }
            }
            else
                cuenta.logger.log_Error("PELEAS", "No hay monstruos disponibles en el mapa");
        }

        private void checkbox_espectadores_CheckedChanged(object sender, EventArgs e)
        {
            cuenta.pelea_extension.configuracion.desactivar_espectador = checkbox_espectadores.Checked;
            cuenta.pelea_extension.configuracion.guardar();
        }

        private void checkBox_utilizar_dragopavo_CheckedChanged(object sender, EventArgs e)
        {
            cuenta.pelea_extension.configuracion.utilizar_dragopavo = checkBox_utilizar_dragopavo.Checked;
            cuenta.pelea_extension.configuracion.guardar();
        }

        private void comboBox_lista_tactica_SelectedIndexChanged(object sender, EventArgs e)
        {
            cuenta.pelea_extension.configuracion.tactica = (Tactica)comboBox_lista_tactica.SelectedIndex;
            cuenta.pelea_extension.configuracion.guardar();
        }

        private void button_eliminar_hechizo_Click(object sender, EventArgs e)
        {
            if (listView_hechizos_pelea.FocusedItem == null)
                return;

            cuenta.pelea_extension.configuracion.hechizos.RemoveAt(listView_hechizos_pelea.FocusedItem.Index);
            cuenta.pelea_extension.configuracion.guardar();
            refrescar_Lista_Hechizos();
        }

        private void comboBox_lista_posicionamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            cuenta.pelea_extension.configuracion.posicionamiento = (PosicionamientoInicioPelea)comboBox_lista_posicionamiento.SelectedIndex;
            cuenta.pelea_extension.configuracion.guardar();
        }

        private void checkBox_ignorar_invocaciones_CheckedChanged(object sender, EventArgs e)
        {
            cuenta.pelea_extension.configuracion.ignorar_invocaciones = checkBox_ignorar_invocaciones.Checked;
            cuenta.pelea_extension.configuracion.guardar();
        }

        private void ordenar_ListView(ListView lv)
        {
            foreach (ColumnHeader columna in lv.Columns)
                columna.Width = -2;
        }
    }
}
