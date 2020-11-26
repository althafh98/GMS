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
    public partial class frmSalesManagement : Form
    {
        public frmSalesManagement()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N8DRI7J;Initial Catalog=Database;Integrated Security=True");

        DataTable dt = new DataTable();
        int tot = 0;

        public void Product_name()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tbl_Purchase";
            cmd.ExecuteNonQuery();
            DataTable dt0 = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt0);
            foreach (DataRow dr in dt0.Rows)
            {

                cBoxPname.Items.Add(dr["ProductName"].ToString());
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void frmSalesManagement_Load(object sender, EventArgs e)
        {
            if (con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            Product_name();

            dt.Clear();
            dt.Columns.Add("ProductName");
            dt.Columns.Add("Price");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Total");
        }

        private void txtPrice_Enter(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select top 1 * from tbl_Purchase where ProductName = '" + cBoxPname.Text + "' order by id desc";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                txtPrice.Text = dr["Price"].ToString();
            }
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            try
            {
                txtTotal.Text = Convert.ToString(Convert.ToInt32(txtPrice.Text) * Convert.ToInt32(txtQuantity.Text));
            }
            catch (Exception ex)
            {
               
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int stock = 0;

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from tbl_Stock where ProductName = '" + txtName.Text +"' ";
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            sda1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                stock = Convert.ToInt32(dr1["ProductQuantity"].ToString());

                if (Convert.ToInt32(txtQuantity.Text) > stock)
                {
                    MessageBox.Show("This much Quantity not available");
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dr["ProductName"] = txtName.Text;
                    dr["Price"] = txtPrice.Text;
                    dr["Quantity"] = txtQuantity.Text;
                    dr["Total"] = txtTotal.Text;
                    dt.Rows.Add(dr);
                    dataGridViewSales.DataSource = dt;

                    tot = tot + Convert.ToInt32(dr["Total"].ToString());

                    lblAmount.Text = tot.ToString(); 
                }
            }
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
