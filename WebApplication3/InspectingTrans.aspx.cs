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
    public partial class InspectingTrans : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            makeDropdown("journalsub", "Title");



        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
       { 

        }

        public void makeDropdown(string tbl, string column)
        {
            DataTable things = new DataTable();

            MySqlConnection contable = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            contable.Open();

            MySqlCommand cmdtable = new MySqlCommand("select `" + column + "` from chartofaccounts." + tbl, contable);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmdtable);

            adp.Fill(things);

            DropDownList1.DataSource = things;
            DropDownList1.DataTextField = column;


            DropDownList1.DataBind();

            cmdtable.Dispose();
            contable.Close();
        }

        public void BindData(string title)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("select * from `chartofaccounts`.`journalsub` WHERE `Title` = '" + title + "'", con);
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
            string ddS = DropDownList1.SelectedValue;
            BindData(ddS);
        }
    }
}