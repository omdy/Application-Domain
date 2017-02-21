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
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(checker == 1)
            {
                checker = 0;
                Response.Redirect("~/Journalize.aspx");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            /*
            
            String dbEvent = "Added " + toEL + " to Account " + TextBox1.Text;




            String evDB = "INSERT INTO chartofaccounts.journaltran VALUES('" + user + "','" + date + "','" + dbType + "','" + dbEvent + "')";
            MySqlCommand cmd2 = new MySqlCommand(evDB, con2);

            try
            {
                cmd2.ExecuteNonQuery();
            }
            catch
            {
                Response.Write("You entered in one of the fields wrong for the event log.");
            }


            cmd2.Dispose();
            con.Close();
            con2.Close();
            Response.Write("Your submission has been posted");
            */
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}