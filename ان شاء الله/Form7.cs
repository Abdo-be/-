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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            showmedc();
            getmanu();
        }
        SqlConnection ctn = new SqlConnection(@"Data Source=DESKTOP-F74G727\SQLEXPRESS;Initial Catalog=PharmacyManagement;Integrated Security=True");

        private void label5_Click(object sender, EventArgs e)
        {
            sellerAd fd = new sellerAd();
            fd.Show();
            this.Hide();

        }

        private void label20_Click(object sender, EventArgs e)
        {
            window fd = new window();
            fd.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form9 fd = new Form9();
            fd.Show();
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

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Form9 fd = new Form9();
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

        private void label4_Click(object sender, EventArgs e)
        {
            Form8 fd = new Form8();
            fd.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard fd = new Dashboard();
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
        private void reset()
        {
            textMedName.Text = "";
            textPrice.Text = "";
            textManufacturerName.Text = "";
            comboMedType.SelectedValue = "";
            textQuantity.Text = "";
            key = 0;
        }
        private void Form7_Load(object sender, EventArgs e)
        {

        }
        void afficher()
        {
            if (textMedName.Text == "" || textPrice.Text == "" || textQuantity.Text == "" || comboMedType.SelectedIndex == -1)
            {
              //  MessageBox.Show("il doit remplir  tout les information");
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
                        cmd.Parameters.AddWithValue("@men", textMedName.Text);
                        cmd.Parameters.AddWithValue("@met", comboMedType.SelectedItem);
                        cmd.Parameters.AddWithValue("@meQ", textQuantity.Text);
                        cmd.Parameters.AddWithValue("@mepr", textPrice.Text);
                        cmd.Parameters.AddWithValue("@meID", comboManufacturer.SelectedValue);
                        cmd.Parameters.AddWithValue("@meniName", textManufacturerName.Text);
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
        private void button2_Click(object sender, EventArgs e)
        {
            if (textMedName.Text == "" || textPrice.Text == "" || textManufacturerName.Text == "" || comboMedType.SelectedIndex == -1)
            {
                MessageBox.Show("il doit saisir tout les information");
            }
            else
            {
                try
                {

                    ctn.Open();
                    SqlCommand cmd = new SqlCommand("update  medcines set medcineName= @men,medcinType=@met,Quantity=@meQ,price=@mepr ,manifacturerID=@meID, manifacturerName=@meniName where manifacturerID=@mekey ", ctn);
                    cmd.Parameters.AddWithValue("@men", textMedName.Text);
                    cmd.Parameters.AddWithValue("@met", comboMedType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@meQ", textQuantity.Text);
                    cmd.Parameters.AddWithValue("@mepr", textPrice.Text);
                    cmd.Parameters.AddWithValue("@meID", comboManufacturer.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@meniName", textManufacturerName.Text);
                    cmd.Parameters.AddWithValue("@mekey", key);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("update");
                    ctn.Close();
                    showmedc();
                    reset();
                    afficher();

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

                        MessageBox.Show("deleted");
                        ctn.Close();
                        showmedc();
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
        int i = -1;
        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from medcines", ctn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "medcines");
            DataTable dt = ds.Tables["medcines"];
            if (i < dt.Rows.Count - 1)
            {
                i = 0;

                textMedName.Text = dt.Rows[i]["medcineName"].ToString();
                comboMedType.SelectedItem = dt.Rows[i]["medcinType"].ToString();
                textQuantity.Text = dt.Rows[i]["Quantity"].ToString();
                textPrice.Text = dt.Rows[i]["price"].ToString();
                comboManufacturer.SelectedItem = dt.Rows[i]["manifacturerID"].ToString();
                textManufacturerName.Text = dt.Rows[i]["manifacturerName"].ToString();
                guna2DataGridView1.ClearSelection();
                guna2DataGridView1.Rows[i].Selected = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from medcines", ctn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "medcines");
            DataTable dt = ds.Tables["medcines"];
            if (i < dt.Rows.Count - 1)
            {
                i = ds.Tables[0].Rows.Count - 1;

                textMedName.Text = dt.Rows[i]["medcineName"].ToString();
                comboMedType.SelectedItem = dt.Rows[i]["medcinType"].ToString();
                textQuantity.Text = dt.Rows[i]["Quantity"].ToString();
                textPrice.Text = dt.Rows[i]["price"].ToString();
                comboManufacturer.SelectedItem = dt.Rows[i]["manifacturerID"].ToString();
                textManufacturerName.Text = dt.Rows[i]["manifacturerName"].ToString();
                guna2DataGridView1.ClearSelection();
                guna2DataGridView1.Rows[i].Selected = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from medcines", ctn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "medcines");
            DataTable dt = ds.Tables["medcines"];
            if (i < dt.Rows.Count - 1)
            {
                i++;

                textMedName.Text = dt.Rows[i]["medcineName"].ToString();
                comboMedType.SelectedItem = dt.Rows[i]["medcinType"].ToString();
                textQuantity.Text = dt.Rows[i]["Quantity"].ToString();
                textPrice.Text = dt.Rows[i]["price"].ToString();
                comboManufacturer.SelectedItem = dt.Rows[i]["manifacturerID"].ToString();
                textManufacturerName.Text = dt.Rows[i]["manifacturerName"].ToString();
                guna2DataGridView1.ClearSelection();
                guna2DataGridView1.Rows[i].Selected = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from medcines", ctn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "medcines");
            DataTable dt = ds.Tables["medcines"];
            if (i > 0)
            {

                i--;

                textMedName.Text = dt.Rows[i]["medcineName"].ToString();
                comboMedType.SelectedItem = dt.Rows[i]["medcinType"].ToString();
                textQuantity.Text = dt.Rows[i]["Quantity"].ToString();
                textPrice.Text = dt.Rows[i]["price"].ToString();
                comboManufacturer.SelectedItem = dt.Rows[i]["manifacturerID"].ToString();
                textManufacturerName.Text = dt.Rows[i]["manifacturerName"].ToString();
                guna2DataGridView1.ClearSelection();
                guna2DataGridView1.Rows[i].Selected = true;
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textMedName.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboMedType.SelectedItem = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textQuantity.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textPrice.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboManufacturer.SelectedItem = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textManufacturerName.Text = guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            if (textMedName.Text == "")
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
