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
    public partial class AddMembers : Form
    {
        public AddMembers()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Cone = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahmad\OneDrive\Belgeler\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void AddMembers_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AdTb.Text == "" || TelefonTb.Text == "" || YasTb.Text == "" || AylikTb.Text == "")
            {
                MessageBox.Show("eksik bilgi girdiniz!!");

            }
            else
            {
                try
                {
                    Cone.Open();
                    string query = "insert into UyeTbl values('" + AdTb.Text + "','" + TelefonTb.Text + "','" + CinsiyetCb.SelectedItem.ToString() + "','" + YasTb.Text + "','" + AylikTb.Text + "','" + ZamanCb.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, Cone);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" üye başarıyla eklendi ");
                    AdTb.Text = "";
                    YasTb.Text = "";
                    CinsiyetCb.Text = "";
                    TelefonTb.Text = "";
                    AylikTb.Text = "";
                    ZamanCb.Text = "";
                    Cone.Close();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdTb.Text = "";
            YasTb.Text ="";
            CinsiyetCb.Text = "";
            TelefonTb.Text = "";
            AylikTb.Text = "";
            ZamanCb.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm frm3 = new MainForm();
            frm3.Show();
            this.Hide();
        }
    }
}
