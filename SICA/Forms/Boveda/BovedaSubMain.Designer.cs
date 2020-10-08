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
            this.btGuardarExp = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btGuardarDoc = new FontAwesome.Sharp.IconButton();
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
            this.pnTop.Controls.Add(this.btGuardarDoc);
            this.pnTop.Controls.Add(this.btRetirar);
            this.pnTop.Controls.Add(this.btGuardarExp);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1048, 45);
            this.pnTop.TabIndex = 2;
            // 
            // btGuardarExp
            // 
            this.btGuardarExp.BackColor = System.Drawing.Color.MidnightBlue;
            this.btGuardarExp.Dock = System.Windows.Forms.DockStyle.Left;
            this.btGuardarExp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btGuardarExp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGuardarExp.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btGuardarExp.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuardarExp.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btGuardarExp.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btGuardarExp.IconColor = System.Drawing.Color.Gainsboro;
            this.btGuardarExp.IconSize = 30;
            this.btGuardarExp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGuardarExp.Location = new System.Drawing.Point(0, 0);
            this.btGuardarExp.Name = "btGuardarExp";
            this.btGuardarExp.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btGuardarExp.Rotation = 0D;
            this.btGuardarExp.Size = new System.Drawing.Size(250, 45);
            this.btGuardarExp.TabIndex = 9;
            this.btGuardarExp.Text = "Guardar Expediente";
            this.btGuardarExp.UseVisualStyleBackColor = false;
            this.btGuardarExp.Click += new System.EventHandler(this.btGuardarCaja_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(750, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 1);
            this.panel1.TabIndex = 8;
            // 
            // btGuardarDoc
            // 
            this.btGuardarDoc.BackColor = System.Drawing.Color.MidnightBlue;
            this.btGuardarDoc.Dock = System.Windows.Forms.DockStyle.Left;
            this.btGuardarDoc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btGuardarDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGuardarDoc.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btGuardarDoc.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuardarDoc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btGuardarDoc.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btGuardarDoc.IconColor = System.Drawing.Color.Gainsboro;
            this.btGuardarDoc.IconSize = 30;
            this.btGuardarDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGuardarDoc.Location = new System.Drawing.Point(500, 0);
            this.btGuardarDoc.Name = "btGuardarDoc";
            this.btGuardarDoc.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btGuardarDoc.Rotation = 0D;
            this.btGuardarDoc.Size = new System.Drawing.Size(250, 45);
            this.btGuardarDoc.TabIndex = 5;
            this.btGuardarDoc.Text = "Guardar Documento";
            this.btGuardarDoc.UseVisualStyleBackColor = false;
            this.btGuardarDoc.Click += new System.EventHandler(this.btGuardarDoc_Click);
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
            this.btRetirar.Location = new System.Drawing.Point(250, 0);
            this.btRetirar.Name = "btRetirar";
            this.btRetirar.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btRetirar.Rotation = 0D;
            this.btRetirar.Size = new System.Drawing.Size(250, 45);
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
        private FontAwesome.Sharp.IconButton btGuardarDoc;
        private FontAwesome.Sharp.IconButton btRetirar;
        private FontAwesome.Sharp.IconButton btGuardarExp;
    }
}