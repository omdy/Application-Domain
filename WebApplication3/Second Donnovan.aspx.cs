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
    public partial class Second_Donnovan : System.Web.UI.Page
    {

        String user = "Andy Mecke";
        String date = "02/16/2017";

        protected void Page_Load(object sender, EventArgs e)
        {
            Label12.Text = user;
            Label13.Text = date;

        }
        

        protected void Button2_Click(object sender, EventArgs e)
        {

           

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con.Open();
            String coaDB = "INSERT INTO chartofaccounts.chartofaccounts VALUES('" + TextBox2.Text + "','" + DropDownList1.Text + "','" + DropDownList2.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + user + "','" + date + "','" + DropDownList3.Text + "','" + TextBox11.Text + "')";
            MySqlCommand cmd = new MySqlCommand(coaDB, con);

            String dbType = "Account";
            String dbEvent = "Added " + TextBox2.Text;
            String evDB = "INSERT INTO chartofaccounts.eventlog (Name, Date, Type, Event)VALUES('" + user + "','" + date + "','" + dbType + "','" + dbEvent + "')";
            MySqlCommand cmd2 = new MySqlCommand(evDB, con);

            String abDB = "INSERT INTO `chartofaccounts`.`accountbalances` (`Account`, `Actual Balance`, `Pending+Value`, `Pending-Value`, `PendingCombined`, `Liquidity Order`) VALUES('" + TextBox2.Text + "','0','0','0', '0', '" + TextBox7.Text + "')";
            MySqlCommand cmd3 = new MySqlCommand(abDB, con);

            try
            {
                cmd.ExecuteNonQuery();
                
                cmd2.ExecuteNonQuery();

                cmd3.ExecuteNonQuery();

                
            }
            catch
            {
                //Response.Write("You entered in one of the fields wrong.");
                Response.Write(abDB);
            }

            


            cmd2.Dispose();
            cmd.Dispose();
            con.Close();
            Response.Write("Submitted to database. Good job!");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}