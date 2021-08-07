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
    public partial class LoginForm : Form
    {
        private StreamReader reader;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int countUserName, countPassword, countAdmin;
            bool flag = false;

            countUserName = File.ReadAllLines("Username.txt").Length;
            countPassword = File.ReadAllText("Password.txt").Length;
            countAdmin = File.ReadAllText("AdminName.txt").Length;

            string[] username = new string[countUserName];
            string[] password = new string[countPassword];
            string[] adminName = new string[countAdmin];

            if (File.Exists("Username.txt"))
            {
                reader = new StreamReader("Username.txt");

                for (int i = 0; i < countUserName; i++)
                {
                    username[i] = reader.ReadLine();
                }

                reader.Close();
            }

            if (File.Exists("Password.txt"))
            {
                reader = new StreamReader("Password.txt");

                for (int i = 0; i < countUserName; i++)
                {
                    password[i] = reader.ReadLine();
                }

                reader.Close();
            }

            if (File.Exists("AdminName.txt"))
            {
                reader = new StreamReader("AdminName.txt");

                for (int i = 0; i < countUserName; i++)
                {
                    adminName[i] = reader.ReadLine();
                }

                reader.Close();
            }


            for (int i = 0; i < countUserName && i < countPassword; i++)
            {
                if (textBox1.Text == username[i] && textBox2.Text == password[i])
                {
                    flag = true;
                    AdminPage admin = new AdminPage();
                    admin.LabelText = username[i];

                    this.Hide();
                    admin.Show();
                    break;
                }
            }

            if (flag == false)
            {
                MessageBox.Show("Invalid username and/or password!", " ",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            this.Hide();
            signUp.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Please contact Mapúa DOIT regarding this case."
                + "\n\nDevelopment Office for Information Technology"
                + "\n\nMANILA CAMPUS"
                + "\n\n4th Floor, Admin Bldg."
                + "\nMapúa Institute of Technology"
                + "\nMuralla St., Intramuros , Manila"
                + "\n1002 Philipines"
                + "\nTel. No. +63(2) 247-5000 loc. 1403"
                + "\nFax No. +63(2) 527-3683"

                + "\n\nMAKATI CAMPUS"
                + "\n\n2/F Mapúa Information Technology Center"
                + "\n333 Sen. Gil Puyat Avenue, Makati City"
                + "\n1202 Philippines"
                + "\nTel. No. + 63(2) 247-5000 loc. 5800 or +63(2) 891-0686"
                + "\nFax No. +63(2) 891-0686"

                + "\n\nE-mail Addresses: helpdesk@mapua.edu.ph",

                "Contact DOIT");
        }
    }
}
