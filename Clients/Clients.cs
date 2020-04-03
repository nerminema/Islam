using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELK_POWER.Setup;
using ELK_POWER.Classes;

namespace ELK_POWER.Clients
{
    public partial class Clients : Form
    {
       
        public Clients()
        {
            InitializeComponent();
            Fill();
        }
        public Clients(int id )
        {
            InitializeComponent();
            Fill();
            List< usp_SelectAllClientsByID_Result >list= client.SelectAll(id);
            txt_clientName.Text = list[0].Client_Name;
            txt_Mobil.Text = list[0].Client_Mobil;
            txt_whats.Text = list[0].Client_WhatusApp;
            cb_cat.SelectedValue = (int)list[0].Client_CatID;
            cb_City.SelectedValue = (int)area.SelectAll((int)list[0].ClientAreaID)[0].CityID;
            cb_area.SelectedValue = (int)list[0].ClientAreaID;
            cb_branches.SelectedValue = (int)list[0].BranchID;
            cmb_ads.SelectedValue = (int)list[0].HowDidYouKnowus;
            btn_save.Text = "تعديل بيانات";
            btn_save.Tag = id;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = clientCar.SelectAllByCar((int)id);
        }
        BrandsClass brands = new BrandsClass();
        CarModelClass model = new CarModelClass();
        ClientCategoryClass cat = new ClientCategoryClass();
        ColorsClass colors = new ColorsClass();
        CityClass city = new CityClass();
        BranchesClass branch = new BranchesClass();
        AreaClass area = new AreaClass();
        ClientClass client = new ClientClass();
        HowClass how = new HowClass();
        ClientCarClass clientCar = new ClientCarClass();
        private void Fill()
        {
            #region cars brand 
            cb_CarBrand.DataSource = brands.SelectAll();
            cb_CarBrand.DisplayMember = "BrandName";
            cb_CarBrand.ValueMember = "ID";
            cb_CarBrand.SelectedIndex = -1;
            #endregion
            #region client Category 
           // ComboBox cb_CarBrand = this.Owner.Controls.Find("cb_cat", true).First() as ComboBox;
            cb_cat.DataSource = cat.SelectAll();
            cb_cat.DisplayMember = "Client_Category";
            cb_cat.ValueMember = "ID";
            cb_cat.SelectedIndex = -1;

            #endregion 
            #region Colors
            cb_colors.DataSource = colors.SelectAll();
            cb_colors.DisplayMember = "ColorName";
            cb_colors.ValueMember = "ID";
            cb_colors.SelectedIndex = -1;
            #endregion
            #region City
            cb_City.DataSource = city.SelectAll();
            cb_City.DisplayMember = "CityName";
            cb_City.ValueMember = "ID";
            cb_City.SelectedIndex = -1;
            #endregion
            #region ads 
            cmb_ads.DataSource = how.SelectAll();
            cmb_ads.DisplayMember = "HowDidYouUS";
            cmb_ads.ValueMember = "ID";
            cmb_ads.SelectedIndex = -1;
            #endregion
            #region Area 
            cb_area.DataSource = area.SelectAll();
            cb_area.DisplayMember = "AreaName";
            cb_area.ValueMember = "ID";
            cb_area.SelectedIndex = -1;
            #endregion 
            #region  branches
            cb_branches.DataSource = branch.SelectAll();
            cb_branches.DisplayMember = "BranchName";
            cb_branches.ValueMember = "ID";
            cb_branches.SelectedIndex = -1;
            #endregion

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                txt_whats.Text = txt_Mobil.Text;
            else
                txt_whats.Text = "";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CarBrands brand = new CarBrands();
            brand.Show(this);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClientCategory cat = new ClientCategory();
            cat.Show(this);
        }

        private void cb_CarBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cb_model.DataSource = model.SelectAllByBrand(int.Parse(cb_CarBrand.SelectedValue.ToString()));
                cb_model.DisplayMember = "CarModel";
                cb_model.ValueMember = "ID";
                cb_model.SelectedIndex = -1;
            }catch{ }

        }

        private void cb_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cb_area.DataSource = area.SelectAllByCity(int.Parse(cb_City.SelectedValue.ToString()));
                cb_area.DisplayMember = "AreaName";
                cb_area.ValueMember = "ID";
                cb_area.SelectedIndex = -1;
            }
            catch
            { }
        }
        int? id = null;
        private void button1_Click(object sender, EventArgs e)
        {
            if (id == null)
            {
                try
                {
                    client.Insert(txt_clientName.Text, txt_Mobil.Text, txt_whats.Text, int.Parse(cb_area.SelectedValue.ToString()), int.Parse(cb_cat.SelectedValue.ToString()), int.Parse(cmb_ads.SelectedValue.ToString()), int.Parse(cb_branches.SelectedValue.ToString()));
                    id = client.Max();
                    if (id != null)
                    {
                        clientCar.Insert((int)id, int.Parse(cb_model.SelectedValue.ToString()), txt_car_No.Text, int.Parse(cb_colors.SelectedValue.ToString()), txt_Km.Text);
                    }
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = clientCar.SelectAllByCar((int)id);
                    btn_save.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("من فضلك ادخل البيانات بشكل صحيح", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else 
            {
                client.Update(txt_clientName.Text, txt_Mobil.Text, txt_whats.Text, int.Parse(cb_area.SelectedValue.ToString()), int.Parse(cb_cat.SelectedValue.ToString()), int.Parse(cmb_ads.SelectedValue.ToString()), int.Parse(cb_branches.SelectedValue.ToString()), int.Parse(btn_save.Tag.ToString()));
               
                if (groupBox2.Tag == null)
                {
                    clientCar.Insert((int)id, int.Parse(cb_model.SelectedValue.ToString()), txt_car_No.Text, int.Parse(cb_colors.SelectedValue.ToString()), txt_Km.Text);
                }
                else 
                {
                clientCar.Update((int)id, int.Parse(cb_model.SelectedValue.ToString()), txt_car_No.Text, int.Parse(cb_colors.SelectedValue.ToString()), txt_Km.Text,int.Parse(groupBox2.Tag.ToString()));
                }
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = clientCar.SelectAllByCar((int)id);
                btn_save.Enabled = false;
            }

        }

        private void txt_clientName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        if(id!=null)
        {
                if (groupBox2.Tag == null)
                {
                    clientCar.Insert((int)id, int.Parse(cb_model.SelectedValue.ToString()), txt_car_No.Text, int.Parse(cb_colors.SelectedValue.ToString()), txt_Km.Text);
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = clientCar.SelectAllByCar((int)id);
                }
               
                else
                {
                    clientCar.Update((int)id, int.Parse(cb_model.SelectedValue.ToString()), txt_car_No.Text, int.Parse(cb_colors.SelectedValue.ToString()), txt_Km.Text, int.Parse(groupBox2.Tag.ToString()));
                }
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = clientCar.SelectAllByCar((int)id);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            int id = int.Parse(dataGridView1.Rows[index].Cells["Column4"].Value.ToString());
            if (e.ColumnIndex==6)
            {
                List < usp_SelectAllClient_CarsByID_Result > items= clientCar.SelectAll(id);
                txt_car_No.Text = items[0].CarNo;
                txt_Km.Text = items[0].KM;
                cb_CarBrand.SelectedValue =(int) model.SelectAll((int)items[0].CarID)[0].BrandID;
                cb_model.SelectedValue = (int)items[0].CarID;
                cb_colors.SelectedValue = (int)items[0].ColorID;
            }
           
            else if (e.ColumnIndex == 7)
            {
                clientCar.Delete(id);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = clientCar.SelectAllByCar((int)id);
            }
        }
    }
}
