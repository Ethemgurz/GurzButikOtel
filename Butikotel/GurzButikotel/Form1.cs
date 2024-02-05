using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GurzButikotel
{
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text=="admin" && txtSifre.Text=="123456") 
            {
               FrmAnaForm fr = new FrmAnaForm();
               fr.Show();
               this.Hide();
            
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı");
            
            }
        }
    }
}
/*"Giriş Yap" butonu (BtnGirisYap), kullanıcının girdiği kullanıcı adı ve şifreyi kontrol eder.
Eğer kullanıcı adı "admin" ve şifre "123456" ise, ana formu (FrmAnaForm) oluşturur ve gösterir. Ardından, giriş formunu gizler.
Eğer kullanıcı adı veya şifre hatalı ise, bir hata iletişim kutusu görüntüler.*/
