namespace SICA.Forms.Recibir
{
    partial class RecibirNuevo
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btBuscarCargo = new FontAwesome.Sharp.IconButton();
            this.btIngresoManual = new FontAwesome.Sharp.IconButton();
            this.btCargarValido = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.dgv.Location = new System.Drawing.Point(0, 53);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1048, 555);
            this.dgv.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btBuscarCargo);
            this.panel1.Controls.Add(this.btIngresoManual);
            this.panel1.Controls.Add(this.btCargarValido);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 53);
            this.panel1.TabIndex = 29;
            // 
            // btBuscarCargo
            // 
            this.btBuscarCargo.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btBuscarCargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscarCargo.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btBuscarCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarCargo.ForeColor = System.Drawing.Color.Gainsboro;
            this.btBuscarCargo.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btBuscarCargo.IconColor = System.Drawing.Color.Black;
            this.btBuscarCargo.IconSize = 16;
            this.btBuscarCargo.Location = new System.Drawing.Point(12, 12);
            this.btBuscarCargo.Name = "btBuscarCargo";
            this.btBuscarCargo.Rotation = 0D;
            this.btBuscarCargo.Size = new System.Drawing.Size(217, 32);
            this.btBuscarCargo.TabIndex = 30;
            this.btBuscarCargo.Text = "Buscar Cargo Nuevo";
            this.btBuscarCargo.UseVisualStyleBackColor = true;
            this.btBuscarCargo.Click += new System.EventHandler(this.btBuscarCargo_Click);
            // 
            // btIngresoManual
            // 
            this.btIngresoManual.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btIngresoManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btIngresoManual.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btIngresoManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIngresoManual.ForeColor = System.Drawing.Color.Gainsboro;
            this.btIngresoManual.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btIngresoManual.IconColor = System.Drawing.Color.Black;
            this.btIngresoManual.IconSize = 16;
            this.btIngresoManual.Location = new System.Drawing.Point(807, 12);
            this.btIngresoManual.Name = "btIngresoManual";
            this.btIngresoManual.Rotation = 0D;
            this.btIngresoManual.Size = new System.Drawing.Size(217, 32);
            this.btIngresoManual.TabIndex = 30;
            this.btIngresoManual.Text = "Ingreso Manual";
            this.btIngresoManual.UseVisualStyleBackColor = true;
            this.btIngresoManual.Click += new System.EventHandler(this.btIngresoManual_Click);
            // 
            // btCargarValido
            // 
            this.btCargarValido.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btCargarValido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCargarValido.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btCargarValido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCargarValido.ForeColor = System.Drawing.Color.Gainsboro;
            this.btCargarValido.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btCargarValido.IconColor = System.Drawing.Color.Black;
            this.btCargarValido.IconSize = 16;
            this.btCargarValido.Location = new System.Drawing.Point(235, 12);
            this.btCargarValido.Name = "btCargarValido";
            this.btCargarValido.Rotation = 0D;
            this.btCargarValido.Size = new System.Drawing.Size(217, 32);
            this.btCargarValido.TabIndex = 28;
            this.btCargarValido.Text = "Cargar Información Valida";
            this.btCargarValido.UseVisualStyleBackColor = true;
            this.btCargarValido.Visible = false;
            this.btCargarValido.Click += new System.EventHandler(this.btCargarValido_Click);
            // 
            // RecibirNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panel1);
            this.Name = "RecibirNuevo";
            this.Text = "RecibirNuevo";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv;
        private FontAwesome.Sharp.IconButton btCargarValido;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btIngresoManual;
        private FontAwesome.Sharp.IconButton btBuscarCargo;
    }
}