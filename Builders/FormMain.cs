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
    public partial class FormMain : Form
    {
        
        SqlConnection con;
        public FormMain()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\builder\Builders\Builders\Builder.mdf;Integrated Security=True");
            loadstock();
        }

        private void loadstock()
        {
            try
            {
                con.Close();
                con.Open();
                string query = "Select Product,Stock from stocks";
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
        private void button1_Click(object sender, EventArgs e)
        {
            
            loadstock();
            panel5.Controls.Clear();
            FormProduction frm = new FormProduction(con) { TopLevel = false, TopMost = true };
            this.panel5.Controls.Add(frm);
            frm.Show();
            //FormProduction formProduction = new FormProduction();
            //formProduction.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadstock();
            panel5.Controls.Clear();
            Expensive frm = new Expensive(con) { TopLevel = false, TopMost = true };
            this.panel5.Controls.Add(frm);
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadstock();
            panel5.Controls.Clear();

            formpurchase frm = new formpurchase(con) { TopLevel = false, TopMost = true };
            this.panel5.Controls.Add(frm);
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadstock();
            panel5.Controls.Clear();
            sale frm = new sale(con) { TopLevel = false, TopMost = true };
            this.panel5.Controls.Add(frm);
            frm.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            loadstock();
            panel5.Controls.Clear();
            ViewRecord frm = new ViewRecord(con) { TopLevel = false, TopMost = true };
            this.panel5.Controls.Add(frm);
            frm.Show(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel5.Controls.Clear();
            System.Environment.Exit(0);
        }

        
        private void button7_Click(object sender, EventArgs e)
        {
            loadstock();
            Print frm = new Print(con);
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            loadstock();
            panel5.Controls.Clear();
            FormReport frm = new FormReport(con) { TopLevel = false, TopMost = true };
            this.panel5.Controls.Add(frm);
            frm.Show();

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            loadstock();
            panel5.Controls.Clear();
            formstockvalue frm = new formstockvalue(con) { TopLevel = false, TopMost = true };
            this.panel5.Controls.Add(frm);
            frm.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
