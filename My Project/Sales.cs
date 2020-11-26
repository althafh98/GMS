using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace My_Project
{
    public partial class frmSales : Form
    {
        int order = 1;
        double total = 0;
        public frmSales()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N8DRI7J;Initial Catalog=Database;Integrated Security=True");

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductName.Text) && !string.IsNullOrEmpty(txtPrice.Text))
            {
                Receipt obj = new Receipt() { Id = order++, ProductName = txtProductName.Text, Price = Convert.ToDouble(txtPrice.Text), Quantity = Convert.ToInt32(txtQuantity.Text) };
                total += obj.Price * obj.Quantity;
                receiptBindingSource.Add(obj);
                receiptBindingSource.MoveLast();
                txtProductName.Text = string.Empty;
                txtPrice.Text = string.Empty;
                txtTotal.Text = string.Format("Rs.{0:0.00}", total);
            }

            txtQuantity.Clear();
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            receiptBindingSource.DataSource = new List<Receipt>();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Receipt obj = receiptBindingSource.Current as Receipt;
            if(obj!= null)
            {
                total = obj.Price * obj.Quantity;
                txtTotal.Text = string.Format("Rs.{0:0.00}", total);
            }
            receiptBindingSource.RemoveCurrent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (frmPrint frm = new frmPrint(receiptBindingSource.DataSource as List<Receipt>, string.Format("Rs.{0:0.00}", total), string.Format("Rs.{0}.00", txtCash.Text), string.Format("Rs.{0:0.00}", Convert.ToDouble(txtCash.Text) - total), DateTime.Now.ToString("dd/MM/yyyy")))
            {
                frm.ShowDialog();
            }
            txtTotal.Clear();
            txtCash.Clear();
                                  
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

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer objfrmCustomer = new frmCustomer();
            this.Hide();
            objfrmCustomer.Show();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStock objfrmStock = new frmStock();
            this.Hide();
            objfrmStock.Show();
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSales objfrmSales = new frmSales();
            this.Hide();
            objfrmSales.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMainMenu objfrmMainMenu = new frmMainMenu();
            this.Hide();
            objfrmMainMenu.Show();
        }
    }
}
