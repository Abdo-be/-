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
    public partial class adminForm : Form
    {
        public static adminForm fd;
        public adminForm()
        {
            InitializeComponent();
            showmedc();
            showbill();
            guna2TextBox4.Text = Form1.user;
            GetCustomer();

        }
        SqlConnection ctn = new SqlConnection(@"Data Source=DESKTOP-F74G727\SQLEXPRESS;Initial Catalog=PharmacyManagement;Integrated Security=True");
        private void UpdateQty()
        {
            try
            {
                int NewQty = Stock - Convert.ToInt32(guna2TextBox1.Text);
                ctn.Open();
                SqlCommand cmd = new SqlCommand("update  medcines set Quantity=@meQ  where manifacturerID=@mekey ", ctn);
           
                cmd.Parameters.AddWithValue("@meQ", NewQty);
               
                cmd.Parameters.AddWithValue("@mekey", Key);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Ligne Sera Modifier! ");
                ctn.Close();
                showmedc();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void insertbill()
        {
            if (guna2TextBox3.Text == "")
            {
                MessageBox.Show("");
            }
            else
            {
                try
                {
                    ctn.Open();
                    SqlCommand cmd = new SqlCommand("insert into bill(Sname,CustomerName,CustomerNum,Bdate,BAmount) values(@Sn,@Cn,@Cnu,@BD,@BA) ", ctn);
                    cmd.Parameters.AddWithValue("@Sn", label20.Text);
                    cmd.Parameters.AddWithValue("@Cn", guna2TextBox3.Text);
                    cmd.Parameters.AddWithValue("@Cnu", comboCustomerId.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@BD", DateTime.Today.Date);
                    cmd.Parameters.AddWithValue("@BA", Grdtotale);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("l'ajout avec succées!");
                    ctn.Close();
                    showbill();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
        }
      
        private void showbill()
        {
            ctn.Open();
            string query = "select *from bill where Sname='"+label20.Text+"'";
            SqlDataAdapter da = new SqlDataAdapter(query, ctn);
            SqlCommandBuilder bldr = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            guna2DataGridView2.DataSource = ds.Tables[0];


            ctn.Close();
        }
        private void showmedc()
        {
            ctn.Open();
            string query = "select *from medcines ";
            SqlDataAdapter da = new SqlDataAdapter(query, ctn);
            SqlCommandBuilder bldr = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            ctn.Close();

        }
        private void GetCustomer()
        {
            ctn.Open();
            SqlCommand cmd = new SqlCommand("select CustomerNum from customer",ctn);
            SqlDataReader dr;
            dr= cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustomerNum",typeof(int));
            dt.Load(dr);
            comboCustomerId.ValueMember = "CustomerNum";
            comboCustomerId.DataSource = dt;
            ctn.Close();


        }
        private void GetCusName()
        {
            ctn.Open();
            SqlCommand cmd = new SqlCommand("select * from customer where CustomerNum='"+comboCustomerId.SelectedValue.ToString()+"'", ctn);
           //SqlDataReader dr;
            //dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            //dt.Columns.Add("CustomerNum", typeof(int));
            //dt.Load(dr);
            //comboCustomerId.ValueMember = "CustomerNum";
            //comboCustomerId.DataSource = dt;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dar in dt.Rows)
            {
                guna2TextBox3.Text = dar["CustomerName"].ToString();
            }
            ctn.Close();
            

        }
        private void label2_Click(object sender, EventArgs e)
        {
            Form7 fr = new Form7();
            fr.Show();
            this.Hide();
            

            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Customers fr = new Customers();
            fr.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Manufacturer fr = new Manufacturer();
            fr.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Seller fr = new Seller();
            fr.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Seller fr = new Seller();
            fr.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Manufacturer fr = new Manufacturer();
            fr.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Customers fr = new Customers();
            fr.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Medcines fr = new Medcines();
            fr.Show();
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
        int n = 0, Grdtotale;
        public void button1_Click(object sender, EventArgs e)
        {
            if(guna2TextBox1.Text==""|| Convert.ToInt32(guna2TextBox1.Text) > Stock)
            {
                MessageBox.Show("Enter the  correct Quantity");
            }
            else
            {
                int total = Convert.ToInt32(guna2TextBox1.Text) * Convert.ToInt32(guna2TextBox2.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(guna2DataGridView3);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = guna2TextBox4.Text;
                newRow.Cells[2].Value = guna2TextBox1.Text;
                newRow.Cells[3].Value = guna2TextBox2.Text;
                newRow.Cells[4].Value = total;
                guna2DataGridView3.Rows.Add(newRow);
                Grdtotale = Grdtotale + total;
                //dataGridView1.Rows.Add(newRow);
                label18.Text = "Rs"+ Grdtotale ;
                n++;
                UpdateQty();
                //dataGridView1.Rows.Add(newRow);

            }
        }
        int pos=60;

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            printDocument2.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("ppr", 285, 600);
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument2.Print();
            }
            insertbill();
        }
        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
        int Key = 0, Stock;
      //  string MEDCINE;
       // int ID, PRICE, QUANTITY, TOTAL;

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
          

        }
        
        private void adminForm_Load(object sender, EventArgs e)
        {
            
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
             Medcines fd = new Medcines();
            fd.Show();
            this.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }
        int medid, medprice, medquantity, medtotal;
        string medmedcine;
        public void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Pharmacy Management", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(50));
            //e.Graphics.DrawString("ID  MEDCINE  PRICE  QUANTITY  TOTAL", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Chocolate, new Point(26,40));
            e.Graphics.DrawString("ID ", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.SandyBrown, new Point(17, 40));
            e.Graphics.DrawString("MEDCINE ", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Purple, new Point(40, 40));
            e.Graphics.DrawString("PRICE ", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.DarkOliveGreen, new Point(115, 40));
            e.Graphics.DrawString("QUANTITY ", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.MediumSlateBlue, new Point(163, 40));
            e.Graphics.DrawString("TOTAL", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.DarkGray, new Point(235, 40));





            foreach (DataGridViewRow row in guna2DataGridView3.Rows)
            {
                medid = Convert.ToInt32(row.Cells["ID"].Value);
                medmedcine = "" + row.Cells["MEDCINE"].Value;
                medprice = Convert.ToInt32(row.Cells["PRICE"].Value);
                medquantity = Convert.ToInt32(row.Cells["QUANTITY"].Value);
                medtotal = Convert.ToInt32(row.Cells["TOTAL"].Value);
                e.Graphics.DrawString("" + medid, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Gray, new Point(21, pos));
                e.Graphics.DrawString("" + medmedcine, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(40, pos));
                e.Graphics.DrawString("" + medprice, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Cyan, new Point(115, pos));
                e.Graphics.DrawString("" + medquantity, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.BlueViolet, new Point(163, pos));
                e.Graphics.DrawString("" + medtotal, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Orange, new Point(235, pos));
                pos = pos + 20;
            }
            e.Graphics.DrawString("Grand Total:Rs" + Grdtotale, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Violet, new Point(50, pos + 50));
            e.Graphics.DrawString("----------welcome to my home----------", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Brown, new Point(10, pos + 85));
            guna2DataGridView3.Rows.Clear();
            guna2DataGridView3.Refresh();
            pos = 100;
            Grdtotale = 0;
            n = 0;
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
          
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox4.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            // comboMedType.SelectedItem = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            Stock = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            guna2TextBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            //  comboManufacturer.SelectedItem = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            //  textManufacturerName.Text = dataGridView3.SelectedRows[0].Cells[6].Value.ToString();
            if (guna2TextBox4.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void guna2DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void label21_Click(object sender, EventArgs e)
        {
            window fd = new window();
            fd.Show();
            this.Hide();
        }

        private void comboCustomerId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCusName();

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
            //textMedName.Text = dataGridView3.SelectedRows[0].Cells[1].Value.ToString();
            //textPrice.Text = dataGridView3.SelectedRows[0].Cells[2].Value.ToString();
            //textManufacturerName.Text = dataGridView3.SelectedRows[0].Cells[3].Value.ToString();
            //comboManufacturer.SelectedValue = dataGridView3.SelectedRows[0].Cells[4].Value.ToString();
            //comboMedType.SelectedItem = dataGridView3.SelectedRows[0].Cells[5].Value.ToString();
            //if (textMedName.Text == "")
            //{
            //    key = 0;
            //}
            //else
            //{
            //    key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            //}
        }
    }
}
