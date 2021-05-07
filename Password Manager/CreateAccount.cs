using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Manager
{
    public partial class CreateAccount : Form
    {

        public string path = @"C:\\Users\\abdoa\\Desktop\\VIKO 4 Semestar\\Information security\\Password Manager\\Password Manager\\bin\\Debug\\Users\\" + Login.username + ".txt";
        public string record = "";
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            StreamReader srCheck = new StreamReader(path);

            string checkID = srCheck.ReadToEnd();

            srCheck.Close();

            if (checkID.Contains(txtID.Text + ";"))
            {
                MessageBox.Show("this ID is exist please chang it");
                txtID.Focus();
                txtID.SelectAll();
            }
            else
            {
                StreamWriter sw = new StreamWriter(path, true);

                string strData = txtID.Text + ";" + txtTitle.Text + ";" + txtUsername.Text + ";" + txtPassword.Text + ";" + txtURL.Text + ";" + txtMore.Text;


                sw.WriteLine(strData);
                sw.Close();

                MessageBox.Show("Account Is Added");

                foreach (Control c in this.Controls)
                {
                    if(c is TextBox)
                    {
                        c.Text = "";
                    }
                }
            }

           

        }

        
       
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (txtID.Text.Trim() != "")
            {
                StreamReader sr = new StreamReader(path);
                string line = "";
                bool found = false;
                do
                {
                    line = sr.ReadLine();
                    if(line != null)
                    {
                        string[] data = line.Split(';');
                        if(data[0] == txtID.Text)
                        {
                            txtID.Text = data[0];
                            txtTitle.Text = data[1];
                            txtUsername.Text = data[2];
                            txtPassword.Text = data[3];
                            txtURL.Text = data[4];
                            txtMore.Text = data[5];
                            found = true;
                            record = line;
                            break;
                        }
                    }
                } while (line != null);

                sr.Close();

                if (!found)
                {
                    MessageBox.Show("this id Not Found");
                }
            }
            else
            {
                MessageBox.Show("please enter the ID!");
            }
        }
        private void Update_Click(object sender, EventArgs e)
        {
            string line = "";
            string[] data1 = record.Split(';');
            StreamReader sr = new StreamReader(path);
            List<string> result = new List<string>();
            do
            {
                line = sr.ReadLine();
                if (line != null)
                {
                    string[] data = line.Split(';');
                    if (data[0] == data1[0])
                    {
                        result.Add(data1[0] + ";" + txtTitle.Text + ";" + txtUsername.Text + ";" + txtPassword.Text + ";" + txtURL.Text + ";" + txtMore.Text);

                    }
                    else
                    {
                        result.Add(line);
                    }
                }
            } while (line != null);
            sr.Close();
            File.Delete(path);
            StreamWriter sw = new StreamWriter(path);
            foreach (var item in result)
            {
                sw.WriteLine(item);
                Console.WriteLine(item);
            }

            sw.Close();

            MessageBox.Show("updated successfully ");

            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string line = "";
                string[] data1 = record.Split(';');
                StreamReader sr = new StreamReader(path);
                List<string> result = new List<string>();
                do
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        string[] data = line.Split(';');
                        if (data[0] == data1[0])
                        {
                            continue;

                        }
                        else
                        {
                            result.Add(line);
                        }
                    }
                } while (line != null);
                sr.Close();
                File.Delete(path);
                StreamWriter sw = new StreamWriter(path);
                foreach (var item in result)
                {
                    sw.WriteLine(item);
                    Console.WriteLine(item);
                }

                sw.Close();

                MessageBox.Show("Deleted successfully ");

                foreach (Control c in this.Controls)
                {
                    if (c is TextBox)
                    {
                        c.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassword.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtPassword.Text);
            MessageBox.Show("Coped password");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PasswordGenerator password = new PasswordGenerator();
            txtPassword.Text = password.GeneratePassword(true, true, true, true, 16);
        }
    }
}
