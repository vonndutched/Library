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
    public partial class ReturnBooks : Form
    {
        public StreamWriter writer;
        public StreamReader reader;
        public StreamWriter writer1;
        public StreamWriter writer2;
        public StreamReader penaltyRead;

        public ReturnBooks()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectedCells.ToString();       
        }

        // *****REFRESH BUTTON***** //
        private void button1_Click_1(object sender, EventArgs e)
        {
            // Clear muna yung nasa grid.
            dataGridView1.Rows.Clear();
            int numDates = File.ReadAllLines("DatesBooks.txt").Length;

            if (File.Exists("BorrowedBookRecords.txt"))
            {
                int booksBorrowed = File.ReadAllLines("BorrowedBookRecords.txt").Length;

                string[] Borrowed = new string[booksBorrowed];

                reader = new StreamReader("BorrowedBookRecords.txt");

                for (int i = 0; i < booksBorrowed; i++)
                {
                    Borrowed[i] = reader.ReadLine();
                }

               


                if (numDates > 0)
                {
                    // Ilalagay nya lahat ng laman ng "BorrowedBookRecords.txt".
                    // Tas lalagay sa array.
                    string[] numBorrowed = new String[numDates + 1];

                    dataGridView1.Rows.Add(numDates);

                    // Iaadd na nya sa grid yung mga nasa array.
                    // Eight lines yung kasunod ng bawat info kaya times eight.
                    for (int i = 0; i < numDates; i++)
                    {
                        dataGridView1[0,i].Value = Borrowed[0 + (8 * i)];
                        dataGridView1[1,i].Value = Borrowed[1 + (8 * i)];
                        dataGridView1[2,i].Value = Borrowed[2 + (8 * i)];
                        dataGridView1[3,i].Value = Borrowed[3 + (8 * i)];
                        dataGridView1[4,i].Value = Borrowed[4 + (8 * i)];
                        dataGridView1[5,i].Value = Borrowed[5 + (8 * i)];

                    }
                    reader.Close();
                }

                else
                {
                    MessageBox.Show("Borrowed books record is empty!", "Empty Book Records",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        // ***** CHECK PENALTY BUTTON ***** //
        private void button1_Click_3(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int days;
                string penaltyWord;
                decimal penalty;
                bool isDamaged = false;

                if (checkBox1.Checked)
                {
                    isDamaged = true;
                }

                // Ginawa kong string yung laman ng cell 5 ng na select na row
                penaltyWord = row.Cells[5].Value.ToString();

                // Eto yung pagcreate ng instance sa class na ginawa natin na "Penalty.cs".
                Penalty penaltyDays = new Penalty(penaltyWord, isDamaged);

                // Conversion saka computation nng oras dun sa loob ng class.
                penaltyDays.ConvertDateToDateTime();
                penaltyDays.ComputeDateDifferenceDay();

                // Dito kinuha na nya yung number of days na hiniram.
                days = penaltyDays.getDaysBorrowed();

                // Computation ng price ng penalty.
                penaltyDays.ComputePenalty();
                penalty = penaltyDays.getPenalty();
                
                // Tas eto pag pinindot mo na yung "Check Penalty".
                // Makikita mo sa textbox yung presyo na babayaran.
                // Tas pwede mo din iedit kunyari depende sa damage etc...

                // Converrt lang sa string yung price ng penalty.
                textBox2.Text = penalty.ToString();
            }
        }

        // ***** RETURN BUTTON ***** //
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select student's info in the data grid view!", "No student selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                // Dinadagdag nya sa mga pwedeng hiramin na libro yung nabalik na.
                writer1 = File.AppendText("TempBooks.txt");
                writer = new StreamWriter("BorrowedBookRecords.txt");
                writer2 = new StreamWriter("DatesBooks.txt");

 

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    writer1.WriteLine(row.Cells[4].Value);
                    if (!row.IsNewRow)
                        dataGridView1.Rows.Remove(row);
                }

                // Eto madedelete naman yung record na kapag napindot na yung return.
                // Kukunin nya lahat ng laman ng grid view na natitira.
                // Tas lalagay nya sa notepad iooverwrite lang nya yung "BorrowedBookRecords.txt".

                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    writer.WriteLine(dataGridView1.Rows[row].Cells[0].Value);
                    writer.WriteLine(dataGridView1.Rows[row].Cells[1].Value);
                    writer.WriteLine(dataGridView1.Rows[row].Cells[2].Value);
                    writer.WriteLine(dataGridView1.Rows[row].Cells[3].Value);
                    writer.WriteLine(dataGridView1.Rows[row].Cells[4].Value);
                    writer.WriteLine(dataGridView1.Rows[row].Cells[5].Value);
                    writer.WriteLine("\n");
                }

                // Eto naman yung mga dates lang ooverwrite nya lang din.
                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    writer2.WriteLine(dataGridView1.Rows[row].Cells[5].Value);
                }

                writer1.Close();
                writer2.Close();
                writer.Close();

                // Tas eto naman mabubura yung price na nakalagay sa textbox na penalty.
                textBox2.Text = "";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReturnBooks_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
