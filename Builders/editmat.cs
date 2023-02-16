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
    public partial class editmat : Form
    {
        string value;
        SqlConnection con;
        public editmat()
        { }
        public editmat(string b, SqlConnection connection)
        {
            InitializeComponent();
            con = connection;
            value = b;
            load();
        }
    private void load()
        {
            try
            {
                con.Open();
                string Command = "select * from othermaterial where Id like '" + value + "%'";
                SqlCommand Comm1 = new SqlCommand(Command, con);

                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    textBox16.Text = DR1.GetValue(2).ToString();
                    numericUpDown8.Value = Int64.Parse(DR1.GetValue(3).ToString());
                    numericUpDown15.Value = Int64.Parse(DR1.GetValue(4).ToString());
                    numericUpDown19.Value = Int64.Parse(DR1.GetValue(5).ToString());
                    numericUpDown9.Value = Int64.Parse(DR1.GetValue(6).ToString());
                    numericUpDown14.Value = Int64.Parse(DR1.GetValue(7).ToString());
                    numericUpDown18.Value = Int64.Parse(DR1.GetValue(8).ToString());
                    numericUpDown10.Value = Int64.Parse(DR1.GetValue(9).ToString());
                    numericUpDown13.Value = Int64.Parse(DR1.GetValue(10).ToString());
                    numericUpDown17.Value = Int64.Parse(DR1.GetValue(11).ToString());
                    numericUpDown19.Value = Int64.Parse(DR1.GetValue(12).ToString());
                    numericUpDown11.Value = Int64.Parse(DR1.GetValue(13).ToString());
                    numericUpDown12.Value = Int64.Parse(DR1.GetValue(14).ToString());
                    numericUpDown16.Value = Int64.Parse(DR1.GetValue(15).ToString());
                    numericUpDown24.Value = Int64.Parse(DR1.GetValue(16).ToString());

                    numericUpDown23.Value = Int64.Parse(DR1.GetValue(17).ToString());
                    numericUpDown22.Value = Int64.Parse(DR1.GetValue(18).ToString());
                    numericUpDown21.Value = Int64.Parse(DR1.GetValue(19).ToString());
                    numericUpDown20.Value = Int64.Parse(DR1.GetValue(20).ToString());
                    textBox13.Text = DR1.GetValue(21).ToString();
                    textBox14.Text = DR1.GetValue(22).ToString();
                    richTextBox2.Text = DR1.GetValue(23).ToString();

                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var dat = dateTimePicker1.Value;
            var shortdat = dat.ToShortDateString();
            string b = shortdat;
            //update
            //try
            //{
            //    //MessageBox.Show(value);
            //    con.Open();
            //    string Query = "update othermaterial set name='" + textBox16.Text + "',raitdumper='" + numericUpDown1.Value + "',raitrate='" + numericUpDown2.Value + "', Amount= '" + numericUpDown3.Value + "',Paid='" + numericUpDown4.Value + "',Balance='" + numericUpDown5.Value + "',Totalbalance='" + numericUpDown6.Value + "' where Id= '" + value + "'";
            //    //This is  MySqlConnection here i have created the object and pass my connection string.  
            //    SqlCommand MyCommand2 = new SqlCommand(Query, con);
            //    SqlDataReader MyReader2;
            //    MyReader2 = MyCommand2.ExecuteReader();
            //    //MessageBox.Show("Data Updated");
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //try
            //{
            //    //MessageBox.Show(value);
            //    con.Open();
            //    string Query = "update cement set Oldbalance='" + numericUpDown7.Value + "',Vehicle='" + textBox18.Text + "',Drivername='" + textBox17.Text + "', Remarks= '" + richTextBox1.Text + "', date= '" + dateTimePicker1.Value + "' where Id= '" + value + "'";
            //    //This is  MySqlConnection here i have created the object and pass my connection string.  
            //    SqlCommand MyCommand2 = new SqlCommand(Query, con);
            //    SqlDataReader MyReader2;
            //    MyReader2 = MyCommand2.ExecuteReader();
            //    MessageBox.Show("Data Updated");
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //delete
            try
            {
                string Query = "delete from othermaterial where id='" + value + "';";
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

