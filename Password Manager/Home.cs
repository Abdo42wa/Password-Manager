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
            
                FileEncrypt(path, keyy);
               
                MessageBox.Show("file is encrypted" + path);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            this.Close();

        }
      /*  private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string path = @"C:\\Users\\abdoa\\Desktop\\VIKO 4 Semestar\\Information security\\Password Manager\\Password Manager\\bin\\Debug\\Users\\" + HomeUsername.Text + ".txt";
            FileEncrypt(path, keyy);
            e.Cancel = true;
            
        }*/
        public static byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 10; i++)
                {
                    
                    rng.GetBytes(data);
                }
            }

            return data;
        }
      

        public void FileEncrypt(string inputFile, string password)
        {
       
            byte[] salt = GenerateRandomSalt();

           
            FileStream fsCrypt = new FileStream(inputFile + ".aes", FileMode.Create);

            
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

           
            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;

           
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

      
            AES.Mode = CipherMode.CFB;

          
            fsCrypt.Write(salt, 0, salt.Length);

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(inputFile, FileMode.Open);

            
            byte[] buffer = new byte[1048576];
            int read;

            try
            {
                while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Application.DoEvents(); 
                    cs.Write(buffer, 0, read);
                }

               
                fsIn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cs.Close();
                fsCrypt.Close();
                File.Delete(inputFile);
            }
        }
    }
}
