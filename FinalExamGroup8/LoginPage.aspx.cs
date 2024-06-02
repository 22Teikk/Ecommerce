using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalExamGroup8
{
    public partial class LoginPage : System.Web.UI.Page
    {
        CategoryDataUtils data = new CategoryDataUtils();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = yourUsername.Value;
            string password = yourPassword.Value;
            if (data.checkAdmin(userName, password))
                Response.Redirect("/ProductPage.aspx");
            else
            {
                Response.Redirect("/LoginPage.aspx");
            };
        }
    }
}