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
    public partial class NewOrder : Form
    {
        OrderStatusClass orders = new OrderStatusClass();
        ClientClass client = new ClientClass();
        BranchesClass branches = new BranchesClass();
        ServicesClass services = new ServicesClass();
        ClientCarClass ClientCarClass = new ClientCarClass();
        public NewOrder()
        {
            InitializeComponent();
            //cb_status1.DataSource = orders.SelectAll();
            //cb_status1.DisplayMember = "StatusOrder";
            //cb_status1.ValueMember = "ID";
            //cb_status1.SelectedIndex = -1;

            cb_Clients.DataSource = client.SelectAll();
            cb_Clients.DisplayMember = "Client_Name";
            cb_Clients.ValueMember = "ID";
            cb_Clients.SelectedIndex = -1;

            cb_branches.DataSource = branches.SelectAll();
            cb_branches.DisplayMember = "BranchName";
            cb_branches.ValueMember = "ID";
            cb_branches.SelectedIndex = -1;

        }
        public NewOrder(int id)
        {
            InitializeComponent();
            //cb_status1.DataSource = orders.SelectAll();
            //cb_status1.DisplayMember = "StatusOrder";
            //cb_status1.ValueMember = "ID";
            //cb_status1.SelectedIndex = -1;

            cb_Clients.DataSource = client.SelectAll();
            cb_Clients.DisplayMember = "Client_Name";
            cb_Clients.ValueMember = "ID";
            cb_Clients.SelectedIndex = -1;

            cb_branches.DataSource = branches.SelectAll();
            cb_branches.DisplayMember = "BranchName";
            cb_branches.ValueMember = "ID";
            cb_branches.SelectedIndex = -1;

            cb_Clients.SelectedValue = id;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource= ClientCarClass.SelectAllByCar(id);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OrderStatus status = new OrderStatus();
            status.Show(this);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (button1.Tag.ToString() == "0")
            {
                orderStatus = 6;
                button1.BackgroundImage = global::ELK_POWER.Properties.Resources.delaypngSelected;
                button1.Tag = 1;
            }
            else
            {
                orderStatus = 0;
                button1.BackgroundImage = Properties.Resources.delaypng;
                button1.Tag = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Tag.ToString() == "0")
            {
                orderStatus = 3;
                button2.BackgroundImage = global::ELK_POWER.Properties.Resources.ActivepngSelected;
                button2.Tag = 1;
            }
            else
            {
                orderStatus = 0;
                button2.BackgroundImage = Properties.Resources.Activepng;
                button2.Tag = 0;
            }
        }
        int orderStatus = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (button3.Tag.ToString() == "0")
            {orderStatus = 1;
                button3.BackgroundImage = global::ELK_POWER.Properties.Resources.ReActiveSelected;
                button3.Tag = 1;
            }
            else
            {
                orderStatus = 0;
                button3.BackgroundImage = Properties.Resources.ReActive;
                button3.Tag = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Tag.ToString() == "0")
            {
                orderStatus = 5;
                button4.BackgroundImage = global::ELK_POWER.Properties.Resources.DoneSelected;
                button4.Tag = 1;
            }
            else
            {
                orderStatus = 0;
                button4.BackgroundImage = Properties.Resources.Done;
                button4.Tag = 0;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Tag.ToString() == "0")
            {
                orderStatus = 2;
                button5.BackgroundImage = global::ELK_POWER.Properties.Resources.PendingSelected;
                button5.Tag = 1;
            }
            else
            {
                orderStatus = 0;
                button5.BackgroundImage = Properties.Resources.Pending;
                button5.Tag = 0;
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NewOrder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aLKPowerDataSet.usp_SelectAllServices' table. You can move, or remove it, as needed.
            this.usp_SelectAllServicesTableAdapter.Fill(this.aLKPowerDataSet.usp_SelectAllServices);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int count = 0;
            if (dataGridView1.Rows[e.RowIndex].Cells[9].Value != null)
                count = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString());
            decimal add = 0;
            if (dataGridView1.Rows[e.RowIndex].Cells["Column11"].Value != null)
                add = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["Column11"].Value.ToString());
            decimal ship = 0;
            if (dataGridView1.Rows[e.RowIndex].Cells["Column10"].Value != null)
                ship = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["Column10"].Value.ToString());
            decimal price = 0;
            if (dataGridView1.Rows[e.RowIndex].Cells["price"].Value != null)
                price = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["price"].Value.ToString());
            if (e.ColumnIndex == 0)
            {
                        if (dataGridView1.Rows[e.RowIndex].Cells[9].Value == null)
                {
                    string serviceID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    List<usp_SelectAllServicesByID_Result> _services = services.SelectAll(int.Parse(serviceID));
                    dataGridView1.Rows[e.RowIndex].Cells["price"].Value = _services[0].ServicesFees.ToString();
                }
                else 
                {
                    string serviceID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    List<usp_SelectAllServicesByID_Result> _services = services.SelectAll(int.Parse(serviceID));
                    dataGridView1.Rows[e.RowIndex].Cells["price"].Value = _services[0].ServicesFees.ToString();
                    //decimal price = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["price"].Value.ToString());
                    //int count = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString());
                    txt_total.Text = ( (price * count) + add + ship).ToString();
                }

            }
            else if (e.ColumnIndex == 9)
            {
                try
                {

                    txt_total.Text = ( (price * count) + add + ship).ToString();
                }
                catch
                { }
            }
            else if (e.ColumnIndex == 10)
            {
                try
                {
                    txt_total.Text = ( (price * count) + add + ship).ToString();
                }
                catch
                { }
            }
            else if (e.ColumnIndex == 11)
            {
                try
                {

                    //dataGridView1.Rows[e.RowIndex].Cells["price"].Value = _services[0].ServicesFees.ToString();
                    txt_total.Text = ( (price * count) + add + ship).ToString();

                }
                catch
                { }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (txt_discount.Text !="")
            {
                if (ch_per.Checked == true)
                {
                    decimal per = (decimal.Parse(txt_discount.Text) / 100) * decimal.Parse(txt_total.Text);
                    txt_total_afterDis.Text = (decimal.Parse(txt_total.Text) - per).ToString();
                }
                else 
                {
                    decimal per = (decimal.Parse(txt_discount.Text));
                    txt_total_afterDis.Text = (decimal.Parse(txt_total.Text) - per).ToString();
                }
            }
        }

        private void ch_per_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_discount.Text != "")
            {
                if (ch_per.Checked == true)
                {
                    decimal per = (decimal.Parse(txt_discount.Text) / 100) * decimal.Parse(txt_total.Text);
                    txt_total_afterDis.Text = (decimal.Parse(txt_total.Text) - per).ToString();
                }
                else
                {
                    decimal per = (decimal.Parse(txt_discount.Text));
                    txt_total_afterDis.Text = (decimal.Parse(txt_total.Text) - per).ToString();
                }
            }
            
        }
        ClientOrdersClass ClientOrders = new ClientOrdersClass();
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (btn_save.Tag == null)
            {
                ClientOrders.InsertNewOrder(int.Parse(cb_Clients.SelectedValue.ToString()), orderStatus, DateTime.Parse(Dt_Date.Value.ToShortDateString()) , int.Parse(cb_branches.SelectedValue.ToString()) , decimal.Parse(txt_total.Text), decimal.Parse(txt_discount.Text) , decimal.Parse(txt_tax.Text ) ,decimal.Parse(txt_Final.Text)  );
            }
            else 
            {
                ClientOrders.UpdateNewOrder(int.Parse(cb_Clients.SelectedValue.ToString()), orderStatus, DateTime.Parse(Dt_Date.Value.ToShortDateString()), int.Parse(cb_branches.SelectedValue.ToString()), decimal.Parse(txt_total.Text), decimal.Parse(txt_discount.Text), decimal.Parse(txt_tax.Text), decimal.Parse(txt_Final.Text), int.Parse(btn_save.Tag.ToString()));
            }
            //DataTable dt = ListtoDataTableConverter.ToDataTable(report.Account(Datein.Value));
            //Utilites.Print("Account", dt);
        }
    }
}
