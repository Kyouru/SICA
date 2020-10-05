namespace SICA.Forms.Boveda
{
    partial class BovedaSubMain
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
            this.btGuardar = new FontAwesome.Sharp.IconButton();
            this.btRetirar = new FontAwesome.Sharp.IconButton();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnSubMain
            // 
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
            this.pnTop.Controls.Add(this.btGuardar);
            this.pnTop.Controls.Add(this.btRetirar);
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
            this.panel1.Location = new System.Drawing.Point(280, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 1);
            this.panel1.TabIndex = 8;
            // 
            // btGuardar
            // 
            this.btGuardar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btGuardar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGuardar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btGuardar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuardar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btGuardar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btGuardar.IconColor = System.Drawing.Color.Gainsboro;
            this.btGuardar.IconSize = 30;
            this.btGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGuardar.Location = new System.Drawing.Point(140, 0);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btGuardar.Rotation = 0D;
            this.btGuardar.Size = new System.Drawing.Size(140, 45);
            this.btGuardar.TabIndex = 5;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.UseVisualStyleBackColor = false;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // btRetirar
            // 
            this.btRetirar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btRetirar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btRetirar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btRetirar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRetirar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btRetirar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRetirar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btRetirar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btRetirar.IconColor = System.Drawing.Color.Gainsboro;
            this.btRetirar.IconSize = 30;
            this.btRetirar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRetirar.Location = new System.Drawing.Point(0, 0);
            this.btRetirar.Name = "btRetirar";
            this.btRetirar.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btRetirar.Rotation = 0D;
            this.btRetirar.Size = new System.Drawing.Size(140, 45);
            this.btRetirar.TabIndex = 4;
            this.btRetirar.Text = "Retirar";
            this.btRetirar.UseVisualStyleBackColor = false;
            this.btRetirar.Click += new System.EventHandler(this.btRetirar_Click);
            // 
            // BovedaSubMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.pnSubMain);
            this.Controls.Add(this.pnTop);
            this.Name = "BovedaSubMain";
            this.Text = "BovedaSubMain";
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnSubMain;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btGuardar;
        private FontAwesome.Sharp.IconButton btRetirar;
    }
}