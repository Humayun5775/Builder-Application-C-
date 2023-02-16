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
    public partial class FromExport : Form
    {


        SqlDataAdapter adapt;
        DataTable datatable;
        SqlConnection con;
        int simple = 0;
        public FromExport()
        {
            InitializeComponent();
        }
        public FromExport(SqlConnection connection, string text1, string text2, DateTimePicker dateTimePicker12, DateTimePicker dateTimePicker22)
        {
            InitializeComponent();
            con = connection;
            textBox1.Text = text2;
            textBox2.Text = text1;
            dateTimePicker1.Value = dateTimePicker12.Value;
            dateTimePicker2.Value = dateTimePicker22.Value;
        }

        public FromExport(SqlConnection connection, string text2, DateTimePicker dateTimePicker12, DateTimePicker dateTimePicker22)
        {
            InitializeComponent();
            con = connection;
            textBox2.Text = text2;
            dateTimePicker1.Value = dateTimePicker12.Value;
            dateTimePicker2.Value = dateTimePicker22.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(simple == 1)
            {
                exportsimple();
            }
            if(simple == 2)
            {
                exportname();
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
                            Paragraph para = new Paragraph("Category : " + textBox2.Text + "\nName : " + textBox1.Text + "\nDate From : " + dateTimePicker1.Text + "\nDate To : " + dateTimePicker2.Text + "\n\n", FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
                            para.Alignment = Element.ALIGN_LEFT;

                            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;

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


        private void exportsimple()
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
                            Paragraph para = new Paragraph("Category : " + textBox2.Text + "\nDate From : " + dateTimePicker1.Text + "\nDate To : " + dateTimePicker2.Text + "\n\n", FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
                            para.Alignment = Element.ALIGN_LEFT;

                            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;

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




        private void export()
        {
            if (textBox2.Text == "cement")
            {
                try
                {
                    con.Close();
                    con.Open();
                    string aa = "Select Date,Bags,Rate,Amount,Paid,Balance,Oldbalance,Totalbalance from cement where Name like '" + textBox1.Text + "' and date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'";
                    adapt = new SqlDataAdapter(aa, con);
                    datatable = new DataTable();
                    adapt.Fill(datatable);
                    dataGridView2.DataSource = datatable;
                    con.Close();
                    simple = 2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (textBox2.Text == "othermaterial")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select Date,TotalAmount,Paid,Balance,Oldbalance,Totalbalance from othermaterial where Name like '" + textBox1.Text + "' and date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'", con);
                    datatable = new DataTable();
                    adapt.Fill(datatable);
                    dataGridView2.DataSource = datatable;
                    con.Close();
                    simple = 2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (textBox2.Text == "dailyexpense")
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
                    simple = 2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (textBox2.Text == "monthlyexpense")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select Date,Amount,Remarks from monthlyexpense where Name like '" + textBox1.Text + "' and date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'", con);
                    datatable = new DataTable();
                    adapt.Fill(datatable);
                    dataGridView2.DataSource = datatable;
                    con.Close();
                    simple = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (textBox2.Text == "sale")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select Date,Things,Totalbill,Receivebank,Receivecash,Oldbalance,Remainingbalance from sale where Name like '" + textBox1.Text + "' and date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'", con);
                    datatable = new DataTable();
                    adapt.Fill(datatable);
                    dataGridView2.DataSource = datatable;
                    con.Close();
                    simple = 2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (textBox2.Text == "production")
            {
                try
                {
                    con.Close();
                    con.Open();
                    adapt = new SqlDataAdapter("Select Date,Blocksize,Blockpersize,totalslaps,totalblocks,Usedcement,Remarks from production where date between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'", con);
                    datatable = new DataTable();
                    adapt.Fill(datatable);
                    dataGridView2.DataSource = datatable;
                    con.Close();
                    simple = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void FromExport_Load(object sender, EventArgs e)
        {
            export();
        }
    }
}
