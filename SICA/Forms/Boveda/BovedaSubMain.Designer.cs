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
            this.btGuardarCaja = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btGuardarDoc = new FontAwesome.Sharp.IconButton();
            this.btRetirarDoc = new FontAwesome.Sharp.IconButton();
            this.btRetirarCaja = new FontAwesome.Sharp.IconButton();
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
            this.pnTop.Controls.Add(this.btGuardarCaja);
            this.pnTop.Controls.Add(this.btRetirarCaja);
            this.pnTop.Controls.Add(this.btGuardarDoc);
            this.pnTop.Controls.Add(this.btRetirarDoc);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1048, 45);
            this.pnTop.TabIndex = 2;
            // 
            // btGuardarCaja
            // 
            this.btGuardarCaja.BackColor = System.Drawing.Color.MidnightBlue;
            this.btGuardarCaja.Dock = System.Windows.Forms.DockStyle.Left;
            this.btGuardarCaja.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btGuardarCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGuardarCaja.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btGuardarCaja.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuardarCaja.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btGuardarCaja.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btGuardarCaja.IconColor = System.Drawing.Color.Gainsboro;
            this.btGuardarCaja.IconSize = 30;
            this.btGuardarCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGuardarCaja.Location = new System.Drawing.Point(750, 0);
            this.btGuardarCaja.Name = "btGuardarCaja";
            this.btGuardarCaja.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btGuardarCaja.Rotation = 0D;
            this.btGuardarCaja.Size = new System.Drawing.Size(250, 45);
            this.btGuardarCaja.TabIndex = 9;
            this.btGuardarCaja.Text = "Guardar Caja";
            this.btGuardarCaja.UseVisualStyleBackColor = false;
            this.btGuardarCaja.Click += new System.EventHandler(this.btGuardarCaja_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(1000, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(48, 1);
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
            this.btGuardarDoc.Location = new System.Drawing.Point(250, 0);
            this.btGuardarDoc.Name = "btGuardarDoc";
            this.btGuardarDoc.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btGuardarDoc.Rotation = 0D;
            this.btGuardarDoc.Size = new System.Drawing.Size(250, 45);
            this.btGuardarDoc.TabIndex = 5;
            this.btGuardarDoc.Text = "Guardar Documento";
            this.btGuardarDoc.UseVisualStyleBackColor = false;
            this.btGuardarDoc.Click += new System.EventHandler(this.btGuardarDoc_Click);
            // 
            // btRetirarDoc
            // 
            this.btRetirarDoc.BackColor = System.Drawing.Color.MidnightBlue;
            this.btRetirarDoc.Dock = System.Windows.Forms.DockStyle.Left;
            this.btRetirarDoc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btRetirarDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRetirarDoc.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btRetirarDoc.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRetirarDoc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btRetirarDoc.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btRetirarDoc.IconColor = System.Drawing.Color.Gainsboro;
            this.btRetirarDoc.IconSize = 30;
            this.btRetirarDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRetirarDoc.Location = new System.Drawing.Point(0, 0);
            this.btRetirarDoc.Name = "btRetirarDoc";
            this.btRetirarDoc.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btRetirarDoc.Rotation = 0D;
            this.btRetirarDoc.Size = new System.Drawing.Size(250, 45);
            this.btRetirarDoc.TabIndex = 4;
            this.btRetirarDoc.Text = "Retirar Documento";
            this.btRetirarDoc.UseVisualStyleBackColor = false;
            this.btRetirarDoc.Click += new System.EventHandler(this.btRetirar_Click);
            // 
            // btRetirarCaja
            // 
            this.btRetirarCaja.BackColor = System.Drawing.Color.MidnightBlue;
            this.btRetirarCaja.Dock = System.Windows.Forms.DockStyle.Left;
            this.btRetirarCaja.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btRetirarCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRetirarCaja.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btRetirarCaja.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRetirarCaja.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btRetirarCaja.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btRetirarCaja.IconColor = System.Drawing.Color.Gainsboro;
            this.btRetirarCaja.IconSize = 30;
            this.btRetirarCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRetirarCaja.Location = new System.Drawing.Point(500, 0);
            this.btRetirarCaja.Name = "btRetirarCaja";
            this.btRetirarCaja.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btRetirarCaja.Rotation = 0D;
            this.btRetirarCaja.Size = new System.Drawing.Size(250, 45);
            this.btRetirarCaja.TabIndex = 10;
            this.btRetirarCaja.Text = "Retirar Caja";
            this.btRetirarCaja.UseVisualStyleBackColor = false;
            this.btRetirarCaja.Click += new System.EventHandler(this.btRetirarCaja_Click);
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
        private FontAwesome.Sharp.IconButton btRetirarDoc;
        private FontAwesome.Sharp.IconButton btGuardarCaja;
        private FontAwesome.Sharp.IconButton btRetirarCaja;
    }
}