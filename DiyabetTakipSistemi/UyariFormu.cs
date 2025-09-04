using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiyabetTakipSistemi
{
    public partial class UyariFormu : Form
    {
        public UyariFormu()
        {
            InitializeComponent();
            this.Load += UyariFormu_Load;
        }

        private void UyariFormu_Load(object sender, EventArgs e)
        {
            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Aa123456789.;Database=Diyabet_db";

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
                    SELECT a.alert_date AS ""Tarih"",
                           u.name || ' ' || u.surname AS ""Hasta"",
                           a.alert_type AS ""Uyarı Türü"",
                           a.message AS ""Açıklama""
                    FROM alerts a
                    JOIN patients p ON a.patient_id = p.patient_id
                    JOIN users u ON p.user_id = u.user_id
                    ORDER BY a.alert_date DESC";

                using (var da = new NpgsqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUyarilar.DataSource = dt;
                }
            }
        }

        private void dgvUyarilar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chkSadeceAcil_CheckedChanged(object sender, EventArgs e)
        {
            // Eğer sadece Acil Uyarı kutusu işaretliyse tekrar filtre uygula
            if (dgvUyarilar.DataSource == null) return;

            DataTable orijinal = (DataTable)dgvUyarilar.DataSource;
            DataView view = new DataView(orijinal);

            if (chkSadeceAcil.Checked)
                view.RowFilter = "[Uyarı Türü] LIKE '%Acil%'";
            else
                view.RowFilter = "";

            dgvUyarilar.DataSource = view;
        }
    }
}
