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
    public partial class window : Form
    {
        public window()
        {
            InitializeComponent();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             Form1 log = new Form1();
            log.Show();
            this.Hide();
        }
        private void label1_Click(object sender, EventArgs e)
        {
      
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form6 dr = new Form6();
            dr.Show();
            this.Hide();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if ( label1.Left<800 )
            {
                label1.Left += 10;
                
            }
            else
            {
                label1.Left = 1;
            

            }
        }

        private void window_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            log.Show();
            this.Hide();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Form6 log = new Form6();
            log.Show();
            this.Hide();
        }
    }
}
