<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPageMaster.Master" AutoEventWireup="true" CodeBehind="ProductStatistic.aspx.cs" Inherits="FinalExamGroup8.ProductStatistic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pagetitle">
        <h1>Điện thoại</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="DashboardPage.aspx">Home</a></li>
                <li class="breadcrumb-item">Sản phẩm</li>
                <li class="breadcrumb-item active">Điện thoại</li>
            </ol>
        </nav>
        <asp:Label runat="server" ID="msgSuccess" class="alert alert-success bg-success text-light border-0 alert-dismissible fade show w-100" Enabled="false"/>
        <asp:Label runat="server" ID="msgFail" class="alert alert-danger bg-danger text-light border-0 alert-dismissible fade show w-100" Enabled="false"/>
    </div>

    <section class="section">
        <div class="row">
            <!-- Daily Statistics -->
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Thống kê theo ngày</h5>
                        <asp:GridView ID="dtgDaily" GridLines="None" CssClass="table datatable" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="FormattedDate" HeaderText="Ngày" />
                                <asp:BoundField DataField="TotalOrders" HeaderText="Số đơn hàng" />
                                <asp:BoundField DataField="TotalRevenue" HeaderText="Doanh thu" DataFormatString="{0:N0}" />
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="btnExportDaily" runat="server" Text="Export to PDF" OnClick="btnExportDaily_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>

            <!-- Monthly Statistics -->
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Thống kê theo tháng</h5>
                        <asp:GridView ID="dtgMonthly" GridLines="None" CssClass="table datatable" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Year" HeaderText="Năm" />
                                <asp:BoundField DataField="Month" HeaderText="Tháng" />
                                <asp:BoundField DataField="TotalOrders" HeaderText="Số đơn hàng" />
                                <asp:BoundField DataField="TotalRevenue" HeaderText="Doanh thu" DataFormatString="{0:N0}" />
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="btnExportMonthly" runat="server" Text="Export to PDF" OnClick="btnExportMonthly_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>

            <!-- Yearly Statistics -->
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Thống kê theo năm</h5>
                        <asp:GridView ID="dtgYearly" GridLines="None" CssClass="table datatable" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Year" HeaderText="Năm" />
                                <asp:BoundField DataField="TotalOrders" HeaderText="Số đơn hàng" />
                                <asp:BoundField DataField="TotalRevenue" HeaderText="Doanh thu" DataFormatString="{0:N0}" />
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="btnExportYearly" runat="server" Text="Export to PDF" OnClick="btnExportYearly_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
