namespace SICA.Forms.DocuClass
{
    partial class DocuClassEntregar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.pnTop = new System.Windows.Forms.Panel();
            this.btLimpiarCarrito = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btEntregar = new FontAwesome.Sharp.IconButton();
            this.tbBusquedaLibre = new System.Windows.Forms.TextBox();
            this.btExcel = new FontAwesome.Sharp.IconButton();
            this.btVerCarrito = new FontAwesome.Sharp.IconButton();
            this.btBuscar = new FontAwesome.Sharp.IconButton();
            this.lbCantidad = new System.Windows.Forms.Label();
            this.pnBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.dgv);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBottom.Location = new System.Drawing.Point(0, 47);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(1048, 561);
            this.pnBottom.TabIndex = 39;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gainsboro;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1048, 561);
            this.dgv.TabIndex = 25;
            this.dgv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnTop.Controls.Add(this.btLimpiarCarrito);
            this.pnTop.Controls.Add(this.label2);
            this.pnTop.Controls.Add(this.btEntregar);
            this.pnTop.Controls.Add(this.tbBusquedaLibre);
            this.pnTop.Controls.Add(this.btExcel);
            this.pnTop.Controls.Add(this.btVerCarrito);
            this.pnTop.Controls.Add(this.btBuscar);
            this.pnTop.Controls.Add(this.lbCantidad);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1048, 47);
            this.pnTop.TabIndex = 38;
            // 
            // btLimpiarCarrito
            // 
            this.btLimpiarCarrito.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btLimpiarCarrito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLimpiarCarrito.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btLimpiarCarrito.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLimpiarCarrito.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btLimpiarCarrito.IconColor = System.Drawing.Color.Gainsboro;
            this.btLimpiarCarrito.IconSize = 30;
            this.btLimpiarCarrito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLimpiarCarrito.Location = new System.Drawing.Point(781, 5);
            this.btLimpiarCarrito.Name = "btLimpiarCarrito";
            this.btLimpiarCarrito.Rotation = 0D;
            this.btLimpiarCarrito.Size = new System.Drawing.Size(48, 38);
            this.btLimpiarCarrito.TabIndex = 35;
            this.btLimpiarCarrito.UseVisualStyleBackColor = true;
            this.btLimpiarCarrito.Click += new System.EventHandler(this.btLimpiarCarrito_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 22);
            this.label2.TabIndex = 26;
            this.label2.Text = "Caja:";
            // 
            // btEntregar
            // 
            this.btEntregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btEntregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEntregar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btEntregar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEntregar.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            this.btEntregar.IconColor = System.Drawing.Color.Gainsboro;
            this.btEntregar.IconSize = 30;
            this.btEntregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEntregar.Location = new System.Drawing.Point(890, 5);
            this.btEntregar.Name = "btEntregar";
            this.btEntregar.Rotation = 0D;
            this.btEntregar.Size = new System.Drawing.Size(48, 38);
            this.btEntregar.TabIndex = 34;
            this.btEntregar.UseVisualStyleBackColor = true;
            this.btEntregar.Click += new System.EventHandler(this.btEntregar_Click);
            // 
            // tbBusquedaLibre
            // 
            this.tbBusquedaLibre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBusquedaLibre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusquedaLibre.Location = new System.Drawing.Point(71, 10);
            this.tbBusquedaLibre.Name = "tbBusquedaLibre";
            this.tbBusquedaLibre.Size = new System.Drawing.Size(237, 24);
            this.tbBusquedaLibre.TabIndex = 27;
            this.tbBusquedaLibre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBusquedaLibre_KeyDown);
            // 
            // btExcel
            // 
            this.btExcel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExcel.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btExcel.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            this.btExcel.IconColor = System.Drawing.Color.Gainsboro;
            this.btExcel.IconSize = 30;
            this.btExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExcel.Location = new System.Drawing.Point(382, 5);
            this.btExcel.Name = "btExcel";
            this.btExcel.Rotation = 0D;
            this.btExcel.Size = new System.Drawing.Size(48, 38);
            this.btExcel.TabIndex = 33;
            this.btExcel.UseVisualStyleBackColor = true;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // btVerCarrito
            // 
            this.btVerCarrito.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btVerCarrito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btVerCarrito.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btVerCarrito.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVerCarrito.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.btVerCarrito.IconColor = System.Drawing.Color.Gainsboro;
            this.btVerCarrito.IconSize = 30;
            this.btVerCarrito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVerCarrito.Location = new System.Drawing.Point(662, 5);
            this.btVerCarrito.Name = "btVerCarrito";
            this.btVerCarrito.Rotation = 0D;
            this.btVerCarrito.Size = new System.Drawing.Size(48, 38);
            this.btVerCarrito.TabIndex = 30;
            this.btVerCarrito.UseVisualStyleBackColor = true;
            this.btVerCarrito.Click += new System.EventHandler(this.btVerCarrito_Click);
            // 
            // btBuscar
            // 
            this.btBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btBuscar.IconColor = System.Drawing.Color.Gainsboro;
            this.btBuscar.IconSize = 30;
            this.btBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBuscar.Location = new System.Drawing.Point(328, 5);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Rotation = 0D;
            this.btBuscar.Size = new System.Drawing.Size(48, 38);
            this.btBuscar.TabIndex = 32;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // lbCantidad
            // 
            this.lbCantidad.AutoSize = true;
            this.lbCantidad.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantidad.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbCantidad.Location = new System.Drawing.Point(716, 12);
            this.lbCantidad.Name = "lbCantidad";
            this.lbCantidad.Size = new System.Drawing.Size(33, 22);
            this.lbCantidad.TabIndex = 31;
            this.lbCantidad.Text = "(0)";
            // 
            // DocuClassEntregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.pnTop);
            this.Name = "DocuClassEntregar";
            this.Text = "DocuClassEntregar";
            this.pnBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBottom;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel pnTop;
        private FontAwesome.Sharp.IconButton btLimpiarCarrito;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btEntregar;
        private System.Windows.Forms.TextBox tbBusquedaLibre;
        private FontAwesome.Sharp.IconButton btExcel;
        private FontAwesome.Sharp.IconButton btVerCarrito;
        private FontAwesome.Sharp.IconButton btBuscar;
        private System.Windows.Forms.Label lbCantidad;
    }
}