using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class control_order : UserControl
    {
        string order_id = "";
        public control_order(string order_id, string text_order)
        {
            InitializeComponent();
            this.order_id = order_id;
            label1.Text = text_order;
        }

        private void control_order_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source = 303-2\SQLEXPRESS; Initial Catalog = bd; Integrated Security = SSPI; Integrated Security = true;"))
            {
                con.Open();
                SqlCommand command = new SqlCommand($@"DELETE FROM [dbo].[Order] WHERE order_id = {order_id}", con);
                command.ExecuteNonQuery();
            }

            label1.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
