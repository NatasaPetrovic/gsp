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
    public class Stajaliste
    {
        #region Properties

        public int ID { get; set; }
        public string Naziv { get; set; }
       
        //public string GeoSirina { get; set; }
        //public string GeoDuzina { get; set; }
        public int UlicaID { get; set; }
        public int Zona { get; set; }
                
        #endregion

        public DataSet ListStajalisteByLinijaAndSmer(string linija, string smer)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GSPConnection"].ConnectionString);

            SqlDataAdapter adapter = new SqlDataAdapter("listStajalisteByLinijaAndSmer", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@Linija", SqlDbType.VarChar, 5));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@Smer", SqlDbType.Char, 1));

            adapter.SelectCommand.Parameters["@Linija"].Value = linija;
            adapter.SelectCommand.Parameters["@Smer"].Value = smer;

            DataSet ds = new DataSet();
            adapter.Fill(ds, "listStajalisteByLinijaAndSmer");

            return ds;
        }

        
    }
}
