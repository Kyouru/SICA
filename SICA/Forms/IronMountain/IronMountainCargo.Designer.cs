namespace SICA.Forms.IronMountain
{
    partial class IronMountainCargo
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
            this.label3 = new System.Windows.Forms.Label();
            this.tbCargoCajas = new System.Windows.Forms.TextBox();
            this.btGenerar = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(58, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 22);
            this.label3.TabIndex = 27;
            this.label3.Text = "Cajas:";
            // 
            // tbCargoCajas
            // 
            this.tbCargoCajas.Location = new System.Drawing.Point(62, 71);
            this.tbCargoCajas.Multiline = true;
            this.tbCargoCajas.Name = "tbCargoCajas";
            this.tbCargoCajas.Size = new System.Drawing.Size(220, 488);
            this.tbCargoCajas.TabIndex = 26;
            // 
            // btGenerar
            // 
            this.btGenerar.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGenerar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btGenerar.IconChar = FontAwesome.Sharp.IconChar.FileSignature;
            this.btGenerar.IconColor = System.Drawing.Color.Gainsboro;
            this.btGenerar.IconSize = 40;
            this.btGenerar.Location = new System.Drawing.Point(312, 71);
            this.btGenerar.Name = "btGenerar";
            this.btGenerar.Rotation = 0D;
            this.btGenerar.Size = new System.Drawing.Size(70, 56);
            this.btGenerar.TabIndex = 28;
            this.btGenerar.UseVisualStyleBackColor = true;
            // 
            // IronMountainCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1048, 608);
            this.Controls.Add(this.btGenerar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCargoCajas);
            this.Name = "IronMountainCargo";
            this.Text = "IronMountainCargo";
            this.Click += new System.EventHandler(this.btGenerarCargo_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCargoCajas;
        private FontAwesome.Sharp.IconButton btGenerar;
    }
}