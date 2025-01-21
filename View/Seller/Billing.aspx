<%@ Page Title="" Language="C#" MasterPageFile="~/View/Seller/SellerMaster.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="SprigAndSproutGrocery.View.Seller.Billing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script type="text/javascript">
    function PrintPannel() {
        var pgrid = document.getElementById('<%= BillGV.ClientID %>');
        if (pgrid) {
            pgrid.border = 0;
            var pwin = window.open('', 'PrintGrid', 'left=100,top=100,width=1024,height=768,toolbar=0,scrollbar=1,status=0,resizable=1');

            // Write the HTML structure and include styles
            pwin.document.write('<html><head><title>Print Grid</title>');
            pwin.document.write('<style>');
            pwin.document.write('table { width: 100%; border-collapse: collapse; font-family: Arial, sans-serif; }');
            pwin.document.write('table, th, td { border: 1px solid black; }');
            pwin.document.write('th, td { padding: 8px; text-align: left; }');
            pwin.document.write('h1 { text-align: center; margin-bottom: 20px; }');
            pwin.document.write('</style>');
            pwin.document.write('</head><body>');
            pwin.document.write('<h1>Client Bill Preview</h1>');
            pwin.document.write(pgrid.outerHTML);
            pwin.document.write('</body></html>');

            pwin.document.close();  // Close the document to complete the writing
            pwin.focus();  // Focus on the new window

            // Delay before printing to ensure the content is fully loaded
            setTimeout(function () {
                pwin.print();
                pwin.close();
            }, 500);  // 500 ms delay for rendering
        } else {
            console.error('Grid element not found.');
        }
    }
</script>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">

    <div class="container-fluid">
     <div class="d-flex justify-content-center align-items-center">
    <img src="../../Asset/Images/doller.png" class="img-fluid" style="max-width: 15%; height: auto; margin-top:50px;" />
</div>
        <div class="row">
            <!-- Left Column for Product Form and GridView -->
            <div class="col-md-5">
                <!-- Product Form -->
             <div class="row">
                <div class="card mb-3">
                    <div class="card-body">
                        <h4 class="text-danger">Product Details</h4>
                        <div class="mb-3">
                            <label class="form-label" for="productname">Product Name:</label>
                            <input type="text" class="form-control" runat="server" id="productname" name="productname" required />
                        </div>
                        <div class="mb-3">
                            <label class="form-label" for="productprice">Product Price:</label>
                            <input type="text" class="form-control" runat="server" id="productprice" name="productprice" required />
                        </div>
                        <div class="mb-3">
                            <label class="form-label" for="productqty">Product Quantity:</label>
                            <input type="text" class="form-control" runat="server" id="productqty" name="productqty" required />
                        </div>
                    </div>
                </div>

                 <div class="col">
                      <label id="errmsg" runat="server" class="text-danger"></label>
                     <asp:Button Text="Add To Bill" class="btn btn-danger w-100 btn-block" style = "margin-top:10px" runat="server" ID="AddToBill" OnClick="AddToBill_Click" />
                    <asp:Button Text="Reset" class="btn btn-danger w-100 btn-block" style = "margin-top:10px" runat="server" ID="ResetBtn" /> 
                 </div>
               </div>
                

                <!-- Product List GridView -->
                <div class="card">
                    <div class="card-body">
                        <h4 class="text-danger">Products List</h4>
                        <asp:GridView runat="server" CssClass="table table-hover" ID="productGV" AutoGenerateSelectButton="True" Width="40px" OnSelectedIndexChanged="productGV_SelectedIndexChanged">
                        </asp:GridView>
                    </div>
                </div> 

             <div class="row">
           <div class="col"></div>
           <div class="col"><labal id="gtotal" class="text-danger" runat="server"></labal></div>

            </div> 

            </div>

     
            <!-- Right Column Placeholder -->
            <div class="col-md-6">
                <!-- Add your content for the right column here -->
                <div class="card">
                    <div class="card-body">                        
                        <!-- Add more content as needed -->
                       
                        <div class="row">
                          <div class="col"><asp:Button Text="Print Bill" class="btn btn-warning text-white  btn-block" style = "margin-top:10px" OnClientClick="PrintPannel()" runat="server" ID="BtnPrint" OnClick="BtnPrint_Click" /> </div>
                           <div class="col" ><asp:Button Text="Export to Excel" class="btn btn-success" OnClick="ExportToExcel" runat="server" ID="BtnExportExcel" /></div>

      
                            <div class="col-3"></div>
                              <div class="col"><h1 class="text-warning pl-2">Clinet Billing</h1></div>
                            </div>
                        <div class="row">
                            <asp:GridView ID="BillGV" runat="server" class ="table" CellPadding="4" ForeColor="#333333" GridLines="None" >
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                            </asp:GridView> 
                            
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
