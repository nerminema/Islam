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
    public partial class Area : Form
    {
        public Area()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = brands.SelectAll();
            cb_CarBrand.DataSource = City.SelectAll();
            cb_CarBrand.DisplayMember = "CityName";
            cb_CarBrand.ValueMember = "ID";
            cb_CarBrand.SelectedIndex = -1;

        }
        AreaClass brands = new AreaClass();
        CityClass City = new CityClass();

        private void button1_Click(object sender, EventArgs e)
        {
            if (btn_save.Tag == null)
            {
                brands.Insert(txt_model.Text , int.Parse(cb_CarBrand.SelectedValue.ToString()));
            }
            else
            {
                brands.Update(txt_model.Text, int.Parse(cb_CarBrand.SelectedValue.ToString()), int.Parse(btn_save.Tag.ToString()));
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = brands.SelectAll();
            txt_model.Text = "";
            btn_save.Tag = null;
            cb_CarBrand.SelectedIndex = -1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            if (e.ColumnIndex == 1)
            {
                btn_save.Tag = dataGridView1.Rows[id].Cells["Column4"].Value;
                txt_model.Text = dataGridView1.Rows[id].Cells["Column5"].Value.ToString();
                cb_CarBrand.SelectedValue =dataGridView1.Rows[id].Cells["Column1"].Value;
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
                ComboBox cb_CarBrand = this.Owner.Controls.Find("cb_area", true).First() as ComboBox;
                cb_CarBrand.DataSource = brands.SelectAll();
                cb_CarBrand.DisplayMember = "AreaName";
                cb_CarBrand.ValueMember = "ID";
                cb_CarBrand.SelectedIndex = -1;
            }
            catch
            { }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            City city = new City();
            city.Show(this);
        }

        private void cb_CarBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Select Area by city
            try
            {
                dataGridView1.DataSource = brands.SelectAllByCity(int.Parse(cb_CarBrand.SelectedValue.ToString()));
            }
            catch{ }
            }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txt_model.Text = "";
            btn_save.Tag = null;
            cb_CarBrand.SelectedIndex = -1;
        }
    }
}
