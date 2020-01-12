namespace Bot_Dofus_Retro.Tema.Interfaces
{
    partial class UI_TabPersonaje
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
            this.dockPanel_UI = new Bot_Dofus_Retro.DarkUI.Docking.DarkDockPanel();
            this.SuspendLayout();
            // 
            // dockPanel_UI
            // 
            this.dockPanel_UI.activar_tabs = true;
            this.dockPanel_UI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.dockPanel_UI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel_UI.Location = new System.Drawing.Point(0, 0);
            this.dockPanel_UI.Name = "dockPanel_UI";
            this.dockPanel_UI.Size = new System.Drawing.Size(790, 500);
            this.dockPanel_UI.TabIndex = 0;
            // 
            // UI_TabPersonaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dockPanel_UI);
            this.Name = "UI_TabPersonaje";
            this.Size = new System.Drawing.Size(790, 500);
            this.ResumeLayout(false);

        }

        #endregion

        private Bot_Dofus_Retro.DarkUI.Docking.DarkDockPanel dockPanel_UI;
    }
}
