using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalExamGroup8
{
    public partial class DetailCustomerPage : System.Web.UI.Page
    {
        CustomerDataUtil customerData = new CustomerDataUtil();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                // Nếu không tồn tại, chuyển hướng đến trang đăng nhập
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack)
            {
                LoadCustomerData();
                DataBind();
            }
        }

        private void LoadCustomerData()
        {
            FinalExamGroup8.model.Customer customer = Session["customer"] as FinalExamGroup8.model.Customer;
            if (customer != null)
            {
                tbFirstName.Text = customer.first_name;
                tbLastName.Text = customer.last_name;
                tbEmail.Text = customer.email;
                tbPassword.Text = customer.password;
                tbAddress.Text = customer.address;
                tbPhoneNumber.Text = customer.phone_number;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                FinalExamGroup8.model.Customer customer = Session["customer"] as FinalExamGroup8.model.Customer;
                if (customer != null)
                {
                    customer.first_name = tbFirstName.Text;
                    customer.last_name = tbLastName.Text;
                    customer.email = tbEmail.Text;
                    customer.password = tbPassword.Text;
                    customer.address = tbAddress.Text;
                    customer.phone_number = tbPhoneNumber.Text;

                    customerData.UpdateCustomer(customer);
                    msgSuccess.Text = "Cập nhật thông tin khách hàng thành công";
                    Session.Remove("customer");
                }
                else
                {
                    // Handle case when customer is null
                }
                msgSuccess.Enabled = true;
                msgFail.Enabled = false;
            }
            catch (Exception ex)
            {
                msgFail.Text = "Cập nhật thông tin khách hàng thất bại: " + ex.Message;
                msgSuccess.Enabled = false;
                msgFail.Enabled = true;
            }
        }
    }
}