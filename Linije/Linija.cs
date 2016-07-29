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
        public List<Stajaliste> Ruta { get; set; }

       
        public List<Polazak> RedVoznje { get; set; }
        public List<Interval> Intervali { get; set; }
        #endregion

        public Linija()
        {
            Ruta = new List<Stajaliste>();
            RedVoznje = new List<Polazak>();
            Intervali = new List<Interval>();
        }
        public List<Linija> ListByID(string vrstaVozila, bool dnevna)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GSPConnection"].ConnectionString);

            SqlDataAdapter adapter = new SqlDataAdapter("listLinijaByID", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@VrstaVozila", SqlDbType.NVarChar, 10));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@Dnevna", SqlDbType.Bit));

            adapter.SelectCommand.Parameters["@VrstaVozila"].Value = vrstaVozila;
            adapter.SelectCommand.Parameters["@Dnevna"].Value = dnevna;

            connection.Open();

            DataSet ds = new DataSet();
            adapter.Fill(ds, "listLinijaByID");
            List<Linija> linije = new List<Linija>();



            if (ds.Tables[0].Rows.Count != 0)
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int vremePoluobrta;
                    if(ds.Tables[0].Rows[i]["VremePoluobrta"].ToString() != "" )
                        vremePoluobrta = Convert.ToInt32(ds.Tables[0].Rows[i]["VremePoluobrta"].ToString());
                    else
                        vremePoluobrta=0;

                    linije.Add(new Linija
                    {
                        Naziv = ds.Tables[0].Rows[i]["Naziv"].ToString(),
                        OpisLinije = ds.Tables[0].Rows[i]["OpisLinije"].ToString(),
                        Dnevna = ds.Tables[0].Rows[i]["Dnevna"].ToString() == "1"?true:false,
                        Status = ds.Tables[0].Rows[i]["Status"].ToString() == "1" ? true : false,
                        VremePoluobrta = vremePoluobrta,
                        ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString()),
                        VrstaLinije = ds.Tables[0].Rows[i]["VrstaLinije"].ToString(),
                        VrstaVozila = ds.Tables[0].Rows[i]["VrstaVozila"].ToString(),
                    });
                }

            connection.Close();
            return linije;
        }
        public List<Linija> Filter(string vrstaVozila, bool dnevna, string filter)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GSPConnection"].ConnectionString);

            SqlDataAdapter adapter = new SqlDataAdapter("filterLinija", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@VrstaVozila", SqlDbType.NVarChar, 10));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@Dnevna", SqlDbType.Bit));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@Filter", SqlDbType.NVarChar, 30));

            adapter.SelectCommand.Parameters["@VrstaVozila"].Value = vrstaVozila;
            adapter.SelectCommand.Parameters["@Dnevna"].Value = dnevna;
            adapter.SelectCommand.Parameters["@Filter"].Value = filter;

            connection.Open();

            DataSet ds = new DataSet();
            adapter.Fill(ds, "filterLinija");
            List<Linija> linije = new List<Linija>();

            if (ds.Tables[0].Rows.Count != 0)
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    linije.Add(new Linija
                    {
                        Naziv = ds.Tables[0].Rows[i]["Naziv"].ToString(),
                        OpisLinije = ds.Tables[0].Rows[i]["OpisLinije"].ToString()
                    });
                }

            connection.Close();
            return linije;
        }

        public void GetRuta(string smer)
        {
            if (Naziv != null)
            {
                Stajaliste stajaliste = new Stajaliste();
                Ruta = stajaliste.ListStajalisteByLinijaAndSmer(Naziv, smer);
            }
        }

        public List<Linija> ListByStajaliste(string stajaliste)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GSPConnection"].ConnectionString);

            SqlDataAdapter adapter = new SqlDataAdapter("listLinijaByStajaliste", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@Stajaliste", SqlDbType.NVarChar, 25));
            adapter.SelectCommand.Parameters["@Stajaliste"].Value = stajaliste;
            
            DataSet ds = new DataSet();
            adapter.Fill(ds, "listLinijaByStajaliste");
            List<Linija> linije = new List<Linija>();

            if (ds.Tables[0].Rows.Count != 0)

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)

                    linije.Add(new Linija { Naziv = ds.Tables[0].Rows[i]["Naziv"].ToString() });
			
            connection.Close();
            return linije;
            
        }

        public void GetRedVoznje(string smer, string dan)
        {
            Polazak polazak = new Polazak();
            RedVoznje = polazak.RedVoznje(Naziv, smer, dan,-1,-1);
        }

        public void GetIntervali()
        {
            Interval interval = new Interval();
            Intervali = interval.ListIntervalByLinija(Naziv);
        }
        public void GetInfo()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GSPConnection"].ConnectionString);

            SqlDataAdapter adapter = new SqlDataAdapter("getLinija", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@Linija", SqlDbType.NVarChar, 5));
            adapter.SelectCommand.Parameters["@Linija"].Value = Naziv;

            DataSet ds = new DataSet();
            adapter.Fill(ds, "getLinija");
            List<Linija> linije = new List<Linija>();

            if (ds.Tables[0].Rows.Count != 0)
            {
                OpisLinije = ds.Tables[0].Rows[0]["OpisLinije"].ToString();
                VrstaVozila = ds.Tables[0].Rows[0]["VrstaVozila"].ToString();
                VrstaLinije = ds.Tables[0].Rows[0]["VrstaLinije"].ToString();
                if (ds.Tables[0].Rows[0]["Dnevna"].ToString() == "1")
                    Dnevna = true;
                else
                    Dnevna = false;
                if (ds.Tables[0].Rows[0]["Status"].ToString() == "1")
                    Status = true;
                else
                    Status = false;
                if (ds.Tables[0].Rows[0]["VremePoluobrta"] != null)
                    VremePoluobrta = Convert.ToInt16(ds.Tables[0].Rows[0]["VremePoluobrta"].ToString());

            }

            connection.Close();
            
        }
        public bool InsertLinija()
        {
            if (Naziv != null && OpisLinije != null)
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GSPConnection"].ConnectionString);

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "insertLinija";
                command.Connection = connection;
                command.Parameters.Add("@Naziv", SqlDbType.VarChar, 5).Value = Naziv;
                command.Parameters.Add("@OpisLinije", SqlDbType.NVarChar, 50).Value = OpisLinije;
                command.Parameters.Add("@Dnevna", SqlDbType.Bit).Value = Dnevna;
                command.Parameters.Add("@Status", SqlDbType.Bit).Value = Status;
                command.Parameters.Add("@VremePoluobrta", SqlDbType.Int).Value = VremePoluobrta;
                command.Parameters.Add("@VrstaLinije", SqlDbType.VarChar,10).Value = VrstaLinije;
                command.Parameters.Add("@VrstaVozila", SqlDbType.VarChar, 10).Value = VrstaVozila;

                int res = command.ExecuteNonQuery();

                connection.Close();

                if (res == 1)
                    return true;
                else
                    return false;
            }
            else return false;
        }

        public bool UpdateLinija()
        {
            if (Naziv != null && OpisLinije != null)
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GSPConnection"].ConnectionString);

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "updateLinija";
                command.Connection = connection;
                command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                command.Parameters.Add("@Naziv", SqlDbType.VarChar, 5).Value = Naziv;
                command.Parameters.Add("@OpisLinije", SqlDbType.NVarChar, 50).Value = OpisLinije;
                command.Parameters.Add("@Dnevna", SqlDbType.Bit).Value = Dnevna;
                command.Parameters.Add("@Status", SqlDbType.Bit).Value = Status;
                command.Parameters.Add("@VremePoluobrta", SqlDbType.Int).Value = VremePoluobrta;
                command.Parameters.Add("@VrstaLinije", SqlDbType.VarChar, 10).Value = VrstaLinije;
                command.Parameters.Add("@VrstaVozila", SqlDbType.VarChar, 10).Value = VrstaVozila;

                int res = command.ExecuteNonQuery();

                connection.Close();

                if (res == 1)
                    return true;
                else
                    return false;
            }
            else return false;
        }

        public bool DeleteLinija()
        {
            if (ID != 0)
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GSPConnection"].ConnectionString);

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "deleteLinija";
                command.Connection = connection;
                command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

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
