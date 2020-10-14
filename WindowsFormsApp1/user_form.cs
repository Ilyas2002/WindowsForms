using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class user_form : Form
    {
     list<Order> list_orders = new List<Order>();
        public user_form(string user_id, string car_id, string count, string date)
        {
            InitializeComponent();
            this.user_id = user_id;
        }

        //string Order
        

          public string car_id, cout, date;
        public Order(string car_id, string cout, string date)
        {
            this.user_id = user_id;
            this.car_id = car_id;
            this.count = count;
            this.date = date;
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
                        comboBox1.Items.Add(reader[0].ToString() +" " + reader[1].ToString().Trim() +" "+ reader[2].ToString().Trim());
                    }
                }
            }
        }


    }

    
}
