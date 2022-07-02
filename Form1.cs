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

namespace Telefonrehberuygulamasi1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-LAP7TNM;Initial Catalog=telrehber1;Integrated Security=True");

        void rehberlist()
        {
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from tblrehber", baglanti);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView1.DataSource = dt3;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            rehberlist();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into TBLREHBER (İSİM,NUMARA) values (@p1,@p2)", baglanti);
            komut2.Parameters.AddWithValue("@p1", textBox1.Text);
            komut2.Parameters.AddWithValue("@p2", textBox2.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kişi Rehbere Kayıt Edildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
