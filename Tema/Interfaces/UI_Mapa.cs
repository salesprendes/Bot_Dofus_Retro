using Bot_Dofus_Retro.DarkUI.Docking;
using Bot_Dofus_Retro.Otros;
using Bot_Dofus_Retro.Otros.Game.Entidades.Manejadores.Movimientos;
using Bot_Dofus_Retro.Otros.Mapas;
using Bot_Dofus_Retro.Otros.Mapas.Movimiento;
using Bot_Dofus_Retro.Tema.Controles.ControlMapa;
using Bot_Dofus_Retro.Tema.Controles.ControlMapa.Animaciones;
using Bot_Dofus_Retro.Tema.Controles.ControlMapa.Celdas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2023 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Tema.Interfaces
{
    public partial class UI_Mapa : DarkDocument
    {
        private Cuenta cuenta = null;

        public UI_Mapa(Cuenta _cuenta, string nombre, Bitmap icono)
        {
            InitializeComponent();

            cuenta = _cuenta;
            control_mapa.set_Cuenta(cuenta);
            Icon = icono;
            DockText = nombre;

            comboBox_calidad_minimapa.SelectedIndex = (byte)control_mapa.TipoCalidad;
            set_Eventos();
        }

        private void set_Eventos()
        {
            comboBox_calidad_minimapa.SelectedIndexChanged += (s, e) => control_mapa.TipoCalidad = (CalidadMapa)comboBox_calidad_minimapa.SelectedIndex;
            control_mapa.clic_celda += mapa_Control_Celda_Clic;
            cuenta.juego.mapa.mapa_actualizado += get_Eventos_Mapa_Cambiado;
            cuenta.juego.mapa.entidades_actualizadas += () => control_mapa.Invalidate();
            cuenta.juego.personaje.movimiento_pathfinding_minimapa += get_Dibujar_Pathfinding;
            cuenta.juego.pelea.pelea_creada += get_Eventos_Mapa_Cambiado;
        }

        private void get_Eventos_Mapa_Cambiado()
        {
            BeginInvoke((Action)(() =>
            {
                Mapa mapa = cuenta.juego.mapa;

                byte anchura_actual = control_mapa.mapa_anchura, altura_actual = control_mapa.mapa_altura;
                byte anchura_nueva = mapa.anchura, altura_nueva = mapa.altura;

                /** Evitamos dibujar por cada cambio la cuadricula **/
                if (anchura_actual != anchura_nueva || altura_actual != altura_nueva)
                {
                    control_mapa.mapa_anchura = anchura_nueva;
                    control_mapa.mapa_altura = altura_nueva;

                    control_mapa.set_Celda_Numero();
                    control_mapa.dibujar_Cuadricula();
                }

                label_mapa_id.Text = $"Mapa ID: {mapa.id} {mapa.coordenadas}";
                control_mapa.refrescar_Mapa();
            }));
        }

        private void mapa_Control_Celda_Clic(CeldaMapa celda, MouseButtons botones, bool abajo)
        {
            Mapa mapa = cuenta.juego.mapa;
            Celda celda_actual = cuenta.juego.personaje.celda, celda_destino = mapa.get_Celda_Id(celda.id);

            if (botones == MouseButtons.Left && celda_actual.id != 0 && celda_destino.id != 0 && !abajo)
                cuenta.juego.manejador.movimientos.get_Cambiar_Mapa(MapaTeleportCeldas.NINGUNO, celda_destino);
        }

        private void get_Dibujar_Pathfinding(List<Celda> lista_celdas) => control_mapa.agregar_Animacion(cuenta.juego.personaje.id, lista_celdas, PathFinderUtil.get_Tiempo_Desplazamiento_Mapa(lista_celdas.First(), lista_celdas), TipoAnimaciones.PERSONAJE);
        private void checkBox_animaciones_CheckedChanged(object sender, EventArgs e) => control_mapa.Mostrar_Animaciones = checkBox_animaciones.Checked;
        private void checkBox_mostrar_celdas_CheckedChanged(object sender, EventArgs e) => control_mapa.Mostrar_Celdas_Id = checkBox_mostrar_celdas.Checked;
    }
}
