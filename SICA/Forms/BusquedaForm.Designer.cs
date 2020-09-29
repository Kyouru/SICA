namespace SICA
{
    partial class BusquedaForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbBusquedaLibre = new System.Windows.Forms.TextBox();
            this.btBuscar = new FontAwesome.Sharp.IconButton();
            this.dgvBusqueda = new System.Windows.Forms.DataGridView();
            this.cbFecha = new System.Windows.Forms.CheckBox();
            this.tbFecha = new System.Windows.Forms.TextBox();
            this.tbCaja = new System.Windows.Forms.TextBox();
            this.cbCaja = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(505, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Busqueda Libre:";
            // 
            // tbBusquedaLibre
            // 
            this.tbBusquedaLibre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBusquedaLibre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusquedaLibre.Location = new System.Drawing.Point(660, 13);
            this.tbBusquedaLibre.Name = "tbBusquedaLibre";
            this.tbBusquedaLibre.Size = new System.Drawing.Size(321, 22);
            this.tbBusquedaLibre.TabIndex = 4;
            this.tbBusquedaLibre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBusquedaLibre_KeyDown);
            // 
            // btBuscar
            // 
            this.btBuscar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btBuscar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btBuscar.IconColor = System.Drawing.Color.Black;
            this.btBuscar.IconSize = 16;
            this.btBuscar.Location = new System.Drawing.Point(1002, 13);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Rotation = 0D;
            this.btBuscar.Size = new System.Drawing.Size(88, 23);
            this.btBuscar.TabIndex = 5;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // dgvBusqueda
            // 
            this.dgvBusqueda.AllowUserToAddRows = false;
            this.dgvBusqueda.AllowUserToDeleteRows = false;
            this.dgvBusqueda.AllowUserToResizeRows = false;
            this.dgvBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBusqueda.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBusqueda.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBusqueda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBusqueda.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBusqueda.EnableHeadersVisualStyles = false;
            this.dgvBusqueda.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvBusqueda.Location = new System.Drawing.Point(12, 43);
            this.dgvBusqueda.Name = "dgvBusqueda";
            this.dgvBusqueda.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBusqueda.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvBusqueda.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBusqueda.Size = new System.Drawing.Size(1091, 550);
            this.dgvBusqueda.TabIndex = 6;
            // 
            // cbFecha
            // 
            this.cbFecha.AutoSize = true;
            this.cbFecha.Font = new System.Drawing.Font("Arial", 14F);
            this.cbFecha.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbFecha.Location = new System.Drawing.Point(278, 11);
            this.cbFecha.Name = "cbFecha";
            this.cbFecha.Size = new System.Drawing.Size(87, 26);
            this.cbFecha.TabIndex = 7;
            this.cbFecha.Text = "Fecha:";
            this.cbFecha.UseVisualStyleBackColor = true;
            this.cbFecha.CheckedChanged += new System.EventHandler(this.cbFecha_CheckedChanged);
            // 
            // tbFecha
            // 
            this.tbFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFecha.Location = new System.Drawing.Point(371, 12);
            this.tbFecha.Name = "tbFecha";
            this.tbFecha.Size = new System.Drawing.Size(105, 24);
            this.tbFecha.TabIndex = 8;
            // 
            // tbCaja
            // 
            this.tbCaja.Enabled = false;
            this.tbCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCaja.Location = new System.Drawing.Point(90, 12);
            this.tbCaja.Name = "tbCaja";
            this.tbCaja.Size = new System.Drawing.Size(162, 24);
            this.tbCaja.TabIndex = 10;
            // 
            // cbCaja
            // 
            this.cbCaja.AutoSize = true;
            this.cbCaja.Font = new System.Drawing.Font("Arial", 14F);
            this.cbCaja.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbCaja.Location = new System.Drawing.Point(12, 11);
            this.cbCaja.Name = "cbCaja";
            this.cbCaja.Size = new System.Drawing.Size(72, 26);
            this.cbCaja.TabIndex = 9;
            this.cbCaja.Text = "Caja:";
            this.cbCaja.UseVisualStyleBackColor = true;
            this.cbCaja.CheckedChanged += new System.EventHandler(this.cbCaja_CheckedChanged);
            // 
            // BusquedaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1111, 605);
            this.Controls.Add(this.tbCaja);
            this.Controls.Add(this.cbCaja);
            this.Controls.Add(this.tbFecha);
            this.Controls.Add(this.cbFecha);
            this.Controls.Add(this.dgvBusqueda);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.tbBusquedaLibre);
            this.Controls.Add(this.label2);
            this.Name = "BusquedaForm";
            this.Text = "BusquedaForm";
            this.Load += new System.EventHandler(this.BusquedaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBusquedaLibre;
        private FontAwesome.Sharp.IconButton btBuscar;
        private System.Windows.Forms.DataGridView dgvBusqueda;
        private System.Windows.Forms.CheckBox cbFecha;
        private System.Windows.Forms.TextBox tbFecha;
        private System.Windows.Forms.TextBox tbCaja;
        private System.Windows.Forms.CheckBox cbCaja;
    }
}