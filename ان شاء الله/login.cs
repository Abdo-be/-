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

namespace ان_شاء_الله
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("étes-vous sure de quitter la fenétre!", "Sortie...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guna2TextBox2.Clear();
            guna2TextBox1.Clear();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            button1.ForeColor = Color.Red;
        }
        SqlConnection ctn = new SqlConnection(@"Data Source=DESKTOP-F74G727\SQLEXPRESS;Initial Catalog=PharmacyManagement;Integrated Security=True");
        public static string user;
        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (guna2TextBox2.Text == "" || guna2TextBox1.Text == "")
                {
                    MessageBox.Show("il doit remplir tout les champs");
                }
                else
            {

                SqlCommand cmd = new SqlCommand("select * from seller where sellerName in('" + guna2TextBox2.Text.Trim() + "')and Spasswords in('" + guna2TextBox1.Text.Trim() + "');", ctn);
                SqlDataReader dr;
                    ctn.Open();
                    dr = cmd.ExecuteReader();


                    if (dr.Read())
                    {
                        guna2TextBox2.Text  = dr["sellerName"].ToString();
                        guna2TextBox1.Text   = dr["Spasswords"].ToString();
                        adminForm fd = new adminForm();
                        fd.label20.Text =guna2TextBox2.Text;
                        fd.Show();
                        this.Hide();


                    Close();



                    }
                    else
                    {
                        MessageBox.Show("login ou pw non valid veillez réessayez", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        guna2TextBox2.Clear();
                        guna2TextBox1.Clear();


                    }

                    ctn.Close();
                    // ctn.Open();
                    // SqlDataAdapter sda = new SqlDataAdapter("select count(*) from seller where sellerName='" + textBox1.Text + "'Spasswords='" + textBox2.Text + "' ", ctn);
                    // DataTable dt = new DataTable();
                    // sda.Fill(dt);
                    // if (int.Parse(dt.Rows[0][0].ToString()) == 5)
                    // {
                    //     user = textBox1.Text;
                    //     Form2 fd = new Form2();
                    //     fd.Show();
                    //     this.Hide();
                    //     ctn.Close();
                    // }
                    // else
                    //{
                    //     MessageBox.Show("user or pass incorrect!!");
                    //}



                }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    cancelf();
            //}










        }
        private void cancelf()
        {
            guna2TextBox2.Clear();
            guna2TextBox1.Clear();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form6 dr = new Form6();
            dr.Show();
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
