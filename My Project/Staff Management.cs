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
    public partial class frmStaffManagement : Form
    {
        public frmStaffManagement()
        {   
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N8DRI7J;Initial Catalog=Database;Integrated Security=True"); // DB Connection String
        
        private void frmStaffManagement_Load(object sender, EventArgs e)
        {
            display_data(); //Display the DB Table into the DataGridView 
        }
        public void display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_Staff";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridViewStaff.DataSource = dt;


            con.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                String Name = txtName.Text;
                String Email = txtEmail.Text;
                int Mobile = int.Parse(txtMobile.Text);
                String Address = txtAddress.Text;
                int Age = int.Parse(txtAge.Text);
                String Gender;
                if (radioMale.Checked)
                {
                    Gender = "Male";
                }
                else
                {
                    Gender = "Female";
                }
                int Salary = int.Parse(txtSalary.Text);

                String query_insert = "insert into tbl_Staff values('" + Name + "' , '" + Email + "' , '" + Mobile + "' , '" + Address + "' , '" + Age + "' , '" + Gender + "' , '" + Salary + "')"; //SQL Query
                SqlCommand cmd = new SqlCommand(query_insert, con); // SQL Command
                con.Open(); //Open the Connection
                cmd.ExecuteNonQuery(); //Execute the Connection
                MessageBox.Show("Successfully Saved!", "Saved");

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error while Saving" + ex);
            }

            finally
            {
                con.Close(); //Close the Connection
                display_data();

                txtName.Clear();
                txtEmail.Clear();
                txtMobile.Clear();
                txtAddress.Clear();
                txtAge.Clear();
                radioMale.Checked = false;
                radioFemale.Checked = false;
                txtSalary.Clear();
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {

                String Name = txtName.Text;
                String Email = txtEmail.Text;
                String Mobile = txtMobile.Text;
                String Address = txtAddress.Text;
                int Age = int.Parse(txtAge.Text);
                String Gender;
                if (radioMale.Checked)
                {
                    Gender = "Male";
                }
                else
                {
                    Gender = "Female";
                }
                int Salary = int.Parse(txtSalary.Text);

                String UpdateSql = "update tbl_Staff set Name = '" + Name + "' , Email ='" + Email + "' , Mobile ='" + Mobile + "' , Address ='" + Address + "' , Age ='" + Age + "' , Gender= '" + Gender + "' , Salary ='" + Salary + "' Where Name= '" + Name + "'";  //SQL Query
                SqlCommand cmd = new SqlCommand(UpdateSql, con); // SQL Command
                con.Open(); //Open the Connection
                cmd.ExecuteNonQuery(); //Execute the Connection
                MessageBox.Show("Successfully Updated!", "Updated");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while Updating" + ex);
            }
            finally
            {
                con.Close(); //Close the Connection
                display_data();

                txtName.Clear();
                txtEmail.Clear();
                txtMobile.Clear();
                txtAddress.Clear();
                txtAge.Clear();
                radioMale.Checked = false;
                radioFemale.Checked = false;
                txtSalary.Clear();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                String Name = txtName.Text;
                /* String Email = txtEmail.Text;
                 String Mobile = txtMobile.Text;
                 String Address = txtAddress.Text;
                 int Age = int.Parse(txtAge.Text);
                 String Gender;
                 if (radioMale.Checked)
                 {
                     Gender = "Male";
                 }
                 else
                 {
                     Gender = "Female";
                 }
                 int Salary = int.Parse(txtSalary.Text); */

                String Deletesql = "Delete from tbl_Staff where Name='" + Name + "'";
                SqlCommand cmd = new SqlCommand(Deletesql, con); // SQL Command
                con.Open(); //Open the Connection
                cmd.ExecuteNonQuery(); //Execute the Connection
                MessageBox.Show("Successfully Deleted!", "Deleted");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while Deleting" + ex);
            }
            finally
            {
                con.Close(); //Close the Connection
                display_data();

                txtName.Clear();
                txtEmail.Clear();
                txtMobile.Clear();
                txtAddress.Clear();
                txtAge.Clear();
                radioMale.Checked = false;
                radioFemale.Checked = false;
                txtSalary.Clear();
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tbl_Staff Where Name = '" + txtSearch.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridViewStaff.DataSource = dt;

            con.Close();
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            txtSearch.Clear();
            display_data();
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

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStock objfrmStock = new frmStock();
            this.Hide();
            objfrmStock.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchase objfrmPurchaseManagement = new frmPurchase();
            this.Hide();
            objfrmPurchaseManagement.Show();

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Software Developed by Althaf Husain for his Acadamic (SLIATE) Individual Project");
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Contact our Service Team through Email and Mobile althafhusain1998@gmail.com / +94 77 383 2913");
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer objfrmCustomer = new frmCustomer();
            this.Hide();
            objfrmCustomer.Show();

        }

        private void dataGridViewStaff_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            txtName.Text = dataGridViewStaff.Rows[rowIndex].Cells[1].Value.ToString();
            txtEmail.Text = dataGridViewStaff.Rows[rowIndex].Cells[2].Value.ToString();
            txtMobile.Text = dataGridViewStaff.Rows[rowIndex].Cells[3].Value.ToString();
            txtAddress.Text= dataGridViewStaff.Rows[rowIndex].Cells[4].Value.ToString();
            txtAge.Text = dataGridViewStaff.Rows[rowIndex].Cells[5].Value.ToString();
            //radioMale.Checked = dataGridViewStaff.Rows[rowIndex].Cells[1].Value.ToString();
            txtSalary.Text = dataGridViewStaff.Rows[rowIndex].Cells[7].Value.ToString();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmManagement objfrmManagement = new frmManagement();
            this.Hide();
            objfrmManagement.Show();
        }
    }
} 

