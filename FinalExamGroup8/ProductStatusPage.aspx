<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPageMaster.Master" AutoEventWireup="true" CodeBehind="ProductStatusPage.aspx.cs" Inherits="FinalExamGroup8.ProductStatusPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class="pagetitle">
     <h1>Tình trạng sản phẩm</h1>
     <nav>
         <ol class="breadcrumb">
             <li class="breadcrumb-item"><a href="DashboardPage.aspx">Home</a></li>
             <li class="breadcrumb-item">Sản phẩm</li>
             <li class="breadcrumb-item active">Tình trạng sản phẩm</li>
         </ol>
     </nav>

         <asp:Label runat="server" ID="msgSuccess" class="alert alert-success bg-success text-light border-0 alert-dismissible fade show w-100" Enabled="false"/>
<asp:Label runat="server" ID="msgFail" class="alert alert-danger bg-danger text-light border-0 alert-dismissible fade show w-100" Enabled="false"/>

             <section class="section">
      <div class="row">
        <div class="col-lg-6">

          <div class="card">
            <div class="card-body">
              <h5 class="card-title">Sản phẩm bán chạy nhất</h5>
              <!-- Default Table -->
                <asp:GridView ID="dtgDesc" GridLines="None" CssClass="table datatable" runat="server" AutoGenerateColumns="false" >
    <Columns>
        <asp:ImageField DataImageUrlField="image" HeaderText="Ảnh sản phẩm">
    <ItemStyle Width="100px" Height="100px" />
    <ControlStyle Width="100px" Height="100px" />
</asp:ImageField>
        <asp:BoundField DataField="product_id" HeaderText="Mã sản phẩm" />
        <asp:BoundField DataField="name" HeaderText="Tên sản phẩm" />
        <asp:BoundField DataField="sku" HeaderText="SKU" />
        <asp:BoundField DataField="price" DataFormatString="{0:N0}" HeaderText="Giá" />
        <asp:BoundField DataField="stock" HeaderText="Số lượng còn" />
        <asp:BoundField DataField="total_sold" HeaderText="Đã bán" />
    </Columns>
</asp:GridView>
              <!-- End Default Table Example -->
            </div>
          </div>
        </div>

        <div class="col-lg-6">

          <div class="card">
            <div class="card-body">
              <h5 class="card-title">Sản phẩm không bán được</h5>

              <!-- Table with stripped rows -->
                              <asp:GridView GridLines="None" CssClass="table table-stripped  datatable" ID="dtgAsc" runat="server" AutoGenerateColumns="false" >
    <Columns>
        <asp:ImageField DataImageUrlField="image" HeaderText="Ảnh sản phẩm">
    <ItemStyle Width="100px" Height="100px" />
    <ControlStyle Width="100px" Height="100px" />
</asp:ImageField>
        <asp:BoundField DataField="product_id" HeaderText="Mã sản phẩm" />
        <asp:BoundField DataField="name" HeaderText="Tên sản phẩm" />
        <asp:BoundField DataField="sku" HeaderText="SKU" />
        <asp:BoundField DataField="price" DataFormatString="{0:N0}" HeaderText="Giá" />
        <asp:BoundField DataField="stock" HeaderText="Số lượng" />
        <asp:BoundField DataField="total_sold" HeaderText="Đã bán" />

    </Columns>
</asp:GridView>
              <!-- End Table with stripped rows -->

            </div>
          </div>

        </div>
      </div>
    </section>
 </div>
</asp:Content>
