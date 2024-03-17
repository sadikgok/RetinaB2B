using Entities.Concrete;

namespace Entities.Dtos
{
    public class StokHareketDto:StokHareket
    {
        public string IslemAdi { get; set; }
        public DateTime IslemTarihi { get; set; }
    }
}
