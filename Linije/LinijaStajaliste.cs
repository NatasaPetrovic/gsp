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
    public class LinijaStajaliste
    {
        #region Properties

        public int ID { get; set; }
        public List<Linija> Linije { get; set; }
        public List<Stajaliste> Stajalista { get; set; }
        public char Smer { get; set; }
        public int RedniBroj { get; set; }

        #endregion
        public LinijaStajaliste()
        {
            Linije = new List<Linija>();
            Stajalista = new List<Stajaliste>();
        }
        public List<LinijaStajaliste> ListStajalisteByOpstinaName(string opstina)
        {

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GSPConnection"].ConnectionString);

            SqlDataAdapter adapter = new SqlDataAdapter("listStajalisteByOpstinaName", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@Opstina", SqlDbType.NVarChar, 20));

            adapter.SelectCommand.Parameters["@Opstina"].Value = opstina;

            DataSet ds = new DataSet();
            adapter.Fill(ds, "listStajalisteByOpstinaName");

            List<LinijaStajaliste> stajalista = new List<LinijaStajaliste>();

            if (ds.Tables[0].Rows.Count != 0)
            {
                LinijaStajaliste ls = new LinijaStajaliste();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ls.Linije.Add(new Linija { Naziv = ds.Tables[0].Rows[i]["Linija"].ToString().TrimEnd(),
                                               VrstaVozila = ds.Tables[0].Rows[i]["VrstaVozila"].ToString().TrimEnd()
                    });
                    ls.Stajalista.Add(new Stajaliste
                    {
                        ID = Convert.ToInt16(ds.Tables[0].Rows[i]["ID"].ToString()),
                        Naziv = ds.Tables[0].Rows[i]["Naziv"].ToString().TrimEnd(),
                        UlicaID = Convert.ToInt16(ds.Tables[0].Rows[i]["UlicaID"].ToString())
                    });
                    ls.Smer = Convert.ToChar(ds.Tables[0].Rows[i]["Smer"].ToString());
                    ls.RedniBroj = Convert.ToChar(ds.Tables[0].Rows[i]["RedniBroj"].ToString());

                    stajalista.Add(ls);
                }
                  
            }

            return stajalista;

        }
    }
}
