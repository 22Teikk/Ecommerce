<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPageMaster.Master" AutoEventWireup="true" CodeBehind="CustomerPage.aspx.cs" Inherits="FinalExamGroup8.CustomerPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pagetitle">
    <h1>Thông tin khách hàng</h1>
    <nav>
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="DashboardPage.aspx">Home</a></li>
            <li class="breadcrumb-item">Khách hàng</li>
            <li class="breadcrumb-item active">Thông tin khách hàng</li>
        </ol>
    </nav>
</div>
    <div class="card">
    <asp:Label runat="server" ID="msgSuccess" class="alert alert-success bg-success text-light border-0 alert-dismissible fade show w-100" Enabled="false"/>
    <asp:Label runat="server" ID="msgFail" class="alert alert-danger bg-danger text-light border-0 alert-dismissible fade show w-100" Enabled="false"/>

    <div class="card-body" style="padding: 10px;">
        <h5 class="card-title">Danh sách khách hàng</h5>
        <asp:GridView GridLines="None" CssClass="table table-borderless" ID="dtgCustomer" runat="server" AutoGenerateColumns="false" OnRowEditing="dtgCustomer_RowEditing" OnRowDeleting="dtgCustomer_RowDeleting">
            <Columns>
                <asp:BoundField DataField="customer_id" HeaderText="Mã khách hàng" />
                <asp:BoundField DataField="first_name" HeaderText="Tên" />
                <asp:BoundField DataField="last_name" HeaderText="Họ" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="address" HeaderText="Địa chỉ" />
                <asp:BoundField DataField="phone_number" HeaderText="Số điện thoại" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" OnCommand="btnEdit_Command" runat="server" Text="Sửa" CommandName="Edit" CommandArgument='<%# Eval("customer_id") %>' CssClass="btn btn-primary btn-sm" />
                        <asp:Button ID="btnDelete" OnCommand="btnDelete_Command" runat="server" Text="Xóa" CommandName="Delete" CommandArgument='<%# Eval("customer_id") %>' CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa khách hàng này không?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>

</asp:Content>
