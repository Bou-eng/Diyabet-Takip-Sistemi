namespace DiyabetTakipSistemi
{
    partial class HastaDetayFormu
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
            this.dgvGunlukVeriler = new System.Windows.Forms.DataGridView();
            this.btnOrtalama = new System.Windows.Forms.Button();
            this.btnGrafik = new System.Windows.Forms.Button();
            this.btnCsvExport = new System.Windows.Forms.Button();
            this.btnOranGoster = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGunlukVeriler)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGunlukVeriler
            // 
            this.dgvGunlukVeriler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGunlukVeriler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGunlukVeriler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGunlukVeriler.Location = new System.Drawing.Point(0, 0);
            this.dgvGunlukVeriler.Name = "dgvGunlukVeriler";
            this.dgvGunlukVeriler.ReadOnly = true;
            this.dgvGunlukVeriler.RowHeadersWidth = 62;
            this.dgvGunlukVeriler.RowTemplate.Height = 28;
            this.dgvGunlukVeriler.Size = new System.Drawing.Size(800, 551);
            this.dgvGunlukVeriler.TabIndex = 0;
            this.dgvGunlukVeriler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGunlukVeriler_CellContentClick);
            // 
            // btnOrtalama
            // 
            this.btnOrtalama.Location = new System.Drawing.Point(261, 350);
            this.btnOrtalama.Name = "btnOrtalama";
            this.btnOrtalama.Size = new System.Drawing.Size(217, 45);
            this.btnOrtalama.TabIndex = 1;
            this.btnOrtalama.Text = "Ortalama Hesapla";
            this.btnOrtalama.UseVisualStyleBackColor = true;
            this.btnOrtalama.Click += new System.EventHandler(this.btnOrtalama_Click);
            // 
            // btnGrafik
            // 
            this.btnGrafik.Location = new System.Drawing.Point(261, 443);
            this.btnGrafik.Name = "btnGrafik";
            this.btnGrafik.Size = new System.Drawing.Size(217, 42);
            this.btnGrafik.TabIndex = 2;
            this.btnGrafik.Text = "Grafik Göster";
            this.btnGrafik.UseVisualStyleBackColor = true;
            this.btnGrafik.Click += new System.EventHandler(this.btnGrafik_Click);
            // 
            // btnCsvExport
            // 
            this.btnCsvExport.Location = new System.Drawing.Point(261, 491);
            this.btnCsvExport.Name = "btnCsvExport";
            this.btnCsvExport.Size = new System.Drawing.Size(217, 36);
            this.btnCsvExport.TabIndex = 3;
            this.btnCsvExport.Text = "CSV Dışa Aktar";
            this.btnCsvExport.UseVisualStyleBackColor = true;
            this.btnCsvExport.Click += new System.EventHandler(this.btnCsvExport_Click);
            // 
            // btnOranGoster
            // 
            this.btnOranGoster.Location = new System.Drawing.Point(261, 401);
            this.btnOranGoster.Name = "btnOranGoster";
            this.btnOranGoster.Size = new System.Drawing.Size(217, 36);
            this.btnOranGoster.TabIndex = 4;
            this.btnOranGoster.Text = "Uygulama Oranını Göster";
            this.btnOranGoster.UseVisualStyleBackColor = true;
            this.btnOranGoster.Click += new System.EventHandler(this.btnOranGoster_Click);
            // 
            // HastaDetayFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 551);
            this.Controls.Add(this.btnOranGoster);
            this.Controls.Add(this.btnCsvExport);
            this.Controls.Add(this.btnGrafik);
            this.Controls.Add(this.btnOrtalama);
            this.Controls.Add(this.dgvGunlukVeriler);
            this.Name = "HastaDetayFormu";
            this.Text = "Hasta Detay Formu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGunlukVeriler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGunlukVeriler;
        private System.Windows.Forms.Button btnOrtalama;
        private System.Windows.Forms.Button btnGrafik;
        private System.Windows.Forms.Button btnCsvExport;
        private System.Windows.Forms.Button btnOranGoster;
    }
}