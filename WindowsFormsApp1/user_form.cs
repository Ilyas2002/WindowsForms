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
    public partial class user_form : Form
    {
        List<Order> list_orders = new List<Order>();
        public string user_id = "";
        public user_form(string user_id)
        {
            InitializeComponent();
            this.user_id = user_id;
        }

        //string Order

        public struct Order
        {
            public string car_id, count, date, user_id;
            public Order(string car_id, string count, string date, string user_id)
            {
                this.user_id = user_id;
                this.car_id = car_id;
                this.count = count;
                this.date = date;
            }
        }


        private void user_from_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source = 303-2\SQLEXPRESS; Initial Catalog = bd; Integrated Security = SSPI; Integrated Security = true;"))
            {
                con.Open();
                SqlCommand command = new SqlCommand($"Select marka,value from [dbo].[car]", con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader[0].ToString() + " " + reader[1].ToString().Trim() + " " + reader[2].ToString().Trim());
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source = 303-2\SQLEXPRESS; Initial Catalog = bd; Integrated Security = SSPI; Integrated Security = true;"))
            {
                //con.DataSource = 
                con.Open();
                SqlCommand command = new SqlCommand($@"INSERT INTO [dbo].[order]
           ([user_id]
           ,[car_id]
           ,[count]
           ,[date])
     VALUES
           ({user_id}
           ,{comboBox1.SelectedIndex+1}
           ,{textBox1.Text}
           ,'{DateTime.Now}')", con);
                command.ExecuteNonQuery();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

        }
    }

    
}
