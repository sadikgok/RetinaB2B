using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class IslemDetay
    {
        [Key]
        public int IslemDetayId { get; set; }
        public int IslemId { get; set; }
        public int CariId { get; set; }
        public int KasaId { get; set; }
        public decimal? IskontoTutari { get; set; }
        public decimal? TlTutari { get; set; }
        public decimal? DovizTutari { get; set; }
        public decimal? DovizTlKarsiligi { get; set; }
        public decimal? AraToplam { get; set; }
        public decimal? KdvTutari { get; set; }
        public decimal? ToplamKar { get; set; }
        public int? IskontoYuzdesi { get; set; }
        public decimal? DovizKuru { get; set; }
        public DateTime? VadeTarihi { get; set; }
        public bool? VadeUyari { get; set; }
        public bool? KdvDisinda { get; set; }
        public decimal? OdenenTutar { get; set; }
    }
}
