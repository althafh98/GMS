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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection SqlCon = new SqlConnection(@"Data Source=DESKTOP-N8DRI7J;Initial Catalog=Database;Integrated Security=True");
            String query ="Select * from tbl_User Where Username = '" +txtUsername.Text.Trim() + "' and Password = '" +txtPassword.Text.Trim()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query,SqlCon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                frmMainMenu objfrmMainMenu = new frmMainMenu();
                this.Hide();
                objfrmMainMenu.Show();

           /* String Username = txtUsername.Text;
            String Password = txtPassword.Text;

            if (Username == "Admin" && Password == "admin")
            {

                MessageBox.Show("Login Successfully", "Success");

                frmMainMenu objfrmMainMenu = new frmMainMenu();
                this.Hide();
                objfrmMainMenu.Show();*/

            }
        
            else
            {
                MessageBox.Show("Check your Username or Password" , "Invalid");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabelReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmUserRegistration objfrmUserRegistration = new frmUserRegistration();
            objfrmUserRegistration.Show();
        }
    }
}
