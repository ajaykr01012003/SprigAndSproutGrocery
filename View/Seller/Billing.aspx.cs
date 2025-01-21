using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SprigAndSproutGrocery.View.Seller
{
    public partial class Billing : System.Web.UI.Page
    {
        Models.Functions con;
        DataTable dt=new DataTable();
        int Seller=Login.skey;
        protected void Page_Load(object sender, EventArgs e)
        {

            con = new Models.Functions();
            ShowProducts();
            //GetAllCategory();

            if (!this.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5]
                {
                    new DataColumn("ID"),
                    new DataColumn("Product"),
                    new DataColumn("Price"),
                    new DataColumn("Quantity"),
                    new DataColumn("Total")
                });
                ViewState["Bill"]=dt;
                this.DataBind();
            }
             
        }

        protected void BindiGrid()
        {
            BillGV.DataSource = (DataTable)ViewState["Bill"];
            BillGV.DataBind();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }


        public static int amount;
        public void InsertBill()
        {
            try
            {
              
                
                    // Specify the columns explicitly
                    string Quiry = "INSERT INTO  (bildate, seller, amount) " +
                                   "VALUES ('{0}', {1}, {2})";
                    Quiry = string.Format(Quiry, System.DateTime.Today, Seller, amount);
                     con.setdata(Quiry);
                    errmsg.InnerText = "Bill Successfully Added!!!";

              


                
            }
            catch (Exception ex)
            {
                errmsg.InnerText = ex.Message;
            }
        }
        protected void ShowProducts()
        {
            string Query = "select pid as ID, pname as Name, pcat as Category, pprice as Price,pqty as Quantity  from Products";
            productGV.DataSource = con.getdata(Query);
            productGV.DataBind();

        }

        int key = 0;
        int stock;

        protected void productGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                productname.Value = productGV.SelectedRow.Cells[2].Text;
                // productcategories.DataTextField = productGV.SelectedRow.Cells[3].Text;
                productprice.Value = productGV.SelectedRow.Cells[4].Text;
                // Parse the stock value
               stock = int.Parse(productGV.SelectedRow.Cells[5].Text);

                errmsg.InnerText = "Rs. " + stock;

                //// Check if the stockText is a valid integer
                //if (int.TryParse(stockText, out stock))
                //{
                //    errmsg.InnerText = "Stock: " + stock;
                //}
                //else
                //{
                //    errmsg.InnerText = "Invalid stock value.";
                //    stock = 0; // Set a default value or handle appropriately
                //}

                if (string.IsNullOrEmpty(productname.Value))
                {
                    key = 0;
                }
                else
                {
                    // Assuming the key is in the first cell (Cells[1]) and it's a numeric value
                    key = Convert.ToInt32(productGV.SelectedRow.Cells[1].Text);
                }
            }catch( Exception ex)
            {
                errmsg.InnerText = ex.Message;  
            }
        }

        protected void UpdateStock()
        {
            int newQty;
            newQty = stock-Convert.ToInt32(productqty.Value);

            // Specify the columns explicitly
            string Quiry = "update Products  set pqty='{0}' where pid={1}";

            Quiry = string.Format(Quiry, newQty, productGV.SelectedRow.Cells[1].Text);
            con.setdata(Quiry);
            ShowProducts();
            errmsg.InnerText = "Quantity Successfully DATA Updated!!!";

            productname.Value = "";
          
            productprice.Value = "";
           

        }


        protected void AddToBill_Click(object sender, EventArgs e)
        {
            int total=Convert.ToInt32(productqty.Value) * Convert.ToInt32(productprice.Value);
            DataTable dt = (DataTable)ViewState["Bill"];
            dt.Rows.Add(BillGV.Rows.Count+1,
                productname.Value.Trim(),
                productprice.Value.Trim(),
                productqty.Value.Trim(),
                total
                
                );

            ViewState["Bill"] = dt;
            this.BindiGrid();
            UpdateStock();
            int gridtotal=0;
            for(int i=0; i<BillGV.Rows.Count; i++)
            {
                gridtotal = gridtotal + Int32.Parse(BillGV.Rows[i].Cells[4].Text.ToString());
            }

            amount = gridtotal;
            gtotal.InnerText = "Rs. " + gridtotal;

            // gridtotal = (Convert.ToInt32(productqty.Value) * Convert.ToInt32(productprice.Value));

            gtotal.InnerText = "";
            productname.Value = "";
            productprice.Value = "";
            productqty.Value = "";
        }

        protected void ExportToExcel(object sender, EventArgs e)
        {
            // Clear response to prevent any unwanted output before we start sending the Excel data.
            Response.Clear();
            Response.Buffer = true;

            // Set the file name and ensure the file is downloaded as an Excel file
            Response.AddHeader("content-disposition", "attachment;filename=ExportedData.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";

            // Create a StringWriter and HtmlTextWriter to render the GridView
            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    // Render the GridView to the HtmlTextWriter
                    BillGV.RenderControl(hw);

                    // Output the content to the response stream
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
        }

        protected void BtnPrint_Click(object sender, EventArgs e)
        {
            InsertBill();
        }
    }
}