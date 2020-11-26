using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Project
{
    public partial class frmManagement : Form
    {
        public frmManagement()
        {
            InitializeComponent();
        }
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMainMenu objfrmMainMenu = new frmMainMenu();
            this.Hide();
            objfrmMainMenu.Show();
        }

        private void staffsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStaffManagement objfrmStaffManagement = new frmStaffManagement();
            this.Hide();
            objfrmStaffManagement.Show();
        }

        private void suppliersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSupplier objfrmSupplier = new frmSupplier();
            this.Hide();
            objfrmSupplier.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Contact our Service Team through Email and Mobile althafhusain1998@gmail.com / +94 77 383 2913");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Software Developed by Althaf Husain for his Acadamic (SLIATE) Individual Project");
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSales objfrmSales = new frmSales();
            this.Hide();
            objfrmSales.Show();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStock objfrmStock = new frmStock();
            this.Hide();
            objfrmStock.Show();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer objfrmCustomer = new frmCustomer();
            this.Hide();
            objfrmCustomer.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchase objfrmPurchaseManagement = new frmPurchase();
            this.Hide();
            objfrmPurchaseManagement.Show();
        }
    }
}
