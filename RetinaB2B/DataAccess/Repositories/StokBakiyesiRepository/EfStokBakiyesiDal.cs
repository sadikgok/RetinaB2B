using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.StokBakiyesiRepository
{
    public class EfStokBakiyesiDal : EfEntityRepositoryBase<StokBakiyesi, SimpleContextDb>, IStokBakiyesiDal
    {
        public async Task StokBakiyeDusur(StokBakiyesi stokBakiyesi)
        {
            using (var context = new SimpleContextDb())
            {
                var stok = await context.StokBakiyeleri
                    .FirstOrDefaultAsync(p => p.StokId == stokBakiyesi.StokId && p.DepoId == stokBakiyesi.DepoId);
                if (stok == null)
                {
                    throw new Exception("Stok Bulunamadý");
                }
                stok.StokBakiye = (stok.StokBakiye) - (stokBakiyesi.StokBakiye);
                await context.SaveChangesAsync();
            }
        }

        public async Task StokBakiyeArtir(StokBakiyesi stokBakiyesi)
        {
            using (var context = new SimpleContextDb())
            {
                var stok = await context.StokBakiyeleri
                    .FirstOrDefaultAsync(p => p.StokId == stokBakiyesi.StokId && p.DepoId == stokBakiyesi.DepoId);
                if (stok == null)
                {
                    throw new Exception("Stok Bulunamadý");
                }
                stok.StokBakiye = (stok.StokBakiye) + (stokBakiyesi.StokBakiye);
                await context.SaveChangesAsync();
            }
        }
    }

}
