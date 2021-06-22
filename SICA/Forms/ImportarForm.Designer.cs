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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbDesembolsos = new System.Windows.Forms.TabPage();
            this.btCargarVigentes = new System.Windows.Forms.Button();
            this.btBuscarVigentes = new System.Windows.Forms.Button();
            this.dgvDesembolsado = new System.Windows.Forms.DataGridView();
            this.tpCancelados = new System.Windows.Forms.TabPage();
            this.btActualizarCancelados = new System.Windows.Forms.Button();
            this.btCargarCancelados = new System.Windows.Forms.Button();
            this.btBuscarCancelados = new System.Windows.Forms.Button();
            this.dgvCancelados = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tbDesembolsos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDesembolsado)).BeginInit();
            this.tpCancelados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCancelados)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbDesembolsos);
            this.tabControl1.Controls.Add(this.tpCancelados);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1226, 659);
            this.tabControl1.TabIndex = 0;
            // 
            // tbDesembolsos
            // 
            this.tbDesembolsos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tbDesembolsos.Controls.Add(this.btCargarVigentes);
            this.tbDesembolsos.Controls.Add(this.btBuscarVigentes);
            this.tbDesembolsos.Controls.Add(this.dgvDesembolsado);
            this.tbDesembolsos.Location = new System.Drawing.Point(4, 31);
            this.tbDesembolsos.Name = "tbDesembolsos";
            this.tbDesembolsos.Padding = new System.Windows.Forms.Padding(3);
            this.tbDesembolsos.Size = new System.Drawing.Size(1218, 624);
            this.tbDesembolsos.TabIndex = 0;
            this.tbDesembolsos.Text = "Expediente Desembolsados";
            // 
            // btCargarVigentes
            // 
            this.btCargarVigentes.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCargarVigentes.Location = new System.Drawing.Point(244, 6);
            this.btCargarVigentes.Name = "btCargarVigentes";
            this.btCargarVigentes.Size = new System.Drawing.Size(190, 33);
            this.btCargarVigentes.TabIndex = 2;
            this.btCargarVigentes.Text = "Cargar Información";
            this.btCargarVigentes.UseVisualStyleBackColor = true;
            this.btCargarVigentes.Visible = false;
            this.btCargarVigentes.Click += new System.EventHandler(this.btCargarVigentes_Click);
            // 
            // btBuscarVigentes
            // 
            this.btBuscarVigentes.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarVigentes.Location = new System.Drawing.Point(8, 6);
            this.btBuscarVigentes.Name = "btBuscarVigentes";
            this.btBuscarVigentes.Size = new System.Drawing.Size(230, 33);
            this.btBuscarVigentes.TabIndex = 1;
            this.btBuscarVigentes.Text = "Buscar Vigentes .csv";
            this.btBuscarVigentes.UseVisualStyleBackColor = true;
            this.btBuscarVigentes.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // dgvDesembolsado
            // 
            this.dgvDesembolsado.AllowUserToAddRows = false;
            this.dgvDesembolsado.AllowUserToDeleteRows = false;
            this.dgvDesembolsado.AllowUserToResizeRows = false;
            this.dgvDesembolsado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDesembolsado.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgvDesembolsado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDesembolsado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.dgvDesembolsado.Size = new System.Drawing.Size(1202, 571);
            this.dgvDesembolsado.TabIndex = 0;
            // 
            // tpCancelados
            // 
            this.tpCancelados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tpCancelados.Controls.Add(this.btActualizarCancelados);
            this.tpCancelados.Controls.Add(this.btCargarCancelados);
            this.tpCancelados.Controls.Add(this.btBuscarCancelados);
            this.tpCancelados.Controls.Add(this.dgvCancelados);
            this.tpCancelados.Location = new System.Drawing.Point(4, 31);
            this.tpCancelados.Name = "tpCancelados";
            this.tpCancelados.Padding = new System.Windows.Forms.Padding(3);
            this.tpCancelados.Size = new System.Drawing.Size(1218, 624);
            this.tpCancelados.TabIndex = 1;
            this.tpCancelados.Text = "Actualizar Cancelados";
            // 
            // btActualizarCancelados
            // 
            this.btActualizarCancelados.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActualizarCancelados.Location = new System.Drawing.Point(269, 7);
            this.btActualizarCancelados.Name = "btActualizarCancelados";
            this.btActualizarCancelados.Size = new System.Drawing.Size(238, 33);
            this.btActualizarCancelados.TabIndex = 8;
            this.btActualizarCancelados.Text = "Actualizar Información";
            this.btActualizarCancelados.UseVisualStyleBackColor = true;
            this.btActualizarCancelados.Visible = false;
            this.btActualizarCancelados.Click += new System.EventHandler(this.btActualizarCancelados_Click);
            // 
            // btCargarCancelados
            // 
            this.btCargarCancelados.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCargarCancelados.Location = new System.Drawing.Point(513, 7);
            this.btCargarCancelados.Name = "btCargarCancelados";
            this.btCargarCancelados.Size = new System.Drawing.Size(190, 33);
            this.btCargarCancelados.TabIndex = 6;
            this.btCargarCancelados.Text = "Cargar Información";
            this.btCargarCancelados.UseVisualStyleBackColor = true;
            this.btCargarCancelados.Visible = false;
            this.btCargarCancelados.Click += new System.EventHandler(this.btCargarCancelados_Click);
            // 
            // btBuscarCancelados
            // 
            this.btBuscarCancelados.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarCancelados.Location = new System.Drawing.Point(8, 7);
            this.btBuscarCancelados.Name = "btBuscarCancelados";
            this.btBuscarCancelados.Size = new System.Drawing.Size(255, 33);
            this.btBuscarCancelados.TabIndex = 5;
            this.btBuscarCancelados.Text = "Buscar Cancelados .csv";
            this.btBuscarCancelados.UseVisualStyleBackColor = true;
            this.btBuscarCancelados.Click += new System.EventHandler(this.btBuscarCancelados_Click);
            // 
            // dgvCancelados
            // 
            this.dgvCancelados.AllowUserToAddRows = false;
            this.dgvCancelados.AllowUserToDeleteRows = false;
            this.dgvCancelados.AllowUserToResizeRows = false;
            this.dgvCancelados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCancelados.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgvCancelados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCancelados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCancelados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCancelados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCancelados.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCancelados.EnableHeadersVisualStyles = false;
            this.dgvCancelados.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvCancelados.Location = new System.Drawing.Point(8, 46);
            this.dgvCancelados.Name = "dgvCancelados";
            this.dgvCancelados.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCancelados.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCancelados.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCancelados.Size = new System.Drawing.Size(1202, 571);
            this.dgvCancelados.TabIndex = 4;
            // 
            // ImportarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1226, 659);
            this.Controls.Add(this.tabControl1);
            this.Name = "ImportarForm";
            this.Text = "ImportarForm";
            this.tabControl1.ResumeLayout(false);
            this.tbDesembolsos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDesembolsado)).EndInit();
            this.tpCancelados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCancelados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbDesembolsos;
        private System.Windows.Forms.Button btCargarVigentes;
        private System.Windows.Forms.Button btBuscarVigentes;
        private System.Windows.Forms.DataGridView dgvDesembolsado;
        private System.Windows.Forms.TabPage tpCancelados;
        private System.Windows.Forms.Button btCargarCancelados;
        private System.Windows.Forms.Button btBuscarCancelados;
        private System.Windows.Forms.DataGridView dgvCancelados;
        private System.Windows.Forms.Button btActualizarCancelados;
    }
}