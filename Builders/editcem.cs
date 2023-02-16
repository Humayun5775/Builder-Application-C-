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
    public partial class editcem : Form
    {
        string value;
        SqlConnection con;
        
        public editcem()
        {
            InitializeComponent();
        }
        public editcem(string b, SqlConnection connection)
        {

            InitializeComponent();
            con = connection;
            value = b;
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dat = dateTimePicker1.Value;
            var shortdat = dat.ToShortDateString();
            string b = shortdat;
            try
            {
                //MessageBox.Show(value);
                con.Close();
                con.Open();
                string Query = "update cement set Name='" + textBox1.Text + "',bags='" + numericUpDown1.Value + "',Rate='" + numericUpDown2.Value + "', Amount= '" + numericUpDown3.Value + "',Paid='" + numericUpDown4.Value + "',Balance='" + numericUpDown5.Value + "',Totalbalance='" + numericUpDown6.Value + "' where Id= '" + value + "'";
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
            try
            {
                //MessageBox.Show(value);
                con.Close();
                con.Open();
                string Query = "update cement set Oldbalance='" + numericUpDown7.Value + "',Vehicle='" + textBox18.Text + "',Drivername='" + textBox17.Text + "', Remarks= '" + richTextBox1.Text + "', date= '" + b + "' where Id= '" + value + "'";
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
            this.Close();
        }

        private void load()
        {
            try
            {
                con.Close();
                con.Open();
                string Command = "select * from cement where Id like '" + value + "%'";
                SqlCommand Comm1 = new SqlCommand(Command, con);

                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    textBox1.Text = DR1.GetValue(1).ToString();
                    numericUpDown1.Value = Int64.Parse(DR1.GetValue(2).ToString());
                    numericUpDown2.Value = Int64.Parse(DR1.GetValue(3).ToString());
                    numericUpDown3.Value = Int64.Parse(DR1.GetValue(4).ToString());
                    numericUpDown4.Value = Int64.Parse(DR1.GetValue(5).ToString());
                    numericUpDown5.Value = Int64.Parse(DR1.GetValue(6).ToString());
                    numericUpDown6.Value = Int64.Parse(DR1.GetValue(7).ToString());
                    numericUpDown7.Value = Int64.Parse(DR1.GetValue(8).ToString());
                    textBox18.Text = DR1.GetValue(9).ToString();
                    textBox17.Text = DR1.GetValue(10).ToString();
                    richTextBox1.Text = DR1.GetValue(11).ToString();
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //delete
            try
            {
                string Query = "delete from cement where id='" + value + "';";
                SqlCommand MyCommand2 = new SqlCommand(Query, con);
                SqlDataReader Reader2;
                Reader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Deleted");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
