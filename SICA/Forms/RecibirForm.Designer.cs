namespace SICA
{
    partial class RecibirForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpNuevo = new System.Windows.Forms.TabPage();
            this.btCargarValido = new System.Windows.Forms.Button();
            this.btBuscarCargo = new System.Windows.Forms.Button();
            this.dgvCargo = new System.Windows.Forms.DataGridView();
            this.tpReingreso = new System.Windows.Forms.TabPage();
            this.btRecibir = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.dgvReingreso = new System.Windows.Forms.DataGridView();
            this.btBuscarReingreso = new FontAwesome.Sharp.IconButton();
            this.tbBusquedaLibre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tpPagare = new System.Windows.Forms.TabPage();
            this.btRecibirPagare = new FontAwesome.Sharp.IconButton();
            this.dgvPagare = new System.Windows.Forms.DataGridView();
            this.btBuscarPagare = new FontAwesome.Sharp.IconButton();
            this.tbSolicitud = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLetra = new System.Windows.Forms.TabPage();
            this.btCargarLetrasValidas = new System.Windows.Forms.Button();
            this.btCargarLetras = new System.Windows.Forms.Button();
            this.dgvLetras = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tpNuevo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargo)).BeginInit();
            this.tpReingreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReingreso)).BeginInit();
            this.tpPagare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagare)).BeginInit();
            this.tbLetra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLetras)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpNuevo);
            this.tabControl1.Controls.Add(this.tpReingreso);
            this.tabControl1.Controls.Add(this.tpPagare);
            this.tabControl1.Controls.Add(this.tbLetra);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 14.25F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1073, 583);
            this.tabControl1.TabIndex = 0;
            // 
            // tpNuevo
            // 
            this.tpNuevo.BackColor = System.Drawing.Color.MidnightBlue;
            this.tpNuevo.Controls.Add(this.btCargarValido);
            this.tpNuevo.Controls.Add(this.btBuscarCargo);
            this.tpNuevo.Controls.Add(this.dgvCargo);
            this.tpNuevo.Location = new System.Drawing.Point(4, 31);
            this.tpNuevo.Name = "tpNuevo";
            this.tpNuevo.Padding = new System.Windows.Forms.Padding(3);
            this.tpNuevo.Size = new System.Drawing.Size(1065, 548);
            this.tpNuevo.TabIndex = 0;
            this.tpNuevo.Text = "Nuevo";
            // 
            // btCargarValido
            // 
            this.btCargarValido.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCargarValido.Location = new System.Drawing.Point(244, 9);
            this.btCargarValido.Name = "btCargarValido";
            this.btCargarValido.Size = new System.Drawing.Size(212, 33);
            this.btCargarValido.TabIndex = 13;
            this.btCargarValido.Text = "Cargar Información Valida";
            this.btCargarValido.UseVisualStyleBackColor = true;
            this.btCargarValido.Visible = false;
            this.btCargarValido.Click += new System.EventHandler(this.btCargarValido_Click);
            // 
            // btBuscarCargo
            // 
            this.btBuscarCargo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarCargo.Location = new System.Drawing.Point(8, 9);
            this.btBuscarCargo.Name = "btBuscarCargo";
            this.btBuscarCargo.Size = new System.Drawing.Size(230, 33);
            this.btBuscarCargo.TabIndex = 12;
            this.btBuscarCargo.Text = "Buscar Cargo .xlsx";
            this.btBuscarCargo.UseVisualStyleBackColor = true;
            this.btBuscarCargo.Click += new System.EventHandler(this.btBuscarCargo_Click);
            // 
            // dgvCargo
            // 
            this.dgvCargo.AllowUserToAddRows = false;
            this.dgvCargo.AllowUserToDeleteRows = false;
            this.dgvCargo.AllowUserToResizeRows = false;
            this.dgvCargo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCargo.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvCargo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCargo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 14.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCargo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCargo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCargo.EnableHeadersVisualStyles = false;
            this.dgvCargo.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvCargo.Location = new System.Drawing.Point(8, 48);
            this.dgvCargo.Name = "dgvCargo";
            this.dgvCargo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCargo.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCargo.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCargo.Size = new System.Drawing.Size(1054, 492);
            this.dgvCargo.TabIndex = 11;
            // 
            // tpReingreso
            // 
            this.tpReingreso.BackColor = System.Drawing.Color.MidnightBlue;
            this.tpReingreso.Controls.Add(this.btRecibir);
            this.tpReingreso.Controls.Add(this.label1);
            this.tpReingreso.Controls.Add(this.tbUsuario);
            this.tpReingreso.Controls.Add(this.dgvReingreso);
            this.tpReingreso.Controls.Add(this.btBuscarReingreso);
            this.tpReingreso.Controls.Add(this.tbBusquedaLibre);
            this.tpReingreso.Controls.Add(this.label2);
            this.tpReingreso.Location = new System.Drawing.Point(4, 31);
            this.tpReingreso.Name = "tpReingreso";
            this.tpReingreso.Padding = new System.Windows.Forms.Padding(3);
            this.tpReingreso.Size = new System.Drawing.Size(1065, 548);
            this.tpReingreso.TabIndex = 1;
            this.tpReingreso.Text = "Reingreso";
            // 
            // btRecibir
            // 
            this.btRecibir.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btRecibir.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRecibir.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btRecibir.IconColor = System.Drawing.Color.Black;
            this.btRecibir.IconSize = 16;
            this.btRecibir.Location = new System.Drawing.Point(945, 13);
            this.btRecibir.Name = "btRecibir";
            this.btRecibir.Rotation = 0D;
            this.btRecibir.Size = new System.Drawing.Size(88, 23);
            this.btRecibir.TabIndex = 20;
            this.btRecibir.Text = "Recibir";
            this.btRecibir.UseVisualStyleBackColor = true;
            this.btRecibir.Click += new System.EventHandler(this.btRecibir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(40, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "Usuario:";
            // 
            // tbUsuario
            // 
            this.tbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsuario.Location = new System.Drawing.Point(125, 10);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(177, 24);
            this.tbUsuario.TabIndex = 18;
            // 
            // dgvReingreso
            // 
            this.dgvReingreso.AllowUserToAddRows = false;
            this.dgvReingreso.AllowUserToDeleteRows = false;
            this.dgvReingreso.AllowUserToResizeRows = false;
            this.dgvReingreso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReingreso.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvReingreso.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReingreso.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReingreso.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReingreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 14.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReingreso.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvReingreso.EnableHeadersVisualStyles = false;
            this.dgvReingreso.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvReingreso.Location = new System.Drawing.Point(17, 47);
            this.dgvReingreso.Name = "dgvReingreso";
            this.dgvReingreso.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvReingreso.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvReingreso.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvReingreso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReingreso.Size = new System.Drawing.Size(1040, 498);
            this.dgvReingreso.TabIndex = 14;
            // 
            // btBuscarReingreso
            // 
            this.btBuscarReingreso.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btBuscarReingreso.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarReingreso.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btBuscarReingreso.IconColor = System.Drawing.Color.Black;
            this.btBuscarReingreso.IconSize = 16;
            this.btBuscarReingreso.Location = new System.Drawing.Point(818, 13);
            this.btBuscarReingreso.Name = "btBuscarReingreso";
            this.btBuscarReingreso.Rotation = 0D;
            this.btBuscarReingreso.Size = new System.Drawing.Size(88, 23);
            this.btBuscarReingreso.TabIndex = 13;
            this.btBuscarReingreso.Text = "Buscar";
            this.btBuscarReingreso.UseVisualStyleBackColor = true;
            this.btBuscarReingreso.Click += new System.EventHandler(this.btBuscarReingreso_Click);
            // 
            // tbBusquedaLibre
            // 
            this.tbBusquedaLibre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBusquedaLibre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusquedaLibre.Location = new System.Drawing.Point(480, 11);
            this.tbBusquedaLibre.Name = "tbBusquedaLibre";
            this.tbBusquedaLibre.Size = new System.Drawing.Size(321, 26);
            this.tbBusquedaLibre.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(325, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 22);
            this.label2.TabIndex = 11;
            this.label2.Text = "Busqueda Libre:";
            // 
            // tpPagare
            // 
            this.tpPagare.BackColor = System.Drawing.Color.MidnightBlue;
            this.tpPagare.Controls.Add(this.btRecibirPagare);
            this.tpPagare.Controls.Add(this.dgvPagare);
            this.tpPagare.Controls.Add(this.btBuscarPagare);
            this.tpPagare.Controls.Add(this.tbSolicitud);
            this.tpPagare.Controls.Add(this.label4);
            this.tpPagare.Location = new System.Drawing.Point(4, 31);
            this.tpPagare.Name = "tpPagare";
            this.tpPagare.Padding = new System.Windows.Forms.Padding(3);
            this.tpPagare.Size = new System.Drawing.Size(1065, 548);
            this.tpPagare.TabIndex = 2;
            this.tpPagare.Text = "Pagare";
            // 
            // btRecibirPagare
            // 
            this.btRecibirPagare.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btRecibirPagare.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRecibirPagare.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btRecibirPagare.IconColor = System.Drawing.Color.Black;
            this.btRecibirPagare.IconSize = 16;
            this.btRecibirPagare.Location = new System.Drawing.Point(589, 12);
            this.btRecibirPagare.Name = "btRecibirPagare";
            this.btRecibirPagare.Rotation = 0D;
            this.btRecibirPagare.Size = new System.Drawing.Size(88, 23);
            this.btRecibirPagare.TabIndex = 27;
            this.btRecibirPagare.Text = "Recibir";
            this.btRecibirPagare.UseVisualStyleBackColor = true;
            this.btRecibirPagare.Click += new System.EventHandler(this.btRecibirPagare_Click);
            // 
            // dgvPagare
            // 
            this.dgvPagare.AllowUserToAddRows = false;
            this.dgvPagare.AllowUserToDeleteRows = false;
            this.dgvPagare.AllowUserToResizeRows = false;
            this.dgvPagare.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPagare.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvPagare.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPagare.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 14.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPagare.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPagare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 14.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPagare.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPagare.EnableHeadersVisualStyles = false;
            this.dgvPagare.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvPagare.Location = new System.Drawing.Point(12, 41);
            this.dgvPagare.Name = "dgvPagare";
            this.dgvPagare.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPagare.RowHeadersVisible = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPagare.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvPagare.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagare.Size = new System.Drawing.Size(1040, 498);
            this.dgvPagare.TabIndex = 24;
            // 
            // btBuscarPagare
            // 
            this.btBuscarPagare.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btBuscarPagare.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarPagare.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btBuscarPagare.IconColor = System.Drawing.Color.Black;
            this.btBuscarPagare.IconSize = 16;
            this.btBuscarPagare.Location = new System.Drawing.Point(462, 12);
            this.btBuscarPagare.Name = "btBuscarPagare";
            this.btBuscarPagare.Rotation = 0D;
            this.btBuscarPagare.Size = new System.Drawing.Size(88, 23);
            this.btBuscarPagare.TabIndex = 23;
            this.btBuscarPagare.Text = "Buscar";
            this.btBuscarPagare.UseVisualStyleBackColor = true;
            this.btBuscarPagare.Click += new System.EventHandler(this.btBuscarPagare_Click);
            // 
            // tbSolicitud
            // 
            this.tbSolicitud.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbSolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSolicitud.Location = new System.Drawing.Point(124, 10);
            this.tbSolicitud.Name = "tbSolicitud";
            this.tbSolicitud.Size = new System.Drawing.Size(321, 26);
            this.tbSolicitud.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(31, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 22);
            this.label4.TabIndex = 21;
            this.label4.Text = "Solicitud:";
            // 
            // tbLetra
            // 
            this.tbLetra.BackColor = System.Drawing.Color.MidnightBlue;
            this.tbLetra.Controls.Add(this.btCargarLetrasValidas);
            this.tbLetra.Controls.Add(this.btCargarLetras);
            this.tbLetra.Controls.Add(this.dgvLetras);
            this.tbLetra.Location = new System.Drawing.Point(4, 31);
            this.tbLetra.Name = "tbLetra";
            this.tbLetra.Padding = new System.Windows.Forms.Padding(3);
            this.tbLetra.Size = new System.Drawing.Size(1065, 548);
            this.tbLetra.TabIndex = 3;
            this.tbLetra.Text = "Letra";
            // 
            // btCargarLetrasValidas
            // 
            this.btCargarLetrasValidas.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCargarLetrasValidas.Location = new System.Drawing.Point(241, 9);
            this.btCargarLetrasValidas.Name = "btCargarLetrasValidas";
            this.btCargarLetrasValidas.Size = new System.Drawing.Size(212, 33);
            this.btCargarLetrasValidas.TabIndex = 16;
            this.btCargarLetrasValidas.Text = "Cargar Información Valida";
            this.btCargarLetrasValidas.UseVisualStyleBackColor = true;
            this.btCargarLetrasValidas.Visible = false;
            // 
            // btCargarLetras
            // 
            this.btCargarLetras.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCargarLetras.Location = new System.Drawing.Point(5, 9);
            this.btCargarLetras.Name = "btCargarLetras";
            this.btCargarLetras.Size = new System.Drawing.Size(230, 33);
            this.btCargarLetras.TabIndex = 15;
            this.btCargarLetras.Text = "Buscar Cargo Letras .xlsx";
            this.btCargarLetras.UseVisualStyleBackColor = true;
            this.btCargarLetras.Click += new System.EventHandler(this.btCargarLetras_Click);
            // 
            // dgvLetras
            // 
            this.dgvLetras.AllowUserToAddRows = false;
            this.dgvLetras.AllowUserToDeleteRows = false;
            this.dgvLetras.AllowUserToResizeRows = false;
            this.dgvLetras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLetras.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvLetras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLetras.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 14.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLetras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvLetras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial", 14.25F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLetras.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvLetras.EnableHeadersVisualStyles = false;
            this.dgvLetras.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvLetras.Location = new System.Drawing.Point(5, 48);
            this.dgvLetras.Name = "dgvLetras";
            this.dgvLetras.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvLetras.RowHeadersVisible = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvLetras.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvLetras.Size = new System.Drawing.Size(1054, 492);
            this.dgvLetras.TabIndex = 14;
            // 
            // RecibirForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1073, 583);
            this.Controls.Add(this.tabControl1);
            this.Name = "RecibirForm";
            this.Text = "CustodiarForm";
            this.tabControl1.ResumeLayout(false);
            this.tpNuevo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargo)).EndInit();
            this.tpReingreso.ResumeLayout(false);
            this.tpReingreso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReingreso)).EndInit();
            this.tpPagare.ResumeLayout(false);
            this.tpPagare.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagare)).EndInit();
            this.tbLetra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLetras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpNuevo;
        private System.Windows.Forms.Button btCargarValido;
        private System.Windows.Forms.Button btBuscarCargo;
        private System.Windows.Forms.DataGridView dgvCargo;
        private System.Windows.Forms.TabPage tpReingreso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.DataGridView dgvReingreso;
        private FontAwesome.Sharp.IconButton btBuscarReingreso;
        private System.Windows.Forms.TextBox tbBusquedaLibre;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btRecibir;
        private System.Windows.Forms.TabPage tpPagare;
        private FontAwesome.Sharp.IconButton btRecibirPagare;
        private System.Windows.Forms.DataGridView dgvPagare;
        private FontAwesome.Sharp.IconButton btBuscarPagare;
        private System.Windows.Forms.TextBox tbSolicitud;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tbLetra;
        private System.Windows.Forms.Button btCargarLetrasValidas;
        private System.Windows.Forms.Button btCargarLetras;
        private System.Windows.Forms.DataGridView dgvLetras;
    }
}