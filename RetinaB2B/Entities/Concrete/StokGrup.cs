using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class StokGrup
    {
        [Key]
        public int StokGrupId { get; set; }

        [StringLength(50)]
        public string StokGrupAdi { get; set; }

        public ICollection<Stok> Stoks { get; set; } 
    }
}
