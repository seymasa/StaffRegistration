using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;

namespace PersonelKayit
{
    class PersonelManager
    {
        private SqlConnection baglanti;
        private string toplam;
        private List<string> iller = new List<string>();

        public PersonelManager()
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-0TMEF2S\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        }

        public void Kaydet()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into tbl_personel(ID,Ad,Soyad,Sehir,Maas,Durum,Meslek) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);

            komut.Parameters.AddWithValue("@p1", Personel.id);
            komut.Parameters.AddWithValue("@p2", Personel.ad);
            komut.Parameters.AddWithValue("@p3", Personel.soyad);
            komut.Parameters.AddWithValue("@p4", Personel.sehir);
            komut.Parameters.AddWithValue("@p5", Personel.maas);
            komut.Parameters.AddWithValue("@p6", Personel.durum);
            komut.Parameters.AddWithValue("@p7", Personel.meslek);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public void Sil()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from tbl_personel where ID=@a", baglanti);
            komut.Parameters.AddWithValue("@a", Personel.id);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public void Guncelle()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update tbl_personel set  Ad=@a1,Soyad=@a2,Sehir=@a3,Maas=@a4,Durum=@a5,Meslek=@a6 where ID=@a7", baglanti);
            komut.Parameters.AddWithValue("@a1", Personel.ad);
            komut.Parameters.AddWithValue("@a2", Personel.soyad);
            komut.Parameters.AddWithValue("@a3", Personel.sehir);
            komut.Parameters.AddWithValue("@a4", Personel.maas);
            komut.Parameters.AddWithValue("@a5", Personel.durum);
            komut.Parameters.AddWithValue("@a6", Personel.meslek);
            komut.Parameters.AddWithValue("@a7", Personel.id);
            komut.ExecuteNonQuery();
            Console.WriteLine(komut.ExecuteNonQuery());
            baglanti.Close();
        }

        public string KisiSay()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select count(*) from tbl_personel", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read()) { toplam = dr[0].ToString(); } //sutun sayısı oradaki dr 0 NOT: Tek sutun donuyor zaten o da 0. indexte
            baglanti.Close();
            return toplam;
        }

        public string EvliPersonel()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select count(*) from tbl_personel where Durum = 'True'", baglanti);
            SqlDataReader dr1 = komut.ExecuteReader();
            while (dr1.Read()) { toplam = dr1[0].ToString(); }
            baglanti.Close();
            return toplam;
        }

        public string BekarPersonel()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select count(*) from tbl_personel where Durum = 'False'", baglanti);
            SqlDataReader dr1 = komut.ExecuteReader();
            while (dr1.Read()) { toplam = dr1[0].ToString(); }
            baglanti.Close();
            return toplam;
        }

        public string FarkıSehirSayisi()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select distinct Sehir from tbl_personel", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            int iter = 0;
            while (dr.Read()) { iter++; toplam = iter.ToString(); }
            baglanti.Close();
            return toplam;

        }

        public string TopMaas()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select sum(Maas) from tbl_personel ", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read()) { toplam = dr[0].ToString(); }
            baglanti.Close();
            return toplam;
        }

        public string OrtMaas()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select avg(Maas) from tbl_personel", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read()) { toplam = dr[0].ToString(); }
            baglanti.Close();
            return toplam;
        }

        public List<string> İllerBas()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from iller", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read()) { iller.Add(dr[1].ToString()); }
            return iller;
        }


        ~PersonelManager()
        {
            try
            {
                baglanti.Close();
            }
            catch (Exception) { Thread.Sleep(2); }
        }
    }
}
