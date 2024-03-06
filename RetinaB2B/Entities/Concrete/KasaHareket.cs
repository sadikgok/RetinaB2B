using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class KasaHareket
    {
        public int KasaHareketId { get; set; }
        public int KasaId { get; set; }
        public int IslemId { get; set; }
        public decimal KasayaGiren { get; set; }
        public decimal KasadanCikan { get; set; }

        [Column(TypeName = "text")]
        public string KasaHareketAciklama { get; set; }
    }
}
