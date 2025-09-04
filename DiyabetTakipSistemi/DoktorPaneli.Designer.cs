namespace DiyabetTakipSistemi
{
    partial class DoktorPaneli
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
            this.btnListele = new System.Windows.Forms.Button();
            this.dgvHastalar = new System.Windows.Forms.DataGridView();
            this.btnYeniHasta = new System.Windows.Forms.Button();
            this.btnUyarilar = new System.Windows.Forms.Button();
            this.pictureProfil = new System.Windows.Forms.PictureBox();
            this.lblIsim = new System.Windows.Forms.Label();
            this.btnHastaGuncelle = new System.Windows.Forms.Button();
            this.btnTurAta = new System.Windows.Forms.Button();
            this.btnUyarilariTemizle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHastalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfil)).BeginInit();
            this.SuspendLayout();
            // 
            // btnListele
            // 
            this.btnListele.Location = new System.Drawing.Point(422, 24);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(151, 49);
            this.btnListele.TabIndex = 1;
            this.btnListele.Text = "Hastaları Listele";
            this.btnListele.UseVisualStyleBackColor = true;
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // dgvHastalar
            // 
            this.dgvHastalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHastalar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvHastalar.Location = new System.Drawing.Point(0, 339);
            this.dgvHastalar.Name = "dgvHastalar";
            this.dgvHastalar.ReadOnly = true;
            this.dgvHastalar.RowHeadersWidth = 62;
            this.dgvHastalar.RowTemplate.Height = 28;
            this.dgvHastalar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHastalar.Size = new System.Drawing.Size(800, 166);
            this.dgvHastalar.TabIndex = 2;
            this.dgvHastalar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHastalar_CellDoubleClick);
            // 
            // btnYeniHasta
            // 
            this.btnYeniHasta.Location = new System.Drawing.Point(422, 92);
            this.btnYeniHasta.Name = "btnYeniHasta";
            this.btnYeniHasta.Size = new System.Drawing.Size(147, 46);
            this.btnYeniHasta.TabIndex = 3;
            this.btnYeniHasta.Text = "Yeni Hasta Ekle";
            this.btnYeniHasta.UseVisualStyleBackColor = true;
            this.btnYeniHasta.Click += new System.EventHandler(this.btnYeniHasta_Click);
            // 
            // btnUyarilar
            // 
            this.btnUyarilar.Location = new System.Drawing.Point(422, 220);
            this.btnUyarilar.Name = "btnUyarilar";
            this.btnUyarilar.Size = new System.Drawing.Size(147, 44);
            this.btnUyarilar.TabIndex = 4;
            this.btnUyarilar.Text = "Uyarıları Gör";
            this.btnUyarilar.UseVisualStyleBackColor = true;
            this.btnUyarilar.Click += new System.EventHandler(this.btnUyarilar_Click);
            // 
            // pictureProfil
            // 
            this.pictureProfil.Location = new System.Drawing.Point(116, 24);
            this.pictureProfil.Name = "pictureProfil";
            this.pictureProfil.Size = new System.Drawing.Size(130, 129);
            this.pictureProfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureProfil.TabIndex = 5;
            this.pictureProfil.TabStop = false;
            // 
            // lblIsim
            // 
            this.lblIsim.AutoSize = true;
            this.lblIsim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsim.Location = new System.Drawing.Point(112, 182);
            this.lblIsim.Name = "lblIsim";
            this.lblIsim.Size = new System.Drawing.Size(57, 20);
            this.lblIsim.TabIndex = 6;
            this.lblIsim.Text = "label1";
            this.lblIsim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHastaGuncelle
            // 
            this.btnHastaGuncelle.Location = new System.Drawing.Point(422, 158);
            this.btnHastaGuncelle.Name = "btnHastaGuncelle";
            this.btnHastaGuncelle.Size = new System.Drawing.Size(147, 44);
            this.btnHastaGuncelle.TabIndex = 7;
            this.btnHastaGuncelle.Text = "Hasta Güncelle";
            this.btnHastaGuncelle.UseVisualStyleBackColor = true;
            this.btnHastaGuncelle.Click += new System.EventHandler(this.btnHastaGuncelle_Click);
            // 
            // btnTurAta
            // 
            this.btnTurAta.Location = new System.Drawing.Point(69, 234);
            this.btnTurAta.Name = "btnTurAta";
            this.btnTurAta.Size = new System.Drawing.Size(214, 44);
            this.btnTurAta.TabIndex = 8;
            this.btnTurAta.Text = "Diyet/Egzersiz Türü Ata";
            this.btnTurAta.UseVisualStyleBackColor = true;
            this.btnTurAta.Click += new System.EventHandler(this.btnTurAta_Click);
            // 
            // btnUyarilariTemizle
            // 
            this.btnUyarilariTemizle.Location = new System.Drawing.Point(422, 280);
            this.btnUyarilariTemizle.Name = "btnUyarilariTemizle";
            this.btnUyarilariTemizle.Size = new System.Drawing.Size(147, 44);
            this.btnUyarilariTemizle.TabIndex = 9;
            this.btnUyarilariTemizle.Text = "Uyarıları Temizle";
            this.btnUyarilariTemizle.UseVisualStyleBackColor = true;
            this.btnUyarilariTemizle.Click += new System.EventHandler(this.btnUyarilariTemizle_Click);
            // 
            // DoktorPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 505);
            this.Controls.Add(this.btnUyarilariTemizle);
            this.Controls.Add(this.btnTurAta);
            this.Controls.Add(this.btnHastaGuncelle);
            this.Controls.Add(this.lblIsim);
            this.Controls.Add(this.pictureProfil);
            this.Controls.Add(this.btnUyarilar);
            this.Controls.Add(this.btnYeniHasta);
            this.Controls.Add(this.dgvHastalar);
            this.Controls.Add(this.btnListele);
            this.Name = "DoktorPaneli";
            this.Text = "Doktor Paneli";
            this.Load += new System.EventHandler(this.DoktorPaneli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHastalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.DataGridView dgvHastalar;
        private System.Windows.Forms.Button btnYeniHasta;
        private System.Windows.Forms.Button btnUyarilar;
        private System.Windows.Forms.PictureBox pictureProfil;
        private System.Windows.Forms.Label lblIsim;
        private System.Windows.Forms.Button btnHastaGuncelle;
        private System.Windows.Forms.Button btnTurAta;
        private System.Windows.Forms.Button btnUyarilariTemizle;
    }
}