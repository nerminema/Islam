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
    public partial class Branches : Form
    {
        CityClass city = new CityClass();
        AreaClass area = new AreaClass();
        BranchesClass branch = new BranchesClass();
        public Branches()
        {
            InitializeComponent();
            cb_CarBrand.DataSource = city.SelectAll();
            cb_CarBrand.DisplayMember = "CityName";
            cb_CarBrand.ValueMember = "ID";
            cb_CarBrand.SelectedIndex = -1;
            cb_area.DataSource = area.SelectAll();
            
            cb_area.DisplayMember = "AreaName";
            cb_area.ValueMember = "ID";
            cb_area.SelectedIndex = -1;
            dataGridView1.DataSource = branch.SelectAll();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            City city = new City();
            city.Show();
        }

        private void cb_CarBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cb_area.DataSource = area.SelectAllByCity(int.Parse(cb_CarBrand.SelectedValue.ToString()));
                //cb_area.DataSource = area.SelectAll();
                cb_area.DisplayMember = "AreaName";
                cb_area.ValueMember = "ID";
                cb_area.SelectedIndex = -1;
                if (cb_area.Items.Count == 0)
                    cb_area.DataSource = null;
                
            }
            catch
            { }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Area city = new Area();
            city.Show();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (btn_save.Tag == null)
            {
                branch.Insert(txt_model.Text, int.Parse(cb_area.SelectedValue.ToString()));
            }
            else
            {
                branch.Update(txt_model.Text, int.Parse(btn_save.Tag.ToString()), int.Parse(cb_area.SelectedValue.ToString()));
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = branch.SelectAll();
            txt_model.Text = "";
            btn_save.Tag = null;
            cb_CarBrand.SelectedIndex = -1;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            if (e.ColumnIndex == 0)
            {
                btn_save.Tag = dataGridView1.Rows[id].Cells["Column4"].Value;
                txt_model.Text = dataGridView1.Rows[id].Cells["Column5"].Value.ToString();
                cb_CarBrand.SelectedValue = (int)area.SelectAll(int.Parse(dataGridView1.Rows[id].Cells["Column1"].Value.ToString()))[0].CityID;
                cb_area.DataSource = area.SelectAllByCity(int.Parse(cb_CarBrand.SelectedValue.ToString()));

                cb_area.DisplayMember = "AreaName";
                cb_area.ValueMember = "ID";
                cb_area.SelectedIndex = -1;
                cb_area.SelectedValue = dataGridView1.Rows[id].Cells["Column1"].Value;

                
            }
            else if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("هل انت متأكد انك تريد الحذف", "تحذير", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    branch.Delete(int.Parse(dataGridView1.Rows[id].Cells["Column4"].Value.ToString()));
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = branch.SelectAll();
                }
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cb_area.SelectedIndex = cb_CarBrand.SelectedIndex = -1;
            txt_model.Text = "";
        }

        private void Branches_Load(object sender, EventArgs e)
        {

        }

        private void cb_area_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = branch.SelectAllByCity(int.Parse(cb_area.SelectedValue.ToString()));
            }
            catch
            { }
        }
    }
}
