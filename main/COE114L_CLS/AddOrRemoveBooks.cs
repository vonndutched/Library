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
    public partial class AddOrRemoveBooks : Form
    {
        private StreamReader reader;
        private StreamWriter writer;
        private StreamWriter gridToNote;

        public AddOrRemoveBooks()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            if (File.Exists("TempBooks.txt"))
            {
                int booksAvailableNum = File.ReadAllLines("TempBooks.txt").Length;

                reader = new StreamReader("TempBooks.txt");

                for (int i = 0; i < booksAvailableNum; i++)
                {
                   dataGridView1.Rows.Add(reader.ReadLine());
                }

                reader.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("TempBooks.txt"))
            {
                writer = new StreamWriter("TempBooks.txt", true);
                bool found = false;

                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    found = true;
                    writer.WriteLine(textBox1.Text);
                }

                else
                {
                    MessageBox.Show("All fields are required!",
                    "Empty Field Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                writer.Close();

                if (found)
                {
                    MessageBox.Show("Book successfully added! \nClick refresh to update the table",
                    "Adding Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists("TempBooks.txt"))
            {
                foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        dataGridView1.Rows.Remove(row);
                    }
                }

                gridToNote = new StreamWriter("TempBooks.txt");

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    gridToNote.WriteLine(dataGridView1.Rows[i].Cells[0].Value);
                }

                gridToNote.Close();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
