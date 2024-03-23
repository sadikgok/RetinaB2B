using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Cari
    {

        [Key]
        public int CariId { get; set; }
        public string CariAdi { get; set; }
        public string CariGrubu { get; set; }
        public decimal? CariTlBakiye { get; set; }
        public decimal? CariDovizBakiye { get; set; }
        public decimal? CariEskiTlBakiye { get; set; }
        public decimal? CariEskiDovizBakiye { get; set; }
        public string? CariTelefon { get; set; }
        public string? CariCepTelefon { get; set; }
        public string? CariIl { get; set; }
        public string? CariAdres { get; set; }
        public string? CariYetkiliKisi { get; set; }
        public string? VergiNo { get; set; }
        public string? VergiDairesi { get; set; }
        public string? Aciklama { get; set; }
        public string? Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
