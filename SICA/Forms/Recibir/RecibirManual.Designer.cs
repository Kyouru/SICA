
namespace SICA.Forms.Recibir
{
    partial class RecibirManual
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNumeroCaja = new System.Windows.Forms.TextBox();
            this.cbNumeroCaja = new System.Windows.Forms.CheckBox();
            this.cbFecha = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDescripcion1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbDescripcion2 = new System.Windows.Forms.CheckBox();
            this.tbDescripcion2 = new System.Windows.Forms.TextBox();
            this.lbDescripcion2 = new System.Windows.Forms.Label();
            this.cbDescripcion3 = new System.Windows.Forms.CheckBox();
            this.tbDescripcion3 = new System.Windows.Forms.TextBox();
            this.lbDescripcion3 = new System.Windows.Forms.Label();
            this.cbCodDocumento = new System.Windows.Forms.CheckBox();
            this.cbCodDepartamento = new System.Windows.Forms.CheckBox();
            this.cmbCodDocumento = new System.Windows.Forms.ComboBox();
            this.cmbCodDepartamento = new System.Windows.Forms.ComboBox();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.cbDescripcion4 = new System.Windows.Forms.CheckBox();
            this.tbDescripcion4 = new System.Windows.Forms.TextBox();
            this.lbDescripcion4 = new System.Windows.Forms.Label();
            this.cbDescripcion5 = new System.Windows.Forms.CheckBox();
            this.tbDescripcion5 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbDescripcion1 = new System.Windows.Forms.ComboBox();
            this.btRegistrar = new FontAwesome.Sharp.IconButton();
            this.lbPagare = new System.Windows.Forms.Label();
            this.cmbPagare = new System.Windows.Forms.ComboBox();
            this.cmbExpediente = new System.Windows.Forms.ComboBox();
            this.lbExpediente = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(40, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 22);
            this.label2.TabIndex = 47;
            this.label2.Text = "Numero de Caja:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(40, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 22);
            this.label1.TabIndex = 48;
            this.label1.Text = "Codigo Departamento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(40, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 22);
            this.label3.TabIndex = 49;
            this.label3.Text = "Codigo Documento:";
            // 
            // tbNumeroCaja
            // 
            this.tbNumeroCaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNumeroCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNumeroCaja.Location = new System.Drawing.Point(258, 9);
            this.tbNumeroCaja.Name = "tbNumeroCaja";
            this.tbNumeroCaja.Size = new System.Drawing.Size(179, 24);
            this.tbNumeroCaja.TabIndex = 2;
            this.tbNumeroCaja.Visible = false;
            // 
            // cbNumeroCaja
            // 
            this.cbNumeroCaja.AutoSize = true;
            this.cbNumeroCaja.Location = new System.Drawing.Point(19, 16);
            this.cbNumeroCaja.Name = "cbNumeroCaja";
            this.cbNumeroCaja.Size = new System.Drawing.Size(15, 14);
            this.cbNumeroCaja.TabIndex = 52;
            this.cbNumeroCaja.UseVisualStyleBackColor = true;
            this.cbNumeroCaja.CheckedChanged += new System.EventHandler(this.cbNumeroCaja_CheckedChanged);
            // 
            // cbFecha
            // 
            this.cbFecha.AutoSize = true;
            this.cbFecha.Location = new System.Drawing.Point(19, 118);
            this.cbFecha.Name = "cbFecha";
            this.cbFecha.Size = new System.Drawing.Size(15, 14);
            this.cbFecha.TabIndex = 58;
            this.cbFecha.UseVisualStyleBackColor = true;
            this.cbFecha.CheckedChanged += new System.EventHandler(this.cbFecha_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(40, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 22);
            this.label4.TabIndex = 56;
            this.label4.Text = "Fecha Desde:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(40, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 22);
            this.label5.TabIndex = 59;
            this.label5.Text = "Fecha Hasta:";
            // 
            // cbDescripcion1
            // 
            this.cbDescripcion1.AutoSize = true;
            this.cbDescripcion1.Checked = true;
            this.cbDescripcion1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDescripcion1.Enabled = false;
            this.cbDescripcion1.Location = new System.Drawing.Point(19, 166);
            this.cbDescripcion1.Name = "cbDescripcion1";
            this.cbDescripcion1.Size = new System.Drawing.Size(15, 14);
            this.cbDescripcion1.TabIndex = 64;
            this.cbDescripcion1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(40, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 22);
            this.label6.TabIndex = 62;
            this.label6.Text = "Descripción 1:";
            // 
            // cbDescripcion2
            // 
            this.cbDescripcion2.AutoSize = true;
            this.cbDescripcion2.Checked = true;
            this.cbDescripcion2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDescripcion2.Location = new System.Drawing.Point(19, 196);
            this.cbDescripcion2.Name = "cbDescripcion2";
            this.cbDescripcion2.Size = new System.Drawing.Size(15, 14);
            this.cbDescripcion2.TabIndex = 67;
            this.cbDescripcion2.UseVisualStyleBackColor = true;
            this.cbDescripcion2.CheckedChanged += new System.EventHandler(this.cbDescripcion2_CheckedChanged);
            // 
            // tbDescripcion2
            // 
            this.tbDescripcion2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDescripcion2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescripcion2.Location = new System.Drawing.Point(258, 189);
            this.tbDescripcion2.Name = "tbDescripcion2";
            this.tbDescripcion2.Size = new System.Drawing.Size(389, 24);
            this.tbDescripcion2.TabIndex = 8;
            // 
            // lbDescripcion2
            // 
            this.lbDescripcion2.AutoSize = true;
            this.lbDescripcion2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescripcion2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbDescripcion2.Location = new System.Drawing.Point(40, 189);
            this.lbDescripcion2.Name = "lbDescripcion2";
            this.lbDescripcion2.Size = new System.Drawing.Size(132, 22);
            this.lbDescripcion2.TabIndex = 65;
            this.lbDescripcion2.Text = "Descripción 2:";
            // 
            // cbDescripcion3
            // 
            this.cbDescripcion3.AutoSize = true;
            this.cbDescripcion3.Checked = true;
            this.cbDescripcion3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDescripcion3.Location = new System.Drawing.Point(19, 226);
            this.cbDescripcion3.Name = "cbDescripcion3";
            this.cbDescripcion3.Size = new System.Drawing.Size(15, 14);
            this.cbDescripcion3.TabIndex = 70;
            this.cbDescripcion3.UseVisualStyleBackColor = true;
            this.cbDescripcion3.CheckedChanged += new System.EventHandler(this.cbDescripcion3_CheckedChanged);
            // 
            // tbDescripcion3
            // 
            this.tbDescripcion3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDescripcion3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescripcion3.Location = new System.Drawing.Point(258, 219);
            this.tbDescripcion3.Name = "tbDescripcion3";
            this.tbDescripcion3.Size = new System.Drawing.Size(389, 24);
            this.tbDescripcion3.TabIndex = 9;
            // 
            // lbDescripcion3
            // 
            this.lbDescripcion3.AutoSize = true;
            this.lbDescripcion3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescripcion3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbDescripcion3.Location = new System.Drawing.Point(40, 219);
            this.lbDescripcion3.Name = "lbDescripcion3";
            this.lbDescripcion3.Size = new System.Drawing.Size(132, 22);
            this.lbDescripcion3.TabIndex = 68;
            this.lbDescripcion3.Text = "Descripción 3:";
            // 
            // cbCodDocumento
            // 
            this.cbCodDocumento.AutoSize = true;
            this.cbCodDocumento.Checked = true;
            this.cbCodDocumento.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCodDocumento.Enabled = false;
            this.cbCodDocumento.Location = new System.Drawing.Point(19, 76);
            this.cbCodDocumento.Name = "cbCodDocumento";
            this.cbCodDocumento.Size = new System.Drawing.Size(15, 14);
            this.cbCodDocumento.TabIndex = 72;
            this.cbCodDocumento.UseVisualStyleBackColor = true;
            // 
            // cbCodDepartamento
            // 
            this.cbCodDepartamento.AutoSize = true;
            this.cbCodDepartamento.Checked = true;
            this.cbCodDepartamento.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCodDepartamento.Enabled = false;
            this.cbCodDepartamento.Location = new System.Drawing.Point(19, 46);
            this.cbCodDepartamento.Name = "cbCodDepartamento";
            this.cbCodDepartamento.Size = new System.Drawing.Size(15, 14);
            this.cbCodDepartamento.TabIndex = 71;
            this.cbCodDepartamento.UseVisualStyleBackColor = true;
            // 
            // cmbCodDocumento
            // 
            this.cmbCodDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCodDocumento.FormattingEnabled = true;
            this.cmbCodDocumento.Location = new System.Drawing.Point(258, 68);
            this.cmbCodDocumento.Name = "cmbCodDocumento";
            this.cmbCodDocumento.Size = new System.Drawing.Size(179, 26);
            this.cmbCodDocumento.TabIndex = 4;
            // 
            // cmbCodDepartamento
            // 
            this.cmbCodDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCodDepartamento.FormattingEnabled = true;
            this.cmbCodDepartamento.Location = new System.Drawing.Point(258, 38);
            this.cmbCodDepartamento.Name = "cmbCodDepartamento";
            this.cmbCodDepartamento.Size = new System.Drawing.Size(179, 26);
            this.cmbCodDepartamento.TabIndex = 3;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(258, 99);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(113, 24);
            this.dtpDesde.TabIndex = 5;
            this.dtpDesde.Visible = false;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(258, 129);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(113, 24);
            this.dtpHasta.TabIndex = 6;
            this.dtpHasta.Visible = false;
            // 
            // cbDescripcion4
            // 
            this.cbDescripcion4.AutoSize = true;
            this.cbDescripcion4.Checked = true;
            this.cbDescripcion4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDescripcion4.Location = new System.Drawing.Point(19, 256);
            this.cbDescripcion4.Name = "cbDescripcion4";
            this.cbDescripcion4.Size = new System.Drawing.Size(15, 14);
            this.cbDescripcion4.TabIndex = 80;
            this.cbDescripcion4.UseVisualStyleBackColor = true;
            this.cbDescripcion4.CheckedChanged += new System.EventHandler(this.cbDescripcion4_CheckedChanged);
            // 
            // tbDescripcion4
            // 
            this.tbDescripcion4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDescripcion4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescripcion4.Location = new System.Drawing.Point(258, 249);
            this.tbDescripcion4.Name = "tbDescripcion4";
            this.tbDescripcion4.Size = new System.Drawing.Size(389, 24);
            this.tbDescripcion4.TabIndex = 10;
            // 
            // lbDescripcion4
            // 
            this.lbDescripcion4.AutoSize = true;
            this.lbDescripcion4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescripcion4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbDescripcion4.Location = new System.Drawing.Point(40, 249);
            this.lbDescripcion4.Name = "lbDescripcion4";
            this.lbDescripcion4.Size = new System.Drawing.Size(132, 22);
            this.lbDescripcion4.TabIndex = 78;
            this.lbDescripcion4.Text = "Descripción 4:";
            // 
            // cbDescripcion5
            // 
            this.cbDescripcion5.AutoSize = true;
            this.cbDescripcion5.Checked = true;
            this.cbDescripcion5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDescripcion5.Location = new System.Drawing.Point(19, 286);
            this.cbDescripcion5.Name = "cbDescripcion5";
            this.cbDescripcion5.Size = new System.Drawing.Size(15, 14);
            this.cbDescripcion5.TabIndex = 83;
            this.cbDescripcion5.UseVisualStyleBackColor = true;
            this.cbDescripcion5.CheckedChanged += new System.EventHandler(this.cbDescripcion5_CheckedChanged);
            // 
            // tbDescripcion5
            // 
            this.tbDescripcion5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDescripcion5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescripcion5.Location = new System.Drawing.Point(258, 279);
            this.tbDescripcion5.Name = "tbDescripcion5";
            this.tbDescripcion5.Size = new System.Drawing.Size(389, 24);
            this.tbDescripcion5.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(40, 279);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 22);
            this.label10.TabIndex = 81;
            this.label10.Text = "Descripción 5:";
            // 
            // cmbDescripcion1
            // 
            this.cmbDescripcion1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDescripcion1.FormattingEnabled = true;
            this.cmbDescripcion1.Location = new System.Drawing.Point(258, 158);
            this.cmbDescripcion1.Name = "cmbDescripcion1";
            this.cmbDescripcion1.Size = new System.Drawing.Size(389, 26);
            this.cmbDescripcion1.TabIndex = 7;
            this.cmbDescripcion1.SelectedIndexChanged += new System.EventHandler(this.cmbDescripcion1_SelectedIndexChanged);
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
            this.btRegistrar.Location = new System.Drawing.Point(224, 346);
            this.btRegistrar.Name = "btRegistrar";
            this.btRegistrar.Rotation = 0D;
            this.btRegistrar.Size = new System.Drawing.Size(217, 32);
            this.btRegistrar.TabIndex = 14;
            this.btRegistrar.Text = "Registrar";
            this.btRegistrar.UseVisualStyleBackColor = true;
            this.btRegistrar.Click += new System.EventHandler(this.btRegistrar_Click);
            // 
            // lbPagare
            // 
            this.lbPagare.AutoSize = true;
            this.lbPagare.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPagare.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbPagare.Location = new System.Drawing.Point(40, 309);
            this.lbPagare.Name = "lbPagare";
            this.lbPagare.Size = new System.Drawing.Size(76, 22);
            this.lbPagare.TabIndex = 86;
            this.lbPagare.Text = "Pagaré:";
            this.lbPagare.Visible = false;
            // 
            // cmbPagare
            // 
            this.cmbPagare.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPagare.FormattingEnabled = true;
            this.cmbPagare.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cmbPagare.Location = new System.Drawing.Point(133, 309);
            this.cmbPagare.Name = "cmbPagare";
            this.cmbPagare.Size = new System.Drawing.Size(68, 26);
            this.cmbPagare.TabIndex = 12;
            this.cmbPagare.Text = "SI";
            this.cmbPagare.Visible = false;
            // 
            // cmbExpediente
            // 
            this.cmbExpediente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExpediente.FormattingEnabled = true;
            this.cmbExpediente.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cmbExpediente.Location = new System.Drawing.Point(369, 309);
            this.cmbExpediente.Name = "cmbExpediente";
            this.cmbExpediente.Size = new System.Drawing.Size(68, 26);
            this.cmbExpediente.TabIndex = 13;
            this.cmbExpediente.Text = "SI";
            this.cmbExpediente.Visible = false;
            // 
            // lbExpediente
            // 
            this.lbExpediente.AutoSize = true;
            this.lbExpediente.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExpediente.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbExpediente.Location = new System.Drawing.Point(241, 309);
            this.lbExpediente.Name = "lbExpediente";
            this.lbExpediente.Size = new System.Drawing.Size(111, 22);
            this.lbExpediente.TabIndex = 88;
            this.lbExpediente.Text = "Expediente:";
            this.lbExpediente.Visible = false;
            // 
            // RecibirManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(664, 390);
            this.Controls.Add(this.cmbExpediente);
            this.Controls.Add(this.lbExpediente);
            this.Controls.Add(this.cmbPagare);
            this.Controls.Add(this.lbPagare);
            this.Controls.Add(this.btRegistrar);
            this.Controls.Add(this.cmbDescripcion1);
            this.Controls.Add(this.cbDescripcion5);
            this.Controls.Add(this.tbDescripcion5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbDescripcion4);
            this.Controls.Add(this.tbDescripcion4);
            this.Controls.Add(this.lbDescripcion4);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.cmbCodDepartamento);
            this.Controls.Add(this.cmbCodDocumento);
            this.Controls.Add(this.cbCodDocumento);
            this.Controls.Add(this.cbCodDepartamento);
            this.Controls.Add(this.cbDescripcion3);
            this.Controls.Add(this.tbDescripcion3);
            this.Controls.Add(this.lbDescripcion3);
            this.Controls.Add(this.cbDescripcion2);
            this.Controls.Add(this.tbDescripcion2);
            this.Controls.Add(this.lbDescripcion2);
            this.Controls.Add(this.cbDescripcion1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbFecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbNumeroCaja);
            this.Controls.Add(this.tbNumeroCaja);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RecibirManual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RecibirManual";
            this.Load += new System.EventHandler(this.RecibirManual_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNumeroCaja;
        private System.Windows.Forms.CheckBox cbNumeroCaja;
        private System.Windows.Forms.CheckBox cbFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbDescripcion1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbDescripcion2;
        private System.Windows.Forms.TextBox tbDescripcion2;
        private System.Windows.Forms.Label lbDescripcion2;
        private System.Windows.Forms.CheckBox cbDescripcion3;
        private System.Windows.Forms.TextBox tbDescripcion3;
        private System.Windows.Forms.Label lbDescripcion3;
        private System.Windows.Forms.CheckBox cbCodDocumento;
        private System.Windows.Forms.CheckBox cbCodDepartamento;
        private System.Windows.Forms.ComboBox cmbCodDocumento;
        private System.Windows.Forms.ComboBox cmbCodDepartamento;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.CheckBox cbDescripcion4;
        private System.Windows.Forms.TextBox tbDescripcion4;
        private System.Windows.Forms.Label lbDescripcion4;
        private System.Windows.Forms.CheckBox cbDescripcion5;
        private System.Windows.Forms.TextBox tbDescripcion5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbDescripcion1;
        private FontAwesome.Sharp.IconButton btRegistrar;
        private System.Windows.Forms.Label lbPagare;
        private System.Windows.Forms.ComboBox cmbPagare;
        private System.Windows.Forms.ComboBox cmbExpediente;
        private System.Windows.Forms.Label lbExpediente;
    }
}