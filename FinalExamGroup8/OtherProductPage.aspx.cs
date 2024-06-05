using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalExamGroup8
{
    public partial class OtherProductPage : System.Web.UI.Page
    {
        ProductDataUtils data = new ProductDataUtils();
        CategoryDataUtils cateData = new CategoryDataUtils();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCategory.DataSource = cateData.listOtherCategory();
                ddlCategory.DataTextField = "category_name";
                ddlCategory.DataValueField = "category_id";
                DataBind();
                int categoryId = int.Parse(ddlCategory.SelectedValue.ToString());
                ShowList(categoryId);
            }
        }

        private void ShowList(int categoryId)
        {
            var list = data.GetProductsByCategory(categoryId);
            if (list.Count > 0)
            {
                dtgProduct.DataSource = list;
                emptyLayout.Visible = false;
            }
            else
            {
                emptyLayout.Visible = true;
            }
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

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCategoryId = int.Parse(ddlCategory.SelectedValue);
            ShowList(selectedCategoryId);
        }

        protected void dtgProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Response.Redirect("OtherProductPage.aspx");
        }
    }
}
