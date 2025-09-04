using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DiyabetTakipSistemi
{
    public partial class HastaPaneli : Form
    {
        private int patientId;
        private int userId;

        public HastaPaneli(int gelenPatientId, int gelenUserId)
        {
            InitializeComponent();
            patientId = gelenPatientId;
            userId = gelenUserId;
        }

        private void HastaPaneli_Load(object sender, EventArgs e)
        {
            this.Text = "Hasta Paneli";
            MessageBox.Show("Hasta paneline hoş geldiniz!");

            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Aa123456789.;Database=Diyabet_db";

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                // PROFIL RESMI ve ISIM cek
                string sql = "SELECT name, surname, profile_picture FROM users WHERE user_id = @uid";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("uid", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string ad = reader.GetString(0);
                            string soyad = reader.GetString(1);
                            lblIsim.Text = ad + " " + soyad;

                            if (!reader.IsDBNull(2))
                            {
                                byte[] imgData = (byte[])reader[2];
                                using (MemoryStream ms = new MemoryStream(imgData))
                                {
                                    pictureProfil.Image = Image.FromStream(ms);
                                    pictureProfil.SizeMode = PictureBoxSizeMode.Zoom;
                                }
                            }
                            else
                            {
                                pictureProfil.Image = null;
                            }
                        }
                    }
                }

                // DOKTORUN ATADIĞI DİYET / EGZERSİZ TÜRÜ GÖSTER
                string turSql = @"
                    SELECT diet_type, exercise_type
                    FROM patients
                    WHERE patient_id = @pid";

                using (var cmd = new NpgsqlCommand(turSql, conn))
                {
                    cmd.Parameters.AddWithValue("pid", patientId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblDiyetTuru.Text = "Diyet Türü: " + (reader.IsDBNull(0) ? "-" : reader.GetString(0));
                            lblEgzersizTuru.Text = "Egzersiz Türü: " + (reader.IsDBNull(1) ? "-" : reader.GetString(1));
                        }
                        else
                        {
                            lblDiyetTuru.Text = "Diyet Türü: -";
                            lblEgzersizTuru.Text = "Egzersiz Türü: -";
                        }
                    }
                }

                // GUNLUK ÖLÇÜM ZAMANI KONTROLÜ
                string zamanSql = @"
                    SELECT report_time FROM daily_reports 
                    WHERE patient_id = @pid AND report_date = CURRENT_DATE";

                bool sabahVar = false;
                bool ogleVar = false;
                bool aksamVar = false;

                using (var zamanCmd = new NpgsqlCommand(zamanSql, conn))
                {
                    zamanCmd.Parameters.AddWithValue("pid", patientId);
                    using (var reader = zamanCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TimeSpan saat = reader.GetTimeSpan(0);

                            if (saat >= TimeSpan.FromHours(6) && saat < TimeSpan.FromHours(12))
                                sabahVar = true;
                            else if (saat >= TimeSpan.FromHours(12) && saat < TimeSpan.FromHours(18))
                                ogleVar = true;
                            else if (saat >= TimeSpan.FromHours(18) && saat < TimeSpan.FromHours(24))
                                aksamVar = true;
                        }
                    }
                }

                // Eksik olan saat dilimleri için alerts ekle
                List<string> eksikler = new List<string>();
                if (!sabahVar) eksikler.Add("Sabah");
                if (!ogleVar) eksikler.Add("Öğle");
                if (!aksamVar) eksikler.Add("Akşam");

                foreach (string dilim in eksikler)
                {
                    string alertSql = @"
                        INSERT INTO alerts (patient_id, alert_type, message)
                        VALUES (@pid, 'Eksik Ölçüm', @mesaj)";

                    using (var alertCmd = new NpgsqlCommand(alertSql, conn))
                    {
                        alertCmd.Parameters.AddWithValue("pid", patientId);
                        alertCmd.Parameters.AddWithValue("mesaj", $"Bugün {dilim.ToLower()} saatlerinde ölçüm yapılmamış.");
                        alertCmd.ExecuteNonQuery();
                    }
                }

                // HİÇ ölçüm yapılmamışsa genel uyarı (ayrıca yazılabilir)
                if (!sabahVar && !ogleVar && !aksamVar)
                {
                    string alertSql = @"
                        INSERT INTO alerts (patient_id, alert_type, message)
                        VALUES (@pid, 'Eksik Ölçüm', 'Bugün hiç kan şekeri ölçümü yapılmadı.')";

                    using (var alertCmd = new NpgsqlCommand(alertSql, conn))
                    {
                        alertCmd.Parameters.AddWithValue("pid", patientId);
                        alertCmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void btnVeriGir_Click(object sender, EventArgs e)
        {
            GunlukVeriFormu veriForm = new GunlukVeriFormu(patientId);
            veriForm.ShowDialog();
        }
    }
}
