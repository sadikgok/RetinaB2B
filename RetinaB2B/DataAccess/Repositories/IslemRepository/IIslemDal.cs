using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Repositories.IslemRepository
{
    public interface IIslemDal : IEntityRepository<Islem>
    {
        int GetLastIslemId();
    }
}
