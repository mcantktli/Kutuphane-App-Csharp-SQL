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

//SQL yolu = Data Source=MEHMETCAN\SQLEXPRESS;Initial Catalog=kutuphaneprogram;Integrated Security=True

namespace Kütüphane_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=MEHMETCAN\\SQLEXPRESS;Initial Catalog=kutuphaneprogram;Integrated Security=True");

        private void verilerigoruntule()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from kitaplar", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["kitapad"].ToString());
                ekle.SubItems.Add(oku["yazar"].ToString());
                ekle.SubItems.Add(oku["yayınevi"].ToString());
                ekle.SubItems.Add(oku["sayfa"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoruntule();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form formkayıtvesil = new Form2();
            formkayıtvesil.Show();
            this.Hide();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form kitapara = new Form3();
            kitapara.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form oduncler = new Form4();
            oduncler.Show();
            this.Hide();
        }
    }
}
