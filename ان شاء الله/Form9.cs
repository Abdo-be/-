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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            showCUS();
        }
        SqlConnection ctn = new SqlConnection(@"Data Source=DESKTOP-F74G727\SQLEXPRESS;Initial Catalog=PharmacyManagement;Integrated Security=True");
        private void showCUS()
        {
            ctn.Open();
            string query = "select *from customer";
            SqlDataAdapter da = new SqlDataAdapter(query, ctn);
            SqlCommandBuilder bldr = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
           guna2DataGridView1.DataSource = ds.Tables[0];
            ctn.Close();

        }
        private void label2_Click(object sender, EventArgs e)
        {
            Form7 dr = new Form7();
            dr.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard dr = new Dashboard();
            dr.Show();
            this.Hide();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form8 dr = new Form8();
            dr.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            sellerAd dr = new sellerAd();
            dr.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            window dr = new window();
            dr.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard fd = new Dashboard();
            fd.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form7 fd = new Form7();
            fd.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Form8 fd = new Form8();
            fd.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            sellerAd fd = new sellerAd();
            fd.Show();
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Dashboard fd = new Dashboard();
            fd.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox3.Text == "" || guna2TextBox2.Text == "" || comboGender.SelectedIndex == -1)
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

                    MessageBox.Show("la modifiaction avec sucées!");
                    ctn.Close();
                    showCUS();

                    reset();
                    afficher();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        void afficher()
        {
            if (guna2TextBox1.Text == "" || guna2TextBox3.Text == "" ||guna2TextBox2.Text == "" || comboGender.SelectedIndex == -1)
            {
                //  MessageBox.Show("il doit saisir tout les information");
            }
            else
            {
                try
                {
                    ctn.Open();
                    SqlCommand cmd = new SqlCommand("insert into customer(CustomerName,Custgender,Custadress,Custphone,Custdatabirth) values(@cn,@cg,@cadr,@cp,@cdat) ", ctn);
                    cmd.Parameters.AddWithValue("@cn", guna2TextBox1.Text);
                    cmd.Parameters.AddWithValue("@cg", comboGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@cadr", guna2TextBox2.Text);
                    cmd.Parameters.AddWithValue("@cp", guna2TextBox3.Text);
                    cmd.Parameters.AddWithValue("@cdat", guna2DateTimePicker1.Value.Date);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("added");
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
        private void reset()
        {
            guna2TextBox1.Text = "";
            guna2TextBox3.Text = "";
            guna2TextBox2.Text = "";
            comboGender.SelectedIndex = 0;
            guna2DateTimePicker1.Value = DateTime.Now.Date;
            key = 0;
        }
        private void Form9_Load(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void label1_Click_2(object sender, EventArgs e)
        {
            Dashboard fd = new Dashboard();
            fd.Show();
            this.Hide();
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

                        MessageBox.Show("la suppression avec sucées!");
                        ctn.Close();
                        showCUS();
                        reset();
                        afficher();
                    }
                    else
                    {
                        MessageBox.Show("suppression sera  ignorés !");
                        reset();
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int i = -1;
        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from customer", ctn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "customer");
            DataTable dt = ds.Tables["customer"];
            if (i < dt.Rows.Count - 1)
            {
                i = 0;
                guna2TextBox1.Text = dt.Rows[i]["CustomerName"].ToString();
                comboGender.SelectedItem = dt.Rows[i]["Custgender"].ToString();
                guna2TextBox2.Text = dt.Rows[i]["Custadress"].ToString();
                guna2TextBox3.Text = dt.Rows[i]["Custphone"].ToString();
                guna2DateTimePicker1.Text = dt.Rows[i]["Custdatabirth"].ToString();
                guna2DataGridView1.ClearSelection();
                guna2DataGridView1.Rows[i].Selected = true;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from customer", ctn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "customer");
            DataTable dt = ds.Tables["customer"];
            if (i < dt.Rows.Count - 1)
            {
                i = ds.Tables[0].Rows.Count - 1;
                guna2TextBox1.Text = dt.Rows[i]["CustomerName"].ToString();
                comboGender.SelectedItem = dt.Rows[i]["Custgender"].ToString();
                guna2TextBox2.Text = dt.Rows[i]["Custadress"].ToString();
                guna2TextBox3.Text = dt.Rows[i]["Custphone"].ToString();
                guna2DateTimePicker1.Text = dt.Rows[i]["Custdatabirth"].ToString();
                guna2DataGridView1.ClearSelection();
                guna2DataGridView1.Rows[i].Selected = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from customer", ctn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "customer");
            DataTable dt = ds.Tables["customer"];
            if (i < dt.Rows.Count - 1)
            {
                i++;
                guna2TextBox1.Text = dt.Rows[i]["CustomerName"].ToString();
                comboGender.SelectedItem = dt.Rows[i]["Custgender"].ToString();
                guna2TextBox2.Text = dt.Rows[i]["Custadress"].ToString();
                guna2TextBox3.Text = dt.Rows[i]["Custphone"].ToString();
                guna2DateTimePicker1.Text = dt.Rows[i]["Custdatabirth"].ToString();
                guna2DataGridView1.ClearSelection();
                guna2DataGridView1.Rows[i].Selected = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from customer", ctn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "customer");
            DataTable dt = ds.Tables["customer"];
            if (i > 0)
            {

                i--;
                guna2TextBox1.Text = dt.Rows[i]["CustomerName"].ToString();
                comboGender.SelectedItem = dt.Rows[i]["Custgender"].ToString();
                guna2TextBox2.Text = dt.Rows[i]["Custadress"].ToString();
                guna2TextBox3.Text = dt.Rows[i]["Custphone"].ToString();
                guna2DateTimePicker1.Text = dt.Rows[i]["Custdatabirth"].ToString();
                guna2DataGridView1.ClearSelection();
                guna2DataGridView1.Rows[i].Selected = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
            SqlCommand cmd = new SqlCommand("select CustomerName,Custgender,Custadress from customer", ctn);
            DataTable dt = new DataTable();
            SqlDataReader dr;
            ctn.Open(); 
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            dt.WriteXml("customer.xml");
            ctn.Close();

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboGender.SelectedItem =guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
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

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
