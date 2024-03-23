using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.CariHareketRepository
{
    public interface ICariHareketDal : IEntityRepository<CariHareket>
    {
        Task<List<CariHareketDto>> GetCariHareketByCariId(int cariId);
    }
}
