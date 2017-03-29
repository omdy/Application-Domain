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
        String date = "03/29/2017";

        protected void Page_Load(object sender, EventArgs e)
        {
            Label12.Text = user;
            Label13.Text = date;

        }
        

        protected void Button2_Click(object sender, EventArgs e)
        {

           

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con.Open();

            string accName = TextBox2.Text;
            string accType = DropDownList1.Text;
            string accSide = DropDownList2.Text;
            string accSub = TextBox6.Text;
            string accOrder = TextBox7.Text;
            string accUser = user;
            string accDate = date;
            string accActive = DropDownList3.Text;
            string accComment = TextBox11.Text;
            string ib = TextBox12.Text;

            
            insertAcc(user, date, accName, accOrder, accSub, accType, accSide, accActive, accComment);



            String dbType = "Account";
            String dbEvent = "Added " + TextBox2.Text;
            String evDB = "INSERT INTO chartofaccounts.eventlog (Name, Date, Type, Event)VALUES('" + user + "','" + date + "','" + dbType + "','" + dbEvent + "')";
            MySqlCommand cmd2 = new MySqlCommand(evDB, con);

            String abDB = "INSERT INTO `chartofaccounts`.`accountbalances` (`Account`, `Actual Balance`, `Pending+Value`, `Pending-Value`, `PendingCombined`, `Liquidity Order`) VALUES('" + TextBox2.Text + "','" + Double.Parse(ib) + "','0','0', '0', '" + TextBox7.Text + "')";
            MySqlCommand cmd3 = new MySqlCommand(abDB, con);

            try
            {
                
                
                cmd2.ExecuteNonQuery();

                cmd3.ExecuteNonQuery();

                
            }
            catch
            {
                Response.Write("You entered in one of the fields wrong.");
                
            }

            


            cmd2.Dispose();
            
            con.Close();
            Response.Write("Submitted to database. Good job!");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        public Boolean insertAcc(string user, string date, string accName, string order, string sub, string type, string side, string active, string comment)
        {
            MySqlConnection conIA = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conIA.Open();

            String coaDB = "INSERT INTO chartofaccounts.chartofaccounts VALUES('" + accName + "','" + type + "','" + side + "','" + sub + "','" + order + "','" + user + "','" + date + "','" + active + "','" + comment + "')";
            MySqlCommand cmdIA = new MySqlCommand(coaDB, conIA);

            try
            {
                cmdIA.ExecuteNonQuery();                
            }
            catch
            {
                Response.Write("Your account was not submitted. Please review the information submitted.");
                return false;
            }
            
            cmdIA.Dispose();
            conIA.Close();
            return true;
        }
    }
}