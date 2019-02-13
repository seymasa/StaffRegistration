namespace PersonelKayit
{
    class Personel
    {
        public static int id { get; set; }
        public static string ad { get; set; }
        public static string soyad { get; set; }
        public static string sehir { get; set; }
        public static string meslek { get; set; }
        public static bool durum { get; set; }
        public static decimal maas { get; set; }

        public Personel(int idi) {
            id = idi;
        }

        public Personel() { }
        public Personel(int idi,string adi) : this(id) { ad = adi; }
        public Personel(int idi,string ad, string soyadi) : this(id,ad) { soyad = soyadi; }
        public Personel(int idi,string ad, string soyad, string sehiri) : this(id,ad,soyad) { sehir = sehiri; }
        public Personel(int idi,string ad, string soyad, string sehir, string mesleki) : this(id,ad,soyad,sehir) { meslek = mesleki; }
        public Personel(int idi,string ad, string soyad, string sehir, string meslek, bool durumu) : this(id,ad,soyad,sehir,meslek) { durum = durumu; }
        public Personel(int idi,string ad, string soyad, string sehir, string meslek, bool durum, decimal maasi) : this(id, ad, soyad, sehir, meslek,durum) { maas = maasi; }



    }
}
