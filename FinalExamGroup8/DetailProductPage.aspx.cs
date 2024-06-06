using FinalExamGroup8.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalExamGroup8
{
    public partial class DetailProductPage : System.Web.UI.Page
    {
        ProductDataUtils proData = new ProductDataUtils();
        CategoryDataUtils cateData = new CategoryDataUtils();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                // Nếu không tồn tại, chuyển hướng đến trang đăng nhập
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack)
            {
                LoadDataDDL();
            }
        }

        private void LoadDataDDL()
        {
            ddlCategory.DataSource = cateData.listCategory();
            ddlCategory.DataValueField = "category_id";
            ddlCategory.DataTextField = "category_name";
            DataBind();
            Product product = Session["product"] as Product;
            if (product != null)
            {
                tbSku.Value = product.sku;
                tbName.Value = product.name;
                tbPrice.Value = product.price.ToString();
                tbStock.Value = product.stock.ToString();
                ddlCategory.SelectedValue = product.category_id.ToString();
                imagePreview.Src = product.image;
                imagePreview.Style.Remove("display");
                btnAdd.Text = "Cập nhật";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = tbName.Value;
                string sku = tbSku.Value;
                decimal price = decimal.Parse(tbPrice.Value);
                int stock = int.Parse(tbStock.Value);
                int cate_id = int.Parse(ddlCategory.SelectedValue);
                string image = "";
                Product product = Session["product"] as Product;
                FileUpload f = inputImage;
                if (f.HasFile)
                {
                    try
                    {
                        string fileName = Path.GetFileName(f.FileName);
                        string savePath = Server.MapPath("~/images/") + fileName;
                        string directoryPath = Server.MapPath("~/images/");
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }
                        f.SaveAs(savePath);
                        image = "~/images/" + fileName;
                    }
                    catch (Exception ex)
                    {
                        // Xử lý ngoại lệ
                        Response.Write("Lỗi: " + ex.Message);
                    }
                }
                else
                {
                    Response.Write("Không có file nào được chọn.");
                }
                if (product != null)
                {
                    product.name = name;
                    product.sku = sku;
                    product.price = price;
                    product.stock = stock;
                    product.category_id = cate_id;
                    product.image = image;
                    proData.UpdateProduct(product);
                    msgSuccess.Text = "Sửa sản phẩm thành công";
                    Session.Remove("product");
                }
                else
                {
                    product = new Product();
                    product.name = name;
                    product.sku = sku;
                    product.price = price;
                    product.stock = stock;
                    product.category_id = cate_id;
                    product.image = image;
                    proData.AddProduct(product);
                    msgSuccess.Text = "Thêm sản phẩm thành công";
                }
                msgSuccess.Enabled = true;
                msgFail.Enabled = false;
            }
            catch (Exception ex)
            {
                msgFail.Text = "Thêm sản phẩm thất bại: " + ex.Message;
                msgSuccess.Enabled = false;
                msgFail.Enabled = true;
            }
        }
    }
}