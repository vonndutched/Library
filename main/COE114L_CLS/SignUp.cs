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
    public partial class SignUp : Form
    {
        private StreamReader reader;
        private StreamWriter writer;
        bool valid = false;

        public SignUp()
        {
            InitializeComponent();
        }

        private void masterPasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void logInMasterPasswordButton_Click(object sender, EventArgs e)
        {
            // Kailangan nakainitialize yung master password para magamit.
            string masterPassword="";

            // Chinecheck kung merong "MasterPassword.txt".
            if (File.Exists("MasterPassword.txt"))
            {
                // Gagawa ng instance sa StremReader Class.
                reader = new StreamReader("MasterPassword.txt");
                // Babasahin kung ano yung master password na nasa "MasterPassword.txt".
                masterPassword = reader.ReadLine();

                reader.Close();
            }

            // Chinechech kung yung inenter sa textbox ay equal dun sa nabasang master password
            // sa "MasterPassword.txt"
            if (masterPasswordTextBox.Text==masterPassword)
            {
                // Ginawa tong flag na to para malaman kung pwede na mag register yung bagong user.
                valid = true;

                // Pwede ng gamiting yung mga tools kaya hindi na read only.
                fullNameTextBox.ReadOnly = false;
                signUpUserNameTextBox.ReadOnly = false;
                signUpPasswordTextBox.ReadOnly = false;
                confirmPasswordTextBox.ReadOnly = false;
                registerAccountButton.Enabled = true;

                // Iniiba lang kulay nung mga tools na nasa SigUp.cs[Designer].
                fullNameTextBox.BackColor = Color.White;
                signUpUserNameTextBox.BackColor = Color.White;
                signUpPasswordTextBox.BackColor = Color.White;
                confirmPasswordTextBox.BackColor = Color.White;
                

                label5.Text = "(Unlocked)";

                // Prompt na tama ang inenter na master password.
                MessageBox.Show("Successfully unlocked! \nClick OK then register in the previous window.", " ",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Invalid master password!", " ",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void MasterPassword_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void fullNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void signUpUserNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void signUpPasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void confirmPasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void registerAccountButton_Click(object sender, EventArgs e)
        {
            if (valid)
            {
                // Tinitingnan kung parehas kung nasa password saka confirm password na textbox.
                if (signUpPasswordTextBox.Text==confirmPasswordTextBox.Text)
                {
                    // Basically nirerecord lang neto separately yung mga useri info.

                    if (File.Exists("AdminName.txt"))
                    {
                        writer = new StreamWriter("AdminName.txt", true);
                        writer.WriteLine(fullNameTextBox.Text.ToString());

                        writer.Close();
                    }

                    if (File.Exists("Username.txt"))
                    {
                        writer = new StreamWriter("Username.txt", true);
                        writer.WriteLine(signUpUserNameTextBox.Text.ToString());

                        writer.Close();
                    }

                    if (File.Exists("Password.txt"))
                    {
                        writer = new StreamWriter("Password.txt", true);
                        writer.WriteLine(signUpPasswordTextBox.Text.ToString());

                        writer.Close();
                    }

                    if (MessageBox.Show("Registered successfully! \nClick OK to log in.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information)==DialogResult.OK)
                    {
                        // Bubuksan yung LoginForm window uli tapos icoclose tong SignUp window.
                        LoginForm login = new LoginForm();
                        this.Hide();
                        login.Show();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }
    }
}
