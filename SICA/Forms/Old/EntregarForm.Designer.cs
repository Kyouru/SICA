namespace SICA.Forms
{
    partial class EntregarForm
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
            this.tcEntregar = new System.Windows.Forms.TabControl();
            this.tbExpedientes = new System.Windows.Forms.TabPage();
            this.lbCantidadEXP = new System.Windows.Forms.Label();
            this.btVerCarritoEXP = new FontAwesome.Sharp.IconButton();
            this.btEntregarEXP = new FontAwesome.Sharp.IconButton();
            this.btBuscarEXP = new FontAwesome.Sharp.IconButton();
            this.tbBusquedaLibreEXP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvExpedientes = new System.Windows.Forms.DataGridView();
            this.tpDocumentos = new System.Windows.Forms.TabPage();
            this.lbCantidadDOC = new System.Windows.Forms.Label();
            this.btVerCarritoDocumento = new FontAwesome.Sharp.IconButton();
            this.btEntregarDOC = new FontAwesome.Sharp.IconButton();
            this.btBuscarDOC = new FontAwesome.Sharp.IconButton();
            this.tbBusquedaLibreDOC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDocumentos = new System.Windows.Forms.DataGridView();
            this.tpPagare = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDesembolsado = new System.Windows.Forms.CheckBox();
            this.lbCantidadPagare = new System.Windows.Forms.Label();
            this.btVerCarritoPagare = new FontAwesome.Sharp.IconButton();
            this.btEntregarPagare = new FontAwesome.Sharp.IconButton();
            this.dgvPagare = new System.Windows.Forms.DataGridView();
            this.btBuscarPagare = new FontAwesome.Sharp.IconButton();
            this.tbBusquedaLibrePagare = new System.Windows.Forms.TextBox();
            this.tpLetras = new System.Windows.Forms.TabPage();
            this.tcEntregar.SuspendLayout();
            this.tbExpedientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpedientes)).BeginInit();
            this.tpDocumentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).BeginInit();
            this.tpPagare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagare)).BeginInit();
            this.SuspendLayout();
            // 
            // tcEntregar
            // 
            this.tcEntregar.Controls.Add(this.tbExpedientes);
            this.tcEntregar.Controls.Add(this.tpDocumentos);
            this.tcEntregar.Controls.Add(this.tpPagare);
            this.tcEntregar.Controls.Add(this.tpLetras);
            this.tcEntregar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcEntregar.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcEntregar.Location = new System.Drawing.Point(0, 0);
            this.tcEntregar.Name = "tcEntregar";
            this.tcEntregar.SelectedIndex = 0;
            this.tcEntregar.Size = new System.Drawing.Size(1276, 661);
            this.tcEntregar.TabIndex = 1;
            // 
            // tbExpedientes
            // 
            this.tbExpedientes.BackColor = System.Drawing.Color.MidnightBlue;
            this.tbExpedientes.Controls.Add(this.lbCantidadEXP);
            this.tbExpedientes.Controls.Add(this.btVerCarritoEXP);
            this.tbExpedientes.Controls.Add(this.btEntregarEXP);
            this.tbExpedientes.Controls.Add(this.btBuscarEXP);
            this.tbExpedientes.Controls.Add(this.tbBusquedaLibreEXP);
            this.tbExpedientes.Controls.Add(this.label2);
            this.tbExpedientes.Controls.Add(this.dgvExpedientes);
            this.tbExpedientes.Location = new System.Drawing.Point(4, 31);
            this.tbExpedientes.Name = "tbExpedientes";
            this.tbExpedientes.Padding = new System.Windows.Forms.Padding(3);
            this.tbExpedientes.Size = new System.Drawing.Size(1268, 626);
            this.tbExpedientes.TabIndex = 0;
            this.tbExpedientes.Text = "Expedientes";
            this.tbExpedientes.Enter += new System.EventHandler(this.tbExpedientes_Enter);
            // 
            // lbCantidadEXP
            // 
            this.lbCantidadEXP.AutoSize = true;
            this.lbCantidadEXP.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantidadEXP.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbCantidadEXP.Location = new System.Drawing.Point(925, 8);
            this.lbCantidadEXP.Name = "lbCantidadEXP";
            this.lbCantidadEXP.Size = new System.Drawing.Size(33, 22);
            this.lbCantidadEXP.TabIndex = 24;
            this.lbCantidadEXP.Text = "(0)";
            // 
            // btVerCarritoEXP
            // 
            this.btVerCarritoEXP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btVerCarritoEXP.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btVerCarritoEXP.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVerCarritoEXP.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.btVerCarritoEXP.IconColor = System.Drawing.Color.Black;
            this.btVerCarritoEXP.IconSize = 30;
            this.btVerCarritoEXP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVerCarritoEXP.Location = new System.Drawing.Point(870, 4);
            this.btVerCarritoEXP.Name = "btVerCarritoEXP";
            this.btVerCarritoEXP.Rotation = 0D;
            this.btVerCarritoEXP.Size = new System.Drawing.Size(51, 30);
            this.btVerCarritoEXP.TabIndex = 23;
            this.btVerCarritoEXP.UseVisualStyleBackColor = true;
            this.btVerCarritoEXP.Click += new System.EventHandler(this.btVerCarritoEXP_Click);
            // 
            // btEntregarEXP
            // 
            this.btEntregarEXP.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btEntregarEXP.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEntregarEXP.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btEntregarEXP.IconColor = System.Drawing.Color.Black;
            this.btEntregarEXP.IconSize = 16;
            this.btEntregarEXP.Location = new System.Drawing.Point(982, 10);
            this.btEntregarEXP.Name = "btEntregarEXP";
            this.btEntregarEXP.Rotation = 0D;
            this.btEntregarEXP.Size = new System.Drawing.Size(110, 23);
            this.btEntregarEXP.TabIndex = 9;
            this.btEntregarEXP.Text = "Entregar";
            this.btEntregarEXP.UseVisualStyleBackColor = true;
            this.btEntregarEXP.Click += new System.EventHandler(this.btEntregarEXP_Click);
            // 
            // btBuscarEXP
            // 
            this.btBuscarEXP.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btBuscarEXP.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarEXP.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btBuscarEXP.IconColor = System.Drawing.Color.Black;
            this.btBuscarEXP.IconSize = 16;
            this.btBuscarEXP.Location = new System.Drawing.Point(508, 10);
            this.btBuscarEXP.Name = "btBuscarEXP";
            this.btBuscarEXP.Rotation = 0D;
            this.btBuscarEXP.Size = new System.Drawing.Size(88, 23);
            this.btBuscarEXP.TabIndex = 8;
            this.btBuscarEXP.Text = "Buscar";
            this.btBuscarEXP.UseVisualStyleBackColor = true;
            this.btBuscarEXP.Click += new System.EventHandler(this.btBuscarEXP_Click);
            // 
            // tbBusquedaLibreEXP
            // 
            this.tbBusquedaLibreEXP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBusquedaLibreEXP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusquedaLibreEXP.Location = new System.Drawing.Point(166, 10);
            this.tbBusquedaLibreEXP.Name = "tbBusquedaLibreEXP";
            this.tbBusquedaLibreEXP.Size = new System.Drawing.Size(321, 22);
            this.tbBusquedaLibreEXP.TabIndex = 7;
            this.tbBusquedaLibreEXP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBusquedaLibreEXP_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(11, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Busqueda Libre:";
            // 
            // dgvExpedientes
            // 
            this.dgvExpedientes.AllowUserToAddRows = false;
            this.dgvExpedientes.AllowUserToDeleteRows = false;
            this.dgvExpedientes.AllowUserToResizeRows = false;
            this.dgvExpedientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExpedientes.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvExpedientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvExpedientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExpedientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExpedientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExpedientes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvExpedientes.EnableHeadersVisualStyles = false;
            this.dgvExpedientes.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvExpedientes.Location = new System.Drawing.Point(8, 45);
            this.dgvExpedientes.Name = "dgvExpedientes";
            this.dgvExpedientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvExpedientes.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvExpedientes.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvExpedientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpedientes.Size = new System.Drawing.Size(1252, 573);
            this.dgvExpedientes.TabIndex = 0;
            this.dgvExpedientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpedientes_CellDoubleClick);
            // 
            // tpDocumentos
            // 
            this.tpDocumentos.BackColor = System.Drawing.Color.MidnightBlue;
            this.tpDocumentos.Controls.Add(this.lbCantidadDOC);
            this.tpDocumentos.Controls.Add(this.btVerCarritoDocumento);
            this.tpDocumentos.Controls.Add(this.btEntregarDOC);
            this.tpDocumentos.Controls.Add(this.btBuscarDOC);
            this.tpDocumentos.Controls.Add(this.tbBusquedaLibreDOC);
            this.tpDocumentos.Controls.Add(this.label1);
            this.tpDocumentos.Controls.Add(this.dgvDocumentos);
            this.tpDocumentos.Location = new System.Drawing.Point(4, 31);
            this.tpDocumentos.Name = "tpDocumentos";
            this.tpDocumentos.Padding = new System.Windows.Forms.Padding(3);
            this.tpDocumentos.Size = new System.Drawing.Size(1151, 582);
            this.tpDocumentos.TabIndex = 1;
            this.tpDocumentos.Text = "Documentos";
            this.tpDocumentos.Enter += new System.EventHandler(this.tpDocumentos_Enter);
            // 
            // lbCantidadDOC
            // 
            this.lbCantidadDOC.AutoSize = true;
            this.lbCantidadDOC.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantidadDOC.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbCantidadDOC.Location = new System.Drawing.Point(969, 11);
            this.lbCantidadDOC.Name = "lbCantidadDOC";
            this.lbCantidadDOC.Size = new System.Drawing.Size(33, 22);
            this.lbCantidadDOC.TabIndex = 26;
            this.lbCantidadDOC.Text = "(0)";
            // 
            // btVerCarritoDocumento
            // 
            this.btVerCarritoDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btVerCarritoDocumento.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btVerCarritoDocumento.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVerCarritoDocumento.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.btVerCarritoDocumento.IconColor = System.Drawing.Color.Black;
            this.btVerCarritoDocumento.IconSize = 30;
            this.btVerCarritoDocumento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVerCarritoDocumento.Location = new System.Drawing.Point(914, 7);
            this.btVerCarritoDocumento.Name = "btVerCarritoDocumento";
            this.btVerCarritoDocumento.Rotation = 0D;
            this.btVerCarritoDocumento.Size = new System.Drawing.Size(51, 30);
            this.btVerCarritoDocumento.TabIndex = 25;
            this.btVerCarritoDocumento.UseVisualStyleBackColor = true;
            this.btVerCarritoDocumento.Click += new System.EventHandler(this.btVerCarritoDocumento_Click);
            // 
            // btEntregarDOC
            // 
            this.btEntregarDOC.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btEntregarDOC.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEntregarDOC.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btEntregarDOC.IconColor = System.Drawing.Color.Black;
            this.btEntregarDOC.IconSize = 16;
            this.btEntregarDOC.Location = new System.Drawing.Point(1017, 11);
            this.btEntregarDOC.Name = "btEntregarDOC";
            this.btEntregarDOC.Rotation = 0D;
            this.btEntregarDOC.Size = new System.Drawing.Size(110, 24);
            this.btEntregarDOC.TabIndex = 13;
            this.btEntregarDOC.Text = "Entregar";
            this.btEntregarDOC.UseVisualStyleBackColor = true;
            this.btEntregarDOC.Click += new System.EventHandler(this.btEntregarDOC_Click);
            // 
            // btBuscarDOC
            // 
            this.btBuscarDOC.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btBuscarDOC.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarDOC.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btBuscarDOC.IconColor = System.Drawing.Color.Black;
            this.btBuscarDOC.IconSize = 16;
            this.btBuscarDOC.Location = new System.Drawing.Point(510, 11);
            this.btBuscarDOC.Name = "btBuscarDOC";
            this.btBuscarDOC.Rotation = 0D;
            this.btBuscarDOC.Size = new System.Drawing.Size(88, 23);
            this.btBuscarDOC.TabIndex = 12;
            this.btBuscarDOC.Text = "Buscar";
            this.btBuscarDOC.UseVisualStyleBackColor = true;
            this.btBuscarDOC.Click += new System.EventHandler(this.btBuscarDOC_Click);
            // 
            // tbBusquedaLibreDOC
            // 
            this.tbBusquedaLibreDOC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBusquedaLibreDOC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusquedaLibreDOC.Location = new System.Drawing.Point(168, 11);
            this.tbBusquedaLibreDOC.Name = "tbBusquedaLibreDOC";
            this.tbBusquedaLibreDOC.Size = new System.Drawing.Size(321, 22);
            this.tbBusquedaLibreDOC.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Busqueda Libre:";
            // 
            // dgvDocumentos
            // 
            this.dgvDocumentos.AllowUserToAddRows = false;
            this.dgvDocumentos.AllowUserToDeleteRows = false;
            this.dgvDocumentos.AllowUserToResizeRows = false;
            this.dgvDocumentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocumentos.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvDocumentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDocumentos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocumentos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocumentos.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDocumentos.EnableHeadersVisualStyles = false;
            this.dgvDocumentos.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvDocumentos.Location = new System.Drawing.Point(8, 46);
            this.dgvDocumentos.Name = "dgvDocumentos";
            this.dgvDocumentos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDocumentos.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDocumentos.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDocumentos.Size = new System.Drawing.Size(1135, 529);
            this.dgvDocumentos.TabIndex = 4;
            this.dgvDocumentos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentos_CellDoubleClick);
            // 
            // tpPagare
            // 
            this.tpPagare.BackColor = System.Drawing.Color.MidnightBlue;
            this.tpPagare.Controls.Add(this.label3);
            this.tpPagare.Controls.Add(this.cbDesembolsado);
            this.tpPagare.Controls.Add(this.lbCantidadPagare);
            this.tpPagare.Controls.Add(this.btVerCarritoPagare);
            this.tpPagare.Controls.Add(this.btEntregarPagare);
            this.tpPagare.Controls.Add(this.dgvPagare);
            this.tpPagare.Controls.Add(this.btBuscarPagare);
            this.tpPagare.Controls.Add(this.tbBusquedaLibrePagare);
            this.tpPagare.Location = new System.Drawing.Point(4, 31);
            this.tpPagare.Name = "tpPagare";
            this.tpPagare.Padding = new System.Windows.Forms.Padding(3);
            this.tpPagare.Size = new System.Drawing.Size(1151, 582);
            this.tpPagare.TabIndex = 2;
            this.tpPagare.Text = "Pagares";
            this.tpPagare.Enter += new System.EventHandler(this.tpPagare_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(24, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 22);
            this.label3.TabIndex = 36;
            this.label3.Text = "Busqueda Libre:";
            // 
            // cbDesembolsado
            // 
            this.cbDesembolsado.AutoSize = true;
            this.cbDesembolsado.Checked = true;
            this.cbDesembolsado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDesembolsado.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbDesembolsado.Location = new System.Drawing.Point(480, 11);
            this.cbDesembolsado.Name = "cbDesembolsado";
            this.cbDesembolsado.Size = new System.Drawing.Size(159, 26);
            this.cbDesembolsado.TabIndex = 35;
            this.cbDesembolsado.Text = "Desembolsado";
            this.cbDesembolsado.UseVisualStyleBackColor = true;
            // 
            // lbCantidadPagare
            // 
            this.lbCantidadPagare.AutoSize = true;
            this.lbCantidadPagare.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantidadPagare.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbCantidadPagare.Location = new System.Drawing.Point(995, 9);
            this.lbCantidadPagare.Name = "lbCantidadPagare";
            this.lbCantidadPagare.Size = new System.Drawing.Size(33, 22);
            this.lbCantidadPagare.TabIndex = 34;
            this.lbCantidadPagare.Text = "(0)";
            // 
            // btVerCarritoPagare
            // 
            this.btVerCarritoPagare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btVerCarritoPagare.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btVerCarritoPagare.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVerCarritoPagare.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.btVerCarritoPagare.IconColor = System.Drawing.Color.Black;
            this.btVerCarritoPagare.IconSize = 30;
            this.btVerCarritoPagare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVerCarritoPagare.Location = new System.Drawing.Point(940, 5);
            this.btVerCarritoPagare.Name = "btVerCarritoPagare";
            this.btVerCarritoPagare.Rotation = 0D;
            this.btVerCarritoPagare.Size = new System.Drawing.Size(51, 30);
            this.btVerCarritoPagare.TabIndex = 33;
            this.btVerCarritoPagare.UseVisualStyleBackColor = true;
            // 
            // btEntregarPagare
            // 
            this.btEntregarPagare.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btEntregarPagare.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEntregarPagare.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btEntregarPagare.IconColor = System.Drawing.Color.Black;
            this.btEntregarPagare.IconSize = 16;
            this.btEntregarPagare.Location = new System.Drawing.Point(1046, 10);
            this.btEntregarPagare.Name = "btEntregarPagare";
            this.btEntregarPagare.Rotation = 0D;
            this.btEntregarPagare.Size = new System.Drawing.Size(88, 23);
            this.btEntregarPagare.TabIndex = 32;
            this.btEntregarPagare.Text = "Entregar";
            this.btEntregarPagare.UseVisualStyleBackColor = true;
            this.btEntregarPagare.Click += new System.EventHandler(this.btEntregarPagare_Click);
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
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPagare.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPagare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPagare.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPagare.EnableHeadersVisualStyles = false;
            this.dgvPagare.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvPagare.Location = new System.Drawing.Point(6, 38);
            this.dgvPagare.Name = "dgvPagare";
            this.dgvPagare.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPagare.RowHeadersVisible = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPagare.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvPagare.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagare.Size = new System.Drawing.Size(1139, 536);
            this.dgvPagare.TabIndex = 31;
            this.dgvPagare.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPagare_CellDoubleClick);
            // 
            // btBuscarPagare
            // 
            this.btBuscarPagare.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btBuscarPagare.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarPagare.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btBuscarPagare.IconColor = System.Drawing.Color.Black;
            this.btBuscarPagare.IconSize = 16;
            this.btBuscarPagare.Location = new System.Drawing.Point(671, 13);
            this.btBuscarPagare.Name = "btBuscarPagare";
            this.btBuscarPagare.Rotation = 0D;
            this.btBuscarPagare.Size = new System.Drawing.Size(88, 23);
            this.btBuscarPagare.TabIndex = 30;
            this.btBuscarPagare.Text = "Buscar";
            this.btBuscarPagare.UseVisualStyleBackColor = true;
            this.btBuscarPagare.Click += new System.EventHandler(this.btBuscarPagare_Click);
            // 
            // tbBusquedaLibrePagare
            // 
            this.tbBusquedaLibrePagare.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBusquedaLibrePagare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusquedaLibrePagare.Location = new System.Drawing.Point(184, 10);
            this.tbBusquedaLibrePagare.Name = "tbBusquedaLibrePagare";
            this.tbBusquedaLibrePagare.Size = new System.Drawing.Size(278, 26);
            this.tbBusquedaLibrePagare.TabIndex = 29;
            // 
            // tpLetras
            // 
            this.tpLetras.BackColor = System.Drawing.Color.MidnightBlue;
            this.tpLetras.Location = new System.Drawing.Point(4, 31);
            this.tpLetras.Name = "tpLetras";
            this.tpLetras.Padding = new System.Windows.Forms.Padding(3);
            this.tpLetras.Size = new System.Drawing.Size(1151, 582);
            this.tpLetras.TabIndex = 3;
            this.tpLetras.Text = "Letras";
            // 
            // EntregarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1276, 661);
            this.Controls.Add(this.tcEntregar);
            this.Name = "EntregarForm";
            this.Text = "EntregarForm";
            this.tcEntregar.ResumeLayout(false);
            this.tbExpedientes.ResumeLayout(false);
            this.tbExpedientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpedientes)).EndInit();
            this.tpDocumentos.ResumeLayout(false);
            this.tpDocumentos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).EndInit();
            this.tpPagare.ResumeLayout(false);
            this.tpPagare.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagare)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcEntregar;
        private System.Windows.Forms.TabPage tbExpedientes;
        private System.Windows.Forms.DataGridView dgvExpedientes;
        private System.Windows.Forms.TabPage tpDocumentos;
        private System.Windows.Forms.DataGridView dgvDocumentos;
        private System.Windows.Forms.TabPage tpPagare;
        private System.Windows.Forms.TabPage tpLetras;
        private FontAwesome.Sharp.IconButton btBuscarEXP;
        private System.Windows.Forms.TextBox tbBusquedaLibreEXP;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btEntregarEXP;
        private FontAwesome.Sharp.IconButton btEntregarDOC;
        private FontAwesome.Sharp.IconButton btBuscarDOC;
        private System.Windows.Forms.TextBox tbBusquedaLibreDOC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCantidadEXP;
        private FontAwesome.Sharp.IconButton btVerCarritoEXP;
        private System.Windows.Forms.Label lbCantidadDOC;
        private FontAwesome.Sharp.IconButton btVerCarritoDocumento;
        private FontAwesome.Sharp.IconButton btEntregarPagare;
        private System.Windows.Forms.DataGridView dgvPagare;
        private FontAwesome.Sharp.IconButton btBuscarPagare;
        private System.Windows.Forms.TextBox tbBusquedaLibrePagare;
        private System.Windows.Forms.Label lbCantidadPagare;
        private FontAwesome.Sharp.IconButton btVerCarritoPagare;
        private System.Windows.Forms.CheckBox cbDesembolsado;
        private System.Windows.Forms.Label label3;
    }
}