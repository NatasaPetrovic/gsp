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
    public static class ControlExtensions
    {
        /// <summary>
        /// recursively finds a child control of the specified parent.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Control FindControlRecursive(this Control control, string id)
        {
            if (control == null) return null;
            //try to find the control at the current level
            Control ctrl = control.FindControl(id);

            if (ctrl == null)
            {
                //search the children
                foreach (Control child in control.Controls)
                {
                    ctrl = FindControlRecursive(child, id);

                    if (ctrl != null) break;
                }
            }
            return ctrl;
        }
    }

    public partial class LinijaOpis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string linija = Request.QueryString["linija"];
            Stajaliste stajalista = new Stajaliste();

            DataSet ds = stajalista.ListStajalisteByLinijaAndSmer(linija, RadioButtonList1.SelectedValue);

            if (ds.Tables[0].Rows.Count != 0)
            {
                Repeater1.DataSource = ds.Tables[0];
                Repeater1.DataBind();
            }

            Polazak polazak = new Polazak();
            List<Polazak> polasci = new List<Polazak>();

            string dan = RadioButtonList2.SelectedValue;
            if (dan == "Radni dan")
                dan = "radni";
            
            polasci = polazak.RedVoznje(linija, RadioButtonList1.SelectedValue, dan);

            Control container = this.FindControlRecursive("container");
            foreach(Polazak pol in polasci) {
                HtmlGenericControl div = new HtmlGenericControl("div");
               
                div.Controls.Add( new Label() { Text = pol.Vreme + "\r\n" } );
                div.InnerHtml = pol + "";
               container.Controls.Add(div);
}
            //if (ds.Tables[0].Rows.Count != 0)
            //{
            //    Repeater2.DataSource = ds.Tables[0];
            //    Repeater2.DataBind();
            //}

        }
    }
}