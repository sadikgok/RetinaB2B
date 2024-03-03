using Entities.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public partial class Stok
    {
        [Key]
        public int StokId { get; set; }

        [StringLength(200)]
        public string StokAdi { get; set; }

        [StringLength(150)]
        public string Barkod { get; set; }

        public int? StokGrupId { get; set; }

        [StringLength(50)]
        public string Birimi { get; set; }

        public decimal? StokBakiye { get; set; }

        public decimal? AlisFiyati { get; set; }

        public decimal? SatisFiyati { get; set; }

        public decimal? ToptanSatisFiyati { get; set; }

        public decimal? BayiSatisFiyati { get; set; }

        public int? IndirimliStokAdedi { get; set; }

        public decimal? IndirimliSatisFiyati { get; set; }

        public int? KdvOrani { get; set; }

        [StringLength(1500)]
        public string Aciklama { get; set; }

        public decimal? AsgariMiktar { get; set; }

        [StringLength(50)]
        public string ParaBirimi { get; set; }
        public byte[] Image { get; set; }

        public decimal? ToptanKKSatis { get; set; }

        public decimal? ToptanTaksitliSatis { get; set; }
    }
}
