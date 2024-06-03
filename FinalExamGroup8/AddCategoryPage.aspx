<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPageMaster.Master" AutoEventWireup="true" CodeBehind="AddCategoryPage.aspx.cs" Inherits="FinalExamGroup8.AddCategoryPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pagetitle">

        <h1>Thêm danh mục</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="DashboardPage.aspx">Home</a></li>
                <li class="breadcrumb-item">Danh mục</li>
                <li class="breadcrumb-item active">Thêm danh mục</li>
            </ol>
        </nav>
        <div class="container w-50">
            <div class="card">
                <asp:Label runat="server" ID="msgSuccess" class="alert alert-success bg-success text-light border-0 alert-dismissible fade show w-100" Enabled="false"/>
                <asp:Label runat="server" ID="msgFail" class="alert alert-danger bg-danger text-light border-0 alert-dismissible fade show w-100" Enabled="false"/>

                <div class="card-body" style="padding: 10px;">
                    <h5 class="card-title">Thông tin danh mục</h5>
                    <div class="form-floating mb-3">
                        <input runat="server" type="text" class="form-control" id="tbName" placeholder="Nhập tên danh mục">

                        <label for="tbName">Tên danh mục</label>
                    </div>
                    <div class="row mb-3">
                        <div class="col-sm-12 text-center d-flex justify-content-center">
                            <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" Text="Thêm" CssClass="btn btn-primary me-2" />
                            <asp:Button ID="btnDel" runat="server" Text="Xóa dòng" CssClass="btn btn-danger ms-2" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
