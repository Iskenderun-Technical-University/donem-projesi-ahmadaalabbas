using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spor_merkezi
{
    public partial class viewmembers : Form
    {
        public viewmembers()
        {
            InitializeComponent();
        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void FilterByName()
        {
            Cone.Open();
            string query = "select * from UyeTbl where UyeAdı='" + UyeArama.Text + "'";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, Cone);
            
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            var ds = new DataSet();
            sda.Fill(dt);
            MemberSDGV.DataSource = dt;
            Cone.Close();


        }
        private void button3_Click(object sender, EventArgs e)
        {
            FilterByName();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm frm3 = new MainForm();
            frm3.Show();
            this.Hide();
        }
        SqlConnection Cone = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahmad\OneDrive\Belgeler\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Cone.Open();
            string query = "select * from UyeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Cone);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds= new DataSet();
            sda.Fill(ds);
            MemberSDGV.DataSource = ds.Tables[0];
            Cone.Close();


        }
        private void viewmembers_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void UyeArama_TextChange(object sender, EventArgs e)
        {
            Cone.Open();
            string query = "select * from UyeTbl where concat(UyeAdı,UyeCins) like '%" + UyeArama.Text + "%'";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, Cone);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            var ds = new DataSet();
            sda.Fill(dt);
            MemberSDGV.DataSource = dt;
            Cone.Close();
        }
    }
}
