namespace DiyabetTakipSistemi
{
    partial class Form1
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
            this.btnGiris = new System.Windows.Forms.Button();
            this.lblTc = new System.Windows.Forms.Label();
            this.txtTc = new System.Windows.Forms.TextBox();
            this.lblSifre = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.btnDoktorEkle = new System.Windows.Forms.Button();
            this.btnDoktorGuncelle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGiris
            // 
            this.btnGiris.Location = new System.Drawing.Point(356, 239);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(103, 43);
            this.btnGiris.TabIndex = 0;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.UseVisualStyleBackColor = true;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // lblTc
            // 
            this.lblTc.AutoSize = true;
            this.lblTc.Location = new System.Drawing.Point(300, 45);
            this.lblTc.Name = "lblTc";
            this.lblTc.Size = new System.Drawing.Size(97, 20);
            this.lblTc.TabIndex = 1;
            this.lblTc.Text = "TC Kimlik No";
            // 
            // txtTc
            // 
            this.txtTc.Location = new System.Drawing.Point(304, 77);
            this.txtTc.Name = "txtTc";
            this.txtTc.Size = new System.Drawing.Size(224, 26);
            this.txtTc.TabIndex = 2;
            this.txtTc.TextChanged += new System.EventHandler(this.txtTc_TextChanged);
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.Location = new System.Drawing.Point(300, 117);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(42, 20);
            this.lblSifre.TabIndex = 3;
            this.lblSifre.Text = "Şifre\r\n";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(304, 150);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(224, 26);
            this.txtSifre.TabIndex = 4;
            // 
            // cmbRol
            // 
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(304, 193);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(224, 28);
            this.cmbRol.TabIndex = 5;
            // 
            // btnDoktorEkle
            // 
            this.btnDoktorEkle.Location = new System.Drawing.Point(303, 301);
            this.btnDoktorEkle.Name = "btnDoktorEkle";
            this.btnDoktorEkle.Size = new System.Drawing.Size(225, 42);
            this.btnDoktorEkle.TabIndex = 6;
            this.btnDoktorEkle.Text = "Doktor Ekle";
            this.btnDoktorEkle.UseVisualStyleBackColor = true;
            this.btnDoktorEkle.Click += new System.EventHandler(this.btnDoktorEkle_Click);
            // 
            // btnDoktorGuncelle
            // 
            this.btnDoktorGuncelle.Location = new System.Drawing.Point(303, 363);
            this.btnDoktorGuncelle.Name = "btnDoktorGuncelle";
            this.btnDoktorGuncelle.Size = new System.Drawing.Size(225, 42);
            this.btnDoktorGuncelle.TabIndex = 7;
            this.btnDoktorGuncelle.Text = "Doktor Güncelle";
            this.btnDoktorGuncelle.UseVisualStyleBackColor = true;
            this.btnDoktorGuncelle.Click += new System.EventHandler(this.btnDoktorGuncelle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDoktorGuncelle);
            this.Controls.Add(this.btnDoktorEkle);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.txtTc);
            this.Controls.Add(this.lblTc);
            this.Controls.Add(this.btnGiris);
            this.Name = "Form1";
            this.Text = "GIRIŞ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Label lblTc;
        private System.Windows.Forms.TextBox txtTc;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Button btnDoktorEkle;
        private System.Windows.Forms.Button btnDoktorGuncelle;
    }
}

