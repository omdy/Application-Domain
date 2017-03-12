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
    public partial class Journalize : System.Web.UI.Page
    {


        String user = "Andy Mecke";
        String date = "03/08/2017";

        int idI = 0;

        

        DataTable dt = new DataTable();
        DataRow rw;

        int pos = 0;

        
        

        protected void Page_Load(object sender, EventArgs e)
        {

            

            makeDropdown("accountbalances", "Account");

            


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string dLB = Label2.Text;
            string cLB = Label3.Text;

            bool master = false;
            bool check = false;
            bool check2 = false;
            if (dLB == "0.00") { check = true; }
            if (cLB == "0.00") { check2 = true; }
            if ((check ? 1 : 0) + (check2 ? 1 : 0) < 1) { master = true; }
            if (master == true)
            {
                double temp = Double.Parse(dLB);
                double temp2 = Double.Parse(cLB);

                if (temp == temp2)
                {

                    List<int> idL = new List<int>();
                    List<string> accountL = new List<string>();
                    List<double> debitL = new List<double>();
                    List<double> creditL = new List<double>();







                    MySqlConnection conRead = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
                    conRead.Open();
                    String sVal = "SELECT `account` FROM `chartofaccounts`.`journaltran`";
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
                    sVal = "SELECT `debit` FROM `chartofaccounts`.`journaltran`";
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
                    sVal = "SELECT `credit` FROM `chartofaccounts`.`journaltran`";
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
                    MySqlConnection conRead4 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
                    conRead4.Open();
                    sVal = "SELECT `ID` FROM `chartofaccounts`.`journaltran`";
                    MySqlCommand cmdRead4 = new MySqlCommand(sVal, conRead4);
                    try
                    {
                        MySqlDataReader reader4 = cmdRead4.ExecuteReader();
                        while (reader4.Read())
                        {
                            idL.Add(Int32.Parse(reader4.GetString(0)));


                        }



                    }
                    catch
                    {
                        Response.Write(sVal);
                    }


                    cmdRead4.Dispose();
                    conRead4.Close();

                    



                    

                    int[] idA = idL.ToArray();
                    string[] accountA = accountL.ToArray();
                    double[] debitA = debitL.ToArray();
                    double[] creditA = creditL.ToArray();

                    

                   

                    for (int i = 0; i <= accountA.Length - 1; i++)
                    {
                        string tbS = TextBox5.Text;


                        insertStringDB2("journalsub", tbS, idA[i], accountA[i], String.Format("{0:0.00}", debitA[i]), String.Format("{0:0.00}", creditA[i]));




                    }

                    MySqlConnection conDel = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
                    conDel.Open();
                    String sDel = "TRUNCATE TABLE `chartofaccounts`.`journaltran`";
                    MySqlCommand cmdDel = new MySqlCommand(sDel, conDel);
                    try
                    {
                        cmdDel.ExecuteNonQuery();
                    }
                    catch
                    {
                        Response.Write("Yo it no remove stuff.");
                    }


                    Response.Redirect("~/Default.aspx");

                    
                }
                else
                {
                    Label4.Visible = true;
                    Label4.ForeColor = System.Drawing.Color.Red;
                    Label4.Text = "The entries made do not balance.";
                }
            }
            else
            {
                Label4.Visible = true;
                Label4.ForeColor = System.Drawing.Color.Red;
                Label4.Text = "The entries are only 0.00, please submit entries or return to home.";
            }

            





        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            double dbt = Double.Parse(TextBox1.Text);
            double ct = Double.Parse(TextBox2.Text);
            if (Double.Parse(TextBox1.Text) != Double.Parse(TextBox2.Text))
            {
                bool master = false;
                bool check = false;
                bool check2 = false;
                if (dbt == 0) { check = true; }
                if (ct == 0) { check2 = true; }
                if ((check ? 1:0) + (check2 ? 1 : 0) < 1) { master = true; }
                
                if (master == false)
                {
                    master = false;
                    check = false;
                    check2 = false;
                    if (dbt >= 0) { check = true; }
                    if (ct >= 0) { check2 = true; }
                    if ((check ? 1 : 0) + (check2 ? 1 : 0) <= 1) { master = true; }


                    if (master == false)
                    {
                        string tbl = "journaltran";

                        string ddS = DropDownList1.SelectedValue;
                        string tb1S = TextBox1.Text;
                        string tb2S = TextBox2.Text;
                        string tbComment = TextBox3.Text;

                        List<int> idL = new List<int>();
                        List<string> accountL = new List<string>();
                        List<double> debitL = new List<double>();
                        List<double> creditL = new List<double>();

                        insertStringDB(tbl, DropDownList1.SelectedValue, TextBox1.Text, TextBox2.Text);

                        



                        MySqlConnection conRead = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
                        conRead.Open();
                        String sVal = "SELECT `account` FROM `chartofaccounts`.`journaltran`";
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
                        sVal = "SELECT `debit` FROM `chartofaccounts`.`journaltran`";
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
                        sVal = "SELECT `credit` FROM `chartofaccounts`.`journaltran`";
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
                        MySqlConnection conRead4 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
                        conRead4.Open();
                        sVal = "SELECT `ID` FROM `chartofaccounts`.`journaltran`";
                        MySqlCommand cmdRead4 = new MySqlCommand(sVal, conRead4);
                        try
                        {
                            MySqlDataReader reader4 = cmdRead4.ExecuteReader();
                            while (reader4.Read())
                            {
                                idL.Add(Int32.Parse(reader4.GetString(0)));


                            }



                        }
                        catch
                        {
                            Response.Write(sVal);
                        }


                        cmdRead4.Dispose();
                        conRead4.Close();

                        /*idL.Add((idL.Count) + 1);
                        accountL.Add(DropDownList1.SelectedValue);
                        debitL.Add(Double.Parse(TextBox1.Text));
                        creditL.Add(Double.Parse(TextBox2.Text));*/



                        DataTable dt = new DataTable();
                        dt.Columns.Add("ID", typeof(int));
                        dt.Columns.Add("Account", typeof(string));
                        dt.Columns.Add("Debit", typeof(string));
                        dt.Columns.Add("Credit", typeof(string));

                        int[] idA = idL.ToArray();
                        string[] accountA = accountL.ToArray();
                        double[] debitA = debitL.ToArray();
                        double[] creditA = creditL.ToArray();

                        double dSum = 0;
                        double cSum = 0;

                        for (int i = 0; i <= accountA.Length - 1; i++)
                        {
                            dSum = dSum + debitA[i];

                        }

                        Label2.Text = ""  + dSum;


                        for (int i = 0; i <= accountA.Length - 1; i++)
                        {
                            cSum = cSum + creditA[i];

                        }

                        Label3.Text = "" + cSum;

                        for (int i = 0; i <= accountA.Length - 1; i++)
                        {
                            string dS = "";
                            string cS = "";

                            if (i == 0)
                            {
                                //This one will add the $
                                DataRow row = dt.NewRow();
                                row["ID"] = idA[i];
                                row["Account"] = accountA[i];
                                if (debitA[i] == 0)
                                {
                                    row["Debit"] = "";
                                }
                                else
                                {
                                    dS = "$" + String.Format("{0:0.00}", debitA[i]);
                                    row["Debit"] = dS;
                                }
                                if (creditA[i] == 0)
                                {
                                    row["Credit"] = cS;
                                }
                                else
                                {
                                    cS = String.Format("{0:0.00}", creditA[i]);
                                    row["Credit"] = cS;
                                }
                                
                                dt.Rows.Add(row);
                            }
                            else
                            {
                                DataRow row = dt.NewRow();
                                row["ID"] = idA[i];
                                row["Account"] = accountA[i];
                                if (debitA[i] == 0)
                                {
                                    row["Debit"] = "";
                                }
                                else
                                {
                                    dS = String.Format("{0:0.00}", debitA[i]);
                                    row["Debit"] = dS;
                                }
                                if (creditA[i] == 0)
                                {
                                    row["Credit"] = cS;
                                }
                                else
                                {
                                    cS = String.Format("{0:0.00}", creditA[i]);
                                    row["Credit"] = cS;
                                }
                                dt.Rows.Add(row);
                            }

                            


                        }



                        GridView1.DataSource = dt;
                        GridView1.DataBind();

                        DropDownList2.DataSource = dt;
                        DropDownList2.DataTextField = "ID";


                        DropDownList2.DataBind();


                        TextBox1.Text = "0";
                        TextBox2.Text = "0";

                        Label1.Visible = true;
                        Label1.ForeColor = System.Drawing.Color.Blue;
                        Label1.Text = "Added";

                    }
                    else
                    {
                        Label1.Visible = true;
                        Label1.ForeColor = System.Drawing.Color.Red;
                        Label1.Text = "You can't add a negative value.";

                    }
                }
                else
                {
                    Label1.Visible = true;
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "Either debit or credit needs to be 0";

                }

            }
            else
            {
                Label1.Visible = true;
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "You can't add both debit and credit";

            }
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string ddS = DropDownList2.SelectedValue;

            MySqlConnection conDel = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conDel.Open();
            String sDel = "DELETE FROM FROM `chartofaccounts`.`journaltran` WHERE `ID` =  '" + ddS + "'";
            MySqlCommand cmdDel = new MySqlCommand(sDel, conDel);

            try
            {
                cmdDel.ExecuteNonQuery();
            }
            catch
            {
                Response.Write("Something went wrong with deleting." + sDel);
            }
            cmdDel.Dispose();
            conDel.Close();

            string tbl = "journaltran";

           

            List<int> idL = new List<int>();
            List<string> accountL = new List<string>();
            List<double> debitL = new List<double>();
            List<double> creditL = new List<double>();

            





            MySqlConnection conRead = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conRead.Open();
            String sVal = "SELECT `account` FROM `chartofaccounts`.`journaltran`";
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
            sVal = "SELECT `debit` FROM `chartofaccounts`.`journaltran`";
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
            sVal = "SELECT `credit` FROM `chartofaccounts`.`journaltran`";
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
            MySqlConnection conRead4 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conRead4.Open();
            sVal = "SELECT `ID` FROM `chartofaccounts`.`journaltran`";
            MySqlCommand cmdRead4 = new MySqlCommand(sVal, conRead4);
            try
            {
                MySqlDataReader reader4 = cmdRead4.ExecuteReader();
                while (reader4.Read())
                {
                    idL.Add(Int32.Parse(reader4.GetString(0)));


                }



            }
            catch
            {
                Response.Write(sVal);
            }


            cmdRead4.Dispose();
            conRead4.Close();

            /*idL.Add((idL.Count) + 1);
            accountL.Add(DropDownList1.SelectedValue);
            debitL.Add(Double.Parse(TextBox1.Text));
            creditL.Add(Double.Parse(TextBox2.Text));*/



            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Account", typeof(string));
            dt.Columns.Add("Debit", typeof(string));
            dt.Columns.Add("Credit", typeof(string));

            int[] idA = idL.ToArray();
            string[] accountA = accountL.ToArray();
            double[] debitA = debitL.ToArray();
            double[] creditA = creditL.ToArray();

            double dSum = 0;
            double cSum = 0;

            for (int i = 0; i <= accountA.Length - 1; i++)
            {
                dSum = dSum + debitA[i];

            }

            Label2.Text = "" + dSum;


            for (int i = 0; i <= accountA.Length - 1; i++)
            {
                cSum = cSum + creditA[i];

            }

            Label3.Text = "" + cSum;

            for (int i = 0; i <= accountA.Length - 1; i++)
            {
                string dS = "";
                string cS = "";

                if (i == 0)
                {
                    //This one will add the $
                    DataRow row = dt.NewRow();
                    row["ID"] = idA[i];
                    row["Account"] = accountA[i];
                    if (debitA[i] == 0)
                    {
                        row["Debit"] = "";
                    }
                    else
                    {
                        dS = "$" + String.Format("{0:0.00}", debitA[i]);
                        row["Debit"] = dS;
                    }
                    if (creditA[i] == 0)
                    {
                        row["Credit"] = cS;
                    }
                    else
                    {
                        cS = String.Format("{0:0.00}", creditA[i]);
                        row["Credit"] = cS;
                    }

                    dt.Rows.Add(row);
                }
                else
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = idA[i];
                    row["Account"] = accountA[i];
                    if (debitA[i] == 0)
                    {
                        row["Debit"] = "";
                    }
                    else
                    {
                        dS = String.Format("{0:0.00}", debitA[i]);
                        row["Debit"] = dS;
                    }
                    if (creditA[i] == 0)
                    {
                        row["Credit"] = cS;
                    }
                    else
                    {
                        cS = String.Format("{0:0.00}", creditA[i]);
                        row["Credit"] = cS;
                    }
                    dt.Rows.Add(row);
                }




            }



            GridView1.DataSource = dt;
            GridView1.DataBind();

            DropDownList2.DataSource = dt;
            DropDownList2.DataTextField = "ID";


            DropDownList2.DataBind();


            TextBox1.Text = "0";
            TextBox2.Text = "0";

            Label5.Visible = true;
            Label5.ForeColor = System.Drawing.Color.Red;
            Label5.Text = "Row " + ddS + " deleted!";

        }
        public double getDoubleDB(string tbl, string acc, string place)
        {
            double dbVal = 0;
            MySqlConnection conVal = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conVal.Open();
            String sVal = "SELECT `" + place + "` FROM `chartofaccounts`.`" + tbl + "` WHERE `Account` =  '" + acc + "'";
            MySqlCommand cmdVal = new MySqlCommand(sVal, conVal);
            try
            {
                MySqlDataReader reader2 = cmdVal.ExecuteReader();
                if (reader2.Read())
                {
                    String s = reader2.GetValue(0).ToString();
                    dbVal = Double.Parse(s);

                }
            }
            catch
            {
                Response.Write(sVal);
            }


            cmdVal.Dispose();
            conVal.Close();
            return dbVal;
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

        public void updateDoubleDB(string tbl, string column, double amount, string account)
        {
            MySqlConnection conUp = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conUp.Open();

            String coaDB = "UPDATE `chartofaccounts`.`" + tbl + "` SET `" + column + "` = '" + amount + "' WHERE `Account` = '" + account + "'";
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

        public void insertStringDB(string tbl_name, string account, string debit, string credit)
        {
            MySqlConnection conIN = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conIN.Open();

            

            String coaDB = "INSERT INTO `chartofaccounts`.`"+ tbl_name + "` (`account`,`debit`,`credit`) VALUES('" + account + "','" + debit + "','" + credit + "')";
            MySqlCommand cmdIN = new MySqlCommand(coaDB, conIN);

            try
            {
                cmdIN.ExecuteNonQuery();

            }
            catch
            {
                Response.Write("Your account transaction was not submitted. Please review the information submitted.");
            }
            cmdIN.Dispose();
            conIN.Close();
        }

        public void insertStringDB2(string tbl_name,string title, int id, string account, string debit, string credit)
        {
            MySqlConnection conIN2 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conIN2.Open();



            String coaDB2 = "INSERT INTO `chartofaccounts`.`" + tbl_name + "` (`Title`,`ID`,`Account`,`Debit`,`Credit`) VALUES('" + title + "','" + id + "','" + account + "','" + debit + "','" + credit + "')";
            MySqlCommand cmdIN2 = new MySqlCommand(coaDB2, conIN2);

            try
            {
                cmdIN2.ExecuteNonQuery();

            }
            catch
            {
                Response.Write("Your account transaction was not submitted. Please review the information submitted.");
            }
            cmdIN2.Dispose();
            conIN2.Close();
        }


        public void BindData()
        {
            MySqlConnection conJ = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conJ.Open();

            MySqlCommand cmdJ = new MySqlCommand("select * from chartofaccounts.journaltran", conJ);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(cmdJ);
            DataSet ds = new DataSet();
            adp1.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();

            cmdJ.Dispose();
            conJ.Close();
        }

        public void makeBox()
        {
            string tbl = "journaltran";

            string ddS = DropDownList1.SelectedValue;
            string tb1S = TextBox1.Text;
            string tb2S = TextBox2.Text;
            string tbComment = TextBox3.Text;

            List<int> idL = new List<int>();
            List<string> accountL = new List<string>();
            List<double> debitL = new List<double>();
            List<double> creditL = new List<double>();

            insertStringDB(tbl, DropDownList1.SelectedValue, TextBox1.Text, TextBox2.Text);

            Response.Write(TextBox1.Text);
            Response.Write(TextBox2.Text);



            MySqlConnection conRead = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conRead.Open();
            String sVal = "SELECT `account` FROM `chartofaccounts`.`journaltran`";
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
            sVal = "SELECT `debit` FROM `chartofaccounts`.`journaltran`";
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
            sVal = "SELECT `credit` FROM `chartofaccounts`.`journaltran`";
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
            MySqlConnection conRead4 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conRead4.Open();
            sVal = "SELECT `ID` FROM `chartofaccounts`.`journaltran`";
            MySqlCommand cmdRead4 = new MySqlCommand(sVal, conRead4);
            try
            {
                MySqlDataReader reader4 = cmdRead4.ExecuteReader();
                while (reader4.Read())
                {
                    idL.Add(Int32.Parse(reader4.GetString(0)));


                }



            }
            catch
            {
                Response.Write(sVal);
            }


            cmdRead4.Dispose();
            conRead4.Close();

            /*idL.Add((idL.Count) + 1);
            accountL.Add(DropDownList1.SelectedValue);
            debitL.Add(Double.Parse(TextBox1.Text));
            creditL.Add(Double.Parse(TextBox2.Text));*/



            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Account", typeof(string));
            dt.Columns.Add("Debit", typeof(double));
            dt.Columns.Add("Credit", typeof(double));

            int[] idA = idL.ToArray();
            string[] accountA = accountL.ToArray();
            double[] debitA = debitL.ToArray();
            double[] creditA = creditL.ToArray();


            for (int i = 0; i <= accountA.Length - 1; i++)
            {
                DataRow row = dt.NewRow();
                row["ID"] = idA[i];
                row["Account"] = accountA[i];
                row["Debit"] = debitA[i];
                row["Credit"] = creditA[i];
                dt.Rows.Add(row);


            }








            GridView1.DataSource = dt;
            GridView1.DataBind();





        }




        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string ddS = DropDownList2.SelectedValue;

            MySqlConnection conDel = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conDel.Open();
            String sDel = "DELETE FROM `chartofaccounts`.`journaltran` WHERE `ID` =  '" + ddS + "'";
            MySqlCommand cmdDel = new MySqlCommand(sDel, conDel);

            try
            {
                cmdDel.ExecuteNonQuery();
            }
            catch
            {
                Response.Write("Something went wrong with deleting." + sDel);
            }
            cmdDel.Dispose();
            conDel.Close();

            string tbl = "journaltran";



            List<int> idL = new List<int>();
            List<string> accountL = new List<string>();
            List<double> debitL = new List<double>();
            List<double> creditL = new List<double>();







            MySqlConnection conRead = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conRead.Open();
            String sVal = "SELECT `account` FROM `chartofaccounts`.`journaltran`";
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
            sVal = "SELECT `debit` FROM `chartofaccounts`.`journaltran`";
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
            sVal = "SELECT `credit` FROM `chartofaccounts`.`journaltran`";
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
            MySqlConnection conRead4 = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=chartofaccounts;password=andy");
            conRead4.Open();
            sVal = "SELECT `ID` FROM `chartofaccounts`.`journaltran`";
            MySqlCommand cmdRead4 = new MySqlCommand(sVal, conRead4);
            try
            {
                MySqlDataReader reader4 = cmdRead4.ExecuteReader();
                while (reader4.Read())
                {
                    idL.Add(Int32.Parse(reader4.GetString(0)));


                }



            }
            catch
            {
                Response.Write(sVal);
            }


            cmdRead4.Dispose();
            conRead4.Close();

            /*idL.Add((idL.Count) + 1);
            accountL.Add(DropDownList1.SelectedValue);
            debitL.Add(Double.Parse(TextBox1.Text));
            creditL.Add(Double.Parse(TextBox2.Text));*/



            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Account", typeof(string));
            dt.Columns.Add("Debit", typeof(string));
            dt.Columns.Add("Credit", typeof(string));

            int[] idA = idL.ToArray();
            string[] accountA = accountL.ToArray();
            double[] debitA = debitL.ToArray();
            double[] creditA = creditL.ToArray();

            double dSum = 0;
            double cSum = 0;

            for (int i = 0; i <= accountA.Length - 1; i++)
            {
                dSum = dSum + debitA[i];

            }

            Label2.Text = "" + dSum;


            for (int i = 0; i <= accountA.Length - 1; i++)
            {
                cSum = cSum + creditA[i];

            }

            Label3.Text = "" + cSum;

            for (int i = 0; i <= accountA.Length - 1; i++)
            {
                string dS = "";
                string cS = "";

                if (i == 0)
                {
                    //This one will add the $
                    DataRow row = dt.NewRow();
                    row["ID"] = idA[i];
                    row["Account"] = accountA[i];
                    if (debitA[i] == 0)
                    {
                        row["Debit"] = "";
                    }
                    else
                    {
                        dS = "$" + String.Format("{0:0.00}", debitA[i]);
                        row["Debit"] = dS;
                    }
                    if (creditA[i] == 0)
                    {
                        row["Credit"] = cS;
                    }
                    else
                    {
                        cS = String.Format("{0:0.00}", creditA[i]);
                        row["Credit"] = cS;
                    }

                    dt.Rows.Add(row);
                }
                else
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = idA[i];
                    row["Account"] = accountA[i];
                    if (debitA[i] == 0)
                    {
                        row["Debit"] = "";
                    }
                    else
                    {
                        dS = String.Format("{0:0.00}", debitA[i]);
                        row["Debit"] = dS;
                    }
                    if (creditA[i] == 0)
                    {
                        row["Credit"] = cS;
                    }
                    else
                    {
                        cS = String.Format("{0:0.00}", creditA[i]);
                        row["Credit"] = cS;
                    }
                    dt.Rows.Add(row);
                }




            }



            GridView1.DataSource = dt;
            GridView1.DataBind();

            DropDownList2.DataSource = dt;
            DropDownList2.DataTextField = "ID";


            DropDownList2.DataBind();


            TextBox1.Text = "0";
            TextBox2.Text = "0";

            Label5.Visible = true;
            Label5.ForeColor = System.Drawing.Color.Red;
            Label5.Text = "Row " + ddS + " deleted!";
        }
    }
}