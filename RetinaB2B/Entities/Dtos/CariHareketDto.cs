namespace Entities.Dtos
{
    public class CariHareketDto
    {
        public string IslemAdi { get; set; }
        public string IslemTipi { get; set; }
        public string OdemeSekli { get; set; }
        public DateTime IslemTarihi { get; set; }
        public decimal CariBorc { get; set; }
        public decimal CariAlacak { get; set; }
        public decimal CariDovizAlacak { get; set; }
        public decimal CariDovizBorc { get; set; }
        public string CariHareketAciklama { get; set; }
    }
}
