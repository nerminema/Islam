using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELK_POWER.Classes;

namespace ELK_POWER.Setup
{
    public partial class Services : Form
    {
        public Services()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = services.SelectAll();
        }

        ServicesClass services = new ServicesClass();
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Tag == null)
            {
                services.Insert(textBox1.Text , decimal.Parse(txt_fees.Text));
            }
            else
            {
                services.Update(textBox1.Text, int.Parse(button1.Tag.ToString()), decimal.Parse(txt_fees.Text));
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = services.SelectAll();
            txt_fees.Text=textBox1.Text = "";
            button1.Tag = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            if (e.ColumnIndex == 2)
            {
                button1.Tag = dataGridView1.Rows[id].Cells["Column4"].Value;
                textBox1.Text = dataGridView1.Rows[id].Cells["Column1"].Value.ToString();
                txt_fees.Text = dataGridView1.Rows[id].Cells["Column5"].Value.ToString();
            }
            else if (e.ColumnIndex == 3)
            {
                if (MessageBox.Show("هل انت متأكد انك تريد الحذف", "تحذير", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    services.Delete(int.Parse(dataGridView1.Rows[id].Cells["Column4"].Value.ToString()));
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = services.SelectAll();
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
          txt_fees.Text=  textBox1.Text = "";
            button1.Tag = null;
        }
    }
}
