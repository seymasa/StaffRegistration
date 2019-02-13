using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PersonelKayit
{
    public partial class AnaForm : Form
    {

        public AnaForm()
        {
            InitializeComponent();
        }

        Personel p = new Personel();

        private void Form1_Load(object sender, EventArgs e)
        {
            PersonelManager pm = new PersonelManager();
            tbl_personelTableAdapter.Fill(this.personelVeriTabaniDataSet1.tbl_personel);
            List<string> iller = new List<string>();
            iller = pm.İllerBas();
            foreach (string i in iller)
            {
                cb_Sehir.Items.Add(i);
            }
        }

        private void btn_Listele_Click(object sender, EventArgs e)
        {
            tbl_personelTableAdapter.Fill(this.personelVeriTabaniDataSet1.tbl_personel);
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            PersonelManager pm = new PersonelManager();
            Personel.id = Convert.ToInt16(tb_Id.Text);
            Personel.ad = tb_Ad.Text;
            Personel.soyad = tb_Soyad.Text;
            Personel.sehir = cb_Sehir.Text;
            Personel.maas = Convert.ToDecimal(tb_Maas.Text);
            if (rb_Evli.Checked)
            {
                Personel.durum = true;
            }
            else Personel.durum = false;
            Personel.meslek = tb_Meslek.Text;
            pm.Kaydet();
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            PersonelManager pm = new PersonelManager();
            Personel.id = Convert.ToInt16(tb_Id.Text);
            pm.Sil();
            tbl_personelTableAdapter.Fill(this.personelVeriTabaniDataSet1.tbl_personel);

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex; //secilen satırın 0. indexi yani id si
            tb_Id.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            tb_Ad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            tb_Soyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cb_Sehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            tb_Maas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            tb_Meslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            string durumum = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            if (durumum == "True") { rb_Evli.Checked = true; } else { rb_bekar.Checked = true; }
        }

        private void btn_Temizle_Click(object sender, EventArgs e)
        {
            tb_Id.Text = "";
            tb_Ad.Text = "";
            tb_Soyad.Text = "";
            cb_Sehir.Text = "";
            tb_Meslek.Text = "";
            tb_Maas.Text = "";
            if (rb_Evli.Checked == true) { rb_Evli.Checked = false; }
        }

        private void btn_Güncelle_Click(object sender, EventArgs e)
        {
            PersonelManager pm = new PersonelManager();
            Personel.id = Convert.ToInt16(tb_Id.Text);
            Personel.ad = tb_Ad.Text;
            Personel.soyad = tb_Soyad.Text;
            Personel.sehir = cb_Sehir.Text;
            Personel.meslek = tb_Meslek.Text;
            Personel.maas = Convert.ToInt32(tb_Maas.Text);
            if (rb_Evli.Checked == true) { Personel.durum = true; } else { Personel.durum = false; }
            pm.Guncelle();
        }

        private void btn_Istatistik_Click(object sender, EventArgs e)
        {
            Istatistik frm = new Istatistik();
            frm.Show();
        }

    }
}
