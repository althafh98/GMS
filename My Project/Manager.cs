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
    public partial class frmManager : Form
    {
        public frmManager()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            String Pass = txtPassword.Text;
            if (Pass == "Manager123")
            {
                MessageBox.Show("Login Successfully", "Login Success");
                frmManagement objfrmManagement = new frmManagement();
                this.Hide();
                objfrmManagement.Show();
            }
            else
            {
                MessageBox.Show("Your Password is incorrect", "Invalid Password");
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            frmMainMenu objfrmMainMenu = new frmMainMenu();
            this.Hide();
            objfrmMainMenu.Show();
        }
    }
}
