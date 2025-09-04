using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DiyabetTakipSistemi
{
    public partial class GrafikOranFormu : Form
    {
        private string hastaTc;

        public GrafikOranFormu(string gelenTc)
        {
            InitializeComponent();
            hastaTc = gelenTc;
        }

        private void GrafikOranFormu_Load(object sender, EventArgs e)
        {
            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Aa123456789.;Database=Diyabet_db";
            int patientId = -1;

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                // 1. patient_id'yi TC'den al
                string getIdSql = @"
                    SELECT p.patient_id FROM patients p
                    JOIN users u ON p.user_id = u.user_id
                    WHERE u.tc_no = @tc";

                using (var cmd = new NpgsqlCommand(getIdSql, conn))
                {
                    cmd.Parameters.AddWithValue("tc", hastaTc);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                        patientId = Convert.ToInt32(result);
                    else
                    {
                        MessageBox.Show("Hasta bulunamadı.");
                        return;
                    }
                }

                // 2. Diet oranlarını al
                int dietTrue = 0, dietFalse = 0, exTrue = 0, exFalse = 0;

                string sql = @"
                    SELECT diet_status, exercise_status
                    FROM daily_reports
                    WHERE patient_id = @pid";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("pid", patientId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bool diet = reader.GetBoolean(0);
                            bool ex = reader.GetBoolean(1);

                            if (diet) dietTrue++; else dietFalse++;
                            if (ex) exTrue++; else exFalse++;
                        }
                    }
                }

                // 3. Diyet grafik
                chartDiyet.Series.Clear();
                Series dSeries = new Series
                {
                    Name = "Diyet",
                    ChartType = SeriesChartType.Doughnut
                };
                dSeries.Points.AddXY("Uygulandı", dietTrue);
                dSeries.Points.AddXY("Uygulanmadı", dietFalse);
                chartDiyet.Series.Add(dSeries);
                chartDiyet.Titles.Add("Diyet Uygulama Oranı");

                // 4. Egzersiz grafik
                chartEgzersiz.Series.Clear();
                Series eSeries = new Series
                {
                    Name = "Egzersiz",
                    ChartType = SeriesChartType.Doughnut
                };
                eSeries.Points.AddXY("Uygulandı", exTrue);
                eSeries.Points.AddXY("Uygulanmadı", exFalse);
                chartEgzersiz.Series.Add(eSeries);
                chartEgzersiz.Titles.Add("Egzersiz Uygulama Oranı");
            }
        }
    }
}
