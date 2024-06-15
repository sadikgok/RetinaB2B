namespace Entities.Dtos
{
    public class ProductListDto 
    {
        public int StokId { get; set; }
        public string StokAdi { get; set; }
        public decimal? SatisFiyati { get; set; }
        public decimal? ToptanSatisFiyati { get; set; }
        public decimal? BayiSatisFiyati { get; set; }
        public int? IndirimliStokAdedi { get; set; }
        public decimal? IndirimliSatisFiyati { get; set; }
        public string MainImageUrl { get; set; }
        public List<string> Image { get; set; }

    }
}
