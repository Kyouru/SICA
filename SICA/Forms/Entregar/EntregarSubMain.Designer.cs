namespace SICA.Forms.Entregar
{
    partial class EntregarSubMain
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
            this.pnTop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btDocumento = new FontAwesome.Sharp.IconButton();
            this.btExpediente = new FontAwesome.Sharp.IconButton();
            this.pnSubMain = new System.Windows.Forms.Panel();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnTop.Controls.Add(this.panel1);
            this.pnTop.Controls.Add(this.btDocumento);
            this.pnTop.Controls.Add(this.btExpediente);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1048, 45);
            this.pnTop.TabIndex = 0;
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
            // btDocumento
            // 
            this.btDocumento.BackColor = System.Drawing.Color.MidnightBlue;
            this.btDocumento.Dock = System.Windows.Forms.DockStyle.Left;
            this.btDocumento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDocumento.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btDocumento.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDocumento.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btDocumento.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btDocumento.IconColor = System.Drawing.Color.Gainsboro;
            this.btDocumento.IconSize = 30;
            this.btDocumento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDocumento.Location = new System.Drawing.Point(140, 0);
            this.btDocumento.Name = "btDocumento";
            this.btDocumento.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btDocumento.Rotation = 0D;
            this.btDocumento.Size = new System.Drawing.Size(140, 45);
            this.btDocumento.TabIndex = 5;
            this.btDocumento.Text = "Documentos";
            this.btDocumento.UseVisualStyleBackColor = false;
            this.btDocumento.Click += new System.EventHandler(this.btDocumento_Click);
            // 
            // btExpediente
            // 
            this.btExpediente.BackColor = System.Drawing.Color.MidnightBlue;
            this.btExpediente.Dock = System.Windows.Forms.DockStyle.Left;
            this.btExpediente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btExpediente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExpediente.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btExpediente.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExpediente.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btExpediente.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btExpediente.IconColor = System.Drawing.Color.Gainsboro;
            this.btExpediente.IconSize = 30;
            this.btExpediente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExpediente.Location = new System.Drawing.Point(0, 0);
            this.btExpediente.Name = "btExpediente";
            this.btExpediente.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btExpediente.Rotation = 0D;
            this.btExpediente.Size = new System.Drawing.Size(140, 45);
            this.btExpediente.TabIndex = 4;
            this.btExpediente.Text = "Expedientes";
            this.btExpediente.UseVisualStyleBackColor = false;
            this.btExpediente.Click += new System.EventHandler(this.btBusqueda_Click);
            // 
            // pnSubMain
            // 
            this.pnSubMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSubMain.Location = new System.Drawing.Point(0, 45);
            this.pnSubMain.Name = "pnSubMain";
            this.pnSubMain.Size = new System.Drawing.Size(1048, 563);
            this.pnSubMain.TabIndex = 1;
            // 
            // EntregarSubMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.pnSubMain);
            this.Controls.Add(this.pnTop);
            this.Name = "EntregarSubMain";
            this.Text = "EntregarSubMain";
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTop;
        private FontAwesome.Sharp.IconButton btExpediente;
        private FontAwesome.Sharp.IconButton btDocumento;
        private System.Windows.Forms.Panel pnSubMain;
        private System.Windows.Forms.Panel panel1;
    }
}