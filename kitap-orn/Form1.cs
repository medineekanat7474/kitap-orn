using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kitap_orn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Kitap kitap;
        List<Kitap>kitapbilgisi = new List<Kitap>();
        private void Form1_Load(object sender, EventArgs e)
        {
            kitapbilgisi.Add(new Kitap(1, "Sokak Nöbetçileri", "Aslı Arslan", 719, "ROMAN", false, new DateTime(2019, 1, 24)));
            kitapbilgisi.Add(new Kitap(2, "Sokak Nöbetçileri2", "Aslı Arslan", 816, "ROMAN", false, new DateTime(2023, 6, 12)));
            kitapbilgisi.Add(new Kitap(3, "ölüler Konuşamaz", "Dilara Keskin", 368, "ROMAN", true, new DateTime(2020,11,3)));
            kitapbilgisi.Add(new Kitap(4, "Şeker Portakalı", "Jose Mauro de Vasconcoles", 183, "ÇOCUK ROMANI", false, new DateTime(1983, 12, 1)));
            kitapbilgisi.Add(new Kitap(5, "Melekler ve Şeytanlar", "Dan Brown", 576, "MACERA", true, new DateTime(2004, 3, 3)));

            dgvKitapListesi.DataSource = kitapbilgisi;
        }

        private void dgvKitapListesi_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvKitapListesi.CurrentRow.Cells["id"].Value.ToString();
            txtKitapAdi.Text = dgvKitapListesi.CurrentRow.Cells["kitapadi"].Value.ToString();
            txtYazar.Text = dgvKitapListesi.CurrentRow.Cells["yazar"].Value.ToString();
            txtSayfaSayisi.Text = dgvKitapListesi.CurrentRow.Cells["sayfasayisi"].Value.ToString();
            cmbTür.Text= dgvKitapListesi.CurrentRow.Cells["tur"].Value.ToString();
            chkCilt.Checked = (bool)dgvKitapListesi.CurrentRow.Cells["cilt"].Value;
            dtpTarih.Value = (DateTime)dgvKitapListesi.CurrentRow.Cells["tarih"].Value;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int id=Convert.ToInt32(txtId.Text);
            string kitapadi = txtKitapAdi.Text;
            string yazaradi = txtYazar.Text;
            int sayfasayisi=Convert.ToInt32(txtSayfaSayisi.Text);
            string tur = cmbTür.Text;
            bool cilt = chkCilt.Checked;
            DateTime tarih=dtpTarih.Value;

            Kitap yeniliste = new Kitap(id, kitapadi, yazaradi, sayfasayisi, tur, cilt, tarih);

            kitapbilgisi.Add(yeniliste);
            dgvKitapListesi.DataSource=kitapbilgisi.ToList();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow secilensatir=dgvKitapListesi.SelectedRows[0];
            Kitap secilenkitap=secilensatir.DataBoundItem as Kitap;

            DialogResult result = MessageBox.Show("seçilen satır silinsin mi?","randevu sil",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
             if (result == DialogResult.Yes)
            {
                kitapbilgisi.Remove(secilenkitap);
            }
            dgvKitapListesi.DataSource = kitapbilgisi.ToList();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            DataGridViewRow secilensatir = dgvKitapListesi.SelectedRows[0];
            Kitap secilenkitap= secilensatir.DataBoundItem as Kitap;

            secilenkitap.Id = Convert.ToInt32(txtId.Text);
            secilenkitap.Kitapadi = txtKitapAdi.Text;
            secilenkitap.Yazar = txtYazar.Text;
            secilenkitap.Sayfasayisi= Convert.ToInt32(txtSayfaSayisi.Text);
            secilenkitap.Tur = cmbTür.Text;
            secilenkitap.Cilt = chkCilt.Checked;
            secilenkitap.Tarih = dtpTarih.Value;

            dgvKitapListesi.DataSource = null;
            dgvKitapListesi.DataSource=kitapbilgisi.ToList();
        }
    }
}
