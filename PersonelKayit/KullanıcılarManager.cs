using System.Data.SqlClient;

namespace PersonelKayit
{
    class KullanıcılarManager
    {
        SqlConnection baglanti;
        bool kontrol = false;
        public KullanıcılarManager()
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-0TMEF2S\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        }


        public bool KontrolEt()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from tbl_Kullanici where KullaniciAd=@kullaniciAd and Parola=@parola", baglanti);
            komut.Parameters.AddWithValue("@kullaniciAd", Kullanıcılar.kullaniciAdi);
            komut.Parameters.AddWithValue("@parola", Kullanıcılar.parola);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                kontrol = true;
            }
            baglanti.Close();
            return kontrol;
        }
    }
}
