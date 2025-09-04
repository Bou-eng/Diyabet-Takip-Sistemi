using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace DiyabetTakipSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbRol.Items.Clear();
            cmbRol.Items.Add("doctor");
            cmbRol.Items.Add("patient");
            cmbRol.SelectedIndex = 0;
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
                    sb.Append(b.ToString("x2")); // hex format
                }

                return sb.ToString();
            }
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Aa123456789.;Database=Diyabet_db";

            using (var conn = new NpgsqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string tc = txtTc.Text.Trim();
                    string sifre = txtSifre.Text.Trim();
                    string rol = cmbRol.SelectedItem.ToString();
                    string hashliSifre = MD5Hash(sifre);

                    string sql = "SELECT role FROM users WHERE tc_no = @tc AND password = @sifre AND role = @rol";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("tc", tc);
                        cmd.Parameters.AddWithValue("sifre", hashliSifre);
                        cmd.Parameters.AddWithValue("rol", rol);

                        var result = cmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("TC, şifre veya rol yanlış!", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (rol == "doctor")
                        {
                            string idSorgu = @"
                                SELECT d.doctor_id, u.user_id
                                FROM doctors d
                                JOIN users u ON d.user_id = u.user_id
                                WHERE u.tc_no = @tc";

                            using (var cmd2 = new NpgsqlCommand(idSorgu, conn))
                            {
                                cmd2.Parameters.AddWithValue("tc", tc);

                                using (var reader = cmd2.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        int doctorId = reader.GetInt32(0);
                                        int userId = reader.GetInt32(1);

                                        MessageBox.Show("Doktor paneline yönlendiriliyor...", "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Hide();
                                        DoktorPaneli doktorForm = new DoktorPaneli(doctorId, userId);
                                        doktorForm.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Doktor ID bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                        else if (rol == "patient")
                        {
                            string idSorgu = @"
                                SELECT p.patient_id, u.user_id
                                FROM patients p
                                JOIN users u ON p.user_id = u.user_id
                                WHERE u.tc_no = @tc";

                            using (var cmd2 = new NpgsqlCommand(idSorgu, conn))
                            {
                                cmd2.Parameters.AddWithValue("tc", tc);

                                using (var reader = cmd2.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        int patientId = reader.GetInt32(0);
                                        int userId = reader.GetInt32(1);

                                        MessageBox.Show("Hasta paneline yönlendiriliyor...", "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Hide();
                                        HastaPaneli hastaForm = new HastaPaneli(patientId, userId);
                                        hastaForm.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Hasta ID bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDoktorEkle_Click(object sender, EventArgs e)
        {
            YeniDoktorFormu doktorForm = new YeniDoktorFormu();
            doktorForm.ShowDialog();
        }

        private void btnDoktorGuncelle_Click(object sender, EventArgs e)
        {
            DoktorGuncelleFormu form = new DoktorGuncelleFormu();
            form.ShowDialog();
        }

    }
}
