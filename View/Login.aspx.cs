using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SprigAndSproutGrocery.View
{
    public partial class Login : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
        }

        public static string sname;
        public static int skey;

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void LoginAdmin_Click(object sender, EventArgs e)
        {
            if (adminradio.Checked)
            {
                if(email.Value== "Admin@123" && password.Value=="Admin")
                {
                    Response.Redirect("Admin/Sellers.aspx");
                }
                else
                {
                    loginmsg.InnerText = "Invalid Sellerid and password !!! ";
                }
            }
            else
            {
                string Query = "select selid, selname selemail, selpassword from Seller where selemail='{0}' and selpassword='{1}'";
                Query = string.Format(Query, email.Value, password.Value);
                DataTable dt = con.getdata(Query);  
                if(dt.Rows.Count == 0)
                {
                    loginmsg.InnerText = "User invalid!!";
                }
                else
                {
                    sname = email.Value;
                    skey = Convert.ToInt32(dt.Rows[0][0].ToString());
                    Response.Redirect("Seller/Billing.aspx");
                }

            }
        }
    }
}