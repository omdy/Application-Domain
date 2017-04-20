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
    public partial class Ledger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            form1.Style["color"] = "blue";

            if (!IsPostBack)
            {
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void BindData()
        {
            List<string> titleL = new List<string>();
            List<string> statusL = new List<string>();
            List<int> idL = new List<int>();
            List<string> accountL = new List<string>();
            List<double> debitL = new List<double>();
            List<double> creditL = new List<double>();
            List<string> typeL = new List<string>();
            List<double> balanceL = new List<double>();
            List<string> accountL2 = new List<string>();


            MySqlConnection conRead = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conRead.Open();
            String sVal = "SELECT `Title` FROM `chartofaccounts`.`posting` WHERE `Status` = 'posted'";
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
            String sVal2 = "SELECT `Status` FROM `chartofaccounts`.`posting` WHERE `Status` = 'posted'";
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
            String sVal3 = "SELECT `ID` FROM `chartofaccounts`.`posting` WHERE `Status` = 'posted'";
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
            String sVal4 = "SELECT `Account` FROM `chartofaccounts`.`posting` WHERE `Status` = 'posted'";
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
            String sVal5 = "SELECT `Debit` FROM `chartofaccounts`.`posting` WHERE `Status` = 'posted'";
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
            String sVal6 = "SELECT `Credit` FROM `chartofaccounts`.`posting` WHERE `Status` = 'posted'";
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

            MySqlConnection conRead7 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conRead7.Open();
            string sVal7 = "SELECT `side` FROM `chartofaccounts`.`chartofaccounts` ORDER BY `Liquidity Order`";
            MySqlCommand cmdRead7 = new MySqlCommand(sVal7, conRead7);
            try
            {
                MySqlDataReader reader7 = cmdRead7.ExecuteReader();
                while (reader7.Read())
                {
                    typeL.Add(reader7.GetString(0));


                }



            }
            catch
            {
                Response.Write(sVal7);
            }

            cmdRead7.Dispose();
            conRead7.Close();

            MySqlConnection conRead8 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conRead2.Open();
            string sVal8 = "SELECT `Actual Balance` FROM `chartofaccounts`.`accountbalances` ORDER BY `Liquidity Order`";
            MySqlCommand cmdRead8 = new MySqlCommand(sVal8, conRead2);
            try
            {


                MySqlDataReader reader8 = cmdRead8.ExecuteReader();
                while (reader8.Read())
                {
                    balanceL.Add(Double.Parse(reader8.GetString(0)));


                }


            }
            catch
            {
                Response.Write(sVal8);
            }


            cmdRead8.Dispose();
            conRead8.Close();

            MySqlConnection conRead9 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conRead9.Open();
            String sVal9 = "SELECT `Account` FROM `chartofaccounts`.`accountbalances` ORDER BY `Liquidity Order`";
            MySqlCommand cmdRead9 = new MySqlCommand(sVal9, conRead9);
            try
            {
                MySqlDataReader reader9 = cmdRead9.ExecuteReader();
                while (reader9.Read())
                {
                    accountL2.Add(reader9.GetString(0));


                }


            }
            catch
            {
                Response.Write(sVal9);
            }


            cmdRead9.Dispose();
            conRead9.Close();

            string[] titleA = titleL.ToArray();
            string[] statusA = statusL.ToArray();
            int[] idA = idL.ToArray();
            string[] accountA = accountL.ToArray();
            double[] debitA = debitL.ToArray();
            double[] creditA = creditL.ToArray();
            string[] typeA = typeL.ToArray();
            double[] balanceA = balanceL.ToArray();
            string[] accountA2 = accountL2.ToArray();

            DataTable dt = new DataTable();
            dt.Columns.Add("Title", typeof(string));
            
            
            dt.Columns.Add("Account", typeof(string));
            dt.Columns.Add("Debit", typeof(string));
            dt.Columns.Add("Credit", typeof(string));

            


            
            string[] accountAdd = new string[accountA.Length];

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
                    DataRow row = dt.NewRow();
                    row["Account"] = accountA[i];
                    dt.Rows.Add(row);
                    
                    if (i == 0)
                    {

                        for (int j = 0; j <= accountAdd.Length - 1; j++)
                        {
                            string dS = "";
                            string cS = "";
                            if (accountA[j] == accountAdd[accCount])
                            {
                                DataRow row2 = dt.NewRow();
                                row2["Title"] = titleA[j];
                                if (debitA[j] == 0)
                                {
                                    row2["Debit"] = "";
                                }
                                else
                                {
                                    dS = "$" + String.Format("{0:n}", debitA[j]);
                                    row2["Debit"] = dS;
                                }
                                if (creditA[j] == 0)
                                {
                                    row2["Credit"] = cS;
                                }
                                else
                                {
                                    cS = String.Format("{0:n}", creditA[j]);
                                    row2["Credit"] = cS;
                                }


                                dt.Rows.Add(row2);

                             
                                    

                            }//if
                        }//for
                        //accCount++;
                        DataRow row3 = dt.NewRow();

                        dt.Rows.Add(row3);

                        DataRow rowB = dt.NewRow();
                        rowB["Title"] = "Total: ";
                        for (int q = 0; q <= accountA2.Length - 1; q++)
                        {
                            if (accountA2[q] == accountAdd[accCount])
                            {
                                
                                if (typeA[q] == "Left")
                                {
                                    
                                    rowB["Debit"] = String.Format("{0:n}", balanceA[q]);
                                }
                                else
                                {
                                    
                                    rowB["Credit"] = String.Format("{0:n}", balanceA[q]);
                                }
                            }
                        }

                        dt.Rows.Add(rowB);

                    }//if
                    else
                    {
                        for (int j = 0; j <= accountAdd.Length - 1; j++)
                        {
                            string dS = "";
                            string cS = "";
                            if (accountA[j] == accountAdd[accCount])
                            {
                                DataRow row2 = dt.NewRow();
                                row2["Title"] = titleA[j];
                                if (debitA[j] == 0)
                                {
                                    row2["Debit"] = "";
                                }
                                else
                                {
                                    dS = String.Format("{0:n}", debitA[j]);
                                    row2["Debit"] = dS;
                                }
                                if (creditA[j] == 0)
                                {
                                    row2["Credit"] = cS;
                                }
                                else
                                {
                                    cS = String.Format("{0:n}", creditA[j]);
                                    row2["Credit"] = cS;
                                }

                                dt.Rows.Add(row2);

                                

                            }
                            
                            //accCount++;

                        }

                        DataRow row3 = dt.NewRow();
                        
                        dt.Rows.Add(row3);

                        DataRow rowB = dt.NewRow();
                        rowB["Title"] = "Total: ";
                        for (int q = 0; q <= accountA2.Length - 1; q++)
                        {
                            if (accountA2[q] == accountAdd[accCount])
                            {

                                if (typeA[q] == "Left")
                                {

                                    rowB["Debit"] = String.Format("{0:n}", balanceA[q]);
                                }
                                else
                                {

                                    rowB["Credit"] = String.Format("{0:n}", balanceA[q]);
                                }
                            }
                        }

                        dt.Rows.Add(rowB);
                    }

                    
                    DataRow row4 = dt.NewRow();
                    dt.Rows.Add(row4);
                    


                    accCount++; 
                }//if


            }//for loop
    

            

            



            ViewState["CurrentTable"] = dt;

            GridView2.DataSource = dt;
            GridView2.DataBind();
            



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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}