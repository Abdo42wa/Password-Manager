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
    public partial class Login : Form
    {
        public static string username = "";
        string keyy = "youtubee";
        Hash sh = new Hash();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql ql = new sql();
            username = LoginUsername.Text;
            string path = @"C:\\Users\\abdoa\\Desktop\\VIKO 4 Semestar\\Information security\\Password Manager\\Password Manager\\bin\\Debug\\Users\\" + username + ".txt";
          
        
        
            try
            {
                 if (File.Exists(path+".aes"))
                 {
                    ASE sE = new ASE();
                    sE.FileDecrypt(path + ".aes", path, keyy);

                }
                else
                {
                    FileStream fs = File.Create(path);
                    fs.Close();
                }
                

                ql.login(LoginUsername.Text, sh.passHash( loginPassword.Text));

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
