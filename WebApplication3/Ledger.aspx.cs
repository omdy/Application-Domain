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
            if(!IsPostBack)
            {
                BindData();
            }
                

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
            Response.Write("It got here top.");
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
                    }
                    DataRow row3 = dt.NewRow();
                    dt.Rows.Add(row3);
                    DataRow row4 = dt.NewRow();
                    dt.Rows.Add(row4);
                    accCount++; 
                }//if


            }//for loop
    

            

            



            ViewState["CurrentTable"] = dt;

            GridView2.DataSource = dt;
            GridView2.DataBind();

            Response.Write("It got here bottom.");



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
            DataBind();
        }
    }
}