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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=MEHMETCAN\\SQLEXPRESS;Initial Catalog=kutuphaneprogram;Integrated Security=True");

        private void verilerigoruntule()
        {
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

        private void Form3_Load(object sender, EventArgs e)
        {
            verilerigoruntule();
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
        }


        int id = 0;

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[4].Text;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                MessageBox.Show("Lütfen alıcı bilgilerini eksiksiz giriniz ve ödünç verilecek kitabı 'id' sütunundan seçiniz.\nZorunlu kısımlar '*' ile belirtilmiştir!");
            }

            else
            {
                string girilenadsoyad = textBox6.Text;
                string girilentc = textBox7.Text;
                string girilennumara = textBox8.Text;
                string aldıgıkitap = textBox2.Text;
                SqlConnection conn = new SqlConnection("Data Source = MEHMETCAN\\SQLEXPRESS; Initial Catalog = kutuphaneprogram; Integrated Security = True");
                {
                    conn.Open();
                    SqlCommand query = new SqlCommand("Insert into alıcılar(adsoyad,tcno,numara,aldıgıkitap) values ('" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox8.Text.ToString() + "','" + textBox2.Text.ToString() + "')", conn);
                    query.ExecuteNonQuery();
                    MessageBox.Show("Kitap ödünç verildi!");
                    label6.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;
                    label10.Visible = false;
                    label11.Visible = false;
                    textBox6.Visible = false;
                    textBox7.Visible = false;
                    textBox8.Visible = false;
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    conn.Close();
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form oduncler = new Form4();
            oduncler.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form oduncverme = new Form1();
            oduncverme.Show();
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
