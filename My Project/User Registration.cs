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
    public partial class frmUserRegistration : Form
    {
        public frmUserRegistration()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N8DRI7J;Initial Catalog=Database;Integrated Security=True");

        private void btnRegister_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_User where Username = '" + txtUsername.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into tbl_User values('" + txtFname.Text + "' , '" + txtLname.Text + "' , '" + txtEmail.Text + "' , '" + txtMobile.Text + "' , '" + txtUsername.Text +"' , '" + txtPassword.Text + "' )";
                cmd1.ExecuteNonQuery();

                MessageBox.Show("Registration Success" , "Success");

                txtFname.Clear();
                txtLname.Clear();
                txtEmail.Clear();
                txtMobile.Clear();
                txtUsername.Clear();
                txtPassword.Clear();
            }
            else
            {
                MessageBox.Show("This Username Already Exist" , "Wrong Username");
            }
        }

        private void frmUserRegistration_Load(object sender, EventArgs e)
        {
            if (con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
