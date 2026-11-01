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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            showCUS();
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
            Medcines fr = new Medcines();
            fr.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Manufacturer ft = new Manufacturer();
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

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard fg = new Dashboard();
            fg.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Medcines fg = new Medcines();
            fg.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Manufacturer fg = new Manufacturer();
            fg.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("étes-vous sure de quitter la fenétre!", "Sortie...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void showCUS()
        {
            ctn.Open();
            string query = "select *from customer";
            SqlDataAdapter da = new SqlDataAdapter(query, ctn);
            SqlCommandBuilder bldr = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            guna2DataGridView1.DataSource=ds.Tables[0];
            ctn.Close();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox3.Text == "" || guna2TextBox2.Text == ""|| comboGender.SelectedIndex==-1)
            {
                MessageBox.Show("il doit saisir tout les information");
            }
            else
            {
                try
                {
                    DialogResult res = MessageBox.Show("voulez-vous vraiment ajouter cet lign", "confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.OK)
                    {
                        ctn.Open();
                        SqlCommand cmd = new SqlCommand("insert into customer(CustomerName,Custgender,Custadress,Custphone,Custdatabirth) values(@cn,@cg,@cadr,@cp,@cdat) ", ctn);
                        cmd.Parameters.AddWithValue("@cn", guna2TextBox1.Text);
                        cmd.Parameters.AddWithValue("@cg", comboGender.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@cadr", guna2TextBox2.Text);
                        cmd.Parameters.AddWithValue("@cp", guna2TextBox3.Text);
                        cmd.Parameters.AddWithValue("@cdat", guna2DateTimePicker1.Value.Date);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("l'ajout avec sucées!");
                        ctn.Close();
                        showCUS();
                        reset();
                    }
                    else
                    {
                        MessageBox.Show("l'ajout sera ignoré!");
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
        private void reset()
        {
            guna2TextBox1.Text = "";
            guna2TextBox3.Text = "";
            guna2TextBox2.Text = "";
            comboGender.SelectedIndex = 0;
            guna2DateTimePicker1.Value = DateTime.Now.Date;
            key = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the customer");
            }
            else
            {
                try
                {
                    DialogResult res = MessageBox.Show("voulez-vous vraiment supprimer cette ligne", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.OK)
                    {
                        ctn.Open();
                        SqlCommand cmd = new SqlCommand("delete from customer where CustomerNum=@ckey", ctn);
                        cmd.Parameters.AddWithValue("@ckey", key);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("la suppression avec succées!");
                        ctn.Close();
                        showCUS();
                        reset();
                    }
                    else
                    {
                        MessageBox.Show("suppression ignorés");
                        reset();
                    }

              

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox3.Text == "" || guna2TextBox2.Text == ""|| comboGender.SelectedIndex==-1)
            {
                MessageBox.Show("il doit saisir tout les information");
            }
            else
            {
                try
                {
                    ctn.Open();
                    SqlCommand cmd = new SqlCommand("update  customer set CustomerName=@cn, Custgender=@cg,Custadress=@cadr,Custphone=@cp,Custdatabirth=@cdat where CustomerNum=@ckey ", ctn);
                    cmd.Parameters.AddWithValue("@cn", guna2TextBox1.Text);
                    cmd.Parameters.AddWithValue("@cg", comboGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@cadr", guna2TextBox2.Text);
                    cmd.Parameters.AddWithValue("@cp", guna2TextBox3.Text);
                    cmd.Parameters.AddWithValue("@cdat", guna2DateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@ckey", key);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("la modification avec succées!");
                    ctn.Close();
                    showCUS();
                    reset();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {
            window fd = new window();
            fd.Show();
            this.Hide();
        }

        private void Customers_Load(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboGender.SelectedItem = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            guna2TextBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            guna2TextBox3.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            guna2DateTimePicker1.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            if (guna2TextBox1.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
