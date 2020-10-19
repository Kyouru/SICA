namespace SICA.Forms.DocuClass
{
    partial class DocuClassValidar
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
            this.btValidarDatosCSV = new FontAwesome.Sharp.IconButton();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.pnTop = new System.Windows.Forms.Panel();
            this.cmbCaja = new System.Windows.Forms.ComboBox();
            this.btValidarCaja = new FontAwesome.Sharp.IconButton();
            this.btExcel = new FontAwesome.Sharp.IconButton();
            this.pnBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // btValidarDatosCSV
            // 
            this.btValidarDatosCSV.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btValidarDatosCSV.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btValidarDatosCSV.IconColor = System.Drawing.Color.Black;
            this.btValidarDatosCSV.IconSize = 16;
            this.btValidarDatosCSV.Location = new System.Drawing.Point(31, 7);
            this.btValidarDatosCSV.Name = "btValidarDatosCSV";
            this.btValidarDatosCSV.Rotation = 0D;
            this.btValidarDatosCSV.Size = new System.Drawing.Size(150, 34);
            this.btValidarDatosCSV.TabIndex = 0;
            this.btValidarDatosCSV.Text = "Validar Datos .csv";
            this.btValidarDatosCSV.UseVisualStyleBackColor = true;
            this.btValidarDatosCSV.Click += new System.EventHandler(this.btValidarDatosCSV_Click);
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.dgv);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBottom.Location = new System.Drawing.Point(0, 47);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(1048, 561);
            this.pnBottom.TabIndex = 41;
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
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnTop.Controls.Add(this.cmbCaja);
            this.pnTop.Controls.Add(this.btValidarCaja);
            this.pnTop.Controls.Add(this.btValidarDatosCSV);
            this.pnTop.Controls.Add(this.btExcel);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1048, 47);
            this.pnTop.TabIndex = 40;
            // 
            // cmbCaja
            // 
            this.cmbCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCaja.FormattingEnabled = true;
            this.cmbCaja.Location = new System.Drawing.Point(334, 10);
            this.cmbCaja.Name = "cmbCaja";
            this.cmbCaja.Size = new System.Drawing.Size(195, 28);
            this.cmbCaja.TabIndex = 35;
            // 
            // btValidarCaja
            // 
            this.btValidarCaja.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btValidarCaja.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btValidarCaja.IconColor = System.Drawing.Color.Black;
            this.btValidarCaja.IconSize = 16;
            this.btValidarCaja.Location = new System.Drawing.Point(545, 7);
            this.btValidarCaja.Name = "btValidarCaja";
            this.btValidarCaja.Rotation = 0D;
            this.btValidarCaja.Size = new System.Drawing.Size(150, 34);
            this.btValidarCaja.TabIndex = 34;
            this.btValidarCaja.Text = "Validar Caja";
            this.btValidarCaja.UseVisualStyleBackColor = true;
            this.btValidarCaja.Click += new System.EventHandler(this.btValidarCaja_Click);
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
            this.btExcel.Location = new System.Drawing.Point(774, 5);
            this.btExcel.Name = "btExcel";
            this.btExcel.Rotation = 0D;
            this.btExcel.Size = new System.Drawing.Size(48, 38);
            this.btExcel.TabIndex = 33;
            this.btExcel.UseVisualStyleBackColor = true;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // DocuClassValidar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.pnTop);
            this.Name = "DocuClassValidar";
            this.Text = "DocuClassValidar";
            this.Load += new System.EventHandler(this.DocuClassValidar_Load);
            this.pnBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btValidarDatosCSV;
        private System.Windows.Forms.Panel pnBottom;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel pnTop;
        private FontAwesome.Sharp.IconButton btExcel;
        private FontAwesome.Sharp.IconButton btValidarCaja;
        private System.Windows.Forms.ComboBox cmbCaja;
    }
}