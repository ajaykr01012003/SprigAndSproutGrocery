using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SprigAndSproutGrocery.Models
{
    public class Functions
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConnString;

        public Functions()
        {

            ConnString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Documents\\SprigAndSproutGrocery.mdf;Integrated Security=True;Connect Timeout=30";
            con= new SqlConnection(ConnString);
            cmd = new SqlCommand();
            cmd.Connection = con;

        }
        public DataTable getdata(string Query)
        {
            try
            {
                dt = new DataTable();
                cmd.CommandText = Query;
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
              
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }


        public int setdata(string Query)
        {
            int cnt = 0;

            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.CommandText = Query;
            cnt=cmd.ExecuteNonQuery();
            con.Close();


            return cnt;
        }

    }
}