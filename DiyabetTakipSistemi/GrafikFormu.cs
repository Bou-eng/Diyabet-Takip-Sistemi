using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using System.Windows.Forms.DataVisualization.Charting;

namespace DiyabetTakipSistemi
{
    public partial class GrafikFormu : Form
    {
        private string hastaTc;

        public GrafikFormu(string gelenTc)
        {
            InitializeComponent();
            hastaTc = gelenTc;
            this.Load += GrafikFormu_Load;
        }

        private void kanSekeriChart_Click(object sender, EventArgs e)
        {

        }
        private void GrafikFormu_Load(object sender, EventArgs e)
        {
            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Aa123456789.;Database=Diyabet_db";

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
                    SELECT dr.report_date, dr.report_time, dr.blood_sugar
                    FROM daily_reports dr
                    JOIN patients p ON dr.patient_id = p.patient_id
                    JOIN users u ON p.user_id = u.user_id
                    WHERE u.tc_no = @tc
                    ORDER BY dr.report_date, dr.report_time";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("tc", hastaTc);

                    using (var reader = cmd.ExecuteReader())
                    {
                        Series seri = new Series("Kan Şekeri");
                        seri.ChartType = SeriesChartType.Line;
                        seri.BorderWidth = 2;

                        while (reader.Read())
                        {
                            DateTime zaman = reader.GetDateTime(0).Date + reader.GetTimeSpan(1);
                            int deger = reader.GetInt32(2);
                            seri.Points.AddXY(zaman, deger);
                        }

                        kanSekeriChart.Series.Clear();
                        kanSekeriChart.Series.Add(seri);

                        kanSekeriChart.ChartAreas[0].AxisX.LabelStyle.Format = "dd.MM HH:mm";
                        kanSekeriChart.ChartAreas[0].AxisX.Title = "Zaman";
                        kanSekeriChart.ChartAreas[0].AxisY.Title = "Kan Şekeri (mg/dL)";
                        kanSekeriChart.Titles.Clear();
                        kanSekeriChart.Titles.Add("Kan Şekeri Değerleri");
                    }
                }
            }
        }
    }
}
