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
    public partial class sellerAd : Form
    {
        public sellerAd()
        {
            InitializeComponent();
            showni();
        }
        SqlConnection ctn = new SqlConnection(@"Data Source=DESKTOP-F74G727\SQLEXPRESS;Initial Catalog=PharmacyManagement;Integrated Security=True");
        static DataSet ds = new DataSet();

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard fd = new Dashboard();
            fd.Show();
            this.Hide();
        }
        void reset()
        {
            guna2TextBox1.Text = "";
            guna2TextBox4.Text = "";
            guna2TextBox2.Text = "";
            comboBoxsellerGen.SelectedIndex = 0;
            guna2TextBox3.Text = "";

            key = 0;
        }
        void showni()
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
        void afficher()
        {
            if (guna2TextBox1.Text == "" || guna2TextBox4.Text == "" || guna2TextBox3.Text == "" || guna2TextBox2.Text == "" || comboBoxsellerGen.SelectedIndex == -1)
            {
               // MessageBox.Show("il doit saisir tout les information");
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
                        cmd.Parameters.AddWithValue("@sadr", guna2TextBox2.Text);
                        cmd.Parameters.AddWithValue("@spass", guna2TextBox3.Text);
                        cmd.Parameters.AddWithValue("@sdat", guna2DateTimePicker1.Value.Date);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("data doit remplit");
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox4.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "" || comboBoxsellerGen.SelectedIndex == -1)
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
                        cmd.Parameters.AddWithValue("@sP", guna2TextBox3.Text);
                        cmd.Parameters.AddWithValue("@sadr", guna2TextBox2.Text);
                        cmd.Parameters.AddWithValue("@spass", guna2TextBox4.Text);
                        cmd.Parameters.AddWithValue("@sdat", guna2DateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@skey", key);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("la Modification avec succées");
                        ctn.Close();
                        showni();
                        reset();
                        afficher();
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

        private void label8_Click(object sender, EventArgs e)
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

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard fd = new Dashboard();
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

        private void label4_Click(object sender, EventArgs e)
        {
            Form8 fd = new Form8();
            fd.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            sellerAd fd = new sellerAd();
            fd.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            window fd = new window();
            fd.Show();
            this.Hide();
        }
        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
              //  MessageBox.Show("Select the seller");
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("étes-vous sure de quitter le programme!", "Sortie...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
        int posi = 0;
        private void naviguer()
        {
        
               for(int i = 0; i < guna2DataGridView1.Rows.Count; i++)
            {
                if(guna2DataGridView1.Rows[i].Selected)
                {
                    guna2DataGridView1.Rows[i].Selected = false;
                }
            }
            guna2DataGridView1.Rows[posi].Selected = true;
        }
        private void label3_Click_1(object sender, EventArgs e)
        {
            Form9 fd = new Form9();
            fd.Show();
            this.Hide();
        }

        private void sellerAd_Load(object sender, EventArgs e)
        {

        }
        int i=-1;
        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from seller", ctn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "seller");
            DataTable dt = ds.Tables["seller"];
            if (i < dt.Rows.Count - 1)
            {
                i=0;
                guna2TextBox1.Text = dt.Rows[i]["sellerName"].ToString();
                comboBoxsellerGen.SelectedItem = dt.Rows[i]["sellergender"].ToString();
                guna2TextBox4.Text = dt.Rows[i]["Sphone"].ToString();
                guna2TextBox2.Text = dt.Rows[i]["Sadress"].ToString();
                guna2TextBox3.Text = dt.Rows[i]["Spasswords"].ToString();

                guna2DateTimePicker1.Text = dt.Rows[i]["SdateBS"].ToString();
                guna2DataGridView1.ClearSelection();
                guna2DataGridView1.Rows[i].Selected = true;
                // DataTable dt = ds.Tables["seller"];
                //if (i < dt.Rows.Count - 1)
                //{

                //textsellerName.Text = dt.Rows[i]["sellerName"].ToString();
                //comboBoxsellerGen.SelectedItem = dt.Rows[i]["sellergender"].ToString();
                //textsellerPhon.Text = dt.Rows[i]["Sphone"].ToString();
                //textsellerAddr.Text = dt.Rows[i]["Sadress"].ToString();
                //textsellerPassw.Text = dt.Rows[i]["Spasswords"].ToString();

                //dateTimePicker1.Text = dt.Rows[i]["SdateBS"].ToString();

                //posi = 0;
                //    naviguer();
                }
            }
        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from seller", ctn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "seller");
            DataTable dt = ds.Tables["seller"];
            if (i < dt.Rows.Count - 1)
            {
                i = ds.Tables[0].Rows.Count - 1;
                guna2TextBox1.Text = dt.Rows[i]["sellerName"].ToString();
                comboBoxsellerGen.SelectedItem = dt.Rows[i]["sellergender"].ToString();
                guna2TextBox4.Text = dt.Rows[i]["Sphone"].ToString();
                guna2TextBox2.Text = dt.Rows[i]["Sadress"].ToString();
                guna2TextBox3.Text = dt.Rows[i]["Spasswords"].ToString();

                guna2DateTimePicker1.Text = dt.Rows[i]["SdateBS"].ToString();
                guna2DataGridView1.ClearSelection();
                guna2DataGridView1.Rows[i].Selected = true;
                // DataTable dt = ds.Tables["seller"];
                //if (i < dt.Rows.Count - 1)
                //{
                // 
                //posi = ds.Tables[0].Rows.Count - 1;
                //naviguer();
                }
            }
        
        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from seller", ctn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "seller");
            DataTable dt = ds.Tables["seller"];
            if (i < dt.Rows.Count - 1)
            {
                i++;
                guna2TextBox1.Text = dt.Rows[i]["sellerName"].ToString();
                comboBoxsellerGen.SelectedItem = dt.Rows[i]["sellergender"].ToString();
                guna2TextBox4.Text = dt.Rows[i]["Sphone"].ToString();
                guna2TextBox2.Text = dt.Rows[i]["Sadress"].ToString();
                guna2TextBox3.Text = dt.Rows[i]["Spasswords"].ToString();

                guna2DateTimePicker1.Text = dt.Rows[i]["SdateBS"].ToString();
                guna2DataGridView1.ClearSelection();
                guna2DataGridView1.Rows[i].Selected = true;
            }
            //DataTable dt = ds.Tables["seller"];
            //if (i < dt.Rows.Count - 1)
            //{
            //    textsellerName.Text = dt.Rows[i]["sellerName"].ToString();
            //    comboBoxsellerGen.SelectedItem = dt.Rows[i]["sellergender"].ToString();
            //    textsellerPhon.Text = dt.Rows[i]["Sphone"].ToString();
            //    textsellerAddr.Text = dt.Rows[i]["Sadress"].ToString();
            //    textsellerPassw.Text = dt.Rows[i]["Spasswords"].ToString();

            //    dateTimePicker1.Text = dt.Rows[i]["SdateBS"].ToString();
            //    posi++;
            //    naviguer();
            //}

        }
        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from seller", ctn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "seller");
            DataTable dt = ds.Tables["seller"];
            if (i > 0)
            {

                i--;
                guna2TextBox1.Text = dt.Rows[i]["sellerName"].ToString();
                comboBoxsellerGen.SelectedItem = dt.Rows[i]["sellergender"].ToString();
                guna2TextBox4.Text = dt.Rows[i]["Sphone"].ToString();
                guna2TextBox2.Text = dt.Rows[i]["Sadress"].ToString();
                guna2TextBox3.Text = dt.Rows[i]["Spasswords"].ToString();

                guna2DateTimePicker1.Text = dt.Rows[i]["SdateBS"].ToString();
                guna2DataGridView1.ClearSelection();
                guna2DataGridView1.Rows[i].Selected = true;
            }
            //DataTable dt = ds.Tables["seller"];
            //if (i < dt.Rows.Count - 1)
            //{
            //    textsellerName.Text = dt.Rows[i]["sellerName"].ToString();
            //    comboBoxsellerGen.SelectedItem = dt.Rows[i]["sellergender"].ToString();
            //    textsellerPhon.Text = dt.Rows[i]["Sphone"].ToString();
            //    textsellerAddr.Text = dt.Rows[i]["Sadress"].ToString();
            //    textsellerPassw.Text = dt.Rows[i]["Spasswords"].ToString();

            //    dateTimePicker1.Text = dt.Rows[i]["SdateBS"].ToString();
            //    posi--;
            //    naviguer();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        


        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBoxsellerGen.SelectedItem = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            guna2TextBox4.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            guna2TextBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            guna2TextBox3.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();

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
    }
}
