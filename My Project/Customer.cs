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
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N8DRI7J;Initial Catalog=Database;Integrated Security=True");
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            display_data(); //Display the Database into the DataDridView
        }

        public void display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from [tbl_Customer]";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridViewCustomers.DataSource = dt;

            con.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                String Name = txtName.Text;
                String Email = txtEmail.Text;
                int Mobile = int.Parse(txtMobile.Text);
                String Address = txtAddress.Text;
                int Pincode = int.Parse(txtPincode.Text);

                String query_insert = "insert into tbl_Customer values('" + Name + "' , '" + Email + "' , '" + Mobile + "' , '" + Address + "' , '" + Pincode + "')"; // SQL Query 
                SqlCommand cmd = new SqlCommand(query_insert, con); //SQL Command
                con.Open(); // Open the Connection
                cmd.ExecuteNonQuery(); //Execute the Connection 
                MessageBox.Show("Successfully Saved!", "Saved");

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error While Saving" + ex);
            }

            finally
            {
                con.Close(); //Close the Connection
                display_data();

                txtName.Clear();
                txtEmail.Clear();
                txtMobile.Clear();
                txtAddress.Clear();
                txtPincode.Clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                String Name = txtName.Text;
                String Email = txtEmail.Text;
                int Mobile = int.Parse(txtMobile.Text);
                String Address = txtAddress.Text;
                int Pincode = int.Parse(txtPincode.Text);

                String UpdateSql = "update tbl_Customer set Name ='" + Name + "' , Email ='" + Email + "' , Mobile ='" + Mobile + "' , Address = '" + Address + "' , Pincode = '" + Pincode + "' Where Name= '" + Name + "'";  //SQL Query
                SqlCommand cmd = new SqlCommand(UpdateSql, con); //SQL Command
                con.Open(); //Open the Connection
                cmd.ExecuteNonQuery(); //Execute the Connection
                MessageBox.Show("Successfully Updated!", "Updated");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error While Updating" + ex);
            }

            finally
            {
                con.Close(); //Close the Connection
                display_data();

                txtName.Clear();
                txtEmail.Clear();
                txtMobile.Clear();
                txtAddress.Clear();
                txtPincode.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                String Name = txtName.Text;
                /*  String Email = txtEmail.Text;
                    int Mobile = int.Parse(txtMobile.Text);
                    String Address = txtAddress.Text;
                    int Pincode = int.Parse(txtPincode.Text); */

                String Deletesql = "Delete from tbl_Customer where Name='" + Name + "'";
                SqlCommand cmd = new SqlCommand(Deletesql, con); // SQL Command
                con.Open(); //Open the Connection
                cmd.ExecuteNonQuery(); //Execute the Connection
                MessageBox.Show("Successfully Deleted!", "Deleted");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error While Saving" + ex);
            }

            finally
            {
                con.Close(); //Close the Connection
                display_data();

                txtName.Clear();
                txtEmail.Clear();
                txtMobile.Clear();
                txtAddress.Clear();
                txtPincode.Clear();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tbl_Customer Where Name = '" + txtSearch.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridViewCustomers.DataSource = dt;

            con.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            display_data();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMainMenu objfrmMainMenu = new frmMainMenu();
            this.Hide();
            objfrmMainMenu.Show();
        }

        private void dataGridViewCustomers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            txtName.Text = dataGridViewCustomers.Rows[rowIndex].Cells[1].Value.ToString();
            txtEmail.Text = dataGridViewCustomers.Rows[rowIndex].Cells[2].Value.ToString();
            txtMobile.Text = dataGridViewCustomers.Rows[rowIndex].Cells[3].Value.ToString();
            txtAddress.Text = dataGridViewCustomers.Rows[rowIndex].Cells[4].Value.ToString();
            txtPincode.Text = dataGridViewCustomers.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            frmMainMenu objfrmMainMenu = new frmMainMenu();
            this.Hide();
            objfrmMainMenu.Show();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStock objfrmStock = new frmStock();
            this.Hide();
            objfrmStock.Show();
        }
    }
}
