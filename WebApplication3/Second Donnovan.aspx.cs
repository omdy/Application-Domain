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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con.Open();
            String insertS = "INSERT INTO chartofaccounts.chartofaccounts VALUES('" + TextBox2.Text + "','" + DropDownList1.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "','" + TextBox10.Text + "','" + TextBox11.Text + "','" + TextBox12.Text + "')";
            MySqlCommand cmd = new MySqlCommand(insertS, con);


            /* MySqlCommand cmd = new MySqlCommand("Insert into chartofaccounts (Account Name, Type, Side, Initial Balance, Account Code, Liquidity Order, Added By, Added On, Active, Comment, Subgroup) values(@Account Name, @Type, @Side, @Initial Balance, @Account Code, @Liquidity Order, @Added By, @Added On, @Active, @Comment, @Subgroup)", con);
             //@Account Name, @Type, @Side, @Initial Balance, @Account Code, @Liquidity Order, @Added By, @Added On, @Active, @Comment
             cmd.Parameters.AddWithValue("@Account Name", TextBox2.Text);
             cmd.Parameters.AddWithValue("@Type", TextBox3.Text);
             cmd.Parameters.AddWithValue("@Side", TextBox4.Text);
             cmd.Parameters.AddWithValue("@Initial Balance", TextBox5.Text);
             cmd.Parameters.AddWithValue("@Account Code", TextBox6.Text);
             cmd.Parameters.AddWithValue("@Liquidity Order", TextBox7.Text);
             cmd.Parameters.AddWithValue("@Added By", TextBox8.Text);
             cmd.Parameters.AddWithValue("@Added On", TextBox9.Text);
             cmd.Parameters.AddWithValue("@Active", TextBox10.Text);
             cmd.Parameters.AddWithValue("@Commment", TextBox11.Text);
             cmd.Parameters.AddWithValue("@Subgroup", TextBox12.Text);*/
            cmd.ExecuteNonQuery();
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