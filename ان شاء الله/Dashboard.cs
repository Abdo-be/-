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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
           // sumAmount();
            countSellered();
            countCust();
            countMed();
            countSeller();
            //GetSeller();
            //getBestSeller();
            //getBestCustomer();
        }
        SqlConnection ctn = new SqlConnection(@"Data Source=DESKTOP-F74G727\SQLEXPRESS;Initial Catalog=PharmacyManagement;Integrated Security=True");

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form7 fr = new Form7();
            fr.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form9 fg = new Form9();
            fg.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            sellerAd s = new sellerAd();
            s.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form8 ft = new Form8();
            ft.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            sellerAd s = new sellerAd();
            s.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form7 fr = new Form7();
            fr.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Form9 fg = new Form9();
            fg.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Form8 fg = new Form8();
            fg.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("etes-vous sure de quitter la fenétre!", "Sortie...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
        }
//        private void sumAmount()
//        {
//            ctn.Open();
//            SqlDataAdapter da = new SqlDataAdapter("select sum(BAmount) from bill", ctn);
//            DataTable dt = new DataTable();
//            da.Fill(dt);
//            label31.Text = "Rs=" + dt.Rows[0][0].ToString();
//            ctn.Close();
//        }
//        private void getBestSeller()
//        {

//            try
//            {
//                ctn.Open();
//                string InnerQuery = "select Max(BAmount) from bill ";
//                DataTable dt = new DataTable();
//                SqlDataAdapter dr = new SqlDataAdapter(InnerQuery, ctn);
//                dr.Fill(dt);
//                SqlDataAdapter da = new SqlDataAdapter("select Sname  from bill where BAmount ='" + dt.Rows[0][0].ToString() + "'", ctn);
//                DataTable dt1 = new DataTable();
//                da.Fill(dt1);
//                label33.Text = dt1.Rows[0][0].ToString();
//                ctn.Close();
//        }
//            catch
//            {
//                ctn.Close();
//            }

//}
//            private void getBestCustomer()
//        {

//            try
//            {
//                ctn.Open();
//                string innerQuery = "select Max(BAmount) from customer ";
//                DataTable dt = new DataTable();
//                SqlDataAdapter dr = new SqlDataAdapter(innerQuery, ctn);
//                dr.Fill(dt);
//                SqlDataAdapter da = new SqlDataAdapter("select CustomerName  from bill where BAmount ='" + dt.Rows[0][0].ToString() + "'", ctn);
//                DataTable dt1 = new DataTable();
//                da.Fill(dt1);
//                label34.Text = dt1.Rows[0][0].ToString();
//                ctn.Close();
//            }
//            catch
//            {

//            }
//        }
        //private void sumAmountBySeller()
        //{
        //    ctn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter("select Sum(BAmount) from bill where Sname ='" + comboBox1.SelectedValue.ToString() + "'", ctn);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    label30.Text = "Rs" + dt.Rows[0][0].ToString();
        //    ctn.Close();
        //}
        private void countCust()
        {
            ctn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select count(*) from  customer", ctn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            LbLCustomers.Text = dt.Rows[0][0].ToString();
            ctn.Close();
        }
        private void countSeller()
        {
            ctn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select count(*) from medcines ", ctn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            LBLMedc.Text = dt.Rows[0][0].ToString();
            ctn.Close();
        }
        private void countSellered()
        {
            ctn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select count(*) from seller ", ctn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            label25.Text = dt.Rows[0][0].ToString();
            ctn.Close();
        }
        private void countMed()
        {
            ctn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select count(*) from manufacturer", ctn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lblManifac.Text = dt.Rows[0][0].ToString();
            ctn.Close();
        }
        //private void GetSeller()
        //{
        //    ctn.Open();
        //    SqlCommand cmd = new SqlCommand("select sellerName from seller", ctn);
        //    SqlDataReader dr;
        //    dr = cmd.ExecuteReader();
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("sellerName", typeof(string));
        //    comboBox1.ValueMember = "sellerName";
        //    comboBox1.DataSource = dt;
        //    ctn.Close();

        //}
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
         
        }
        private void label22_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label24_Click(object sender, EventArgs e)
        {
            window fd = new window();
            fd.Show();
            this.Hide();
        }
        private void label2_Click_1(object sender, EventArgs e)
        {
            Form7 fd = new Form7();
            fd.Show();
            this.Hide();
        }

        private void panel17_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            Form9 fd = new Form9();
            fd.Show();
            this.Hide();
        }
        
        private void comboBox1_SelectionChangeCommitted_1(object sender, EventArgs e)
        { 
           // sumAmountBySeller();
            //GetSeller();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }
    }
}
