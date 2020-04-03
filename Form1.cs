using ELK_POWER.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELK_POWER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void أنواعالسياراتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarBrands car = new CarBrands();
            car.Show(this);
        }

        private void موديلاتالسياراتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarModel model = new CarModel();
            model.Show(this);
        }

        private void محافظاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            City model = new City();
            model.Show();
        }

        private void مناطقToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Area area = new Area();
            area.Show();
        }

        private void الفروعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Branches branches = new Branches();
            branches.Show();
        }

        private void إعداداتالإعلانToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void كيفوصلتإليناToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ads branches = new Ads();
            branches.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void قائمةالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clients.AllClients branches = new Clients.AllClients();
            branches.Show();
        }

        private void عميلجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clients.Clients branches = new Clients.Clients();
            branches.Show();
        }

        private void إعداداتالخدماتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Services services = new Services();
            services.Show();
        }
    }
}
