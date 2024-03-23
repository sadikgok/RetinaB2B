namespace Entities.Concrete
{
    public class CariHareket
    {
        public int CariHareketId { get; set; }
        public int CariId { get; set; }
        public int IslemId { get; set; }
        public decimal CariBorc { get; set; }
        public decimal CariAlacak { get; set; }
        public decimal CariDovizAlacak { get; set; }
        public decimal CariDovizBorc { get; set; }
        public string CariHareketAciklama { get; set; }

        public virtual Cari Cariler { get; set; }
    }
}
