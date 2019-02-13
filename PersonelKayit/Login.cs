using System;
using System.Windows.Forms;

namespace PersonelKayit
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kullanıcılar.kullaniciAdi = tb_KAd.Text;
            Kullanıcılar.parola = tb_pass.Text;
            KullanıcılarManager km = new KullanıcılarManager();
            AnaForm anaform = new AnaForm();
            bool kontrol = km.KontrolEt();
            if (kontrol == true)
            {
                anaform.Show();
                this.Hide();
            }
            else MessageBox.Show("Hatalı Bilgi Girildi!");
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
