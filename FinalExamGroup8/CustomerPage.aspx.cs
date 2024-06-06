using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalExamGroup8
{
    public partial class CustomerPage : System.Web.UI.Page
    {
        CustomerDataUtil data = new CustomerDataUtil();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                // Nếu không tồn tại, chuyển hướng đến trang đăng nhập
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            dtgCustomer.DataSource = data.listCustomer();
            dtgCustomer.DataBind();
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int customer_id = Convert.ToInt32(e.CommandArgument);
                try
                {
                    data.DeleteCustomer(customer_id);
                    BindGridView();
                    msgSuccess.Text = "Xóa khách hàng thành công";
                    msgSuccess.Enabled = true;
                    msgFail.Enabled = false;
                }
                catch (Exception ex)
                {
                    msgFail.Text = "Xóa khách hàng thất bại: " + ex.Message;
                    msgSuccess.Enabled = false;
                    msgFail.Enabled = true;
                }
            }
        }

        protected void dtgCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void dtgCustomer_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void btnEdit_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int customer_id = Convert.ToInt32(e.CommandArgument);
                Session["customer"] = data.GetCustomer(customer_id);
                Response.Redirect("DetailCustomerPage.aspx");
            }
        }

    }
}