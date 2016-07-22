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
    public class Interval
    {
        #region Properties

        public int ID { get; set; }
        public string VrsniInterval { get; set; }
        public string VanvrsniInterval { get; set; }
        public string Dan { get; set; }

        #endregion

         public List<Interval> ListIntervalByLinija(string linija)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GSPConnection"].ConnectionString);

                SqlDataAdapter adapter = new SqlDataAdapter("listIntervalByLinija", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@Linija", SqlDbType.VarChar, 5));
               
                adapter.SelectCommand.Parameters["@Linija"].Value = linija;
                

                DataSet ds = new DataSet();
                adapter.Fill(ds, "listIntervalByLinija");

                List<Interval> lista = new List<Interval>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Interval interval = new Interval();
                    interval.Dan = ds.Tables[0].Rows[i]["Dan"].ToString();
                    interval.VanvrsniInterval = ds.Tables[0].Rows[i]["VanvrsniInterval"].ToString();
                    interval.VrsniInterval = ds.Tables[0].Rows[i]["VrsniInterval"].ToString();
                    lista.Add(interval);
                }
                return lista;
            }
    }
}
