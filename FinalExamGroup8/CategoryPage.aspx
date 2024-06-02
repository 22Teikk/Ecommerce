<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPageMaster.Master" AutoEventWireup="true" CodeBehind="CategoryPage.aspx.cs" Inherits="FinalExamGroup8.CategoryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="pagetitle">
        <h1>Danh mục sản phẩm</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="DashboardPage.aspx">Home</a></li>
                <li class="breadcrumb-item">Danh mục</li>
                <li class="breadcrumb-item active">Danh sách danh mục</li>
            </ol>
        </nav>
    </div>


  <%--  <div runat="server" id="divAlert" class="alert alert-danger bg-danger text-light border-0 alert-dismissible fade show" role="alert" hidden>
        A simple danger alert with solid color—check it out!
                <button type="button" class="btn-close btn-close-white" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>--%>
    <div class="card">
        <asp:Label runat="server" ID="msgSuccess" class="alert alert-success bg-success text-light border-0 alert-dismissible fade show w-100" Enabled="false"/>
        <asp:Label runat="server" ID="msgFail" class="alert alert-danger bg-danger text-light border-0 alert-dismissible fade show w-100" Enabled="false"/>

        <div class="card-body" style="padding: 10px;">
            <h5 class="card-title">Danh mục hiện có</h5>
            <asp:GridView GridLines="None" CssClass="table table-borderless" ID="dtgCategory" runat="server" AutoGenerateColumns="false" OnRowEditing="dtgCategory_RowEditing" OnRowDeleting="dtgCategory_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="category_id" HeaderText="Mã danh mục" />
                    <asp:BoundField DataField="category_name" HeaderText="Tên danh mục" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" OnCommand="btnEdit_Command" runat="server" Text="Sửa" CommandName="Edit" CommandArgument='<%# Eval("category_id") %>' CssClass="btn btn-primary btn-sm" />
                            <asp:Button ID="btnDelete" OnCommand="btnDelete_Command" runat="server" Text="Xóa" CommandName="Delete" CommandArgument='<%# Eval("category_id") %>' CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa danh mục này không?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
