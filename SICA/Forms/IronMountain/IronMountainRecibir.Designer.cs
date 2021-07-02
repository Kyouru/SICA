namespace SICA.Forms.IronMountain
{
    partial class IronMountainRecibir
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
            this.pnBottom = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.pnTop = new System.Windows.Forms.Panel();
            this.btLimpiarCarrito = new FontAwesome.Sharp.IconButton();
            this.btVerCarrito = new FontAwesome.Sharp.IconButton();
            this.btSiguiente = new FontAwesome.Sharp.IconButton();
            this.lbCantidad = new System.Windows.Forms.Label();
            this.btExcel = new FontAwesome.Sharp.IconButton();
            this.btActualizar = new FontAwesome.Sharp.IconButton();
            this.pnBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBottom
            // 
            this.pnBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnBottom.Controls.Add(this.dgv);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBottom.Location = new System.Drawing.Point(0, 50);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(1048, 558);
            this.pnBottom.TabIndex = 52;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gainsboro;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1048, 558);
            this.dgv.TabIndex = 25;
            this.dgv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnTop.Controls.Add(this.btLimpiarCarrito);
            this.pnTop.Controls.Add(this.btVerCarrito);
            this.pnTop.Controls.Add(this.btSiguiente);
            this.pnTop.Controls.Add(this.lbCantidad);
            this.pnTop.Controls.Add(this.btExcel);
            this.pnTop.Controls.Add(this.btActualizar);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1048, 50);
            this.pnTop.TabIndex = 51;
            // 
            // btLimpiarCarrito
            // 
            this.btLimpiarCarrito.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btLimpiarCarrito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLimpiarCarrito.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLimpiarCarrito.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btLimpiarCarrito.IconColor = System.Drawing.Color.Gainsboro;
            this.btLimpiarCarrito.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btLimpiarCarrito.IconSize = 30;
            this.btLimpiarCarrito.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btLimpiarCarrito.Location = new System.Drawing.Point(781, 5);
            this.btLimpiarCarrito.Name = "btLimpiarCarrito";
            this.btLimpiarCarrito.Size = new System.Drawing.Size(48, 38);
            this.btLimpiarCarrito.TabIndex = 44;
            this.btLimpiarCarrito.UseVisualStyleBackColor = true;
            this.btLimpiarCarrito.Click += new System.EventHandler(this.btLimpiarCarrito_Click);
            // 
            // btVerCarrito
            // 
            this.btVerCarrito.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btVerCarrito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btVerCarrito.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVerCarrito.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.btVerCarrito.IconColor = System.Drawing.Color.Gainsboro;
            this.btVerCarrito.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btVerCarrito.IconSize = 30;
            this.btVerCarrito.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btVerCarrito.Location = new System.Drawing.Point(662, 5);
            this.btVerCarrito.Name = "btVerCarrito";
            this.btVerCarrito.Size = new System.Drawing.Size(48, 38);
            this.btVerCarrito.TabIndex = 39;
            this.btVerCarrito.UseVisualStyleBackColor = true;
            this.btVerCarrito.Click += new System.EventHandler(this.btVerCarrito_Click);
            // 
            // btSiguiente
            // 
            this.btSiguiente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSiguiente.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSiguiente.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            this.btSiguiente.IconColor = System.Drawing.Color.Gainsboro;
            this.btSiguiente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btSiguiente.IconSize = 30;
            this.btSiguiente.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSiguiente.Location = new System.Drawing.Point(890, 5);
            this.btSiguiente.Name = "btSiguiente";
            this.btSiguiente.Size = new System.Drawing.Size(48, 38);
            this.btSiguiente.TabIndex = 43;
            this.btSiguiente.UseVisualStyleBackColor = true;
            this.btSiguiente.Click += new System.EventHandler(this.btSiguiente_Click);
            // 
            // lbCantidad
            // 
            this.lbCantidad.AutoSize = true;
            this.lbCantidad.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantidad.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbCantidad.Location = new System.Drawing.Point(716, 12);
            this.lbCantidad.Name = "lbCantidad";
            this.lbCantidad.Size = new System.Drawing.Size(33, 22);
            this.lbCantidad.TabIndex = 40;
            this.lbCantidad.Text = "(0)";
            // 
            // btExcel
            // 
            this.btExcel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExcel.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            this.btExcel.IconColor = System.Drawing.Color.Gainsboro;
            this.btExcel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btExcel.IconSize = 30;
            this.btExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btExcel.Location = new System.Drawing.Point(510, 4);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(48, 38);
            this.btExcel.TabIndex = 42;
            this.btExcel.UseVisualStyleBackColor = true;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // btActualizar
            // 
            this.btActualizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btActualizar.IconChar = FontAwesome.Sharp.IconChar.SyncAlt;
            this.btActualizar.IconColor = System.Drawing.Color.Gainsboro;
            this.btActualizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btActualizar.IconSize = 30;
            this.btActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btActualizar.Location = new System.Drawing.Point(456, 4);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(48, 38);
            this.btActualizar.TabIndex = 41;
            this.btActualizar.UseVisualStyleBackColor = true;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // IronMountainRecibir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.pnTop);
            this.Name = "IronMountainRecibir";
            this.Text = "IronMountainRecibir";
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
        private FontAwesome.Sharp.IconButton btVerCarrito;
        private FontAwesome.Sharp.IconButton btSiguiente;
        private System.Windows.Forms.Label lbCantidad;
        private FontAwesome.Sharp.IconButton btExcel;
        private FontAwesome.Sharp.IconButton btActualizar;
    }
}