namespace Entities.Dtos
{
    public class DepoStokDto
    {
        public string DepoAdi { get; set; }
        public decimal Bakiye { get; set; }
        public int StokId { get; set; }
        public string StokAdi { get; set; }
        public string Barkod { get; set; }
        public decimal AlisFiyati { get; set; }
        public decimal SatisFiyati { get; set; }
        public string ParaBirimi { get; set; }
    }
}
