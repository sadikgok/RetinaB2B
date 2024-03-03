using Entities.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Depo
    {
        [Key]
        public int DepoId { get; set; }

        [StringLength(150)]
        public string DepoAdi { get; set; }

        [StringLength(50)]
        public string DepoIP { get; set; }

        public bool? Aktif { get; set; }
    }
}
