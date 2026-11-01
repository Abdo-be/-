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
    public partial class Manufacturer : Form
    {
        public Manufacturer()
        {
            InitializeComponent();
            showMan();
        }
        
        SqlConnection ctn = new SqlConnection(@"Data Source=DESKTOP-F74G727\SQLEXPRESS;Initial Catalog=PharmacyManagement;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard ft = new Dashboard();
            ft.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Medcines ft = new Medcines();
            ft.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Customers ft = new Customers();
            ft.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Seller s = new Seller();
            s.Show();
            this.Hide();

        }

        private void label11_Click(object sender, EventArgs e)
        {
            Seller s = new Seller();
            s.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Medcines fg = new Medcines();
            fg.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard fg = new Dashboard();
            fg.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Customers fg = new Customers();
            fg.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("etes-vous sure de quitter le programme!", "Sortie...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void showMan()
        {
            ctn.Open();
            string query = "select *from manufacturer ";
            SqlDataAdapter da = new SqlDataAdapter(query, ctn);
            SqlCommandBuilder bldr = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            ctn.Close();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox3.Text == "" ||  guna2TextBox2.Text == "")
            {
                MessageBox.Show("il doit saisir tout les information");
            }
            else
            {
                try
                {
                    DialogResult res = MessageBox.Show("voulez-vous vraiment ajouter cette ligne", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.OK)
                    {
                        ctn.Open();
                        SqlCommand cmd = new SqlCommand("insert into manufacturer(manName,manAdd,manphone,manDate) values(@mn,@madd,@mph,@mdat) ", ctn);
                        cmd.Parameters.AddWithValue("@mn", guna2TextBox1.Text);
                        cmd.Parameters.AddWithValue("@madd", guna2TextBox2.Text);
                        cmd.Parameters.AddWithValue("@mph", guna2TextBox3.Text);
                        cmd.Parameters.AddWithValue("@mdat", guna2DateTimePicker1.Value.Date);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("L'Ajout avec succées!");
                        ctn.Close();
                        showMan();
                        reset();
                    }
                     else
                    {
                        MessageBox.Show("l'ajout est  ignorés");
                        reset();
                    }
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key==0)
            {
                MessageBox.Show("Select the Manufacturer");
            }
            else
            {
                try
                {
                    DialogResult res = MessageBox.Show("voulez-vous vraiment supprimer cette ligne","Question",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                    if (res == DialogResult.OK)
                    {
                        ctn.Open();
                        SqlCommand cmd = new SqlCommand("delete from manufacturer where manifacturerID=@mkey", ctn);
                        cmd.Parameters.AddWithValue("@mkey", key);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("la suppression avec succées!");
                        ctn.Close();
                        showMan();
                        reset();
                    }
                    else
                    {
                        MessageBox.Show(" la suppression sera ignorés");
                        reset();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void reset()
        {
            guna2TextBox1.Text = "";
            guna2TextBox3.Text = "";
            guna2TextBox2.Text = "";
            guna2DateTimePicker1.Value = DateTime.Now.Date;
            key = 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox3.Text == "" || guna2TextBox2.Text == "")
            {
                MessageBox.Show("il doit saisir tout les information");
            }
            else
            {
                try { 
                  
                    ctn.Open();
                    SqlCommand cmd = new SqlCommand("update  manufacturer set manName= @mn,manAdd=@madd,manphone=@mph,manDate=@mdat where manifacturerID=@mkey ", ctn);
                    cmd.Parameters.AddWithValue("@mn", guna2TextBox1.Text);
                    cmd.Parameters.AddWithValue("@madd", guna2TextBox2.Text);
                    cmd.Parameters.AddWithValue("@mph", guna2TextBox3.Text);
                    cmd.Parameters.AddWithValue("@mdat", guna2DateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@mkey", key);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("la modification avec succées!");
                    ctn.Close();
                    showMan();
                    reset();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        
        private void Manufacturer_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            //textBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            //textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            //dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //if (textBox1.Text == "")
            //{
            //    key = 0;
            //}
            //else
            //{
            //    key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            //}
        }

        private void label15_Click(object sender, EventArgs e)
        {
            window fd = new window();
            fd.Show();
            this.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            panel5.BringToFront();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            guna2TextBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            guna2TextBox3.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            guna2DateTimePicker1.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            if (guna2TextBox1.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
