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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void BindData()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("select * from chartofaccounts", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();

            cmd.Dispose();
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Second Donnovan.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            /*MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con.Open();



            String insertS = "INSERT INTO chartofaccounts.chartofaccounts VALUES('" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "','" + TextBox10.Text + "','" + TextBox11.Text + "','" + TextBox12.Text + "')";

            MySqlCommand cmd = new MySqlCommand(insertS, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            //INSERT INTO chartofaccounts.chartofaccounts VALUES('Supplies', 'Asset', 'Left', '1000.29', '1003', '125', 'Andy', '01-03-2017', '2', 'Testing', 'Current BS');
            //" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "','" + TextBox10.Text + "','" + TextBox11.Text + "','" + TextBox12.Text +"')
            cmd.Dispose();
            con.Close();
            Response.Write("It done.");*/
        }
    }

}