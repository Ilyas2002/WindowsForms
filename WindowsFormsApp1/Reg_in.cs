using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Reg_in : Form
    {
        public Reg_in()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!=""&& (textBox2.Text == textBox3.Text) && textBox4.Text != "" && textBox5.Text != "")
            {
                using (SqlConnection con = new SqlConnection(@"Data Source = 303-2\SQLEXPRESS; Initial Catalog = bd; Integrated Security = SSPI; Integrated Security = true;"))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand($@"INSERT INTO [dbo].[user]
           ([login]
           ,[password]
           ,[role_id]
           ,[fio]
           ,[email])
     VALUES
           (<login, nchar(10),>
           ,<password, nchar(30),>
           ,<role_id, nchar(10),>
           ,<fio, nchar(100),>
           ,<email, nchar(30),>)", con);

                    if (command.ExecuteNonQuery() == 1)
                        this.Close();

                }
            }
            
        }

        private void Reg_in_Load(object sender, EventArgs e)
        {

        }
    }
}
