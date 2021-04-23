using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Manager
{
    public partial class Login : Form
    {
        public static string username = "";
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql ql = new sql();
            username = LoginUsername.Text;
            try
            {
                ql.login(LoginUsername.Text, loginPassword.Text);

                Home home = new Home();
                home.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.ShowDialog();
        }
    }
}
