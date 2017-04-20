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
        string currentTable { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                makeDropdown("posting", "Title");
                BindData();
            }
                



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

        //Selecting Title
        protected void Button1_Click(object sender, EventArgs e)
        {
            string ddS = DropDownList1.SelectedValue;
            BindData2(ddS);
            updateTableDB(ddS);

        }

        //Accepting
        protected void Button2_Click(object sender, EventArgs e)
        {
            string s;
            s = getStringDB("tableplaceholders", "current table", "Value", "Type");
            updateStatusDB("posting", "Status", true, s);

            string ddS = DropDownList1.SelectedValue;
            BindData2(ddS);
            updateTableDB(ddS);
        }
        //Denial
        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox1.Visible = true;
            Button5.Visible = true;
            Button3.Visible = false;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string t = TextBox1.Text;
            string s;
            s = getStringDB("tableplaceholders", "current table", "Value", "Type");
            updateStatusDenyDB("posting", "Status", true, s, t);

            TextBox1.Visible = false;
            Button5.Visible = false;
            Button3.Visible = true;

            string ddS = DropDownList1.SelectedValue;
            BindData2(ddS);
            updateTableDB(ddS);
        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            currentTable = "";
            Response.Redirect("~/Default.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
       { 

        }

        public void makeDropdown(string tbl, string column)
        {
            string temp = "";
            string temp2 = "";
            List<string> statusL = new List<string>();

            


            DataTable things = new DataTable();

            MySqlConnection contable = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            contable.Open();

            MySqlCommand cmdtable = new MySqlCommand("select `" + column + "` from `chartofaccounts`.`" + tbl + "`", contable);

            try
            {
                MySqlDataReader readerT = cmdtable.ExecuteReader();
                while (readerT.Read())
                {
                    temp2 = readerT.GetString(0);
                    if (temp2 != temp)
                    {
                        statusL.Add(temp2);
                    }

                    temp = temp2;
                    
                }


            }
            catch
            {
                Response.Write("Can't read the titles");
            }

            


            DropDownList1.DataSource = statusL;
            


            DropDownList1.DataBind();

            cmdtable.Dispose();
            contable.Close();
        }

        public void BindData()
        {
            List<string> titleL = new List<string>();
            List<string> statusL = new List<string>();
            List<int> idL = new List<int>();
            List<string> accountL = new List<string>();
            List<double> debitL = new List<double>();
            List<double> creditL = new List<double>();

            MySqlConnection conRead = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conRead.Open();
            String sVal = "SELECT `Title` FROM `chartofaccounts`.`posting`";
            MySqlCommand cmdRead = new MySqlCommand(sVal, conRead);
            try
            {
                MySqlDataReader reader1 = cmdRead.ExecuteReader();
                while (reader1.Read())
                {
                    titleL.Add(reader1.GetString(0));


                }

                reader1.Close();
            }
            catch
            {
                Response.Write(sVal);
            }

            cmdRead.Dispose();
            conRead.Close();

            MySqlConnection conRead2 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conRead2.Open();
            String sVal2 = "SELECT `Status` FROM `chartofaccounts`.`posting`";
            MySqlCommand cmdRead2 = new MySqlCommand(sVal2, conRead2);
            try
            {
                MySqlDataReader reader2 = cmdRead2.ExecuteReader();
                while (reader2.Read())
                {
                    statusL.Add(reader2.GetString(0));


                }
                reader2.Close();

            }
            catch
            {
                Response.Write(sVal2);
            }

            cmdRead2.Dispose();
            conRead2.Close();

            MySqlConnection conRead3 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conRead3.Open();
            String sVal3 = "SELECT `ID` FROM `chartofaccounts`.`posting`";
            MySqlCommand cmdRead3 = new MySqlCommand(sVal3, conRead3);
            try
            {
                MySqlDataReader reader3 = cmdRead3.ExecuteReader();
                while (reader3.Read())
                {
                    idL.Add(Int32.Parse(reader3.GetString(0)));


                }

                reader3.Close();


            }
            catch
            {
                Response.Write(sVal3);
            }

            cmdRead3.Dispose();
            conRead3.Close();

            MySqlConnection conRead4 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conRead4.Open();
            String sVal4 = "SELECT `Account` FROM `chartofaccounts`.`posting`";
            MySqlCommand cmdRead4 = new MySqlCommand(sVal4, conRead4);
            try
            {
                MySqlDataReader reader4 = cmdRead4.ExecuteReader();
                while (reader4.Read())
                {
                    accountL.Add(reader4.GetString(0));


                }

                reader4.Close();


            }
            catch
            {
                Response.Write(sVal4);
            }

            cmdRead4.Dispose();
            conRead4.Close();

            MySqlConnection conRead5 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conRead5.Open();
            String sVal5 = "SELECT `Debit` FROM `chartofaccounts`.`posting`";
            MySqlCommand cmdRead5 = new MySqlCommand(sVal5, conRead5);
            try
            {
                MySqlDataReader reader5 = cmdRead5.ExecuteReader();
                while (reader5.Read())
                {
                    debitL.Add(Double.Parse(reader5.GetString(0)));


                }

                reader5.Close();


            }
            catch
            {
                Response.Write(sVal5);
            }

            cmdRead5.Dispose();
            conRead5.Close();

            MySqlConnection conRead6 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conRead6.Open();
            String sVal6 = "SELECT `Credit` FROM `chartofaccounts`.`posting`";
            MySqlCommand cmdRead6 = new MySqlCommand(sVal6, conRead6);
            try
            {
                MySqlDataReader reader6 = cmdRead6.ExecuteReader();
                while (reader6.Read())
                {
                    creditL.Add(Double.Parse(reader6.GetString(0)));


                }

                reader6.Close();


            }
            catch
            {
                Response.Write(sVal6);
            }

            cmdRead6.Dispose();
            conRead6.Close();

            string[] titleA = titleL.ToArray();
            string[] statusA = statusL.ToArray();
            int[] idA = idL.ToArray();
            string[] accountA = accountL.ToArray();
            double[] debitA = debitL.ToArray();
            double[] creditA = creditL.ToArray();

            DataTable dt = new DataTable();
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Account", typeof(string));
            dt.Columns.Add("Debit", typeof(string));
            dt.Columns.Add("Credit", typeof(string));
            dt.Columns.Add("Comment", typeof(string));

            string s = titleA[0];
            
            for (int i = 0; i <= accountA.Length - 1; i++)
            {
                string dS = "";
                string cS = "";

                if (s != titleA[i])
                {
                    DataRow row2 = dt.NewRow();
                    dt.Rows.Add(row2);
                }

                if (i == 0)
                {
                    //This one will add the $
                    DataRow row = dt.NewRow();
                    if (s != titleA[i])
                    {
                        row["ID"] = idA[i];
                        row["Account"] = accountA[i];
                        if (debitA[i] == 0)
                        {
                            row["Debit"] = "";
                        }
                        else
                        {
                            dS = "$" + String.Format("{0:n}", debitA[i]);
                            row["Debit"] = dS;
                        }
                        if (creditA[i] == 0)
                        {
                            row["Credit"] = cS;
                        }
                        else
                        {
                            cS = String.Format("{0:n}", creditA[i]);
                            row["Credit"] = cS;
                        }

                        dt.Rows.Add(row);
                    }
                    else
                    {
                        s = titleA[i];
                        row["Title"] = titleA[i];
                        row["Status"] = statusA[i];
                        row["ID"] = idA[i];
                        row["Account"] = accountA[i];
                        if (debitA[i] == 0)
                        {
                            row["Debit"] = "";
                        }
                        else
                        {
                            dS = "$" + String.Format("{0:n}", debitA[i]);
                            row["Debit"] = dS;
                        }
                        if (creditA[i] == 0)
                        {
                            row["Credit"] = cS;
                        }
                        else
                        {
                            cS = String.Format("{0:n}", creditA[i]);
                            row["Credit"] = cS;
                        }

                        dt.Rows.Add(row);
                    }
                    
                    
                }
                else
                {
                    DataRow row = dt.NewRow();
                    if (s == titleA[i])
                    {
                        row["ID"] = idA[i];
                        row["Account"] = accountA[i];
                        if (debitA[i] == 0)
                        {
                            row["Debit"] = "";
                        }
                        else
                        {
                            dS = String.Format("{0:n}", debitA[i]);
                            row["Debit"] = dS;
                        }
                        if (creditA[i] == 0)
                        {
                            row["Credit"] = cS;
                        }
                        else
                        {
                            cS = String.Format("{0:n}", creditA[i]);
                            row["Credit"] = cS;
                        }

                        dt.Rows.Add(row);
                    }
                    else
                    {
                        s = titleA[i];
                        row["Title"] = titleA[i];
                        row["Status"] = statusA[i];
                        row["ID"] = idA[i];
                        row["Account"] = accountA[i];
                        if (debitA[i] == 0)
                        {
                            row["Debit"] = "";
                        }
                        else
                        {
                            dS = String.Format("{0:n}", debitA[i]);
                            row["Debit"] = dS;
                        }
                        if (creditA[i] == 0)
                        {
                            row["Credit"] = cS;
                        }
                        else
                        {
                            cS = String.Format("{0:n}", creditA[i]);
                            row["Credit"] = cS;
                        }

                        dt.Rows.Add(row);
                    }
                    
                    
                }
                
                
                
            }

            ViewState["CurrentTable"] = dt;

            GridView1.DataSource = dt;
            GridView1.DataBind();
            


            /*
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("select * from `chartofaccounts`.`posting` WHERE `Title` = '" + title + "'", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();

            cmd.Dispose();
            con.Close();*/
        }

        public void BindData2(string title)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("select * from `chartofaccounts`.`posting` WHERE `Title` = '" + title + "'", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            GridView2.DataSource = ds;
            GridView2.DataBind();

            cmd.Dispose();
            con.Close();
        }

        public void updateStatusDenyDB(string tbl, string column, bool master, string title, string reason)
        {
            string check = getStringDB(tbl, title, "Status", "Title");

            if (check == "posted")
            {
                Response.Write("This journal is already posted!");
            }
            if (check == "denied")
            {
                Response.Write("This journal has been denied already!");
            }
            if(check == "TBD")
            {
                MySqlConnection conUp = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
                conUp.Open();

                String coaDB = "UPDATE `chartofaccounts`.`" + tbl + "` SET `" + column + "` = 'denied',`Reason` = '" + reason +"' WHERE `Title` = '" + title + "'";
                MySqlCommand cmdUp = new MySqlCommand(coaDB, conUp);

                try
                {
                    cmdUp.ExecuteNonQuery();
                    Response.Write("This journal was denied!");
                }
                catch
                {
                    Response.Write("Your account was not submitted. Please review the information submitted.");
                }
                cmdUp.Dispose();
                conUp.Close();
            }

            BindData();




        }


        public void updateStatusDB(string tbl, string column, bool master, string title)
        {
            string check = getStringDB(tbl, title, "Status", "Title");

            if (check == "posted")
            {
                Response.Write("This journal is already posted!");
            }
            if (check == "denied")
            {
                Response.Write("This journal has been denied!");
            }
            if (check == "TBD")
            {
                MySqlConnection conUp = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
                conUp.Open();

                String coaDB = "UPDATE `chartofaccounts`.`" + tbl + "` SET `" + column + "` = 'posted' WHERE `Title` = '" + title + "'";
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


                List<string> accountL = new List<string>();
                List<double> debitL = new List<double>();
                List<double> creditL = new List<double>();

                MySqlConnection conRead = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
                conRead.Open();
                string sVal = "SELECT `Account` FROM `chartofaccounts`.`posting` WHERE `Title` = '" + title + "'";
                MySqlCommand cmdRead = new MySqlCommand(sVal, conRead);
                try
                {
                    MySqlDataReader reader = cmdRead.ExecuteReader();
                    while (reader.Read())
                    {
                        accountL.Add(reader.GetString(0));


                    }


                }
                catch
                {
                    Response.Write(sVal);
                }


                cmdRead.Dispose();
                conRead.Close();

                MySqlConnection conRead2 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
                conRead2.Open();
                sVal = "SELECT `Debit` FROM `chartofaccounts`.`posting` WHERE `Title` = '" + title + "'";
                MySqlCommand cmdRead2 = new MySqlCommand(sVal, conRead2);
                try
                {


                    MySqlDataReader reader2 = cmdRead2.ExecuteReader();
                    while (reader2.Read())
                    {
                        debitL.Add(Double.Parse(reader2.GetString(0)));


                    }


                }
                catch
                {
                    Response.Write(sVal);
                }


                cmdRead2.Dispose();
                conRead2.Close();

                MySqlConnection conRead3 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
                conRead3.Open();
                sVal = "SELECT `Credit` FROM `chartofaccounts`.`posting` WHERE `Title` = '" + title + "'";
                MySqlCommand cmdRead3 = new MySqlCommand(sVal, conRead3);
                try
                {
                    MySqlDataReader reader3 = cmdRead3.ExecuteReader();
                    while (reader3.Read())
                    {
                        creditL.Add(Double.Parse(reader3.GetString(0)));


                    }



                }
                catch
                {
                    Response.Write(sVal);
                }

                cmdRead3.Dispose();
                conRead3.Close();

                string[] accountA = accountL.ToArray();
                double[] debitA = debitL.ToArray();
                double[] creditA = creditL.ToArray();

                string[] accountAdd = new string[accountA.Length];
                /*for (int i = 0; i <= accountA.Length - 1; i++)
                {
                    accountAdd[i] = "1";
                }*/

                double[] debitAdd = new double[accountA.Length];
                double[] creditAdd = new double[accountA.Length];

                int accCount = 0;
                for (int i = 0; i <= accountA.Length - 1; i++)
                {
                    bool b = false;
                    string accS = accountA[i];
                    for (int j = 0; j <= accountAdd.Length - 1; j++)
                    {

                        if (accS == accountAdd[j])
                        {
                            b = true;
                        }
                    }

                    if (b == false)
                    {
                        accountAdd[accCount] = accountA[i];
                        debitAdd[accCount] = 0;
                        creditAdd[accCount] = 0;
                        for (int j = 0; j <= accountAdd.Length - 1; j++)
                        {
                            if (accountA[j] == accountAdd[accCount])
                            {
                                debitAdd[accCount] = debitAdd[accCount] + debitA[j];
                                creditAdd[accCount] = creditAdd[accCount] + creditA[j];
                            }//if
                        }//for
                        accCount++;

                    }//if


                }//for loop

                




                for (int i = 0; i <= accountAdd.Length - 1; i++)
                {
                    string s = getStringDB("chartofaccounts", accountAdd[i], "Side", "Account Name");

                    if (s == "Left")
                    {
                        string dbBalance = getStringDB("accountbalances", accountAdd[i], "Actual Balance", "Account");
                        double dBalance = 0;
                        double cBalance = 0;
                        dBalance = dBalance + debitAdd[i];
                        cBalance = cBalance - creditAdd[i];
                        double actualB = double.Parse(dbBalance);
                        actualB = actualB + dBalance + cBalance;
                        updateBalanceDB(accountAdd[i], actualB);


                    }
                    if (s == "Right")
                    {
                        string dbBalance = getStringDB("accountbalances", accountAdd[i], "Actual Balance", "Account");
                        double dBalance = 0;
                        double cBalance = 0;
                        dBalance = dBalance - debitAdd[i];
                        cBalance = cBalance + creditAdd[i];

                        double actualB = double.Parse(dbBalance);
                        actualB = actualB + dBalance + cBalance;
                        updateBalanceDB(accountAdd[i], actualB);
                    }


                }


            }

            BindData();


        }

        //seting the current table
        public void updateTableDB( string current)
        {
            MySqlConnection conUp = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conUp.Open();

            String coaDB = "UPDATE `chartofaccounts`.`tableplaceholders` SET `Value` = '" + current + "' WHERE `Type` = 'current table'";
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

        public void updateBalanceDB(string account, double balance)
        {
            MySqlConnection conUp = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conUp.Open();

            String coaDB = "UPDATE `chartofaccounts`.`accountbalances` SET `Actual Balance` = '" + balance + "' WHERE `Account` = '" + account + "'";
            MySqlCommand cmdUp = new MySqlCommand(coaDB, conUp);

            try
            {
                cmdUp.ExecuteNonQuery();
            }
            catch
            {
                Response.Write("Your balance post was not submitted. Please review the information submitted.");
            }
            cmdUp.Dispose();
            conUp.Close();
        }



        public string getStringDB(string tbl, string condition, string column, string column2)
        {

            MySqlConnection conVal = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conVal.Open();
            String sVal = "SELECT `" + column + "` FROM `chartofaccounts`.`" + tbl + "` WHERE `" + column2 + "` =  '" + condition + "'";
            String rString = "";
            MySqlCommand cmdVal = new MySqlCommand(sVal, conVal);
            try
            {
                MySqlDataReader reader2 = cmdVal.ExecuteReader();
                if (reader2.Read())
                {
                    rString = reader2.GetValue(0).ToString();


                }
            }
            catch
            {
                Response.Write(sVal);
            }


            cmdVal.Dispose();
            conVal.Close();
            return rString;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}