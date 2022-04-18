namespace SICA
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnLeft = new System.Windows.Forms.Panel();
            this.btDocuClass = new FontAwesome.Sharp.IconButton();
            this.btBoveda = new FontAwesome.Sharp.IconButton();
            this.btIronMountain = new FontAwesome.Sharp.IconButton();
            this.btLetra = new FontAwesome.Sharp.IconButton();
            this.btPagare = new FontAwesome.Sharp.IconButton();
            this.btRecibir = new FontAwesome.Sharp.IconButton();
            this.btEntregar = new FontAwesome.Sharp.IconButton();
            this.btBusqueda = new FontAwesome.Sharp.IconButton();
            this.icMain = new FontAwesome.Sharp.IconPictureBox();
            this.pnTop = new System.Windows.Forms.Panel();
            this.btActualizar = new FontAwesome.Sharp.IconButton();
            this.lbEstado = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btMinimizar = new FontAwesome.Sharp.IconButton();
            this.btMaximizar = new FontAwesome.Sharp.IconButton();
            this.btCerrar = new FontAwesome.Sharp.IconButton();
            this.pnMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icMain)).BeginInit();
            this.pnTop.SuspendLayout();
            this.pnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnLeft
            // 
            this.pnLeft.Controls.Add(this.btDocuClass);
            this.pnLeft.Controls.Add(this.btBoveda);
            this.pnLeft.Controls.Add(this.btIronMountain);
            this.pnLeft.Controls.Add(this.btLetra);
            this.pnLeft.Controls.Add(this.btPagare);
            this.pnLeft.Controls.Add(this.btRecibir);
            this.pnLeft.Controls.Add(this.btEntregar);
            this.pnLeft.Controls.Add(this.btBusqueda);
            this.pnLeft.Controls.Add(this.icMain);
            this.pnLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLeft.Location = new System.Drawing.Point(0, 0);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(200, 746);
            this.pnLeft.TabIndex = 0;
            // 
            // btDocuClass
            // 
            this.btDocuClass.Dock = System.Windows.Forms.DockStyle.Top;
            this.btDocuClass.FlatAppearance.BorderSize = 0;
            this.btDocuClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDocuClass.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDocuClass.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btDocuClass.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btDocuClass.IconColor = System.Drawing.Color.Gainsboro;
            this.btDocuClass.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btDocuClass.IconSize = 30;
            this.btDocuClass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDocuClass.Location = new System.Drawing.Point(0, 497);
            this.btDocuClass.Name = "btDocuClass";
            this.btDocuClass.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btDocuClass.Size = new System.Drawing.Size(200, 61);
            this.btDocuClass.TabIndex = 15;
            this.btDocuClass.Text = "  DocuClass";
            this.btDocuClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDocuClass.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDocuClass.UseVisualStyleBackColor = true;
            this.btDocuClass.Visible = false;
            this.btDocuClass.Click += new System.EventHandler(this.btDocuClass_Click);
            // 
            // btBoveda
            // 
            this.btBoveda.Dock = System.Windows.Forms.DockStyle.Top;
            this.btBoveda.FlatAppearance.BorderSize = 0;
            this.btBoveda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBoveda.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBoveda.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btBoveda.IconChar = FontAwesome.Sharp.IconChar.Archive;
            this.btBoveda.IconColor = System.Drawing.Color.Gainsboro;
            this.btBoveda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btBoveda.IconSize = 30;
            this.btBoveda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBoveda.Location = new System.Drawing.Point(0, 436);
            this.btBoveda.Name = "btBoveda";
            this.btBoveda.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btBoveda.Size = new System.Drawing.Size(200, 61);
            this.btBoveda.TabIndex = 14;
            this.btBoveda.Text = "  Boveda";
            this.btBoveda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBoveda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btBoveda.UseVisualStyleBackColor = true;
            this.btBoveda.Click += new System.EventHandler(this.btBoveda_Click);
            // 
            // btIronMountain
            // 
            this.btIronMountain.Dock = System.Windows.Forms.DockStyle.Top;
            this.btIronMountain.FlatAppearance.BorderSize = 0;
            this.btIronMountain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btIronMountain.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIronMountain.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btIronMountain.IconChar = FontAwesome.Sharp.IconChar.Mountain;
            this.btIronMountain.IconColor = System.Drawing.Color.Gainsboro;
            this.btIronMountain.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btIronMountain.IconSize = 30;
            this.btIronMountain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btIronMountain.Location = new System.Drawing.Point(0, 375);
            this.btIronMountain.Name = "btIronMountain";
            this.btIronMountain.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btIronMountain.Size = new System.Drawing.Size(200, 61);
            this.btIronMountain.TabIndex = 13;
            this.btIronMountain.Text = "  Iron Mountain";
            this.btIronMountain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btIronMountain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btIronMountain.UseVisualStyleBackColor = true;
            this.btIronMountain.Click += new System.EventHandler(this.btIronMountain_Click);
            // 
            // btLetra
            // 
            this.btLetra.Dock = System.Windows.Forms.DockStyle.Top;
            this.btLetra.FlatAppearance.BorderSize = 0;
            this.btLetra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLetra.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLetra.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btLetra.IconChar = FontAwesome.Sharp.IconChar.MoneyCheckAlt;
            this.btLetra.IconColor = System.Drawing.Color.Gainsboro;
            this.btLetra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btLetra.IconSize = 30;
            this.btLetra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLetra.Location = new System.Drawing.Point(0, 314);
            this.btLetra.Name = "btLetra";
            this.btLetra.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btLetra.Size = new System.Drawing.Size(200, 61);
            this.btLetra.TabIndex = 12;
            this.btLetra.Text = "  Letra";
            this.btLetra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLetra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btLetra.UseVisualStyleBackColor = true;
            this.btLetra.Click += new System.EventHandler(this.btLetras_Click);
            // 
            // btPagare
            // 
            this.btPagare.Dock = System.Windows.Forms.DockStyle.Top;
            this.btPagare.FlatAppearance.BorderSize = 0;
            this.btPagare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPagare.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPagare.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btPagare.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            this.btPagare.IconColor = System.Drawing.Color.Gainsboro;
            this.btPagare.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btPagare.IconSize = 30;
            this.btPagare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPagare.Location = new System.Drawing.Point(0, 253);
            this.btPagare.Name = "btPagare";
            this.btPagare.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btPagare.Size = new System.Drawing.Size(200, 61);
            this.btPagare.TabIndex = 11;
            this.btPagare.Text = "  Pagare";
            this.btPagare.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPagare.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPagare.UseVisualStyleBackColor = true;
            this.btPagare.Click += new System.EventHandler(this.btPagare_Click);
            // 
            // btRecibir
            // 
            this.btRecibir.Dock = System.Windows.Forms.DockStyle.Top;
            this.btRecibir.FlatAppearance.BorderSize = 0;
            this.btRecibir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRecibir.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRecibir.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btRecibir.IconChar = FontAwesome.Sharp.IconChar.LuggageCart;
            this.btRecibir.IconColor = System.Drawing.Color.Gainsboro;
            this.btRecibir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btRecibir.IconSize = 30;
            this.btRecibir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRecibir.Location = new System.Drawing.Point(0, 192);
            this.btRecibir.Name = "btRecibir";
            this.btRecibir.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btRecibir.Size = new System.Drawing.Size(200, 61);
            this.btRecibir.TabIndex = 5;
            this.btRecibir.Text = "  Valija";
            this.btRecibir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRecibir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRecibir.UseVisualStyleBackColor = true;
            this.btRecibir.Click += new System.EventHandler(this.btRecibir_Click);
            // 
            // btEntregar
            // 
            this.btEntregar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btEntregar.FlatAppearance.BorderSize = 0;
            this.btEntregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEntregar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEntregar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btEntregar.IconChar = FontAwesome.Sharp.IconChar.FileUpload;
            this.btEntregar.IconColor = System.Drawing.Color.Gainsboro;
            this.btEntregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btEntregar.IconSize = 30;
            this.btEntregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEntregar.Location = new System.Drawing.Point(0, 131);
            this.btEntregar.Name = "btEntregar";
            this.btEntregar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btEntregar.Size = new System.Drawing.Size(200, 61);
            this.btEntregar.TabIndex = 4;
            this.btEntregar.Text = "  Entregar";
            this.btEntregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEntregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEntregar.UseVisualStyleBackColor = true;
            this.btEntregar.Click += new System.EventHandler(this.btEntregar_Click);
            // 
            // btBusqueda
            // 
            this.btBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.btBusqueda.FlatAppearance.BorderSize = 0;
            this.btBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBusqueda.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBusqueda.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btBusqueda.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btBusqueda.IconColor = System.Drawing.Color.Gainsboro;
            this.btBusqueda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btBusqueda.IconSize = 30;
            this.btBusqueda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBusqueda.Location = new System.Drawing.Point(0, 70);
            this.btBusqueda.Name = "btBusqueda";
            this.btBusqueda.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btBusqueda.Size = new System.Drawing.Size(200, 61);
            this.btBusqueda.TabIndex = 3;
            this.btBusqueda.Text = "  Busqueda";
            this.btBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBusqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btBusqueda.UseVisualStyleBackColor = true;
            this.btBusqueda.Click += new System.EventHandler(this.btBusqueda_Click);
            // 
            // icMain
            // 
            this.icMain.BackColor = System.Drawing.Color.MidnightBlue;
            this.icMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("icMain.BackgroundImage")));
            this.icMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.icMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.icMain.IconChar = FontAwesome.Sharp.IconChar.None;
            this.icMain.IconColor = System.Drawing.SystemColors.ControlText;
            this.icMain.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icMain.IconSize = 70;
            this.icMain.Location = new System.Drawing.Point(0, 0);
            this.icMain.Name = "icMain";
            this.icMain.Size = new System.Drawing.Size(200, 70);
            this.icMain.TabIndex = 0;
            this.icMain.TabStop = false;
            this.icMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.icMain_MouseDown);
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnTop.Controls.Add(this.btActualizar);
            this.pnTop.Controls.Add(this.lbEstado);
            this.pnTop.Controls.Add(this.panel2);
            this.pnTop.Controls.Add(this.lbUsuario);
            this.pnTop.Controls.Add(this.label1);
            this.pnTop.Controls.Add(this.btMinimizar);
            this.pnTop.Controls.Add(this.btMaximizar);
            this.pnTop.Controls.Add(this.btCerrar);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(5, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1129, 34);
            this.pnTop.TabIndex = 1;
            this.pnTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseDown);
            // 
            // btActualizar
            // 
            this.btActualizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btActualizar.IconChar = FontAwesome.Sharp.IconChar.SyncAlt;
            this.btActualizar.IconColor = System.Drawing.Color.Gainsboro;
            this.btActualizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btActualizar.IconSize = 20;
            this.btActualizar.Location = new System.Drawing.Point(6, 3);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(34, 28);
            this.btActualizar.TabIndex = 42;
            this.btActualizar.UseVisualStyleBackColor = true;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // lbEstado
            // 
            this.lbEstado.AutoSize = true;
            this.lbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstado.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbEstado.Location = new System.Drawing.Point(48, 8);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(0, 18);
            this.lbEstado.TabIndex = 9;
            this.lbEstado.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbEstado_MouseDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1129, 5);
            this.panel2.TabIndex = 8;
            // 
            // lbUsuario
            // 
            this.lbUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbUsuario.Location = new System.Drawing.Point(902, 10);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(109, 13);
            this.lbUsuario.TabIndex = 7;
            this.lbUsuario.Text = "NOMBRE_USUARIO";
            this.lbUsuario.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbUsuario_MouseDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(850, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Usuario:";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // btMinimizar
            // 
            this.btMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMinimizar.FlatAppearance.BorderSize = 0;
            this.btMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMinimizar.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btMinimizar.IconColor = System.Drawing.Color.White;
            this.btMinimizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btMinimizar.IconSize = 24;
            this.btMinimizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btMinimizar.Location = new System.Drawing.Point(1050, 0);
            this.btMinimizar.Margin = new System.Windows.Forms.Padding(0);
            this.btMinimizar.Name = "btMinimizar";
            this.btMinimizar.Size = new System.Drawing.Size(26, 23);
            this.btMinimizar.TabIndex = 5;
            this.btMinimizar.UseVisualStyleBackColor = true;
            this.btMinimizar.Click += new System.EventHandler(this.btMinimizar_Click);
            // 
            // btMaximizar
            // 
            this.btMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMaximizar.FlatAppearance.BorderSize = 0;
            this.btMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMaximizar.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.btMaximizar.IconColor = System.Drawing.Color.White;
            this.btMaximizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btMaximizar.IconSize = 24;
            this.btMaximizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btMaximizar.Location = new System.Drawing.Point(1076, 0);
            this.btMaximizar.Margin = new System.Windows.Forms.Padding(0);
            this.btMaximizar.Name = "btMaximizar";
            this.btMaximizar.Size = new System.Drawing.Size(26, 23);
            this.btMaximizar.TabIndex = 4;
            this.btMaximizar.UseVisualStyleBackColor = true;
            this.btMaximizar.Click += new System.EventHandler(this.btMaximizar_Click);
            // 
            // btCerrar
            // 
            this.btCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCerrar.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.btCerrar.IconColor = System.Drawing.Color.White;
            this.btCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btCerrar.IconSize = 24;
            this.btCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCerrar.Location = new System.Drawing.Point(1102, 0);
            this.btCerrar.Margin = new System.Windows.Forms.Padding(0);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(26, 23);
            this.btCerrar.TabIndex = 3;
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.pnTop);
            this.pnMain.Controls.Add(this.panel1);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(200, 0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1134, 746);
            this.pnMain.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 746);
            this.panel1.TabIndex = 12;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1334, 746);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icMain)).EndInit();
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            this.pnMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel pnMain;
        private FontAwesome.Sharp.IconPictureBox icMain;
        private FontAwesome.Sharp.IconButton btMinimizar;
        private FontAwesome.Sharp.IconButton btMaximizar;
        private FontAwesome.Sharp.IconButton btCerrar;
        private FontAwesome.Sharp.IconButton btEntregar;
        private FontAwesome.Sharp.IconButton btRecibir;
        private FontAwesome.Sharp.IconButton btBusqueda;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbEstado;
        private System.Windows.Forms.Timer timer1;
        private FontAwesome.Sharp.IconButton btActualizar;
        private FontAwesome.Sharp.IconButton btDocuClass;
        private FontAwesome.Sharp.IconButton btBoveda;
        private FontAwesome.Sharp.IconButton btIronMountain;
        private FontAwesome.Sharp.IconButton btLetra;
        private FontAwesome.Sharp.IconButton btPagare;
    }
}

