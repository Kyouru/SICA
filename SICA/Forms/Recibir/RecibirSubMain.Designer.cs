namespace SICA.Forms.Recibir
{
    partial class RecibirSubMain
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
            this.pnSubMain = new System.Windows.Forms.Panel();
            this.pnTop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btConfirmar = new FontAwesome.Sharp.IconButton();
            this.btReingreso = new FontAwesome.Sharp.IconButton();
            this.btNuevo = new FontAwesome.Sharp.IconButton();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnSubMain
            // 
            this.pnSubMain.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnSubMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSubMain.Location = new System.Drawing.Point(0, 45);
            this.pnSubMain.Name = "pnSubMain";
            this.pnSubMain.Size = new System.Drawing.Size(1048, 563);
            this.pnSubMain.TabIndex = 3;
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnTop.Controls.Add(this.panel1);
            this.pnTop.Controls.Add(this.btConfirmar);
            this.pnTop.Controls.Add(this.btReingreso);
            this.pnTop.Controls.Add(this.btNuevo);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1048, 45);
            this.pnTop.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(420, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 1);
            this.panel1.TabIndex = 8;
            // 
            // btConfirmar
            // 
            this.btConfirmar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btConfirmar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConfirmar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfirmar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btConfirmar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btConfirmar.IconColor = System.Drawing.Color.Gainsboro;
            this.btConfirmar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btConfirmar.IconSize = 30;
            this.btConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btConfirmar.Location = new System.Drawing.Point(280, 0);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btConfirmar.Size = new System.Drawing.Size(140, 45);
            this.btConfirmar.TabIndex = 9;
            this.btConfirmar.Text = "Confirmar";
            this.btConfirmar.UseVisualStyleBackColor = false;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            // 
            // btReingreso
            // 
            this.btReingreso.BackColor = System.Drawing.Color.MidnightBlue;
            this.btReingreso.Dock = System.Windows.Forms.DockStyle.Left;
            this.btReingreso.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btReingreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btReingreso.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReingreso.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btReingreso.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btReingreso.IconColor = System.Drawing.Color.Gainsboro;
            this.btReingreso.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btReingreso.IconSize = 30;
            this.btReingreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btReingreso.Location = new System.Drawing.Point(140, 0);
            this.btReingreso.Name = "btReingreso";
            this.btReingreso.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btReingreso.Size = new System.Drawing.Size(140, 45);
            this.btReingreso.TabIndex = 5;
            this.btReingreso.Text = "Reingreso";
            this.btReingreso.UseVisualStyleBackColor = false;
            this.btReingreso.Click += new System.EventHandler(this.btReingreso_Click);
            // 
            // btNuevo
            // 
            this.btNuevo.BackColor = System.Drawing.Color.MidnightBlue;
            this.btNuevo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNuevo.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNuevo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btNuevo.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btNuevo.IconColor = System.Drawing.Color.Gainsboro;
            this.btNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btNuevo.IconSize = 30;
            this.btNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNuevo.Location = new System.Drawing.Point(0, 0);
            this.btNuevo.Name = "btNuevo";
            this.btNuevo.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btNuevo.Size = new System.Drawing.Size(140, 45);
            this.btNuevo.TabIndex = 4;
            this.btNuevo.Text = "Nuevo";
            this.btNuevo.UseVisualStyleBackColor = false;
            this.btNuevo.Click += new System.EventHandler(this.btNuevo_Click);
            // 
            // RecibirSubMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.pnSubMain);
            this.Controls.Add(this.pnTop);
            this.Name = "RecibirSubMain";
            this.Text = "RecibirSubMain";
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnSubMain;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btReingreso;
        private FontAwesome.Sharp.IconButton btNuevo;
        private FontAwesome.Sharp.IconButton btConfirmar;
    }
}