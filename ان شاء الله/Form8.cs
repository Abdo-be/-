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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            showMan();
        }
        SqlConnection ctn = new SqlConnection(@"Data Source=DESKTOP-F74G727\SQLEXPRESS;Initial Catalog=PharmacyManagement;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard fd = new Dashboard();
            fd.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard fd = new Dashboard();
            fd.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Form7 fd = new Form7();
            fd.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Form9 fd = new Form9();
            fd.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            sellerAd fd = new sellerAd();
            fd.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form7 fd = new Form7();
            fd.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form9 fd = new Form9();
            fd.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            sellerAd fd = new sellerAd();
            fd.Show();
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

        private void label18_Click(object sender, EventArgs e)
        {
            window fd = new window();
            fd.Show();
            this.Hide();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Dashboard fd = new Dashboard();
            fd.Show();
            this.Hide();
        }
        void afficher()
        {
            if (guna2TextBox1.Text == "" || guna2TextBox3.Text == "" || guna2TextBox2.Text == "")
            {
              //  MessageBox.Show("il doit saisir tout les information");
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

                        MessageBox.Show("added");
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
        private void reset()
        {
            guna2TextBox1.Text = "";
            guna2TextBox3.Text = "";
            guna2TextBox2.Text = "";
            key = 0;
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
        private void Form8_Load(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox3.Text == "" || guna2TextBox2.Text == "")
            {
                //MessageBox.Show("il doit saisir tout les information");
            }
            else
            {
                try
                {
                    ctn.Open();
                    SqlCommand cmd = new SqlCommand("update  manufacturer set manName= @mn,manAdd=@madd,manphone=@mph,manDate=@mdat where manifacturerID=@mkey ", ctn);
                    cmd.Parameters.AddWithValue("@mn", guna2TextBox1.Text);
                    cmd.Parameters.AddWithValue("@madd", guna2TextBox2.Text);
                    cmd.Parameters.AddWithValue("@mph", guna2TextBox3.Text);
                    cmd.Parameters.AddWithValue("@mdat", guna2DateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@mkey", key);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("la modification avec sucées!");
                    ctn.Close();
                    showMan();
                    reset();
                    afficher();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Manufacturer");
            }
            else
            {
                try
                {
                    DialogResult res = MessageBox.Show("voulez-vous vraiment supprimer cette ligne", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.OK)
                    {
                        ctn.Open();
                        SqlCommand cmd = new SqlCommand("delete from manufacturer where manifacturerID=@mkey", ctn);
                        cmd.Parameters.AddWithValue("@mkey", key);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("la suppression avec sucées! ");
                        ctn.Close();
                        showMan();
                        reset();
                        afficher();
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

        private void label2_Click_1(object sender, EventArgs e)
        {
            Form7 fd = new Form7();
            fd.Show();
            this.Hide();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            Form9 fd = new Form9();
            fd.Show();
            this.Hide();
        }

        private void label1_Click_2(object sender, EventArgs e)
        {
            Dashboard fd = new Dashboard();
            fd.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        int i = -1;
        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from manufacturer", ctn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "manufacturer");
            DataTable dt = ds.Tables["manufacturer"];
            if (i < dt.Rows.Count - 1)
            {
                i = ds.Tables[0].Rows.Count - 1;
                guna2TextBox1.Text = dt.Rows[i]["manName"].ToString();
                guna2TextBox2.Text = dt.Rows[i]["manAdd"].ToString();
                guna2TextBox3.Text = dt.Rows[i]["manphone"].ToString();
                guna2DateTimePicker1.Text = dt.Rows[i]["manDate"].ToString();
                guna2DataGridView1.ClearSelection();
                guna2DataGridView1.Rows[i].Selected = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from manufacturer", ctn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "manufacturer");
            DataTable dt = ds.Tables["manufacturer"];
            if (i < dt.Rows.Count - 1)
            {
                i = 0;
                guna2TextBox1.Text = dt.Rows[i]["manName"].ToString();
                guna2TextBox2.Text = dt.Rows[i]["manAdd"].ToString();
                guna2TextBox3.Text = dt.Rows[i]["manphone"].ToString();
                guna2DateTimePicker1.Text = dt.Rows[i]["manDate"].ToString();
                guna2DataGridView1.ClearSelection();
                guna2DataGridView1.Rows[i].Selected = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from manufacturer", ctn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "manufacturer");
            DataTable dt = ds.Tables["manufacturer"];
            if (i < dt.Rows.Count - 1)
            {
                i++;
                guna2TextBox1.Text = dt.Rows[i]["manName"].ToString();
                guna2TextBox2.Text = dt.Rows[i]["manAdd"].ToString();
                guna2TextBox3.Text = dt.Rows[i]["manphone"].ToString();
                guna2DateTimePicker1.Text = dt.Rows[i]["manDate"].ToString();
                guna2DataGridView1.ClearSelection();
                guna2DataGridView1.Rows[i].Selected = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from manufacturer", ctn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "manufacturer");
            DataTable dt = ds.Tables["manufacturer"];
            if (i > 0)
            {

                i--;
                guna2TextBox1.Text = dt.Rows[i]["manName"].ToString();
                guna2TextBox2.Text = dt.Rows[i]["manAdd"].ToString();
                guna2TextBox3.Text = dt.Rows[i]["manphone"].ToString();
                guna2DateTimePicker1.Text = dt.Rows[i]["manDate"].ToString();
                guna2DataGridView1.ClearSelection();
                guna2DataGridView1.Rows[i].Selected = true;
            }
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

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
