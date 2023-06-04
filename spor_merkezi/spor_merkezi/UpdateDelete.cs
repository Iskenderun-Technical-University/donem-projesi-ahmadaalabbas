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
    public partial class UpdateDelete : Form
    {
        public UpdateDelete()
        {
            InitializeComponent();
        }
        SqlConnection Cone = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahmad\OneDrive\Belgeler\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Cone.Open();
            string query = "select * from UyeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Cone);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            MemberSDGV.DataSource = ds.Tables[0];
            Cone.Close();


        }
        private void UpdateDelete_Load(object sender, EventArgs e)
        {
            populate();

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm frm3 = new MainForm();
            frm3.Show();
            this.Hide();
        }
        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdTb.Text = "";
            YasTb.Text = "";
            CinsiyetCb.Text = "";
            TelefonTb.Text = "";
            AylikTb.Text = "";
            ZamanCb.Text = "";
        }

        private void MemberSDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void MemberSDGV_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (MemberSDGV.Rows.Count != 0)
                {
                    key = Convert.ToInt32(MemberSDGV.CurrentRow.Cells[0].Value.ToString());
                    AdTb.Text = MemberSDGV.CurrentRow.Cells[1].Value.ToString();
                    TelefonTb.Text = MemberSDGV.CurrentRow.Cells[2].Value.ToString();
                    CinsiyetCb.Text = MemberSDGV.CurrentRow.Cells[3].Value.ToString();
                    YasTb.Text = MemberSDGV.CurrentRow.Cells[4].Value.ToString();
                    AylikTb.Text = MemberSDGV.CurrentRow.Cells[5].Value.ToString();
                    ZamanCb.Text = MemberSDGV.CurrentRow.Cells[6].Value.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("silinecek üyeyi seçiniz");
            }
            else
            {
                try
                {
                    Cone.Open();
                    string query = "delete from UyeTbl where MId='" + MemberSDGV.CurrentRow.Cells[0].Value + "'";
                    SqlCommand cmd= new SqlCommand(query, Cone);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Üye başarıyla silindi");
                    Cone.Close();
                    populate();

               }
                catch(Exception Ex)
               {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0|| AdTb.Text == "" || TelefonTb.Text == "" || YasTb.Text == "" || AylikTb.Text == ""|| CinsiyetCb.Text==""|| ZamanCb.Text=="")
            {
                MessageBox.Show("eksik bilgi girdiniz!!");

            }
            else
            {
                try
                {
                    Cone.Open();
                    string query = "update UyeTbl set UyeAdı='" + AdTb.Text + "', UyePh='" + TelefonTb.Text + "', UyeCins='" + CinsiyetCb.Text + "', UyeYas='" + YasTb.Text + "', UyeAylıkT='" + AylikTb.Text + "', UyeZaman='" + ZamanCb.Text + "' where MId=" + MemberSDGV.CurrentRow.Cells[0].Value + ";";
                    SqlCommand cmd = new SqlCommand(query, Cone);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Üye başarıyla Güncellendi");
                    Cone.Close();
                    populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }
    }
}
