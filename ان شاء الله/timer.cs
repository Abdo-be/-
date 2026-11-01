using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ان_شاء_الله
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private void progressBar1_Click(object sender, EventArgs e)
        {
           
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int startPoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startPoint += 1;
            guna2VProgressBar1.Value = startPoint;
            label1.Text = startPoint.ToString()+"%";
            if (guna2VProgressBar1.Value == 100)
            {
                timer1.Stop();
                guna2VProgressBar1.Value = 0;
                window login = new window();
                this.Hide();
                login.Show();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
