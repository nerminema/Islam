using ELK_POWER.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELK_POWER.Orders
{
    public partial class OrderStatus : Form
    {
        public OrderStatus()
        {
            InitializeComponent();
            dataGridView1.DataSource = order.SelectAll();
        }
        OrderStatusClass order = new OrderStatusClass();
        private void button1_Click(object sender, EventArgs e)
        {
                if(btn_save.Tag== null)
                {
                order.Insert(txt_Status.Text);
                }
                else
                {
                order.Update(txt_Status.Text, int.Parse(btn_save.Tag.ToString()));
                }
          dataGridView1.DataSource=  order.SelectAll();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txt_Status.Text = "";
            btn_save.Tag = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id=int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString());
            if (e.ColumnIndex == 1)
            {
                order.Delete(id);
            }
            else if(e.ColumnIndex ==2)
            {
                txt_Status.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                btn_save.Tag = id.ToString();
            }
            dataGridView1.DataSource = order.SelectAll();
        }

        private void OrderStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
               ComboBox cb_status  = this.Owner.Controls.Find("cb_status", true).First() as ComboBox;
                cb_status.DataSource = order.SelectAll();
                cb_status.DisplayMember = "StatusOrder";
                cb_status.ValueMember = "ID";
                cb_status.SelectedIndex = -1;
            }
            catch
            { }
        }
    }
}
