<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPageMaster.Master" AutoEventWireup="true" CodeBehind="StateManagementPage.aspx.cs" Inherits="FinalExamGroup8.StateManagementPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pagetitle">
        <h1>Quản lý trạng thái giao hàng</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="DashboardPage.aspx">Trang chủ</a></li>
                <li class="breadcrumb-item">Sản phẩm</li>
                <li class="breadcrumb-item active">Quản lý trạng thái giao hàng</li>
            </ol>
        </nav>
        <asp:Label runat="server" ID="msgSuccess" CssClass="alert alert-success bg-success text-light border-0 alert-dismissible fade show w-100" Visible="false" />
        <asp:Label runat="server" ID="msgFail" CssClass="alert alert-danger bg-danger text-light border-0 alert-dismissible fade show w-100" Visible="false" />
    </div>

    <div class="col-lg-12">
        <div class="card">
            <div class="card-body">
                <h5 class="card-title">Trạng thái các đơn hàng</h5>
                <label for="ddlStatus" class="form-label">Xem theo trạng thái</label>

                <asp:DropDownList CssClass="form-select" ID="ddlStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                    <asp:ListItem Text="Chờ Xác Nhận" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Đang vận chuyển" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Đã Giao" Value="2"></asp:ListItem>
                </asp:DropDownList>
                <div runat="server" class="col-lg-6" style="margin-top: 50px;" id="emptyLayout">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">Thông báo</h5>
                            <p>Danh mục sản phẩm này đang trống, vui lòng thêm dữ liệu hoặc xem sản phẩm khác!</p>
                        </div>
                    </div>
                </div>
                <asp:GridView ID="dtgOrderShipment" GridLines="None" CssClass="table datatable" runat="server" AutoGenerateColumns="false" OnRowDataBound="dtgOrderShipment_RowDataBound" OnRowCommand="dtgOrderShipment_RowCommand">
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
                        <asp:BoundField DataField="OrderDate" HeaderText="Ngày Đặt Hàng" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="PaymentMethod" HeaderText="Phương Thức Thanh Toán" />
                        <asp:BoundField DataField="Quantity" HeaderText="Số Lượng" />
                        <asp:BoundField DataField="ProductName" HeaderText="Tên Sản Phẩm" />
                        <asp:TemplateField HeaderText="Ảnh">
                            <ItemTemplate>
                                <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# Eval("ProductImage") %>' Height="50" Width="50" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cập Nhật Trạng Thái">
                            <ItemTemplate>
                                <asp:DropDownList CssClass="form-select" ID="ddlUpdateStatus" runat="server">
                                    <asp:ListItem Text="Chờ Xác Nhận" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Đang vận chuyển" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Đã Giao" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cập Nhật">
                            <ItemTemplate>
                                <asp:Button ID="btnUpdateStatus" runat="server" Text="Cập Nhật" CommandName="UpdateStatus" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-primary btn-sm"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                
          
            </div>
        </div>
    </div>
</asp:Content>
