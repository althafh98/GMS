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
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
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


        private void managerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManager objfrmManager = new frmManager();
            this.Hide();
            objfrmManager.Show();
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStaff objfrmStaff = new frmStaff();
            this.Hide();
            objfrmStaff.Show();
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin objfrmAdmin = new frmLogin();
            this.Hide();
            objfrmAdmin.Show();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You must Login First");
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You must Login First");
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You must Login First");
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
