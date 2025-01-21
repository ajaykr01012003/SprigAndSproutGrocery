using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SprigAndSproutGrocery.View.Admin
{
    public partial class Dashbord : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {

            con = new Models.Functions();
            GetAllCategory();
            getProducts();
            getCategories();
            sumSelbySeller();
            sumselFinance();
            getSellers();
            
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        private void getProducts()
        {
            string Query = "Select Count(*) from Products";
            pnum.InnerText = con.getdata(Query).Rows[0][0].ToString();
            pnum.DataBind();
        }

        private void getCategories()
        {
            string Query = "Select Count(*) from Category";
            catnum.InnerText = con.getdata(Query).Rows[0][0].ToString();
            catnum.DataBind();
        }

        private void getSellers()
        {
            string Query = "Select Count(*) from Seller";
            selnum.InnerText = con.getdata(Query).Rows[0][0].ToString();
            selnum.DataBind();
        }

        public void GetAllCategory()
        {
            string Query = "Select * from Category";
            DropDownList1.DataTextField = con.getdata(Query).Columns["catname"].ToString();
            DropDownList1.DataTextField = con.getdata(Query).Columns["catid"].ToString();
            DropDownList1.DataSource = con.getdata(Query);
            DropDownList1.DataBind();

        }
        private void sumselFinance()
        {

            string Query = "Select Sum(amount) from Bill";
            fnum.InnerText = "Rs. " + con.getdata(Query).Rows[0][0].ToString();
            fnum.DataBind();
        }
        private void sumSelbySeller()
        {

            string Query = "Select Sum(amount) from Bill where seller= "+DropDownList1.SelectedValue+" ";
            totalselnum.InnerText ="Rs. "+ con.getdata(Query).Rows[0][0].ToString();
            totalselnum.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sumSelbySeller();
        }
    }
}