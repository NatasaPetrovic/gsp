using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();

            string username = TextBox1.Text;
            string password = TextBox2.Text;
            
            string login = service.Login(username, password);
            
            Session["UserAuthentication"] = username;
            Response.Redirect("admin.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}