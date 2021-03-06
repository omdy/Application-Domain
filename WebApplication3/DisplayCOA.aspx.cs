﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
namespace WebApplication3
{
    public partial class DisplayCOA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button20_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Journalize.aspx");
        }

        protected void Button21_Click(object sender, EventArgs e)
        {
            Response.Redirect("InspectingTrans.aspx");
        }

        protected void Button22_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrialB.aspx");
        }

        protected void Button23_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ledger.aspx");
        }

        protected void Button24_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Second Donnovan.aspx");
        }

        protected void Button25_Click(object sender, EventArgs e)
        {
            Response.Redirect("DisplayCOA.aspx");
        }

        protected void Button26_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Event Log.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con.Open();
            //SELECT `Actual Balance` FROM `chartofaccounts`.`accountbalances` WHERE `Account` = '" + Label4.Text + "'"
            MySqlCommand cmd = new MySqlCommand("select * from chartofaccounts.chartofaccounts", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();

            cmd.Dispose();
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con.Open();
            //SELECT `Actual Balance` FROM `chartofaccounts`.`accountbalances` WHERE `Account` = '" + Label4.Text + "'"
            MySqlCommand cmd = new MySqlCommand("select `Account`,`Actual Balance` from chartofaccounts.accountbalances", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();

            cmd.Dispose();
            con.Close();

        }
    }
}