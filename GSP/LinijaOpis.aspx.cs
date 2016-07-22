using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Linije;
using System.Data;
using System.Web.UI.HtmlControls;

namespace GSP
{
    public partial class LinijaOpis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string smer;
            if (DropDownList1.SelectedValue == "")
                smer = "A";
            else
                smer = DropDownList1.SelectedValue;

            Linija linija = new Linija();
            linija.Naziv = Request.QueryString["linija"];

            linija.GetInfo();

            DivNaziv.InnerHtml = linija.Naziv + " " + linija.OpisLinije;

            linija.GetRedVoznje(smer, DropDownList2.SelectedValue);

            foreach (var polazak in linija.RedVoznje)
            {
                HtmlGenericControl divPolazak = new HtmlGenericControl();
                divPolazak.TagName = "div";
                divPolazak.Attributes["class"] = "col-md-2 col-sm-2 col-xs-2 list-sub center";
                divPolazak.InnerHtml = polazak.Vreme;
                Polasci.Controls.Add(divPolazak);
            }

            linija.GetRuta(smer);

            foreach (var item in linija.Ruta)
            {
                HtmlGenericControl divRuta = new HtmlGenericControl();
                divRuta.TagName = "div";
                divRuta.Attributes["class"] = "col-md-12 col-sm-12 col-xs-12 list-sub";
                divRuta.InnerHtml = item.Naziv;
                Stajalista.Controls.Add(divRuta);
            }
        }
    }
}