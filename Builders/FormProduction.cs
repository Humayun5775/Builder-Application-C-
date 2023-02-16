using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Builders
{
    public partial class FormProduction : Form
    {

        SqlConnection con;
        int checks =0;
        decimal stockprice = 0; 
        public FormProduction()
        {

            InitializeComponent();
        }
        public FormProduction(SqlConnection connection)
        {

            InitializeComponent();
            con = connection;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cal();
            try
            {

                con.Close();
                con.Open();
                string query = "select Stock from stocks where product like '" + comboBox1.Text + "%'";
                SqlCommand check = new SqlCommand(query, con);
                decimal calll;
                SqlDataReader reader = check.ExecuteReader();
                if (reader.HasRows)
                {
                    //User Exists
                    getvalue();
                    getvaluece();
                    decimal a = numericUpDown6.Value - nudcement.Value;
                    if (a > 0)
                    {
                        numericUpDown6.Value = a;
                        numericUpDown4.Value = numericUpDown4.Value + numericUpDown3.Value;
                        calll = stockprice * numericUpDown4.Value;
                        con.Close();
                        con.Open();
                        string Query = "update stocks set Stock='" + numericUpDown4.Value +  "',TotalStockPrice='" + calll.ToString() +  "' where Product= '" + comboBox1.Text + "'";
                        //This is  MySqlConnection here i have created the object and pass my connection string.  
                        SqlCommand MyCommand2 = new SqlCommand(Query, con);
                        SqlDataReader MyReader2;
                        MyReader2 = MyCommand2.ExecuteReader();
                        //  MessageBox.Show("Data Updated");
                        con.Close();
                        updatecement();
                        one();
                        stockprice = 0;
                        numericUpDown4.Value = 0;
                    }
                    else
                    {
                        MessageBox.Show("You cannot use more then you have");
                        zero();
                    }
                }
                else
                {
                    //User NOT Exists
                    int z = 0;
                    getvaluece();
                    decimal a = numericUpDown6.Value - nudcement.Value;
                    if (a > 0)
                    {
                        con.Close();
                        con.Open();
                        string q = "Insert into stocks ( product,stock,PricePerBlock,TotalStockPrice) values ('" + comboBox1.Text + "','" + numericUpDown3.Value + "','" + z.ToString() + "','" + z.ToString() + "')";
                        SqlCommand insert = new SqlCommand(q, con);
                        insert.ExecuteNonQuery();
                        //MessageBox.Show("Record Inserted");
                        con.Close();
                        updatecement();
                        one();
                    }
                    else
                    {
                        MessageBox.Show("You cannot use more then you have");
                        zero();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (checks == 1)
            {
                try
                {
                    con.Close();
                    con.Open();
                    string query = "Insert into production ( Blocksize,Blockpersize,Totalslaps,Totalblocks,Usedcement,Averageblock,Remarks,Date,Labourrate,Labouramount,Paidlabour,Labourbalance) values ('" + comboBox1.Text + "','" + numericUpDown1.Value.ToString() + "','" + numericUpDown2.Value.ToString() + "','" + numericUpDown3.Value.ToString() + "','" + nudcement.Value.ToString() + "','" + textBox1.Text + "','" + richTextBox3.Text + "','" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "','" + numericUpDown8.Value + "','" + numericUpDown7.Value + "','" + numericUpDown9.Value + "','" + numericUpDown10.Value + "')";
                    SqlCommand insert = new SqlCommand(query, con);
                    insert.ExecuteNonQuery();
                  //  MessageBox.Show("Record Inserted");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            reset();
            this.Refresh();
            
        }
        private void one()
        {
            checks = 1;
        }

        private void zero()
        {
            checks = 0;
        }

        private void updatecement()
        {
            con.Close();
            con.Open();
            string Query = "update stocks set Stock='" + numericUpDown6.Value + "' where Product='" + textBox65.Text + "'";
            //This is  MySqlConnection here i have created the object and pass my connection string.  
            SqlCommand MyCommand2 = new SqlCommand(Query, con);
            SqlDataReader MyReader2;
            MyReader2 = MyCommand2.ExecuteReader();
            //MessageBox.Show("Data Updated");
            con.Close();
        }
        private void getvalue()
        {
            string Command = "select Stock,PricePerBlock from stocks where product like '" + comboBox1.Text + "'";
            SqlCommand Comm1 = new SqlCommand(Command, con);
            con.Close();
            con.Open();
            SqlDataReader DR1 = Comm1.ExecuteReader();
            if (DR1.Read())
            {
                numericUpDown4.Value = Int64.Parse(DR1.GetValue(0).ToString());
                stockprice = Int64.Parse(DR1.GetValue(1).ToString());
            }
            con.Close();
        }


        private void getvaluece()
        {
            string Command = "select Stock from stocks where Product like '" + textBox65.Text + "'";
            SqlCommand Comm1 = new SqlCommand(Command, con);
            con.Close();
            con.Open();
            SqlDataReader DR1 = Comm1.ExecuteReader();
            if (DR1.Read())
            {
                numericUpDown6.Value = Int64.Parse(DR1.GetValue(0).ToString());
            }
            con.Close();
        }
        
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown3.Value = numericUpDown1.Value * numericUpDown2.Value;
            numericUpDown7.Value = numericUpDown8.Value * numericUpDown2.Value;
        }
        private void cal()
        {
            numericUpDown3.Value = numericUpDown1.Value * numericUpDown2.Value;
            numericUpDown7.Value = numericUpDown8.Value * numericUpDown2.Value;
            textBox1.Text = (numericUpDown3.Value / nudcement.Value).ToString();
            numericUpDown7.Value = numericUpDown8.Value * numericUpDown2.Value;
            numericUpDown10.Value = numericUpDown7.Value - numericUpDown9.Value;
        }
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = (numericUpDown3.Value / nudcement.Value).ToString();
        }

        private void FormProduction_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void reset()
        {
            
            textBox1.Text = "";
            richTextBox3.Text = "";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            nudcement.Value = 1;
            numericUpDown6.Value = 0;
            
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown7.Value = numericUpDown8.Value * numericUpDown2.Value;
        }
        

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown10.Value = numericUpDown7.Value - numericUpDown9.Value;
        }
    }
}
