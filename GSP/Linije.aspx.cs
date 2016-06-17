using Linije;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSP
{
    public partial class Linije : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Linija linije = new Linija();
            DataSet ds = linije.ListByID(DropDownList1.SelectedValue, RadioButtonList1.SelectedValue == "Dnevna"?true:false);

            if (ds.Tables[0].Rows.Count != 0)
            {
                Repeater1.DataSource = ds.Tables[0];
                Repeater1.DataBind();
            }
               
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            
            Response.Redirect("LinijaOpis.aspx?linija=" + e.CommandArgument.ToString());
        }
    }
}