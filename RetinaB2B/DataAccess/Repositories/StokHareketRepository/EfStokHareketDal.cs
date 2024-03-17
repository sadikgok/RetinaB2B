using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.StokHareketRepository
{
    public class EfStokHareketDal : EfEntityRepositoryBase<StokHareket, SimpleContextDb>, IStokHareketDal
    {
        public async Task<List<StokHareketDto>> GetStokHareketByStokId(int stokId)
        {
            using (var context = new SimpleContextDb())
            {
                var result = from stokHareket in context.StokHareketleri.Where(p => p.StokId == stokId)
                             join islem in context.Islemler on stokHareket.IslemId equals islem.IslemId into jj
                             from islem in jj.DefaultIfEmpty()
                             select new StokHareketDto
                             {
                                 IslemId = islem != null ? islem.IslemId : 0,
                                 IslemAdi = islem != null ? islem.IslemAdi : "",
                                 IslemTarihi = islem != null ? islem.IslemTarihi : DateTime.MinValue,
                                 StokId = stokHareket.StokId,
                                 StokGirisi = stokHareket.StokGirisi,
                                 StokCikisi = stokHareket.StokCikisi,
                                 AlisFiyati = stokHareket.AlisFiyati,
                                 SatisFiyati = stokHareket.SatisFiyati,
                                 SHareketAciklama = stokHareket.SHareketAciklama
                             };
                return await result.OrderByDescending(p => p.IslemTarihi).ToListAsync();
            }
        }
    }
}
