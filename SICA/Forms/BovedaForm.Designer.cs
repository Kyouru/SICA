namespace SICA.Forms
{
    partial class BovedaForm
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
            this.tpGuardar = new System.Windows.Forms.TabPage();
            this.cbCajaGuardar = new System.Windows.Forms.CheckBox();
            this.lbCantidadGuardar = new System.Windows.Forms.Label();
            this.btVerCarritoGuardar = new FontAwesome.Sharp.IconButton();
            this.tbBusquedaLibreGuardar = new System.Windows.Forms.TextBox();
            this.btBuscarGuardar = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btBovedaGuardar = new FontAwesome.Sharp.IconButton();
            this.dgvBovedaGuardar = new System.Windows.Forms.DataGridView();
            this.tpRetirarBoveda = new System.Windows.Forms.TabPage();
            this.cbCajaRetiro = new System.Windows.Forms.CheckBox();
            this.lbCantidadRetiro = new System.Windows.Forms.Label();
            this.btVerCarritoRetirar = new FontAwesome.Sharp.IconButton();
            this.btBovedaRetirar = new FontAwesome.Sharp.IconButton();
            this.tbBusquedaLibreRetirar = new System.Windows.Forms.TextBox();
            this.dgvBovedaRetirar = new System.Windows.Forms.DataGridView();
            this.btBuscarRetirar = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpGuardar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBovedaGuardar)).BeginInit();
            this.tpRetirarBoveda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBovedaRetirar)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpGuardar
            // 
            this.tpGuardar.BackColor = System.Drawing.Color.MidnightBlue;
            this.tpGuardar.Controls.Add(this.cbCajaGuardar);
            this.tpGuardar.Controls.Add(this.lbCantidadGuardar);
            this.tpGuardar.Controls.Add(this.btVerCarritoGuardar);
            this.tpGuardar.Controls.Add(this.tbBusquedaLibreGuardar);
            this.tpGuardar.Controls.Add(this.btBuscarGuardar);
            this.tpGuardar.Controls.Add(this.label1);
            this.tpGuardar.Controls.Add(this.btBovedaGuardar);
            this.tpGuardar.Controls.Add(this.dgvBovedaGuardar);
            this.tpGuardar.Location = new System.Drawing.Point(4, 31);
            this.tpGuardar.Name = "tpGuardar";
            this.tpGuardar.Padding = new System.Windows.Forms.Padding(3);
            this.tpGuardar.Size = new System.Drawing.Size(1150, 562);
            this.tpGuardar.TabIndex = 2;
            this.tpGuardar.Text = "Guardar";
            // 
            // cbCajaGuardar
            // 
            this.cbCajaGuardar.AutoSize = true;
            this.cbCajaGuardar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbCajaGuardar.Location = new System.Drawing.Point(732, 12);
            this.cbCajaGuardar.Name = "cbCajaGuardar";
            this.cbCajaGuardar.Size = new System.Drawing.Size(67, 26);
            this.cbCajaGuardar.TabIndex = 33;
            this.cbCajaGuardar.Text = "Caja";
            this.cbCajaGuardar.UseVisualStyleBackColor = true;
            // 
            // lbCantidadGuardar
            // 
            this.lbCantidadGuardar.AutoSize = true;
            this.lbCantidadGuardar.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantidadGuardar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbCantidadGuardar.Location = new System.Drawing.Point(977, 10);
            this.lbCantidadGuardar.Name = "lbCantidadGuardar";
            this.lbCantidadGuardar.Size = new System.Drawing.Size(33, 22);
            this.lbCantidadGuardar.TabIndex = 32;
            this.lbCantidadGuardar.Text = "(0)";
            // 
            // btVerCarritoGuardar
            // 
            this.btVerCarritoGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btVerCarritoGuardar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btVerCarritoGuardar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVerCarritoGuardar.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.btVerCarritoGuardar.IconColor = System.Drawing.Color.Black;
            this.btVerCarritoGuardar.IconSize = 30;
            this.btVerCarritoGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVerCarritoGuardar.Location = new System.Drawing.Point(922, 6);
            this.btVerCarritoGuardar.Name = "btVerCarritoGuardar";
            this.btVerCarritoGuardar.Rotation = 0D;
            this.btVerCarritoGuardar.Size = new System.Drawing.Size(51, 30);
            this.btVerCarritoGuardar.TabIndex = 31;
            this.btVerCarritoGuardar.UseVisualStyleBackColor = true;
            // 
            // tbBusquedaLibreGuardar
            // 
            this.tbBusquedaLibreGuardar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBusquedaLibreGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusquedaLibreGuardar.Location = new System.Drawing.Point(181, 11);
            this.tbBusquedaLibreGuardar.Name = "tbBusquedaLibreGuardar";
            this.tbBusquedaLibreGuardar.Size = new System.Drawing.Size(413, 26);
            this.tbBusquedaLibreGuardar.TabIndex = 29;
            // 
            // btBuscarGuardar
            // 
            this.btBuscarGuardar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btBuscarGuardar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarGuardar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btBuscarGuardar.IconColor = System.Drawing.Color.Black;
            this.btBuscarGuardar.IconSize = 16;
            this.btBuscarGuardar.Location = new System.Drawing.Point(612, 12);
            this.btBuscarGuardar.Name = "btBuscarGuardar";
            this.btBuscarGuardar.Rotation = 0D;
            this.btBuscarGuardar.Size = new System.Drawing.Size(88, 23);
            this.btBuscarGuardar.TabIndex = 30;
            this.btBuscarGuardar.Text = "Guardar";
            this.btBuscarGuardar.UseVisualStyleBackColor = true;
            this.btBuscarGuardar.Click += new System.EventHandler(this.btBuscarGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(26, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 22);
            this.label1.TabIndex = 28;
            this.label1.Text = "Busqueda Libre:";
            // 
            // btBovedaGuardar
            // 
            this.btBovedaGuardar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btBovedaGuardar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBovedaGuardar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btBovedaGuardar.IconColor = System.Drawing.Color.Black;
            this.btBovedaGuardar.IconSize = 16;
            this.btBovedaGuardar.Location = new System.Drawing.Point(1016, 12);
            this.btBovedaGuardar.Name = "btBovedaGuardar";
            this.btBovedaGuardar.Rotation = 0D;
            this.btBovedaGuardar.Size = new System.Drawing.Size(88, 23);
            this.btBovedaGuardar.TabIndex = 27;
            this.btBovedaGuardar.Text = "Recibir";
            this.btBovedaGuardar.UseVisualStyleBackColor = true;
            this.btBovedaGuardar.Click += new System.EventHandler(this.btBovedaGuardar_Click);
            // 
            // dgvBovedaGuardar
            // 
            this.dgvBovedaGuardar.AllowUserToAddRows = false;
            this.dgvBovedaGuardar.AllowUserToDeleteRows = false;
            this.dgvBovedaGuardar.AllowUserToResizeRows = false;
            this.dgvBovedaGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBovedaGuardar.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvBovedaGuardar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBovedaGuardar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 14.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBovedaGuardar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBovedaGuardar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBovedaGuardar.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBovedaGuardar.EnableHeadersVisualStyles = false;
            this.dgvBovedaGuardar.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvBovedaGuardar.Location = new System.Drawing.Point(12, 41);
            this.dgvBovedaGuardar.Name = "dgvBovedaGuardar";
            this.dgvBovedaGuardar.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBovedaGuardar.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvBovedaGuardar.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBovedaGuardar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBovedaGuardar.Size = new System.Drawing.Size(1125, 512);
            this.dgvBovedaGuardar.TabIndex = 24;
            this.dgvBovedaGuardar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBovedaGuardar_CellDoubleClick);
            // 
            // tpRetirarBoveda
            // 
            this.tpRetirarBoveda.BackColor = System.Drawing.Color.MidnightBlue;
            this.tpRetirarBoveda.Controls.Add(this.cbCajaRetiro);
            this.tpRetirarBoveda.Controls.Add(this.lbCantidadRetiro);
            this.tpRetirarBoveda.Controls.Add(this.btVerCarritoRetirar);
            this.tpRetirarBoveda.Controls.Add(this.btBovedaRetirar);
            this.tpRetirarBoveda.Controls.Add(this.tbBusquedaLibreRetirar);
            this.tpRetirarBoveda.Controls.Add(this.dgvBovedaRetirar);
            this.tpRetirarBoveda.Controls.Add(this.btBuscarRetirar);
            this.tpRetirarBoveda.Controls.Add(this.label2);
            this.tpRetirarBoveda.Location = new System.Drawing.Point(4, 31);
            this.tpRetirarBoveda.Name = "tpRetirarBoveda";
            this.tpRetirarBoveda.Padding = new System.Windows.Forms.Padding(3);
            this.tpRetirarBoveda.Size = new System.Drawing.Size(1150, 562);
            this.tpRetirarBoveda.TabIndex = 1;
            this.tpRetirarBoveda.Text = "Retirar";
            // 
            // cbCajaRetiro
            // 
            this.cbCajaRetiro.AutoSize = true;
            this.cbCajaRetiro.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbCajaRetiro.Location = new System.Drawing.Point(728, 12);
            this.cbCajaRetiro.Name = "cbCajaRetiro";
            this.cbCajaRetiro.Size = new System.Drawing.Size(67, 26);
            this.cbCajaRetiro.TabIndex = 25;
            this.cbCajaRetiro.Text = "Caja";
            this.cbCajaRetiro.UseVisualStyleBackColor = true;
            // 
            // lbCantidadRetiro
            // 
            this.lbCantidadRetiro.AutoSize = true;
            this.lbCantidadRetiro.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantidadRetiro.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbCantidadRetiro.Location = new System.Drawing.Point(930, 12);
            this.lbCantidadRetiro.Name = "lbCantidadRetiro";
            this.lbCantidadRetiro.Size = new System.Drawing.Size(33, 22);
            this.lbCantidadRetiro.TabIndex = 24;
            this.lbCantidadRetiro.Text = "(0)";
            // 
            // btVerCarritoRetirar
            // 
            this.btVerCarritoRetirar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btVerCarritoRetirar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btVerCarritoRetirar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVerCarritoRetirar.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.btVerCarritoRetirar.IconColor = System.Drawing.Color.Black;
            this.btVerCarritoRetirar.IconSize = 30;
            this.btVerCarritoRetirar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVerCarritoRetirar.Location = new System.Drawing.Point(875, 8);
            this.btVerCarritoRetirar.Name = "btVerCarritoRetirar";
            this.btVerCarritoRetirar.Rotation = 0D;
            this.btVerCarritoRetirar.Size = new System.Drawing.Size(51, 30);
            this.btVerCarritoRetirar.TabIndex = 23;
            this.btVerCarritoRetirar.UseVisualStyleBackColor = true;
            // 
            // btBovedaRetirar
            // 
            this.btBovedaRetirar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btBovedaRetirar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBovedaRetirar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btBovedaRetirar.IconColor = System.Drawing.Color.Black;
            this.btBovedaRetirar.IconSize = 16;
            this.btBovedaRetirar.Location = new System.Drawing.Point(969, 11);
            this.btBovedaRetirar.Name = "btBovedaRetirar";
            this.btBovedaRetirar.Rotation = 0D;
            this.btBovedaRetirar.Size = new System.Drawing.Size(88, 23);
            this.btBovedaRetirar.TabIndex = 20;
            this.btBovedaRetirar.Text = "Recibir";
            this.btBovedaRetirar.UseVisualStyleBackColor = true;
            this.btBovedaRetirar.Click += new System.EventHandler(this.btBovedaRetirar_Click);
            // 
            // tbBusquedaLibreRetirar
            // 
            this.tbBusquedaLibreRetirar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBusquedaLibreRetirar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusquedaLibreRetirar.Location = new System.Drawing.Point(173, 11);
            this.tbBusquedaLibreRetirar.Name = "tbBusquedaLibreRetirar";
            this.tbBusquedaLibreRetirar.Size = new System.Drawing.Size(413, 26);
            this.tbBusquedaLibreRetirar.TabIndex = 12;
            // 
            // dgvBovedaRetirar
            // 
            this.dgvBovedaRetirar.AllowUserToAddRows = false;
            this.dgvBovedaRetirar.AllowUserToDeleteRows = false;
            this.dgvBovedaRetirar.AllowUserToResizeRows = false;
            this.dgvBovedaRetirar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBovedaRetirar.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvBovedaRetirar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBovedaRetirar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 14.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBovedaRetirar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBovedaRetirar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 14.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBovedaRetirar.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBovedaRetirar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvBovedaRetirar.EnableHeadersVisualStyles = false;
            this.dgvBovedaRetirar.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvBovedaRetirar.Location = new System.Drawing.Point(17, 47);
            this.dgvBovedaRetirar.Name = "dgvBovedaRetirar";
            this.dgvBovedaRetirar.ReadOnly = true;
            this.dgvBovedaRetirar.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBovedaRetirar.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvBovedaRetirar.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBovedaRetirar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBovedaRetirar.Size = new System.Drawing.Size(1125, 512);
            this.dgvBovedaRetirar.TabIndex = 14;
            this.dgvBovedaRetirar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBovedaRetirar_CellDoubleClick);
            // 
            // btBuscarRetirar
            // 
            this.btBuscarRetirar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btBuscarRetirar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarRetirar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btBuscarRetirar.IconColor = System.Drawing.Color.Black;
            this.btBuscarRetirar.IconSize = 16;
            this.btBuscarRetirar.Location = new System.Drawing.Point(604, 12);
            this.btBuscarRetirar.Name = "btBuscarRetirar";
            this.btBuscarRetirar.Rotation = 0D;
            this.btBuscarRetirar.Size = new System.Drawing.Size(88, 23);
            this.btBuscarRetirar.TabIndex = 13;
            this.btBuscarRetirar.Text = "Buscar";
            this.btBuscarRetirar.UseVisualStyleBackColor = true;
            this.btBuscarRetirar.Click += new System.EventHandler(this.btBuscarRetirar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(16, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 22);
            this.label2.TabIndex = 11;
            this.label2.Text = "Busqueda Libre:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpRetirarBoveda);
            this.tabControl1.Controls.Add(this.tpGuardar);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 14.25F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1158, 597);
            this.tabControl1.TabIndex = 1;
            // 
            // BovedaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1158, 597);
            this.Controls.Add(this.tabControl1);
            this.Name = "BovedaForm";
            this.Text = "BovedaForm";
            this.tpGuardar.ResumeLayout(false);
            this.tpGuardar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBovedaGuardar)).EndInit();
            this.tpRetirarBoveda.ResumeLayout(false);
            this.tpRetirarBoveda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBovedaRetirar)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tpGuardar;
        private FontAwesome.Sharp.IconButton btBovedaGuardar;
        private System.Windows.Forms.DataGridView dgvBovedaGuardar;
        private System.Windows.Forms.TabPage tpRetirarBoveda;
        private System.Windows.Forms.Label lbCantidadRetiro;
        private FontAwesome.Sharp.IconButton btVerCarritoRetirar;
        private FontAwesome.Sharp.IconButton btBovedaRetirar;
        private System.Windows.Forms.TextBox tbBusquedaLibreRetirar;
        private System.Windows.Forms.DataGridView dgvBovedaRetirar;
        private FontAwesome.Sharp.IconButton btBuscarRetirar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label lbCantidadGuardar;
        private FontAwesome.Sharp.IconButton btVerCarritoGuardar;
        private System.Windows.Forms.TextBox tbBusquedaLibreGuardar;
        private FontAwesome.Sharp.IconButton btBuscarGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbCajaRetiro;
        private System.Windows.Forms.CheckBox cbCajaGuardar;
    }
}