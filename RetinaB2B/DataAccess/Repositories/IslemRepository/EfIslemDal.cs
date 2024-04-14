using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.IslemRepository
{
    public class EfIslemDal : EfEntityRepositoryBase<Islem, SimpleContextDb>, IIslemDal
    {
        public int GetLastIslemId()
        {
            using (var context = new SimpleContextDb())
            {
                var lastId = context.Islemler
                        .OrderByDescending(p => p.IslemId)
                        .Select(p => p.IslemId)
                        .FirstOrDefault();
                return lastId;
            }
        }

        public async Task<int> Add(Islem islem) 
        {
            using (var context = new SimpleContextDb())
            {
                var addedEntity = context.Entry(islem);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                return islem.IslemId;
            }
        }
    }
}
