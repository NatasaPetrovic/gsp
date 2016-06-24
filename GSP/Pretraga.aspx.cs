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
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "Detaljnije")
            {
                DropDownList3.Visible = true;
                DropDownList4.Visible = true;
                button.Text = "Sakrij";

            }
            else
            {
                DropDownList3.Visible = false;
                DropDownList4.Visible = false;
                button.Text = "Detaljnije";
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            if (Button1.Text == "Detaljnije")
            {


            }
            else
            {
 
            }
        }

        
    }
}