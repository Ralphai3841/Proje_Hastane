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
    public partial class FrmBilgiDüzenle : Form
    {
        public FrmBilgiDüzenle()
        {
            InitializeComponent();
        }

        public string TCno;

        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmBilgiDüzenle_Load(object sender, EventArgs e)
        {
            MskTC.Text = TCno;
            SqlCommand komut = new SqlCommand("select * from TBLHASTALAR where HASTATC=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", MskTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                MskTelefon.Text = dr[4].ToString();
                TxtSifre.Text = dr[5].ToString();
                CmbCinsiyet.Text = dr[6].ToString();
            }
            bgl.baglanti().Close();
        }

        private void BtnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update TBLHASTALAR set HASTAAD=@P1, HASTASOYAD=@P2, HASTATELEFON=@P3, HASTASIFRE=@P4, HASTACINSIYET=@P5 where HASTATC=@P6", bgl.baglanti());
            komut2.Parameters.AddWithValue("@P1", TxtAd.Text);
            komut2.Parameters.AddWithValue("@P2", TxtSoyad.Text);
            komut2.Parameters.AddWithValue("@P3", MskTelefon.Text);
            komut2.Parameters.AddWithValue("@P4", TxtSifre.Text);
            komut2.Parameters.AddWithValue("@P5", CmbCinsiyet.Text);
            komut2.Parameters.AddWithValue("@P6", MskTC.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
