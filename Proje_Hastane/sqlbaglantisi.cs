using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-FB9086OP;Initial Catalog=HastaneProjesi;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
