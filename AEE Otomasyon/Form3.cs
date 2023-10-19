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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=aeeotomasyon; user ID=postgres; password=1234");
        private void Form3_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "SELECT * FROM uyeler";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand ara = new NpgsqlCommand("SELECT * FROM uyeler WHERE uyead LIKE '%"+textBox1.Text.Trim() + "%' AND uyesoyad LIKE '%"+textBox2.Text.Trim()+ "%' ",baglanti);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(ara);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
            if (button4.Enabled == false)
            {
                button4.Enabled = true;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string date = ("SELECT * FROM uyeler WHERE bitistarih<@simdikitarih");
            DataTable dt = new DataTable();
            DateTime dtime = DateTime.Now;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(date, baglanti);
            da.SelectCommand.Parameters.AddWithValue("@simdikitarih",dtime);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string date = ("SELECT * FROM uyeler WHERE bitistarih>@simdikitarih");
            DataTable dt = new DataTable();
            DateTime dtime = DateTime.Now;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(date, baglanti);
            da.SelectCommand.Parameters.AddWithValue("@simdikitarih", dtime);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.ToUpper();
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox2.Text = textBox2.Text.ToUpper();
            textBox2.SelectionStart = textBox2.Text.Length;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            textBox27.Text = "";
            textBox28.Text = "";
            textBox29.Text = "";
            textBox30.Text = "";
            textBox31.Text = "";
            textBox32.Text = "";
            textBox33.Text = "";
            textBox34.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";
            textBox37.Text = "";
            textBox38.Text = "";
            textBox39.Text = "";
            textBox40.Text = "";
            textBox41.Text = "";
            textBox42.Text = "";
            textBox43.Text = "";
            textBox44.Text = "";
            textBox45.Text = "";
            textBox46.Text = "";
            textBox47.Text = "";
            textBox48.Text = "";
            textBox49.Text = "";
            textBox50.Text = "";
            textBox51.Text = "";
            textBox52.Text = "";
            textBox53.Text = "";
            textBox54.Text = "";
            textBox55.Text = "";
            textBox56.Text = "";
            textBox57.Text = "";
            textBox58.Text = "";



            int secilialan = dataGridView1.SelectedCells[0].RowIndex;   
            string id = dataGridView1.Rows[secilialan].Cells[0].Value.ToString();
            string ad = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string soyad = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string telno = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            string mail = dataGridView1.Rows[secilialan].Cells[5].Value.ToString();
            string paket = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string btarih = dataGridView1.Rows[secilialan].Cells[7].Value.ToString();
            string bttarih = dataGridView1.Rows[secilialan].Cells[8].Value.ToString();

            textBox8.Text = id;
            textBox3.Text = ad;
            textBox4.Text = soyad;
            textBox5.Text = telno;
            textBox6.Text = mail;
            textBox7.Text = paket;
            dateTimePicker1.Text = btarih;
            dateTimePicker2.Text = bttarih;
            
            /*textBox8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString(); 
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();*/

            baglanti.Open();
            NpgsqlCommand  sorgu = new NpgsqlCommand("SELECT * FROM baslangıc WHERE uyeid=(SELECT uyeid FROM uyeler WHERE uyeid='" + id + "')",baglanti);
            NpgsqlDataReader read = sorgu.ExecuteReader();
            while (read.Read())
            {
                textBox9.Text = read["kilo"].ToString();
                textBox10.Text = read["boy"].ToString();
                textBox11.Text = read["omuz"].ToString();
                textBox12.Text = read["gögüs"].ToString();
                textBox13.Text = read["bel"].ToString();
                textBox14.Text = read["sagbacak"].ToString();
                textBox15.Text = read["solbacak"].ToString();
                textBox16.Text = read["basen"].ToString();
                textBox17.Text = read["sagkol"].ToString();
                textBox18.Text = read["solkol"].ToString();

                
                
            }
            
            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand sorgu2 = new NpgsqlCommand("SELECT * FROM ay1 WHERE uyeid=(SELECT uyeid FROM uyeler WHERE uyeid='" + id + "')", baglanti);
            NpgsqlDataReader read2 = sorgu2.ExecuteReader();
            while (read2.Read())
            {
                textBox28.Text = read2["kilo"].ToString();
                textBox27.Text = read2["boy"].ToString();
                textBox26.Text = read2["omuz"].ToString();
                textBox25.Text = read2["gögüs"].ToString();
                textBox24.Text = read2["bel"].ToString();
                textBox23.Text = read2["sagbacak"].ToString();
                textBox22.Text = read2["solbacak"].ToString();
                textBox21.Text = read2["basen"].ToString();
                textBox20.Text = read2["sagkol"].ToString();
                textBox19.Text = read2["solkol"].ToString();



            }

            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand sorgu3 = new NpgsqlCommand("SELECT * FROM ay3 WHERE uyeid=(SELECT uyeid FROM uyeler WHERE uyeid='" + id + "')", baglanti);
            NpgsqlDataReader read3 = sorgu3.ExecuteReader();
            while (read3.Read())
            {
                textBox38.Text = read3["kilo"].ToString();
                textBox37.Text = read3["boy"].ToString();
                textBox36.Text = read3["omuz"].ToString();
                textBox35.Text = read3["gögüs"].ToString();
                textBox34.Text = read3["bel"].ToString();
                textBox33.Text = read3["sagbacak"].ToString();
                textBox32.Text = read3["solbacak"].ToString();
                textBox31.Text = read3["basen"].ToString();
                textBox30.Text = read3["sagkol"].ToString();
                textBox29.Text = read3["solkol"].ToString();



            }

            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand sorgu4 = new NpgsqlCommand("SELECT * FROM ay6 WHERE uyeid=(SELECT uyeid FROM uyeler WHERE uyeid='" + id + "')", baglanti);
            NpgsqlDataReader read4 = sorgu4.ExecuteReader();
            while (read4.Read())
            {
                textBox48.Text = read4["kilo"].ToString();
                textBox47.Text = read4["boy"].ToString();
                textBox46.Text = read4["omuz"].ToString();
                textBox45.Text = read4["gögüs"].ToString();
                textBox44.Text = read4["bel"].ToString();
                textBox43.Text = read4["sagbacak"].ToString();
                textBox42.Text = read4["solbacak"].ToString();
                textBox41.Text = read4["basen"].ToString();
                textBox40.Text = read4["sagkol"].ToString();
                textBox39.Text = read4["solkol"].ToString();



            }

            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand sorgu5 = new NpgsqlCommand("SELECT * FROM ay12 WHERE uyeid=(SELECT uyeid FROM uyeler WHERE uyeid='" + id + "')", baglanti);
            NpgsqlDataReader read5 = sorgu5.ExecuteReader();
            while (read5.Read())
            {
                textBox58.Text = read5["kilo"].ToString();
                textBox57.Text = read5["boy"].ToString();
                textBox56.Text = read5["omuz"].ToString();
                textBox55.Text = read5["gögüs"].ToString();
                textBox54.Text = read5["bel"].ToString();
                textBox53.Text = read5["sagbacak"].ToString();
                textBox52.Text = read5["solbacak"].ToString();
                textBox51.Text = read5["basen"].ToString();
                textBox50.Text = read5["sagkol"].ToString();
                textBox49.Text = read5["solkol"].ToString();



            }

            baglanti.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string id = dataGridView1.Rows[secilialan].Cells[0].Value.ToString();
            baglanti.Open();
            NpgsqlCommand guncelle = new NpgsqlCommand("UPDATE uyeler SET uyead='"+textBox3.Text+"',uyesoyad='"+textBox4.Text+"',telno='"+textBox5.Text+"',email='"+textBox6.Text+"',paketid='"+textBox7.Text+"',baslatarih='"+dateTimePicker1.Value+"',bitistarih='"+dateTimePicker2.Value+"' WHERE uyeid='"+id+"'",baglanti);
            guncelle.ExecuteNonQuery();
            string sorgu = "SELECT * FROM uyeler";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
            button11.Enabled = false;
            this.Controls.Clear();
            this.InitializeComponent();
            button4.Enabled = false;
            MessageBox.Show("Bilgiler Güncellendi .");
            


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text.ToUpper();
            textBox3.SelectionStart = textBox3.Text.Length;
        }

        

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text.ToUpper();
            textBox5.SelectionStart = textBox5.Text.Length;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = textBox4.Text.ToUpper();
            textBox4.SelectionStart = textBox4.Text.Length;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox7.Text = textBox7.Text.ToUpper();
            textBox7.SelectionStart = textBox7.Text.Length;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox8.Text);
            int kilo = Convert.ToInt32(textBox9.Text);
            int boy = Convert.ToInt32(textBox10.Text);
            int omuz = Convert.ToInt32(textBox11.Text);
            int gögüs = Convert.ToInt32(textBox12.Text);
            int bel = Convert.ToInt32(textBox13.Text);
            int sagbacak = Convert.ToInt32(textBox14.Text);
            int solbacak = Convert.ToInt32(textBox15.Text);
            int basen = Convert.ToInt32(textBox16.Text);
            int sagkol = Convert.ToInt32(textBox17.Text);
            int solkol = Convert.ToInt32(textBox18.Text);
            baglanti.Open();
            NpgsqlCommand veriekle = new NpgsqlCommand("INSERT INTO baslangıc (uyeid,kilo,boy,omuz,gögüs,bel,sagbacak,solbacak,basen,sagkol,solkol) VALUES (@uyeid,@kilo,@boy,@omuz,@gögüs,@bel,@sagbacak,@solbacak,@basen,@sagkol,@solkol)");
            veriekle.Connection = baglanti;
            veriekle.Parameters.AddWithValue("uyeid", id);
            veriekle.Parameters.AddWithValue("uyeid", id);
            veriekle.Parameters.AddWithValue("kilo", kilo);
            veriekle.Parameters.AddWithValue("boy", boy);
            veriekle.Parameters.AddWithValue("omuz", omuz);
            veriekle.Parameters.AddWithValue("gögüs", gögüs);
            veriekle.Parameters.AddWithValue("bel", bel);
            veriekle.Parameters.AddWithValue("sagbacak", sagbacak);
            veriekle.Parameters.AddWithValue("solbacak", solbacak);
            veriekle.Parameters.AddWithValue("basen", basen);
            veriekle.Parameters.AddWithValue("sagkol", sagkol);
            veriekle.Parameters.AddWithValue("solkol", solkol);


            veriekle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ölçüler Kaydedildi !");
            
            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox8.Text);
            int kilo = Convert.ToInt32(textBox28.Text);
            int boy = Convert.ToInt32(textBox27.Text);
            int omuz = Convert.ToInt32(textBox26.Text);
            int gögüs = Convert.ToInt32(textBox25.Text);
            int bel = Convert.ToInt32(textBox24.Text);
            int sagbacak = Convert.ToInt32(textBox23.Text);
            int solbacak = Convert.ToInt32(textBox22.Text);
            int basen = Convert.ToInt32(textBox21.Text);
            int sagkol = Convert.ToInt32(textBox20.Text);
            int solkol = Convert.ToInt32(textBox19.Text);
            baglanti.Open();
            NpgsqlCommand veriekle = new NpgsqlCommand("INSERT INTO ay1 (uyeid,kilo,boy,omuz,gögüs,bel,sagbacak,solbacak,basen,sagkol,solkol) VALUES (@uyeid,@kilo,@boy,@omuz,@gögüs,@bel,@sagbacak,@solbacak,@basen,@sagkol,@solkol)");
            veriekle.Connection = baglanti;
            veriekle.Parameters.AddWithValue("uyeid", id);
            veriekle.Parameters.AddWithValue("kilo", kilo);
            veriekle.Parameters.AddWithValue("boy", boy);
            veriekle.Parameters.AddWithValue("omuz", omuz);
            veriekle.Parameters.AddWithValue("gögüs", gögüs);
            veriekle.Parameters.AddWithValue("bel", bel);
            veriekle.Parameters.AddWithValue("sagbacak", sagbacak);
            veriekle.Parameters.AddWithValue("solbacak", solbacak);
            veriekle.Parameters.AddWithValue("basen", basen);
            veriekle.Parameters.AddWithValue("sagkol", sagkol);
            veriekle.Parameters.AddWithValue("solkol", solkol);


            veriekle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ölçüler Kaydedildi !");
            
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox8.Text);
            int kilo = Convert.ToInt32(textBox38.Text);
            int boy = Convert.ToInt32(textBox37.Text);
            int omuz = Convert.ToInt32(textBox36.Text);
            int gögüs = Convert.ToInt32(textBox35.Text);
            int bel = Convert.ToInt32(textBox34.Text);
            int sagbacak = Convert.ToInt32(textBox33.Text);
            int solbacak = Convert.ToInt32(textBox32.Text);
            int basen = Convert.ToInt32(textBox31.Text);
            int sagkol = Convert.ToInt32(textBox30.Text);
            int solkol = Convert.ToInt32(textBox29.Text);
            baglanti.Open();
            NpgsqlCommand veriekle = new NpgsqlCommand("INSERT INTO ay3 (uyeid,kilo,boy,omuz,gögüs,bel,sagbacak,solbacak,basen,sagkol,solkol) VALUES (@uyeid,@kilo,@boy,@omuz,@gögüs,@bel,@sagbacak,@solbacak,@basen,@sagkol,@solkol)");
            veriekle.Connection = baglanti;
            veriekle.Parameters.AddWithValue("uyeid", id);
            veriekle.Parameters.AddWithValue("uyeid", id);
            veriekle.Parameters.AddWithValue("kilo", kilo);
            veriekle.Parameters.AddWithValue("boy", boy);
            veriekle.Parameters.AddWithValue("omuz", omuz);
            veriekle.Parameters.AddWithValue("gögüs", gögüs);
            veriekle.Parameters.AddWithValue("bel", bel);
            veriekle.Parameters.AddWithValue("sagbacak", sagbacak);
            veriekle.Parameters.AddWithValue("solbacak", solbacak);
            veriekle.Parameters.AddWithValue("basen", basen);
            veriekle.Parameters.AddWithValue("sagkol", sagkol);
            veriekle.Parameters.AddWithValue("solkol", solkol);


            veriekle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ölçüler Kaydedildi !");
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox8.Text);
            int kilo = Convert.ToInt32(textBox48.Text);
            int boy = Convert.ToInt32(textBox47.Text);
            int omuz = Convert.ToInt32(textBox46.Text);
            int gögüs = Convert.ToInt32(textBox45.Text);
            int bel = Convert.ToInt32(textBox44.Text);
            int sagbacak = Convert.ToInt32(textBox43.Text);
            int solbacak = Convert.ToInt32(textBox42.Text);
            int basen = Convert.ToInt32(textBox41.Text);
            int sagkol = Convert.ToInt32(textBox40.Text);
            int solkol = Convert.ToInt32(textBox39.Text);
            baglanti.Open();
            NpgsqlCommand veriekle = new NpgsqlCommand("INSERT INTO ay6 (uyeid,kilo,boy,omuz,gögüs,bel,sagbacak,solbacak,basen,sagkol,solkol) VALUES (@uyeid,@kilo,@boy,@omuz,@gögüs,@bel,@sagbacak,@solbacak,@basen,@sagkol,@solkol)");
            veriekle.Connection = baglanti;
            veriekle.Parameters.AddWithValue("uyeid", id);
            veriekle.Parameters.AddWithValue("uyeid", id);
            veriekle.Parameters.AddWithValue("kilo", kilo);
            veriekle.Parameters.AddWithValue("boy", boy);
            veriekle.Parameters.AddWithValue("omuz", omuz);
            veriekle.Parameters.AddWithValue("gögüs", gögüs);
            veriekle.Parameters.AddWithValue("bel", bel);
            veriekle.Parameters.AddWithValue("sagbacak", sagbacak);
            veriekle.Parameters.AddWithValue("solbacak", solbacak);
            veriekle.Parameters.AddWithValue("basen", basen);
            veriekle.Parameters.AddWithValue("sagkol", sagkol);
            veriekle.Parameters.AddWithValue("solkol", solkol);


            veriekle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ölçüler Kaydedildi !");
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox8.Text);
            int kilo = Convert.ToInt32(textBox58.Text);
            int boy = Convert.ToInt32(textBox57.Text);
            int omuz = Convert.ToInt32(textBox56.Text);
            int gögüs = Convert.ToInt32(textBox55.Text);
            int bel = Convert.ToInt32(textBox54.Text);
            int sagbacak = Convert.ToInt32(textBox53.Text);
            int solbacak = Convert.ToInt32(textBox52.Text);
            int basen = Convert.ToInt32(textBox51.Text);
            int sagkol = Convert.ToInt32(textBox50.Text);
            int solkol = Convert.ToInt32(textBox49.Text);
            baglanti.Open();
            NpgsqlCommand veriekle = new NpgsqlCommand("INSERT INTO ay12 (uyeid,kilo,boy,omuz,gögüs,bel,sagbacak,solbacak,basen,sagkol,solkol) VALUES (@uyeid,@kilo,@boy,@omuz,@gögüs,@bel,@sagbacak,@solbacak,@basen,@sagkol,@solkol)");
            veriekle.Connection = baglanti;
            veriekle.Parameters.AddWithValue("uyeid", id);
            veriekle.Parameters.AddWithValue("uyeid", id);
            veriekle.Parameters.AddWithValue("kilo", kilo);
            veriekle.Parameters.AddWithValue("boy", boy);
            veriekle.Parameters.AddWithValue("omuz", omuz);
            veriekle.Parameters.AddWithValue("gögüs", gögüs);
            veriekle.Parameters.AddWithValue("bel", bel);
            veriekle.Parameters.AddWithValue("sagbacak", sagbacak);
            veriekle.Parameters.AddWithValue("solbacak", solbacak);
            veriekle.Parameters.AddWithValue("basen", basen);
            veriekle.Parameters.AddWithValue("sagkol", sagkol);
            veriekle.Parameters.AddWithValue("solkol", solkol);


            veriekle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ölçüler Kaydedildi !");
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string id = dataGridView1.Rows[secilialan].Cells[0].Value.ToString();
            baglanti.Open();
            NpgsqlCommand guncelle = new NpgsqlCommand("DELETE FROM baslangıc WHERE uyeid='"+id+"'", baglanti);
            NpgsqlCommand guncelle1 = new NpgsqlCommand("DELETE FROM ay1 WHERE uyeid='" + id + "'", baglanti);
            NpgsqlCommand guncelle2 = new NpgsqlCommand("DELETE FROM ay3 WHERE uyeid='" + id + "'", baglanti);
            NpgsqlCommand guncelle3 = new NpgsqlCommand("DELETE FROM ay6 WHERE uyeid='" + id + "'", baglanti);
            NpgsqlCommand guncelle4 = new NpgsqlCommand("DELETE FROM ay12 WHERE uyeid='" + id + "'", baglanti);
            NpgsqlCommand guncelle5 = new NpgsqlCommand("DELETE FROM uyeler WHERE uyeid='" + id + "'", baglanti);

            guncelle.ExecuteNonQuery();
            guncelle1.ExecuteNonQuery();
            guncelle2.ExecuteNonQuery();
            guncelle3.ExecuteNonQuery();
            guncelle4.ExecuteNonQuery();
            guncelle5.ExecuteNonQuery();
            string sorgu = "SELECT * FROM uyeler";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            button11.Enabled = true;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Form5 fr5 = new Form5();
            fr5.textBox2.Text = textBox3.Text+" "+textBox4.Text;
            fr5.textBox1.Text = textBox6.Text;
            fr5.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
