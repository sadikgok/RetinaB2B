using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class StokBakiyesi
    {
        [Key]
        public int DepoId { get; set; }
        public int StokId { get; set; }
        public decimal StokBakiye { get; set; }
    }
}
