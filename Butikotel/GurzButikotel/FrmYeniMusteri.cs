using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Interop;



namespace GurzButikotel
{
    public partial class FrmYeniMusteri : Form
    {
        public FrmYeniMusteri()
        {
            InitializeComponent();
        }

        
        SqlConnection baglanti = new SqlConnection(@"Data Source = MSI\SQLEXPRESS; Initial Catalog = GurzButikOtel; Integrated Security = True; Encrypt=False");

        //Butonlar, farklı odaları seçmek için kullanılır ve tıklanma olayları, TxtOdaNo metin kutusuna oda numarasını yerleştirir.
        private void BtnOda101_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "101";
        }

        private void BtnOda102_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "102";
        }

        private void BtnOda103_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "103";
        }

        private void BtnOda104_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "104";
        }

        private void BtnOda105_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "105";
        }

        private void BtnOda106_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "106";
        }

        private void BtnOda107_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "107";
        }

        private void BtnOda108_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "108";
        }

        private void BtnOda109_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "109";
        }

        private void BtnOda110_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "110";
        }
        //"BosOda" ve "DoluOda" butonları, kullanıcıya boş ve dolu odaları göstermek için bilgilendirme mesajları verir.
        private void BtnBosOda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeşil Renkli Butonlar Boş Odaları Gösterir");
        }

        private void BtnDoluOda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kırmızı Renkli Butonlar Dolu Odaları Gösterir");
        }
        //DtpGirisTarihi ve DtpCikisTarihi denetimleri, müşterinin giriş ve çıkış tarihlerini seçmesine olanak tanır. Bu tarihler arasındaki fark hesaplanarak, kalınacak gün sayısına dayalı bir ücret hesaplanır.
        private void DtpCikisTarihi_ValueChanged(object sender, EventArgs e)
        {
            int Ucret;
            DateTime KucukTarih = Convert.ToDateTime(DtpGirisTarihi.Text);
            DateTime BuyukTarih = Convert.ToDateTime(DtpCikisTarihi.Text);

            TimeSpan Sonuc = BuyukTarih - KucukTarih;

            label11.Text = Sonuc.TotalDays.ToString();

            Ucret = Convert.ToInt32(label11.Text) * 50;
            txtUcret.Text = Ucret.ToString();
            
        }
        //"Kaydet" butonu, müşteri bilgilerini veritabanına kaydeder. Bu işlem için parametrelerle güvenli bir şekilde SQL sorgusu oluşturulur ve veritabanına gönderilir.
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            
            {
                try
                {
                    baglanti.Open();

                    SqlCommand komut = new SqlCommand("INSERT INTO MusteriEkle (Adi, Soyadi, Cinsiyet, Telefon, Email, TC, OdaNo, Ucret, GirisTarihi, CikisTarihi) VALUES (@Adi, @Soyadi, @Cinsiyet, @Telefon, @Email, @TC, @OdaNo, @Ucret, @GirisTarihi, @CikisTarihi)", baglanti);

                    // Parametreleri ekleyerek güvenli bir şekilde sorguyu çalıştırma
                    komut.Parameters.AddWithValue("@Adi", TxtAdi.Text);
                    komut.Parameters.AddWithValue("@Soyadi", TxtSoyadi.Text);
                    komut.Parameters.AddWithValue("@Cinsiyet", comboBox1.Text);
                    komut.Parameters.AddWithValue("@Telefon", MskTxtTelefon.Text);
                    komut.Parameters.AddWithValue("@Email", TxtMail.Text);
                    komut.Parameters.AddWithValue("@TC", textBox6.Text);
                    komut.Parameters.AddWithValue("@OdaNo", TxtOdaNo.Text);
                    komut.Parameters.AddWithValue("@Ucret", txtUcret.Text);
                    komut.Parameters.AddWithValue("@GirisTarihi", DtpGirisTarihi.Value);
                    komut.Parameters.AddWithValue("@CikisTarihi", DtpCikisTarihi.Value);

                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Müşteri başarıyla kaydedildi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }






        }


        //FrmYeniMusteri_Load olayı, form yüklendiğinde çalışır ve mevcut oda durumunu kontrol eder. Her oda için ilgili tabloyu sorgular ve odanın dolu veya boş olduğunu belirler. Dolu odalar kırmızı, boş odalar ise yeşil renkte görüntülenir.
        private void FrmYeniMusteri_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from Oda101", baglanti);
            SqlDataReader oku1 = komut1.ExecuteReader();

            while (oku1.Read())
            {
                BtnOda101.Text = oku1["Adi"].ToString() + " " + oku1["Soyadi"].ToString();

            }
            baglanti.Close();
            if (BtnOda101.Text != "101")
            {
                BtnOda101.BackColor = Color.Red;
            }

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from Oda102", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();

            while (oku2.Read())
            {
                BtnOda102.Text = oku2["Adi"].ToString() + " " + oku2["Soyadi"].ToString();

            }
            baglanti.Close();
            if (BtnOda102.Text != "102")
            {
                BtnOda102.BackColor = Color.Red;
            }

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select * from Oda103", baglanti);
            SqlDataReader oku3 = komut3.ExecuteReader();

            while (oku3.Read())
            {
                BtnOda103.Text = oku3["Adi"].ToString() + " " + oku3["Soyadi"].ToString();

            }
            baglanti.Close();
            if (BtnOda103.Text != "103")
            {
                BtnOda103.BackColor = Color.Red;
            }
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select * from Oda104", baglanti);
            SqlDataReader oku4 = komut4.ExecuteReader();

            while (oku4.Read())
            {
                BtnOda104.Text = oku4["Adi"].ToString() + " " + oku4["Soyadi"].ToString();

            }
            baglanti.Close();
            if (BtnOda104.Text != "104")
            {
                BtnOda104.BackColor = Color.Red;
            }
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select * from Oda105", baglanti);
            SqlDataReader oku5 = komut5.ExecuteReader();

            while (oku5.Read())
            {
                BtnOda105.Text = oku5["Adi"].ToString() + " " + oku5["Soyadi"].ToString();

            }
            baglanti.Close();
            if (BtnOda105.Text != "105")
            {
                BtnOda105.BackColor = Color.Red;
            }

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select * from Oda106", baglanti);
            SqlDataReader oku6 = komut6.ExecuteReader();

            while (oku1.Read())
            {
                BtnOda101.Text = oku6["Adi"].ToString() + " " + oku6["Soyadi"].ToString();

            }
            baglanti.Close();
            if (BtnOda106.Text != "106")
            {
                BtnOda106.BackColor = Color.Red;
            }

            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("select * from Oda107", baglanti);
            SqlDataReader oku7 = komut7.ExecuteReader();

            while (oku1.Read())
            {
                BtnOda107.Text = oku7["Adi"].ToString() + " " + oku7["Soyadi"].ToString();

            }
            baglanti.Close();
            if (BtnOda107.Text != "107")
            {
                BtnOda107.BackColor = Color.Red;
            }

            baglanti.Open();
            SqlCommand komut8 = new SqlCommand("select * from Oda108", baglanti);
            SqlDataReader oku8 = komut8.ExecuteReader();

            while (oku1.Read())
            {
                BtnOda101.Text = oku8["Adi"].ToString() + " " + oku8["Soyadi"].ToString();

            }
            baglanti.Close();
            if (BtnOda108.Text != "108")
            {
                BtnOda108.BackColor = Color.Red;
            }

            baglanti.Open();
            SqlCommand komut9 = new SqlCommand("select * from Oda109", baglanti);
            SqlDataReader oku9 = komut9.ExecuteReader();

            while (oku1.Read())
            {
                BtnOda109.Text = oku9["Adi"].ToString() + " " + oku9["Soyadi"].ToString();

            }
            baglanti.Close();
            if (BtnOda109.Text != "109")
            {
                BtnOda109.BackColor = Color.Red;
            }

            baglanti.Open();
            SqlCommand komut10 = new SqlCommand("select * from Oda110", baglanti);
            SqlDataReader oku10 = komut10.ExecuteReader();

            while (oku1.Read())
            {
                BtnOda110.Text = oku10["Adi"].ToString() + " " + oku10["Soyadi"].ToString();

            }
            baglanti.Close();
            if (BtnOda110.Text != "110")
            {
                BtnOda110.BackColor = Color.Red;
            }
        }
    }
}
//Data Source=MSI\SQLEXPRESS;Initial Catalog=GurzButikOtel;Integrated Security=True;Encrypt=False
