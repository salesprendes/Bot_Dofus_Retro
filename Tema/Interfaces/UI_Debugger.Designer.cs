using Bot_Dofus_Retro.DarkUI.Controls;

namespace Bot_Dofus_Retro.Tema.Interfaces
{
    partial class UI_Debugger
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
            this.tableLayoutPanel_superior = new System.Windows.Forms.TableLayoutPanel();
            this.checkbox_debugger = new System.Windows.Forms.CheckBox();
            this.button_limpiar_logs_debugger = new Bot_Dofus_Retro.DarkUI.Controls.DarkButton();
            this.ListView_paquete = new Bot_Dofus_Retro.DarkUI.Controls.DarkListView();
            this.tableLayoutPanel_superior.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_superior
            // 
            this.tableLayoutPanel_superior.ColumnCount = 2;
            this.tableLayoutPanel_superior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.31645F));
            this.tableLayoutPanel_superior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.68354F));
            this.tableLayoutPanel_superior.Controls.Add(this.checkbox_debugger, 0, 0);
            this.tableLayoutPanel_superior.Controls.Add(this.button_limpiar_logs_debugger, 1, 0);
            this.tableLayoutPanel_superior.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel_superior.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_superior.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel_superior.Name = "tableLayoutPanel_superior";
            this.tableLayoutPanel_superior.RowCount = 1;
            this.tableLayoutPanel_superior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_superior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel_superior.Size = new System.Drawing.Size(790, 42);
            this.tableLayoutPanel_superior.TabIndex = 0;
            // 
            // checkbox_debugger
            // 
            this.checkbox_debugger.AutoSize = true;
            this.checkbox_debugger.Checked = true;
            this.checkbox_debugger.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_debugger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkbox_debugger.Location = new System.Drawing.Point(3, 4);
            this.checkbox_debugger.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkbox_debugger.Name = "checkbox_debugger";
            this.checkbox_debugger.Size = new System.Drawing.Size(589, 34);
            this.checkbox_debugger.TabIndex = 0;
            this.checkbox_debugger.Text = "Activado";
            this.checkbox_debugger.UseVisualStyleBackColor = true;
            // 
            // button_limpiar_logs_debugger
            // 
            this.button_limpiar_logs_debugger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_limpiar_logs_debugger.Location = new System.Drawing.Point(598, 4);
            this.button_limpiar_logs_debugger.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_limpiar_logs_debugger.Name = "button_limpiar_logs_debugger";
            this.button_limpiar_logs_debugger.Padding = new System.Windows.Forms.Padding(5);
            this.button_limpiar_logs_debugger.Size = new System.Drawing.Size(189, 34);
            this.button_limpiar_logs_debugger.TabIndex = 1;
            this.button_limpiar_logs_debugger.Text = "Limpiar";
            this.button_limpiar_logs_debugger.Click += new System.EventHandler(this.button_limpiar_logs_debugger_Click);
            // 
            // ListView_paquete
            // 
            this.ListView_paquete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView_paquete.Location = new System.Drawing.Point(0, 42);
            this.ListView_paquete.Name = "ListView_paquete";
            this.ListView_paquete.Size = new System.Drawing.Size(790, 458);
            this.ListView_paquete.TabIndex = 1;
            // 
            // UI_Debugger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListView_paquete);
            this.Controls.Add(this.tableLayoutPanel_superior);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UI_Debugger";
            this.Size = new System.Drawing.Size(790, 500);
            this.tableLayoutPanel_superior.ResumeLayout(false);
            this.tableLayoutPanel_superior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_superior;
        private System.Windows.Forms.CheckBox checkbox_debugger;
        private DarkButton button_limpiar_logs_debugger;
        private DarkListView ListView_paquete;
    }
}
