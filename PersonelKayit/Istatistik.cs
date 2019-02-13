using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PersonelKayit
{
    public partial class Istatistik : Form
    {
        public Istatistik()
        {
            InitializeComponent();
        }

        private void Istatistik_Load(object sender, EventArgs e)
        {
            PersonelManager pm = new PersonelManager();
            lbl_Top.Text = pm.KisiSay().ToString();
            lbl_Evli.Text = pm.EvliPersonel().ToString();
            lbl_Bekar.Text = pm.BekarPersonel().ToString();
            lbl_Sehir.Text = pm.FarkıSehirSayisi().ToString();
            lbl_TopMaas.Text = pm.TopMaas().ToString();
            lbl_OrtMaas.Text = pm.OrtMaas().ToString();

        }
    }
}
