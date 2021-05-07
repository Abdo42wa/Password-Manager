using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Manager
{
    public partial class SignUp : Form
    {
        public string userpassword,userconfirmpassword;
        Hash sh = new Hash();
        public SignUp()
        {
            InitializeComponent();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql ql = new sql();
            try
            {
               
                if (Password.Text == ConfiemPassword.Text)
                {
                    ql.AddUser(Username.Text,sh.passHash(Password.Text));
                }
                else
                {
                    MessageBox.Show("password does not match");
                }
                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }
    }
}
