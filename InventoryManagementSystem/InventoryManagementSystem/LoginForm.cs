using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
	public partial class LoginForm : Form
	{
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\dbMSS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
		SqlDataReader dr;
        public LoginForm()
		{
			InitializeComponent();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxPass.Checked == false)
				txtpass.UseSystemPasswordChar = true;
			else
				txtpass.UseSystemPasswordChar = false;
		}

		private void IblClear_Click(object sender, EventArgs e)
		{
			txtname.Clear();
			txtpass.Clear();
		}

		private void pictureBoxClose_Click(object sender, EventArgs e)
		{
			 
		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			
			try
			{
                
                    cm = new SqlCommand("SELECT * FROM TbUSer WHERE username=@username AND password=@password", con);
                    cm.Parameters.AddWithValue("@username", txtname.Text);
                    cm.Parameters.AddWithValue("@password", txtpass.Text);
                    con.Open();
                    dr = cm.ExecuteReader();
                    if (dr.Read())

                    {
                        MessageBox.Show("Welcome" +   dr["fullname"].ToString() + " ! ", "ACESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainForm main = new MainForm();
                    this.Hide();
                    main.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
				con.Close();
                

            }
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
            var newForm = new UserModuleForm();
			newForm.Show();
           
        }

		private void button2_Click(object sender, EventArgs e)
		{
            
        }

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			lblValue.Text = comboBox.Text;
		}
	}
}
