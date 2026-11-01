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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 ff = new Form1();
            ff.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        
        }
        void cancel()
        {
            textBox1.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
     
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("etes-vous sure de quitter la fenétre!", "Sortie...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            cancel();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "bennani")
            {
                Dashboard dr = new Dashboard();
                dr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("erreur");
                cancel();


            }
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.UseSystemPasswordChar = false;
            }
            else
            {
                textBox1.UseSystemPasswordChar = true;
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
