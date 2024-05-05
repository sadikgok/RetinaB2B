using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class StokHareket
    {
        [Key]
        public int StokHareketId { get; set; }

        public int StokId { get; set; }

        public int IslemId { get; set; }

        public decimal StokGirisi { get; set; }

        public decimal StokCikisi { get; set; }

        public decimal AlisFiyati { get; set; }

        public decimal SatisFiyati { get; set; }

        [Column(TypeName = "text")]
        public string SHareketAciklama { get; set; }
    }
}
