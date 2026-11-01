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
    public partial class Medcines : Form
    {
        public Medcines()
        {
            InitializeComponent();
            showmedc();
            getmanu();
           
        }
        SqlConnection ctn = new SqlConnection(@"Data Source=DESKTOP-F74G727\SQLEXPRESS;Initial Catalog=PharmacyManagement;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard ft = new Dashboard();
            ft.Show();
            this.Hide();
        }
        private void getManNAME()
        {
            ctn.Open();
            SqlCommand cmd = new SqlCommand("select *from manufacturer where manifacturerID='"+comboManufacturer.SelectedValue.ToString()+"'", ctn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                guna2TextBox4.Text = dr["manName"].ToString();
            }
            ctn.Close();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Customers fg = new Customers();
            fg.Show();
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

        private void label9_Click(object sender, EventArgs e)
        {
            Customers fg = new Customers();
            fg.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Manufacturer fg = new Manufacturer();
            fg.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard fg = new Dashboard();
            fg.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("étes-vous sure de quitter le programme!", "Sortie...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ;
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void showmedc()
        {
            ctn.Open();
            string query = "select *from medcines";
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
            guna2TextBox4.Text = "";
            comboMedType.SelectedValue = "";
            guna2TextBox2.Text = "";
            key = 0;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox3.Text == "" || guna2TextBox2.Text== ""|| comboMedType.SelectedIndex==-1)
            {
                MessageBox.Show("il doit remplir  tout les information");
            }
            else
            {
                try
                {
                    DialogResult res = MessageBox.Show("voulez-vous vraiment Ajouter  cette ligne", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.OK)
                    {
                        ctn.Open();
                    SqlCommand cmd = new SqlCommand("insert into medcines(medcineName,medcinType,Quantity,price,manifacturerID,manifacturerName) values(@men,@met,@meQ,@mepr,@meID,@meniName) ", ctn);
                    cmd.Parameters.AddWithValue("@men", guna2TextBox1.Text);
                    cmd.Parameters.AddWithValue("@met", comboMedType.SelectedItem);
                    cmd.Parameters.AddWithValue("@meQ", guna2TextBox2.Text);
                    cmd.Parameters.AddWithValue("@mepr", guna2TextBox3.Text);
                    cmd.Parameters.AddWithValue("@meID", comboManufacturer.SelectedValue);
                    cmd.Parameters.AddWithValue("@meniName", guna2TextBox4.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("l'ajout avec succées");
                    ctn.Close();
                    showmedc();
                    reset();
                    }
                    else
                    {
                        MessageBox.Show("l'ajout sera  ignorés");
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
        private void getmanu()
        {
            ctn.Open();
            SqlCommand cmd = new SqlCommand("select manifacturerID from manufacturer", ctn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("manifacturerID", typeof(int));
            dt.Load(dr);
            comboManufacturer.ValueMember = "manifacturerID";
            comboManufacturer.DataSource = dt;

            ctn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the medcines");
            }
            else
            {
                try
                {
                    DialogResult res = MessageBox.Show("voulez-vous vraiment supprimer cette ligne", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.OK)
                    {
                        ctn.Open();
                        SqlCommand cmd = new SqlCommand("delete from medcines where mednum =@mekey", ctn);
                        cmd.Parameters.AddWithValue("@mekey", key);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("la suppression avec succées!");
                        ctn.Close();
                        showmedc();
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
            if (guna2TextBox1.Text == "" || guna2TextBox3.Text == "" || guna2TextBox4.Text == ""|| comboMedType.SelectedIndex == -1)
            {
               MessageBox.Show("il doit saisir tout les information");
            }
            else
            {
                try
                {

                    ctn.Open();
                    SqlCommand cmd = new SqlCommand("update  medcines set medcineName= @men,medcinType=@met,Quantity=@meQ,price=@mepr ,manifacturerID=@meID, manifacturerName=@meniName where manifacturerID=@mekey ", ctn);
                    cmd.Parameters.AddWithValue("@men", guna2TextBox1.Text);
                    cmd.Parameters.AddWithValue("@met", comboMedType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@meQ", guna2TextBox2.Text);
                    cmd.Parameters.AddWithValue("@mepr", guna2TextBox3.Text);
                    cmd.Parameters.AddWithValue("@meID", comboManufacturer.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@meniName", guna2TextBox4.Text);
                    cmd.Parameters.AddWithValue("@mekey", key);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("la modification avec succées!");
                    ctn.Close();
                    showmedc();
                    reset();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getManNAME();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            window fd = new window();
            fd.Show();
            this.Hide();
        }

        private void Medcines_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            Seller fd = new Seller();
            fd.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboMedType.SelectedItem = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            guna2TextBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            guna2TextBox3.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboManufacturer.SelectedItem = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            guna2TextBox4.Text = guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString();
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
