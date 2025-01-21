using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SprigAndSproutGrocery.View.Admin
{
    public partial class Products : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            con = new Models.Functions();
            ShowProducts();
            GetAllCategory();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

     
        protected void ShowProducts()
        {
            string Query = "select * from Products";
            productGV.DataSource = con.getdata(Query);
            productGV.DataBind();

        }

        public void GetAllCategory()
        {
            string Query = "Select * from Category";
            productcategories.DataTextField = con.getdata(Query).Columns["catname"].ToString();
            productcategories.DataTextField = con.getdata(Query).Columns["catid"].ToString();
            productcategories.DataSource = con.getdata(Query);
            productcategories.DataBind();

        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (productname.Value == "" || productcategories.DataTextField == "" || productprice.Value == "" || productquantity.Value == "" || productexpdate.Value == "")
                {
                    errmsg.InnerText = "Missing Data field";
                }
                else
                {
                    String pname = productname.Value;
                    int pcat = int.Parse(productcategories.SelectedValue);
                    int pprice = int.Parse(productprice.Value);
                    int pqty = int.Parse(productquantity.Value);
                    string pexpdate = productexpdate.Value;

                    // Specify the columns explicitly
                    string Quiry = "INSERT INTO Products (pname, pcat, pprice, pqty, pexpdate) " +
                                   "VALUES ('{0}', {1}, {2}, {3}, '{4}')";
                    Quiry = string.Format(Quiry, pname, pcat, pprice, pqty, pexpdate);
                    con.setdata(Quiry);
                    ShowProducts();
                    errmsg.InnerText = "Product Successfully Added!!!";

                    productname.Value = "";
                    productcategories.DataTextField = "";
                    productprice.Value = "";
                    productquantity.Value = "";
                    productexpdate.Value = "";


                }
            }
            catch (Exception ex)
            {
                errmsg.InnerText = ex.Message;
            }
        }

        int key = 0;
        protected void productGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            productname.Value = productGV.SelectedRow.Cells[2].Text;
            productcategories.DataTextField= productGV.SelectedRow.Cells[3].Text;
            productprice.Value = productGV.SelectedRow.Cells[4].Text;
            productquantity.Value = productGV.SelectedRow.Cells[5].Text;
            productexpdate.Value = productGV.SelectedRow.Cells[6].Text;

            if (string.IsNullOrEmpty(productname.Value))
            {
                key = 0;
            }
            else
            {
                // Assuming the key is in the first cell (Cells[1]) and it's a numeric value
                key = Convert.ToInt32(productGV.SelectedRow.Cells[1].Text);
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (productname.Value == "")
                {
                    errmsg.InnerText = "Missing Data field";
                }
                else
                {
                    String sname = productname.Value;


                    // Specify the columns explicitly
                    string Quiry = "delete from Products where pid={0}";
                    Quiry = string.Format(Quiry, productGV.SelectedRow.Cells[1].Text);
                    con.setdata(Quiry);
                    ShowProducts();
                    errmsg.InnerText = "Product Successfully Deleted!!!";

                    productname.Value = "";
                    productcategories.DataTextField = "";
                    productprice.Value = "";
                    productquantity.Value = "";
                    productexpdate.Value = "";


                }
            }
            catch (Exception ex)
            {
                errmsg.InnerText = ex.Message;
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {

                if (productname.Value == "" || productcategories.DataTextField == "" || productprice.Value == "" || productquantity.Value == "" || productexpdate.Value == "")
                {
                    errmsg.InnerText = "Missing Data field";
                }
                else
                {

                    String pname = productname.Value;
                    int pcat = int.Parse(productcategories.SelectedValue);
                    int pprice = int.Parse(productprice.Value);
                    int pqty = int.Parse(productquantity.Value);
                    string pexpdate = productexpdate.Value;

                    // Specify the columns explicitly
                    string Quiry = "update Products  set pname='{0}', pcat={1}, pprice={2}, pqty={3}, pexpdate='{4}' where pid={5}";

                    Quiry = string.Format(Quiry, pname, pcat, pprice, pqty, pexpdate, productGV.SelectedRow.Cells[1].Text);
                    con.setdata(Quiry);
                    ShowProducts();
                    errmsg.InnerText = "Product Successfully DATA Updated!!!";

                    productname.Value = "";
                    productcategories.DataTextField = "";
                    productprice.Value = "";
                    productquantity.Value = "";
                    productexpdate.Value = "";


                } 
            }
            catch (Exception ex)
            {
                errmsg.InnerText = ex.Message;
            }
        }
    }
}