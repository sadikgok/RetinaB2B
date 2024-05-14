namespace Entities.Dtos
{
    public class CariRegisterDto
    {
        public int CariId { get; set; }
        public string CariAdi { get; set; }
        public string CariGrubu { get; set; }
        public string? CariTelefon { get; set; }
        public string? CariCepTelefon { get; set; }
        public string? CariIl { get; set; }
        public string? CariAdres { get; set; }
        public string? CariYetkiliKisi { get; set; }
        public string? VergiNo { get; set; }
        public string? VergiDairesi { get; set; }
        public decimal? CariTlBakiye { get; set; }
        public decimal? CariDovizBakiye { get; set; }
        public decimal? CariEskiTlBakiye { get; set; }
        public decimal? CariEskiDovizBakiye { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
