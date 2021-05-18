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
    public partial class Home : Form
    {

        public Home()
        {
            InitializeComponent();
            
        }

        string keyy = "youtubee";
        private void Home_Load(object sender, EventArgs e)
        {

            HomeUsername.Text = Login.username;

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            
            CreateAccount createAccount = new CreateAccount();
            createAccount.ShowDialog();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AccountsForm form = new AccountsForm();
            form.ShowDialog();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"C:\\Users\\abdoa\\Desktop\\VIKO 4 Semestar\\Information security\\Password Manager\\Password Manager\\bin\\Debug\\Users\\" + HomeUsername.Text + ".txt";
                ASE sE = new ASE();
                sE.FileEncrypt(path, keyy);
               
                MessageBox.Show("file is encrypted" + path);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            this.Close();

        }
       
    }
}
