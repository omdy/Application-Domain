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
            /*
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("select * from chartofaccounts.accountbalances ORDER BY `Liquidity Order`", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            GridView2.DataSource = ds;
            GridView2.DataBind();

            cmd.Dispose();
            con.Close();*/
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

        public void insertAcc(string user, string date, string accName, string order, string code, string type, string side, string active, string comment)
        {
            MySqlConnection conIA = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conIA.Open();
            


            String coaDB = "INSERT INTO chartofaccounts.chartofaccounts VALUES('" + accName + "','" + type + "','" + side + "','" + code + "','" + order + "','" + user + "','" + date + "','" + active + "','" + comment + "')";
            MySqlCommand cmdIA = new MySqlCommand(coaDB, conIA);

            try
            {
                cmdIA.ExecuteNonQuery();
                
            }
            catch
            {
                Response.Write("Your account was not submitted. Please review the information submitted.");
            }
            cmdIA.Dispose();
            conIA.Close();
        }
        

        //UPDATE `chartofaccounts`.`journaltran` SET `Account1`= '" + TextBox7.Text + "', `Value1`= '" + TextBox5.Text + "', `Account2`= '" + TextBox8.Text + "', `Value2`= '" + TextBox6.Text + "' WHERE `ID`= '1';











    }
}