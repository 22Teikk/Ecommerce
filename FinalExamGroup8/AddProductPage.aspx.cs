using FinalExamGroup8.model;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;
using System.Xml.Linq;

namespace FinalExamGroup8
{
    public partial class AddProductPage : System.Web.UI.Page
    {
        ProductDataUtils proData = new ProductDataUtils();
        CategoryDataUtils cateData = new CategoryDataUtils();
        protected void Page_Load(object sender, EventArgs e)
        {
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