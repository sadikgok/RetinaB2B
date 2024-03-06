using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Kasa
    {
        [Key]
        public int KasaId { get; set; }

        [StringLength(50)]
        public string KasaAdi { get; set; }

        public decimal KasaBakiye { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        [StringLength(50)]
        public string HesapTipi { get; set; }
    }
}
