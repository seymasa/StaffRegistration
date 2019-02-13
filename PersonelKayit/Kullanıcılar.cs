namespace PersonelKayit
{
    class Kullanıcılar
    {
        public static string kullaniciAdi { get; set; }
        public static string parola { get; set; }

        public Kullanıcılar() { }
        public Kullanıcılar(string _kullanciAdi) : this() { kullaniciAdi = _kullanciAdi; }
        public Kullanıcılar(string _kullaniciAdi, string _parola) : this(_kullaniciAdi) { parola = _parola; }
    }
}
