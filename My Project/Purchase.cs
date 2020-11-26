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
    public partial class frmPurchase : Form
    {
        public frmPurchase()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N8DRI7J;Initial Catalog=Database;Integrated Security=True");

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            if (con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            Display_data();
            Product_type();
            unit();
            Dealer_name();
        }

        public void Display_data()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_Purchase";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridViewPurchase.DataSource = dt;
        }

        public void Product_type()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tbl_ProductType";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {

                cBoxProductType.Items.Add(dr["ProductType"].ToString());
            }

        }
        public void unit()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tbl_Unit";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                cBoxUnit.Items.Add(dr["UnitType"].ToString());
            }

        }

        public void Dealer_name()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tbl_Supplier";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                cBoxSupplier.Items.Add(dr["SupplierName"].ToString());
            }

        }
        private void txtPrice_Leave(object sender, EventArgs e)
        {
            txtTotal.Text = Convert.ToString(Convert.ToInt32(txtQuantity.Text) * Convert.ToInt32(txtPrice.Text));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int i;

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandText = "Select * from tbl_Stock where ProductName = '" + txtProductName.Text + "' ";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            sda1.Fill(dt1);
            i = Convert.ToInt32(dt1.Rows.Count.ToString());

            if (i==0)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into tbl_Purchase values('" + cBoxProductType.Text + "' , '" + txtProductName.Text + "' , '" + cBoxUnit.Text + "' , '" + txtQuantity.Text + "' , '" + txtPrice.Text + "' , '" + txtTotal.Text + "' , '" + dateTimePickerArrival.Value.ToString("dd-MM-yyyy") + "' , '" + cBoxSupplier.Text + "' , '" + dateTimePickerExpiry.Value.ToString("dd-MM-yyyy") + "' )";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Saved!", "Record Saved");

                SqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "insert into tbl_Stock values('" + txtProductName.Text + "' , '" + txtQuantity.Text + "' , '" + cBoxUnit.Text + "' )";
                cmd3.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "insert into tbl_Purchase values('" + cBoxProductType.Text + "' , '" + txtProductName.Text + "' , '" + cBoxUnit.Text + "' , '" + txtQuantity.Text + "' , '" + txtPrice.Text + "' , '" + txtTotal.Text + "' , '" + dateTimePickerArrival.Value.ToString("dd-MM-yyyy") + "' , '" + cBoxSupplier.Text + "' , '" + dateTimePickerExpiry.Value.ToString("dd-MM-yyyy") + "' )";
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Successfully Saved!", "Record Saved");

                SqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "update tbl_Stock set ProductQuantity = ProductQuantity + '" + txtQuantity.Text + "' where ProductName = '" + txtProductName.Text + "' ";
                cmd4.ExecuteNonQuery();


            }

            Display_data();
            cBoxProductType.Text = String.Empty;
            txtProductName.Clear();
            cBoxUnit.Text = String.Empty;
            txtQuantity.Clear();
            txtPrice.Clear();
            txtTotal.Clear();
            cBoxSupplier.Text = String.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String ProductName = txtProductName.Text;

            String Deletesql = "Delete from tbl_Purchase where ProductName='" + ProductName + "'";
            SqlCommand cmd = new SqlCommand(Deletesql, con); // SQL Command
            cmd.ExecuteNonQuery(); //Execute the Connection

            String Deletesql1 = "Delete from tbl_Stock where ProductName='" + ProductName + "'";
            SqlCommand cmd1 = new SqlCommand(Deletesql1, con); // SQL Command
            cmd1.ExecuteNonQuery(); //Execute the Connection
            MessageBox.Show("Successfully Deleted!", "Deleted");

            Display_data();
            cBoxProductType.Text = String.Empty;
            txtProductName.Clear();
            cBoxUnit.Text = String.Empty;
            txtQuantity.Clear();
            txtPrice.Clear();
            txtTotal.Clear();
            dateTimePickerArrival.Text = String.Empty;
            cBoxSupplier.Text = String.Empty;
            dateTimePickerExpiry.Text = String.Empty;
        }

        private void dataGridViewPurchase_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            cBoxProductType.Text = dataGridViewPurchase.Rows[rowIndex].Cells[1].Value.ToString();
            txtProductName.Text = dataGridViewPurchase.Rows[rowIndex].Cells[2].Value.ToString();
            cBoxUnit.Text = dataGridViewPurchase.Rows[rowIndex].Cells[3].Value.ToString();
            txtQuantity.Text = dataGridViewPurchase.Rows[rowIndex].Cells[4].Value.ToString();
            txtPrice.Text = dataGridViewPurchase.Rows[rowIndex].Cells[5].Value.ToString();
            txtTotal.Text = dataGridViewPurchase.Rows[rowIndex].Cells[6].Value.ToString();
            //dateTimePickerArrival.Text = dataGridViewPurchase.Rows[rowIndex].Cells[7].Value.ToString();
            cBoxSupplier.Text = dataGridViewPurchase.Rows[rowIndex].Cells[8].Value.ToString();
            //dateTimePickerExpiry.Text = dataGridViewPurchase.Rows[rowIndex].Cells[9].Value.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
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
