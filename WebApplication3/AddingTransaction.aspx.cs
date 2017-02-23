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
            /*
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT `Account Name` FROM `chartofaccounts` ORDER BY `Liquidity Order`", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            
            adp.Fill();

            DropDownList1.DataSource = ds;
            DropDownList1.DataBind();

            con.Close();

            //cut here
            DataTable dt = new DataTable;

            using (MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy"))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT `Account Name` FROM `chartofaccounts` ORDER BY `Liquidity Order`", con))
                {
                    con.Open();
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for(int i = 0; i<dt.Rows.Count; i++)
                        {
                            objDept.
                        }
                    }

                }
            }*/
            

            
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

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con.Open();



            //UPDATE `chartofaccounts`.`journaltran` SET `Account1`= '" + TextBox7.Text + "', `Value1`= '" + TextBox5.Text + "', `Account2`= '" + TextBox8.Text + "', `Value2`= '" + TextBox6.Text + "' WHERE `ID`= '1';

            String evDB = "UPDATE `chartofaccounts`.`journaltran` SET `Account1`= '" + TextBox7.Text + "', `Value1`= '" + TextBox5.Text + "', `Account2`= '" + TextBox8.Text + "', `Value2`= '" + TextBox6.Text + "' WHERE `ID`= '1'";
            MySqlCommand cmd2 = new MySqlCommand(evDB, con);

            try
            {
                cmd2.ExecuteNonQuery();
                Response.Redirect("~/Journalize.aspx");
            }
            catch
            {
                Response.Write("You entered in one of the fields wrong for the event log.");
            }


            cmd2.Dispose();
            con.Close();
            
            //Response.Write("Your submission has been posted");
           
        }

        
    }
}