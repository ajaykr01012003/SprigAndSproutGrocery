<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Dashbord.aspx.cs" Inherits="SprigAndSproutGrocery.View.Admin.Dashbord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <!-- Main Container -->
    <div class="container-fluid">
        
        <!-- First Row with 3 Cards -->
        <div class="row mb-5 mt-5">
            <div class="col-md-4 mt-5 col-sm-6 col-12">
                <div class="card bg-danger text-white">
                    <div class="row no-gutters">
                        <div class="col-md-4">
                            <img src="your-image-url.jpg" class="img-fluid" />
                        </div>
                        <div class="col-md-8">
                            <div class="card-body text-left">  <!-- Add text-left class here -->
                                <h5 class="card-title">Products</h5>
                                <p class="card-text" runat="server" id="pnum" >Num</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-4 mt-5 col-sm-6 col-12">
                <div class="card bg-warning text-white">
                    <div class="row no-gutters">
                        <div class="col-md-4">
                            <img src="your-image-url.jpg" class="img-fluid" />
                        </div>
                        <div class="col-md-8">
                            <div class="card-body text-left">  <!-- Add text-left class here -->
                                <h5 class="card-title">Category</h5>
                                <p class="card-text" runat="server" id="catnum">Num</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-4 mt-5 col-sm-6 col-12">
                <div class="card bg-primary text-white">
                    <div class="row no-gutters">
                        <div class="col-md-4">
                            <img src="your-image-url.jpg" class="img-fluid"  />
                        </div>
                        <div class="col-md-8">
                            <div class="card-body text-left">  <!-- Add text-left class here -->
                                <h5 class="card-title">Finance</h5>
                                <p class="card-text" runat="server" id="fnum">Num</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    
            <div class="col-md-4 mt-5 col-sm-6 col-12">
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>

                <div class="card bg-danger text-white">
                    <div class="row no-gutters">
                        <div class="col-md-4">
                            <img src="your-image-url.jpg" class="img-fluid"  />
                        </div>
                        <div class="col-md-8">
                            <div class="card-body text-left">  <!-- Add text-left class here -->
                                <h5 class="card-title">Category Amounts</h5>
                                <p class="card-text" runat="server" id="catamontnum">Num</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-4 mt-5 col-sm-6 col-12">
                <div class="card bg-warning text-white">
                    <div class="row no-gutters">
                        <div class="col-md-4">
                            <img src="your-image-url.jpg" class="img-fluid"  />
                        </div>
                        <div class="col-md-8">
                            <div class="card-body text-left">  <!-- Add text-left class here -->
                                <h5 class="card-title">Total Sales</h5>
                                <p class="card-text" runat="server" id="totalselnum">Num</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-4 mt-5 col-sm-6 col-12">
                <div class="card bg-primary text-white">
                    <div class="row no-gutters">
                        <div class="col-md-4">
                            <img src="your-image-url.jpg" class="img-fluid" />
                        </div>
                        <div class="col-md-8">
                            <div class="card-body text-left">  <!-- Add text-left class here -->
                                <h5 class="card-title">Sellers</h5>
                                <p class="card-text" runat="server" id="selnum">Num</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div> 

        <div class="row">
            <div class="col-4"></div>
             <div class="col-4">
                 <img  src="../../Asset/Images/grocery.jpg" style="height:200px;"/>
             </div>
                z<div class="col-4"></div>

        </div>

    </div>
</asp:Content>
