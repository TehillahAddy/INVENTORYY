using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class OrderModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\dbMSS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        int qty = 0;
        public OrderModuleForm()
        {
            InitializeComponent();
            LoadCus();
            LoadProduct();

        }

        private void btnBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        public void LoadCus()
        {
            int i = 0;
            dgvCus.Rows.Clear();
            cm = new SqlCommand("SELECT cid, cname FROM tbCus WHERE CONCAT(cid,cname) LIKE '%"+txtSearchCust.Text+"%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCus.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();
        }

        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbProduct WHERE CONCAT(pid, pname, pprice, pdescription, pcategory) LIKE '%" + txtSearchProd.Text + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void txtSearchCust_TextChanged(object sender, EventArgs e)
        {
            LoadCus();
        }

        private void txtSearchProd_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

      
     


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            GetQty();
            if (Convert.ToInt16(UDQty.Value) > qty)
            {
                MessageBox.Show("Instock quantity is not enough!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UDQty.Value = UDQty.Value - 1;
                return;
            }
            if (Convert.ToInt16(UDQty.Value) > 0)
            {
                int total = Convert.ToInt16(txtPrice.Text) * Convert.ToInt16(UDQty.Value);
                txtTotal.Text = total.ToString();
            }
        }

        private void dgvCus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCid.Text = dgvCus.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCName.Text = dgvCus.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
            qty = Convert.ToInt16(dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString());
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCid.Text == "")
                {
                    MessageBox.Show("Please select customer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                if (txtPid.Text == "")
                {
                    MessageBox.Show("Please select Product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }



                if (MessageBox.Show("Are you sure you want to insert this order?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbOrder(odate, pid, cid, qty, price, total)VALUES(@odate, @pid, @cid, @qty, @price, @total)", con);
                    cm.Parameters.AddWithValue("@odate", dtOrder.Value);
                    cm.Parameters.AddWithValue("@pid", Convert.ToInt16(txtPid.Text));
                    cm.Parameters.AddWithValue("@cid", Convert.ToInt16(txtCid.Text));
                    cm.Parameters.AddWithValue("@qty", Convert.ToInt16(UDQty.Value));
                    cm.Parameters.AddWithValue("@price", Convert.ToInt16(txtPrice.Text));
                    cm.Parameters.AddWithValue("@total", Convert.ToInt16(txtTotal.Text));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Order has been successfully inserted");
                    

                    cm = new SqlCommand("UPDATE tbProduct SET pqty=(pqty-@pqty) WHERE pid LIKE '" + txtPid.Text + "' ", con);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(UDQty.Value));


                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    Clear();
                    LoadProduct();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void Clear()
        {
            txtCid.Clear();
            txtCName.Clear();

            txtPid.Clear();
            txtPName.Clear();

            txtPrice.Clear();
            UDQty.Value = 0;
            txtTotal.Clear();
            dtOrder.Value = DateTime.Now;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
           




        }

        public void GetQty()
        {
            cm = new SqlCommand("SELECT pqty FROM tbProduct WHERE pid='" + txtPid.Text + "'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                qty = Convert.ToInt32(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newform = new BarcodeForm();
            this.Hide();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("SHOPRITE INVENT. MGMNT. SYSTEM", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Red, new Point(210));
            e.Graphics.DrawString("Product ID:3", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(100,70));
            e.Graphics.DrawString("Customer Name:Cristiano", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(100, 100));
            e.Graphics.DrawString("Date:07/09/2022", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(100, 130));
            e.Graphics.DrawString("Total Amount:5000", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(100, 160));
            e.Graphics.DrawString("CodeSpace", new Font("Century Gothic", 25, FontStyle.Italic), Brushes.Red, new Point(230, 240));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {

                printDocument1.Print();
            }
        }
    }
}
