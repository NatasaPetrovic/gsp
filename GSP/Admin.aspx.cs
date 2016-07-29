using Linije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSP
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserAuthentication"] == null)
            //    Response.Redirect("Login.aspx");
            //else
            //    GridView1.DataBind();
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            BindRedVoznje();
            BindLinije();
        }

        private void BindLinije()
        {
            Linija linija = new Linija();
            List<Linija> linije = linija.ListByID(DdlVrstaVozila.SelectedValue, DdlDnevna.SelectedValue == "Dnevna" ? true : false);

            GvLinije.DataSource = linije;
            GvLinije.DataBind();
        }
        private void BindRedVoznje()
        {
            Polazak polazak = new Polazak();
            string linija;
            if (DdlLinije.SelectedValue == "")
                linija = "5";
            else
                linija = DdlLinije.SelectedValue;

            List<Polazak> redVoznje = polazak.RedVoznje(linija, DdlSmer.SelectedValue, DdlDan.SelectedValue, -1, -1);

            if (redVoznje.Count != 0)
                LinijaStajaliste.Value = redVoznje[0].LinijaStajalisteID.ToString();

            GvRedVoznje.DataSource = redVoznje;
            GvRedVoznje.DataBind();
        }

        private void BindStajalista()
        {
            Linija linija = new Linija();
            linija.Naziv = HiddenlLinija.Value;
            linija.GetRuta(DdlSmer.SelectedValue);

            GvStajalista.DataSource = linija.Ruta;
            GvStajalista.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GvRedVoznje.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Polazak polazak = new Polazak();
            Label lblID = (Label) GvRedVoznje.Rows[e.RowIndex].FindControl("lblID");
            polazak.ID = Convert.ToInt32(lblID.Text);

            if (polazak.DeletePolazak())
                LblRedVoznje.Text = "Podatak je izbrisan";
            else
                LblRedVoznje.Text = "Greska pri brisanju";
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                Polazak polazak = new Polazak();

                TextBox txtVreme = (TextBox) GvRedVoznje.FooterRow.FindControl("txtVreme");
                polazak.Vreme = txtVreme.Text;

                polazak.LinijaStajalisteID = Convert.ToInt32(LinijaStajaliste.Value);
                polazak.Dan = DdlDan.SelectedValue;

                if (polazak.InsertPolazak())
                    LblRedVoznje.Text = "Uspesno ste uneli podatak";
                else
                    LblRedVoznje.Text = "Greska pri unosu";
            }

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvRedVoznje.EditIndex = e.NewEditIndex;
            BindRedVoznje();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvRedVoznje.EditIndex = -1;
            GvRedVoznje.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Polazak polazak = new Polazak();
            Label lblID = (Label) GvRedVoznje.Rows[e.RowIndex].FindControl("lblID");
            polazak.LinijaStajalisteID = Convert.ToInt32(lblID.Text);
            TextBox txtVreme = (TextBox) GvRedVoznje.Rows[e.RowIndex].FindControl("TextBox1");
            polazak.Vreme = txtVreme.Text;

            if (polazak.UpdatePolazak())
                LblRedVoznje.Text = "Podatak je izmenjen";
            else
                LblRedVoznje.Text = "Greska pri izmeni";
            GvRedVoznje.EditIndex = -1;
            GvRedVoznje.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (sender != null)
            {
                GridView gridView = sender as GridView;
                gridView.PageIndex = e.NewPageIndex;
                gridView.DataBind();
            }
        }

        protected void GvLinije_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvLinije.EditIndex = e.NewEditIndex;
            BindLinije();
        }

        protected void GvLinije_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Linija linija = new Linija();
            Label lblID = (Label)GvLinije.Rows[e.RowIndex].FindControl("LblID");
            linija.ID = Convert.ToInt32(lblID.Text);

            TextBox txtNaziv = (TextBox)GvLinije.Rows[e.RowIndex].FindControl("TxtNazivEdit");
            linija.Naziv = txtNaziv.Text;

            TextBox txtOpisLinije = (TextBox)GvLinije.Rows[e.RowIndex].FindControl("TxtOpisLinijeEdit");
            linija.OpisLinije = txtOpisLinije.Text;

            DropDownList ddlDnevna = (DropDownList)GvLinije.Rows[e.RowIndex].FindControl("DdlDnevnaEdit");
            linija.Dnevna = ddlDnevna.SelectedValue == "True" ? true : false;

            DropDownList ddlStatus = (DropDownList)GvLinije.Rows[e.RowIndex].FindControl("DdlStatusEdit");
            linija.Status = ddlStatus.SelectedValue == "True" ? true : false;

            TextBox txtVremePoluobrta = (TextBox)GvLinije.Rows[e.RowIndex].FindControl("TxtVremePoluobrtaEdit");
            linija.VremePoluobrta = Convert.ToInt32(txtVremePoluobrta.Text);

            DropDownList ddlVrstaLinije = (DropDownList)GvLinije.Rows[e.RowIndex].FindControl("DdlVrstaLinijeEdit");
            linija.VrstaLinije = ddlVrstaLinije.SelectedValue;

            DropDownList ddlVrstaVozila = (DropDownList)GvLinije.Rows[e.RowIndex].FindControl("DdlVrstaVozilaEdit");
            linija.VrstaVozila = ddlVrstaVozila.SelectedValue;

            if (linija.UpdateLinija())
                LblRedVoznje.Text = "Podatak je izmenjen";
            else
                LblRedVoznje.Text = "Greska pri izmeni";
            GvLinije.EditIndex = -1;
            GvLinije.DataBind();
        }

        protected void GvLinije_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Linija linija = new Linija();
            Label lblID = (Label)GvLinije.Rows[e.RowIndex].FindControl("LblID");
            linija.ID = Convert.ToInt32(lblID.Text);

            if (linija.DeleteLinija())
                LblRedVoznje.Text = "Podatak je izbrisan";
            else
                LblRedVoznje.Text = "Greska pri brisanju";
        }

        protected void GvLinije_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                Linija linija = new Linija();

                TextBox txtNaziv = (TextBox)GvLinije.FooterRow.FindControl("TxtNaziv");
                linija.Naziv = txtNaziv.Text;

                TextBox txtOpisLinije = (TextBox)GvLinije.FooterRow.FindControl("TxtOpisLinije");
                linija.OpisLinije = txtOpisLinije.Text;

                DropDownList ddlDnevna = (DropDownList)GvLinije.FooterRow.FindControl("DdlDnevnaInsert");
                linija.Dnevna = ddlDnevna.SelectedValue == "True" ? true : false;

                DropDownList ddlStatus = (DropDownList)GvLinije.FooterRow.FindControl("DdlStatusInsert");
                linija.Status = ddlStatus.SelectedValue == "True" ? true : false;

                TextBox txtVremePoluobrta = (TextBox)GvLinije.FooterRow.FindControl("TxtVremePoluobrta");
                linija.VremePoluobrta = Convert.ToInt32(txtVremePoluobrta.Text);

                DropDownList ddlVrstaLinije = (DropDownList)GvLinije.FooterRow.FindControl("DdlVrstaLinijeInsert");
                linija.VrstaLinije = ddlVrstaLinije.SelectedValue;

                DropDownList ddlVrstaVozila = (DropDownList)GvLinije.FooterRow.FindControl("DdlVrstaVozilaInsert");
                linija.VrstaVozila = ddlVrstaVozila.SelectedValue;

                if (linija.InsertLinija())
                    LblRedVoznje.Text = "Podatak je izmenjen";
                else
                    LblRedVoznje.Text = "Greska pri izmeni";

                GvLinije.EditIndex = -1;
                GvLinije.DataBind();
            }
        }

        protected void GvLinije_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvLinije.EditIndex = -1;
            GvLinije.DataBind();
        }

        protected void GvLinije_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (sender != null)
            {
                GridView gridView = sender as GridView;
                gridView.PageIndex = e.NewPageIndex;
                gridView.DataBind();
            }
        }

        protected void BtnLinije_Click(object sender, EventArgs e)
        {
            GvLinije.DataBind();
        }

        protected void GvLinije_DataBound(object sender, EventArgs e)
        {

        }

        protected void BtnShowFooterLinije_Click(object sender, EventArgs e)
        {
            GvLinije.ShowFooter = true;
        }

        protected void BtnShowFooterRedVoznje_Click(object sender, EventArgs e)
        {
            GvRedVoznje.ShowFooter = true;
        }

        protected void GvLinije_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label lblNaziv = (Label)GvLinije.SelectedRow.FindControl("LblNaziv");
            string linija = lblNaziv.Text;
            HiddenlLinija.Value = linija;

            BindStajalista();
        }

        protected void GvStajalista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (sender != null)
            {
                GridView gridView = sender as GridView;
                gridView.PageIndex = e.NewPageIndex;
                BindStajalista();
            }
        }

        protected void GvStajalista_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvStajalista.EditIndex = -1;
            BindStajalista();
        }

        protected void GvStajalista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                Stajaliste stajaliste = new Stajaliste();

                TextBox txtNaziv = (TextBox)GvStajalista.FooterRow.FindControl("txtNazivInsert");
                stajaliste.Naziv = txtNaziv.Text;

                TextBox txtUlica = (TextBox)GvStajalista.FooterRow.FindControl("txtUlicaInsert");
                stajaliste.Ulica = txtUlica.Text;

                TextBox txtNaselje = (TextBox)GvStajalista.FooterRow.FindControl("txtNaseljeInsert");
                stajaliste.Naselje = txtNaselje.Text;

                TextBox txtOpstina = (TextBox)GvStajalista.FooterRow.FindControl("txtOpstinaInsert");
                stajaliste.Opstina = txtOpstina.Text;

                TextBox txtZona = (TextBox)GvStajalista.FooterRow.FindControl("txtZonaInsert");
                stajaliste.Zona =Convert.ToInt32(txtZona.Text);

                TextBox txtRedniBroj = (TextBox)GvStajalista.FooterRow.FindControl("txtRedniBrojInsert");
                stajaliste.RedniBroj = Convert.ToInt32(txtRedniBroj.Text);

                string linija = HiddenlLinija.Value;
                string smer = DdlSmer.SelectedValue;

                if (stajaliste.InsertStajaliste(linija, smer))
                    LblRedVoznje.Text = "Uspesno ste uneli podatak";
                else
                    LblRedVoznje.Text = "Greska pri unosu";

                BindStajalista();
            }
        }

        protected void GvStajalista_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Stajaliste stajaliste = new Stajaliste();
            Label lblID = (Label)GvStajalista.Rows[e.RowIndex].FindControl("LblID");
            stajaliste.ID = Convert.ToInt32(lblID.Text);

            string linija = HiddenlLinija.Value;
            string smer = DdlSmer.SelectedValue;


            if (stajaliste.DeleteStajaliste(linija, smer))
                LblRedVoznje.Text = "Podatak je izbrisan";
            else
                LblRedVoznje.Text = "Greska pri brisanju";

            BindStajalista();
        }

        protected void GvStajalista_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvStajalista.EditIndex = e.NewEditIndex;
            BindStajalista();
        }

        protected void GvStajalista_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Stajaliste stajaliste = new Stajaliste();

            Label lblID = (Label)GvStajalista.Rows[e.RowIndex].FindControl("LblID");
            stajaliste.ID = Convert.ToInt32(lblID.Text);

            TextBox txtNaziv = (TextBox)GvStajalista.Rows[e.RowIndex].FindControl("txtNazivEdit");
            stajaliste.Naziv = txtNaziv.Text;

            TextBox txtUlica = (TextBox)GvStajalista.Rows[e.RowIndex].FindControl("txtUlicaEdit");
            stajaliste.Ulica = txtUlica.Text;

            TextBox txtNaselje = (TextBox)GvStajalista.Rows[e.RowIndex].FindControl("txtNaseljeEdit");
            stajaliste.Naselje = txtNaselje.Text;

            TextBox txtOpstina = (TextBox)GvStajalista.Rows[e.RowIndex].FindControl("txtOpstinaEdit");
            stajaliste.Opstina = txtOpstina.Text;

            TextBox txtZona = (TextBox)GvStajalista.Rows[e.RowIndex].FindControl("txtZonaEdit");
            stajaliste.Zona = Convert.ToInt32(txtZona.Text);

            TextBox txtRedniBroj = (TextBox)GvStajalista.Rows[e.RowIndex].FindControl("txtRedniBrojEdit");
            stajaliste.RedniBroj = Convert.ToInt32(txtRedniBroj.Text);

            string linija = HiddenlLinija.Value;
            string smer = DdlSmer.SelectedValue;

            if (stajaliste.UpdateStajaliste(linija, smer))
                LblRedVoznje.Text = "Uspesno ste uneli podatak";
            else
                LblRedVoznje.Text = "Greska pri unosu";

            GvStajalista.EditIndex = -1;
            BindStajalista();

        }


    }
}