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
        public int RedniBroj { get; set; }
                
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
                stajaliste.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                stajaliste.Naziv = ds.Tables[0].Rows[i]["Naziv"].ToString();
                stajaliste.Opstina = ds.Tables[0].Rows[i]["Opstina"].ToString();
                stajaliste.Naselje = ds.Tables[0].Rows[i]["Naselje"].ToString();
                stajaliste.Ulica = ds.Tables[0].Rows[i]["Ulica"].ToString();
                if (ds.Tables[0].Rows[i]["Zona"].ToString() != "")
                    stajaliste.Zona = Convert.ToInt16(ds.Tables[0].Rows[i]["Zona"].ToString());
                stajaliste.RedniBroj = Convert.ToInt16(ds.Tables[0].Rows[i]["RedniBroj"].ToString());

                stajalista.Add(stajaliste);
            }}


            return stajalista;
        }

        public bool InsertStajaliste(string linija, string smer)
        {
            if (Naziv != null && Naselje != null && Opstina != null && Ulica!=null && Zona != null)
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GSPConnection"].ConnectionString);

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "insertStajaliste";
                command.Connection = connection;
                command.Parameters.Add("@Naziv", SqlDbType.NVarChar, 50).Value = Naziv;
                command.Parameters.Add("@Ulica", SqlDbType.NVarChar, 50).Value = Ulica;
                command.Parameters.Add("@Naselje", SqlDbType.NVarChar, 30).Value = Naselje;
                command.Parameters.Add("@Opstina", SqlDbType.NVarChar, 30).Value = Opstina;
                command.Parameters.Add("@Zona", SqlDbType.SmallInt).Value = Zona;
                command.Parameters.Add("@Linija", SqlDbType.VarChar, 5).Value = linija;
                command.Parameters.Add("@Smer", SqlDbType.Char, 1).Value = smer;
                command.Parameters.Add("@RedniBroj", SqlDbType.SmallInt).Value = RedniBroj;
                
                int res = command.ExecuteNonQuery();

                connection.Close();

                if (res == 1)
                    return true;
                else
                    return false;
            }
            else return false;
        }

        public bool DeleteStajaliste(string linija, string smer)
        {
             SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GSPConnection"].ConnectionString);

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "deleteStajaliste";
                command.Connection = connection;
                command.Parameters.Add("@ID", SqlDbType.NVarChar, 50).Value = ID;
                command.Parameters.Add("@Linija", SqlDbType.VarChar, 5).Value = linija;
                command.Parameters.Add("@Smer", SqlDbType.Char, 1).Value = smer;
                
                int res = command.ExecuteNonQuery();

                connection.Close();

                if (res == 1)
                    return true;
                else
                    return false;
           
        }

        public bool UpdateStajaliste(string linija, string smer)
        {
            if (ID!= 0 && Naziv != null && Naselje != null && Opstina != null && Ulica != null && Zona != null)
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GSPConnection"].ConnectionString);

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "updateStajaliste";
                command.Connection = connection;
                command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                command.Parameters.Add("@Naziv", SqlDbType.NVarChar, 50).Value = Naziv;
                command.Parameters.Add("@Ulica", SqlDbType.NVarChar, 50).Value = Ulica;
                command.Parameters.Add("@Naselje", SqlDbType.NVarChar, 30).Value = Naselje;
                command.Parameters.Add("@Opstina", SqlDbType.NVarChar, 30).Value = Opstina;
                command.Parameters.Add("@Zona", SqlDbType.SmallInt).Value = Zona;
                command.Parameters.Add("@RedniBroj", SqlDbType.SmallInt).Value = RedniBroj;
                command.Parameters.Add("@Linija", SqlDbType.VarChar, 5).Value = linija;
                command.Parameters.Add("@Smer", SqlDbType.Char, 1).Value = smer;

                int res = command.ExecuteNonQuery();

                connection.Close();

                if (res == 1)
                    return true;
                else
                    return false;
            }
            else return false;
        }
    }
}
