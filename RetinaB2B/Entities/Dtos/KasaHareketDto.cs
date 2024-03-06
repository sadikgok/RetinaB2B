using Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Dtos
{
    public class KasaHareketDto
    {
        public string IslemAdi { get; set; }
        public string IslemTipi { get; set; }
        public string OdemeSekli { get; set; }
        public DateTime IslemTarihi { get; set; }
        public decimal KasayaGiren { get; set; }
        public decimal KasadanCikan { get; set; }

        [Column(TypeName = "text")]
        public string KasaHareketAciklama { get; set; }

    }
}
