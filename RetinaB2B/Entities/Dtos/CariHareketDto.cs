namespace Entities.Dtos
{
    public class CariHareketDto
    {
        public int IslemId { get; set; }
        public string IslemAdi { get; set; }
        public DateTime IslemTarihi { get; set; }
        public decimal CariBorc { get; set; }
        public decimal CariAlacak { get; set; }
        public decimal CariDovizAlacak { get; set; }
        public decimal CariDovizBorc { get; set; }
        public string CariHareketAciklama { get; set; } 
    }
}
