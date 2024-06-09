<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPageMaster.Master" AutoEventWireup="true" CodeBehind="OtherProductPage.aspx.cs" Inherits="FinalExamGroup8.OtherProductPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="col-12">
    <div class="card top-selling overflow-auto">

        <asp:Label runat="server" ID="msgSuccess" class="alert alert-success bg-success text-light border-0 alert-dismissible fade show w-100" Enabled="false"/>
        <asp:Label runat="server" ID="msgFail" class="alert alert-danger bg-danger text-light border-0 alert-dismissible fade show w-100" Enabled="false"/>
        
        <div class="card-body pb-0">
            <h5 class="card-title">Toàn bộ sản phẩm khác</h5>
            
            <div class="col-md-4">
    <label for="ddlCategory" class="form-label">Danh mục</label>
            <asp:DropDownList runat="server" ID="ddlCategory" CssClass="form-select"  AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" />

</div>

            <!-- Add DropDownList for category selection -->

          <div class="card" runat="server" id="emptyLayout">
            <div class="card-body">
              <h5 class="card-title">Thông báo</h5>
              <p>Danh mục sản phẩm này đang trống, vui lòng thêm dữ liệu hoặc xem sản phẩm khác!</p>
            </div>
          </div>

            <asp:GridView GridLines="None" CssClass="table table-borderless  datatable" ID="dtgProduct" runat="server" AutoGenerateColumns="false" OnRowDeleting="dtgProduct_RowDeleting">
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

</asp:Content>
