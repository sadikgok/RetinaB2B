using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.KasaHareketRepository
{
    public class EfKasaHareketDal : EfEntityRepositoryBase<KasaHareket, SimpleContextDb>, IKasaHareketDal
    {
        public async Task<List<KasaHareketDto>> GetKasaHareketByKasaId(int kasaId)
        {
            using (SimpleContextDb context = new SimpleContextDb())
            {
                var result = from kasaHareket in context.KasaHareketleri.Where(p => p.KasaId == kasaId)
                             join islem in context.Islemler on kasaHareket.IslemId equals islem.IslemId
                             select new KasaHareketDto
                             {
                                 IslemId=islem.IslemId,
                                 IslemAdi = islem.IslemAdi,
                                 IslemTarihi = islem.IslemTarihi,
                                 IslemTipi = islem.IslemTipi,
                                 OdemeSekli = islem.OdemeSekli,
                                 KasadanCikan = kasaHareket.KasadanCikan,
                                 KasayaGiren = kasaHareket.KasayaGiren,
                                 KasaHareketAciklama = kasaHareket.KasaHareketAciklama
                             };
                return await result.OrderByDescending(p => p.IslemTarihi).ToListAsync();
              
            }
        }
    }
}
