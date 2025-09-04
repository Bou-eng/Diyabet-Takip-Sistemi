using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DiyabetTakipSistemi
{
    public partial class DoktorGuncelleFormu : Form
    {
        private int userId = -1;
        private int doctorId = -1;
        private byte[] profilResmiVerisi = null;

        public DoktorGuncelleFormu()
        {
            InitializeComponent();
        }

        private void DoktorGuncelleFormu_Load(object sender, EventArgs e)
        {
            cmbCinsiyet.Items.Clear();
            cmbCinsiyet.Items.Add("Erkek");
            cmbCinsiyet.Items.Add("Kadın");
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string tc = txtTc.Text.Trim();
            if (string.IsNullOrEmpty(tc))
            {
                MessageBox.Show("Lütfen bir TC numarası girin.");
                return;
            }

            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Aa123456789.;Database=Diyabet_db";

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
                    SELECT u.user_id, d.doctor_id, u.name, u.surname, u.email, u.gender, u.birth_date, u.profile_picture
                    FROM users u
                    JOIN doctors d ON u.user_id = d.user_id
                    WHERE u.tc_no = @tc AND u.role = 'doctor'";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("tc", tc);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userId = reader.GetInt32(0);
                            doctorId = reader.GetInt32(1);
                            txtAd.Text = reader.GetString(2);
                            txtSoyad.Text = reader.GetString(3);
                            txtEmail.Text = reader.GetString(4);
                            cmbCinsiyet.SelectedItem = reader.GetString(5);
                            dtpDogumTarihi.Value = reader.GetDateTime(6);

                            if (!reader.IsDBNull(7))
                            {
                                byte[] imgData = (byte[])reader[7];
                                using (MemoryStream ms = new MemoryStream(imgData))
                                {
                                    pictureBox1.Image = Image.FromStream(ms);
                                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                    profilResmiVerisi = imgData;
                                }
                            }
                            else
                            {
                                pictureBox1.Image = null;
                                profilResmiVerisi = null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Bu TC numarasına sahip doktor bulunamadı.");
                        }
                    }
                }
            }
        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(ofd.FileName);
                pictureBox1.Image = img;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, img.RawFormat);
                    profilResmiVerisi = ms.ToArray();
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (userId == -1)
            {
                MessageBox.Show("Lütfen önce bir doktor arayın.");
                return;
            }

            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Aa123456789.;Database=Diyabet_db";

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                string sql;

                if (!string.IsNullOrWhiteSpace(txtYeniSifre.Text))
                {
                    sql = @"
                    UPDATE users
                    SET name = @ad,
                        surname = @soyad,
                        email = @mail,
                        gender = @cinsiyet,
                        birth_date = @dogum,
                        profile_picture = @resim,
                        password = @sifre
                    WHERE user_id = @uid";
                }
                else
                {
                    sql = @"
                    UPDATE users
                    SET name = @ad,
                        surname = @soyad,
                        email = @mail,
                        gender = @cinsiyet,
                        birth_date = @dogum,
                        profile_picture = @resim
                    WHERE user_id = @uid";
                }

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("ad", txtAd.Text.Trim());
                    cmd.Parameters.AddWithValue("soyad", txtSoyad.Text.Trim());
                    cmd.Parameters.AddWithValue("mail", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("cinsiyet", cmbCinsiyet.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("dogum", dtpDogumTarihi.Value.Date);
                    cmd.Parameters.AddWithValue("resim", (object)profilResmiVerisi ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("uid", userId);

                    if (!string.IsNullOrWhiteSpace(txtYeniSifre.Text))
                    {
                        string yeniHash = MD5Hash(txtYeniSifre.Text.Trim());
                        cmd.Parameters.AddWithValue("sifre", yeniHash);
                    }

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Doktor bilgileri başarıyla güncellendi.");
                this.Close();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (userId == -1 || doctorId == -1)
            {
                MessageBox.Show("Lütfen önce bir doktor arayın.");
                return;
            }

            var onay = MessageBox.Show("Bu doktoru tamamen silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (onay != DialogResult.Yes) return;

            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Aa123456789.;Database=Diyabet_db";

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                string delDoctor = "DELETE FROM doctors WHERE doctor_id = @did";
                using (var cmd = new NpgsqlCommand(delDoctor, conn))
                {
                    cmd.Parameters.AddWithValue("did", doctorId);
                    cmd.ExecuteNonQuery();
                }

                string delUser = "DELETE FROM users WHERE user_id = @uid";
                using (var cmd = new NpgsqlCommand(delUser, conn))
                {
                    cmd.Parameters.AddWithValue("uid", userId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Doktor başarıyla silindi.");
                this.Close();
            }
        }

        private string MD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtYeniSifre.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
