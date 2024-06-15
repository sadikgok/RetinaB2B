using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class FirmaBilgisi
    {
        [Key]
        public int FirmaId { get; set; }
        public string FirmaAdi { get; set; }
        public string VergiDairesi { get; set; }
        public string VergiNo { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string BankaAdi { get; set; }
        public string IbanNo { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string HesapDonemi { get; set; }
    }
}
