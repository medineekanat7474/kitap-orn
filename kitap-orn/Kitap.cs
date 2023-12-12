using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kitap_orn
{
    internal class Kitap
    {
        int id;
        string kitapadi;
        string yazar;
        int sayfasayisi;
        string tur;
        bool cilt;
        DateTime tarih;

        public int Id { get => id; set => id = value; }
        public string Kitapadi { get => kitapadi; set => kitapadi = value; }
        public string Yazar { get => yazar; set => yazar = value; }
        public int Sayfasayisi { get => sayfasayisi; set => sayfasayisi = value; }
        public string Tur { get => tur; set => tur = value; }
        public bool Cilt { get => cilt; set => cilt = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }

        public Kitap(int id, string kitapadi, string yazar, int sayfasayisi, string tur, bool cilt, DateTime tarih)
        {
            this.id = id;
            this.kitapadi = kitapadi;
            this.yazar = yazar;
            this.sayfasayisi = sayfasayisi;
            this.tur = tur;
            this.cilt = cilt;
            this.tarih = tarih;
        }
    }
}
