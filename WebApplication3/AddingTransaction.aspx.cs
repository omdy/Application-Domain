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
    public partial class AddingTransaction : System.Web.UI.Page
    {
        int checker = 0;
        String user = "Andy Mecke";
        String date = "02/20/2017";

        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Journalize.aspx");

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            



            //UPDATE `chartofaccounts`.`journaltran` SET `Account1`= '" + TextBox7.Text + "', `Value1`= '" + TextBox5.Text + "', `Account2`= '" + TextBox8.Text + "', `Value2`= '" + TextBox6.Text + "' WHERE `ID`= '1';

            //String evDB = "UPDATE `chartofaccounts`.`journaltran` SET `Account1`= '" + TextBox7.Text + "', `Value1`= '" + TextBox5.Text + "', `Account2`= '" + TextBox8.Text + "', `Value2`= '" + TextBox6.Text + "' WHERE `ID`= '1'";
            

            updateDoubleDB("journaltran", "Account1", "ID", TextBox7.Text, "1");
            updateDoubleDB("journaltran", "Value1", "ID", TextBox5.Text, "1");
            updateDoubleDB("journaltran", "Account2", "ID", TextBox8.Text, "1");
            updateDoubleDB("journaltran", "Value2", "ID", TextBox6.Text, "1");
            //yes iehgexcceer


            Response.Redirect("~/Journalize.aspx");


            
        }

        public void updateDoubleDB(string tbl, string column, string Ccolumn,  string amount, string condition)
        {
            MySqlConnection conUp = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conUp.Open();

            String coaDB = "UPDATE `chartofaccounts`.`" + tbl + "` SET `" + column + "` = '" + amount + "' WHERE `" + Ccolumn + "` = '" + condition + "'";
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