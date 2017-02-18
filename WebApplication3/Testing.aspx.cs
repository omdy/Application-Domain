using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace WebApplication3
{
    public partial class Testing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con.Open();

            //SELECT `Account` FROM `chartofaccounts`.`accountbalances` WHERE `Pending+Value` =  '1000';

            String coaDB = "SELECT `Pending+Value` FROM `chartofaccounts`.`accountbalances` WHERE `Account` =  'Cash'";
            MySqlCommand cmd = new MySqlCommand(coaDB, con);

            MySqlDataReader reader = cmd.ExecuteReader();

            
            if (reader.Read())
            {
                 String s = reader.GetValue(0).ToString();
                TextBox1.Text = s;
            }

            MySqlConnection con2 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con2.Open();

            String abDB = "UPDATE `chartofaccounts`.`accountbalances` SET `Pending+Value` = '1020' WHERE `Account` = 'Cash'";
            MySqlCommand cmd2 = new MySqlCommand(abDB, con2);
            Response.Write(abDB);
            cmd2.ExecuteNonQuery();
            cmd2.Dispose();




            con.Close();
            con2.Close();



            
        }
    }
}