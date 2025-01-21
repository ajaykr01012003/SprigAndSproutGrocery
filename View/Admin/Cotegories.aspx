<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Cotegories.aspx.cs" Inherits="SprigAndSproutGrocery.View.Admin.Cotegories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <h2 class="text-danger">Category Details</h2>
                        <div>
                            <label id="errmsg" runat="server" class="text-danger"></label>
                        </div>
                        <div class="mb-2">
                            <label class="form-label" for="categoryname">Category Name:</label>
                            <input type="text" class="form-control" id="categoryname" name="categoryname" runat="server" required>
                        </div>
                        <div class="mb-2">
                            <label class="form-label" for="categoryremark">Category Remarks:</label>
                            <input type="text" class="form-control" id="categoryremark" name="categoryremark" runat="server" required>
                        </div>
                        <div style="margin-top: 20px">
                            <asp:Button Text="Edit" class="btn btn-danger w-100 btn-block" style = "margin-top:10px" runat="server" ID="EditBtn" OnClick="EditBtn_Click" />
                            <asp:Button Text="Save" class="btn btn-danger w-100 btn-block" style = "margin-top:10px" runat="server" ID="SaveBtn" OnClick="SaveBtn_Click" />
                            <asp:Button Text="Delete" class="btn btn-danger w-100 btn-block" style = "margin-top:10px" runat="server" ID="DeleteBtn" OnClick="DeleteBtn_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-8">
                <div class="card">
                    <div class="card-body">
                        <h2 class="text-danger"> Category List</h2>
                        <asp:GridView runat="server" class="table table-hover" ID="categoryGV" AutoGenerateSelectButton="True" OnSelectedIndexChanged="categoryGV_SelectedIndexChanged">
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
