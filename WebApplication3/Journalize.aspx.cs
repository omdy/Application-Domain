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
    public partial class Journalize : System.Web.UI.Page
    {

        String user = "Andy Mecke";
        String date = "02/16/2017";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con.Open();
            MySqlConnection con2 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con2.Open();

            double amount0 = Double.Parse(TextBox2.Text);

            double amountPos = 0;
            double amountNeg = 0;

            String toEL;

            if (amount0 >= 0)
            {
                amountPos = amount0;
                toEL = "" + amountPos;
                double dbAdd = 0;
                String coaDB = "SELECT `Pending+Value` FROM `chartofaccounts`.`accountbalances` WHERE `Account` =  '" + TextBox1.Text + "'";
                MySqlCommand cmdP = new MySqlCommand(coaDB, con);

                MySqlDataReader reader = cmdP.ExecuteReader();
                if (reader.Read())
                {
                    String s = reader.GetValue(0).ToString();
                    dbAdd = Double.Parse(s);
                    
                }
                cmdP.Dispose();
                amountPos = dbAdd + amountPos;
                String abDB = "UPDATE `chartofaccounts`.`accountbalances` SET `Pending+Value` = '" + amountPos + "' WHERE `Account` = '" + TextBox1.Text + "'";
                MySqlCommand cmd = new MySqlCommand(abDB, con2);
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            else
            {
                amountNeg = amount0;
                toEL = "" + amountNeg;
                double dbSub = 0;
                String coaDB = "SELECT `Pending-Value` FROM `chartofaccounts`.`accountbalances` WHERE `Account` =  '" + TextBox1.Text + "'";
                MySqlCommand cmdD = new MySqlCommand(coaDB, con);

                MySqlDataReader reader = cmdD.ExecuteReader();
                if (reader.Read())
                {
                    String s = reader.GetValue(0).ToString();
                    dbSub = Double.Parse(s);
                }
                amountNeg = dbSub + amountNeg;
                Response.Write(amountNeg);

                String abDB = "UPDATE `chartofaccounts`.`accountbalances` SET `Pending-Value` = '" + amountNeg + "' WHERE `Account` = '" + TextBox1.Text + "'";
                MySqlCommand cmd = new MySqlCommand(abDB, con2);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }


            



            //UPDATE `chartofaccounts`.`accountbalances` SET `Pending+Value`='100', `Pending-Value`='100' WHERE `Account`='Law Library';


            
            
            
            String dbType = "Journal Entry";
            String dbEvent = "Added " + toEL + " to Account " + TextBox1.Text;


            
            
            String evDB = "INSERT INTO chartofaccounts.eventlog (Name, Date, Type, Event)VALUES('" + user + "','" + date + "','" + dbType + "','" + dbEvent + "')";
            MySqlCommand cmd2 = new MySqlCommand(evDB, con2);
            cmd2.ExecuteNonQuery();


            cmd2.Dispose();
            con.Close();
            con2.Close();
            Response.Write("Your submission has been posted");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}