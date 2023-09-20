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
    public partial class FrmHastaKayıt : Form
    {
        public FrmHastaKayıt()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLHASTALAR (HASTAAD,HASTASOYAD,HASTATC,HASTATELEFON,HASTASIFRE,HASTACINSIYET) values (@P1,@P2,@P3,@P4,@P5,@P6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@P3", MskTC.Text);
            komut.Parameters.AddWithValue("@P4", MskTelefon.Text);
            komut.Parameters.AddWithValue("@P5", TxtSifre.Text);
            komut.Parameters.AddWithValue("@P6", CmbCinsiyet.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Gerçekleşmiştir Şifreniz" + TxtSifre.Text , "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }
    }
}
