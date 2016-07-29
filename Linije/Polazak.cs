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
                    p.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                    p.LinijaStajalisteID = Convert.ToInt32(ds.Tables[0].Rows[i]["LinijaStajalisteID"].ToString());
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

        public bool DeletePolazak()
        {
            if (ID != 0)
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GSPConnection"].ConnectionString);

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "deletePolazak";
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

        public bool UpdatePolazak()
        {
            if (ID != 0 && Vreme != null)
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GSPConnection"].ConnectionString);

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "updatePolazak";
                command.Connection = connection;
                command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                command.Parameters.Add("@Vreme", SqlDbType.VarChar, 5).Value = Vreme;

                int res = command.ExecuteNonQuery();

                connection.Close();

                if (res == 1)
                    return true;
                else
                    return false;
            }
            else return false;

        }

        public bool InsertPolazak()
        {
            if (Vreme != null && Dan != null && LinijaStajalisteID != 0)
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GSPConnection"].ConnectionString);

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "insertPolazak";
                command.Connection = connection;
                command.Parameters.Add("@Vreme", SqlDbType.VarChar, 5).Value = Vreme;
                command.Parameters.Add("@Dan", SqlDbType.VarChar, 8).Value = Dan;
                command.Parameters.Add("@LinijaStajalisteID", SqlDbType.Int).Value = LinijaStajalisteID;

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
