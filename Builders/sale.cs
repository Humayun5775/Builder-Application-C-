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
    public partial class sale : Form
    {
        SqlConnection con;
        SqlDataAdapter adapt;
        DataTable datatab = new DataTable();
        DataTable datatable;
        int i;
        int check;
        decimal pricestock;
        string c;

        public sale()
        {
            InitializeComponent();
            
            loaddata();
            combo();
        }
        public sale(SqlConnection connection)
        {
            InitializeComponent();
            con = connection;
            loaddata();
            combo();
        }
    private void loadstock()
        {
            try
            {
                con.Open();
                string Command = "select stock from stocks where product like '" + comboBox1.Text + "%'";
                SqlCommand Comm1 = new SqlCommand(Command, con);

                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    numericUpDown5.Value = Int64.Parse(DR1.GetValue(0).ToString());
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
        private void combo()
        {
            try
            {
                comboBox1.Items.Clear();
                con.Close();
                con.Open();

                string Command = "select product from stocks ";
                SqlCommand Comm1 = new SqlCommand(Command, con);
                Comm1.ExecuteNonQuery();
                DataTable da = new DataTable();
                SqlDataAdapter dr = new SqlDataAdapter(Command, con);
                dr.Fill(da);
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    comboBox1.Items.Add(da.Rows[i]["product"]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void sale_Load(object sender, EventArgs e)
        {
            
             dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);

            datatab.Columns.Add("BlockSize", typeof(string));
            datatab.Columns.Add("TotalBlock", typeof(int));
            datatab.Columns.Add("Rate", typeof(int));
            datatab.Columns.Add("Amount", typeof(int));
            datatab.Columns.Add("extra", typeof(string));

            dataGridView2.DataSource = datatab;
        }
        private void loaddata()
        {
            try
            {
                con.Close();
                con.Open();
                string query = "Select * from sale";
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

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                int j = dataGridView2.RowCount;
                for (int i = 0; i < j-1; i++)
                {

                    con.Close();
                    con.Open();
                    numericUpDown11.Value = Int64.Parse(dataGridView2.Rows[i].Cells[1].Value.ToString());
                    c = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    string query = "select stock,PricePerBlock from stocks where product like '" + c + "'";
                    SqlCommand check = new SqlCommand(query, con);
                    SqlDataReader reader = check.ExecuteReader();
                    if (reader.HasRows)
                    {
                        //User Exists
                        if (reader.Read())
                        {
                            numericUpDown10.Value = Int64.Parse(reader.GetValue(0).ToString());
                            pricestock = Int64.Parse(reader.GetValue(1).ToString());
                        }
                        con.Close();
                        Update();
                    }
                    else
                    {
                        //User NOT Exists
                        MessageBox.Show("No Stock Availible");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (check == 1)
            {
                try
                {
                    con.Close();
                    con.Open();
                    string query = "Insert into sale ( Date,Buyername,Mobile,Things,Totalbill,Receivecash,Receivebank,Oldbalance,Remainingbalance) values ('"  + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")+ "','" +textBox1.Text + "','" + textBox3.Text + "','" + richTextBox1.Text + "','" + numericUpDown8.Value.ToString() + "','" + numericUpDown3.Value.ToString() + "','" + numericUpDown4.Value.ToString() + "','" + numericUpDown9.Value.ToString() + "','" + numericUpDown7.Value.ToString() +"')";
                    SqlCommand insert = new SqlCommand(query, con);
                    insert.ExecuteNonQuery();
                    //MessageBox.Show("Record Inserted");
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
        private void Update()
        {
            try
            {
                decimal inputprice;
                decimal a = numericUpDown10.Value - numericUpDown11.Value;
                if (a > 0)
                {
                    con.Close();
                    con.Open();
                    numericUpDown10.Value = a;
                    inputprice = pricestock * a;
                    string Query = "update stocks set Stock='" + numericUpDown10.Value + "',TotalStockPrice='" + inputprice + "' where Product= '" + c + "'";
                    //This is  MySqlConnection here i have created the object and pass my connection string.  
                    SqlCommand MyCommand2 = new SqlCommand(Query, con);
                    SqlDataReader MyReader2;
                    MyReader2 = MyCommand2.ExecuteReader();
                    //MessageBox.Show("Data Updated");
                    con.Close();
                    check = 1;
                }
                else
                {
                    MessageBox.Show("You cannot sell more then you have");
                    check = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void reset()
        {
            richTextBox1.Text = "";
            textBox1.Text = "";
            comboBox1.ResetText();
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.ResetText();
            // numericUpDown5.Value = 0;
            numericUpDown6.Value = 0;
            numericUpDown7.Value = 0;
            numericUpDown8.Value = 0;
            numericUpDown9.Value = 0;
            numericUpDown10.Value = 0;
            numericUpDown11.Value = 0;

            DataTable dt = (DataTable)dataGridView2.DataSource;
            dt.Clear();
            dataGridView2.DataSource = dt;
            dataGridView2.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                datatab.Rows.Add(comboBox1.Text, numericUpDown1.Value, numericUpDown2.Value, numericUpDown6.Value);
                richTextBox1.Text = richTextBox1.Text + comboBox1.Text + ", " + (numericUpDown1.Value).ToString() + ", " + (numericUpDown2.Value).ToString() + ", " + (numericUpDown6.Value).ToString() + "\n";
                numericUpDown8.Value = numericUpDown8.Value + numericUpDown6.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                //numericUpDown7.Value = Int64.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                //textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                i = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[i];
                string b = row.Cells[0].Value.ToString();

                string Command = "select BuyerName,Remainingbalance from sale where Id like '" + b + "%'";
                SqlCommand Comm1 = new SqlCommand(Command, con);
                con.Close();
                con.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    numericUpDown9.Value = Int64.Parse(DR1.GetValue(1).ToString());
                    textBox1.Text = DR1.GetValue(0).ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown6.Value = numericUpDown1.Value * numericUpDown2.Value;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown7.Value = numericUpDown3.Value + numericUpDown4.Value + numericUpDown9.Value - numericUpDown8.Value;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Close();
                con.Open();
                adapt = new SqlDataAdapter("Select * from sale where BuyerName like '" + textBox1.Text + "%' ORDER BY Id DESC", con);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadstock();
        }
    }
}