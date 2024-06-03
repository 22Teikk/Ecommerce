<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPageMaster.Master" AutoEventWireup="true" CodeBehind="ProductMobilePage.aspx.cs" Inherits="FinalExamGroup8.ProductMobile" %>
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

             <section class="section">
      <div class="row">
        <div class="col-lg-6">

          <div class="card">
            <div class="card-body">
              <h5 class="card-title">Sản phẩm còn hàng</h5>
              <!-- Default Table -->
                <asp:GridView ID="dtgStock" GridLines="None" CssClass="table datatable" runat="server" AutoGenerateColumns="false" >
    <Columns>
        <asp:BoundField DataField="product_id" HeaderText="Mã sản phẩm" />
        <asp:BoundField DataField="name" HeaderText="Tên sản phẩm" />
        <asp:BoundField DataField="sku" HeaderText="SKU" />
        <asp:BoundField DataField="price" DataFormatString="{0:N0}" HeaderText="Giá" />
        <asp:BoundField DataField="stock" HeaderText="Số lượng" />
         <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <div class="btn-group">
                    <asp:Button ID="btnEdit" OnCommand="btnEdit_Command" runat="server" Text="Sửa" CommandName="Edit" CommandArgument='<%# Eval("product_id") %>' CssClass="btn btn-primary btn-sm" />
                    <asp:Button ID="btnDelete" OnCommand="btnDelete_Command" runat="server" Text="Xóa" CommandName="Delete" CommandArgument='<%# Eval("product_id") %>' CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa sản phẩm này không?');" />
                </div>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
              <!-- End Default Table Example -->
            </div>
          </div>
        </div>

        <div class="col-lg-6">

          <div class="card">
            <div class="card-body">
              <h5 class="card-title">Sản phẩm hết hàng</h5>

              <!-- Table with stripped rows -->
                              <asp:GridView GridLines="None" CssClass="table table-stripped  datatable" ID="dtgOutStock" runat="server" AutoGenerateColumns="false" >
    <Columns>
        <asp:BoundField DataField="product_id" HeaderText="Mã sản phẩm" />
        <asp:BoundField DataField="name" HeaderText="Tên sản phẩm" />
        <asp:BoundField DataField="sku" HeaderText="SKU" />
        <asp:BoundField DataField="price" DataFormatString="{0:N0}" HeaderText="Giá" />
        <asp:BoundField DataField="stock" HeaderText="Số lượng" />
         <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <div class="btn-group">
                    <asp:Button ID="btnEdit" OnCommand="btnEdit_Command" runat="server" Text="Sửa" CommandName="Edit" CommandArgument='<%# Eval("product_id") %>' CssClass="btn btn-primary btn-sm" />
                    <asp:Button ID="btnDelete" OnCommand="btnDelete_Command" runat="server" Text="Xóa" CommandName="Delete" CommandArgument='<%# Eval("product_id") %>' CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa sản phẩm này không?');" />
                </div>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
              <!-- End Table with stripped rows -->

            </div>
          </div>

        </div>
      </div>
    </section>
         <div class="col-12">
              <div class="card top-selling overflow-auto">

                <div class="card-body pb-0">
                  <h5 class="card-title">Toàn bộ sản phẩm</h5>

                    <asp:GridView GridLines="None" CssClass="table table-borderless  datatable" ID="dtgProduct" runat="server" AutoGenerateColumns="false" >
                        <Columns>
                            <asp:ImageField DataImageUrlField="image" HeaderText="Ảnh sản phẩm">
                                <ItemStyle Width="100px" Height="100px" />
                    <ControlStyle Width="100px" Height="100px" />
                            </asp:ImageField>
                            <asp:BoundField DataField="name" HeaderText="Tên sản phẩm" />
                            <asp:BoundField DataField="product_id" HeaderText="Mã" />
                            <asp:BoundField DataField="sku" HeaderText="SKU" />
                            <asp:BoundField DataField="price" DataFormatString="{0:N0}" HeaderText="Giá" />
                            <asp:BoundField DataField="stock" HeaderText="Số lượng" />
                             <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <div class="btn-group">
                    <asp:Button ID="btnEdit" OnCommand="btnEdit_Command" runat="server" Text="Sửa" CommandName="Edit" CommandArgument='<%# Eval("product_id") %>' CssClass="btn btn-primary btn-sm" />
                    <asp:Button ID="btnDelete" OnCommand="btnDelete_Command" runat="server" Text="Xóa" CommandName="Delete" CommandArgument='<%# Eval("product_id") %>' CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa sản phẩm này không?');" />
                </div>
            </ItemTemplate>
        </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

              </div>
            </div>
 </div>
</asp:Content>
