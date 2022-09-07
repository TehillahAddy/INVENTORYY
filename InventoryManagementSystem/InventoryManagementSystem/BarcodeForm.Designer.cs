namespace InventoryManagementSystem
{
    partial class BarcodeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarcodeForm));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.textBoxdisplay = new System.Windows.Forms.TextBox();
            this.buttonscan = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.customerButton1 = new InventoryManagementSystem.CustomerButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Camera";
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(5, 61);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(328, 240);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // textBoxdisplay
            // 
            this.textBoxdisplay.Location = new System.Drawing.Point(5, 332);
            this.textBoxdisplay.Name = "textBoxdisplay";
            this.textBoxdisplay.ReadOnly = true;
            this.textBoxdisplay.Size = new System.Drawing.Size(328, 20);
            this.textBoxdisplay.TabIndex = 2;
            // 
            // buttonscan
            // 
            this.buttonscan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonscan.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonscan.Location = new System.Drawing.Point(118, 358);
            this.buttonscan.Name = "buttonscan";
            this.buttonscan.Size = new System.Drawing.Size(91, 33);
            this.buttonscan.TabIndex = 3;
            this.buttonscan.Text = "Scan";
            this.buttonscan.UseVisualStyleBackColor = true;
            this.buttonscan.Click += new System.EventHandler(this.buttonscan_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(81, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(252, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Display";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // customerButton1
            // 
            this.customerButton1.Image = ((System.Drawing.Image)(resources.GetObject("customerButton1.Image")));
            this.customerButton1.ImageHover = ((System.Drawing.Image)(resources.GetObject("customerButton1.ImageHover")));
            this.customerButton1.ImageNormal = ((System.Drawing.Image)(resources.GetObject("customerButton1.ImageNormal")));
            this.customerButton1.Location = new System.Drawing.Point(5, 367);
            this.customerButton1.Name = "customerButton1";
            this.customerButton1.Size = new System.Drawing.Size(41, 40);
            this.customerButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.customerButton1.TabIndex = 12;
            this.customerButton1.TabStop = false;
            this.customerButton1.Click += new System.EventHandler(this.customerButton1_Click);
            // 
            // BarcodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(359, 410);
            this.Controls.Add(this.customerButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonscan);
            this.Controls.Add(this.textBoxdisplay);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label1);
            this.Name = "BarcodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BarcodeForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BarcodeForm_FormClosing);
            this.Load += new System.EventHandler(this.BarcodeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerButton1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox textBoxdisplay;
        private System.Windows.Forms.Button buttonscan;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private CustomerButton customerButton1;
    }
}