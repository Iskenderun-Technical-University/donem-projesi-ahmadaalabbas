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


namespace spor_merkezi
{
    public partial class login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahmad\OneDrive\Belgeler\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public static bool check(string str)
        {
            return (String.IsNullOrEmpty(str) ||
                str.Trim().Length == 0) ? true : false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand();
            if (check(guna2TextBox1.Text) == true || check(guna2TextBox2.Text) == true)
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox1.Clear(); guna2TextBox2.Clear(); guna2TextBox1.Focus();
            }
            else
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "Select * from Login where Username='" + guna2TextBox1.Text +
                    "'And password='" + guna2TextBox2.Text + "'";
                SqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {
                    this.Hide();
                    MainForm frm3 = new MainForm();
                    frm3.Show();
                    
                }
                else
                {
                    MessageBox.Show("Yanlış Bilgi Girdiniz!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    guna2TextBox1.Clear(); guna2TextBox2.Clear(); guna2TextBox1.Focus();
                }
                con.Close();
            }



               
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.ExitThread( ); 
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
        }
    }
}
