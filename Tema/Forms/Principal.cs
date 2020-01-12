using Bot_Dofus_Retro.Otros;
using Bot_Dofus_Retro.Otros.Grupos;
using Bot_Dofus_Retro.Tema.Interfaces;
using Bot_Dofus_Retro.Utilidades.Configuracion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bot_Dofus_Retro.DarkUI.Forms;
using Bot_Dofus_Retro.DarkUI.Docking;
using Bot_Dofus_Retro.DarkUI.Controls;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2021 Alvaro Prendes — Todos los derechos reservados.
	Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Tema.Forms
{
    public partial class Principal : DarkForm
    {
        public static Dictionary<string, DarkDockContent> cuentas_cargadas;

        public Principal()
        {
            InitializeComponent();
            cuentas_cargadas = new Dictionary<string, DarkDockContent>();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory("mapas");
            Directory.CreateDirectory("items");
        }

        private void gestionDeCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (GestionCuentas gestion_cuentas = new GestionCuentas())
            {
                if (gestion_cuentas.ShowDialog() == DialogResult.OK)
                {
                    List<CuentaConf> cuentas_para_cargar = gestion_cuentas.get_Cuentas_Cargadas();
                    CuentaConf configuracion_cuenta = cuentas_para_cargar.First();
                    DarkTreeNode nodo_lider = get_Nuevo_Nodo(configuracion_cuenta.nombre_cuenta);

                    if (cuentas_para_cargar.Count > 1)
                    {
                        /** Crea al lider **/
                        Cuenta cuenta_lider = new Cuenta(configuracion_cuenta);
                        Grupo grupo = new Grupo(cuenta_lider);
                        cuentas_cargadas.Add(configuracion_cuenta.nombre_cuenta, agregar_Nueva_Tab_Pagina(new UI_Principal(grupo.lider)));
                        cuentas_para_cargar.Remove(configuracion_cuenta);

                        /** Crea los miembros **/
                        foreach (CuentaConf cuenta_conf in cuentas_para_cargar)
                        {
                            Cuenta cuenta = new Cuenta(cuenta_conf);
                            grupo.agregar_Miembro(cuenta);
                            cuentas_cargadas.Add(cuenta_conf.nombre_cuenta, agregar_Nueva_Tab_Pagina(new UI_Principal(cuenta)));
                            nodo_lider.Nodes.Add(get_Nuevo_Nodo(cuenta_conf.nombre_cuenta));
                        }
                    }
                    else
                        cuentas_cargadas.Add(configuracion_cuenta.nombre_cuenta, agregar_Nueva_Tab_Pagina(new UI_Principal(new Cuenta(configuracion_cuenta))));

                    darkTreeView1.Nodes.Add(nodo_lider);
                    darkTreeView1.Focus();
                    darkTreeView1.SelectNode(nodo_lider);
                }
            }
        }

        private DarkDockContent agregar_Nueva_Tab_Pagina(DarkDockContent control)
        {
            darkDockPanel_principal.AddContent(control);
            return control;
        }

        private DarkTreeNode get_Nuevo_Nodo(string nombre_cuenta) => new DarkTreeNode(nombre_cuenta) { Icon = Properties.Resources.desconectado };

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Opciones form_opciones = new Opciones())
                form_opciones.ShowDialog();
        }

        private void DarkTreeView1_SelectedNodesChanged(object sender, EventArgs e)
        {
            foreach (DarkTreeNode nodo in darkTreeView1.SelectedNodes)
            {
                if (cuentas_cargadas.ContainsKey(nodo.Text))
                {
                    DarkDockContent pagina = cuentas_cargadas[nodo.Text];
                    darkDockPanel_principal.ActiveGroup.SetVisibleContent(pagina);
                    darkTreeView1.Focus();
                }
            }
        }

        private void DarkDockPanel_principal_ContentRemoved(object sender, DockContentEventArgs e)
        {
            int contador_nodo = 0, contador_subnodo = 0;
            bool nodo_encontrado = false, subnodo_encontrado = false;
            DarkTreeNode nodo, subnodo;

            while (!nodo_encontrado && contador_nodo < darkTreeView1.Nodes.Count)
            {
                nodo = darkTreeView1.Nodes[contador_nodo];

                if (nodo.Nodes.Count > 0)// primero borramos los subnodos
                {
                    while (!subnodo_encontrado && contador_subnodo < nodo.Nodes.Count)
                    {
                        subnodo = nodo.Nodes[contador_subnodo];

                        if (subnodo.Text.Equals(e.Content.DockText))
                        {
                            subnodo.Remove();
                            subnodo_encontrado = true;
                            nodo_encontrado = true;
                        }

                        contador_subnodo++;
                    }
                    contador_subnodo = 0;
                }

                if (nodo.Text.Equals(e.Content.DockText))
                {
                    nodo.Remove();
                    nodo_encontrado = true;
                }

                contador_nodo++;
            }

            if (darkTreeView1.Nodes.Count > 0)
            {
                int total = darkTreeView1.Nodes.Count;
                darkTreeView1.SelectNode(darkTreeView1.Nodes[total - 1]);
            }
        }

        private void DarkDockPanel_principal_ContenidoCambiado(object sender, DockContentEventArgs e)
        {
            int contador_nodo = 0, contador_subnodo = 0;
            bool encontrado = false;
            DarkTreeNode nodo, subnodo;

            while (!encontrado && contador_nodo < darkTreeView1.Nodes.Count)
            {
                nodo = darkTreeView1.Nodes[contador_nodo];

                if (nodo.Nodes.Count > 0)
                {
                    while (!encontrado && contador_subnodo < nodo.Nodes.Count)
                    {
                        subnodo = nodo.Nodes[contador_subnodo];

                        if (subnodo.Text.Equals(e.Content.DockText))
                        {
                            subnodo.Icon = e.Content.Icon;
                            encontrado = true;
                        }

                        contador_subnodo++;
                    }
                    contador_subnodo = 0;
                }

                if (nodo.Text.Equals(e.Content.DockText))
                {
                    nodo.Icon = e.Content.Icon;
                    encontrado = true;
                }

                contador_nodo++;
            }
        }
    }
}
