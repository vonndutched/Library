using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace COE114L_CLS
{
    public partial class BorrowBooks : Form
    {
        public StreamWriter writer;
        public StreamReader reader;
        public StreamReader reader1;
        public StreamWriter writer1;
        public StreamWriter Dates;
        public StreamWriter gridtoNote;

        public BorrowBooks()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool complete = true;

            if (File.Exists("BorrowedBookRecords.txt"))
            {
                writer = new StreamWriter("BorrowedBookRecords.txt", true);

                    if (string.IsNullOrWhiteSpace(textBox1.Text) 
                        || string.IsNullOrEmpty(textBox2.Text)
                        || comboBox1.SelectedItem==null 
                        || comboBox2.SelectedItem==null
                        || dataGridView1.SelectedRows.Count==0)
                    {
                        MessageBox.Show("All fields are required!",
                        "Empty Field Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        complete = false;

                        writer.Close();
                    }
                

                if (complete)
                {
                    // Write yung name sa BorrowedBooksRecord.txt".
                    writer.WriteLine(textBox1.Text);
                    // Write yung student number.
                    writer.WriteLine(textBox2.Text);
                    // Write yung program.
                    writer.WriteLine(comboBox1.Text);
                    // Write yung year level.
                    writer.WriteLine(comboBox2.Text);

                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        writer.WriteLine(row.Cells[0].Value.ToString());

                        if (!row.IsNewRow)
                        {
                            // Tatanggalin yung na select na rows sa data grid view.
                            dataGridView1.Rows.Remove(row);
                        }
                    }

                    // Gawa ng instance para kopyahin yung nasa grid view sa "TempBooks.txt"
                    gridtoNote = new StreamWriter("TempBooks.txt");

                    for (int row = 0; row < dataGridView1.Rows.Count; row++)
                    {
                        gridtoNote.WriteLine(dataGridView1.Rows[row].Cells[0].Value);
                    }

                    gridtoNote.Close();

                    writer.WriteLine(DateTime.Now.ToString());
                    writer.WriteLine("\n");

                    writer.Close();

                    Dates = File.AppendText("DatesBooks.txt");
                    Dates.WriteLine(DateTime.Now.ToString());
                    Dates.Close();
                }
            }
        }

        public void button2_Click_1(object sender, EventArgs e)
        {
            int countBooksAvailable;
            //Kapag pinindot yung refresh kukunin nya yung laman ng tempBooks, 
            //yun yung may laman ng available books tas dun din mababawas

            countBooksAvailable = File.ReadAllLines("TempBooks.txt").Length;

            this.dataGridView1.Rows.Clear();

            if (File.Exists("TempBooks.txt"))
            {
                string[] books = new string[countBooksAvailable];

                reader = new StreamReader("TempBooks.txt");

                for (int i = 0; i < countBooksAvailable; i++)
                {
                    books[i] = reader.ReadLine();
                    dataGridView1.Rows.Add(books[i]);
                }

                reader.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void BorrowBooks_Load(object sender, EventArgs e)
        {

        }

    }
}
