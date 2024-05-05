using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.IslemHareketRepository
{
    public class EfIslemHareketDal : EfEntityRepositoryBase<IslemHareket, SimpleContextDb>, IIslemHareketDal
    {
        public async Task<List<IslemHareket>> GetIslemHareketByIslemId(int islemId)
        {
            using (var context = new SimpleContextDb())
            {
                var result = await context.IslemHareketleri
                    .Where(p => p.IslemId == islemId)
                    .ToListAsync();
                return result;
            }
        }
    }
}
