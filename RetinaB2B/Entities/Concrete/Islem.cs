namespace Entities.Concrete
{
    public class Islem
    {
        public int IslemId { get; set; }
        public string IslemAdi { get; set; }
        public string IslemTipi { get; set; }
        public string IslemDurumu { get; set; }
        public string OdemeSekli { get; set; }
        public DateTime IslemTarihi { get; set; }
        public decimal ToplamTutar { get; set; }
        public string Aciklama { get; set; }
        public decimal DovizKuru { get; set; }
        public decimal OdenenTutar { get; set; }
        public int DepoId { get; set; }
        public string IslemNumber { get; set; }
    }
}
