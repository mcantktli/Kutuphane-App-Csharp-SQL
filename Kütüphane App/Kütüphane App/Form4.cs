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

namespace Kütüphane_App
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }


        SqlConnection baglan = new SqlConnection("Data Source=MEHMETCAN\\SQLEXPRESS;Initial Catalog=kutuphaneprogram;Integrated Security=True");

        private void verilerigoruntule()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from alıcılar", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["adsoyad"].ToString();
                ekle.SubItems.Add(oku["tcno"].ToString());
                ekle.SubItems.Add(oku["numara"].ToString());
                ekle.SubItems.Add(oku["aldıgıkitap"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            verilerigoruntule();
        }


        string alıcı;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(alıcı))
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("Delete from alıcılar where adsoyad = @adsoyad", baglan);
                komut.Parameters.AddWithValue("@adsoyad", alıcı);
                komut.ExecuteNonQuery();
                baglan.Close();
                verilerigoruntule();
                MessageBox.Show("İade alındı!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }

            else
            {
                MessageBox.Show("Lütfen silinecek veriyi seçiniz!");
            }

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem secim = listView1.SelectedItems[0];
                alıcı = secim.SubItems[0].Text;
                textBox1.Text = secim.SubItems[0].Text;
                textBox2.Text = secim.SubItems[1].Text;
                textBox3.Text = secim.SubItems[2].Text;
                textBox4.Text = secim.SubItems[3].Text;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form oduncekranı = new Form1();
            oduncekranı.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}

//Kitap ödünç alındığında datadan sil, Form4 e ödünçleri görüntüle butonu ekle
