﻿namespace SICA
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBusquedaLibre = new System.Windows.Forms.TextBox();
            this.dgvBusqueda = new System.Windows.Forms.DataGridView();
            this.tbCaja = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btExcel = new FontAwesome.Sharp.IconButton();
            this.btBuscar = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cbFecha = new System.Windows.Forms.CheckBox();
            this.btEdit = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(432, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Busqueda:";
            // 
            // tbBusquedaLibre
            // 
            this.tbBusquedaLibre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBusquedaLibre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusquedaLibre.Location = new System.Drawing.Point(539, 12);
            this.tbBusquedaLibre.Name = "tbBusquedaLibre";
            this.tbBusquedaLibre.Size = new System.Drawing.Size(378, 24);
            this.tbBusquedaLibre.TabIndex = 4;
            this.tbBusquedaLibre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBusquedaLibre_KeyDown);
            // 
            // dgvBusqueda
            // 
            this.dgvBusqueda.AllowUserToAddRows = false;
            this.dgvBusqueda.AllowUserToDeleteRows = false;
            this.dgvBusqueda.AllowUserToResizeRows = false;
            this.dgvBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBusqueda.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgvBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBusqueda.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBusqueda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBusqueda.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBusqueda.EnableHeadersVisualStyles = false;
            this.dgvBusqueda.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvBusqueda.Location = new System.Drawing.Point(12, 46);
            this.dgvBusqueda.Name = "dgvBusqueda";
            this.dgvBusqueda.ReadOnly = true;
            this.dgvBusqueda.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBusqueda.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvBusqueda.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBusqueda.Size = new System.Drawing.Size(1087, 547);
            this.dgvBusqueda.TabIndex = 6;
            this.dgvBusqueda.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusqueda_CellDoubleClick);
            this.dgvBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvBusqueda_KeyDown);
            // 
            // tbCaja
            // 
            this.tbCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCaja.Location = new System.Drawing.Point(71, 12);
            this.tbCaja.Name = "tbCaja";
            this.tbCaja.Size = new System.Drawing.Size(125, 24);
            this.tbCaja.TabIndex = 10;
            this.tbCaja.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBusquedaLibre_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 605);
            this.panel1.TabIndex = 11;
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
            this.btExcel.Location = new System.Drawing.Point(992, 2);
            this.btExcel.Name = "btExcel";
            this.btExcel.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btExcel.Size = new System.Drawing.Size(48, 38);
            this.btExcel.TabIndex = 12;
            this.btExcel.UseVisualStyleBackColor = true;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // btBuscar
            // 
            this.btBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btBuscar.IconColor = System.Drawing.Color.Gainsboro;
            this.btBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btBuscar.IconSize = 30;
            this.btBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btBuscar.Location = new System.Drawing.Point(938, 2);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(48, 38);
            this.btBuscar.TabIndex = 5;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 22);
            this.label1.TabIndex = 13;
            this.label1.Text = "Caja:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(307, 12);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(119, 24);
            this.dtpFecha.TabIndex = 17;
            // 
            // cbFecha
            // 
            this.cbFecha.AutoSize = true;
            this.cbFecha.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFecha.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbFecha.Location = new System.Drawing.Point(214, 11);
            this.cbFecha.Name = "cbFecha";
            this.cbFecha.Size = new System.Drawing.Size(87, 26);
            this.cbFecha.TabIndex = 18;
            this.cbFecha.Text = "Fecha:";
            this.cbFecha.UseVisualStyleBackColor = true;
            this.cbFecha.CheckedChanged += new System.EventHandler(this.cbFecha_CheckedChanged);
            // 
            // btEdit
            // 
            this.btEdit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEdit.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btEdit.IconColor = System.Drawing.Color.Gainsboro;
            this.btEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btEdit.IconSize = 30;
            this.btEdit.Location = new System.Drawing.Point(1046, 2);
            this.btEdit.Name = "btEdit";
            this.btEdit.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btEdit.Size = new System.Drawing.Size(48, 38);
            this.btEdit.TabIndex = 19;
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // BusquedaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1111, 605);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.cbFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btExcel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbCaja);
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
        private System.Windows.Forms.TextBox tbCaja;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.CheckBox cbFecha;
        private FontAwesome.Sharp.IconButton btEdit;
    }
}