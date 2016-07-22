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
            if (Session["UserAuthentication"] == null)
                Response.Redirect("Login.aspx");
            else
                GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
    }
}