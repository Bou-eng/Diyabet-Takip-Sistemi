using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Npgsql;

namespace DiyabetTakipSistemi
{
    public partial class DoktorPaneli : Form
    {
        private int doctorId;
        private int userId;

        public DoktorPaneli(int gelenDoctorId, int gelenUserId)
        {
            InitializeComponent();
            doctorId = gelenDoctorId;
            userId = gelenUserId;
        }

        private void DoktorPaneli_Load(object sender, EventArgs e)
        {
            this.Text = "Doktor Paneli";
            dgvHastalar.Visible = false;
            MessageBox.Show("Doktor paneline hoş geldiniz!");

            // Doktor ismi ve profil resmi çekilir
            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Aa123456789.;Database=Diyabet_db";

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

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
                            lblIsim.Text = "Dr. " + ad + " " + soyad;

                            if (!reader.IsDBNull(2))
                            {
                                byte[] imgBytes = (byte[])reader[2];
                                using (MemoryStream ms = new MemoryStream(imgBytes))
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
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Aa123456789.;Database=Diyabet_db";

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
                    SELECT u.name AS Ad, u.surname AS Soyad, u.tc_no AS TCKimlik, u.email AS Email
                    FROM patients p
                    JOIN users u ON p.user_id = u.user_id
                    WHERE p.doctor_id = @doctorId";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("doctorId", doctorId);

                    using (var da = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvHastalar.DataSource = dt;
                        dgvHastalar.Visible = true;
                    }
                }
            }
        }

        private void btnYeniHasta_Click(object sender, EventArgs e)
        {
            YeniHastaFormu yeniForm = new YeniHastaFormu(doctorId);
            yeniForm.ShowDialog();
        }

        private void dgvHastalar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string tcNo = dgvHastalar.Rows[e.RowIndex].Cells["TCKimlik"].Value.ToString();
                HastaDetayFormu detayForm = new HastaDetayFormu(tcNo);
                detayForm.ShowDialog();
            }
        }

        private void btnUyarilar_Click(object sender, EventArgs e)
        {
            UyariFormu form = new UyariFormu();
            form.ShowDialog();
        }

        private void btnHastaGuncelle_Click(object sender, EventArgs e)
        {
            HastaGuncelleFormu form = new HastaGuncelleFormu();
            form.ShowDialog();
        }

        private void btnTurAta_Click(object sender, EventArgs e)
        {
            if (dgvHastalar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir hasta seçin.");
                return;
            }

            string tcNo = dgvHastalar.SelectedRows[0].Cells["TCKimlik"].Value.ToString();
            TurAtamaFormu form = new TurAtamaFormu(tcNo);
            form.ShowDialog();
        }

        private void btnUyarilariTemizle_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Tüm uyarılar silinecek. Devam etmek istiyor musunuz?",
                "Uyarı Temizleme",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Aa123456789.;Database=Diyabet_db";

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
            DELETE FROM alerts
            WHERE patient_id IN (
                SELECT patient_id
                FROM patients
                WHERE doctor_id = @did
            )";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("did", doctorId);
                    int count = cmd.ExecuteNonQuery();
                    MessageBox.Show($"{count} uyarı silindi.", "İşlem Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
}