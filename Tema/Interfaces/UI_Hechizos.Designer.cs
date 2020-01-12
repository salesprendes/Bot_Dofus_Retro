namespace Bot_Dofus_Retro.Tema.Interfaces
{
    partial class UI_Hechizos
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.darkSectionPanel_hechizos = new Bot_Dofus_Retro.DarkUI.Controls.DarkSectionPanel();
            this.ListView_hechizos = new Bot_Dofus_Retro.DarkUI.Controls.DarkListView();
            this.SuspendLayout();
            // 
            // darkSectionPanel_hechizos
            // 
            this.darkSectionPanel_hechizos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.darkSectionPanel_hechizos.Location = new System.Drawing.Point(0, 357);
            this.darkSectionPanel_hechizos.Name = "darkSectionPanel_hechizos";
            this.darkSectionPanel_hechizos.SectionHeader = "Opciones";
            this.darkSectionPanel_hechizos.Size = new System.Drawing.Size(790, 143);
            this.darkSectionPanel_hechizos.TabIndex = 0;
            // 
            // ListView_hechizos
            // 
            this.ListView_hechizos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView_hechizos.Location = new System.Drawing.Point(0, 0);
            this.ListView_hechizos.Name = "ListView_hechizos";
            this.ListView_hechizos.Size = new System.Drawing.Size(790, 357);
            this.ListView_hechizos.TabIndex = 1;
            this.ListView_hechizos.Text = "darkListView1";
            // 
            // UI_Hechizos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListView_hechizos);
            this.Controls.Add(this.darkSectionPanel_hechizos);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UI_Hechizos";
            this.Size = new System.Drawing.Size(790, 500);
            this.ResumeLayout(false);

        }

        #endregion

        private Bot_Dofus_Retro.DarkUI.Controls.DarkSectionPanel darkSectionPanel_hechizos;
        private Bot_Dofus_Retro.DarkUI.Controls.DarkListView ListView_hechizos;
    }
}
