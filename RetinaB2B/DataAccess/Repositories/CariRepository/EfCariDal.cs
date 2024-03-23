using Core.DataAccess.EntityFramework;
using Core.Utilities.Result.Abstract;
using DataAccess.Context.EntityFramework;
using Entities;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.CariRepository
{
    public class EfCariDal : EfEntityRepositoryBase<Cari,SimpleContextDb>, ICariDal
    {
        public async Task<List<CariDto>> GetListDto()
        {
            using (var context = new SimpleContextDb())
            {
                var result = from cari in context.Cariler
                             select new CariDto
                             {
                                 CariId = cari.CariId,
                                 CariAdi = cari.CariAdi,
                                 CariTlBakiye =(decimal) cari.CariTlBakiye,
                                 CariDovizBakiye = (decimal) cari.CariDovizBakiye,
                                 CariGrubu = cari.CariGrubu,
                                 CariIl = cari.CariIl,
                                 CariAdres = cari.CariAdres,
                                 CariCepTelefon = cari.CariCepTelefon,
                                 CariTelefon = cari.CariTelefon,
                             };
                return await result.OrderByDescending(p => p.CariId).ToListAsync();
            }
        }

        public async Task UpdateCariBakiye(CariBakiyeDto cariBakiyeDto)
        {
            using(var context = new SimpleContextDb())
            {
                var cari = await context.Cariler.FindAsync(cariBakiyeDto.CariId);
                if (cari == null)
                {
                    throw new Exception("Cari bulunamadý.");
                }

                cari.CariTlBakiye = cariBakiyeDto.CariTlBakiye;
                cari.CariDovizBakiye = cariBakiyeDto.CariDovizBakiye;
                cari.CariEskiTlBakiye = cariBakiyeDto.CariEskiTlBakiye;
                cari.CariEskiDovizBakiye = cariBakiyeDto.CariEskiDovizBakiye;

                await context.SaveChangesAsync();
            }
        }

    }
    
}
