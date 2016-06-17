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
    public class Linija
    {
        #region Properties

        public int ID { get; set; }
        public string Naziv { get; set; }
        public string OpisLinije { get; set; }
        public string VrstaVozila { get; set; }
        public string VrstaLinije { get; set; }
        public bool Dnevna { get; set; }
        public bool Status { get; set; }
        public int VremePoluobrta { get; set; }

        #endregion


        public DataSet ListByID(string vrstaVozila, bool dnevna)
        {
            
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GSPConnection"].ConnectionString);

            SqlDataAdapter adapter = new SqlDataAdapter("listLinijaByID", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@VrstaVozila", SqlDbType.NVarChar, 10));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@Dnevna", SqlDbType.Bit));

            adapter.SelectCommand.Parameters["@VrstaVozila"].Value = vrstaVozila;
            adapter.SelectCommand.Parameters["@Dnevna"].Value = dnevna;

            DataSet ds = new DataSet();
            adapter.Fill(ds, "listLinijaByID");

            return ds;
        }
    }
}
