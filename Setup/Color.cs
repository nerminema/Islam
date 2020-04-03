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
    public partial class Color : Form
    {
        public Color()
        {
            InitializeComponent();
        }
        ColorsClass brands = new ColorsClass();
      

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Tag == null)
            {
                brands.Insert(textBox1.Text);
            }
            else
            {
                brands.Update(textBox1.Text, int.Parse(button1.Tag.ToString()));
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = brands.SelectAll();
            textBox1.Text = "";
            button1.Tag = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            if (e.ColumnIndex == 1)
            {
                button1.Tag = dataGridView1.Rows[id].Cells["Column4"].Value;
                textBox1.Text = dataGridView1.Rows[id].Cells["Column1"].Value.ToString();
            }
            else if (e.ColumnIndex == 2)
            {
                if (MessageBox.Show("هل انت متأكد انك تريد الحذف", "تحذير", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    brands.Delete(int.Parse(dataGridView1.Rows[id].Cells["Column4"].Value.ToString()));
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = brands.SelectAll();
                }
            }

        }

        private void CarBrands_Load(object sender, EventArgs e)
        {

        }

        private void CarBrands_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ComboBox cb_CarBrand = this.Owner.Controls.Find("cb_Colors", true).First() as ComboBox;
                cb_CarBrand.DataSource = brands.SelectAll();
                cb_CarBrand.DisplayMember = "ColorName";
                cb_CarBrand.ValueMember = "ID";
                cb_CarBrand.SelectedIndex = -1;
            }
            catch
            { }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            button1.Tag = null;
        }
    }
}
