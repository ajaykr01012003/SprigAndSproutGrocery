using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SprigAndSproutGrocery.View.Admin
{
    public partial class Cotegories : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            ShowCategories();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void ShowCategories()
        {
            string Query = "select * from Category";
            categoryGV.DataSource = con.getdata(Query);
            categoryGV.DataBind();

        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (categoryname.Value == "" || categoryremark.Value == "")
                {
                    errmsg.InnerText = "Missing Data field";
                }
                else
                {
                    String cname = categoryname.Value;
                    string crem = categoryremark.Value;


                    // Specify the columns explicitly
                    string Quiry = "INSERT INTO Category (catname, catdescription) " +
                                   "VALUES ('{0}', '{1}')";
                    Quiry = string.Format(Quiry, cname, crem);
                    con.setdata(Quiry);
                    ShowCategories();
                    errmsg.InnerText = "Category Successfully Added!!!";

                    categoryname.Value = "";
                    categoryremark.Value = "";



                }
            }
            catch (Exception ex)
            {
                errmsg.InnerText = ex.Message;
            }
        }

      

        int key = 0;

        protected void categoryGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoryname.Value = categoryGV.SelectedRow.Cells[2].Text;
            categoryremark.Value = categoryGV.SelectedRow.Cells[3].Text;

            if (categoryname.Value=="")
            {
                key = 0;
            }
            else
            {
                // Assuming the key is in the first cell (Cells[1]) and it's a numeric value
                key = Convert.ToInt32(categoryGV.SelectedRow.Cells[1].Text);
            }
         
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (categoryname.Value == "" || categoryremark.Value == "" )
                {
                    errmsg.InnerText = "Missing Data field";
                }
                else
                {
                    String sname = categoryname.Value;
                    string catdes = categoryremark.Value;
                 

                    // Specify the columns explicitly
                    string Quiry = "update Category  set catname='{0}', catdescription='{1}' where catid='{2}'";

                    Quiry = string.Format(Quiry, sname, catdes, categoryGV.SelectedRow.Cells[1].Text);
                    con.setdata(Quiry);
                    ShowCategories();
                    errmsg.InnerText = "category Successfully DATA Updated!!!";

                    categoryname.Value = "";
                    categoryremark.Value = "";
                   


                }
            }
            catch (Exception ex)
            {
                errmsg.InnerText = ex.Message;
            }

        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (categoryname.Value == "")
                {
                    errmsg.InnerText = "Missing Data field";
                }
                else
                {
                    String sname = categoryname.Value;


                    // Specify the columns explicitly
                    string Quiry = "delete from Category where catid={0}";
                    Quiry = string.Format(Quiry, categoryGV.SelectedRow.Cells[1].Text);
                    con.setdata(Quiry);
                    ShowCategories();
                    errmsg.InnerText = "Category Successfully Deleted!!!";

                    categoryname.Value=string.Empty;
                    categoryremark.Value=string.Empty;

                }
            }
            catch (Exception ex)
            {
                errmsg.InnerText = ex.Message;
            }
        }
    }
}