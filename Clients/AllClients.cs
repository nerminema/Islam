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

namespace ELK_POWER.Clients
{
    public partial class AllClients : Form
    {
        ClientClass clientClass = new ClientClass();
        public AllClients()
        {
            InitializeComponent();
            Fill();
            dataGridView1.AutoGenerateColumns = false;
           dataGridView1.DataSource=clientClass.SelectAll();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            int id = int.Parse(dataGridView1.Rows[index].Cells["ID"].Value.ToString());
            if (e.ColumnIndex == 6)
            {
           
                Clients c = new Clients(id);
                c.Show(this);
            }
            else if (e.ColumnIndex==7)
            {
                clientClass.Delete(id);

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = clientClass.SelectAll();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txt_name.Text != "")
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = clientClass.SearchByName(txt_name.Text);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (txt_code.Text != "")
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = clientClass.SearchByID(int.Parse(txt_code.Text));
            }
        }

        private void cmb_ads_SelectedIndexChanged(object sender, EventArgs e)
        {
        try
        {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = clientClass.SearchByHowID(int.Parse(cmb_ads.SelectedValue.ToString()));
            }
        catch
        {

        }

        }

        private void cb_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cb_area.DataSource = area.SelectAllByCity(int.Parse(cb_City.SelectedValue.ToString()));
                cb_area.DisplayMember = "AreaName";
                cb_area.ValueMember = "ID";
                cb_area.SelectedIndex = -1;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = clientClass.SearchByCity(int.Parse(cb_City.SelectedValue.ToString()));
            }
            catch
            {

            }
        }

        private void cb_area_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = clientClass.SearchByArea(int.Parse(cb_area.SelectedValue.ToString()));
            }
            catch
            {

            }
        }

        private void cb_branches_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = clientClass.SearchByBranch(int.Parse(cb_branches.SelectedValue.ToString()));
            }
            catch
            {

            }
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
            
            #endregion
            #region client Category 
            // ComboBox cb_CarBrand = this.Owner.Controls.Find("cb_cat", true).First() as ComboBox;
            cb_cat.DataSource = cat.SelectAll();
            cb_cat.DisplayMember = "Client_Category";
            cb_cat.ValueMember = "ID";
            cb_cat.SelectedIndex = -1;

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

        private void cb_cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = clientClass.SearchBycat(int.Parse(cb_cat.SelectedValue.ToString()));
            }
            catch
            {

            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Clients c = new Clients();
            c.Show();
        }
    }
}
