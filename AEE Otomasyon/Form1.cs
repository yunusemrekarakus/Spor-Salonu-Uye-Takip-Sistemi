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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost;port=5432; Database=aeeotomasyon; user ID=postgres; password=1234");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string sorgu = ("SELECT * FROM admin WHERE uname=@uname AND passwd=@passwd");
                NpgsqlParameter prm1 = new NpgsqlParameter("uname",textBox1.Text.Trim());
                NpgsqlParameter prm2 = new NpgsqlParameter("passwd",textBox2.Text.Trim());
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);
                da.Fill(dt);
                
                
                if (dt.Rows.Count > 0)
                {
                    baglanti.Close();
                    this.Controls.Clear();
                    this.InitializeComponent();
                    Form2 fr = new Form2();
                    fr.Show();
                    
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Giriş");
                baglanti.Close();
                this.Controls.Clear();
                this.InitializeComponent();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
