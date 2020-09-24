namespace SICA
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnLeft = new System.Windows.Forms.Panel();
            this.pnTop = new System.Windows.Forms.Panel();
            this.pnMain = new System.Windows.Forms.Panel();
            this.btMinimizar = new FontAwesome.Sharp.IconButton();
            this.btMaximizar = new FontAwesome.Sharp.IconButton();
            this.btCerrar = new FontAwesome.Sharp.IconButton();
            this.icMain = new FontAwesome.Sharp.IconPictureBox();
            this.btImportar = new FontAwesome.Sharp.IconButton();
            this.pnLeft.SuspendLayout();
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pnLeft
            // 
            this.pnLeft.Controls.Add(this.btImportar);
            this.pnLeft.Controls.Add(this.icMain);
            this.pnLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLeft.Location = new System.Drawing.Point(0, 0);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(200, 668);
            this.pnLeft.TabIndex = 0;
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.btMinimizar);
            this.pnTop.Controls.Add(this.btMaximizar);
            this.pnTop.Controls.Add(this.btCerrar);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(200, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1075, 27);
            this.pnTop.TabIndex = 1;
            // 
            // pnMain
            // 
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(200, 27);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1075, 641);
            this.pnMain.TabIndex = 2;
            // 
            // btMinimizar
            // 
            this.btMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMinimizar.FlatAppearance.BorderSize = 0;
            this.btMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMinimizar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btMinimizar.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btMinimizar.IconColor = System.Drawing.Color.White;
            this.btMinimizar.IconSize = 24;
            this.btMinimizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btMinimizar.Location = new System.Drawing.Point(996, 0);
            this.btMinimizar.Margin = new System.Windows.Forms.Padding(0);
            this.btMinimizar.Name = "btMinimizar";
            this.btMinimizar.Rotation = 0D;
            this.btMinimizar.Size = new System.Drawing.Size(26, 23);
            this.btMinimizar.TabIndex = 5;
            this.btMinimizar.UseVisualStyleBackColor = true;
            this.btMinimizar.Click += new System.EventHandler(this.btMinimizar_Click);
            // 
            // btMaximizar
            // 
            this.btMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMaximizar.FlatAppearance.BorderSize = 0;
            this.btMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMaximizar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btMaximizar.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.btMaximizar.IconColor = System.Drawing.Color.White;
            this.btMaximizar.IconSize = 24;
            this.btMaximizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btMaximizar.Location = new System.Drawing.Point(1022, 0);
            this.btMaximizar.Margin = new System.Windows.Forms.Padding(0);
            this.btMaximizar.Name = "btMaximizar";
            this.btMaximizar.Rotation = 0D;
            this.btMaximizar.Size = new System.Drawing.Size(26, 23);
            this.btMaximizar.TabIndex = 4;
            this.btMaximizar.UseVisualStyleBackColor = true;
            this.btMaximizar.Click += new System.EventHandler(this.btMaximizar_Click);
            // 
            // btCerrar
            // 
            this.btCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCerrar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btCerrar.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.btCerrar.IconColor = System.Drawing.Color.White;
            this.btCerrar.IconSize = 24;
            this.btCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCerrar.Location = new System.Drawing.Point(1048, 0);
            this.btCerrar.Margin = new System.Windows.Forms.Padding(0);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Rotation = 0D;
            this.btCerrar.Size = new System.Drawing.Size(26, 23);
            this.btCerrar.TabIndex = 3;
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // icMain
            // 
            this.icMain.BackColor = System.Drawing.Color.MidnightBlue;
            this.icMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.icMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.icMain.IconChar = FontAwesome.Sharp.IconChar.None;
            this.icMain.IconColor = System.Drawing.SystemColors.ControlText;
            this.icMain.IconSize = 100;
            this.icMain.Location = new System.Drawing.Point(0, 0);
            this.icMain.Name = "icMain";
            this.icMain.Size = new System.Drawing.Size(200, 100);
            this.icMain.TabIndex = 0;
            this.icMain.TabStop = false;
            this.icMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.icMain_MouseDown);
            // 
            // btImportar
            // 
            this.btImportar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btImportar.FlatAppearance.BorderSize = 0;
            this.btImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btImportar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btImportar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImportar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btImportar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btImportar.IconColor = System.Drawing.Color.Black;
            this.btImportar.IconSize = 16;
            this.btImportar.Location = new System.Drawing.Point(0, 100);
            this.btImportar.Name = "btImportar";
            this.btImportar.Rotation = 0D;
            this.btImportar.Size = new System.Drawing.Size(200, 61);
            this.btImportar.TabIndex = 1;
            this.btImportar.Text = "Importar";
            this.btImportar.UseVisualStyleBackColor = true;
            this.btImportar.Click += new System.EventHandler(this.btImportar_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1275, 668);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnTop);
            this.Controls.Add(this.pnLeft);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.pnLeft.ResumeLayout(false);
            this.pnTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel pnMain;
        private FontAwesome.Sharp.IconButton btImportar;
        private FontAwesome.Sharp.IconPictureBox icMain;
        private FontAwesome.Sharp.IconButton btMinimizar;
        private FontAwesome.Sharp.IconButton btMaximizar;
        private FontAwesome.Sharp.IconButton btCerrar;
    }
}

