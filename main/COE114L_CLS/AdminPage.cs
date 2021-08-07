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
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        // Display lang ng time dun sa toolstrip.
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Oopen lang yung AddOrRemoveBooks na window.
            AddOrRemoveBooks addOrRemove = new AddOrRemoveBooks();
            addOrRemove.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Oopen lang yung BorrowBooks window.
            BorrowBooks borrowBooks = new BorrowBooks();
            borrowBooks.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Oopen lang yung ReturnBooks window.
            ReturnBooks returnBooks = new ReturnBooks();
            returnBooks.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        // Ginawa tong property para baguhin yung <admin name> label dun sa pangalan ng user na naglogin.
        public string LabelText
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;
            }
            
        }

        private void adminGuidelinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminGuidelines guide = new AdminGuidelines();
            guide.Show();
        }

        private void aboutCLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutCLS about = new AboutCLS();
            about.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();

            this.Close();
        }
    }
}
