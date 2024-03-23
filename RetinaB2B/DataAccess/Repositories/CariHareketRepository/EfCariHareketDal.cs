using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.CariHareketRepository
{
    public class EfCariHareketDal : EfEntityRepositoryBase<CariHareket, SimpleContextDb>, ICariHareketDal
    {
        public async Task<List<CariHareketDto>> GetCariHareketByCariId(int cariId)
        {
            using (SimpleContextDb context = new SimpleContextDb())
            {
                var result = from cariHareket in context.CariHareketleri.Where(p => p.CariId == cariId)
                             join islem in context.Islemler on cariHareket.IslemId equals islem.IslemId
                             select new CariHareketDto
                             {
                                 IslemAdi = islem.IslemAdi,
                                 IslemTarihi = islem.IslemTarihi,
                                 IslemTipi = islem.IslemTipi,
                                 OdemeSekli = islem.OdemeSekli,
                                 CariAlacak = cariHareket.CariAlacak,
                                 CariBorc = cariHareket.CariBorc,
                                 CariDovizAlacak = cariHareket.CariDovizAlacak,
                                 CariDovizBorc = cariHareket.CariDovizBorc,
                                 CariHareketAciklama = cariHareket.CariHareketAciklama
                             };
                return await result.OrderByDescending(p => p.IslemTarihi).ToListAsync();

            }
        }
    }
}
