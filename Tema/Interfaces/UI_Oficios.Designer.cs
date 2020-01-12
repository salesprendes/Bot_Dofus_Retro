namespace Bot_Dofus_Retro.Tema.Interfaces
{
    partial class UI_Oficios
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
            this.dataGridView_oficios = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Experiencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ListView_skills = new Bot_Dofus_Retro.DarkUI.Controls.DarkListView();
            this.darkSectionPanel_skills = new Bot_Dofus_Retro.DarkUI.Controls.DarkSectionPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_oficios)).BeginInit();
            this.darkSectionPanel_skills.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_oficios
            // 
            this.dataGridView_oficios.AllowUserToAddRows = false;
            this.dataGridView_oficios.AllowUserToDeleteRows = false;
            this.dataGridView_oficios.AllowUserToOrderColumns = true;
            this.dataGridView_oficios.AllowUserToResizeColumns = false;
            this.dataGridView_oficios.AllowUserToResizeRows = false;
            this.dataGridView_oficios.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView_oficios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_oficios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nombre,
            this.Nivel,
            this.Experiencia,
            this.porcentaje});
            this.dataGridView_oficios.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView_oficios.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView_oficios.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_oficios.Name = "dataGridView_oficios";
            this.dataGridView_oficios.ReadOnly = true;
            this.dataGridView_oficios.RowHeadersVisible = false;
            this.dataGridView_oficios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_oficios.Size = new System.Drawing.Size(790, 236);
            this.dataGridView_oficios.TabIndex = 4;
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.FillWeight = 200F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 200;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 200;
            // 
            // Nivel
            // 
            this.Nivel.HeaderText = "Nivel";
            this.Nivel.Name = "Nivel";
            this.Nivel.ReadOnly = true;
            // 
            // Experiencia
            // 
            this.Experiencia.FillWeight = 200F;
            this.Experiencia.HeaderText = "Experiencia";
            this.Experiencia.MinimumWidth = 200;
            this.Experiencia.Name = "Experiencia";
            this.Experiencia.ReadOnly = true;
            this.Experiencia.Width = 200;
            // 
            // porcentaje
            // 
            this.porcentaje.HeaderText = "Porcentaje";
            this.porcentaje.Name = "porcentaje";
            this.porcentaje.ReadOnly = true;
            // 
            // ListView_skills
            // 
            this.ListView_skills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView_skills.Location = new System.Drawing.Point(1, 25);
            this.ListView_skills.Name = "ListView_skills";
            this.ListView_skills.Size = new System.Drawing.Size(788, 238);
            this.ListView_skills.TabIndex = 5;
            // 
            // darkSectionPanel_skills
            // 
            this.darkSectionPanel_skills.Controls.Add(this.ListView_skills);
            this.darkSectionPanel_skills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkSectionPanel_skills.Location = new System.Drawing.Point(0, 236);
            this.darkSectionPanel_skills.Name = "darkSectionPanel_skills";
            this.darkSectionPanel_skills.SectionHeader = "SKILLS";
            this.darkSectionPanel_skills.Size = new System.Drawing.Size(790, 264);
            this.darkSectionPanel_skills.TabIndex = 6;
            // 
            // UI_Oficios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.darkSectionPanel_skills);
            this.Controls.Add(this.dataGridView_oficios);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UI_Oficios";
            this.Size = new System.Drawing.Size(790, 500);
            this.Load += new System.EventHandler(this.UI_Oficios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_oficios)).EndInit();
            this.darkSectionPanel_skills.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_oficios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Experiencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentaje;
        private Bot_Dofus_Retro.DarkUI.Controls.DarkListView ListView_skills;
        private Bot_Dofus_Retro.DarkUI.Controls.DarkSectionPanel darkSectionPanel_skills;
    }
}
