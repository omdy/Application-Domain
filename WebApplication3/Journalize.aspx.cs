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
        String date = "02/22/2017";


        protected void Page_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con.Open();
            MySqlConnection con2 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con2.Open();
            MySqlConnection con3 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con3.Open();
            MySqlConnection con4 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con4.Open();

            String t1 = "SELECT `Account1` FROM `chartofaccounts`.`journaltran` WHERE `ID` =  '1'";
            MySqlCommand cmdt1 = new MySqlCommand(t1, con);

            String t2 = "SELECT `Account2` FROM `chartofaccounts`.`journaltran` WHERE `ID` =  '1'";
            MySqlCommand cmdt2 = new MySqlCommand(t2, con2);

            String t3 = "SELECT `Value1` FROM `chartofaccounts`.`journaltran` WHERE `ID` =  '1'";
            MySqlCommand cmdt3 = new MySqlCommand(t3, con3);

            String t4 = "SELECT `Value2` FROM `chartofaccounts`.`journaltran` WHERE `ID` =  '1'";
            MySqlCommand cmdt4 = new MySqlCommand(t4, con4);

            MySqlDataReader reader = cmdt1.ExecuteReader();
            if (reader.Read())
            {
                String s = reader.GetValue(0).ToString();
                Label3.Text = s;

            }
            
            MySqlDataReader reader2 = cmdt2.ExecuteReader();
            if (reader2.Read())
            {
                String s = reader2.GetValue(0).ToString();
                Label4.Text = s;

            }

            MySqlDataReader reader3 = cmdt3.ExecuteReader();
            if (reader3.Read())
            {
                String s = reader3.GetValue(0).ToString();
                Label5.Text = s;

            }

            MySqlDataReader reader4 = cmdt4.ExecuteReader();
            if (reader4.Read())
            {
                String s = reader4.GetValue(0).ToString();
                Label6.Text = s;

            }

            cmdt1.Dispose();
            cmdt2.Dispose();
            cmdt3.Dispose();
            cmdt4.Dispose();

            con.Close();
            con2.Close();
            con3.Close();
            con4.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con.Open();
            MySqlConnection con2 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con2.Open();
            MySqlConnection con3 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con3.Open();
            MySqlConnection con4 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con4.Open();
            MySqlConnection con5 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con5.Open();
            MySqlConnection con6 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con6.Open();



            double amount = Double.Parse(Label5.Text);
            double amount2 = Double.Parse(Label6.Text);

            if (amount == 0 && amount2 == 0)
            {
                Response.Write("You cannot enter a 0 amount. Go to Add/Edit");
            }
            if(amount != amount2)
            {
                Response.Write("You cannot make an entry that doesn't balance. Go to Add/Edit");
            }
            else
            {
                String toEL = "" + amount;
                double dbAdd = 0;
                String ab = "SELECT `Actual Balance` FROM `chartofaccounts`.`accountbalances` WHERE `Account` =  '" + Label3.Text + "'";
                MySqlCommand cmdb = new MySqlCommand(ab, con);



                MySqlDataReader reader = cmdb.ExecuteReader();
                if (reader.Read())
                {
                    String s = reader.GetValue(0).ToString();
                    dbAdd = Double.Parse(s);

                }
                cmdb.Dispose();
                amount = dbAdd + amount;
                String abDB = "UPDATE `chartofaccounts`.`accountbalances` SET `Actual Balance` = '" + amount + "' WHERE `Account` = '" + Label3.Text + "'";
                MySqlCommand cmd = new MySqlCommand(abDB, con2);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    Response.Write("You entered the credit field wrong.");
                }
                cmd.Dispose();



                String toEL2 = "" + amount2;
                double dbAdd2 = 0;
                String ab2 = "SELECT `Actual Balance` FROM `chartofaccounts`.`accountbalances` WHERE `Account` =  '" + Label4.Text + "'";
                MySqlCommand cmdb2 = new MySqlCommand(ab2, con3);



                MySqlDataReader reader2 = cmdb2.ExecuteReader();
                if (reader2.Read())
                {
                    String s = reader2.GetValue(0).ToString();
                    dbAdd = Double.Parse(s);

                }
                cmdb2.Dispose();
                amount2 = dbAdd2 + amount2;
                String abDB2 = "UPDATE `chartofaccounts`.`accountbalances` SET `Actual Balance` = '" + amount2 + "' WHERE `Account` = '" + Label4.Text + "'";
                MySqlCommand cmd2 = new MySqlCommand(abDB2, con4);

                try
                {
                    cmd2.ExecuteNonQuery();
                }
                catch
                {
                    Response.Write("You entered in The Debit field wrong.");
                }
                cmd2.Dispose();

                //DELETE FROM `chartofaccounts`.`journaltran` WHERE `ID`= '1';
                //UPDATE `chartofaccounts`.`journaltran` SET `Account1`= 'Not Entered', `Value1`= '0', `Account2`= '"Not Entered"', `Value2`= '0' WHERE `ID`= '1'
                MySqlCommand cmd3 = new MySqlCommand("UPDATE `chartofaccounts`.`journaltran` SET `Account1`= 'Not Entered', `Value1`= '0', `Account2`= 'Not Entered', `Value2`= '0' WHERE `ID`= '1'", con5);

                try
                {
                    cmd3.ExecuteNonQuery();
                }
                catch
                {
                    Response.Write("Deleting the old entry went wrong, call for help.");

                }
                cmd3.Dispose();


                //UPDATE `chartofaccounts`.`accountbalances` SET `Pending+Value`='100', `Pending-Value`='100' WHERE `Account`='Law Library';


                String dbType = "Journal Entry";
                String dbEvent = "Credited " + Label5.Text + " to Account " + Label3.Text + " and Debited " + Label6.Text + " to Account " + Label4.Text;





                String evDB = "INSERT INTO chartofaccounts.eventlog (Name, Date, Type, Event)VALUES('" + user + "','" + date + "','" + dbType + "','" + dbEvent + "')";
                MySqlCommand cmd4 = new MySqlCommand(evDB, con6);

                try
                {
                    cmd4.ExecuteNonQuery();
                }
                catch
                {
                    Response.Write("You entered in one of the fields wrong for the event log.");
                }


                cmd4.Dispose();
                con.Close();
                con2.Close();
                con3.Close();
                con4.Close();
                con5.Close();
                con6.Close();
                Response.Write("Your submission has been posted to the event log.");
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddingTransaction.aspx");
        }
    }
}