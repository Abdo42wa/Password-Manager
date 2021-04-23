using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager
{
    class sql
    {
        private SqlConnection conn;
       


        //ServerConnection Server = new ServerConnection();

        public sql()
        {
            conn = new SqlConnection("Data Source = DESKTOP-V6NNKDQ; Initial Catalog=passwordManager; Integrated Security=True");

        }

        public void AddUser(string username,string password)
        {
            string yourSql = "SELECT Username FROM UserTbl WHERE Username = @Username";
            SqlCommand cmd1 = new SqlCommand(yourSql, conn);
            cmd1.Parameters.AddWithValue("@Username", username);
            conn.Open();
            var rezult = cmd1.ExecuteScalar();
            conn.Close();

            if (rezult != null)
            {
                throw new Exception("This username alrady exists , sry plz try new one");
            }
            else
            {
                string mySQL = string.Empty;

                mySQL += "INSERT INTO UserTbl (Username, Password)";

                mySQL += "VALUES (@Username,@Password)";

                SqlCommand cmd = new SqlCommand(mySQL, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                throw new Exception("You have created an account successfully");




            }

        }

        public void login(string Username, string Password)
        {
            if (!string.IsNullOrEmpty(Username) &&
                  !string.IsNullOrEmpty(Password))
            {

           
                string mySQL = string.Empty;

                //get info from data base
                mySQL += "SELECT * FROM UserTbl ";
                mySQL += "WHERE Username = @Username";
                mySQL += " AND password = @password";

                SqlCommand cmd = new SqlCommand(mySQL, conn);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@password", Password);


                conn.Open();
                cmd.ExecuteNonQuery();
                DataTable userData = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(userData);

                conn.Close();


                if (userData.Rows.Count > 0)
                {
                   

                    return;
                }
                else
                {
                    throw new Exception("The username or password is in correct. Try again");

                }


            }
            else
            {
                throw new Exception("Please Enter your data");


            }

        }
    }
}
