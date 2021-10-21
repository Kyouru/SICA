namespace SICA.Forms
{
    partial class CambiarPasswordForm
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
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btGrabarPassword = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(16, 48);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '•';
            this.tbPassword.Size = new System.Drawing.Size(265, 26);
            this.tbPassword.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Introduzca su nueva contraseña:";
            // 
            // btGrabarPassword
            // 
            this.btGrabarPassword.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btGrabarPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGrabarPassword.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleRight;
            this.btGrabarPassword.IconColor = System.Drawing.Color.Gainsboro;
            this.btGrabarPassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btGrabarPassword.IconSize = 50;
            this.btGrabarPassword.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btGrabarPassword.Location = new System.Drawing.Point(299, 9);
            this.btGrabarPassword.Name = "btGrabarPassword";
            this.btGrabarPassword.Size = new System.Drawing.Size(74, 70);
            this.btGrabarPassword.TabIndex = 7;
            this.btGrabarPassword.UseVisualStyleBackColor = true;
            this.btGrabarPassword.Click += new System.EventHandler(this.btGrabarPassword_Click);
            // 
            // CambiarPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(385, 91);
            this.Controls.Add(this.btGrabarPassword);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label2);
            this.Name = "CambiarPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuario";
            this.Load += new System.EventHandler(this.CambiarPasswordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btGrabarPassword;
    }
}