namespace DiyabetTakipSistemi
{
    partial class GrafikOranFormu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartEgzersiz = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDiyet = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartEgzersiz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDiyet)).BeginInit();
            this.SuspendLayout();
            // 
            // chartEgzersiz
            // 
            chartArea1.Name = "ChartArea1";
            this.chartEgzersiz.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartEgzersiz.Legends.Add(legend1);
            this.chartEgzersiz.Location = new System.Drawing.Point(39, 12);
            this.chartEgzersiz.Name = "chartEgzersiz";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartEgzersiz.Series.Add(series1);
            this.chartEgzersiz.Size = new System.Drawing.Size(472, 410);
            this.chartEgzersiz.TabIndex = 0;
            this.chartEgzersiz.Text = "chart1";
            // 
            // chartDiyet
            // 
            chartArea2.Name = "ChartArea1";
            this.chartDiyet.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartDiyet.Legends.Add(legend2);
            this.chartDiyet.Location = new System.Drawing.Point(579, 12);
            this.chartDiyet.Name = "chartDiyet";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartDiyet.Series.Add(series2);
            this.chartDiyet.Size = new System.Drawing.Size(442, 410);
            this.chartDiyet.TabIndex = 1;
            this.chartDiyet.Text = "chart1";
            // 
            // GrafikOranFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 593);
            this.Controls.Add(this.chartDiyet);
            this.Controls.Add(this.chartEgzersiz);
            this.Name = "GrafikOranFormu";
            this.Text = "Grafik Oran Formu";
            this.Load += new System.EventHandler(this.GrafikOranFormu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartEgzersiz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDiyet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartEgzersiz;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDiyet;
    }
}