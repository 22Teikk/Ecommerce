<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPageMaster.Master" AutoEventWireup="true" CodeBehind="AddCustomerPage.aspx.cs" Inherits="FinalExamGroup8.AddCustomerPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <% FinalExamGroup8.model.Customer customer = Session["customer"] as FinalExamGroup8.model.Customer; %>
    <div class="pagetitle">
        <h1>Khách hàng</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="DashboardPage.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="CustomerPage.aspx">Khách hàng</a></li>
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
                        <h5 class="card-title">
                            <%= (customer == null) ? "Thêm khách hàng" : "Sửa khách hàng" %>
                        </h5>   

                        <!-- Multi Columns Form -->
                        <div class="col-md-12 mb-3">
                            <label for="tbFirstName" class="form-label">Họ</label>
                            <input type="text" class="form-control" id="tbFirstName" runat="server" placeholder="Nhập họ" />
                        </div>

                        <div class="col-md-12 mb-3">
                            <label for="tbLastName" class="form-label">Tên</label>
                            <input type="text" class="form-control" id="tbLastName" runat="server" placeholder="Nhập tên" />
                        </div>

                        <div class="col-md-12 mb-3">
                            <label for="tbEmail" class="form-label">Email</label>
                            <input type="email" class="form-control" id="tbEmail" runat="server" placeholder="Nhập email" />
                        </div>

                        <div class="col-md-12 mb-3">
                            <label for="tbPassword" class="form-label">Mật khẩu</label>
                            <input type="password" class="form-control" id="tbPassword" runat="server" placeholder="Nhập mật khẩu" />
                        </div>

                        <div class="col-md-12 mb-3">
                            <label for="tbAddress" class="form-label">Địa chỉ</label>
                            <input type="text" class="form-control" id="tbAddress" runat="server" placeholder="Nhập địa chỉ" />
                        </div>

                        <div class="col-md-12 mb-3">
                            <label for="tbPhoneNumber" class="form-label">Số điện thoại</label>
                            <input type="text" class="form-control" id="tbPhoneNumber" runat="server" placeholder="Nhập số điện thoại" />
                        </div>

                        <div class="text-center">
                            <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" CssClass="btn btn-primary" Text="Thêm mới" />
                            <button type="reset" class="btn btn-secondary">Làm mới</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    </asp:Content>