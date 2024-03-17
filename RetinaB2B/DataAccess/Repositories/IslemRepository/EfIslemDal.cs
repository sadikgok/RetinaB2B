using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;

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
    } 
}
