using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.StokHareketRepository
{
    public interface IStokHareketDal : IEntityRepository<StokHareket>
    {
        Task<List<StokHareketDto>> GetStokHareketByStokId(int stokId);
        Task<List<StokHareket>> GetStokHareketByIslemId(int islemId);   
    }
}
