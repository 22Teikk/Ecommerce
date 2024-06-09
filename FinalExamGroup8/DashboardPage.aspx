<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPageMaster.Master" AutoEventWireup="true" CodeBehind="DashboardPage.aspx.cs" Inherits="FinalExamGroup8.ProductPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="pagetitle">
        <h1>Trang chủ</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="DashboardPage.aspx">Home</a></li>
                <li class="breadcrumb-item active">Thông tin chung</li>
            </ol>
        </nav>
    </div>
    <section class="section dashboard">
        <div class="row">

            <!-- Left side columns -->
            <div class="col-lg-8">
                <div class="row">

                    <!-- Sales Card -->
                    <div class="col-xxl-4 col-md-6">
                        <div class="card info-card sales-card">

                            <div class="card-body">
                                <h5 class="card-title">Bán hàng <span>| Hôm nay</span></h5>

                                <div class="d-flex align-items-center">
                                    <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                        <i class="bi bi-cart"></i>
                                    </div>
                                    <div class="ps-3">
                                        <h6 id="saleToday" runat="server">145</h6>
                                        <span id="percentDay" runat="server">12%</span> <span class="text-muted small pt-2 ps-1">So với hôm qua</span>

                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <!-- End Sales Card -->

                    <!-- Revenue Card -->
                    <div class="col-xxl-4 col-md-6">
                        <div class="card info-card revenue-card">


                            <div class="card-body">
                                <h5 class="card-title">Doanh thu <span>| Tháng này</span></h5>

                                <div class="d-flex align-items-center">
                                    <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                        <i class="bi bi-currency-dollar"></i>
                                    </div>
                                    <div class="ps-3">
                                        <h6 id="revenueMonth" runat="server">$3,264</h6>
                                        <span id="percentMonth" runat="server">8%</span> <span class="text-muted small pt-2 ps-1">So với tháng trước</span>

                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <!-- End Revenue Card -->

                    <!-- Customers Card -->
                    <div class="col-xxl-4 col-xl-12">

                        <div class="card info-card customers-card">

                            <div class="card-body">
                                <h5 class="card-title">Khách hàng <span>| Năm nay</span></h5>

                                <div class="d-flex align-items-center">
                                    <div class="card-icon rounded-circle d-flex align-items-center justify-content-center">
                                        <i class="bi bi-people"></i>
                                    </div>
                                    <div class="ps-3">
                                        <h6 id="customerYear" runat="server">1244</h6>
                                        <span id="percentYear" runat="server">12%</span> <span class="text-muted small pt-2 ps-1">So với năm trước</span>

                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>
                    <!-- End Customers Card -->

                    <!-- Recent Sales -->
                    <div class="col-12">
                        <div class="card recent-sales overflow-auto">
                            <div class="card-body">
                                <h5 class="card-title">Thông tin đơn hàng <span>| Hôm nay</span></h5>
                                <div runat="server" style="margin-top: 50px;" id="emptyLayout">

                                    <div class="card-body">
                                        <h5 class="card-title">Thông báo</h5>
                                                 <p style="color: red;">Chưa có sản phẩm nào được bán trong ngày hôm nay!</p>
                                    </div>
                                </div>
                                <asp:GridView AutoGenerateColumns="false" GridLines="None" CssClass="table datatable" runat="server" ID="grvRecentSale">
                                    <Columns>
                                        <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
                                        <asp:BoundField DataField="ShipmentDate" HeaderText="Ngày Giao Hàng" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="Address" HeaderText="Địa Chỉ" />
                                        <asp:TemplateField HeaderText="Tên Khách Hàng">
                                            <ItemTemplate>
                                                <%# Eval("FirstName") %> <%# Eval("LastName") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="TotalPrice" HeaderText="Tổng Giá Tiền" DataFormatString="{0:N0}" />
                                        <asp:BoundField DataField="Quantity" HeaderText="Số Lượng" />
                                        <asp:BoundField DataField="ProductName" HeaderText="Tên Sản Phẩm" />
                                        <asp:TemplateField HeaderText="Trạng thái đơn hàng">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" CssClass='<%# GetStatusCssClass(Eval("Status")) %>' Text='<%# GetStatusText(Eval("Status")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>

                        </div>
                    </div>
                    <!-- End Recent Sales -->

                    <!-- Top Selling -->
                    <div class="col-12">
                        <div class="card top-selling overflow-auto">

                            <div class="card-body pb-0">
                                <h5 class="card-title">Bán chạy nhất<span>| Hôm nay</span></h5>
                                 <div runat="server" style="margin-top: 50px;" id="EmptySell">

     <div class="card-body">
         <h5 class="card-title">Thông báo</h5>
         <p style="color: red;">Chưa có sản phẩm nào được bán trong ngày hôm nay!</p>
     </div>
 </div>
                                <asp:GridView ID="grvProductSales" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="table datatable">
    <Columns>
                <asp:ImageField DataImageUrlField="ProductImage" HeaderText="Ảnh sản phẩm">
            <ItemStyle Width="100px" Height="100px" />
<ControlStyle Width="100px" Height="100px" />
        </asp:ImageField>
        <asp:BoundField DataField="ProductName" HeaderText="Tên sản phẩm" />
        <asp:BoundField DataField="Price" HeaderText="Giá" />
        <asp:BoundField DataField="TotalQuantitySold" HeaderText="Số lượng đã bán" />
        <asp:BoundField DataField="TotalRevenue" HeaderText="Doanh thu" />
    </Columns>
</asp:GridView>

                                
                            </div>

                        </div>
                    </div>
                    <!-- End Top Selling -->

                </div>
            </div>
            <!-- End Left side columns -->

            <!-- Right side columns -->
            <div class="col-lg-4">
                <!-- Website Traffic -->
<div class="card">
    <div class="card-body pb-0">
        <h5 class="card-title">Chi tiết doanh thu</h5>
                <canvas style="margin-bottom: 50px;" id="myPieChart" width="400" height="400" class="echart"></canvas>

    </div>
</div>
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Pie Chart</h5>

                        <!-- Pie Chart -->
                        <canvas id="pieChart" style="max-height: 400px;"></canvas>
                        <script>
                            document.addEventListener("DOMContentLoaded", () => {
                                new Chart(document.querySelector('#pieChart'), {
                                    type: 'pie',
                                    data: {
                                        labels: [
                                            'Red',
                                            'Blue',
                                            'Yellow'
                                        ],
                                        datasets: [{
                                            label: 'My First Dataset',
                                            data: [300, 50, 100],
                                            backgroundColor: [
                                                'rgb(255, 99, 132)',
                                                'rgb(54, 162, 235)',
                                                'rgb(255, 205, 86)'
                                            ],
                                            hoverOffset: 4
                                        }]
                                    }
                                });
                            });
                        </script>
                        <!-- End Pie Chart -->

                    </div>
                </div>

<script>
    function DrawPieChart(chartData) {
        var categoryNames = [];
        var totalRevenues = [];
        chartData.forEach(function (item) {
            categoryNames.push(item.CategoryName);
            totalRevenues.push(item.TotalRevenue);
        });

        var ctx = document.getElementById('myPieChart').getContext('2d');
        var myPieChart = new Chart(ctx, {
            type: 'pie',
            data: {
                labels: categoryNames,
                datasets: [{
                    data: totalRevenues,
                    backgroundColor: [
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(255, 206, 86, 0.2)',
                        'rgba(75, 192, 192, 0.2)',
                        'rgba(153, 102, 255, 0.2)'
                    ],
                    borderColor: [
                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)'
                    ],
                    borderWidth: 1
                }]
            },
            options: {
                // Cấu hình thêm nếu cần
            }
        });
    }
</script>


                </div>
                <!-- End Website Traffic -->

                <!-- News & Updates Traffic -->

            </div>
        <!-- End News & Updates -->
    </section>

</asp:Content>
