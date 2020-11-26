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
    public partial class frmSupplier : Form
    {
        public frmSupplier()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N8DRI7J;Initial Catalog=Database;Integrated Security=True");


        private void frmSupplier_Load(object sender, EventArgs e)
        {
            display_data(); //Display the Database into the DataDridView
        }

        public void display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from [tbl_Supplier]";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridViewSupplier.DataSource = dt;

            con.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                String SupplierName = txtName.Text;
                String CompanyName = txtCname.Text;
                String Email = txtEmail.Text;
                int Contact = int.Parse(txtContact.Text);
                String Address = txtAddress.Text;

                String query_insert = "insert into tbl_Supplier values('" + SupplierName + "' ,'" + CompanyName + "' , '" + Email + "' , '" + Contact + "' , '" + Address + "')"; // SQL Query 
                SqlCommand cmd = new SqlCommand(query_insert, con); //SQL Command
                con.Open(); // Open the Connection
                cmd.ExecuteNonQuery(); //Execute the Connection 
                MessageBox.Show("Successfully Saved!", "Saved");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error While Saving" +ex);
            }

            finally
            {
                con.Close(); //Close the Connection
                display_data();

                txtName.Clear();
                txtCname.Clear();
                txtEmail.Clear();
                txtContact.Clear();
                txtAddress.Clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                String SupplierName = txtName.Text;
                String CompanyName = txtCname.Text;
                String Email = txtEmail.Text;
                int Contact = int.Parse(txtContact.Text);
                String Address = txtAddress.Text;

                String UpdateSql = "update tbl_Supplier set Supplier Name ='" + SupplierName + "' , Company Name = '" + CompanyName + "' Email ='" + Email + "' , Contact ='" + Contact + "' , Address = '" + Address + "' Where Supplier Name= '" + SupplierName + "'";  //SQL Query
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
                txtCname.Clear();
                txtEmail.Clear();
                txtContact.Clear();
                txtAddress.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                String SupplierName = txtName.Text;
                /*String CompanyName = txtCname.Text;
                String Email = txtEmail.Text;
                int Contact = int.Parse(txtContact.Text);
                String Address = txtAddress.Text;
                */

                String Deletesql = "Delete from tbl_Supplier where Supplier Name='" + SupplierName + "'";
                SqlCommand cmd = new SqlCommand(Deletesql, con); // SQL Command
                con.Open(); //Open the Connection
                cmd.ExecuteNonQuery(); //Execute the Connection
                MessageBox.Show("Successfully Deleted!", "Deleted");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error While Deleting" + ex);
            }

            finally
            {
                con.Close(); //Close the Connection
                display_data();

                txtName.Clear();
                txtCname.Clear();
                txtEmail.Clear();
                txtContact.Clear();
                txtAddress.Clear();
            }
        }

        private void dataGridViewSupplier_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            txtName.Text = dataGridViewSupplier.Rows[rowIndex].Cells[1].Value.ToString();
            txtCname.Text = dataGridViewSupplier.Rows[rowIndex].Cells[2].Value.ToString();
            txtContact.Text = dataGridViewSupplier.Rows[rowIndex].Cells[3].Value.ToString();
            txtEmail.Text = dataGridViewSupplier.Rows[rowIndex].Cells[4].Value.ToString();
            txtAddress.Text = dataGridViewSupplier.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMainMenu objfrmMainMenu = new frmMainMenu();
            this.Hide();
            objfrmMainMenu.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tbl_Supplier Where SupplierName = '" + txtSearch.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridViewSupplier.DataSource = dt;

            con.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            display_data();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStock objfrmStock = new frmStock();
            this.Hide();
            objfrmStock.Show();
        }
    }
}
