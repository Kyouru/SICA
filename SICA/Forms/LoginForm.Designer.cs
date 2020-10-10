namespace SICA
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.pnTop = new System.Windows.Forms.Panel();
            this.btMinimizar = new FontAwesome.Sharp.IconButton();
            this.btMaximizar = new FontAwesome.Sharp.IconButton();
            this.btCerrar = new FontAwesome.Sharp.IconButton();
            this.btEntrar = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(14, 430);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(17, 473);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // tbUsername
            // 
            this.tbUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.Location = new System.Drawing.Point(117, 429);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(223, 26);
            this.tbUsername.TabIndex = 2;
            this.tbUsername.Text = "SICADBA";
            this.tbUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPassword_KeyDown);
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(117, 472);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '•';
            this.tbPassword.Size = new System.Drawing.Size(223, 26);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.Text = "MidoriLove";
            this.tbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPassword_KeyDown);
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnTop.Controls.Add(this.btMinimizar);
            this.pnTop.Controls.Add(this.btMaximizar);
            this.pnTop.Controls.Add(this.btCerrar);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(435, 27);
            this.pnTop.TabIndex = 4;
            this.pnTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseDown);
            // 
            // btMinimizar
            // 
            this.btMinimizar.FlatAppearance.BorderSize = 0;
            this.btMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMinimizar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btMinimizar.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btMinimizar.IconColor = System.Drawing.Color.White;
            this.btMinimizar.IconSize = 24;
            this.btMinimizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btMinimizar.Location = new System.Drawing.Point(357, 0);
            this.btMinimizar.Margin = new System.Windows.Forms.Padding(0);
            this.btMinimizar.Name = "btMinimizar";
            this.btMinimizar.Rotation = 0D;
            this.btMinimizar.Size = new System.Drawing.Size(26, 23);
            this.btMinimizar.TabIndex = 2;
            this.btMinimizar.UseVisualStyleBackColor = true;
            this.btMinimizar.Click += new System.EventHandler(this.btMinimizar_Click);
            // 
            // btMaximizar
            // 
            this.btMaximizar.FlatAppearance.BorderSize = 0;
            this.btMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMaximizar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btMaximizar.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.btMaximizar.IconColor = System.Drawing.Color.White;
            this.btMaximizar.IconSize = 24;
            this.btMaximizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btMaximizar.Location = new System.Drawing.Point(383, 0);
            this.btMaximizar.Margin = new System.Windows.Forms.Padding(0);
            this.btMaximizar.Name = "btMaximizar";
            this.btMaximizar.Rotation = 0D;
            this.btMaximizar.Size = new System.Drawing.Size(26, 23);
            this.btMaximizar.TabIndex = 1;
            this.btMaximizar.UseVisualStyleBackColor = true;
            this.btMaximizar.Click += new System.EventHandler(this.btMaximizar_Click);
            // 
            // btCerrar
            // 
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCerrar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btCerrar.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.btCerrar.IconColor = System.Drawing.Color.White;
            this.btCerrar.IconSize = 24;
            this.btCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCerrar.Location = new System.Drawing.Point(409, 0);
            this.btCerrar.Margin = new System.Windows.Forms.Padding(0);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Rotation = 0D;
            this.btCerrar.Size = new System.Drawing.Size(26, 23);
            this.btCerrar.TabIndex = 0;
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // btEntrar
            // 
            this.btEntrar.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEntrar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btEntrar.IconChar = FontAwesome.Sharp.IconChar.Dungeon;
            this.btEntrar.IconColor = System.Drawing.Color.Gainsboro;
            this.btEntrar.IconSize = 50;
            this.btEntrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEntrar.Location = new System.Drawing.Point(348, 430);
            this.btEntrar.Name = "btEntrar";
            this.btEntrar.Rotation = 0D;
            this.btEntrar.Size = new System.Drawing.Size(74, 70);
            this.btEntrar.TabIndex = 6;
            this.btEntrar.UseVisualStyleBackColor = true;
            this.btEntrar.Click += new System.EventHandler(this.btEntrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SICA.Properties.Resources.logo3;
            this.pictureBox1.Location = new System.Drawing.Point(33, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(380, 380);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(435, 520);
            this.Controls.Add(this.btEntrar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnTop);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.pnTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Panel pnTop;
        private FontAwesome.Sharp.IconButton btCerrar;
        private FontAwesome.Sharp.IconButton btMinimizar;
        private FontAwesome.Sharp.IconButton btMaximizar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btEntrar;
    }
}