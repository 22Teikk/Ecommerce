using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalExamGroup8
{
    public partial class ProductStatusPage : System.Web.UI.Page
    {
        AnalysticDataUtil data = new AnalysticDataUtil();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                // Nếu không tồn tại, chuyển hướng đến trang đăng nhập
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack) {
                dtgDesc.DataSource = data.GetBestProductByOrder(true);
                dtgAsc.DataSource = data.GetBestProductByOrder(false);
                DataBind();
            }
        }
    }
}