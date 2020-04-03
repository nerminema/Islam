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
    public partial class CarModel : Form
    {
        BrandsClass brand = new BrandsClass();
        CarModelClass model = new CarModelClass();
        public CarModel()
        {
            InitializeComponent();
            cb_CarBrand.DataSource = brand.SelectAll();
            cb_CarBrand.DisplayMember = "BrandName";
            cb_CarBrand.ValueMember = "ID";
            cb_CarBrand.SelectedIndex = -1;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = model.SelectAll();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CarBrands brands = new CarBrands();
            brands.Show(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cb_CarBrand.SelectedIndex = -1;
            txt_Cap.Text = txt_model.Text = txt_year.Text = "";
            btn_save.Tag = null;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
        if(btn_save.Tag == null)
        {
                // insert 
                model.Insert(txt_model.Text, int.Parse(cb_CarBrand.SelectedValue.ToString()), txt_Cap.Text, txt_year.Text);
        }
        else 
        {
                // update 
                model.Update(txt_model.Text, int.Parse(cb_CarBrand.SelectedValue.ToString()), txt_Cap.Text, txt_year.Text , int.Parse(btn_save.Tag.ToString()));
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = model.SelectAll();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id  = int.Parse( dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString());
            if (e.ColumnIndex== 4)
            {
               List<usp_SelectAllCarsByID_Result> car= model.SelectAll(id);
                txt_Cap.Text = car[0].MotorCap;
                txt_model.Text = car[0].CarModel;
                txt_year.Text = car[0].Man_Year;
                cb_CarBrand.SelectedValue = car[0].BrandID.ToString();
            }
            else if(e.ColumnIndex==5)
            {
                if (MessageBox.Show("هل انت متأكد انك تريد الحذف", "تحذير", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    model.Delete(id);
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = model.SelectAll();
                }
            }
        }

        private void cb_CarBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
        try
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = model.SelectAllByBrand(int.Parse(cb_CarBrand.SelectedValue.ToString()));
            }
        catch{ }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
