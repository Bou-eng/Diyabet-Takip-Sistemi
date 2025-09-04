namespace DiyabetTakipSistemi
{
    partial class GunlukVeriFormu
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkEgzersiz = new System.Windows.Forms.CheckBox();
            this.chkDiyet = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKanSekeri = new System.Windows.Forms.TextBox();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpSaat = new System.Windows.Forms.DateTimePicker();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.clbBelirtiler = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Egzersiz durumu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Diyet durumu:";
            // 
            // chkEgzersiz
            // 
            this.chkEgzersiz.AutoSize = true;
            this.chkEgzersiz.Location = new System.Drawing.Point(218, 58);
            this.chkEgzersiz.Name = "chkEgzersiz";
            this.chkEgzersiz.Size = new System.Drawing.Size(172, 24);
            this.chkEgzersiz.TabIndex = 2;
            this.chkEgzersiz.Text = "Egzersiz yapıldı mı?";
            this.chkEgzersiz.UseVisualStyleBackColor = true;
            // 
            // chkDiyet
            // 
            this.chkDiyet.AutoSize = true;
            this.chkDiyet.Location = new System.Drawing.Point(218, 133);
            this.chkDiyet.Name = "chkDiyet";
            this.chkDiyet.Size = new System.Drawing.Size(171, 24);
            this.chkDiyet.TabIndex = 3;
            this.chkDiyet.Text = "Diyet uygulandı mı?";
            this.chkDiyet.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kan şekeri (mg/dL):";
            // 
            // txtKanSekeri
            // 
            this.txtKanSekeri.Location = new System.Drawing.Point(218, 214);
            this.txtKanSekeri.Name = "txtKanSekeri";
            this.txtKanSekeri.Size = new System.Drawing.Size(200, 26);
            this.txtKanSekeri.TabIndex = 5;
            // 
            // dtpTarih
            // 
            this.dtpTarih.Location = new System.Drawing.Point(214, 386);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(200, 26);
            this.dtpTarih.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 354);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ölçüm tarihi:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 429);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ölçüm saati:";
            // 
            // dtpSaat
            // 
            this.dtpSaat.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSaat.Location = new System.Drawing.Point(214, 465);
            this.dtpSaat.Name = "dtpSaat";
            this.dtpSaat.ShowUpDown = true;
            this.dtpSaat.Size = new System.Drawing.Size(200, 26);
            this.dtpSaat.TabIndex = 9;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(196, 514);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(236, 43);
            this.btnKaydet.TabIndex = 10;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(188, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Belirti Gir:";
            // 
            // clbBelirtiler
            // 
            this.clbBelirtiler.FormattingEnabled = true;
            this.clbBelirtiler.Items.AddRange(new object[] {
            "Polidipsi",
            "Poliüri",
            "Nöropati",
            "Yorgunluk",
            "Bulanık görme"});
            this.clbBelirtiler.Location = new System.Drawing.Point(214, 292);
            this.clbBelirtiler.Name = "clbBelirtiler";
            this.clbBelirtiler.Size = new System.Drawing.Size(204, 50);
            this.clbBelirtiler.TabIndex = 12;
            // 
            // GunlukVeriFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 579);
            this.Controls.Add(this.clbBelirtiler);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.dtpSaat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpTarih);
            this.Controls.Add(this.txtKanSekeri);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkDiyet);
            this.Controls.Add(this.chkEgzersiz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GunlukVeriFormu";
            this.Text = "Günlük Veri Formu";
            this.Load += new System.EventHandler(this.GunlukVeriFormu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkEgzersiz;
        private System.Windows.Forms.CheckBox chkDiyet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKanSekeri;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpSaat;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox clbBelirtiler;
    }
}