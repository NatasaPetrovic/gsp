using Linije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSP
{
    public partial class Pretraga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (check.Checked)
                pretragaStajaliste.Visible = true;

            else
                pretragaStajaliste.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            rezultat.Visible = true;
            List<Linija> linije = new List<Linija>();

            if (!check.Checked)
            {
                List<LinijaStajaliste> stajalisteOd = new List<LinijaStajaliste>();
                List<LinijaStajaliste> stajalisteDo = new List<LinijaStajaliste>();

                LinijaStajaliste ls = new LinijaStajaliste();
                stajalisteOd = ls.ListStajalisteByOpstinaName(DropDownList1.SelectedItem.ToString());
                stajalisteDo = ls.ListStajalisteByOpstinaName(DropDownList2.SelectedItem.ToString());

                foreach (var linijaStajaliste in stajalisteOd)
                {
                    foreach (Linija linija in linijaStajaliste.Linije)
                    {
                        foreach (var linijaStajalisteDo in stajalisteDo)
                        {
                            if (linijaStajalisteDo.Linije.Exists(x => x.Naziv == linija.Naziv) && !linije.Exists(x => x.Naziv == linija.Naziv))
                                linije.Add(linija);
                        }
                    }
                }
            }
            else
            {
                Linija l = new Linija();
                List<Linija> linijeOd = l.ListByStajaliste(DropDownList3.SelectedItem.ToString());
                List<Linija> linijeDo = l.ListByStajaliste(DropDownList4.SelectedItem.ToString());

                foreach (var item in linijeOd)
                {
                    if (linijeDo.Exists(x => x.Naziv == item.Naziv) && !linije.Exists(x => x.Naziv == item.Naziv))
                        linije.Add(item);
                }
            }
            spnAutobus.InnerHtml = "";
            spnTrolejbus.InnerHtml = "";
            spnTramvaj.InnerHtml = "";
            if (linije.Count != 0)
                foreach (var item in linije)
                    if (item.VrstaVozila == "autobus")
                        spnAutobus.InnerHtml += item.Naziv + " ";
                    else if (item.VrstaVozila == "tramvaj")
                        spnTramvaj.InnerHtml += item.Naziv + " ";
                    else
                        spnTrolejbus.InnerHtml += item.Naziv + " ";

            if (spnAutobus.InnerHtml == "")
                spnAutobus.InnerHtml = " -";
            if (spnTramvaj.InnerHtml == "")
                spnTramvaj.InnerHtml = " -";
            if (spnTrolejbus.InnerHtml == "")
                spnTrolejbus.InnerHtml = " -";
        }

        protected void check_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}