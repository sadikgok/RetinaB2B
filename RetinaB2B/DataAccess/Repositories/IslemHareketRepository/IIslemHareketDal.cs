using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Repositories.IslemHareketRepository
{
    public interface IIslemHareketDal : IEntityRepository<IslemHareket>
    {
        Task<List<IslemHareket>> GetIslemHareketByIslemId(int islemId);
    }
}
