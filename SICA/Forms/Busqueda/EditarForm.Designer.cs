
namespace SICA.Forms.Busqueda
{
    partial class EditarForm
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
            this.cbFechaDesde = new System.Windows.Forms.CheckBox();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCaja = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFechaHasta = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.tbDescripcion1 = new System.Windows.Forms.TextBox();
            this.tbDescripcion2 = new System.Windows.Forms.TextBox();
            this.tbDescripcion3 = new System.Windows.Forms.TextBox();
            this.tbDescripcion4 = new System.Windows.Forms.TextBox();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.cmbDocumento = new System.Windows.Forms.ComboBox();
            this.btGuardar = new System.Windows.Forms.Button();
            this.tbDescripcion5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbFechaDesde
            // 
            this.cbFechaDesde.AutoSize = true;
            this.cbFechaDesde.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFechaDesde.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbFechaDesde.Location = new System.Drawing.Point(31, 114);
            this.cbFechaDesde.Name = "cbFechaDesde";
            this.cbFechaDesde.Size = new System.Drawing.Size(149, 26);
            this.cbFechaDesde.TabIndex = 22;
            this.cbFechaDesde.Text = "Fecha Desde:";
            this.cbFechaDesde.UseVisualStyleBackColor = true;
            this.cbFechaDesde.CheckedChanged += new System.EventHandler(this.cbFechaDesde_CheckedChanged);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaDesde.Enabled = false;
            this.dtpFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaDesde.Location = new System.Drawing.Point(229, 116);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(119, 24);
            this.dtpFechaDesde.TabIndex = 21;
            this.dtpFechaDesde.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(27, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 22);
            this.label1.TabIndex = 20;
            this.label1.Text = "Caja:";
            // 
            // tbCaja
            // 
            this.tbCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCaja.Location = new System.Drawing.Point(229, 22);
            this.tbCaja.Name = "tbCaja";
            this.tbCaja.Size = new System.Drawing.Size(188, 24);
            this.tbCaja.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(28, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 22);
            this.label2.TabIndex = 24;
            this.label2.Text = "Cod. Departamento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(27, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 22);
            this.label3.TabIndex = 26;
            this.label3.Text = "Cod. Documento:";
            // 
            // cbFechaHasta
            // 
            this.cbFechaHasta.AutoSize = true;
            this.cbFechaHasta.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFechaHasta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbFechaHasta.Location = new System.Drawing.Point(31, 144);
            this.cbFechaHasta.Name = "cbFechaHasta";
            this.cbFechaHasta.Size = new System.Drawing.Size(140, 26);
            this.cbFechaHasta.TabIndex = 27;
            this.cbFechaHasta.Text = "Fecha Hasta:";
            this.cbFechaHasta.UseVisualStyleBackColor = true;
            this.cbFechaHasta.CheckedChanged += new System.EventHandler(this.cbFechaHasta_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(28, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 22);
            this.label4.TabIndex = 28;
            this.label4.Text = "Descripcion 1:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(28, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 22);
            this.label5.TabIndex = 29;
            this.label5.Text = "Descripcion 2:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(28, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 22);
            this.label6.TabIndex = 30;
            this.label6.Text = "Descripcion 3:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(28, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 22);
            this.label7.TabIndex = 31;
            this.label7.Text = "Descripcion 4:";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaHasta.Enabled = false;
            this.dtpFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaHasta.Location = new System.Drawing.Point(229, 146);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(119, 24);
            this.dtpFechaHasta.TabIndex = 32;
            this.dtpFechaHasta.Visible = false;
            // 
            // tbDescripcion1
            // 
            this.tbDescripcion1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescripcion1.Location = new System.Drawing.Point(229, 176);
            this.tbDescripcion1.Name = "tbDescripcion1";
            this.tbDescripcion1.Size = new System.Drawing.Size(397, 24);
            this.tbDescripcion1.TabIndex = 33;
            // 
            // tbDescripcion2
            // 
            this.tbDescripcion2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescripcion2.Location = new System.Drawing.Point(229, 206);
            this.tbDescripcion2.Name = "tbDescripcion2";
            this.tbDescripcion2.Size = new System.Drawing.Size(397, 24);
            this.tbDescripcion2.TabIndex = 34;
            // 
            // tbDescripcion3
            // 
            this.tbDescripcion3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescripcion3.Location = new System.Drawing.Point(229, 236);
            this.tbDescripcion3.Name = "tbDescripcion3";
            this.tbDescripcion3.Size = new System.Drawing.Size(397, 24);
            this.tbDescripcion3.TabIndex = 35;
            // 
            // tbDescripcion4
            // 
            this.tbDescripcion4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescripcion4.Location = new System.Drawing.Point(229, 266);
            this.tbDescripcion4.Name = "tbDescripcion4";
            this.tbDescripcion4.Size = new System.Drawing.Size(397, 24);
            this.tbDescripcion4.TabIndex = 36;
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(229, 52);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(284, 26);
            this.cmbDepartamento.TabIndex = 37;
            // 
            // cmbDocumento
            // 
            this.cmbDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cmbDocumento.FormattingEnabled = true;
            this.cmbDocumento.Location = new System.Drawing.Point(229, 84);
            this.cmbDocumento.Name = "cmbDocumento";
            this.cmbDocumento.Size = new System.Drawing.Size(284, 26);
            this.cmbDocumento.TabIndex = 38;
            // 
            // btGuardar
            // 
            this.btGuardar.Location = new System.Drawing.Point(270, 347);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(114, 35);
            this.btGuardar.TabIndex = 39;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.UseVisualStyleBackColor = true;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // tbDescripcion5
            // 
            this.tbDescripcion5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescripcion5.Location = new System.Drawing.Point(229, 296);
            this.tbDescripcion5.Name = "tbDescripcion5";
            this.tbDescripcion5.Size = new System.Drawing.Size(397, 24);
            this.tbDescripcion5.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(28, 296);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 22);
            this.label8.TabIndex = 40;
            this.label8.Text = "Descripcion 5:";
            // 
            // EditarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(659, 394);
            this.Controls.Add(this.tbDescripcion5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btGuardar);
            this.Controls.Add(this.cmbDocumento);
            this.Controls.Add(this.cmbDepartamento);
            this.Controls.Add(this.tbDescripcion4);
            this.Controls.Add(this.tbDescripcion3);
            this.Controls.Add(this.tbDescripcion2);
            this.Controls.Add(this.tbDescripcion1);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbFechaHasta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFechaDesde);
            this.Controls.Add(this.dtpFechaDesde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCaja);
            this.Name = "EditarForm";
            this.Text = "EditarForm";
            this.Load += new System.EventHandler(this.EditarForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCaja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbFechaHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.TextBox tbDescripcion1;
        private System.Windows.Forms.TextBox tbDescripcion2;
        private System.Windows.Forms.TextBox tbDescripcion3;
        private System.Windows.Forms.TextBox tbDescripcion4;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.ComboBox cmbDocumento;
        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.TextBox tbDescripcion5;
        private System.Windows.Forms.Label label8;
    }
}