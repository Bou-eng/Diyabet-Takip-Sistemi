using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace DiyabetTakipSistemi
{
    public partial class YeniDoktorFormu : Form
    {
        private byte[] resimBytes = null;

        public YeniDoktorFormu()
        {
            InitializeComponent();
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
                    resimBytes = ms.ToArray();
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string tc = txtTc.Text.Trim();
            string sifre = MD5Hash(txtSifre.Text.Trim());
            string ad = txtAd.Text.Trim();
            string soyad = txtSoyad.Text.Trim();
            string email = txtEmail.Text.Trim();
            string cinsiyet = cmbCinsiyet.SelectedItem?.ToString() ?? "";
            DateTime dogum = dtpDogumTarihi.Value;

            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Aa123456789.;Database=Diyabet_db";

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                string sqlUser = @"
                    INSERT INTO users (tc_no, password, role, name, surname, email, gender, birth_date, profile_picture)
                    VALUES (@tc, @sifre, 'doctor', @ad, @soyad, @mail, @cinsiyet, @dogum, @resim)
                    RETURNING user_id";

                int userId;
                using (var cmd = new NpgsqlCommand(sqlUser, conn))
                {
                    cmd.Parameters.AddWithValue("tc", tc);
                    cmd.Parameters.AddWithValue("sifre", sifre);
                    cmd.Parameters.AddWithValue("ad", ad);
                    cmd.Parameters.AddWithValue("soyad", soyad);
                    cmd.Parameters.AddWithValue("mail", email);
                    cmd.Parameters.AddWithValue("cinsiyet", cinsiyet);
                    cmd.Parameters.AddWithValue("dogum", dogum);
                    cmd.Parameters.AddWithValue("resim", (object)resimBytes ?? DBNull.Value);

                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                string sqlDoctor = "INSERT INTO doctors (user_id) VALUES (@uid)";
                using (var cmd = new NpgsqlCommand(sqlDoctor, conn))
                {
                    cmd.Parameters.AddWithValue("uid", userId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Doktor başarıyla kaydedildi.");
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void YeniDoktorFormu_Load(object sender, EventArgs e)
        {
            cmbCinsiyet.Items.Clear();
            cmbCinsiyet.Items.Add("Erkek");
            cmbCinsiyet.Items.Add("Kadın");
            cmbCinsiyet.SelectedIndex = 0;
        }

    }
}
