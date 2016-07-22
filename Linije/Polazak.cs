using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linije
{
    public class Polazak
    {
        #region Properties

        public int ID { get; set; }
        public int LinijaStajalisteID { get; set; }
        public string Vreme { get; set; }
        public string Dan { get; set; }
        #endregion

        public List<Polazak> RedVoznje(string linija, string smer, string dan, int vremeOd, int vremeDo)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GSPConnection"].ConnectionString);

            if (vremeOd == -1 && vremeDo == -1)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("listRedVoznjeByLinijaAndSmerAndDan", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@Linija", SqlDbType.VarChar, 5));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@Smer", SqlDbType.Char, 1));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@Dan", SqlDbType.VarChar, 8));

                adapter.SelectCommand.Parameters["@Linija"].Value = linija;
                adapter.SelectCommand.Parameters["@Smer"].Value = smer;
                adapter.SelectCommand.Parameters["@Dan"].Value = dan;

                DataSet ds = new DataSet();
                adapter.Fill(ds, "listRedVoznjeByLinijaAndSmerAndDan");

                List<Polazak> lista = new List<Polazak>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Polazak p = new Polazak();
                    p.Vreme = ds.Tables[0].Rows[i]["Vreme"].ToString();
                    lista.Add(p);
                }
                return lista;
            }
            else
            {
                if (vremeDo == -1)
                    vremeDo = 24;

                SqlDataAdapter adapter = new SqlDataAdapter("listRedVoznjeByVreme", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@Linija", SqlDbType.VarChar, 5));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@Smer", SqlDbType.Char, 1));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@Dan", SqlDbType.VarChar, 8));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@VremeOd", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@VremeDo", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@Linija"].Value = linija;
                adapter.SelectCommand.Parameters["@Smer"].Value = smer;
                adapter.SelectCommand.Parameters["@Dan"].Value = dan;
                adapter.SelectCommand.Parameters["@VremeOd"].Value = vremeOd;
                adapter.SelectCommand.Parameters["@VremeDo"].Value = vremeDo;

                DataSet ds = new DataSet();
                adapter.Fill(ds, "listRedVoznjeByVreme");

                List<Polazak> lista = new List<Polazak>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Polazak p = new Polazak();
                    p.Vreme = ds.Tables[0].Rows[i]["Vreme"].ToString();
                    lista.Add(p);
                }
                return lista;
            }


        }

       
    }
}
