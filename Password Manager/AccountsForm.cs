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
    public partial class AccountsForm : Form
    {
        public AccountsForm()
        {
            InitializeComponent();
        }

        DataTable table = new DataTable();
        private void AccountsForm_Load(object sender, EventArgs e)
        {
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Username", typeof(string));
            table.Columns.Add("Password",typeof(string));
            table.Columns.Add("URL", typeof(string));
            table.Columns.Add("More", typeof(string));

            dataGridView1.DataSource = table;

            table.Columns[3].GetHashCode();

            readfromFile();

           
        }


        public void readfromFile()
        {
            string path = @"C:\\Users\\abdoa\\Desktop\\VIKO 4 Semestar\\Information security\\Password Manager\\Password Manager\\bin\\Debug\\Users\\" + Login.username + ".txt";

            if (File.Exists(path))
            {

                string[] lines = File.ReadAllLines(path);
               

                string[] values;

                for (int i = 0; i < lines.Length; i++)
                {
                    values = lines[i].ToString().Split(';');

                    string[] row = new string[values.Length];

                    for (int j = 0; j < values.Length; j++)
                    {
                        row[j] = values[j].Trim();
                    }

                    table.Rows.Add(row);
                }
            }
            else
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }
                
            
            

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Index == 3)
            {
                if (e.Value != null)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
