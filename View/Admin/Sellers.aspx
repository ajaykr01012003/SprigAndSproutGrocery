<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Sellers.aspx.cs" Inherits="SprigAndSproutGrocery.View.Admin.Sellers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">

    <div class="container-fluid">
       
        <div class="row">
            <!-- Left side: Form -->
            <div class="col-md-6">
                <h2 class="text-danger">Sellers Details</h2>

                <div>
                    <label id="errmsg" runat="server" class="text-danger"></label>
                </div>

                <div class="mb-3">
                    <label class="form-label" runat="server" for="sellername">Seller Name:</label>
                    <input type="text" class="form-control" id="sellername" runat="server" name="sellername" required />
                </div>

                <div class="mb-3">
                    <label class="form-label" for="selleremail">Seller Email:</label>
                    <input type="email" class="form-control" runat="server" id="selleremail" name="email" required />
                </div>

                <div class="mb-3">
                    <label class="form-label" for="sellerpassword">Seller Password:</label>
                    <input type="text" class="form-control" runat="server" id="sellerpassword" name="sellerpassword" required />
                </div>

                <div class="mb-3">
                    <label class="form-label" for="sellerphone">Seller Phone:</label>
                    <input type="text" class="form-control" runat="server" id="sellerphone" name="sellerphone" required />
                </div>

                <div class="mb-3">
                    <label class="form-label" for="selleraddresh">Seller Address:</label>
                    <input type="text" class="form-control" runat="server" id="selleraddresh" name="selleraddresh" required />
                </div>

                <div style="margin-top: 20px">
                    <asp:Button Text="Edit" class="btn btn-danger" runat="server" ID="Editbtn" OnClick="Editbtn_Click" />
                    <asp:Button Text="Save" class="btn btn-danger" runat="server" ID="Savebtn" OnClick="Savebtn_Click" />
                    <asp:Button Text="Delete" class="btn btn-danger" runat="server" ID="Deletebtn" OnClick="Deletebtn_Click" />
                </div>
            </div>

            <!-- Right side: GridView -->
            <div class="col-md-6">
                 <div class="row">
     <div class="col-md-12">
         <br />
         <img src="../../Asset/Images/vegiterian_img.jpg" style="width: 100px; height: auto;" />
         <h4 class="text-danger">Manage Products</h4>
     </div>
 </div> 
                <h2 class="text-danger">Seller List</h2>
                <asp:GridView runat="server" class="table table-hover" ID="sellergv" AutoGenerateSelectButton="True" OnSelectedIndexChanged="sellergv_SelectedIndexChanged">
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
