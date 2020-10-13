namespace SICA.Forms.DocuClass
{
    partial class DocuClassSubMain
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
            this.btRecibir = new FontAwesome.Sharp.IconButton();
            this.btValidar = new FontAwesome.Sharp.IconButton();
            this.btEntregar = new FontAwesome.Sharp.IconButton();
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
            this.pnTop.Controls.Add(this.btRecibir);
            this.pnTop.Controls.Add(this.btValidar);
            this.pnTop.Controls.Add(this.btEntregar);
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
            // btRecibir
            // 
            this.btRecibir.BackColor = System.Drawing.Color.MidnightBlue;
            this.btRecibir.Dock = System.Windows.Forms.DockStyle.Left;
            this.btRecibir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btRecibir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRecibir.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btRecibir.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRecibir.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btRecibir.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btRecibir.IconColor = System.Drawing.Color.Gainsboro;
            this.btRecibir.IconSize = 30;
            this.btRecibir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRecibir.Location = new System.Drawing.Point(280, 0);
            this.btRecibir.Name = "btRecibir";
            this.btRecibir.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btRecibir.Rotation = 0D;
            this.btRecibir.Size = new System.Drawing.Size(140, 45);
            this.btRecibir.TabIndex = 6;
            this.btRecibir.Text = "Recibir";
            this.btRecibir.UseVisualStyleBackColor = false;
            this.btRecibir.Click += new System.EventHandler(this.btRecibir_Click);
            // 
            // btValidar
            // 
            this.btValidar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btValidar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btValidar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btValidar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btValidar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btValidar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btValidar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btValidar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btValidar.IconColor = System.Drawing.Color.Gainsboro;
            this.btValidar.IconSize = 30;
            this.btValidar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btValidar.Location = new System.Drawing.Point(140, 0);
            this.btValidar.Name = "btValidar";
            this.btValidar.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btValidar.Rotation = 0D;
            this.btValidar.Size = new System.Drawing.Size(140, 45);
            this.btValidar.TabIndex = 5;
            this.btValidar.Text = "Validar";
            this.btValidar.UseVisualStyleBackColor = false;
            this.btValidar.Click += new System.EventHandler(this.btValidar_Click);
            // 
            // btEntregar
            // 
            this.btEntregar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btEntregar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btEntregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btEntregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEntregar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btEntregar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEntregar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btEntregar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btEntregar.IconColor = System.Drawing.Color.Gainsboro;
            this.btEntregar.IconSize = 30;
            this.btEntregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEntregar.Location = new System.Drawing.Point(0, 0);
            this.btEntregar.Name = "btEntregar";
            this.btEntregar.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btEntregar.Rotation = 0D;
            this.btEntregar.Size = new System.Drawing.Size(140, 45);
            this.btEntregar.TabIndex = 4;
            this.btEntregar.Text = "Entregar";
            this.btEntregar.UseVisualStyleBackColor = false;
            this.btEntregar.Click += new System.EventHandler(this.btEntregar_Click);
            // 
            // DocuClassSubMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.pnSubMain);
            this.Controls.Add(this.pnTop);
            this.Name = "DocuClassSubMain";
            this.Text = "DocuClassSubMain";
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnSubMain;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btRecibir;
        private FontAwesome.Sharp.IconButton btValidar;
        private FontAwesome.Sharp.IconButton btEntregar;
    }
}