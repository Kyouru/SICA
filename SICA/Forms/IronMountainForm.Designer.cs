namespace SICA.Forms
{
    partial class IronMountainForm
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
            this.tpRecibirIM = new System.Windows.Forms.TabPage();
            this.dgvRecibirIM = new System.Windows.Forms.DataGridView();
            this.btActualizarRecibir = new FontAwesome.Sharp.IconButton();
            this.tpSolicitarIM = new System.Windows.Forms.TabPage();
            this.btVerCarritoSolicitar = new FontAwesome.Sharp.IconButton();
            this.btSolicitarCajasIM = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCaja = new System.Windows.Forms.TextBox();
            this.tbBusquedaLibre = new System.Windows.Forms.TextBox();
            this.dgvSolicitarIM = new System.Windows.Forms.DataGridView();
            this.btBuscarReingreso = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.lbCantidadSolicitar = new System.Windows.Forms.Label();
            this.lbCantidadRecibir = new System.Windows.Forms.Label();
            this.btVerCarritoRecibir = new FontAwesome.Sharp.IconButton();
            this.btRecibirCajas = new FontAwesome.Sharp.IconButton();
            this.tpRecibirIM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecibirIM)).BeginInit();
            this.tpSolicitarIM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitarIM)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpRecibirIM
            // 
            this.tpRecibirIM.BackColor = System.Drawing.Color.MidnightBlue;
            this.tpRecibirIM.Controls.Add(this.lbCantidadRecibir);
            this.tpRecibirIM.Controls.Add(this.btVerCarritoRecibir);
            this.tpRecibirIM.Controls.Add(this.btRecibirCajas);
            this.tpRecibirIM.Controls.Add(this.dgvRecibirIM);
            this.tpRecibirIM.Controls.Add(this.btActualizarRecibir);
            this.tpRecibirIM.Location = new System.Drawing.Point(4, 31);
            this.tpRecibirIM.Name = "tpRecibirIM";
            this.tpRecibirIM.Padding = new System.Windows.Forms.Padding(3);
            this.tpRecibirIM.Size = new System.Drawing.Size(1109, 555);
            this.tpRecibirIM.TabIndex = 2;
            this.tpRecibirIM.Text = "Recibir";
            // 
            // dgvRecibirIM
            // 
            this.dgvRecibirIM.AllowUserToAddRows = false;
            this.dgvRecibirIM.AllowUserToDeleteRows = false;
            this.dgvRecibirIM.AllowUserToResizeRows = false;
            this.dgvRecibirIM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecibirIM.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvRecibirIM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecibirIM.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 14.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecibirIM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecibirIM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecibirIM.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecibirIM.EnableHeadersVisualStyles = false;
            this.dgvRecibirIM.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvRecibirIM.Location = new System.Drawing.Point(12, 41);
            this.dgvRecibirIM.Name = "dgvRecibirIM";
            this.dgvRecibirIM.ReadOnly = true;
            this.dgvRecibirIM.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRecibirIM.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvRecibirIM.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRecibirIM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecibirIM.Size = new System.Drawing.Size(1084, 505);
            this.dgvRecibirIM.TabIndex = 24;
            this.dgvRecibirIM.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecibirIM_CellDoubleClick);
            // 
            // btActualizarRecibir
            // 
            this.btActualizarRecibir.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btActualizarRecibir.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActualizarRecibir.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btActualizarRecibir.IconColor = System.Drawing.Color.Black;
            this.btActualizarRecibir.IconSize = 16;
            this.btActualizarRecibir.Location = new System.Drawing.Point(12, 12);
            this.btActualizarRecibir.Name = "btActualizarRecibir";
            this.btActualizarRecibir.Rotation = 0D;
            this.btActualizarRecibir.Size = new System.Drawing.Size(88, 23);
            this.btActualizarRecibir.TabIndex = 23;
            this.btActualizarRecibir.Text = "Actualizar";
            this.btActualizarRecibir.UseVisualStyleBackColor = true;
            this.btActualizarRecibir.Click += new System.EventHandler(this.btActualizarRecibir_Click);
            // 
            // tpSolicitarIM
            // 
            this.tpSolicitarIM.BackColor = System.Drawing.Color.MidnightBlue;
            this.tpSolicitarIM.Controls.Add(this.lbCantidadSolicitar);
            this.tpSolicitarIM.Controls.Add(this.btVerCarritoSolicitar);
            this.tpSolicitarIM.Controls.Add(this.btSolicitarCajasIM);
            this.tpSolicitarIM.Controls.Add(this.label1);
            this.tpSolicitarIM.Controls.Add(this.tbCaja);
            this.tpSolicitarIM.Controls.Add(this.tbBusquedaLibre);
            this.tpSolicitarIM.Controls.Add(this.dgvSolicitarIM);
            this.tpSolicitarIM.Controls.Add(this.btBuscarReingreso);
            this.tpSolicitarIM.Controls.Add(this.label2);
            this.tpSolicitarIM.Location = new System.Drawing.Point(4, 31);
            this.tpSolicitarIM.Name = "tpSolicitarIM";
            this.tpSolicitarIM.Padding = new System.Windows.Forms.Padding(3);
            this.tpSolicitarIM.Size = new System.Drawing.Size(1109, 555);
            this.tpSolicitarIM.TabIndex = 1;
            this.tpSolicitarIM.Text = "Solicitar";
            this.tpSolicitarIM.Enter += new System.EventHandler(this.tpSolicitarIM_Enter);
            // 
            // btVerCarritoSolicitar
            // 
            this.btVerCarritoSolicitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btVerCarritoSolicitar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btVerCarritoSolicitar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVerCarritoSolicitar.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.btVerCarritoSolicitar.IconColor = System.Drawing.Color.Black;
            this.btVerCarritoSolicitar.IconSize = 30;
            this.btVerCarritoSolicitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVerCarritoSolicitar.Location = new System.Drawing.Point(876, 10);
            this.btVerCarritoSolicitar.Name = "btVerCarritoSolicitar";
            this.btVerCarritoSolicitar.Rotation = 0D;
            this.btVerCarritoSolicitar.Size = new System.Drawing.Size(51, 30);
            this.btVerCarritoSolicitar.TabIndex = 21;
            this.btVerCarritoSolicitar.UseVisualStyleBackColor = true;
            // 
            // btSolicitarCajasIM
            // 
            this.btSolicitarCajasIM.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btSolicitarCajasIM.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSolicitarCajasIM.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btSolicitarCajasIM.IconColor = System.Drawing.Color.Black;
            this.btSolicitarCajasIM.IconSize = 16;
            this.btSolicitarCajasIM.Location = new System.Drawing.Point(970, 14);
            this.btSolicitarCajasIM.Name = "btSolicitarCajasIM";
            this.btSolicitarCajasIM.Rotation = 0D;
            this.btSolicitarCajasIM.Size = new System.Drawing.Size(131, 23);
            this.btSolicitarCajasIM.TabIndex = 20;
            this.btSolicitarCajasIM.Text = "Solicitar Cajas";
            this.btSolicitarCajasIM.UseVisualStyleBackColor = true;
            this.btSolicitarCajasIM.Click += new System.EventHandler(this.btSolicitarCajasIM_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "Caja:";
            // 
            // tbCaja
            // 
            this.tbCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCaja.Location = new System.Drawing.Point(67, 11);
            this.tbCaja.Name = "tbCaja";
            this.tbCaja.Size = new System.Drawing.Size(177, 24);
            this.tbCaja.TabIndex = 18;
            // 
            // tbBusquedaLibre
            // 
            this.tbBusquedaLibre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBusquedaLibre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusquedaLibre.Location = new System.Drawing.Point(422, 12);
            this.tbBusquedaLibre.Name = "tbBusquedaLibre";
            this.tbBusquedaLibre.Size = new System.Drawing.Size(321, 26);
            this.tbBusquedaLibre.TabIndex = 12;
            // 
            // dgvSolicitarIM
            // 
            this.dgvSolicitarIM.AllowUserToAddRows = false;
            this.dgvSolicitarIM.AllowUserToDeleteRows = false;
            this.dgvSolicitarIM.AllowUserToResizeRows = false;
            this.dgvSolicitarIM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSolicitarIM.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvSolicitarIM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSolicitarIM.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSolicitarIM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSolicitarIM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 14.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSolicitarIM.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSolicitarIM.EnableHeadersVisualStyles = false;
            this.dgvSolicitarIM.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvSolicitarIM.Location = new System.Drawing.Point(6, 47);
            this.dgvSolicitarIM.Name = "dgvSolicitarIM";
            this.dgvSolicitarIM.ReadOnly = true;
            this.dgvSolicitarIM.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSolicitarIM.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvSolicitarIM.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSolicitarIM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSolicitarIM.Size = new System.Drawing.Size(1095, 505);
            this.dgvSolicitarIM.TabIndex = 14;
            this.dgvSolicitarIM.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSolicitarIM_CellDoubleClick);
            // 
            // btBuscarReingreso
            // 
            this.btBuscarReingreso.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btBuscarReingreso.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarReingreso.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btBuscarReingreso.IconColor = System.Drawing.Color.Black;
            this.btBuscarReingreso.IconSize = 16;
            this.btBuscarReingreso.Location = new System.Drawing.Point(760, 14);
            this.btBuscarReingreso.Name = "btBuscarReingreso";
            this.btBuscarReingreso.Rotation = 0D;
            this.btBuscarReingreso.Size = new System.Drawing.Size(88, 23);
            this.btBuscarReingreso.TabIndex = 13;
            this.btBuscarReingreso.Text = "Buscar";
            this.btBuscarReingreso.UseVisualStyleBackColor = true;
            this.btBuscarReingreso.Click += new System.EventHandler(this.btBuscarReingreso_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(267, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 22);
            this.label2.TabIndex = 11;
            this.label2.Text = "Busqueda Libre:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpSolicitarIM);
            this.tabControl1.Controls.Add(this.tpRecibirIM);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 14.25F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1117, 590);
            this.tabControl1.TabIndex = 1;
            // 
            // lbCantidadSolicitar
            // 
            this.lbCantidadSolicitar.AutoSize = true;
            this.lbCantidadSolicitar.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantidadSolicitar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbCantidadSolicitar.Location = new System.Drawing.Point(931, 14);
            this.lbCantidadSolicitar.Name = "lbCantidadSolicitar";
            this.lbCantidadSolicitar.Size = new System.Drawing.Size(33, 22);
            this.lbCantidadSolicitar.TabIndex = 22;
            this.lbCantidadSolicitar.Text = "(0)";
            // 
            // lbCantidadRecibir
            // 
            this.lbCantidadRecibir.AutoSize = true;
            this.lbCantidadRecibir.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantidadRecibir.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbCantidadRecibir.Location = new System.Drawing.Point(916, 12);
            this.lbCantidadRecibir.Name = "lbCantidadRecibir";
            this.lbCantidadRecibir.Size = new System.Drawing.Size(33, 22);
            this.lbCantidadRecibir.TabIndex = 27;
            this.lbCantidadRecibir.Text = "(0)";
            // 
            // btVerCarritoRecibir
            // 
            this.btVerCarritoRecibir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btVerCarritoRecibir.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btVerCarritoRecibir.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVerCarritoRecibir.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.btVerCarritoRecibir.IconColor = System.Drawing.Color.Black;
            this.btVerCarritoRecibir.IconSize = 30;
            this.btVerCarritoRecibir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVerCarritoRecibir.Location = new System.Drawing.Point(861, 8);
            this.btVerCarritoRecibir.Name = "btVerCarritoRecibir";
            this.btVerCarritoRecibir.Rotation = 0D;
            this.btVerCarritoRecibir.Size = new System.Drawing.Size(51, 30);
            this.btVerCarritoRecibir.TabIndex = 26;
            this.btVerCarritoRecibir.UseVisualStyleBackColor = true;
            // 
            // btRecibirCajas
            // 
            this.btRecibirCajas.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btRecibirCajas.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRecibirCajas.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btRecibirCajas.IconColor = System.Drawing.Color.Black;
            this.btRecibirCajas.IconSize = 16;
            this.btRecibirCajas.Location = new System.Drawing.Point(955, 12);
            this.btRecibirCajas.Name = "btRecibirCajas";
            this.btRecibirCajas.Rotation = 0D;
            this.btRecibirCajas.Size = new System.Drawing.Size(131, 23);
            this.btRecibirCajas.TabIndex = 25;
            this.btRecibirCajas.Text = "Recibir Cajas";
            this.btRecibirCajas.UseVisualStyleBackColor = true;
            this.btRecibirCajas.Click += new System.EventHandler(this.btRecibirCajas_Click);
            // 
            // IronMountainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1117, 590);
            this.Controls.Add(this.tabControl1);
            this.Name = "IronMountainForm";
            this.Text = "IronMountainForm";
            this.tpRecibirIM.ResumeLayout(false);
            this.tpRecibirIM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecibirIM)).EndInit();
            this.tpSolicitarIM.ResumeLayout(false);
            this.tpSolicitarIM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitarIM)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tpRecibirIM;
        private System.Windows.Forms.DataGridView dgvRecibirIM;
        private FontAwesome.Sharp.IconButton btActualizarRecibir;
        private System.Windows.Forms.TabPage tpSolicitarIM;
        private FontAwesome.Sharp.IconButton btSolicitarCajasIM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCaja;
        private System.Windows.Forms.TextBox tbBusquedaLibre;
        private System.Windows.Forms.DataGridView dgvSolicitarIM;
        private FontAwesome.Sharp.IconButton btBuscarReingreso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private FontAwesome.Sharp.IconButton btVerCarritoSolicitar;
        private System.Windows.Forms.Label lbCantidadSolicitar;
        private System.Windows.Forms.Label lbCantidadRecibir;
        private FontAwesome.Sharp.IconButton btVerCarritoRecibir;
        private FontAwesome.Sharp.IconButton btRecibirCajas;
    }
}