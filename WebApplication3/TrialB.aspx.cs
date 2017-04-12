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
    public partial class TrialB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> accountL = new List<string>();
                List<double> balanceL = new List<double>();
                List<string> typeL = new List<string>();

                MySqlConnection conRead = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
                conRead.Open();
                String sVal = "SELECT `Account` FROM `chartofaccounts`.`accountbalances` ORDER BY `Liquidity Order`";
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
                sVal = "SELECT `Actual Balance` FROM `chartofaccounts`.`accountbalances` ORDER BY `Liquidity Order`";
                MySqlCommand cmdRead2 = new MySqlCommand(sVal, conRead2);
                try
                {


                    MySqlDataReader reader2 = cmdRead2.ExecuteReader();
                    while (reader2.Read())
                    {
                        balanceL.Add(Double.Parse(reader2.GetString(0)));


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
                sVal = "SELECT `side` FROM `chartofaccounts`.`chartofaccounts` ORDER BY `Liquidity Order`";
                MySqlCommand cmdRead3 = new MySqlCommand(sVal, conRead3);
                try
                {
                    MySqlDataReader reader3 = cmdRead3.ExecuteReader();
                    while (reader3.Read())
                    {
                        typeL.Add(reader3.GetString(0));


                    }



                }
                catch
                {
                    Response.Write(sVal);
                }

                cmdRead3.Dispose();
                conRead3.Close();

                DataTable dt = new DataTable();
                dt.Columns.Add("Account", typeof(string));
                dt.Columns.Add("Debit", typeof(string));
                dt.Columns.Add("Credit", typeof(string));

                string[] accountA = accountL.ToArray();
                double[] balanceA = balanceL.ToArray();
                string[] typeA = typeL.ToArray();

                double dSum = 0;
                double cSum = 0;





                for (int i = 0; i <= accountA.Length - 1; i++)
                {
                    string dS = "";
                    string cS = "";

                    if (i == 0)
                    {
                        //This one will add the $

                        if (balanceA[i] != 0)
                        {
                            DataRow row = dt.NewRow();
                            row["Account"] = accountA[i];
                            if (typeA[i] == "Left")
                            {
                                dS = "$" + String.Format("{0:n}", balanceA[i]);
                                row["Debit"] = dS;
                                row["Credit"] = "";
                                dSum = dSum + balanceA[i];

                            }
                            else
                            {
                                if (balanceA[i] < 0)
                                {
                                    double temp = balanceA[i] * -1;
                                    row["Debit"] = "";
                                    cS = "(" + String.Format("{0:n}", temp) + ")";
                                    row["Credit"] = cS;
                                    cSum = cSum + balanceA[i];
                                }
                                else
                                {
                                    row["Debit"] = "";
                                    cS = String.Format("{0:n}", balanceA[i]);
                                    row["Credit"] = cS;
                                    cSum = cSum + balanceA[i];
                                }

                            }

                            dt.Rows.Add(row);
                        }

                    }
                    else
                    {


                        if (balanceA[i] != 0)
                        {
                            DataRow row = dt.NewRow();
                            row["Account"] = accountA[i];
                            if (typeA[i] == "Left")
                            {
                                if (balanceA[i] < 0)
                                {
                                    double temp = balanceA[i] * -1;
                                    dS = "(" + String.Format("{0:n}", temp) + ")";
                                    row["Debit"] = dS;
                                    row["Credit"] = "";
                                    dSum = dSum + balanceA[i];
                                }
                                else
                                {
                                    dS = String.Format("{0:n}", balanceA[i]);
                                    row["Debit"] = dS;
                                    row["Credit"] = "";
                                    dSum = dSum + balanceA[i];
                                }
                            }
                            else
                            {
                                if (balanceA[i] < 0)
                                {
                                    double temp = balanceA[i] * -1;
                                    row["Debit"] = "";
                                    cS = "(" + String.Format("{0:n}", temp) + ")";
                                    row["Credit"] = cS;
                                    cSum = cSum + balanceA[i];
                                }
                                else
                                {
                                    row["Debit"] = "";
                                    cS = String.Format("{0:n}", balanceA[i]);
                                    row["Credit"] = cS;
                                    cSum = cSum + balanceA[i];
                                }
                            }

                            dt.Rows.Add(row);
                        }


                    }


                }

                DataRow row2 = dt.NewRow();

                row2["Account"] = " ";
                row2["Debit"] = "______";
                row2["Credit"] = "______";
                dt.Rows.Add(row2);


                DataRow row3 = dt.NewRow();


                row3["Debit"] = "Totals: " + String.Format("{0:n}", dSum);

                dt.Rows.Add(row3);

                DataRow row4 = dt.NewRow();



                row4["Credit"] = String.Format("{0:n}", cSum);
                dt.Rows.Add(row4);

                ViewState["CurrentTable"] = dt;

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            

            Response.Redirect("~/Default.aspx");




        }//Method end

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<string> accountL = new List<string>();
            List<double> balanceL = new List<double>();
            List<string> typeL = new List<string>();

            MySqlConnection conRead = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conRead.Open();
            String sVal = "SELECT `Account` FROM `chartofaccounts`.`accountbalances` ORDER BY `Liquidity Order`";
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
            sVal = "SELECT `Actual Balance` FROM `chartofaccounts`.`accountbalances` ORDER BY `Liquidity Order`";
            MySqlCommand cmdRead2 = new MySqlCommand(sVal, conRead2);
            try
            {


                MySqlDataReader reader2 = cmdRead2.ExecuteReader();
                while (reader2.Read())
                {
                    balanceL.Add(Double.Parse(reader2.GetString(0)));


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
            sVal = "SELECT `side` FROM `chartofaccounts`.`chartofaccounts` ORDER BY `Liquidity Order`";
            MySqlCommand cmdRead3 = new MySqlCommand(sVal, conRead3);
            try
            {
                MySqlDataReader reader3 = cmdRead3.ExecuteReader();
                while (reader3.Read())
                {
                    typeL.Add(reader3.GetString(0));


                }



            }
            catch
            {
                Response.Write(sVal);
            }

            cmdRead3.Dispose();
            conRead3.Close();

            DataTable dt = new DataTable();
            dt.Columns.Add("Account", typeof(string));
            dt.Columns.Add("Debit", typeof(string));
            dt.Columns.Add("Credit", typeof(string));

            string[] accountA = accountL.ToArray();
            double[] balanceA = balanceL.ToArray();
            string[] typeA = typeL.ToArray();

            double dSum = 0;
            double cSum = 0;





            for (int i = 0; i <= accountA.Length - 1; i++)
            {
                string dS = "";
                string cS = "";

                if (i == 0)
                {
                    //This one will add the $

                    if (balanceA[i] != 0)
                    {
                        DataRow row = dt.NewRow();
                        row["Account"] = accountA[i];
                        if (typeA[i] == "Left")
                        {
                            dS = "$" + String.Format("{0:n}", balanceA[i]);
                            row["Debit"] = dS;

                            row["Credit"] = "";
                            dSum = dSum + balanceA[i];

                        }
                        else
                        {
                            if (balanceA[i] < 0)
                            {
                                double temp = balanceA[i] * -1;
                                row["Debit"] = "";
                                cS = "(" + String.Format("{0:n}", temp) + ")";
                                row["Credit"] = cS;
                                cSum = cSum + balanceA[i];
                            }
                            else
                            {
                                row["Debit"] = "";
                                cS = String.Format("{0:n}", balanceA[i]);
                                row["Credit"] = cS;
                                cSum = cSum + balanceA[i];
                            }

                        }

                        dt.Rows.Add(row);
                    }

                }
                else
                {


                    if (balanceA[i] != 0)
                    {
                        DataRow row = dt.NewRow();
                        row["Account"] = accountA[i];
                        if (typeA[i] == "Left")
                        {
                            if (balanceA[i] < 0)
                            {
                                double temp = balanceA[i] * -1;
                                dS = "(" + String.Format("{0:n}", temp) + ")";
                                row["Debit"] = dS;
                                row["Credit"] = "";
                                dSum = dSum + balanceA[i];
                            }
                            else
                            {
                                dS = String.Format("{0:n}", balanceA[i]);
                                row["Debit"] = dS;
                                row["Credit"] = "";
                                dSum = dSum + balanceA[i];
                            }
                        }
                        else
                        {
                            if (balanceA[i] < 0)
                            {
                                double temp = balanceA[i] * -1;
                                row["Debit"] = "";
                                cS = "(" + String.Format("{0:n}", temp) + ")";
                                row["Credit"] = cS;
                                cSum = cSum + balanceA[i];
                            }
                            else
                            {
                                row["Debit"] = "";
                                cS = String.Format("{0:n}", balanceA[i]);
                                row["Credit"] = cS;
                                cSum = cSum + balanceA[i];
                            }
                        }

                        dt.Rows.Add(row);
                    }


                }


            }

            DataRow row2 = dt.NewRow();

            row2["Account"] = " ";
            row2["Debit"] = "______";
            row2["Credit"] = "______";
            dt.Rows.Add(row2);


            DataRow row3 = dt.NewRow();


            row3["Debit"] = "Totals: " + String.Format("{0:n}", dSum);

            dt.Rows.Add(row3);

            DataRow row4 = dt.NewRow();



            row4["Credit"] = String.Format("{0:n}", cSum);
            dt.Rows.Add(row4);

            ViewState["CurrentTable"] = dt;

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}