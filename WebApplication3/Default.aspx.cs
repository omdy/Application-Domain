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
            //testpoop sloppy dingo
            //sex knights 2 is best anime
            //dal's turn
        }
        public void BindData()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("select * from chartofaccounts.chartofaccounts ORDER BY `Liquidity Order`", con);
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

        }//poppoop

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Second Donnovan.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Journalize.aspx");
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Event Log.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Testing.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con.Open();
            //SELECT `Actual Balance` FROM `chartofaccounts`.`accountbalances` WHERE `Account` = '" + Label4.Text + "'"
            MySqlCommand cmd = new MySqlCommand("select `Account`,`Actual Balance` from chartofaccounts.accountbalances", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            GridView2.DataSource = ds;
            GridView2.DataBind();

            cmd.Dispose();
            con.Close();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        protected void Button11_Click(object sender, EventArgs e)
        {
            Response.Redirect("InspectingTrans.aspx");
        }
    }

}