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
    public partial class formstockvalue : Form
    {

        SqlConnection con;
        public formstockvalue()
        {
            InitializeComponent();
            con = con = new SqlConnection( @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\HUMAYUN\source\repos\Builders\Builders\Database.mdf; Integrated Security = True");
            loadpr();

        }
        public formstockvalue(SqlConnection connection)
        {
            InitializeComponent();
            con = connection;
            loadpr();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(value);
                con.Close();
                con.Open();
                string Query = "update stocks set PricePerBlock='" + numericUpDown1.Value + "',TotalStockPrice='" + numericUpDown2.Value + "' where Product= '" + comboBox1.Text + "'";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                SqlCommand MyCommand2 = new SqlCommand(Query, con);
                SqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Updated");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadstock()
        {
            try
            {
                con.Close();
                con.Open();
                string Command = "select stock,PricePerBlock,TotalStockPrice from stocks where product like '" + comboBox1.Text + "%'";
                SqlCommand Comm1 = new SqlCommand(Command, con);

                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    numericUpDown5.Value = Int64.Parse(DR1.GetValue(0).ToString());
                    numericUpDown1.Value = Int64.Parse(DR1.GetValue(1).ToString());
                    numericUpDown2.Value = Int64.Parse(DR1.GetValue(2).ToString());
                }
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
        private void loadpr()
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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Value = numericUpDown5.Value * numericUpDown1.Value;
        }
    }
}
