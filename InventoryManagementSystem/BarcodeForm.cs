using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
using ZXing;

namespace InventoryManagementSystem
{
    public partial class BarcodeForm : Form
    {
        public BarcodeForm()
        {
            InitializeComponent();
        }

        FilterInfoCollection filter;
        VideoCaptureDevice captureDevice;
     
        private void BarcodeForm_Load(object sender, EventArgs e)
        {
            filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filter in filter)
               comboBox1.Items.Add(filter.Name);

            if(comboBox1.Items !=null)
            comboBox1.SelectedIndex = 0;

        }

        


        private void buttonscan_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(filter[comboBox1.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevie_NewFrame;
            captureDevice.Start();
            timer1.Start();
        }

        private void CaptureDevie_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void BarcodeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (captureDevice.IsRunning)
                captureDevice.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                BarcodeReader barcode = new BarcodeReader();
                Result result = barcode.Decode((Bitmap)pictureBox.Image);
                if (result !=null)
                {
                    textBoxdisplay.Text = result.ToString();
                    timer1.Stop();
                    if (captureDevice.IsRunning)
                        captureDevice.Stop();
                }
            }
        }

        private void customerButton1_Click(object sender, EventArgs e)
        {
            var newform = new OrderModuleForm();
            this.Hide();
        }
    }
}
