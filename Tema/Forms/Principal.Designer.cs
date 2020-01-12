using Bot_Dofus_Retro.DarkUI.Controls;

namespace Bot_Dofus_Retro.Tema.Forms
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.gestionDeCuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkSeparator1 = new Bot_Dofus_Retro.DarkUI.Controls.DarkSeparator();
            this.darkSectionPanel1 = new Bot_Dofus_Retro.DarkUI.Controls.DarkSectionPanel();
            this.darkTreeView1 = new Bot_Dofus_Retro.DarkUI.Controls.DarkTreeView();
            this.darkDockPanel_principal = new Bot_Dofus_Retro.DarkUI.Docking.DarkDockPanel();
            this.menuSuperiorPrincipal = new Bot_Dofus_Retro.DarkUI.Controls.DarkMenuStrip();
            this.darkSectionPanel1.SuspendLayout();
            this.menuSuperiorPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // gestionDeCuentasToolStripMenuItem
            // 
            this.gestionDeCuentasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.gestionDeCuentasToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.gestionDeCuentasToolStripMenuItem.Image = global::Bot_Dofus_Retro.Properties.Resources.gestion_cuentas;
            this.gestionDeCuentasToolStripMenuItem.Name = "gestionDeCuentasToolStripMenuItem";
            this.gestionDeCuentasToolStripMenuItem.Size = new System.Drawing.Size(135, 20);
            this.gestionDeCuentasToolStripMenuItem.Text = "Gestión de cuentas";
            this.gestionDeCuentasToolStripMenuItem.Click += new System.EventHandler(this.gestionDeCuentasToolStripMenuItem_Click);
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.opcionesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.opcionesToolStripMenuItem.Image = global::Bot_Dofus_Retro.Properties.Resources.icono_ajustes;
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.opcionesToolStripMenuItem.Text = "Ajustes";
            this.opcionesToolStripMenuItem.Click += new System.EventHandler(this.opcionesToolStripMenuItem_Click);
            // 
            // darkSeparator1
            // 
            this.darkSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkSeparator1.Location = new System.Drawing.Point(0, 24);
            this.darkSeparator1.Name = "darkSeparator1";
            this.darkSeparator1.Size = new System.Drawing.Size(980, 2);
            this.darkSeparator1.TabIndex = 3;
            this.darkSeparator1.Text = "darkSeparator1";
            // 
            // darkSectionPanel1
            // 
            this.darkSectionPanel1.Controls.Add(this.darkTreeView1);
            this.darkSectionPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.darkSectionPanel1.Location = new System.Drawing.Point(0, 26);
            this.darkSectionPanel1.Name = "darkSectionPanel1";
            this.darkSectionPanel1.SectionHeader = "CUENTAS";
            this.darkSectionPanel1.Size = new System.Drawing.Size(200, 635);
            this.darkSectionPanel1.TabIndex = 4;
            // 
            // darkTreeView1
            // 
            this.darkTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkTreeView1.Location = new System.Drawing.Point(1, 25);
            this.darkTreeView1.MaxDragChange = 20;
            this.darkTreeView1.Name = "darkTreeView1";
            this.darkTreeView1.ShowIcons = true;
            this.darkTreeView1.Size = new System.Drawing.Size(198, 609);
            this.darkTreeView1.TabIndex = 6;
            this.darkTreeView1.Text = "darkTreeView1";
            this.darkTreeView1.SelectedNodesChanged += new System.EventHandler(this.DarkTreeView1_SelectedNodesChanged);
            // 
            // darkDockPanel_principal
            // 
            this.darkDockPanel_principal.activar_tabs = false;
            this.darkDockPanel_principal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.darkDockPanel_principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkDockPanel_principal.Location = new System.Drawing.Point(200, 26);
            this.darkDockPanel_principal.Name = "darkDockPanel_principal";
            this.darkDockPanel_principal.Size = new System.Drawing.Size(780, 635);
            this.darkDockPanel_principal.TabIndex = 0;
            this.darkDockPanel_principal.ContentRemoved += new System.EventHandler<Bot_Dofus_Retro.DarkUI.Docking.DockContentEventArgs>(this.DarkDockPanel_principal_ContentRemoved);
            this.darkDockPanel_principal.ContenidoCambiado += new System.EventHandler<Bot_Dofus_Retro.DarkUI.Docking.DockContentEventArgs>(this.DarkDockPanel_principal_ContenidoCambiado);
            // 
            // menuSuperiorPrincipal
            // 
            this.menuSuperiorPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.menuSuperiorPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.menuSuperiorPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDeCuentasToolStripMenuItem,
            this.opcionesToolStripMenuItem});
            this.menuSuperiorPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuSuperiorPrincipal.Name = "menuSuperiorPrincipal";
            this.menuSuperiorPrincipal.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.menuSuperiorPrincipal.Size = new System.Drawing.Size(980, 24);
            this.menuSuperiorPrincipal.TabIndex = 0;
            this.menuSuperiorPrincipal.Text = "menuSuperiorPrincipal";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 661);
            this.Controls.Add(this.darkDockPanel_principal);
            this.Controls.Add(this.darkSectionPanel1);
            this.Controls.Add(this.darkSeparator1);
            this.Controls.Add(this.menuSuperiorPrincipal);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuSuperiorPrincipal;
            this.MinimumSize = new System.Drawing.Size(996, 700);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BotDofus Retro - Alvaro Prendes";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.darkSectionPanel1.ResumeLayout(false);
            this.menuSuperiorPrincipal.ResumeLayout(false);
            this.menuSuperiorPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem gestionDeCuentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private DarkSeparator darkSeparator1;
        private DarkSectionPanel darkSectionPanel1;
        private DarkTreeView darkTreeView1;
        private DarkUI.Docking.DarkDockPanel darkDockPanel_principal;
        private DarkMenuStrip menuSuperiorPrincipal;
    }
}

