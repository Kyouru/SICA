namespace SICA.Forms
{
    partial class HistoricoForm
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
            this.btEditar = new System.Windows.Forms.Button();
            this.pnSubMain = new System.Windows.Forms.Panel();
            this.btMovimiento = new FontAwesome.Sharp.IconButton();
            this.btHistoricoEdicion = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // btEditar
            // 
            this.btEditar.Location = new System.Drawing.Point(985, 1);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(114, 35);
            this.btEditar.TabIndex = 32;
            this.btEditar.Text = "Editar";
            this.btEditar.UseVisualStyleBackColor = true;
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // pnSubMain
            // 
            this.pnSubMain.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnSubMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnSubMain.Location = new System.Drawing.Point(0, 42);
            this.pnSubMain.Name = "pnSubMain";
            this.pnSubMain.Size = new System.Drawing.Size(1111, 563);
            this.pnSubMain.TabIndex = 36;
            // 
            // btMovimiento
            // 
            this.btMovimiento.BackColor = System.Drawing.Color.MidnightBlue;
            this.btMovimiento.Dock = System.Windows.Forms.DockStyle.Left;
            this.btMovimiento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMovimiento.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMovimiento.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btMovimiento.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btMovimiento.IconColor = System.Drawing.Color.Gainsboro;
            this.btMovimiento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btMovimiento.IconSize = 30;
            this.btMovimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMovimiento.Location = new System.Drawing.Point(0, 0);
            this.btMovimiento.Name = "btMovimiento";
            this.btMovimiento.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btMovimiento.Size = new System.Drawing.Size(251, 42);
            this.btMovimiento.TabIndex = 38;
            this.btMovimiento.Text = "Historico Movimientos";
            this.btMovimiento.UseVisualStyleBackColor = false;
            this.btMovimiento.Click += new System.EventHandler(this.btMovimiento_Click);
            // 
            // btHistoricoEdicion
            // 
            this.btHistoricoEdicion.BackColor = System.Drawing.Color.MidnightBlue;
            this.btHistoricoEdicion.Dock = System.Windows.Forms.DockStyle.Left;
            this.btHistoricoEdicion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btHistoricoEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btHistoricoEdicion.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHistoricoEdicion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btHistoricoEdicion.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btHistoricoEdicion.IconColor = System.Drawing.Color.Gainsboro;
            this.btHistoricoEdicion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btHistoricoEdicion.IconSize = 30;
            this.btHistoricoEdicion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btHistoricoEdicion.Location = new System.Drawing.Point(251, 0);
            this.btHistoricoEdicion.Name = "btHistoricoEdicion";
            this.btHistoricoEdicion.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btHistoricoEdicion.Size = new System.Drawing.Size(229, 42);
            this.btHistoricoEdicion.TabIndex = 39;
            this.btHistoricoEdicion.Text = "Historico Edicion";
            this.btHistoricoEdicion.UseVisualStyleBackColor = false;
            this.btHistoricoEdicion.Click += new System.EventHandler(this.btHistoricoEdicion_Click);
            // 
            // HistoricoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1111, 605);
            this.Controls.Add(this.btHistoricoEdicion);
            this.Controls.Add(this.btMovimiento);
            this.Controls.Add(this.pnSubMain);
            this.Controls.Add(this.btEditar);
            this.Name = "HistoricoForm";
            this.Text = "HistoricoForm";
            this.Load += new System.EventHandler(this.HistoricoForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.Panel pnSubMain;
        private FontAwesome.Sharp.IconButton btMovimiento;
        private FontAwesome.Sharp.IconButton btHistoricoEdicion;
    }
}