
namespace SICA.Forms.Pagare
{
    partial class PagareManual
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
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbCodigoSocio = new System.Windows.Forms.TextBox();
            this.lbDescripcion2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSolicitudSISGO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btRegistrar = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // tbNombre
            // 
            this.tbNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombre.Location = new System.Drawing.Point(231, 73);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(389, 24);
            this.tbNombre.TabIndex = 96;
            // 
            // tbCodigoSocio
            // 
            this.tbCodigoSocio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCodigoSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodigoSocio.Location = new System.Drawing.Point(231, 43);
            this.tbCodigoSocio.Name = "tbCodigoSocio";
            this.tbCodigoSocio.Size = new System.Drawing.Size(389, 24);
            this.tbCodigoSocio.TabIndex = 95;
            // 
            // lbDescripcion2
            // 
            this.lbDescripcion2.AutoSize = true;
            this.lbDescripcion2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescripcion2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbDescripcion2.Location = new System.Drawing.Point(13, 73);
            this.lbDescripcion2.Name = "lbDescripcion2";
            this.lbDescripcion2.Size = new System.Drawing.Size(83, 22);
            this.lbDescripcion2.TabIndex = 111;
            this.lbDescripcion2.Text = "Nombre:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(13, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 22);
            this.label6.TabIndex = 109;
            this.label6.Text = "Codigo Socio:";
            // 
            // tbSolicitudSISGO
            // 
            this.tbSolicitudSISGO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbSolicitudSISGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSolicitudSISGO.Location = new System.Drawing.Point(231, 12);
            this.tbSolicitudSISGO.Name = "tbSolicitudSISGO";
            this.tbSolicitudSISGO.Size = new System.Drawing.Size(179, 24);
            this.tbSolicitudSISGO.TabIndex = 89;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 22);
            this.label2.TabIndex = 102;
            this.label2.Text = "Solicitud SISGO:";
            // 
            // btRegistrar
            // 
            this.btRegistrar.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRegistrar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRegistrar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btRegistrar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btRegistrar.IconColor = System.Drawing.Color.Black;
            this.btRegistrar.IconSize = 16;
            this.btRegistrar.Location = new System.Drawing.Point(209, 113);
            this.btRegistrar.Name = "btRegistrar";
            this.btRegistrar.Rotation = 0D;
            this.btRegistrar.Size = new System.Drawing.Size(217, 32);
            this.btRegistrar.TabIndex = 101;
            this.btRegistrar.Text = "Registrar";
            this.btRegistrar.UseVisualStyleBackColor = true;
            this.btRegistrar.Click += new System.EventHandler(this.btRegistrar_Click);
            // 
            // PagareManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(634, 158);
            this.Controls.Add(this.btRegistrar);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.tbCodigoSocio);
            this.Controls.Add(this.lbDescripcion2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbSolicitudSISGO);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PagareManual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PagareManual";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconButton btRegistrar;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox tbCodigoSocio;
        private System.Windows.Forms.Label lbDescripcion2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSolicitudSISGO;
        private System.Windows.Forms.Label label2;
    }
}