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
        public string Ulica { get; set; }
        public string Opstina { get; set; }
        public string Naselje { get; set; }
        public int UlicaID { get; set; }
        public int Zona { get; set; }
                
        #endregion

        public List<Stajaliste> ListStajalisteByLinijaAndSmer(string linija, string smer)
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
            List<Stajaliste> stajalista = new List<Stajaliste>();

            if(ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
                Stajaliste stajaliste = new Stajaliste();
                stajaliste.Naziv = ds.Tables[0].Rows[i]["Naziv"].ToString();
                stajaliste.Opstina = ds.Tables[0].Rows[i]["Opstina"].ToString();
                stajaliste.Naselje = ds.Tables[0].Rows[i]["Naselje"].ToString();
                stajaliste.Ulica = ds.Tables[0].Rows[i]["Ulica"].ToString();

                stajalista.Add(stajaliste);
            }}


            return stajalista;
        }

       
       

        
    }
}
