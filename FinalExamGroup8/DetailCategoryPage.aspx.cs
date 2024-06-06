using FinalExamGroup8.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalExamGroup8
{
    public partial class DetailCategoryPage : System.Web.UI.Page
    {
        CategoryDataUtils data = new CategoryDataUtils();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                // Nếu không tồn tại, chuyển hướng đến trang đăng nhập
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack)
            {
                // Lấy dữ liệu từ Session và gán cho biến category
                Category category = Session["category"] as Category;
                if (category != null)
                {
                    tbName.Value = category.category_name;
                    btnAdd.Text = "Cập nhật";
                }// Kích hoạt binding dữ liệu
                DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = tbName.Value;
                Category category = Session["category"] as Category;
                if (category != null)
                {
                    category.category_name = name;
                    data.UpdateCategory(category);
                    msgSuccess.Text = "Sửa danh mục thành công";
                    Session.Remove("category");
                }
                else
                {
                    data.AddCategory(name);
                    msgSuccess.Text = "Thêm danh mục thành công";
                }
                msgSuccess.Enabled = true;
                msgFail.Enabled = false;
            }
            catch (Exception ex)
            {
                msgFail.Text = "Thêm danh mục thất bại: " + ex.Message;
                msgSuccess.Enabled = false;
                msgFail.Enabled = true;
            }
        }

    }
}