namespace SICA
{
    partial class RecibirForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpCustodiar = new System.Windows.Forms.TabPage();
            this.btCargarValido = new System.Windows.Forms.Button();
            this.btBuscarCargo = new System.Windows.Forms.Button();
            this.dgvCargo = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tpCustodiar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpCustodiar);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 14.25F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1259, 583);
            this.tabControl1.TabIndex = 0;
            // 
            // tpCustodiar
            // 
            this.tpCustodiar.BackColor = System.Drawing.Color.MidnightBlue;
            this.tpCustodiar.Controls.Add(this.btCargarValido);
            this.tpCustodiar.Controls.Add(this.btBuscarCargo);
            this.tpCustodiar.Controls.Add(this.dgvCargo);
            this.tpCustodiar.Location = new System.Drawing.Point(4, 31);
            this.tpCustodiar.Name = "tpCustodiar";
            this.tpCustodiar.Padding = new System.Windows.Forms.Padding(3);
            this.tpCustodiar.Size = new System.Drawing.Size(1251, 548);
            this.tpCustodiar.TabIndex = 0;
            this.tpCustodiar.Text = "Custodiar";
            // 
            // btCargarValido
            // 
            this.btCargarValido.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCargarValido.Location = new System.Drawing.Point(244, 9);
            this.btCargarValido.Name = "btCargarValido";
            this.btCargarValido.Size = new System.Drawing.Size(212, 33);
            this.btCargarValido.TabIndex = 13;
            this.btCargarValido.Text = "Cargar Información Valida";
            this.btCargarValido.UseVisualStyleBackColor = true;
            this.btCargarValido.Visible = false;
            this.btCargarValido.Click += new System.EventHandler(this.btCargarValido_Click);
            // 
            // btBuscarCargo
            // 
            this.btBuscarCargo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarCargo.Location = new System.Drawing.Point(8, 9);
            this.btBuscarCargo.Name = "btBuscarCargo";
            this.btBuscarCargo.Size = new System.Drawing.Size(230, 33);
            this.btBuscarCargo.TabIndex = 12;
            this.btBuscarCargo.Text = "Buscar Cargo .xlsx";
            this.btBuscarCargo.UseVisualStyleBackColor = true;
            this.btBuscarCargo.Click += new System.EventHandler(this.btBuscarCargo_Click);
            // 
            // dgvCargo
            // 
            this.dgvCargo.AllowUserToAddRows = false;
            this.dgvCargo.AllowUserToDeleteRows = false;
            this.dgvCargo.AllowUserToResizeRows = false;
            this.dgvCargo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCargo.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvCargo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCargo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCargo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 14.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCargo.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCargo.EnableHeadersVisualStyles = false;
            this.dgvCargo.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvCargo.Location = new System.Drawing.Point(8, 48);
            this.dgvCargo.Name = "dgvCargo";
            this.dgvCargo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCargo.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCargo.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCargo.Size = new System.Drawing.Size(1235, 492);
            this.dgvCargo.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.MidnightBlue;
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1251, 548);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "En Transito";
            // 
            // RecibirForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1259, 583);
            this.Controls.Add(this.tabControl1);
            this.Name = "RecibirForm";
            this.Text = "CustodiarForm";
            this.tabControl1.ResumeLayout(false);
            this.tpCustodiar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpCustodiar;
        private System.Windows.Forms.Button btCargarValido;
        private System.Windows.Forms.Button btBuscarCargo;
        private System.Windows.Forms.DataGridView dgvCargo;
        private System.Windows.Forms.TabPage tabPage2;
    }
}