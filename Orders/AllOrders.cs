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
    public partial class AllOrders : Form
    {
        public AllOrders()
        {
            InitializeComponent();
            Fill();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = clientClass.SelectAllWithCarsData();

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
        ClientClass clientClass = new ClientClass();
        private void Fill()
        {
            
            #region  branches
            cb_branches.DataSource = branch.SelectAll();
            cb_branches.DisplayMember = "BranchName";
            cb_branches.ValueMember = "ID";
            cb_branches.SelectedIndex = -1;
            #endregion

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

       

       

       

        private void cb_colors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clients.Clients clients = new Clients.Clients();
            clients.Show();
        }

        private void txt_clientName_TextChanged(object sender, EventArgs e)
        {
            // 
            if (txt_clientName.Text != "")
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = clientClass.SearchByName(txt_clientName.Text);
            }


        }

        private void txt_Mobil_TextChanged(object sender, EventArgs e)
        {
            if (txt_Mobil.Text != "")
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = clientClass.SearchByMobil(txt_Mobil.Text);
            }
        }

        private void cb_branches_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        try{
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = clientClass.SearchByBranch(int.Parse(cb_branches.SelectedValue.ToString()));
            }
        catch{ }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            int id = int.Parse(dataGridView1.Rows[index].Cells["ID"].Value.ToString());
            if(e.ColumnIndex ==11)
            {
                NewOrder order = new NewOrder(id);
                order.Show(this);
            }
            else if (e.ColumnIndex ==12)
            {

            }
        }
    }
}
