using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
            timer1.Start();
        }
        int startPoint = 0;
        int endPoint = 6000;


        private void timer1_Tick(object sender, EventArgs e)
        {
            startPoint += 0;
            if(endPoint == 6000)

            
          


            {
              
                timer1.Stop();
                LoginForm login = new LoginForm();
                this.Hide();
                 login.ShowDialog();
            }


        }

        
    }
}
