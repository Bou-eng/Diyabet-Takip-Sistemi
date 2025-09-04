using Npgsql;
using System;
using System.Windows.Forms;

namespace DiyabetTakipSistemi
{
    public partial class TurAtamaFormu : Form
    {
        private string tcNo;
        private int patientId;

        public TurAtamaFormu(string gelenTc)
        {
            InitializeComponent();
            tcNo = gelenTc;
        }

        private void TurAtamaFormu_Load(object sender, EventArgs e)
        {
            cmbDiyet.Items.AddRange(new string[] {
                "Şekersiz", "Az Şekerli", "Dengeli", "Protein Ağırlıklı"
            });

            cmbEgzersiz.Items.AddRange(new string[] {
                "Yürüyüş", "Klinik Egzersiz", "Yok", "Hafif Kardiyo"
            });

            cmbDiyet.SelectedIndex = 0;
            cmbEgzersiz.SelectedIndex = 0;

            lblTc.Text = "TC: " + tcNo;

            // Veritabanından hasta ID'sini al
            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Aa123456789.;Database=Diyabet_db";

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
                    SELECT p.patient_id
                    FROM patients p
                    JOIN users u ON u.user_id = p.user_id
                    WHERE u.tc_no = @tc";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("tc", tcNo);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        patientId = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Hasta bulunamadı.");
                        this.Close();
                    }
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string secilenDiyet = cmbDiyet.SelectedItem.ToString();
            string secilenEgzersiz = cmbEgzersiz.SelectedItem.ToString();

            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Aa123456789.;Database=Diyabet_db";

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
                    UPDATE patients
                    SET diet_type = @diyet,
                        exercise_type = @egzersiz
                    WHERE patient_id = @pid";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("diyet", secilenDiyet);
                    cmd.Parameters.AddWithValue("egzersiz", secilenEgzersiz);
                    cmd.Parameters.AddWithValue("pid", patientId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Diyet ve egzersiz türleri başarıyla atandı.");
                this.Close();
            }
        }
    }
}
