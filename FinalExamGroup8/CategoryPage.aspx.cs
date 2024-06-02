using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalExamGroup8
{
    public partial class CategoryPage : System.Web.UI.Page
    {
        CategoryDataUtils data = new CategoryDataUtils();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            dtgCategory.DataSource = data.listCategory();
            DataBind();
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int cate_id = Convert.ToInt32(e.CommandArgument);
                try
                {
                    data.DeleteCategory(cate_id);
                    BindGridView();
                    msgSuccess.Text = "Xóa danh mục thành công";
                    msgSuccess.Enabled = true;
                    msgFail.Enabled = false;
                }
                catch (Exception ex)
                {
                    msgFail.Text = "Xóa danh mục thất bại: " + ex.Message;
                    msgSuccess.Enabled = false;
                    msgFail.Enabled = true;
                }
            }
        }

        protected void dtgCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void dtgCategory_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void btnEdit_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int cate_id = Convert.ToInt32(e.CommandArgument);
                Session["category"] = data.GetCategory(cate_id);
                Response.Redirect("DetailCategoryPage.aspx");
            }
        }
    }
}