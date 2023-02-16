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
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;


namespace Builders
{
    public partial class FormReport : Form
    {
        
        SqlConnection con;


        decimal sumExpense=0;
        decimal sumSale=0;
        public FormReport()
        {
            InitializeComponent();
        }
        public FormReport(SqlConnection connection)
        {

            InitializeComponent();
            con = connection;
        }
        private void FormReport_Load(object sender, EventArgs e)
        {
            load();
            textBox1.Text = sumExpense.ToString();
            textBox2.Text = sumSale.ToString();
            textBox3.Text = (sumSale - sumExpense).ToString();
        }

        private void load()
        {
            try
            {
                con.Close();
                con.Open();
                string Command = "select Sum(Amount) from cement where date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'"; 
                SqlCommand Comm1 = new SqlCommand(Command, con);

                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    sumExpense = sumExpense + Int64.Parse(DR1.GetValue(0).ToString());
                }
                con.Close();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                
            }
            //MessageBox.Show(sumExpense.ToString());
            try
            {
                con.Close();
                con.Open();
                string Command = "select Sum(Amount) from dailyexpense where date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'";
                SqlCommand Comm1 = new SqlCommand(Command, con);

                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    sumExpense = sumExpense + Int64.Parse(DR1.GetValue(0).ToString());
                }
                con.Close();

            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

            try
            {
                con.Close();
                con.Open();
                string Command = "select Sum(Amount) from monthlyexpense where date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'";
                SqlCommand Comm1 = new SqlCommand(Command, con);

                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    sumExpense = sumExpense + Int64.Parse(DR1.GetValue(0).ToString());
                }
                con.Close();

            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }


            try
            {
                con.Close();
                con.Open();
                string Command = "select Sum(Totalamount) from Othermaterial where date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'";
                SqlCommand Comm1 = new SqlCommand(Command, con);

                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    sumExpense = sumExpense + Int64.Parse(DR1.GetValue(0).ToString());
                }
                con.Close();

            }
            catch (Exception ex)
            {
            //    MessageBox.Show(ex.Message);
            }


            try
            {
                con.Close();
                con.Open();
                string Command = "select Sum(Labouramount) from production where date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'";
                SqlCommand Comm1 = new SqlCommand(Command, con);

                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    sumExpense = sumExpense + Int64.Parse(DR1.GetValue(0).ToString());
                }
                con.Close();

            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
            }

            //-----------------------------------------------------------Sold--------------
            try
            {
                con.Close();
                con.Open();
                string Command = "select Sum(Labouramount) from production where date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'";
                SqlCommand Comm1 = new SqlCommand(Command, con);

                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    sumSale = sumSale + Int64.Parse(DR1.GetValue(0).ToString());
                }
                con.Close();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            sumExpense = 0;
            sumSale = 0;
            load();

            textBox1.Text = sumExpense.ToString();
            textBox2.Text = sumSale.ToString();
            textBox3.Text = (sumSale - sumExpense).ToString();
        }
    }
}
