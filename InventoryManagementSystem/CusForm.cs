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
    public partial class CusForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\dbMSS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public CusForm()
        {
            InitializeComponent();
            LoadCus();
        }

        public void LoadCus()
        {
            int i = 0;
            dgvCus.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbCus", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCus.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            con.Close();
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            CusModuleForm moduleForm = new CusModuleForm();
            moduleForm.btnsave.Enabled = true;
            moduleForm.btnupdate.Enabled = false;
            moduleForm.ShowDialog();
            LoadCus();

        }

        private void dgvCus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCus.Columns[e.ColumnIndex].Name;
            if (colName == "Edittt")
            {
                CusModuleForm cusModule = new CusModuleForm();
                cusModule.cusid.Text = dgvCus.Rows[e.RowIndex].Cells[1].Value.ToString();
                cusModule.txtcName.Text = dgvCus.Rows[e.RowIndex].Cells[2].Value.ToString();
                cusModule.txtcPhone.Text = dgvCus.Rows[e.RowIndex].Cells[3].Value.ToString();
             

                cusModule.btnsave.Enabled = false;
                cusModule.btnupdate.Enabled = true;
                cusModule.ShowDialog();


            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this user?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbCus WHERE cid LIKE '" + dgvCus.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfully deleted!");
                }

            }
            LoadCus();
        }

        private void customerButton1_Click(object sender, EventArgs e)
        {
            var newform = new MainForm();
            this.Hide();
        }
    }
}
