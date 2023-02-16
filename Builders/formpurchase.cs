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
using System.Text.RegularExpressions;

namespace Builders
{
    public partial class formpurchase : Form
    {
        SqlConnection con;
        SqlDataAdapter adapt;
        DataTable datatable;
        int i;
        public formpurchase()
        {
            InitializeComponent();   
        }
        public formpurchase(SqlConnection connection)
        {
            InitializeComponent();
            con = connection;
            panel1.Hide();
            panel2.Hide();
            dataGridView1.Hide();
        }
        private void btnsave_Click(object sender, EventArgs e)
        {

            //var dat = dateTimePicker1.Value;
            //var shortdat = dat.ToShortDateString();
            //string b = shortdat;
            //MessageBox.Show(b);
            if (comboBox1.Text == "Cement")
            {
                update();
                try
                {
                    con.Close();
                    con.Open();
                    string query = "Insert into cement ( Name, Bags ,Rate, Amount,Paid,Balance,Totalbalance,Oldbalance,Vehicle,Drivername,Remarks,date) values ('" + textBox1.Text + "','" + numericUpDown1.Value.ToString() + "','" + numericUpDown2.Value.ToString() + "','" + numericUpDown3.Value.ToString() + "','" + numericUpDown4.Value.ToString() + "','" + numericUpDown5.Value.ToString() + "','" + numericUpDown6.Value.ToString() + "','" + numericUpDown7.Value.ToString() + "','" + textBox18.Text + "','" + textBox17.Text + "','" + richTextBox1.Text + "','" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "')";
                    SqlCommand insert = new SqlCommand(query, con);
                    insert.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (comboBox1.Text == "Other Materials")
            {
                try
                {
                    con.Close();
                    con.Open();
                    string query = "Insert into othermaterial ( Name, Raitdumper ,Raitrate, Raitamount,Khakadamper,Khakarate,Khakamount,Paindamper,Painrate,Painamount,Totalamount,Paid,Balance,Totalbalance,Oldbalance,Vehicle,Drivername,Remarks,Date) values ('" + textBox16.Text + "','" + numericUpDown8.Value + "','" + numericUpDown15.Value + "','" + numericUpDown19.Value + "','" + numericUpDown10.Value + "','" + numericUpDown13.Value + "','" + numericUpDown17.Value + "','" + numericUpDown9.Value + "','" + numericUpDown14.Value + "','" + numericUpDown18.Value + "','"  + numericUpDown24.Value + "','" + numericUpDown23.Value + "','" + numericUpDown22.Value + "','" + numericUpDown20.Value + "','" + numericUpDown21.Value + "','" + textBox14.Text + "','" + textBox13.Text + "','" + richTextBox2.Text + "','" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "')";
                    SqlCommand insert = new SqlCommand(query, con);
                    insert.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("Select Material Kind");


            reset();
            this.Refresh();
        }
        private void update()
        {
            try
            {
                con.Close();
                con.Open();
                string query = "select Stock from stocks where Product like '" + comboBox1.Text + "'";
                SqlCommand check = new SqlCommand(query, con);
                SqlDataReader reader = check.ExecuteReader();
                if (reader.HasRows)
                {
                    //User Exists
                    if (reader.Read())
                    {
                        numericUpDown25.Value = Int64.Parse(reader.GetValue(0).ToString());
                    }
                    con.Close();
                    con.Open();
                    numericUpDown25.Value = numericUpDown25.Value + numericUpDown1.Value;
                    string Query = "update stocks set Stock='" + numericUpDown25.Value + "' where Product= '" + comboBox1.Text + "'";
                    //This is  MySqlConnection here i have created the object and pass my connection string.  
                    SqlCommand MyCommand2 = new SqlCommand(Query, con);
                    SqlDataReader MyReader2;
                    MyReader2 = MyCommand2.ExecuteReader();
                   // MessageBox.Show("Data Updated");
                    con.Close();
                }
                else
                {
                    //User NOT Exists
                    MessageBox.Show("No Stock Availible");
                    con.Close();
                    con.Open();
                    string qu = "Insert into stocks ( Product,Stock) values ('" + comboBox1.Text + "','" + numericUpDown1.Value + "')";
                    SqlCommand insert = new SqlCommand(qu, con);
                    insert.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted");
                    con.Close();
                }

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Cement")
            {
                panel1.Show();
                panel2.Hide();
                data_loadcemnt();
            }
            else if (comboBox1.Text == "Other Materials")
            {
                panel2.Show();
                panel1.Hide();
                data_loadmet();
            }
            dataGridView1.Show();
        }

        private void data_loadcemnt()
        {
            try
            {
                con.Close();
                con.Open();
                string query = "Select Id,Date,Name,Oldbalance,Totalbalance from cement  order by Date desc";
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
                this.dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void data_loadmet()
        {
            try
            {
                con.Close();
                con.Open();
                string query = "Select Id,Date,Name,Oldbalance,Totalbalance from othermaterial  order by Date desc";
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
                this.dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            reset();
            
            if (comboBox1.Text == "Cement")
            {
                try
                {
                    i = e.RowIndex;
                    DataGridViewRow row = dataGridView1.Rows[i];
                    string b = row.Cells[0].Value.ToString();

                    string Command = "select  Name,Totalbalance from cement sale where Id like '" + b + "%'";
                    SqlCommand Comm1 = new SqlCommand(Command, con);
                    con.Close();
                    con.Open();
                    SqlDataReader DR1 = Comm1.ExecuteReader();
                    if (DR1.Read())
                    {
                        numericUpDown7.Value = Int64.Parse(DR1.GetValue(1).ToString());
                        textBox1.Text = DR1.GetValue(0).ToString();
                    }
                        con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else if (comboBox1.Text == "Other Materials")
            {
                try
                {
                    i = e.RowIndex;
                    DataGridViewRow row = dataGridView1.Rows[i];
                    string b = row.Cells[0].Value.ToString();

                    string Command = "select  Name,Totalbalance from othermaterial where Id like '" + b + "%'";
                    SqlCommand Comm1 = new SqlCommand(Command, con);
                    con.Close();
                    con.Open();
                    SqlDataReader DR1 = Comm1.ExecuteReader();
                    if (DR1.Read())
                    {

                        numericUpDown21.Value = Int64.Parse(DR1.GetValue(1).ToString());
                        textBox16.Text = DR1.GetValue(0).ToString();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

               
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Close();
                con.Open();
                adapt = new SqlDataAdapter("Select Id,Date,Name,Totalamount,Paid,Balance,Oldbalance,Totalbalance from othermaterial where Name like '" + textBox16.Text + "%' order by Date desc", con);
                datatable = new DataTable();
                adapt.Fill(datatable);
                dataGridView1.DataSource = datatable;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Close();
                con.Open();
                adapt = new SqlDataAdapter("Select Id,date,Name,Amount,Paid,Balance,Oldbalance,Totalbalance from cement where Name like '" + textBox1.Text + "%'  order by Date desc", con);
                datatable = new DataTable();
                adapt.Fill(datatable);
                dataGridView1.DataSource = datatable;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void reset()
        {

            textBox1.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            numericUpDown6.Value = 0;
            numericUpDown7.Value = 0;
            numericUpDown8.Value = 0;
            numericUpDown9.Value = 0;
            numericUpDown10.Value = 0;
            numericUpDown13.Value = 0;
            numericUpDown14.Value = 0;
            numericUpDown15.Value = 0;
            numericUpDown17.Value = 0;
            numericUpDown18.Value = 0;
            numericUpDown19.Value = 0;
            numericUpDown20.Value = 0;
            numericUpDown21.Value = 0;
            numericUpDown22.Value = 0;
            numericUpDown23.Value = 0;
            numericUpDown24.Value = 0;

        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //bag
            numericUpDown3.Value = numericUpDown1.Value * numericUpDown2.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            //rate
            numericUpDown3.Value = numericUpDown1.Value * numericUpDown2.Value;
            numericUpDown4.Enabled = true;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            //paid
            numericUpDown5.Value = numericUpDown4.Value - numericUpDown3.Value;

            numericUpDown6.Value = numericUpDown7.Value + numericUpDown5.Value;

        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown6.Value = numericUpDown7.Value + numericUpDown5.Value;
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            //rait
            numericUpDown19.Value = numericUpDown8.Value * numericUpDown15.Value;
        }
        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            //pain
            numericUpDown18.Value = numericUpDown9.Value * numericUpDown14.Value;

        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            //khaka
            numericUpDown17.Value = numericUpDown10.Value * numericUpDown13.Value;
        }

        
        
        private void numericUpDown23_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown22.Value = numericUpDown23.Value - numericUpDown24.Value;
        }

        private void numericUpDown21_ValueChanged(object sender, EventArgs e)
        {
            //oldbalnce
            numericUpDown20.Value = numericUpDown21.Value + numericUpDown22.Value;

        }

        private void formpurchase_Load(object sender, EventArgs e)
        {
           

        }

        private void numericUpDown19_ValueChanged(object sender, EventArgs e)
        {
            //totalbalance
            numericUpDown24.Value = numericUpDown19.Value + numericUpDown18.Value + numericUpDown17.Value;

        }
    }
}
