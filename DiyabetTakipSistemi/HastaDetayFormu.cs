using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DiyabetTakipSistemi
{
    public partial class HastaDetayFormu : Form
    {
        private string hastaTc;

        // TC alan constructor
        public HastaDetayFormu(string gelenTc)
        {
            InitializeComponent();
            hastaTc = gelenTc;
            this.Load += HastaDetayFormu_Load;
        }

        private void HastaDetayFormu_Load(object sender, EventArgs e)
        {
            try
            {
                string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Aa123456789.;Database=Diyabet_db";

                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();

                    // 1. user_id çek
                    string userSql = "SELECT user_id FROM users WHERE tc_no = @tc";
                    using (var cmd = new NpgsqlCommand(userSql, conn))
                    {
                        cmd.Parameters.AddWithValue("tc", hastaTc);
                        var userIdObj = cmd.ExecuteScalar();

                        if (userIdObj != null)
                        {
                            int userId = Convert.ToInt32(userIdObj);

                            // 2. patient_id çek
                            string pidSql = "SELECT patient_id FROM patients WHERE user_id = @uid";
                            using (var cmd2 = new NpgsqlCommand(pidSql, conn))
                            {
                                cmd2.Parameters.AddWithValue("uid", userId);
                                var pidObj = cmd2.ExecuteScalar();

                                if (pidObj != null)
                                {
                                    int patientId = Convert.ToInt32(pidObj);

                                    // 3. Günlük verileri getir
                                    string veriSql = @"
                                        SELECT 
                                            report_date AS ""Tarih"",
                                            report_time AS ""Saat"",
                                            blood_sugar AS ""Kan Şekeri (mg/dL)"",
                                            exercise_status AS ""Egzersiz Yapıldı mı?"",
                                            diet_status AS ""Diyet Uygulandı mı?""
                                        FROM daily_reports
                                        WHERE patient_id = @pid
                                        ORDER BY report_date, report_time";

                                    using (var da = new NpgsqlDataAdapter(veriSql, conn))
                                    {
                                        da.SelectCommand.Parameters.AddWithValue("pid", patientId);
                                        DataTable dt = new DataTable();
                                        da.Fill(dt);
                                        dgvGunlukVeriler.DataSource = dt;
                                        dgvGunlukVeriler.Visible = true;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Hasta ID bulunamadı.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı (user_id) bulunamadı.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvGunlukVeriler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // İsteğe bağlı tıklama işlemleri eklenebilir
        }

        private void btnOrtalama_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Aa123456789.;Database=Diyabet_db";

                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();

                    // 1. user_id çek
                    string userSql = "SELECT user_id FROM users WHERE tc_no = @tc";
                    using (var cmd = new NpgsqlCommand(userSql, conn))
                    {
                        cmd.Parameters.AddWithValue("tc", hastaTc);
                        var userIdObj = cmd.ExecuteScalar();

                        if (userIdObj != null)
                        {
                            int userId = Convert.ToInt32(userIdObj);

                            // 2. patient_id çek
                            string pidSql = "SELECT patient_id FROM patients WHERE user_id = @uid";
                            using (var cmd2 = new NpgsqlCommand(pidSql, conn))
                            {
                                cmd2.Parameters.AddWithValue("uid", userId);
                                var pidObj = cmd2.ExecuteScalar();

                                if (pidObj != null)
                                {
                                    int patientId = Convert.ToInt32(pidObj);

                                    // 3. Bugüne ait ölçümleri çek
                                    string sql = @"
                                SELECT blood_sugar 
                                FROM daily_reports 
                                WHERE patient_id = @pid AND report_date = CURRENT_DATE";

                                    using (var cmd3 = new NpgsqlCommand(sql, conn))
                                    {
                                        cmd3.Parameters.AddWithValue("pid", patientId);
                                        using (var reader = cmd3.ExecuteReader())
                                        {
                                            List<int> sugarValues = new List<int>();

                                            while (reader.Read())
                                            {
                                                sugarValues.Add(reader.GetInt32(0));
                                            }

                                            if (sugarValues.Count < 3)
                                            {
                                                MessageBox.Show("Yetersiz veri: Bugün için en az 3 ölçüm gerekiyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return;
                                            }

                                            double ortalama = sugarValues.Average();
                                            int doz = 0;

                                            if (ortalama > 200)
                                                doz = 3;
                                            else if (ortalama > 150)
                                                doz = 2;
                                            else if (ortalama > 110)
                                                doz = 1;

                                            MessageBox.Show(
                                                $"Bugünkü ölçüm sayısı: {sugarValues.Count}\n" +
                                                $"Ortalama kan şekeri: {ortalama:F1} mg/dL\n" +
                                                $"Önerilen insülin dozu: {doz} ml",
                                                "Ortalama Hesaplama",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information
                                            );
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            GrafikFormu form = new GrafikFormu(hastaTc);
            form.ShowDialog();
        }

        private void btnCsvExport_Click(object sender, EventArgs e)
        {
            if (dgvGunlukVeriler.DataSource == null)
            {
                MessageBox.Show("Listelenecek veri bulunamadı.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Dosyası|*.csv";
            sfd.Title = "CSV Olarak Kaydet";
            sfd.FileName = "hasta_raporlari.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable dt = (DataTable)dgvGunlukVeriler.DataSource;
                    StringBuilder sb = new StringBuilder();

                    // Başlık satırı
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        sb.Append(dt.Columns[i].ColumnName);
                        if (i < dt.Columns.Count - 1)
                            sb.Append(";");
                    }
                    sb.AppendLine();

                    // Veri satırları
                    foreach (DataRow row in dt.Rows)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sb.Append(row[i].ToString());
                            if (i < dt.Columns.Count - 1)
                                sb.Append(";");
                        }
                        sb.AppendLine();
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("CSV dosyası başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }

        private void btnOranGoster_Click(object sender, EventArgs e)
        {
            GrafikOranFormu form = new GrafikOranFormu(hastaTc); // hasta TC'si aktarılır
            form.ShowDialog();
        }

    }
}
