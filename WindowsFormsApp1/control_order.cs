using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
