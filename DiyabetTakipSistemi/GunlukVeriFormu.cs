using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DiyabetTakipSistemi
{
    public partial class GunlukVeriFormu : Form
    {
        private int patientId;

        public GunlukVeriFormu(int gelenHastaId)
        {
            InitializeComponent();
            patientId = gelenHastaId;
        }
        private void GunlukVeriFormu_Load(object sender, EventArgs e)
        {
            // Gerekirse buraya belirtiler listesi yüklenebilir
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Aa123456789.;Database=Diyabet_db";

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                DateTime tarih = dtpTarih.Value.Date;
                TimeSpan saat = dtpSaat.Value.TimeOfDay;
                DateTime tamZaman = tarih + saat;
                int kanSekeri = Convert.ToInt32(txtKanSekeri.Text);
                bool egzersiz = chkEgzersiz.Checked;
                bool diyet = chkDiyet.Checked;
                string belirtiler = string.Join(", ", clbBelirtiler.CheckedItems.Cast<string>());

                // Saat kontrolü (sadece belirlenen aralıklar geçerli)
                bool saatGecerli =
                    (saat >= TimeSpan.FromHours(6) && saat < TimeSpan.FromHours(8)) ||     // Sabah
                    (saat >= TimeSpan.FromHours(12) && saat < TimeSpan.FromHours(13)) ||   // Öğle
                    (saat >= TimeSpan.FromHours(18) && saat < TimeSpan.FromHours(20));     // Akşam

                if (!saatGecerli)
                {
                    MessageBox.Show("Uyarı: Bu ölçüm saati geçerli aralıkta değil!", "Geçersiz Saat", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    string alertSql = @"
                        INSERT INTO alerts (patient_id, alert_type, message)
                        VALUES (@pid, 'Geçersiz Saat', @msg)";
                    using (var cmd = new NpgsqlCommand(alertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("pid", patientId);
                        cmd.Parameters.AddWithValue("msg", $"Ölçüm saati geçerli aralık dışında: {saat}");
                        cmd.ExecuteNonQuery();
                    }
                }

                // Günlük veri kaydı
                string insertSql = @"
                    INSERT INTO daily_reports 
                    (patient_id, report_date, report_time, blood_sugar, exercise_status, diet_status, symptoms)
                    VALUES 
                    (@hastaId, @tarih, @saat, @kan, @egzersiz, @diyet, @belirtiler)";

                using (var cmd = new NpgsqlCommand(insertSql, conn))
                {
                    cmd.Parameters.AddWithValue("hastaId", patientId);
                    cmd.Parameters.AddWithValue("tarih", tarih);
                    cmd.Parameters.AddWithValue("saat", saat);
                    cmd.Parameters.AddWithValue("kan", kanSekeri);
                    cmd.Parameters.AddWithValue("egzersiz", egzersiz);
                    cmd.Parameters.AddWithValue("diyet", diyet);
                    cmd.Parameters.AddWithValue("belirtiler", belirtiler);
                    cmd.ExecuteNonQuery();
                }

                // Öneri motoru
                string öneriSql = "INSERT INTO alerts (patient_id, alert_type, message) VALUES (@pid, @type, @msg)";

                if (kanSekeri < 70)
                {
                    string msg = $"Kan şekeri çok düşük: {kanSekeri} mg/dL";
                    using (var cmd = new NpgsqlCommand(öneriSql, conn))
                    {
                        cmd.Parameters.AddWithValue("pid", patientId);
                        cmd.Parameters.AddWithValue("type", "Hipoglisemi");
                        cmd.Parameters.AddWithValue("msg", msg);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Hipoglisemi uyarısı oluşturuldu!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (kanSekeri > 200)
                {
                    string msg = $"Kan şekeri çok yüksek: {kanSekeri} mg/dL";
                    using (var cmd = new NpgsqlCommand(öneriSql, conn))
                    {
                        cmd.Parameters.AddWithValue("pid", patientId);
                        cmd.Parameters.AddWithValue("type", "Hiperglisemi");
                        cmd.Parameters.AddWithValue("msg", msg);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Hiperglisemi uyarısı oluşturuldu!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (kanSekeri >= 100 && kanSekeri <= 150 && egzersiz && diyet)
                {
                    string msg = "Değerler ideal, böyle devam!";
                    using (var cmd = new NpgsqlCommand(öneriSql, conn))
                    {
                        cmd.Parameters.AddWithValue("pid", patientId);
                        cmd.Parameters.AddWithValue("type", "Öneri");
                        cmd.Parameters.AddWithValue("msg", msg);
                        cmd.ExecuteNonQuery();
                    }
                }

                if (kanSekeri >= 150 && kanSekeri <= 200 && !diyet)
                {
                    string msg = "Diyetinize dikkat etmeniz önerilir.";
                    using (var cmd = new NpgsqlCommand(öneriSql, conn))
                    {
                        cmd.Parameters.AddWithValue("pid", patientId);
                        cmd.Parameters.AddWithValue("type", "Öneri");
                        cmd.Parameters.AddWithValue("msg", msg);
                        cmd.ExecuteNonQuery();
                    }
                }

                if (kanSekeri > 180 && belirtiler.Contains("Bulanık görme"))
                {
                    string msg = "Yüksek şeker ve bulanık görme birlikte tespit edildi. Lütfen doktorunuza başvurun.";
                    using (var cmd = new NpgsqlCommand(öneriSql, conn))
                    {
                        cmd.Parameters.AddWithValue("pid", patientId);
                        cmd.Parameters.AddWithValue("type", "Acil Uyarı");
                        cmd.Parameters.AddWithValue("msg", msg);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Günlük ölçüm sayısı kontrolü
                string saySql = @"
                    SELECT COUNT(*) FROM daily_reports 
                    WHERE patient_id = @pid AND report_date = CURRENT_DATE";

                using (var cmd = new NpgsqlCommand(saySql, conn))
                {
                    cmd.Parameters.AddWithValue("pid", patientId);
                    int say = Convert.ToInt32(cmd.ExecuteScalar());

                    if (say < 3)
                    {
                        string msg = $"Bugünkü ölçüm sayısı: {say}. En az 3 ölçüm gereklidir.";
                        using (var alertCmd = new NpgsqlCommand(öneriSql, conn))
                        {
                            alertCmd.Parameters.AddWithValue("pid", patientId);
                            alertCmd.Parameters.AddWithValue("type", "Yetersiz Veri");
                            alertCmd.Parameters.AddWithValue("msg", msg);
                            alertCmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Yetersiz veri uyarısı oluşturuldu!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                MessageBox.Show("Günlük veri başarıyla kaydedildi!", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
