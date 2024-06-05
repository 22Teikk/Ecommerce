<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPageMaster.Master" AutoEventWireup="true" CodeBehind="DetailCustomerPage.aspx.cs" Inherits="FinalExamGroup8.DetailCustomerPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <% FinalExamGroup8.model.Customer customer = Session["customer"] as FinalExamGroup8.model.Customer; %>

    <div class="pagetitle">
        <h1>Thông tin khách hàng</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="DashboardPage.aspx">Home</a></li>
                <li class="breadcrumb-item">Danh sách khách hàng</li>
                <li class="breadcrumb-item active">Chi tiết khách hàng</li>
            </ol>
        </nav>
    </div>
    <!-- End Page Title -->

    <section class="section">
        <div class="row">
            <div class="col-lg-6">
                <div class="card">
                    <asp:Label runat="server" ID="msgSuccess" class="alert alert-success bg-success text-light border-0 alert-dismissible fade show w-100" Enabled="false" />
                    <asp:Label runat="server" ID="msgFail" class="alert alert-danger bg-danger text-light border-0 alert-dismissible fade show w-100" Enabled="false" />

                    <div class="card-body">
                        <h5 class="card-title">Thông tin khách hàng</h5>

                        <div class="form-group">
                            <label for="tbFirstName">Tên</label>
                            <asp:TextBox runat="server" ID="tbFirstName" CssClass="form-control" />
                        </div>

                        <div class="form-group">
                            <label for="tbLastName">Họ</label>
                            <asp:TextBox runat="server" ID="tbLastName" CssClass="form-control" />
                        </div>

                        <div class="form-group">
                            <label for="tbEmail">Email</label>
                            <asp:TextBox runat="server" ID="tbEmail" CssClass="form-control" />
                        </div>

                        <div class="form-group">
                            <label for="tbPassword">Mật khẩu</label>
                            <asp:TextBox runat="server" ID="tbPassword" CssClass="form-control" TextMode="Password" />
                        </div>

                        <div class="form-group">
                            <label for="tbAddress">Địa chỉ</label>
                            <asp:TextBox runat="server" ID="tbAddress" CssClass="form-control" TextMode="MultiLine" />
                        </div>

                        <div class="form-group">
                            <label for="tbPhoneNumber">Số điện thoại</label>
                            <asp:TextBox runat="server" ID="tbPhoneNumber" CssClass="form-control" />
                        </div>

                        <div class="text-center" style="margin-top: 20px;">
                            <asp:Button runat="server" ID="btnUpdate" OnClick="btnUpdate_Click" CssClass="btn btn-primary" Text="Cập nhật" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
