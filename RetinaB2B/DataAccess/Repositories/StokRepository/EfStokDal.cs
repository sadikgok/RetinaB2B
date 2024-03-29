using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.StokRepository
{
    public class EfStokDal : EfEntityRepositoryBase<Stok, SimpleContextDb>, IStokDal
    {
        public int GetLastStokId()
        {
            using (var context = new SimpleContextDb())
            {
                var lastId = context.Stoklar
                        .OrderByDescending(p => p.StokId)
                        .Select(p => p.StokId)
                        .FirstOrDefault();
                return lastId;
            }
        }

        public async Task<List<DepoStokDto>> GetStokByDepoId(int depoId)
        {
            using (SimpleContextDb context = new SimpleContextDb())
            {
                var result = from stokBakiye in context.StokBakiyeleri.Where(p => p.DepoId == depoId)
                             join depo in context.Depolar on stokBakiye.DepoId equals depo.DepoId
                             join stok in context.Stoklar on stokBakiye.StokId equals stok.StokId
                             select new DepoStokDto
                             {
                                 Bakiye = (decimal)stokBakiye.StokBakiye,
                                 DepoAdi = depo.DepoAdi,
                                 StokId = stok.StokId,
                                 StokAdi = stok.StokAdi,
                                 Barkod = stok.Barkod,
                                 SatisFiyati = (decimal)stok.SatisFiyati,
                                 AlisFiyati = (decimal)stok.AlisFiyati,
                                 ParaBirimi = stok.ParaBirimi,
                             };
                return await result.OrderByDescending(p => p.StokId).ToListAsync();
            }
        }
        public async Task<List<DepoStokDto>> GetStokByGroupId(int grupId)
        {
            using (SimpleContextDb context = new SimpleContextDb())
            {
                var result = from stokGrup in context.StokGruplari.Where(p => p.StokGrupId == grupId)
                             join stok in context.Stoklar on stokGrup.StokGrupId equals stok.StokGrupId
                             join stokBakiye in context.StokBakiyeleri on stok.StokId equals stokBakiye.StokId
                             join depo in context.Depolar on stokBakiye.DepoId equals depo.DepoId
                             select new DepoStokDto
                             {
                                 Bakiye = (decimal)stokBakiye.StokBakiye,
                                 DepoAdi = depo.DepoAdi,
                                 StokId = stok.StokId,
                                 StokAdi = stok.StokAdi,
                                 Barkod = stok.Barkod,
                                 SatisFiyati = (decimal)stok.SatisFiyati,
                                 AlisFiyati = (decimal)stok.AlisFiyati,
                                 ParaBirimi = stok.ParaBirimi,
                             };
                return await result.ToListAsync();
            }
        }
    }
}
