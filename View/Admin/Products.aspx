<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="SprigAndSproutGrocery.View.Admin.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <h2 class="text-danger">Products Details</h2>
                        <label id="errmsg" runat="server" class="text-danger"></label>

                        <div class="mb-3">
                            <label class="form-label" for="productname">Product Name:</label>
                            <input type="text" class="form-control" runat="server" id="productname" name="productname" required />
                        </div>
<div class="mb-3">
    <label class="form-label" for="productcategories">Product Categories:</label>
    <asp:DropDownList ID="productcategories" CssClass="form-control" runat="server" AutoPostBack="True"></asp:DropDownList>
    <asp:HiddenField ID="HiddenField1" runat="server" />
</div>

                        <div class="mb-3">
                            <label class="form-label" for="productprice">Product Price:</label>
                            <input type="text" class="form-control" runat="server" id="productprice" name="productprice" required>
                        </div>
                        <div class="mb-3">
                            <label class="form-label" for="productquantity">Product Quantity:</label>
                            <input type="text" class="form-control" runat="server" id="productquantity" name="productquality" required>
                        </div>
                        <div class="mb-3">
                            <label class="form-label" for="productexpdate">Expiration Date:</label>
                            <input type="date" class="form-control" runat="server" id="productexpdate" name="expdate">
                        </div>
                        <div style="margin-top: 20px">
                            <asp:Button Text="Edit" class="btn btn-danger w-100 btn-block" style = "margin-top:10px" runat="server" ID="EditBtn" OnClick="EditBtn_Click"  />
                            <asp:Button Text="Save" class="btn btn-danger w-100 btn-block" style = "margin-top:10px" runat="server" ID="SaveBtn" OnClick="SaveBtn_Click"  />
                            <asp:Button Text="Delete" class="btn btn-danger w-100 btn-block" style = "margin-top:10px" runat="server" ID="DeleteBtn" OnClick="DeleteBtn_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-8">
                <div class="card">
                    <div class="card-body">
                        <h2 class="text-danger">Products List</h2>
                        <asp:GridView runat="server" class="table table-hover" ID="productGV" AutoGenerateSelectButton="True" OnSelectedIndexChanged="productGV_SelectedIndexChanged">
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
