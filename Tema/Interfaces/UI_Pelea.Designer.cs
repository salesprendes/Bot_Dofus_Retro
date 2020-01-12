namespace Bot_Dofus_Retro.Tema.Interfaces
{
    partial class UI_Pelea
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_Pelea));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_general_pelea = new System.Windows.Forms.TabPage();
            this.checkBox_ignorar_invocaciones = new System.Windows.Forms.CheckBox();
            this.checkBox_utilizar_dragopavo = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkbox_espectadores = new System.Windows.Forms.CheckBox();
            this.groupBox_durante_combate = new System.Windows.Forms.GroupBox();
            this.comboBox_lista_tactica = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox_preparacion = new System.Windows.Forms.GroupBox();
            this.comboBox_lista_posicionamiento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_comenzar_pelea = new System.Windows.Forms.Button();
            this.tabPage_hechizos_pelea = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.listView_hechizos_pelea = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.focus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.n_lanzamientos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lanzamiento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metodo_distancia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.operador_distancia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.distancia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.button_subir_hechizo = new System.Windows.Forms.Button();
            this.button_informacion_hechizo = new System.Windows.Forms.Button();
            this.button_bajar_hechizo = new System.Windows.Forms.Button();
            this.button_eliminar_hechizo = new System.Windows.Forms.Button();
            this.groupBox_agregar_hechizo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_principal = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox_modo_lanzamiento = new System.Windows.Forms.ComboBox();
            this.label_agregar_metodo = new System.Windows.Forms.Label();
            this.label_agregar_focus = new System.Windows.Forms.Label();
            this.label_agregar_nombre = new System.Windows.Forms.Label();
            this.comboBox_lista_hechizos = new System.Windows.Forms.ComboBox();
            this.comboBox_focus_hechizo = new System.Windows.Forms.ComboBox();
            this.label_agregar_lanzamientos = new System.Windows.Forms.Label();
            this.numeric_lanzamientos_turno = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_AOE = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel_segundario = new System.Windows.Forms.TableLayoutPanel();
            this.label_agregar_distancia = new System.Windows.Forms.Label();
            this.comboBox_distancia_enemigo = new System.Windows.Forms.ComboBox();
            this.numeric_distancia = new System.Windows.Forms.NumericUpDown();
            this.comboBox_distancia_operador = new System.Windows.Forms.ComboBox();
            this.button_agregar_hechizo = new System.Windows.Forms.Button();
            this.lista_imagenes = new System.Windows.Forms.ImageList(this.components);
            this.checkBox_piedra_equipada = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage_general_pelea.SuspendLayout();
            this.groupBox_durante_combate.SuspendLayout();
            this.groupBox_preparacion.SuspendLayout();
            this.tabPage_hechizos_pelea.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.groupBox_agregar_hechizo.SuspendLayout();
            this.tableLayoutPanel_principal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_lanzamientos_turno)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel_segundario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_distancia)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_general_pelea);
            this.tabControl1.Controls.Add(this.tabPage_hechizos_pelea);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.lista_imagenes;
            this.tabControl1.ItemSize = new System.Drawing.Size(67, 26);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(790, 500);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_general_pelea
            // 
            this.tabPage_general_pelea.Controls.Add(this.checkBox_ignorar_invocaciones);
            this.tabPage_general_pelea.Controls.Add(this.checkBox_utilizar_dragopavo);
            this.tabPage_general_pelea.Controls.Add(this.checkBox1);
            this.tabPage_general_pelea.Controls.Add(this.checkbox_espectadores);
            this.tabPage_general_pelea.Controls.Add(this.groupBox_durante_combate);
            this.tabPage_general_pelea.Controls.Add(this.groupBox_preparacion);
            this.tabPage_general_pelea.Controls.Add(this.button_comenzar_pelea);
            this.tabPage_general_pelea.ImageIndex = 0;
            this.tabPage_general_pelea.Location = new System.Drawing.Point(4, 30);
            this.tabPage_general_pelea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_general_pelea.Name = "tabPage_general_pelea";
            this.tabPage_general_pelea.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_general_pelea.Size = new System.Drawing.Size(782, 466);
            this.tabPage_general_pelea.TabIndex = 0;
            this.tabPage_general_pelea.Text = "General";
            this.tabPage_general_pelea.UseVisualStyleBackColor = true;
            // 
            // checkBox_ignorar_invocaciones
            // 
            this.checkBox_ignorar_invocaciones.AutoSize = true;
            this.checkBox_ignorar_invocaciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox_ignorar_invocaciones.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.checkBox_ignorar_invocaciones.Location = new System.Drawing.Point(3, 187);
            this.checkBox_ignorar_invocaciones.Name = "checkBox_ignorar_invocaciones";
            this.checkBox_ignorar_invocaciones.Size = new System.Drawing.Size(776, 25);
            this.checkBox_ignorar_invocaciones.TabIndex = 0;
            this.checkBox_ignorar_invocaciones.Text = "Ignorar Invocaciones";
            this.checkBox_ignorar_invocaciones.UseVisualStyleBackColor = true;
            this.checkBox_ignorar_invocaciones.CheckedChanged += new System.EventHandler(this.checkBox_ignorar_invocaciones_CheckedChanged);
            // 
            // checkBox_utilizar_dragopavo
            // 
            this.checkBox_utilizar_dragopavo.AutoSize = true;
            this.checkBox_utilizar_dragopavo.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox_utilizar_dragopavo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.checkBox_utilizar_dragopavo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBox_utilizar_dragopavo.Location = new System.Drawing.Point(3, 162);
            this.checkBox_utilizar_dragopavo.Name = "checkBox_utilizar_dragopavo";
            this.checkBox_utilizar_dragopavo.Size = new System.Drawing.Size(776, 25);
            this.checkBox_utilizar_dragopavo.TabIndex = 1;
            this.checkBox_utilizar_dragopavo.Text = "Utilizar Dragopavo";
            this.checkBox_utilizar_dragopavo.UseVisualStyleBackColor = true;
            this.checkBox_utilizar_dragopavo.CheckedChanged += new System.EventHandler(this.checkBox_utilizar_dragopavo_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.checkBox1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBox1.Location = new System.Drawing.Point(3, 137);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(776, 25);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Bloquear el combate";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkbox_espectadores
            // 
            this.checkbox_espectadores.AutoSize = true;
            this.checkbox_espectadores.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkbox_espectadores.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.checkbox_espectadores.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkbox_espectadores.Location = new System.Drawing.Point(3, 112);
            this.checkbox_espectadores.Name = "checkbox_espectadores";
            this.checkbox_espectadores.Size = new System.Drawing.Size(776, 25);
            this.checkbox_espectadores.TabIndex = 0;
            this.checkbox_espectadores.Text = "Desactivar espectador";
            this.checkbox_espectadores.UseVisualStyleBackColor = true;
            this.checkbox_espectadores.CheckedChanged += new System.EventHandler(this.checkbox_espectadores_CheckedChanged);
            // 
            // groupBox_durante_combate
            // 
            this.groupBox_durante_combate.Controls.Add(this.comboBox_lista_tactica);
            this.groupBox_durante_combate.Controls.Add(this.label2);
            this.groupBox_durante_combate.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_durante_combate.Location = new System.Drawing.Point(3, 61);
            this.groupBox_durante_combate.Name = "groupBox_durante_combate";
            this.groupBox_durante_combate.Size = new System.Drawing.Size(776, 51);
            this.groupBox_durante_combate.TabIndex = 2;
            this.groupBox_durante_combate.TabStop = false;
            this.groupBox_durante_combate.Text = "Durante el combate";
            // 
            // comboBox_lista_tactica
            // 
            this.comboBox_lista_tactica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_lista_tactica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_lista_tactica.FormattingEnabled = true;
            this.comboBox_lista_tactica.Items.AddRange(new object[] {
            "Agresiva",
            "Pasiva",
            "Fugitiva"});
            this.comboBox_lista_tactica.Location = new System.Drawing.Point(70, 21);
            this.comboBox_lista_tactica.Name = "comboBox_lista_tactica";
            this.comboBox_lista_tactica.Size = new System.Drawing.Size(703, 25);
            this.comboBox_lista_tactica.TabIndex = 1;
            this.comboBox_lista_tactica.SelectedIndexChanged += new System.EventHandler(this.comboBox_lista_tactica_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Táctica:";
            // 
            // groupBox_preparacion
            // 
            this.groupBox_preparacion.Controls.Add(this.comboBox_lista_posicionamiento);
            this.groupBox_preparacion.Controls.Add(this.label1);
            this.groupBox_preparacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_preparacion.Location = new System.Drawing.Point(3, 4);
            this.groupBox_preparacion.Name = "groupBox_preparacion";
            this.groupBox_preparacion.Size = new System.Drawing.Size(776, 57);
            this.groupBox_preparacion.TabIndex = 0;
            this.groupBox_preparacion.TabStop = false;
            this.groupBox_preparacion.Text = "Preparación";
            // 
            // comboBox_lista_posicionamiento
            // 
            this.comboBox_lista_posicionamiento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_lista_posicionamiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_lista_posicionamiento.FormattingEnabled = true;
            this.comboBox_lista_posicionamiento.Items.AddRange(new object[] {
            "Lejos de los enemigos",
            "Cerca de los enemigos",
            "No moverse"});
            this.comboBox_lista_posicionamiento.Location = new System.Drawing.Point(332, 21);
            this.comboBox_lista_posicionamiento.Name = "comboBox_lista_posicionamiento";
            this.comboBox_lista_posicionamiento.Size = new System.Drawing.Size(441, 25);
            this.comboBox_lista_posicionamiento.TabIndex = 2;
            this.comboBox_lista_posicionamiento.SelectedIndexChanged += new System.EventHandler(this.comboBox_lista_posicionamiento_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Posicionamiento al comenzar el combate:";
            // 
            // button_comenzar_pelea
            // 
            this.button_comenzar_pelea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_comenzar_pelea.Location = new System.Drawing.Point(3, 424);
            this.button_comenzar_pelea.Name = "button_comenzar_pelea";
            this.button_comenzar_pelea.Size = new System.Drawing.Size(776, 38);
            this.button_comenzar_pelea.TabIndex = 1;
            this.button_comenzar_pelea.Text = "Comenzar combate aleatorio";
            this.button_comenzar_pelea.UseVisualStyleBackColor = true;
            this.button_comenzar_pelea.Click += new System.EventHandler(this.comenzar_combate_aleatorio_Click);
            // 
            // tabPage_hechizos_pelea
            // 
            this.tabPage_hechizos_pelea.Controls.Add(this.tableLayoutPanel6);
            this.tabPage_hechizos_pelea.Controls.Add(this.groupBox_agregar_hechizo);
            this.tabPage_hechizos_pelea.Controls.Add(this.groupBox1);
            this.tabPage_hechizos_pelea.Controls.Add(this.button_agregar_hechizo);
            this.tabPage_hechizos_pelea.ImageIndex = 1;
            this.tabPage_hechizos_pelea.Location = new System.Drawing.Point(4, 30);
            this.tabPage_hechizos_pelea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_hechizos_pelea.Name = "tabPage_hechizos_pelea";
            this.tabPage_hechizos_pelea.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_hechizos_pelea.Size = new System.Drawing.Size(782, 466);
            this.tabPage_hechizos_pelea.TabIndex = 1;
            this.tabPage_hechizos_pelea.Text = "Hechizos";
            this.tabPage_hechizos_pelea.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 92.63302F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.366985F));
            this.tableLayoutPanel6.Controls.Add(this.listView_hechizos_pelea, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel8, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(776, 185);
            this.tableLayoutPanel6.TabIndex = 4;
            // 
            // listView_hechizos_pelea
            // 
            this.listView_hechizos_pelea.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.nombre,
            this.focus,
            this.n_lanzamientos,
            this.lanzamiento,
            this.metodo_distancia,
            this.operador_distancia,
            this.distancia});
            this.listView_hechizos_pelea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_hechizos_pelea.FullRowSelect = true;
            this.listView_hechizos_pelea.HideSelection = false;
            this.listView_hechizos_pelea.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView_hechizos_pelea.Location = new System.Drawing.Point(3, 3);
            this.listView_hechizos_pelea.Name = "listView_hechizos_pelea";
            this.listView_hechizos_pelea.Size = new System.Drawing.Size(712, 179);
            this.listView_hechizos_pelea.TabIndex = 0;
            this.listView_hechizos_pelea.UseCompatibleStateImageBehavior = false;
            this.listView_hechizos_pelea.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 29;
            // 
            // nombre
            // 
            this.nombre.Text = "Nombre";
            this.nombre.Width = 64;
            // 
            // focus
            // 
            this.focus.Text = "Focus";
            this.focus.Width = 54;
            // 
            // n_lanzamientos
            // 
            this.n_lanzamientos.Text = "Lanzamientos x turno";
            this.n_lanzamientos.Width = 136;
            // 
            // lanzamiento
            // 
            this.lanzamiento.Text = "Lanzamiento";
            this.lanzamiento.Width = 87;
            // 
            // metodo_distancia
            // 
            this.metodo_distancia.Text = "Método Distancia";
            this.metodo_distancia.Width = 117;
            // 
            // operador_distancia
            // 
            this.operador_distancia.Text = "Operador";
            this.operador_distancia.Width = 71;
            // 
            // distancia
            // 
            this.distancia.Text = "Distancia";
            this.distancia.Width = 70;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.button_subir_hechizo, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.button_informacion_hechizo, 0, 3);
            this.tableLayoutPanel8.Controls.Add(this.button_bajar_hechizo, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.button_eliminar_hechizo, 0, 2);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(721, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 4;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(52, 179);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // button_subir_hechizo
            // 
            this.button_subir_hechizo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_subir_hechizo.Image = global::Bot_Dofus_Retro.Properties.Resources.flecha_arriba;
            this.button_subir_hechizo.Location = new System.Drawing.Point(3, 3);
            this.button_subir_hechizo.Name = "button_subir_hechizo";
            this.button_subir_hechizo.Size = new System.Drawing.Size(46, 38);
            this.button_subir_hechizo.TabIndex = 0;
            this.button_subir_hechizo.UseVisualStyleBackColor = true;
            this.button_subir_hechizo.Click += new System.EventHandler(this.button_subir_hechizo_Click);
            // 
            // button_informacion_hechizo
            // 
            this.button_informacion_hechizo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_informacion_hechizo.Image = global::Bot_Dofus_Retro.Properties.Resources.icono_informacion;
            this.button_informacion_hechizo.Location = new System.Drawing.Point(3, 135);
            this.button_informacion_hechizo.Name = "button_informacion_hechizo";
            this.button_informacion_hechizo.Size = new System.Drawing.Size(46, 41);
            this.button_informacion_hechizo.TabIndex = 3;
            this.button_informacion_hechizo.UseVisualStyleBackColor = true;
            // 
            // button_bajar_hechizo
            // 
            this.button_bajar_hechizo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_bajar_hechizo.Image = global::Bot_Dofus_Retro.Properties.Resources.flecha_abajo;
            this.button_bajar_hechizo.Location = new System.Drawing.Point(3, 47);
            this.button_bajar_hechizo.Name = "button_bajar_hechizo";
            this.button_bajar_hechizo.Size = new System.Drawing.Size(46, 38);
            this.button_bajar_hechizo.TabIndex = 1;
            this.button_bajar_hechizo.UseVisualStyleBackColor = true;
            this.button_bajar_hechizo.Click += new System.EventHandler(this.button_bajar_hechizo_Click);
            // 
            // button_eliminar_hechizo
            // 
            this.button_eliminar_hechizo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_eliminar_hechizo.Image = global::Bot_Dofus_Retro.Properties.Resources.cruz_roja_pequeña;
            this.button_eliminar_hechizo.Location = new System.Drawing.Point(3, 91);
            this.button_eliminar_hechizo.Name = "button_eliminar_hechizo";
            this.button_eliminar_hechizo.Size = new System.Drawing.Size(46, 38);
            this.button_eliminar_hechizo.TabIndex = 2;
            this.button_eliminar_hechizo.UseVisualStyleBackColor = true;
            this.button_eliminar_hechizo.Click += new System.EventHandler(this.button_eliminar_hechizo_Click);
            // 
            // groupBox_agregar_hechizo
            // 
            this.groupBox_agregar_hechizo.Controls.Add(this.tableLayoutPanel_principal);
            this.groupBox_agregar_hechizo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox_agregar_hechizo.Location = new System.Drawing.Point(3, 189);
            this.groupBox_agregar_hechizo.Name = "groupBox_agregar_hechizo";
            this.groupBox_agregar_hechizo.Size = new System.Drawing.Size(776, 152);
            this.groupBox_agregar_hechizo.TabIndex = 1;
            this.groupBox_agregar_hechizo.TabStop = false;
            this.groupBox_agregar_hechizo.Text = "Agregar hechizo";
            // 
            // tableLayoutPanel_principal
            // 
            this.tableLayoutPanel_principal.ColumnCount = 2;
            this.tableLayoutPanel_principal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.25727F));
            this.tableLayoutPanel_principal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.74273F));
            this.tableLayoutPanel_principal.Controls.Add(this.comboBox_modo_lanzamiento, 1, 3);
            this.tableLayoutPanel_principal.Controls.Add(this.label_agregar_metodo, 0, 3);
            this.tableLayoutPanel_principal.Controls.Add(this.label_agregar_focus, 0, 1);
            this.tableLayoutPanel_principal.Controls.Add(this.label_agregar_nombre, 0, 0);
            this.tableLayoutPanel_principal.Controls.Add(this.comboBox_lista_hechizos, 1, 0);
            this.tableLayoutPanel_principal.Controls.Add(this.comboBox_focus_hechizo, 1, 1);
            this.tableLayoutPanel_principal.Controls.Add(this.label_agregar_lanzamientos, 0, 2);
            this.tableLayoutPanel_principal.Controls.Add(this.numeric_lanzamientos_turno, 1, 2);
            this.tableLayoutPanel_principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_principal.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanel_principal.Name = "tableLayoutPanel_principal";
            this.tableLayoutPanel_principal.RowCount = 4;
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_principal.Size = new System.Drawing.Size(770, 128);
            this.tableLayoutPanel_principal.TabIndex = 2;
            // 
            // comboBox_modo_lanzamiento
            // 
            this.comboBox_modo_lanzamiento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_modo_lanzamiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_modo_lanzamiento.FormattingEnabled = true;
            this.comboBox_modo_lanzamiento.Items.AddRange(new object[] {
            "CAC",
            "ALEJADO",
            "AMBOS"});
            this.comboBox_modo_lanzamiento.Location = new System.Drawing.Point(343, 99);
            this.comboBox_modo_lanzamiento.Name = "comboBox_modo_lanzamiento";
            this.comboBox_modo_lanzamiento.Size = new System.Drawing.Size(424, 25);
            this.comboBox_modo_lanzamiento.TabIndex = 8;
            // 
            // label_agregar_metodo
            // 
            this.label_agregar_metodo.AutoSize = true;
            this.label_agregar_metodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_agregar_metodo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label_agregar_metodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_agregar_metodo.Location = new System.Drawing.Point(3, 96);
            this.label_agregar_metodo.Name = "label_agregar_metodo";
            this.label_agregar_metodo.Size = new System.Drawing.Size(334, 32);
            this.label_agregar_metodo.TabIndex = 7;
            this.label_agregar_metodo.Text = "Método de lanzamiento";
            this.label_agregar_metodo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_agregar_focus
            // 
            this.label_agregar_focus.AutoSize = true;
            this.label_agregar_focus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_agregar_focus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label_agregar_focus.Location = new System.Drawing.Point(3, 32);
            this.label_agregar_focus.Name = "label_agregar_focus";
            this.label_agregar_focus.Size = new System.Drawing.Size(334, 32);
            this.label_agregar_focus.TabIndex = 3;
            this.label_agregar_focus.Text = "Focus:";
            this.label_agregar_focus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_agregar_nombre
            // 
            this.label_agregar_nombre.AutoSize = true;
            this.label_agregar_nombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_agregar_nombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label_agregar_nombre.Location = new System.Drawing.Point(3, 0);
            this.label_agregar_nombre.Name = "label_agregar_nombre";
            this.label_agregar_nombre.Size = new System.Drawing.Size(334, 32);
            this.label_agregar_nombre.TabIndex = 0;
            this.label_agregar_nombre.Text = "Hechizo:";
            this.label_agregar_nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_lista_hechizos
            // 
            this.comboBox_lista_hechizos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_lista_hechizos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_lista_hechizos.FormattingEnabled = true;
            this.comboBox_lista_hechizos.Location = new System.Drawing.Point(343, 3);
            this.comboBox_lista_hechizos.Name = "comboBox_lista_hechizos";
            this.comboBox_lista_hechizos.Size = new System.Drawing.Size(424, 25);
            this.comboBox_lista_hechizos.TabIndex = 1;
            // 
            // comboBox_focus_hechizo
            // 
            this.comboBox_focus_hechizo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_focus_hechizo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_focus_hechizo.FormattingEnabled = true;
            this.comboBox_focus_hechizo.Items.AddRange(new object[] {
            "Enemigo",
            "Aliado",
            "Encima",
            "Celda vacía"});
            this.comboBox_focus_hechizo.Location = new System.Drawing.Point(343, 35);
            this.comboBox_focus_hechizo.Name = "comboBox_focus_hechizo";
            this.comboBox_focus_hechizo.Size = new System.Drawing.Size(424, 25);
            this.comboBox_focus_hechizo.TabIndex = 4;
            // 
            // label_agregar_lanzamientos
            // 
            this.label_agregar_lanzamientos.AutoSize = true;
            this.label_agregar_lanzamientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_agregar_lanzamientos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label_agregar_lanzamientos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_agregar_lanzamientos.Location = new System.Drawing.Point(3, 64);
            this.label_agregar_lanzamientos.Name = "label_agregar_lanzamientos";
            this.label_agregar_lanzamientos.Size = new System.Drawing.Size(334, 32);
            this.label_agregar_lanzamientos.TabIndex = 5;
            this.label_agregar_lanzamientos.Text = "Número de lanzamientos por turno:";
            this.label_agregar_lanzamientos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numeric_lanzamientos_turno
            // 
            this.numeric_lanzamientos_turno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numeric_lanzamientos_turno.Location = new System.Drawing.Point(343, 67);
            this.numeric_lanzamientos_turno.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numeric_lanzamientos_turno.Name = "numeric_lanzamientos_turno";
            this.numeric_lanzamientos_turno.Size = new System.Drawing.Size(424, 25);
            this.numeric_lanzamientos_turno.TabIndex = 6;
            this.numeric_lanzamientos_turno.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_piedra_equipada);
            this.groupBox1.Controls.Add(this.checkBox_AOE);
            this.groupBox1.Controls.Add(this.tableLayoutPanel_segundario);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 341);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 90);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // checkBox_AOE
            // 
            this.checkBox_AOE.AutoSize = true;
            this.checkBox_AOE.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBox_AOE.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.checkBox_AOE.Location = new System.Drawing.Point(3, 52);
            this.checkBox_AOE.Name = "checkBox_AOE";
            this.checkBox_AOE.Size = new System.Drawing.Size(61, 35);
            this.checkBox_AOE.TabIndex = 1;
            this.checkBox_AOE.Text = "AOE";
            this.checkBox_AOE.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel_segundario
            // 
            this.tableLayoutPanel_segundario.ColumnCount = 4;
            this.tableLayoutPanel_segundario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.19846F));
            this.tableLayoutPanel_segundario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.80154F));
            this.tableLayoutPanel_segundario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel_segundario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel_segundario.Controls.Add(this.label_agregar_distancia, 0, 0);
            this.tableLayoutPanel_segundario.Controls.Add(this.comboBox_distancia_enemigo, 1, 0);
            this.tableLayoutPanel_segundario.Controls.Add(this.numeric_distancia, 3, 0);
            this.tableLayoutPanel_segundario.Controls.Add(this.comboBox_distancia_operador, 2, 0);
            this.tableLayoutPanel_segundario.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel_segundario.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanel_segundario.Name = "tableLayoutPanel_segundario";
            this.tableLayoutPanel_segundario.RowCount = 1;
            this.tableLayoutPanel_segundario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.9697F));
            this.tableLayoutPanel_segundario.Size = new System.Drawing.Size(770, 31);
            this.tableLayoutPanel_segundario.TabIndex = 0;
            // 
            // label_agregar_distancia
            // 
            this.label_agregar_distancia.AutoSize = true;
            this.label_agregar_distancia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_agregar_distancia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label_agregar_distancia.Location = new System.Drawing.Point(3, 0);
            this.label_agregar_distancia.Name = "label_agregar_distancia";
            this.label_agregar_distancia.Size = new System.Drawing.Size(318, 31);
            this.label_agregar_distancia.TabIndex = 1;
            this.label_agregar_distancia.Text = "Verificar distancia entre bot y enemigo";
            this.label_agregar_distancia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_distancia_enemigo
            // 
            this.comboBox_distancia_enemigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_distancia_enemigo.FormattingEnabled = true;
            this.comboBox_distancia_enemigo.Items.AddRange(new object[] {
            "Ninguno",
            "Cercano",
            "Lejano"});
            this.comboBox_distancia_enemigo.Location = new System.Drawing.Point(327, 3);
            this.comboBox_distancia_enemigo.Name = "comboBox_distancia_enemigo";
            this.comboBox_distancia_enemigo.Size = new System.Drawing.Size(183, 25);
            this.comboBox_distancia_enemigo.TabIndex = 8;
            // 
            // numeric_distancia
            // 
            this.numeric_distancia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numeric_distancia.Location = new System.Drawing.Point(620, 3);
            this.numeric_distancia.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numeric_distancia.Name = "numeric_distancia";
            this.numeric_distancia.Size = new System.Drawing.Size(147, 25);
            this.numeric_distancia.TabIndex = 7;
            // 
            // comboBox_distancia_operador
            // 
            this.comboBox_distancia_operador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_distancia_operador.FormattingEnabled = true;
            this.comboBox_distancia_operador.Items.AddRange(new object[] {
            "<=",
            "=>"});
            this.comboBox_distancia_operador.Location = new System.Drawing.Point(516, 3);
            this.comboBox_distancia_operador.Name = "comboBox_distancia_operador";
            this.comboBox_distancia_operador.Size = new System.Drawing.Size(98, 25);
            this.comboBox_distancia_operador.TabIndex = 9;
            // 
            // button_agregar_hechizo
            // 
            this.button_agregar_hechizo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_agregar_hechizo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_agregar_hechizo.Location = new System.Drawing.Point(3, 431);
            this.button_agregar_hechizo.Name = "button_agregar_hechizo";
            this.button_agregar_hechizo.Size = new System.Drawing.Size(776, 31);
            this.button_agregar_hechizo.TabIndex = 1;
            this.button_agregar_hechizo.Text = "Agregar hechizo";
            this.button_agregar_hechizo.UseVisualStyleBackColor = true;
            this.button_agregar_hechizo.Click += new System.EventHandler(this.button_agregar_hechizo_Click);
            // 
            // lista_imagenes
            // 
            this.lista_imagenes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("lista_imagenes.ImageStream")));
            this.lista_imagenes.TransparentColor = System.Drawing.Color.Transparent;
            this.lista_imagenes.Images.SetKeyName(0, "1 - Home24.png");
            this.lista_imagenes.Images.SetKeyName(1, "magic32.png");
            // 
            // checkBox_piedra_equipada
            // 
            this.checkBox_piedra_equipada.AutoSize = true;
            this.checkBox_piedra_equipada.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBox_piedra_equipada.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.checkBox_piedra_equipada.Location = new System.Drawing.Point(64, 52);
            this.checkBox_piedra_equipada.Name = "checkBox_piedra_equipada";
            this.checkBox_piedra_equipada.Size = new System.Drawing.Size(233, 35);
            this.checkBox_piedra_equipada.TabIndex = 2;
            this.checkBox_piedra_equipada.Text = "Necesita piedra de captura";
            this.checkBox_piedra_equipada.UseVisualStyleBackColor = true;
            // 
            // UI_Pelea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UI_Pelea";
            this.Size = new System.Drawing.Size(790, 500);
            this.Load += new System.EventHandler(this.UI_Pelea_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_general_pelea.ResumeLayout(false);
            this.tabPage_general_pelea.PerformLayout();
            this.groupBox_durante_combate.ResumeLayout(false);
            this.groupBox_durante_combate.PerformLayout();
            this.groupBox_preparacion.ResumeLayout(false);
            this.groupBox_preparacion.PerformLayout();
            this.tabPage_hechizos_pelea.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.groupBox_agregar_hechizo.ResumeLayout(false);
            this.tableLayoutPanel_principal.ResumeLayout(false);
            this.tableLayoutPanel_principal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_lanzamientos_turno)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel_segundario.ResumeLayout(false);
            this.tableLayoutPanel_segundario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_distancia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_general_pelea;
        private System.Windows.Forms.TabPage tabPage_hechizos_pelea;
        private System.Windows.Forms.ImageList lista_imagenes;
        private System.Windows.Forms.GroupBox groupBox_preparacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_lista_posicionamiento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_lista_tactica;
        private System.Windows.Forms.ListView listView_hechizos_pelea;
        private System.Windows.Forms.GroupBox groupBox_agregar_hechizo;
        private System.Windows.Forms.Button button_agregar_hechizo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_principal;
        private System.Windows.Forms.Label label_agregar_nombre;
        private System.Windows.Forms.ComboBox comboBox_lista_hechizos;
        private System.Windows.Forms.Label label_agregar_focus;
        private System.Windows.Forms.ComboBox comboBox_focus_hechizo;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader nombre;
        private System.Windows.Forms.ColumnHeader focus;
        private System.Windows.Forms.Label label_agregar_lanzamientos;
        private System.Windows.Forms.NumericUpDown numeric_lanzamientos_turno;
        private System.Windows.Forms.ColumnHeader n_lanzamientos;
        private System.Windows.Forms.Button button_comenzar_pelea;
        private System.Windows.Forms.CheckBox checkbox_espectadores;
        private System.Windows.Forms.CheckBox checkBox_utilizar_dragopavo;
        private System.Windows.Forms.ColumnHeader lanzamiento;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button button_subir_hechizo;
        private System.Windows.Forms.Button button_bajar_hechizo;
        private System.Windows.Forms.Button button_eliminar_hechizo;
        private System.Windows.Forms.Button button_informacion_hechizo;
        private System.Windows.Forms.ComboBox comboBox_modo_lanzamiento;
        private System.Windows.Forms.Label label_agregar_metodo;
        private System.Windows.Forms.GroupBox groupBox_durante_combate;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_segundario;
        private System.Windows.Forms.Label label_agregar_distancia;
        private System.Windows.Forms.NumericUpDown numeric_distancia;
        private System.Windows.Forms.ColumnHeader distancia;
        private System.Windows.Forms.CheckBox checkBox_ignorar_invocaciones;
        private System.Windows.Forms.ComboBox comboBox_distancia_enemigo;
        private System.Windows.Forms.ComboBox comboBox_distancia_operador;
        private System.Windows.Forms.ColumnHeader metodo_distancia;
        private System.Windows.Forms.ColumnHeader operador_distancia;
        private System.Windows.Forms.CheckBox checkBox_AOE;
        private System.Windows.Forms.CheckBox checkBox_piedra_equipada;
    }
}
