using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;


namespace DiyabetTakipSistemi
{
    public partial class YeniHastaFormu : Form
    {
        private int doctorId;
        private byte[] profilResmiVerisi;

        public YeniHastaFormu(int gelenDoctorId)
        {
            InitializeComponent();
            doctorId = gelenDoctorId;
        }

        private void YeniHastaFormu_Load(object sender, EventArgs e)
        {
            cmbCinsiyet.Items.Clear();
            cmbCinsiyet.Items.Add("Erkek");
            cmbCinsiyet.Items.Add("Kadın");
            cmbCinsiyet.SelectedIndex = 0;
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
                    profilResmiVerisi = ms.ToArray(); // BYTEA olarak saklanacak
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Aa123456789.;Database=Diyabet_db";

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string tc = txtTc.Text.Trim();

                // TC kontrolü
                string kontrolSql = "SELECT user_id FROM users WHERE tc_no = @tc";
                using (var kontrolCmd = new NpgsqlCommand(kontrolSql, conn))
                {
                    kontrolCmd.Parameters.AddWithValue("tc", tc);
                    var existingUser = kontrolCmd.ExecuteScalar();

                    if (existingUser != null)
                    {
                        MessageBox.Show("Bu TC numarası zaten sistemde kayıtlı!", "Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Kullanıcının şifresi
                string orijinalSifre = txtSifre.Text.Trim();
                string hashliSifre = MD5Hash(orijinalSifre);
                int yeniUserId;

                // 1. USERS tablosuna ekle
                string insertUserSql = @"
            INSERT INTO users (tc_no, password, role, name, surname, email, gender, birth_date, profile_picture)
            VALUES (@tc, @sifre, 'patient', @ad, @soyad, @email, @cinsiyet, @dogum, @resim)
            RETURNING user_id";

                using (var cmd = new NpgsqlCommand(insertUserSql, conn))
                {
                    cmd.Parameters.AddWithValue("tc", tc);
                    cmd.Parameters.AddWithValue("sifre", hashliSifre);
                    cmd.Parameters.AddWithValue("ad", txtAd.Text.Trim());
                    cmd.Parameters.AddWithValue("soyad", txtSoyad.Text.Trim());
                    cmd.Parameters.AddWithValue("email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("cinsiyet", cmbCinsiyet.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("dogum", dtpDogumTarihi.Value.Date);
                    cmd.Parameters.AddWithValue("resim", (object)profilResmiVerisi ?? DBNull.Value);

                    yeniUserId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // 2. PATIENTS tablosuna ekle
                string insertPatientSql = "INSERT INTO patients (user_id, doctor_id) VALUES (@userId, @doctorId)";
                using (var cmd2 = new NpgsqlCommand(insertPatientSql, conn))
                {
                    cmd2.Parameters.AddWithValue("userId", yeniUserId);
                    cmd2.Parameters.AddWithValue("doctorId", doctorId);
                    cmd2.ExecuteNonQuery();
                }

                // 3. Mail gönder
                MailGonder(txtEmail.Text, txtAd.Text.Trim(), txtSoyad.Text.Trim(), tc, orijinalSifre);

                MessageBox.Show("Hasta başarıyla eklendi! Bilgilendirme e-postası gönderildi.", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void MailGonder(string aliciEmail, string ad, string soyad, string tc, string orijinalSifre)
        {
            try
            {
                MailMessage mesaj = new MailMessage();
                mesaj.From = new MailAddress("no-reply@diyabet.local", "Diyabet Takip Sistemi");
                mesaj.To.Add(aliciEmail);
                mesaj.Subject = "Diyabet Takip Sistemi - Giriş Bilgileri";

                string icerik = $"Merhaba {ad} {soyad},\n\n"
                              + "Sisteme kayıt işleminiz başarıyla tamamlandı.\n"
                              + $"TC Kimlik Numaranız: {tc}\n"
                              + $"Şifreniz: {orijinalSifre}\n\n"
                              + "İyi günler dileriz.";

                mesaj.Body = icerik;

                // Papercut SMTP ayarları
                SmtpClient smtp = new SmtpClient("localhost", 25);
                smtp.EnableSsl = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = true;

                smtp.Send(mesaj);
                MessageBox.Show("Test e-postası başarıyla gönderildi.", "Mail Gönderildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta gönderilemedi:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
