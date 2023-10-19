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
using System.Net.Mail;
using System.Net;


namespace AEE_Otomasyon
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        MailMessage eposta = new MailMessage();

        void MailGonder()
        {
            eposta.From = new MailAddress("aeeotomasyon@outlook.com");
            eposta.To.Add(textBox1.Text.ToString());
            eposta.Subject = textBox3.Text.ToString();
            eposta.Body = textBox4.Text.ToString();
            eposta.Attachments.Add(new Attachment(textBox5.Text));

            SmtpClient smtp = new SmtpClient("outlook.com");

            smtp.Credentials = new System.Net.NetworkCredential("aeeotomasyon@outlook.com","Aeeotobizimisimiz5");
            smtp.Host = "smtp.outlook.com";
            smtp.EnableSsl = true;
            smtp.Port = 587;
            

            smtp.Send(eposta);
            MessageBox.Show("Mail Gönderildi.");

        }


        private void Form5_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Göndereceğiniz Dosyayı Seçiniz.";
            ofd.ShowDialog();
            textBox5.Text = ofd.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MailGonder();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
