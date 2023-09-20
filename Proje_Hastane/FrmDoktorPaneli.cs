using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from TBLDOKTORLAR", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            // Branşı Combobox'a Aktarma

            SqlCommand komut2 = new SqlCommand("Select BRANSAD from TBLBRANSLAR", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLDOKTORLAR (DOKTORAD, DOKTORSOYAD, DOKTORBRANS, DOKTORTC, DOKTORSIFRE) values (@D1,@D2,@D3,@D4,@D5)", bgl.baglanti());
            komut.Parameters.AddWithValue("@D1", TxtAd.Text);
            komut.Parameters.AddWithValue("@D2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@D3", CmbBrans.Text);
            komut.Parameters.AddWithValue("@D4", MskTC.Text);
            komut.Parameters.AddWithValue("@D5", TxtSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskTC.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBLDOKTORLAR where DOKTORTC=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", MskTC.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBLDOKTORLAR set DOKTORAD=@D1,DOKTORSOYAD=@D2,DOKTORBRANS=@D3,DOKTORSIFRE=@D5 where DOKTORTC=@D4", bgl.baglanti());
            komut.Parameters.AddWithValue("@D1", TxtAd.Text);
            komut.Parameters.AddWithValue("@D2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@D3", CmbBrans.Text);
            komut.Parameters.AddWithValue("@D4", MskTC.Text);
            komut.Parameters.AddWithValue("@D5", TxtSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
