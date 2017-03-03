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
            //test
            makeDropdown("accountbalances", "Account");

            makeListThing("accountbalances", "Account");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string tbl = "accountbalances";
            string acc = "Cash";
            string place = "Actual Balance";
            string s = "";

            double addThem = getValueDB(tbl, acc, place) + getValueDB(tbl, acc, place);
            s = "" + addThem;
            TextBox1.Text = s;
                
        }

        public double getValueDB(string tbl, string acc, string place)
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

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        public void makeDropdown(string tbl, string column)
        {
            DataTable things = new DataTable();

            MySqlConnection contable = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            contable.Open();

            MySqlCommand cmdtable = new MySqlCommand("select `" + column + "` from chartofaccounts."+ tbl, contable);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmdtable);

            adp.Fill(things);

            DropDownList1.DataSource = things;
            DropDownList1.DataTextField = column;

            DropDownList1.DataBind();
            
            cmdtable.Dispose();
            contable.Close();
        }

        public void makeListThing(string tbl, string column)
        {
            DataTable things = new DataTable();

            MySqlConnection contable = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            contable.Open();

            MySqlCommand cmdtable = new MySqlCommand("select `" + column + "` from chartofaccounts." + tbl, contable);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmdtable);

            adp.Fill(things);

            ListBox1.DataSource = things;
            ListBox1.DataTextField = column;

            ListBox1.DataBind();

            cmdtable.Dispose();
            contable.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            listboxLoad(TextBox2.Text);


        }

        public void listboxLoad(string str)
        {
            ListBox1.Items.Add(str);

            
        }



        //UPDATE `chartofaccounts`.`journaltran` SET `Account1`= '" + TextBox7.Text + "', `Value1`= '" + TextBox5.Text + "', `Account2`= '" + TextBox8.Text + "', `Value2`= '" + TextBox6.Text + "' WHERE `ID`= '1';











    }
}