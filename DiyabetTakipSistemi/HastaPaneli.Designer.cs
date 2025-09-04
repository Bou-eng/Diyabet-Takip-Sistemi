namespace DiyabetTakipSistemi
{
    partial class HastaPaneli
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
            this.btnVeriGir = new System.Windows.Forms.Button();
            this.pictureProfil = new System.Windows.Forms.PictureBox();
            this.lblIsim = new System.Windows.Forms.Label();
            this.lblDiyetTuru = new System.Windows.Forms.Label();
            this.lblEgzersizTuru = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfil)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVeriGir
            // 
            this.btnVeriGir.Location = new System.Drawing.Point(395, 61);
            this.btnVeriGir.Name = "btnVeriGir";
            this.btnVeriGir.Size = new System.Drawing.Size(210, 41);
            this.btnVeriGir.TabIndex = 0;
            this.btnVeriGir.Text = "Günlük Veri Girişi";
            this.btnVeriGir.UseVisualStyleBackColor = true;
            this.btnVeriGir.Click += new System.EventHandler(this.btnVeriGir_Click);
            // 
            // pictureProfil
            // 
            this.pictureProfil.Location = new System.Drawing.Point(80, 61);
            this.pictureProfil.Name = "pictureProfil";
            this.pictureProfil.Size = new System.Drawing.Size(192, 155);
            this.pictureProfil.TabIndex = 1;
            this.pictureProfil.TabStop = false;
            // 
            // lblIsim
            // 
            this.lblIsim.AutoSize = true;
            this.lblIsim.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsim.Location = new System.Drawing.Point(76, 254);
            this.lblIsim.Name = "lblIsim";
            this.lblIsim.Size = new System.Drawing.Size(59, 22);
            this.lblIsim.TabIndex = 2;
            this.lblIsim.Text = "label1";
            // 
            // lblDiyetTuru
            // 
            this.lblDiyetTuru.AutoSize = true;
            this.lblDiyetTuru.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiyetTuru.Location = new System.Drawing.Point(76, 300);
            this.lblDiyetTuru.Name = "lblDiyetTuru";
            this.lblDiyetTuru.Size = new System.Drawing.Size(152, 22);
            this.lblDiyetTuru.TabIndex = 3;
            this.lblDiyetTuru.Text = "Atanan diyet türü";
            // 
            // lblEgzersizTuru
            // 
            this.lblEgzersizTuru.AutoSize = true;
            this.lblEgzersizTuru.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEgzersizTuru.Location = new System.Drawing.Point(76, 340);
            this.lblEgzersizTuru.Name = "lblEgzersizTuru";
            this.lblEgzersizTuru.Size = new System.Drawing.Size(176, 22);
            this.lblEgzersizTuru.TabIndex = 4;
            this.lblEgzersizTuru.Text = "Atanan egzersiz türü";
            // 
            // HastaPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblEgzersizTuru);
            this.Controls.Add(this.lblDiyetTuru);
            this.Controls.Add(this.lblIsim);
            this.Controls.Add(this.pictureProfil);
            this.Controls.Add(this.btnVeriGir);
            this.Name = "HastaPaneli";
            this.Text = "Hasta Paneli";
            this.Load += new System.EventHandler(this.HastaPaneli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVeriGir;
        private System.Windows.Forms.PictureBox pictureProfil;
        private System.Windows.Forms.Label lblIsim;
        private System.Windows.Forms.Label lblDiyetTuru;
        private System.Windows.Forms.Label lblEgzersizTuru;
    }
}