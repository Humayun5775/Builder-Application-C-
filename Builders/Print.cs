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
    public partial class Print : Form
    {

        SqlConnection con;
        string b;
        public Print()
        {
            InitializeComponent();
           
        }
        public Print(SqlConnection connection)
        {
            InitializeComponent();
            con = connection;
            load();
            var dat = dateTimePicker1.Value;
            var shortdat = dat.ToShortDateString();
            b = shortdat;
        }
    private void load()
        {
            try
            {
                con.Close();
                con.Open();
                string query = "Select blocksize,blockpersize,totalslaps,totalblocks,usedcement,averageblock from production where date like '" + b + "%' ORDER BY date DESC";
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
                this.ProductionGrid.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                con.Close();
                con.Open();
                string query = "Select labouramount,paidlabour,labourbalance from production where date like '" + b + "%' ORDER BY date DESC";
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
                this.labgrid.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            try
            {
                con.Close();
                con.Open();
                string query = "Select * from stocks";
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
                this.Stockgrid.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                con.Close();
                con.Open();
                string query = "Select Name,Bags,Rate,Amount,Paid,Balance,Totalbalance,Oldbalance from cement where date like '" + b + "%'";
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
                this.cementgrid.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                con.Close();
                con.Open();
                string query = "Select name,raitamount,khakamount,painamount,coloramount,totalamount,paid,balance from othermaterial where date like '" + b + "%'";
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
                this.raitgride.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                con.Close();
                con.Open();
                string query = "Select Buyername,things,totalbill,Receivecash,Receivebank,Oldbalance,Remainingbalance from sale where date like '" + b + "%'";
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
                this.salegrid.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                con.Close();
                con.Open();
                string query = "Select name,amount from dailyexpense where date like '" + b + "%'";
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
                this.expensegride.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(970, 740, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(10, 25, 25,30, this.Size);
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();


            //if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            //    printDocument1.Print();
        }

        Bitmap bmp;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void Print_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string b = now.ToString();

            // MessageBox.Show(b);

            label7.Text = label7.Text + b;

        }
    }
}
