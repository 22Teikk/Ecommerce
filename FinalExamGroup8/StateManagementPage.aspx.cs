using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalExamGroup8
{
    public partial class StateManagementPage : System.Web.UI.Page
    {
        AnalysticDataUtil data = new AnalysticDataUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrderShipmentData(0);
            }
        }

        private void LoadOrderShipmentData(int status)
        {
            var list = data.GetShipmentOrders(status);
            if (list.Count > 0)
            {
                dtgOrderShipment.DataSource = list;
                emptyLayout.Visible = false;
            }
            else
            {
                emptyLayout.Visible = true;
            }
            DataBind();
        }

        protected void dtgOrderShipment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateStatus")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                // Lấy ra row tương ứng trong GridView
                GridViewRow row = dtgOrderShipment.Rows[rowIndex];

                // Lấy ra OrderId từ cell trong row
                int orderId = int.Parse(row.Cells[0].Text);

                // Lấy ra giá trị của DropDownList (ddlUpdateStatus)
                DropDownList ddlUpdateStatus = (DropDownList)row.FindControl("ddlUpdateStatus");
                int status = int.Parse(ddlUpdateStatus.SelectedValue);
                data.UpdateStatusOrder(orderId, status);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            int status = int.Parse(ddlStatus.SelectedValue.ToString());
            LoadOrderShipmentData(status);
        }

        protected void dtgOrderShipment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Lấy ra giá trị trạng thái từ dòng hiện tại của GridView
                int status = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Status"));

                // Tìm và lấy ra DropDownList trong dòng hiện tại của GridView
                DropDownList ddlUpdateStatus = (DropDownList)e.Row.FindControl("ddlUpdateStatus");

                // Thiết lập giá trị được chọn cho DropDownList dựa trên trạng thái của đơn hàng
                ddlUpdateStatus.SelectedValue = status.ToString();
            }
        }
    }
}
