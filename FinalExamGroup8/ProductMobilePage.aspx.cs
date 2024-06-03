﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalExamGroup8
{
    public partial class ProductMobile : System.Web.UI.Page
    {
        ProductDataUtils data = new ProductDataUtils();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                ShowProducts();
            }
        }

        private void ShowProducts()
        {
            dtgProduct.DataSource = data.listProductByCategoryName("Điện thoại");
            dtgStock.DataSource = data.listProductStock("Điện thoại");
            dtgOutStock.DataSource = data.listProductOutStock("Điện thoại");
            DataBind();
        }

        protected void btnEdit_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int product_id = Convert.ToInt32(e.CommandArgument);
                Session["product"] = data.GetProduct(product_id);
                Response.Redirect("DetailProductPage.aspx");
            }
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int product_id = Convert.ToInt32(e.CommandArgument);
                try
                {
                    data.DeleteProduct(product_id);
                    ShowProducts();
                    msgSuccess.Text = "Xóa sản phẩm thành công";
                    msgSuccess.Enabled = true;
                    msgFail.Enabled = false;
                }
                catch (Exception ex)
                {
                    msgFail.Text = "Xóa sản phẩm thất bại: " + ex.Message;
                    msgSuccess.Enabled = false;
                    msgFail.Enabled = true;
                }
            }
        }

    }
}