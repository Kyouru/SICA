namespace SICA.Forms.Entregar
{
    partial class EntregarExpediente
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
            this.lbCantidadEXP = new System.Windows.Forms.Label();
            this.btVerCarritoEXP = new FontAwesome.Sharp.IconButton();
            this.tbBusquedaLibreEXP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvExpedientes = new System.Windows.Forms.DataGridView();
            this.btExcelEXP = new FontAwesome.Sharp.IconButton();
            this.btBuscarEXP = new FontAwesome.Sharp.IconButton();
            this.btEntregarEXP = new FontAwesome.Sharp.IconButton();
            this.btLimpiarCarrito = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpedientes)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCantidadEXP
            // 
            this.lbCantidadEXP.AutoSize = true;
            this.lbCantidadEXP.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantidadEXP.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbCantidadEXP.Location = new System.Drawing.Point(718, 22);
            this.lbCantidadEXP.Name = "lbCantidadEXP";
            this.lbCantidadEXP.Size = new System.Drawing.Size(33, 22);
            this.lbCantidadEXP.TabIndex = 31;
            this.lbCantidadEXP.Text = "(0)";
            // 
            // btVerCarritoEXP
            // 
            this.btVerCarritoEXP.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btVerCarritoEXP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btVerCarritoEXP.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btVerCarritoEXP.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVerCarritoEXP.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.btVerCarritoEXP.IconColor = System.Drawing.Color.Gainsboro;
            this.btVerCarritoEXP.IconSize = 30;
            this.btVerCarritoEXP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVerCarritoEXP.Location = new System.Drawing.Point(664, 15);
            this.btVerCarritoEXP.Name = "btVerCarritoEXP";
            this.btVerCarritoEXP.Rotation = 0D;
            this.btVerCarritoEXP.Size = new System.Drawing.Size(48, 38);
            this.btVerCarritoEXP.TabIndex = 30;
            this.btVerCarritoEXP.UseVisualStyleBackColor = true;
            this.btVerCarritoEXP.Click += new System.EventHandler(this.btVerCarritoEXP_Click);
            // 
            // tbBusquedaLibreEXP
            // 
            this.tbBusquedaLibreEXP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBusquedaLibreEXP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusquedaLibreEXP.Location = new System.Drawing.Point(121, 20);
            this.tbBusquedaLibreEXP.Name = "tbBusquedaLibreEXP";
            this.tbBusquedaLibreEXP.Size = new System.Drawing.Size(321, 24);
            this.tbBusquedaLibreEXP.TabIndex = 27;
            this.tbBusquedaLibreEXP.TextChanged += new System.EventHandler(this.tbBusquedaLibreEXP_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(14, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 22);
            this.label2.TabIndex = 26;
            this.label2.Text = "Busqueda:";
            // 
            // dgvExpedientes
            // 
            this.dgvExpedientes.AllowUserToAddRows = false;
            this.dgvExpedientes.AllowUserToDeleteRows = false;
            this.dgvExpedientes.AllowUserToResizeRows = false;
            this.dgvExpedientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgvExpedientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvExpedientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.dgvExpedientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExpedientes.EnableHeadersVisualStyles = false;
            this.dgvExpedientes.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvExpedientes.Location = new System.Drawing.Point(0, 0);
            this.dgvExpedientes.Name = "dgvExpedientes";
            this.dgvExpedientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvExpedientes.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvExpedientes.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvExpedientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpedientes.Size = new System.Drawing.Size(1048, 540);
            this.dgvExpedientes.TabIndex = 25;
            // 
            // btExcelEXP
            // 
            this.btExcelEXP.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btExcelEXP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExcelEXP.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btExcelEXP.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            this.btExcelEXP.IconColor = System.Drawing.Color.Gainsboro;
            this.btExcelEXP.IconSize = 30;
            this.btExcelEXP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExcelEXP.Location = new System.Drawing.Point(512, 14);
            this.btExcelEXP.Name = "btExcelEXP";
            this.btExcelEXP.Rotation = 0D;
            this.btExcelEXP.Size = new System.Drawing.Size(48, 38);
            this.btExcelEXP.TabIndex = 33;
            this.btExcelEXP.UseVisualStyleBackColor = true;
            this.btExcelEXP.Click += new System.EventHandler(this.btExcelEXP_Click);
            // 
            // btBuscarEXP
            // 
            this.btBuscarEXP.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscarEXP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarEXP.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btBuscarEXP.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btBuscarEXP.IconColor = System.Drawing.Color.Gainsboro;
            this.btBuscarEXP.IconSize = 30;
            this.btBuscarEXP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBuscarEXP.Location = new System.Drawing.Point(458, 14);
            this.btBuscarEXP.Name = "btBuscarEXP";
            this.btBuscarEXP.Rotation = 0D;
            this.btBuscarEXP.Size = new System.Drawing.Size(48, 38);
            this.btBuscarEXP.TabIndex = 32;
            this.btBuscarEXP.UseVisualStyleBackColor = true;
            this.btBuscarEXP.Click += new System.EventHandler(this.btBuscarEXP_Click);
            // 
            // btEntregarEXP
            // 
            this.btEntregarEXP.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btEntregarEXP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEntregarEXP.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btEntregarEXP.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEntregarEXP.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            this.btEntregarEXP.IconColor = System.Drawing.Color.Gainsboro;
            this.btEntregarEXP.IconSize = 30;
            this.btEntregarEXP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEntregarEXP.Location = new System.Drawing.Point(892, 15);
            this.btEntregarEXP.Name = "btEntregarEXP";
            this.btEntregarEXP.Rotation = 0D;
            this.btEntregarEXP.Size = new System.Drawing.Size(48, 38);
            this.btEntregarEXP.TabIndex = 34;
            this.btEntregarEXP.UseVisualStyleBackColor = true;
            this.btEntregarEXP.Click += new System.EventHandler(this.btEntregarEXP_Click);
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
            this.btLimpiarCarrito.Location = new System.Drawing.Point(783, 15);
            this.btLimpiarCarrito.Name = "btLimpiarCarrito";
            this.btLimpiarCarrito.Rotation = 0D;
            this.btLimpiarCarrito.Size = new System.Drawing.Size(48, 38);
            this.btLimpiarCarrito.TabIndex = 35;
            this.btLimpiarCarrito.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.dgvExpedientes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 540);
            this.panel1.TabIndex = 36;
            // 
            // EntregarExpediente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btLimpiarCarrito);
            this.Controls.Add(this.btEntregarEXP);
            this.Controls.Add(this.btExcelEXP);
            this.Controls.Add(this.btBuscarEXP);
            this.Controls.Add(this.lbCantidadEXP);
            this.Controls.Add(this.btVerCarritoEXP);
            this.Controls.Add(this.tbBusquedaLibreEXP);
            this.Controls.Add(this.label2);
            this.Name = "EntregarExpediente";
            this.Text = "EntregarExpediente";
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpedientes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCantidadEXP;
        private FontAwesome.Sharp.IconButton btVerCarritoEXP;
        private System.Windows.Forms.TextBox tbBusquedaLibreEXP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvExpedientes;
        private FontAwesome.Sharp.IconButton btExcelEXP;
        private FontAwesome.Sharp.IconButton btBuscarEXP;
        private FontAwesome.Sharp.IconButton btEntregarEXP;
        private FontAwesome.Sharp.IconButton btLimpiarCarrito;
        private System.Windows.Forms.Panel panel1;
    }
}