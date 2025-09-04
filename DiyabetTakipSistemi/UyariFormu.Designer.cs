namespace DiyabetTakipSistemi
{
    partial class UyariFormu
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
            this.dgvUyarilar = new System.Windows.Forms.DataGridView();
            this.chkSadeceAcil = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUyarilar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUyarilar
            // 
            this.dgvUyarilar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUyarilar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUyarilar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUyarilar.Location = new System.Drawing.Point(0, 0);
            this.dgvUyarilar.Name = "dgvUyarilar";
            this.dgvUyarilar.ReadOnly = true;
            this.dgvUyarilar.RowHeadersWidth = 62;
            this.dgvUyarilar.RowTemplate.Height = 28;
            this.dgvUyarilar.Size = new System.Drawing.Size(800, 637);
            this.dgvUyarilar.TabIndex = 0;
            this.dgvUyarilar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUyarilar_CellContentClick);
            // 
            // chkSadeceAcil
            // 
            this.chkSadeceAcil.AutoSize = true;
            this.chkSadeceAcil.Location = new System.Drawing.Point(239, 542);
            this.chkSadeceAcil.Name = "chkSadeceAcil";
            this.chkSadeceAcil.Size = new System.Drawing.Size(232, 24);
            this.chkSadeceAcil.TabIndex = 1;
            this.chkSadeceAcil.Text = "Sadece Acil Uyarıları Göster";
            this.chkSadeceAcil.UseVisualStyleBackColor = true;
            this.chkSadeceAcil.CheckedChanged += new System.EventHandler(this.chkSadeceAcil_CheckedChanged);
            // 
            // UyariFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 637);
            this.Controls.Add(this.chkSadeceAcil);
            this.Controls.Add(this.dgvUyarilar);
            this.Name = "UyariFormu";
            this.Text = "Uyari Formu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUyarilar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUyarilar;
        private System.Windows.Forms.CheckBox chkSadeceAcil;
    }
}