using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source = 303-2\SQLEXPRESS; Initial Catalog = bd; Integrated Security = SSPI; Integrated Security = true;"))
            {
                //con.DataSource = 
                con.Open();
                SqlCommand command = new SqlCommand($"Select role_id, user_id from [dbo].[user] where login = '{textBox1.Text}' and password = '{textBox2.Text}'", con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        switch(reader[0].ToString().Trim())
                        {
                            case "admin":
                                admin_form g = new admin_form();
                                g.ShowDialog();
                                break;

                            case "gf":

                                user_form k = new user_form(reader[1].ToString());
                                k.ShowDialog();
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
