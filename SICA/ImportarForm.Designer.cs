namespace SICA
{
    partial class ImportarForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbDesembolsos = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvDesembolsado = new System.Windows.Forms.DataGridView();
            this.btBuscar = new System.Windows.Forms.Button();
            this.btCargar = new System.Windows.Forms.Button();
            this.btExportar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tbDesembolsos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDesembolsado)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbDesembolsos);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1154, 662);
            this.tabControl1.TabIndex = 0;
            // 
            // tbDesembolsos
            // 
            this.tbDesembolsos.BackColor = System.Drawing.Color.MidnightBlue;
            this.tbDesembolsos.Controls.Add(this.btExportar);
            this.tbDesembolsos.Controls.Add(this.btCargar);
            this.tbDesembolsos.Controls.Add(this.btBuscar);
            this.tbDesembolsos.Controls.Add(this.dgvDesembolsado);
            this.tbDesembolsos.Location = new System.Drawing.Point(4, 31);
            this.tbDesembolsos.Name = "tbDesembolsos";
            this.tbDesembolsos.Padding = new System.Windows.Forms.Padding(3);
            this.tbDesembolsos.Size = new System.Drawing.Size(1146, 627);
            this.tbDesembolsos.TabIndex = 0;
            this.tbDesembolsos.Text = "Expediente Desembolsados";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.MidnightBlue;
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1146, 627);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // dgvDesembolsado
            // 
            this.dgvDesembolsado.AllowUserToAddRows = false;
            this.dgvDesembolsado.AllowUserToDeleteRows = false;
            this.dgvDesembolsado.AllowUserToResizeRows = false;
            this.dgvDesembolsado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDesembolsado.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvDesembolsado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDesembolsado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDesembolsado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDesembolsado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDesembolsado.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDesembolsado.EnableHeadersVisualStyles = false;
            this.dgvDesembolsado.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvDesembolsado.Location = new System.Drawing.Point(8, 45);
            this.dgvDesembolsado.Name = "dgvDesembolsado";
            this.dgvDesembolsado.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDesembolsado.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDesembolsado.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDesembolsado.Size = new System.Drawing.Size(1130, 574);
            this.dgvDesembolsado.TabIndex = 0;
            // 
            // btBuscar
            // 
            this.btBuscar.Location = new System.Drawing.Point(8, 6);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(181, 33);
            this.btBuscar.TabIndex = 1;
            this.btBuscar.Text = "Buscar .csv";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // btCargar
            // 
            this.btCargar.Enabled = false;
            this.btCargar.Location = new System.Drawing.Point(195, 6);
            this.btCargar.Name = "btCargar";
            this.btCargar.Size = new System.Drawing.Size(190, 33);
            this.btCargar.TabIndex = 2;
            this.btCargar.Text = "Cargar Información";
            this.btCargar.UseVisualStyleBackColor = true;
            this.btCargar.Click += new System.EventHandler(this.btCargar_Click);
            // 
            // btExportar
            // 
            this.btExportar.Location = new System.Drawing.Point(486, 6);
            this.btExportar.Name = "btExportar";
            this.btExportar.Size = new System.Drawing.Size(190, 33);
            this.btExportar.TabIndex = 3;
            this.btExportar.Text = "Exportar Excel";
            this.btExportar.UseVisualStyleBackColor = true;
            this.btExportar.Click += new System.EventHandler(this.btExportar_Click);
            // 
            // ImportarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1154, 662);
            this.Controls.Add(this.tabControl1);
            this.Name = "ImportarForm";
            this.Text = "ImportarForm";
            this.tabControl1.ResumeLayout(false);
            this.tbDesembolsos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDesembolsado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbDesembolsos;
        private System.Windows.Forms.Button btExportar;
        private System.Windows.Forms.Button btCargar;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.DataGridView dgvDesembolsado;
        private System.Windows.Forms.TabPage tabPage2;
    }
}