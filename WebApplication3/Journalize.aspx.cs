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
        String date = "03/01/2017";


        protected void Page_Load(object sender, EventArgs e)
        {
            
            

            

            Label3.Text = getStringDB("journaltran", "1", "Account1", "ID");

        

            Label4.Text = getStringDB("journaltran", "1", "Account2", "ID");

       

            Label6.Text = getStringDB("journaltran", "1", "Value1", "ID");

            
            Label5.Text = getStringDB("journaltran", "1", "Value2", "ID");
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            



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
            else call1(amount, amount2);
                
            
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddingTransaction.aspx");
        }
        void call1(double amount,double amount2)
        {
            
            
            MySqlConnection con3 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con3.Open();
            MySqlConnection con4 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con4.Open();
            MySqlConnection con5 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con5.Open();
            MySqlConnection con6 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con6.Open();

            String toEL = "" + amount;
            double dbAdd = 0;
            

            dbAdd = getDoubleDB("accountbalances", Label3.Text, "Actual Balance");
            
            amount = dbAdd + amount;

            updateDoubleDB("accountbalances", "Actual Balance", amount, Label3.Text);

            



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
            
            con3.Close();
            con4.Close();
            con5.Close();
            con6.Close();
            Response.Write("Your submission has been posted to the event log.");
        }

        public double getDoubleDB(string tbl, string acc, string place)
        {
            double dbVal = 0;
            MySqlConnection conVal = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conVal.Open();
            String sVal = "SELECT `" + place + "` FROM `chartofaccounts`.`" + tbl + "` WHERE `Account` =  '" + acc + "'";
            MySqlCommand cmdVal = new MySqlCommand(sVal, conVal);
            try
            {
                MySqlDataReader reader2 = cmdVal.ExecuteReader();
                if (reader2.Read())
                {
                    String s = reader2.GetValue(0).ToString();
                    dbVal = Double.Parse(s);

                }
            }
            catch
            {
                Response.Write(sVal);
            }


            cmdVal.Dispose();
            conVal.Close();
            return dbVal;
        }

        public string getStringDB(string tbl, string condition, string column, string column2)
        {
            
            MySqlConnection conVal = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conVal.Open();
            String sVal = "SELECT `" + column + "` FROM `chartofaccounts`.`" + tbl + "` WHERE `" + column2 + "` =  '" + condition + "'";
            String rString = "";
            MySqlCommand cmdVal = new MySqlCommand(sVal, conVal);
            try
            {
                MySqlDataReader reader2 = cmdVal.ExecuteReader();
                if (reader2.Read())
                {
                    rString = reader2.GetValue(0).ToString();
                    

                }
            }
            catch
            {
                Response.Write(sVal);
            }


            cmdVal.Dispose();
            conVal.Close();
            return rString;
        }

        public void updateDoubleDB(string tbl, string column, double amount, string account)
        {
            MySqlConnection conUp = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conUp.Open();

            String coaDB = "UPDATE `chartofaccounts`.`" + tbl + "` SET `" + column + "` = '" + amount + "' WHERE `Account` = '" + account + "'";
            MySqlCommand cmdUp = new MySqlCommand(coaDB, conUp);

            try
            {
                cmdUp.ExecuteNonQuery();

            }
            catch
            {
                Response.Write("Your account was not submitted. Please review the information submitted.");
            }
            cmdUp.Dispose();
            conUp.Close();
        }


    }
}