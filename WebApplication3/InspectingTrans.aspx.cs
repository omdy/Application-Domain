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
            }
                



        }

        //Selecting Title
        protected void Button1_Click(object sender, EventArgs e)
        {
            string ddS = DropDownList1.SelectedValue;
            BindData(ddS);
            updateTableDB(ddS);

        }

        //Accepting
        protected void Button2_Click(object sender, EventArgs e)
        {
            string s;
            s = getStringDB("tableplaceholders", "current table", "Value", "Type");
            updateStatusDB("posting", "Status", true, s);
        }
        //Denial
        protected void Button3_Click(object sender, EventArgs e)
        {
            string s;
            s = getStringDB("tableplaceholders", "current table", "Value", "Type");
            updateStatusDenyDB("posting", "Status", true, s);
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

        public void BindData(string title)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("select * from `chartofaccounts`.`posting` WHERE `Title` = '" + title + "'", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();

            cmd.Dispose();
            con.Close();
        }

        public void BindData()
        {

        }

        public void updateStatusDenyDB(string tbl, string column, bool master, string title)
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

                String coaDB = "UPDATE `chartofaccounts`.`" + tbl + "` SET `" + column + "` = 'denied' WHERE `Title` = '" + title + "'";
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
                            }
                        }
                        accCount++;

                    }


                }

                for (int i = 0; i <= accountAdd.Length - 1; i++)
                {
                    Response.Write(accountAdd[i] + " is  D " + debitAdd[i] + " and C is " + creditAdd[i]);
                }




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

        
    }
}