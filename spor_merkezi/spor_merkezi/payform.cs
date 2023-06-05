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
    public partial class payform : Form
    {
        public payform()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm frm3 = new MainForm();
            frm3.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection Cone = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahmad\OneDrive\Belgeler\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void FillAd()
        {
            Cone.Open();
            SqlCommand cmd = new SqlCommand("select UyeAdı from UyeTbl", Cone);
            SqlDataReader drdr;
            drdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("UyeAdı", typeof(string));
            dt.Load(drdr);
            AdCb.ValueMember = "UyeAdı";
            AdCb.DataSource = dt;
            Cone.Close();
        }
 
        private void populate()
        {
            Cone.Open();
            string query = "select * from OdemeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Cone);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            OdemeDGV.DataSource = ds.Tables[0];
            Cone.Close();


        }
        private void button3_Click(object sender, EventArgs e)
        {
               
            AylikTb.Text = "";
        }


        private void payform_Load(object sender, EventArgs e)
        {
            FillAd();
            populate();
        }

        private void OdemeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (AdCb.Text == "" || AylikTb.Text == "")
            {
                MessageBox.Show("eksik bilgi girdiniz!!");

            }
            else
            {
                string OdemePeriode = periode.Value.ToString() + periode.Value.Year.ToString();
                Cone.Open();
                //SqlDataAdapter sda = new SqlDataAdapter("select count(*) from OdemeTbl where OUye='"+AdCb.SelectedValue.ToString()+"' and OAyı='"+OdemePeriode+ "'",Cone);
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from OdemeTbl where OUye='" + AdCb.SelectedValue.ToString() + "' and OAyı='" + OdemePeriode + "'", Cone);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("bu ay için zaten ödendi ");

                }
                else
                {
                     // string query= "insert into OdemeTbl values('"+OdemePeriode+"','"AdCb.SelectedValue.ToString()"',"+ AylikTb.Text +
                        string query = "insert into OdemeTbl values('" + OdemePeriode + "','" + AdCb.SelectedValue.ToString() + "'," + AylikTb.Text + ");";
                        SqlCommand cmd = new SqlCommand(query,Cone);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ödenen tutar başarıyla eklendi ");


                }
                Cone.Close();
                populate();
            }
        }

        

    }
}
