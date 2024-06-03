<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPageMaster.Master" AutoEventWireup="true" CodeBehind="AddProductPage.aspx.cs" Inherits="FinalExamGroup8.AddProductPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <% FinalExamGroup8.model.Product product = Session["product"] as FinalExamGroup8.model.Product; %>
    <div class="pagetitle">
        <h1>Sản phẩm</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="DashboardPage.aspx">Home</a></li>
                <li class="breadcrumb-item"><a href="ProductMobilePage.aspx">Điện thoại</a></li>
                <li class="breadcrumb-item active">Chi tiết sản phẩm</li>
            </ol>
        </nav>
    </div>
    <!-- End Page Title -->
    <section class="section">
    <div class="row">
        <div class="col-lg-6">
            <div class="card">
                 <asp:Label runat="server" ID="msgSuccess" class="alert alert-success bg-success text-light border-0 alert-dismissible fade show w-100" Enabled="false"/>
 <asp:Label runat="server" ID="msgFail" class="alert alert-danger bg-danger text-light border-0 alert-dismissible fade show w-100" Enabled="false"/>
                <div class="card-body">
                    <h5 class="card-title">
                        <%= (product == null) ? "Thêm sản phẩm" : "Sửa sản phẩm" %>
                    </h5>   

                    <!-- Multi Columns Form -->
                    <div class="col-md-12 mb-3">
                        <label for="tbSku" class="form-label">SKU</label>
                        <input type="text" class="form-control" id="tbSku" runat="server" placeholder="Nhập sku sản phẩm">
                    </div>

                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="tbPrice" class="form-label">Giá tiền</label>
                            <input runat="server" type="number" class="form-control" id="tbPrice" step="0.01" placeholder="Enter a decimal number">
                        </div>

                        <div class="col-md-6">
                            <label for="tbStock" class="form-label">Số lượng</label>
                            <input runat="server" type="number" class="form-control" id="tbStock">
                        </div>
                    </div>

                    <div class="col-12 mb-3">
                        <label for="tbName" class="form-label">Tên sản phẩm</label>
                        <input runat="server" type="text" class="form-control" id="tbName" placeholder="Nhập tên sản phẩm">
                    </div>

                    <div class="row mb-3">
                        <div class="col-md-4">
                            <label for="ddlCategory" class="form-label">Danh mục</label>
                            <asp:DropDownList CssClass="form-select" ID="ddlCategory" runat="server" />
                        </div>

                        <div class="col-md-4">
                            <label for="inputImage" class="form-label">Ảnh</label>
    <asp:FileUpload ID="inputImage" runat="server" CssClass="form-control" accept="image/*" OnChange="previewImage(event)" />
                        </div>
                        <div class="col-md-4">
                            <label for="imagePreview" class="form-label">Preview</label>
                            <img runat="server" id="imagePreview" alt="Image Preview" style="display:none;" class="img-thumbnail"/>
                        </div>
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
    
<script>
    function previewImage(event) {
        var input = event.target;
        var reader = new FileReader();
        reader.onload = function () {
            var dataURL = reader.result;
            var output = document.getElementById('imagePreview');
            output.src = dataURL;
            output.style.display = 'block';
        };
        reader.readAsDataURL(input.files[0]);
    }
</script>
    
</asp:Content>



