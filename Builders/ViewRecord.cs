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

    public partial class ViewRecord : Form
    {

        SqlDataAdapter adapt;
        DataTable datatable;
        SqlConnection con;
        public ViewRecord()
        {
            InitializeComponent();
        }
        public ViewRecord(SqlConnection connection)
        {

            InitializeComponent();
            con = connection;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "cement")
            {
                try
                {
                    con.Close();
                    con.Open();
                    string query = "Select * from cement  order by Id desc";
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
            else if (comboBox1.Text == "othermaterial")
            {
                try
                {
                    con.Close();
                    con.Open();
                    string query = "Select * from othermaterial  order by Id desc";
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
            else if (comboBox1.Text == "dailyexpense")
            {
                try
                {
                    con.Close();
                    con.Open();
                    string query = "Select * from dailyexpense order by date desc";
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
            else if (comboBox1.Text == "monthlyexpense")
            {
                try
                {
                    con.Close();
                    con.Open();
                    string query = "Select * from monthlyexpense order by date desc";
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
            else if (comboBox1.Text == "sale")
            {
                try
                {
                    con.Close();
                    con.Open();
                    string query = "Select * from sale order by Id desc";
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
            else if (comboBox1.Text == "production")
            {
                try
                {
                    con.Close();
                    con.Open();
                    string query = "Select * from production order by date desc";
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
            else if (comboBox1.Text == "stock")
            {
                try
                {
                    con.Close();
                    con.Open();
                    string query = "Select * from stocks";
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            //var dat = dateTimePicker1.Value;
            //var shortdat = dat.ToShortDateString();
            //string b = shortdat;
            ////MessageBox.Show(b);
            if (comboBox1.Text == "cement")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select * from cement where date like '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "%'", con);
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
            else if (comboBox1.Text == "othermaterial")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select * from othermaterial where date like '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "%' ORDER BY date DESC", con);
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
            else if (comboBox1.Text == "dailyexpense")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select * from dailyexpense where date like '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "%' ORDER BY date DESC", con);
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
            else if (comboBox1.Text == "monthlyexpense")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select * from monthlyexpense where date like '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "%' ORDER BY date DESC", con);
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
            else if (comboBox1.Text == "sale")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select * from sale where date like '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "%' ORDER BY date DESC", con);
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
            else if (comboBox1.Text == "production")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select * from production where date like '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "'", con);
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
        private void reset()
        {
            comboBox1.Text = "";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "cement")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select * from cement where name like '" + textBox1.Text + "%' ORDER BY date DESC", con);
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
            else if (comboBox1.Text == "othermaterial")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select * from othermaterial where name like '" + textBox1.Text + "%' ORDER BY date DESC", con);
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
            else if (comboBox1.Text == "dailyexpense")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select * from dailyexpense where name like '" + textBox1.Text + "%' ORDER BY date DESC", con);
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
            else if (comboBox1.Text == "monthlyexpense")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select * from monthlyexpense where name like '" + textBox1.Text + "%' ORDER BY date DESC", con);
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
            else if (comboBox1.Text == "sale")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select * from sale where Buyername like '" + textBox1.Text + "%' ORDER BY date DESC", con);
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
            else if (comboBox1.Text == "production")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select * from production where Blocksize like '" + textBox1.Text + "%' ORDER BY date DESC", con);
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


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            if (comboBox1.Text == "cement")
            {
                //i = e.RowIndex;
                //DataGridViewRow row = dataGridView1.Rows[i];
                //string b = row.Cells[0].Value.ToString();
                //editcem edit = new editcem(b,con);
                //edit.Show();
            }
            else if (comboBox1.Text == "othermaterial")
            {
            }
            else if (comboBox1.Text == "dailyexpense")
            {
            }
            else if (comboBox1.Text == "monthlyexpense")
            {
            }
            else if (comboBox1.Text == "sale")
            {
            }
            else if (comboBox1.Text == "production")
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            export();
            exportname();
            reset();
        }
        private void export()
        {
            if (comboBox1.Text == "cement")
            {
                try
                {
                    con.Close();
                    con.Open();
                    string aa = "Select Date,Bags,Rate,Amount,Paid,Balance,Oldbalance,Totalbalance from cement where Name like '" + textBox1.Text + "' and date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'";
                    adapt = new SqlDataAdapter(aa, con);
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
            else if (comboBox1.Text == "othermaterial")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select Date,TotalAmount,Paid,Balance,Oldbalance,Totalbalance from othermaterial where Name like '" + textBox1.Text + "' and date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'", con);
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
            else if (comboBox1.Text == "dailyexpense")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select Date,Amount,Remarks from dailyexpense where Name like '" + textBox1.Text + "' and date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'", con);
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
            else if (comboBox1.Text == "monthlyexpense")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select Date,Amount,Remarks from monthlyexpense where Name like '" + textBox1.Text + "' and date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'", con);
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
            else if (comboBox1.Text == "sale")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select Date,Things,Totalbill,Receivebank,Receivecash,Oldbalance,Remainingbalance from sale where Name like '" + textBox1.Text + "' and date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'", con);
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
            else if (comboBox1.Text == "production")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select Date,Blocksize,Blockpersize,totalslaps,totalblocks,Usedcement,Remarks from production where date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'", con);
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

        private void exportname()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            Paragraph para = new Paragraph("Category : " + comboBox1.Text + "\nName : " + textBox1.Text + "\nDate From : " + dateTimePicker1.Text + "\nDate To : " + dateTimePicker2.Text + "\n\n", FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
                            para.Alignment = Element.ALIGN_LEFT;

                            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
                            
                            iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance("");
                            png.ScaleToFit(105f, 105f);
                            png.Alignment = Element.ALIGN_RIGHT;

                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                pdfTable.AddCell(cell);
                            }
                            int lenght = dataGridView1.RowCount;
                            int a = 0;
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {

                                    PdfPCell cells = new PdfPCell(new Phrase(cell.Value.ToString()));
                                    cells.HorizontalAlignment = Element.ALIGN_CENTER;
                                    pdfTable.AddCell(cells);
                                    //pdfTable.AddCell(cell.Value.ToString());
                                }

                                a++;
                                if (a >= (lenght))
                                {
                                    break;
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4.Rotate());

                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(para);
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }



        private void Search_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "cement")
            {
                try
                {
                    con.Close();
                    con.Open();

                    string aa = "Select * from cement where Name like '" + textBox1.Text + "' and date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'";
                    adapt = new SqlDataAdapter(aa, con);
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
            else if (comboBox1.Text == "othermaterial")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select * from othermaterial where Name like '" + textBox1.Text + "' and date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'", con);
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
            else if (comboBox1.Text == "dailyexpense")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select * from dailyexpense where  Name like '" + textBox1.Text + "' and date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'", con);
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
            else if (comboBox1.Text == "monthlyexpense")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select * from monthlyexpense where Name like '" + textBox1.Text + "' and date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'", con);
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
            else if (comboBox1.Text == "sale")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select * from sale where  Buyername like '" + textBox1.Text + "' and date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'", con);
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
            else if (comboBox1.Text == "production")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select * from production where Blocksize like '" + textBox1.Text + "' and date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'", con);
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
    }
}
    

