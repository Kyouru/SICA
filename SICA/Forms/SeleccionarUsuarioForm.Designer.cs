﻿namespace SICA.Forms
{
    partial class SeleccionarUsuarioForm
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
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.btSeleccionar = new System.Windows.Forms.Button();
            this.lbSeleccionarUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(10, 12);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(231, 21);
            this.cmbUsuario.TabIndex = 0;
            this.cmbUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbUsuario_KeyPress);
            // 
            // btSeleccionar
            // 
            this.btSeleccionar.Location = new System.Drawing.Point(74, 39);
            this.btSeleccionar.Name = "btSeleccionar";
            this.btSeleccionar.Size = new System.Drawing.Size(106, 23);
            this.btSeleccionar.TabIndex = 2;
            this.btSeleccionar.Text = "Seleccionar";
            this.btSeleccionar.UseVisualStyleBackColor = true;
            this.btSeleccionar.Click += new System.EventHandler(this.btSeleccionar_Click);
            // 
            // lbSeleccionarUsuario
            // 
            this.lbSeleccionarUsuario.AutoSize = true;
            this.lbSeleccionarUsuario.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbSeleccionarUsuario.Location = new System.Drawing.Point(12, 9);
            this.lbSeleccionarUsuario.Name = "lbSeleccionarUsuario";
            this.lbSeleccionarUsuario.Size = new System.Drawing.Size(0, 13);
            this.lbSeleccionarUsuario.TabIndex = 3;
            // 
            // SeleccionarUsuarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(252, 74);
            this.Controls.Add(this.lbSeleccionarUsuario);
            this.Controls.Add(this.btSeleccionar);
            this.Controls.Add(this.cmbUsuario);
            this.Name = "SeleccionarUsuarioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuario";
            this.Load += new System.EventHandler(this.SeleccionarUsuarioForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Button btSeleccionar;
        private System.Windows.Forms.Label lbSeleccionarUsuario;
    }
}