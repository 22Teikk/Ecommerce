using FinalExamGroup8.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalExamGroup8
{
    public partial class AddCustomerPage : System.Web.UI.Page
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
                if (Session["customer"] != null)
                {
                    LoadCustomerData();
                }
            }
        }

        private void LoadCustomerData()
        {
            Customer customer = Session["customer"] as Customer;
            if (customer != null)
            {
                tbFirstName.Value = customer.first_name;
                tbLastName.Value = customer.last_name;
                tbEmail.Value = customer.email;
                tbPassword.Value = customer.password;
                tbAddress.Value = customer.address;
                tbPhoneNumber.Value = customer.phone_number;
                btnAdd.Text = "Cập nhật";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = new Customer
                {
                    first_name = tbFirstName.Value,
                    last_name = tbLastName.Value,
                    email = tbEmail.Value,
                    password = tbPassword.Value,
                    address = tbAddress.Value,
                    phone_number = tbPhoneNumber.Value
                };

                if (Session["customer"] != null)
                {
                    customer.customer_id = (Session["customer"] as Customer).customer_id;
                    data.UpdateCustomer(customer);
                    msgSuccess.Text = "Cập nhật khách hàng thành công";
                }
                else
                {
                    data.AddCustomer(customer);
                    msgSuccess.Text = "Thêm khách hàng thành công";
                }

                msgSuccess.Enabled = true;
                msgFail.Enabled = false;
                ClearFields();
            }
            catch (Exception ex)
            {
                msgFail.Text = "Có lỗi xảy ra: " + ex.Message;
                msgSuccess.Enabled = false;
                msgFail.Enabled = true;
            }
        }

        private void ClearFields()
        {
            tbFirstName.Value = "";
            tbLastName.Value = "";
            tbEmail.Value = "";
            tbPassword.Value = "";
            tbAddress.Value = "";
            tbPhoneNumber.Value = "";
            Session["customer"] = null;
        }
    }
}