using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.KasaHareketRepository
{
    public interface IKasaHareketDal : IEntityRepository<KasaHareket>
    {
        Task<List<KasaHareketDto>> GetKasaHareketByKasaId(int kasaId);
    }
}
