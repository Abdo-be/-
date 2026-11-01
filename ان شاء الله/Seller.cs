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
    public partial class Seller : Form
    {
        public Seller()
        {
            InitializeComponent();
            showni();
        }
        SqlConnection ctn = new SqlConnection(@"Data Source=DESKTOP-F74G727\SQLEXPRESS;Initial Catalog=PharmacyManagement;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard ft = new Dashboard();
            ft.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
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

        private void label8_Click(object sender, EventArgs e)
        {
            Medcines ft = new Medcines ();
            ft.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
            Customers ft = new Customers();
            ft.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Customers ft = new Customers();
            ft.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Manufacturer ft = new Manufacturer();
            ft.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Manufacturer ft = new Manufacturer();
            ft.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("étes-vous sure de quitter le programme!", "Sortie...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void showni()
        {
            ctn.Open();
            string query = "select *from seller";
            SqlDataAdapter da = new SqlDataAdapter(query, ctn);
            SqlCommandBuilder bldr = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            ctn.Close();
            
        }
        private void reset()
        {
            guna2TextBox1.Text = "";
            guna2TextBox3.Text = "";
            guna2TextBox2.Text = "";
            comboBoxsellerGen.SelectedIndex = 0;
            guna2TextBox4.Text = "";
            guna2DateTimePicker1.Value = DateTime.Now.Date;
            
            key = 0;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox3.Text == "" || guna2TextBox4.Text == "" || guna2TextBox2.Text == "" || comboBoxsellerGen.SelectedIndex == -1)
            {
                MessageBox.Show("il doit saisir tout les information");
            }
            else
            {
                try
                {
                    DialogResult res = MessageBox.Show("voulez-vous vraiment Ajouter cette ligne", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.OK)
                    {
                        ctn.Open();
                        SqlCommand cmd = new SqlCommand("insert into seller(sellerName,sellergender,Sphone,Sadress,Spasswords,SdateBS) values(@sn,@sg,@sp,@sadr,@spass,@sdat) ", ctn);
                        cmd.Parameters.AddWithValue("@sn", guna2TextBox1.Text);
                        cmd.Parameters.AddWithValue("@sg", comboBoxsellerGen.SelectedItem);
                        cmd.Parameters.AddWithValue("@sP", guna2TextBox4.Text);
                        cmd.Parameters.AddWithValue("@sadr",guna2TextBox2.Text);
                        cmd.Parameters.AddWithValue("@spass", guna2TextBox3.Text);
                        cmd.Parameters.AddWithValue("@sdat", guna2DateTimePicker1.Value.Date);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("l'ajout avec succées!");
                        ctn.Close();
                        showni();
                        reset();
                    }
                    else
                    {
                        MessageBox.Show("L'ajout sera ignorés");
                        reset();
                    }



                    }
                catch(Exception ex)
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
            if (key == 0)
            {
                MessageBox.Show("Select the seller");
            }
            else
            {
                try
                {
                    DialogResult res = MessageBox.Show("voulez-vous vraiment supprimer cette ligne", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.OK)
                    {
                        ctn.Open();
                        SqlCommand cmd = new SqlCommand("delete from seller where sellerNum=@skey", ctn);
                        cmd.Parameters.AddWithValue("@skey", key);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("La suppression avec succées");
                        ctn.Close();
                        showni();
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
            if (guna2TextBox1.Text == "" || guna2TextBox3.Text == "" || guna2TextBox2.Text == ""|| guna2TextBox4.Text==""|| comboBoxsellerGen.SelectedIndex==-1)
            {
                MessageBox.Show("il doit saisir tout les information");
            }
            else
            {
                try
                {
                    DialogResult res = MessageBox.Show("voulez-vous vraiment Modifier cette ligne", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.OK)
                    {
                        ctn.Open();
                    SqlCommand cmd = new SqlCommand("update seller set sellerName=@sn,sellergender=@sg,Sphone=@sp,Sadress=@sadr,Spasswords=@spass,SdateBS=@sdat where sellerNum=@skey ", ctn);
                    cmd.Parameters.AddWithValue("@sn", guna2TextBox1.Text);
                    cmd.Parameters.AddWithValue("@sg", comboBoxsellerGen.SelectedItem);
                    cmd.Parameters.AddWithValue("@sP", guna2TextBox4.Text);
                    cmd.Parameters.AddWithValue("@sadr", guna2TextBox2.Text);
                    cmd.Parameters.AddWithValue("@spass", guna2TextBox3.Text);
                    cmd.Parameters.AddWithValue("@sdat",guna2DateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@skey", key);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("la Modification avec succées");
                    ctn.Close();
                    showni();
                    reset();
                    }
                    else
                    {
                        MessageBox.Show("la modification sera ignorés");
                        reset();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void label18_Click(object sender, EventArgs e)
        {
            window fd = new window();
            fd.Show();
            this.Hide();
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBoxsellerGen.SelectedItem = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            guna2TextBox3.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            guna2TextBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            guna2TextBox4.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();

            guna2DateTimePicker1.Text = guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            if (guna2TextBox1.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Seller_Load(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
