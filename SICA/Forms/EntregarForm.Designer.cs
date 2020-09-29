namespace SICA.Forms
{
    partial class EntregarForm
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
            this.tcEntregar = new System.Windows.Forms.TabControl();
            this.tbExpedientes = new System.Windows.Forms.TabPage();
            this.btEntregarEXP = new FontAwesome.Sharp.IconButton();
            this.btBuscarEXP = new FontAwesome.Sharp.IconButton();
            this.tbBusquedaLibreEXP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvExpedientes = new System.Windows.Forms.DataGridView();
            this.tpDocumentos = new System.Windows.Forms.TabPage();
            this.dgvDocumentos = new System.Windows.Forms.DataGridView();
            this.tpPagare = new System.Windows.Forms.TabPage();
            this.tpLetras = new System.Windows.Forms.TabPage();
            this.btEntregarDOC = new FontAwesome.Sharp.IconButton();
            this.btBuscarDOC = new FontAwesome.Sharp.IconButton();
            this.tbBusquedaLibreDOC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tcEntregar.SuspendLayout();
            this.tbExpedientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpedientes)).BeginInit();
            this.tpDocumentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).BeginInit();
            this.SuspendLayout();
            // 
            // tcEntregar
            // 
            this.tcEntregar.Controls.Add(this.tbExpedientes);
            this.tcEntregar.Controls.Add(this.tpDocumentos);
            this.tcEntregar.Controls.Add(this.tpPagare);
            this.tcEntregar.Controls.Add(this.tpLetras);
            this.tcEntregar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcEntregar.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcEntregar.Location = new System.Drawing.Point(0, 0);
            this.tcEntregar.Name = "tcEntregar";
            this.tcEntregar.SelectedIndex = 0;
            this.tcEntregar.Size = new System.Drawing.Size(1159, 617);
            this.tcEntregar.TabIndex = 1;
            // 
            // tbExpedientes
            // 
            this.tbExpedientes.BackColor = System.Drawing.Color.MidnightBlue;
            this.tbExpedientes.Controls.Add(this.btEntregarEXP);
            this.tbExpedientes.Controls.Add(this.btBuscarEXP);
            this.tbExpedientes.Controls.Add(this.tbBusquedaLibreEXP);
            this.tbExpedientes.Controls.Add(this.label2);
            this.tbExpedientes.Controls.Add(this.dgvExpedientes);
            this.tbExpedientes.Location = new System.Drawing.Point(4, 31);
            this.tbExpedientes.Name = "tbExpedientes";
            this.tbExpedientes.Padding = new System.Windows.Forms.Padding(3);
            this.tbExpedientes.Size = new System.Drawing.Size(1151, 582);
            this.tbExpedientes.TabIndex = 0;
            this.tbExpedientes.Text = "Expedientes";
            // 
            // btEntregarEXP
            // 
            this.btEntregarEXP.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btEntregarEXP.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEntregarEXP.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btEntregarEXP.IconColor = System.Drawing.Color.Black;
            this.btEntregarEXP.IconSize = 16;
            this.btEntregarEXP.Location = new System.Drawing.Point(804, 11);
            this.btEntregarEXP.Name = "btEntregarEXP";
            this.btEntregarEXP.Rotation = 0D;
            this.btEntregarEXP.Size = new System.Drawing.Size(110, 23);
            this.btEntregarEXP.TabIndex = 9;
            this.btEntregarEXP.Text = "Entregar";
            this.btEntregarEXP.UseVisualStyleBackColor = true;
            this.btEntregarEXP.Click += new System.EventHandler(this.btEntregarEXP_Click);
            // 
            // btBuscarEXP
            // 
            this.btBuscarEXP.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btBuscarEXP.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarEXP.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btBuscarEXP.IconColor = System.Drawing.Color.Black;
            this.btBuscarEXP.IconSize = 16;
            this.btBuscarEXP.Location = new System.Drawing.Point(508, 10);
            this.btBuscarEXP.Name = "btBuscarEXP";
            this.btBuscarEXP.Rotation = 0D;
            this.btBuscarEXP.Size = new System.Drawing.Size(88, 23);
            this.btBuscarEXP.TabIndex = 8;
            this.btBuscarEXP.Text = "Buscar";
            this.btBuscarEXP.UseVisualStyleBackColor = true;
            this.btBuscarEXP.Click += new System.EventHandler(this.btBuscarEXP_Click);
            // 
            // tbBusquedaLibreEXP
            // 
            this.tbBusquedaLibreEXP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBusquedaLibreEXP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusquedaLibreEXP.Location = new System.Drawing.Point(166, 10);
            this.tbBusquedaLibreEXP.Name = "tbBusquedaLibreEXP";
            this.tbBusquedaLibreEXP.Size = new System.Drawing.Size(321, 22);
            this.tbBusquedaLibreEXP.TabIndex = 7;
            this.tbBusquedaLibreEXP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBusquedaLibreEXP_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(11, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Busqueda Libre:";
            // 
            // dgvExpedientes
            // 
            this.dgvExpedientes.AllowUserToAddRows = false;
            this.dgvExpedientes.AllowUserToDeleteRows = false;
            this.dgvExpedientes.AllowUserToResizeRows = false;
            this.dgvExpedientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExpedientes.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvExpedientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvExpedientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.dgvExpedientes.EnableHeadersVisualStyles = false;
            this.dgvExpedientes.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvExpedientes.Location = new System.Drawing.Point(8, 45);
            this.dgvExpedientes.Name = "dgvExpedientes";
            this.dgvExpedientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvExpedientes.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvExpedientes.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvExpedientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpedientes.Size = new System.Drawing.Size(1135, 529);
            this.dgvExpedientes.TabIndex = 0;
            // 
            // tpDocumentos
            // 
            this.tpDocumentos.BackColor = System.Drawing.Color.MidnightBlue;
            this.tpDocumentos.Controls.Add(this.btEntregarDOC);
            this.tpDocumentos.Controls.Add(this.btBuscarDOC);
            this.tpDocumentos.Controls.Add(this.tbBusquedaLibreDOC);
            this.tpDocumentos.Controls.Add(this.label1);
            this.tpDocumentos.Controls.Add(this.dgvDocumentos);
            this.tpDocumentos.Location = new System.Drawing.Point(4, 31);
            this.tpDocumentos.Name = "tpDocumentos";
            this.tpDocumentos.Padding = new System.Windows.Forms.Padding(3);
            this.tpDocumentos.Size = new System.Drawing.Size(1151, 582);
            this.tpDocumentos.TabIndex = 1;
            this.tpDocumentos.Text = "Documentos";
            // 
            // dgvDocumentos
            // 
            this.dgvDocumentos.AllowUserToAddRows = false;
            this.dgvDocumentos.AllowUserToDeleteRows = false;
            this.dgvDocumentos.AllowUserToResizeRows = false;
            this.dgvDocumentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocumentos.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvDocumentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDocumentos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocumentos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocumentos.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDocumentos.EnableHeadersVisualStyles = false;
            this.dgvDocumentos.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvDocumentos.Location = new System.Drawing.Point(8, 46);
            this.dgvDocumentos.Name = "dgvDocumentos";
            this.dgvDocumentos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDocumentos.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDocumentos.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDocumentos.Size = new System.Drawing.Size(1135, 529);
            this.dgvDocumentos.TabIndex = 4;
            // 
            // tpPagare
            // 
            this.tpPagare.BackColor = System.Drawing.Color.MidnightBlue;
            this.tpPagare.Location = new System.Drawing.Point(4, 31);
            this.tpPagare.Name = "tpPagare";
            this.tpPagare.Padding = new System.Windows.Forms.Padding(3);
            this.tpPagare.Size = new System.Drawing.Size(1151, 582);
            this.tpPagare.TabIndex = 2;
            this.tpPagare.Text = "Pagares";
            // 
            // tpLetras
            // 
            this.tpLetras.BackColor = System.Drawing.Color.MidnightBlue;
            this.tpLetras.Location = new System.Drawing.Point(4, 31);
            this.tpLetras.Name = "tpLetras";
            this.tpLetras.Padding = new System.Windows.Forms.Padding(3);
            this.tpLetras.Size = new System.Drawing.Size(1151, 582);
            this.tpLetras.TabIndex = 3;
            this.tpLetras.Text = "Letras";
            // 
            // btEntregarDOC
            // 
            this.btEntregarDOC.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btEntregarDOC.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEntregarDOC.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btEntregarDOC.IconColor = System.Drawing.Color.Black;
            this.btEntregarDOC.IconSize = 16;
            this.btEntregarDOC.Location = new System.Drawing.Point(806, 11);
            this.btEntregarDOC.Name = "btEntregarDOC";
            this.btEntregarDOC.Rotation = 0D;
            this.btEntregarDOC.Size = new System.Drawing.Size(110, 24);
            this.btEntregarDOC.TabIndex = 13;
            this.btEntregarDOC.Text = "Entregar";
            this.btEntregarDOC.UseVisualStyleBackColor = true;
            this.btEntregarDOC.Click += new System.EventHandler(this.btEntregarDOC_Click);
            // 
            // btBuscarDOC
            // 
            this.btBuscarDOC.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btBuscarDOC.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscarDOC.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btBuscarDOC.IconColor = System.Drawing.Color.Black;
            this.btBuscarDOC.IconSize = 16;
            this.btBuscarDOC.Location = new System.Drawing.Point(510, 11);
            this.btBuscarDOC.Name = "btBuscarDOC";
            this.btBuscarDOC.Rotation = 0D;
            this.btBuscarDOC.Size = new System.Drawing.Size(88, 23);
            this.btBuscarDOC.TabIndex = 12;
            this.btBuscarDOC.Text = "Buscar";
            this.btBuscarDOC.UseVisualStyleBackColor = true;
            this.btBuscarDOC.Click += new System.EventHandler(this.btBuscarDOC_Click);
            // 
            // tbBusquedaLibreDOC
            // 
            this.tbBusquedaLibreDOC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBusquedaLibreDOC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusquedaLibreDOC.Location = new System.Drawing.Point(168, 11);
            this.tbBusquedaLibreDOC.Name = "tbBusquedaLibreDOC";
            this.tbBusquedaLibreDOC.Size = new System.Drawing.Size(321, 22);
            this.tbBusquedaLibreDOC.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Busqueda Libre:";
            // 
            // EntregarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1159, 617);
            this.Controls.Add(this.tcEntregar);
            this.Name = "EntregarForm";
            this.Text = "EntregarForm";
            this.tcEntregar.ResumeLayout(false);
            this.tbExpedientes.ResumeLayout(false);
            this.tbExpedientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpedientes)).EndInit();
            this.tpDocumentos.ResumeLayout(false);
            this.tpDocumentos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcEntregar;
        private System.Windows.Forms.TabPage tbExpedientes;
        private System.Windows.Forms.DataGridView dgvExpedientes;
        private System.Windows.Forms.TabPage tpDocumentos;
        private System.Windows.Forms.DataGridView dgvDocumentos;
        private System.Windows.Forms.TabPage tpPagare;
        private System.Windows.Forms.TabPage tpLetras;
        private FontAwesome.Sharp.IconButton btBuscarEXP;
        private System.Windows.Forms.TextBox tbBusquedaLibreEXP;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btEntregarEXP;
        private FontAwesome.Sharp.IconButton btEntregarDOC;
        private FontAwesome.Sharp.IconButton btBuscarDOC;
        private System.Windows.Forms.TextBox tbBusquedaLibreDOC;
        private System.Windows.Forms.Label label1;
    }
}