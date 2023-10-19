using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AEE_Otomasyon
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost;port=5432; Database=aeeotomasyon; user ID=postgres; password=1234");
        
        private void button1_Click(object sender, EventArgs e)
        {
            

            baglanti.Open();
            NpgsqlCommand veriekle = new NpgsqlCommand("INSERT INTO UYELER (uyead,uyesoyad,baslatarih,paketid,bitistarih,telno,email,aciklama) VALUES (@ad,@soyad,@baslatarih,@paketid,@bitistarih,@telno,@email,@aciklama)");
            veriekle.Connection = baglanti;
            veriekle.Parameters.AddWithValue("ad", textBox2.Text.Trim());
            veriekle.Parameters.AddWithValue("soyad", textBox3.Text.Trim());
            veriekle.Parameters.AddWithValue("baslatarih", dateTimePicker1.Value);
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    comboBox1.Text = "1";
                    break;

                case 1:
                    comboBox1.Text = "2";
                    break;

                case 2:
                    comboBox1.Text = "3";
                    break;

                case 3:
                    comboBox1.Text = "4";
                    break;

            }
            int uyelik = Convert.ToInt32(comboBox1.Text);
            veriekle.Parameters.AddWithValue("paketid", uyelik);
            veriekle.Parameters.AddWithValue("bitistarih", dateTimePicker2.Value);
            veriekle.Parameters.AddWithValue("telno", textBox4.Text.Trim());
            veriekle.Parameters.AddWithValue("email", textBox5.Text.Trim());
            veriekle.Parameters.AddWithValue("aciklama", textBox7.Text.Trim()   );
            veriekle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Üye Kaydedildi !");
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.Checked = false;
            dateTimePicker2.Checked = false;   
            textBox4.Clear();
            textBox5.Clear();
            textBox7.Clear();

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }

  

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text.ToUpper();
            textBox2.SelectionStart = textBox2.Text.Length;
            textBox3.Text = textBox3.Text.ToUpper();
            textBox3.SelectionStart = textBox3.Text.Length; 
            textBox7.Text = textBox7.Text.ToUpper();
            textBox7.SelectionStart = textBox7.Text.Length;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
