using FinalExamGroup8.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalExamGroup8
{
    public partial class ProductPage : System.Web.UI.Page
    {
        DashboardDataUtil data = new DashboardDataUtil();
        AnalysticDataUtil anaData = new AnalysticDataUtil();    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                // Nếu không tồn tại, chuyển hướng đến trang đăng nhập
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            LoadSaleDay();
            LoadRevenueMonth();
            LoadCustomerYear();
            LoadRecentDay();
            LoadSellingDay();
            BindTrafficChart();
        }
        private void BindTrafficChart()
        {
            List<ProductSalesInfo> productSalesInfoList = anaData.ChartAllProductByCategory();

            // Nhóm các mục theo category_name và tính tổng doanh thu
            var groupedData = productSalesInfoList.GroupBy(p => p.CategoryName)
                                                  .Select(g => new { CategoryName = g.Key, TotalRevenue = g.Sum(p => p.TotalRevenue) });

            // Chuyển dữ liệu sang JSON
            string chartDataJson = JsonConvert.SerializeObject(groupedData);

            // Gọi hàm JavaScript để vẽ biểu đồ
            ScriptManager.RegisterStartupScript(this, this.GetType(), "DrawPieChart", $"DrawPieChart({chartDataJson});", true);
        }




        private void LoadSellingDay()
        {
            List<ProductSalesInfo> list = anaData.GetProductSalesInfoOfTheDay();
            if (list.Count == 0)
            {
                EmptySell.Visible = true;
            }
            else
            {
                EmptySell.Visible = false;
                grvProductSales.DataSource = list;
                grvProductSales.DataBind();  // Correctly call DataBind on the GridView
            }

        }

        private void LoadRecentDay()
        {
            List<ShipmentOrder> list = anaData.GetTodayShipmentOrders();
            if (list.Count == 0)
            {
                emptyLayout.Visible = true;
                grvRecentSale.Visible = false;  // Hide the GridView if there's no data
            }
            else
            {
                emptyLayout.Visible = false;
                grvRecentSale.Visible = true;  // Ensure the GridView is visible
                grvRecentSale.DataSource = list;
                grvRecentSale.DataBind();  // Correctly call DataBind on the GridView
            }
        }

        protected string GetStatusText(object statusObj)
        {
            int status = Convert.ToInt32(statusObj);
            switch (status)
            {
                case 0:
                    return "Chờ xác nhận";
                case 1:
                    return "Đang vận chuyển";
                case 2:
                    return "Đã giao";
                default:
                    return "Không xác định";
            }
        }

        protected string GetStatusCssClass(object statusObj)
        {
            int status = Convert.ToInt32(statusObj);
            switch (status)
            {
                case 0:
                    return "badge bg-danger";  // For status 0
                case 1:
                    return "badge bg-warning"; // For status 1
                case 2:
                    return "badge bg-success"; // For status 2
                default:
                    return "badge bg-secondary"; // Default case
            }
        }

        public double CalculatePercentageChange(int currentNumber, int previousNumber)
        {
            if (previousNumber == 0)
            {
                return 0;
            }
            double percentageChange = ((double)(currentNumber - previousNumber) / previousNumber) * 100;
            return percentageChange;
        }

        public decimal CalculatePercentageChange(decimal currentNumber, decimal previousNumber)
        {
            if (previousNumber == 0)
            {
                return 0;
            }
            decimal percentageChange = ((decimal)(currentNumber - previousNumber) / previousNumber) * 100;
            return percentageChange;
        }

        private void LoadSaleDay()
        {
            int saleTodayInt = data.SaleToday();
            int salePreviousDayInt = data.SalePreviousDay();
            double percentDayDouble = CalculatePercentageChange(saleTodayInt, salePreviousDayInt);
            if (percentDayDouble > 0)
            {
                percentDay.Attributes.Add("class", "text-success small pt-1 fw-bold");
            }
            else
            {
                percentDay.Attributes.Add("class", "text-danger small pt-1 fw-bold");
            }
            saleToday.InnerText = saleTodayInt.ToString();
            percentDay.InnerText = percentDayDouble + "%";
        }

        private void LoadCustomerYear()
        {
            int saleTodayInt = data.CustomerYear();
            int salePreviousDayInt = data.CustomerPreviousYear();
            double percentDayDouble = CalculatePercentageChange(saleTodayInt, salePreviousDayInt);
            if (percentDayDouble > 0)
            {
                percentYear.Attributes.Add("class", "text-success small pt-1 fw-bold");
            }
            else
            {
                percentYear.Attributes.Add("class", "text-danger small pt-1 fw-bold");
            }
            customerYear.InnerText = saleTodayInt.ToString();
            percentYear.InnerText = percentDayDouble + "%";
        }

        private void LoadRevenueMonth()
        {
            decimal saleTodayInt = data.RevenueMonth();
            decimal salePreviousDayInt = data.RevenuePreviousMonth();
            decimal percentDayDouble = CalculatePercentageChange(saleTodayInt, salePreviousDayInt);
            if (percentDayDouble > 0)
            {
                percentMonth.Attributes.Add("class", "text-success small pt-1 fw-bold");
            }
            else
            {
                percentMonth.Attributes.Add("class", "text-danger small pt-1 fw-bold");
            }
            revenueMonth.InnerText = saleTodayInt.ToString();
            percentMonth.InnerText = percentDayDouble + "%";
        }
    }
}