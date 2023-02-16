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
    public partial class Expensive : Form
    {
        
        SqlDataAdapter adapt;
        DataTable datatable;
        SqlConnection con;
        public Expensive()
        {
            InitializeComponent();
            
        }
        public Expensive(SqlConnection connection)
        {

            InitializeComponent();
            con = connection;
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Daily")
            {
                try
                {
                    con.Close();
                    con.Open();
                    string query = "Insert into dailyexpense ( date, name, amount, remarks) values ('" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "','" + textBox1.Text + "','" + numericUpDown1.Value + "','" + richTextBox1.Text + "')";
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
            else if (comboBox1.Text == "Monthly")
            {
                try
                {
                    con.Close();
                    con.Open();
                    string query = "Insert into monthlyexpense ( date, name, amount, remarks) values ('" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "','" + textBox1.Text + "','" + numericUpDown1.Value + "','" + richTextBox1.Text + "')";
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
                MessageBox.Show("No Type Selected");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Daily")
            {
                try
                {
                    con.Close();
                    con.Open();
                    string query = "Select * from dailyexpense  order by date desc";
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
            else if (comboBox1.Text == "Monthly")
            {
                try
                {
                    con.Close();
                    con.Open();
                    string query = "Select * from monthlyexpense  order by date desc";
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
        }

        private void Expensive_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "Daily")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select * from dailyexpense where name like '" + textBox1.Text + "%' order by date desc", con);
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
            else if (comboBox1.Text == "Monthly")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select * from monthlyexpense where name like '" + textBox1.Text + "%' order by date desc", con);
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
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
