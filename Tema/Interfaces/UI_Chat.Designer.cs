﻿using Bot_Dofus_Retro.DarkUI.Controls;

namespace Bot_Dofus_Retro.Tema.Interfaces
{
    partial class UI_Chat
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
            this.tableLayoutPanel_chat = new System.Windows.Forms.TableLayoutPanel();
            this.txtBox_escribir_consola = new System.Windows.Forms.TextBox();
            this.button_limpiar_consola = new Bot_Dofus_Retro.DarkUI.Controls.DarkButton();
            this.textBox_nombre_privado = new System.Windows.Forms.TextBox();
            this.comboBox_lista_canales = new Bot_Dofus_Retro.DarkUI.Controls.DarkDropdownList();
            this.tableLayout_Canales = new System.Windows.Forms.TableLayoutPanel();
            this.canal_eventos = new Bot_Dofus_Retro.Tema.Controles.ColorCheckBox.ColorCheckBox();
            this.canal_informaciones = new Bot_Dofus_Retro.Tema.Controles.ColorCheckBox.ColorCheckBox();
            this.canal_comercio = new Bot_Dofus_Retro.Tema.Controles.ColorCheckBox.ColorCheckBox();
            this.canal_alineamiento = new Bot_Dofus_Retro.Tema.Controles.ColorCheckBox.ColorCheckBox();
            this.canal_reclutamiento = new Bot_Dofus_Retro.Tema.Controles.ColorCheckBox.ColorCheckBox();
            this.canal_gremio = new Bot_Dofus_Retro.Tema.Controles.ColorCheckBox.ColorCheckBox();
            this.canal_privado = new Bot_Dofus_Retro.Tema.Controles.ColorCheckBox.ColorCheckBox();
            this.canal_general = new Bot_Dofus_Retro.Tema.Controles.ColorCheckBox.ColorCheckBox();
            this.textbox_logs = new Bot_Dofus_Retro.DarkUI.Controls.DarkRichTextBox();
            this.tableLayoutPanel_chat.SuspendLayout();
            this.tableLayout_Canales.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_chat
            // 
            this.tableLayoutPanel_chat.ColumnCount = 4;
            this.tableLayoutPanel_chat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.68493F));
            this.tableLayoutPanel_chat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.27397F));
            this.tableLayoutPanel_chat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.0411F));
            this.tableLayoutPanel_chat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel_chat.Controls.Add(this.txtBox_escribir_consola, 2, 0);
            this.tableLayoutPanel_chat.Controls.Add(this.button_limpiar_consola, 3, 0);
            this.tableLayoutPanel_chat.Controls.Add(this.textBox_nombre_privado, 1, 0);
            this.tableLayoutPanel_chat.Controls.Add(this.comboBox_lista_canales, 0, 0);
            this.tableLayoutPanel_chat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel_chat.Enabled = false;
            this.tableLayoutPanel_chat.Location = new System.Drawing.Point(0, 463);
            this.tableLayoutPanel_chat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel_chat.Name = "tableLayoutPanel_chat";
            this.tableLayoutPanel_chat.RowCount = 1;
            this.tableLayoutPanel_chat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_chat.Size = new System.Drawing.Size(790, 37);
            this.tableLayoutPanel_chat.TabIndex = 2;
            // 
            // txtBox_escribir_consola
            // 
            this.txtBox_escribir_consola.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtBox_escribir_consola.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBox_escribir_consola.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBox_escribir_consola.ForeColor = System.Drawing.SystemColors.Window;
            this.txtBox_escribir_consola.Location = new System.Drawing.Point(294, 3);
            this.txtBox_escribir_consola.Name = "txtBox_escribir_consola";
            this.txtBox_escribir_consola.Size = new System.Drawing.Size(416, 29);
            this.txtBox_escribir_consola.TabIndex = 2;
            this.txtBox_escribir_consola.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_enviar_consola_KeyDown);
            // 
            // button_limpiar_consola
            // 
            this.button_limpiar_consola.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_limpiar_consola.Image = global::Bot_Dofus_Retro.Properties.Resources.icono_limpiar;
            this.button_limpiar_consola.Location = new System.Drawing.Point(716, 4);
            this.button_limpiar_consola.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_limpiar_consola.Name = "button_limpiar_consola";
            this.button_limpiar_consola.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.button_limpiar_consola.Size = new System.Drawing.Size(71, 29);
            this.button_limpiar_consola.TabIndex = 3;
            this.button_limpiar_consola.Click += new System.EventHandler(this.button_limpiar_consola_Click);
            // 
            // textBox_nombre_privado
            // 
            this.textBox_nombre_privado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.textBox_nombre_privado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_nombre_privado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_nombre_privado.Enabled = false;
            this.textBox_nombre_privado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.textBox_nombre_privado.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBox_nombre_privado.Location = new System.Drawing.Point(150, 4);
            this.textBox_nombre_privado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_nombre_privado.MaxLength = 65;
            this.textBox_nombre_privado.Name = "textBox_nombre_privado";
            this.textBox_nombre_privado.Size = new System.Drawing.Size(138, 29);
            this.textBox_nombre_privado.TabIndex = 1;
            // 
            // comboBox_lista_canales
            // 
            this.comboBox_lista_canales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_lista_canales.Location = new System.Drawing.Point(3, 4);
            this.comboBox_lista_canales.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_lista_canales.Name = "comboBox_lista_canales";
            this.comboBox_lista_canales.Size = new System.Drawing.Size(141, 29);
            this.comboBox_lista_canales.TabIndex = 0;
            this.comboBox_lista_canales.SelectedItemChanged += new System.EventHandler(this.comboBox_lista_canales_SelectedItemChanged);
            // 
            // tableLayout_Canales
            // 
            this.tableLayout_Canales.ColumnCount = 1;
            this.tableLayout_Canales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout_Canales.Controls.Add(this.canal_eventos, 0, 7);
            this.tableLayout_Canales.Controls.Add(this.canal_informaciones, 0, 0);
            this.tableLayout_Canales.Controls.Add(this.canal_comercio, 0, 6);
            this.tableLayout_Canales.Controls.Add(this.canal_alineamiento, 0, 4);
            this.tableLayout_Canales.Controls.Add(this.canal_reclutamiento, 0, 5);
            this.tableLayout_Canales.Controls.Add(this.canal_gremio, 0, 3);
            this.tableLayout_Canales.Controls.Add(this.canal_privado, 0, 2);
            this.tableLayout_Canales.Controls.Add(this.canal_general, 0, 1);
            this.tableLayout_Canales.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayout_Canales.Enabled = false;
            this.tableLayout_Canales.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayout_Canales.Location = new System.Drawing.Point(766, 0);
            this.tableLayout_Canales.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayout_Canales.Name = "tableLayout_Canales";
            this.tableLayout_Canales.RowCount = 8;
            this.tableLayout_Canales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayout_Canales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayout_Canales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayout_Canales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayout_Canales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayout_Canales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayout_Canales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayout_Canales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayout_Canales.Size = new System.Drawing.Size(24, 463);
            this.tableLayout_Canales.TabIndex = 1;
            // 
            // canal_eventos
            // 
            this.canal_eventos.AutoSize = true;
            this.canal_eventos.BackColor = System.Drawing.Color.Fuchsia;
            this.canal_eventos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.canal_eventos.ForeColor = System.Drawing.Color.Black;
            this.canal_eventos.Location = new System.Drawing.Point(3, 442);
            this.canal_eventos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.canal_eventos.Name = "canal_eventos";
            this.canal_eventos.Size = new System.Drawing.Size(18, 17);
            this.canal_eventos.TabIndex = 7;
            this.canal_eventos.UseVisualStyleBackColor = false;
            this.canal_eventos.CheckedChanged += new System.EventHandler(this.canal_Chat_Click);
            // 
            // canal_informaciones
            // 
            this.canal_informaciones.AutoSize = true;
            this.canal_informaciones.BackColor = System.Drawing.Color.Lime;
            this.canal_informaciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.canal_informaciones.ForeColor = System.Drawing.Color.Black;
            this.canal_informaciones.Location = new System.Drawing.Point(3, 36);
            this.canal_informaciones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.canal_informaciones.Name = "canal_informaciones";
            this.canal_informaciones.Size = new System.Drawing.Size(18, 17);
            this.canal_informaciones.TabIndex = 0;
            this.canal_informaciones.UseVisualStyleBackColor = false;
            this.canal_informaciones.CheckedChanged += new System.EventHandler(this.canal_Chat_Click);
            // 
            // canal_comercio
            // 
            this.canal_comercio.AutoSize = true;
            this.canal_comercio.BackColor = System.Drawing.Color.SaddleBrown;
            this.canal_comercio.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.canal_comercio.ForeColor = System.Drawing.Color.Black;
            this.canal_comercio.Location = new System.Drawing.Point(3, 378);
            this.canal_comercio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.canal_comercio.Name = "canal_comercio";
            this.canal_comercio.Size = new System.Drawing.Size(18, 17);
            this.canal_comercio.TabIndex = 6;
            this.canal_comercio.UseVisualStyleBackColor = false;
            this.canal_comercio.CheckedChanged += new System.EventHandler(this.canal_Chat_Click);
            // 
            // canal_alineamiento
            // 
            this.canal_alineamiento.AutoSize = true;
            this.canal_alineamiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(146)))), ((int)(((byte)(69)))));
            this.canal_alineamiento.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.canal_alineamiento.ForeColor = System.Drawing.Color.Black;
            this.canal_alineamiento.Location = new System.Drawing.Point(3, 264);
            this.canal_alineamiento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.canal_alineamiento.Name = "canal_alineamiento";
            this.canal_alineamiento.Size = new System.Drawing.Size(18, 17);
            this.canal_alineamiento.TabIndex = 4;
            this.canal_alineamiento.UseVisualStyleBackColor = false;
            this.canal_alineamiento.CheckedChanged += new System.EventHandler(this.canal_Chat_Click);
            // 
            // canal_reclutamiento
            // 
            this.canal_reclutamiento.AutoSize = true;
            this.canal_reclutamiento.BackColor = System.Drawing.Color.Silver;
            this.canal_reclutamiento.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.canal_reclutamiento.ForeColor = System.Drawing.Color.Black;
            this.canal_reclutamiento.Location = new System.Drawing.Point(3, 321);
            this.canal_reclutamiento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.canal_reclutamiento.Name = "canal_reclutamiento";
            this.canal_reclutamiento.Size = new System.Drawing.Size(18, 17);
            this.canal_reclutamiento.TabIndex = 5;
            this.canal_reclutamiento.UseVisualStyleBackColor = false;
            this.canal_reclutamiento.CheckedChanged += new System.EventHandler(this.canal_Chat_Click);
            // 
            // canal_gremio
            // 
            this.canal_gremio.AutoSize = true;
            this.canal_gremio.BackColor = System.Drawing.Color.DarkMagenta;
            this.canal_gremio.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.canal_gremio.ForeColor = System.Drawing.Color.Black;
            this.canal_gremio.Location = new System.Drawing.Point(3, 207);
            this.canal_gremio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.canal_gremio.Name = "canal_gremio";
            this.canal_gremio.Size = new System.Drawing.Size(18, 17);
            this.canal_gremio.TabIndex = 3;
            this.canal_gremio.UseVisualStyleBackColor = false;
            this.canal_gremio.CheckedChanged += new System.EventHandler(this.canal_Chat_Click);
            // 
            // canal_privado
            // 
            this.canal_privado.AutoSize = true;
            this.canal_privado.BackColor = System.Drawing.Color.DodgerBlue;
            this.canal_privado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.canal_privado.ForeColor = System.Drawing.Color.Black;
            this.canal_privado.Location = new System.Drawing.Point(3, 150);
            this.canal_privado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.canal_privado.Name = "canal_privado";
            this.canal_privado.Size = new System.Drawing.Size(18, 17);
            this.canal_privado.TabIndex = 2;
            this.canal_privado.UseVisualStyleBackColor = false;
            this.canal_privado.CheckedChanged += new System.EventHandler(this.canal_Chat_Click);
            // 
            // canal_general
            // 
            this.canal_general.AutoSize = true;
            this.canal_general.BackColor = System.Drawing.Color.Black;
            this.canal_general.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.canal_general.ForeColor = System.Drawing.Color.Black;
            this.canal_general.Location = new System.Drawing.Point(3, 93);
            this.canal_general.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.canal_general.Name = "canal_general";
            this.canal_general.Size = new System.Drawing.Size(18, 17);
            this.canal_general.TabIndex = 1;
            this.canal_general.UseVisualStyleBackColor = false;
            this.canal_general.CheckedChanged += new System.EventHandler(this.canal_Chat_Click);
            // 
            // textbox_logs
            // 
            this.textbox_logs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.textbox_logs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_logs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textbox_logs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.textbox_logs.Location = new System.Drawing.Point(0, 0);
            this.textbox_logs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textbox_logs.MaxLength = 500;
            this.textbox_logs.Name = "textbox_logs";
            this.textbox_logs.Size = new System.Drawing.Size(766, 463);
            this.textbox_logs.TabIndex = 0;
            this.textbox_logs.Text = "";
            // 
            // UI_Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textbox_logs);
            this.Controls.Add(this.tableLayout_Canales);
            this.Controls.Add(this.tableLayoutPanel_chat);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UI_Chat";
            this.Size = new System.Drawing.Size(790, 500);
            this.Load += new System.EventHandler(this.UI_Chat_Load);
            this.tableLayoutPanel_chat.ResumeLayout(false);
            this.tableLayoutPanel_chat.PerformLayout();
            this.tableLayout_Canales.ResumeLayout(false);
            this.tableLayout_Canales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_chat;
        private System.Windows.Forms.TextBox textBox_nombre_privado;
        private DarkButton button_limpiar_consola;
        private DarkDropdownList comboBox_lista_canales;
        private System.Windows.Forms.TableLayoutPanel tableLayout_Canales;
        private Controles.ColorCheckBox.ColorCheckBox canal_eventos;
        private Controles.ColorCheckBox.ColorCheckBox canal_informaciones;
        private Controles.ColorCheckBox.ColorCheckBox canal_comercio;
        private Controles.ColorCheckBox.ColorCheckBox canal_alineamiento;
        private Controles.ColorCheckBox.ColorCheckBox canal_reclutamiento;
        private Controles.ColorCheckBox.ColorCheckBox canal_gremio;
        private Controles.ColorCheckBox.ColorCheckBox canal_privado;
        private Controles.ColorCheckBox.ColorCheckBox canal_general;
        private DarkRichTextBox textbox_logs;
        private System.Windows.Forms.TextBox txtBox_escribir_consola;
    }
}
