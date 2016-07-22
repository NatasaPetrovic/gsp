using Linije;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GSP
{
    public partial class Linije : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                result.Visible = true;
                Linija linija = new Linija();
                List<Linija> linije = linija.ListByID(DropDownList1.SelectedValue, DropDownList2.SelectedValue == "Dnevne linije" ? true : false);

                foreach (var item in linije)
                {
                    HtmlGenericControl div = new HtmlGenericControl();
                    div.Attributes["class"] = "col-md-12 margin";
                    div.TagName = "div";
                    result.Controls.Add(div);

                    HtmlGenericControl divNaziv = new HtmlGenericControl();
                    divNaziv.Attributes["class"] = "col-md-1 col-xs-2 col-sm-2 list-sub";
                    divNaziv.TagName = "div";
                    div.Controls.Add(divNaziv);

                    HtmlGenericControl aNaziv = new HtmlGenericControl();
                    aNaziv.Attributes["href"] = "LinijaOpis.aspx?linija=" + item.Naziv;
                    aNaziv.TagName = "a";
                    aNaziv.InnerHtml = item.Naziv;
                    divNaziv.Controls.Add(aNaziv);

                    HtmlGenericControl divOpis = new HtmlGenericControl();
                    divOpis.Attributes["class"] = "col-md-11 col-xs-10 col-sm-10 list-sub ellipsis";
                    divOpis.TagName = "div";
                    div.Controls.Add(divOpis);

                    HtmlGenericControl aOpis = new HtmlGenericControl();
                    aOpis.Attributes["href"] = "LinijaOpis.aspx?linija=" + item.Naziv;
                    aOpis.TagName = "a";
                    aOpis.InnerHtml = item.OpisLinije;
                    divOpis.Controls.Add(aOpis);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            result.Visible = true;
            result.Controls.Clear();

            Linija linija = new Linija();
            List<Linija> linije = linija.Filter(DropDownList1.SelectedValue, DropDownList2.SelectedValue == "Dnevne linije" ? true : false, TxtFilter.Text);

            foreach (var item in linije)
            {
                HtmlGenericControl div = new HtmlGenericControl();
                div.Attributes["class"] = "col-md-12 margin";
                div.TagName = "div";
                result.Controls.Add(div);

                HtmlGenericControl divNaziv = new HtmlGenericControl();
                divNaziv.Attributes["class"] = "col-md-1 col-xs-2 col-sm-2 list-sub";
                divNaziv.TagName = "div";
                div.Controls.Add(divNaziv);

                HtmlGenericControl aNaziv = new HtmlGenericControl();
                aNaziv.Attributes["href"] = "LinijaOpis.aspx?linija=" + item.Naziv;
                aNaziv.TagName = "a";
                aNaziv.InnerHtml = item.Naziv;
                divNaziv.Controls.Add(aNaziv);

                HtmlGenericControl divOpis = new HtmlGenericControl();
                divOpis.Attributes["class"] = "col-md-11 col-xs-10 col-sm-10 list-sub ellipsis";
                divOpis.TagName = "div";
                div.Controls.Add(divOpis);

                HtmlGenericControl aOpis = new HtmlGenericControl();
                aOpis.Attributes["href"] = "LinijaOpis.aspx?linija=" + item.Naziv;
                aOpis.TagName = "a";
                aOpis.InnerHtml = item.OpisLinije;
                divOpis.Controls.Add(aOpis);
            }
        }

       
    }
}