using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
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
                islem.IslemNumber = GetIslemNumber();
                var addedEntity = context.Entry(islem);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                return islem.IslemId;
            }
        }

        public string GetIslemNumber()
        {
            using (var context = new SimpleContextDb())
            {
                var findLastIslem = context.Islemler.OrderBy(p => p.IslemId).LastOrDefault();

                if (findLastIslem == null)
                {
                    return "ISL0000000000001";
                }
                int findLastOrderNumber = findLastIslem.IslemId;
                findLastOrderNumber++;
                string newIslemNumber = findLastOrderNumber.ToString();
                for (int i = newIslemNumber.Length; i < 13; i++)
                {
                    newIslemNumber = "0" + newIslemNumber;
                }
                newIslemNumber = "ISL" + newIslemNumber;
                return newIslemNumber;
            }
        }
    }
}
