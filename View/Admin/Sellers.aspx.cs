using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SprigAndSproutGrocery.View.Admin
{
    public partial class Sellers : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            ShowSellers();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
           
        }

        protected void ShowSellers()
        {
            string Query = "select * from Seller";
            sellergv.DataSource = con.getdata(Query);
            sellergv.DataBind();

        }
        protected void Editbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (sellername.Value == "" || selleremail.Value == "" || sellerpassword.Value == "" || sellerphone.Value == "" || selleraddresh.Value == "")
                {
                    errmsg.InnerText = "Missing Data field";
                }
                else
                {
                    String sname = sellername.Value;
                    string semail = selleremail.Value;
                    string spassword = sellerpassword.Value;
                    string spnone = sellerphone.Value;
                    string saddres = selleraddresh.Value;

                    // Specify the columns explicitly
                    string Quiry = "update Seller  set selname='{0}', selemail='{1}', selpassword='{2}', selphone='{3}', seladdresh='{4}' where selid='{5}'";
                                
                    Quiry = string.Format(Quiry, sname, semail, spassword, spnone, saddres, sellergv.SelectedRow.Cells[1].Text);
                    con.setdata(Quiry);
                    ShowSellers();
                    errmsg.InnerText = "Seller Successfully DATA Updated!!!";

                    sellername.Value = "";
                    selleremail.Value = "";
                    sellerpassword.Value = "";
                    sellerphone.Value = "";
                    selleraddresh.Value = "";


                }
            }
            catch (Exception ex)
            {
                errmsg.InnerText = ex.Message;
            }
        }

    
        protected void Savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (sellername.Value == "" || selleremail.Value == "" || sellerpassword.Value == "" || sellerphone.Value == "" || selleraddresh.Value == "")
                {
                    errmsg.InnerText = "Missing Data field";
                }
                else
                {
                    String sname = sellername.Value;
                    string semail = selleremail.Value;
                    string spassword = sellerpassword.Value;
                    string spnone = sellerphone.Value;
                    string saddres = selleraddresh.Value;

                    // Specify the columns explicitly
                    string Quiry = "INSERT INTO Seller (selname, selemail, selpassword, selphone, seladdresh) " +
                                   "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";
                    Quiry = string.Format(Quiry, sname, semail, spassword, spnone, saddres);
                    con.setdata(Quiry);
                    ShowSellers();
                    errmsg.InnerText = "Seller Successfully Added!!!";

                    sellername.Value = "";
                    selleremail.Value = "";
                    sellerpassword.Value = "";
                    sellerphone.Value = "";
                    selleraddresh.Value = "";
             

                }
            }
            catch (Exception ex)
            {
                errmsg.InnerText = ex.Message;
            }
        }

        int key = 0;
        protected void sellergv_SelectedIndexChanged(object sender, EventArgs e)
        {
            sellername.Value = sellergv.SelectedRow.Cells[2].Text;
            selleremail.Value = sellergv.SelectedRow.Cells[3].Text;
            sellerpassword.Value = sellergv.SelectedRow.Cells[4].Text;
            sellerphone.Value = sellergv.SelectedRow.Cells[5].Text;
            selleraddresh.Value = sellergv.SelectedRow.Cells[6].Text;

            if (string.IsNullOrEmpty(sellername.Value))
            {
                key = 0;
            }
            else
            {
                // Assuming the key is in the first cell (Cells[1]) and it's a numeric value
                key = Convert.ToInt32(sellergv.SelectedRow.Cells[1].Text);
            }
        }

        protected void Deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (sellername.Value == "")
                {
                    errmsg.InnerText = "Missing Data field";
                }
                else
                {
                    String sname = sellername.Value;


                    // Specify the columns explicitly
                    string Quiry = "delete from Seller where selid={0}";
                    Quiry = string.Format(Quiry, sellergv.SelectedRow.Cells[1].Text);
                    con.setdata(Quiry);
                    ShowSellers();
                    errmsg.InnerText = "Seller Successfully Deleted!!!";

                    sellername.Value = "";
                    selleremail.Value = "";
                    sellerpassword.Value = "";
                    sellerphone.Value = "";
                    selleraddresh.Value = "";


                }
            }
            catch (Exception ex)
            {
                errmsg.InnerText = ex.Message;
            }
        }
    }
}