using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class IslemHareket
    {
        [Key]
        public int IslemHareketId { get; set; }
        public int? IslemId { get; set; }
        public int? StokId { get; set; }
        public string StokAdi { get; set; }
        public string StokBarkod { get; set; }
        public string StokBirimi { get; set; }
        public int? KdvOrani { get; set; }
        public decimal? StokBirimFiyati { get; set; }
        public decimal? StokIslemMiktari { get; set; }
        public decimal? IskontoTutari { get; set; }
        public decimal? HareketTutari { get; set; }
        public decimal? StokAlisFiyati { get; set; }
        public string ParaBirimi { get; set; }
    }
}
