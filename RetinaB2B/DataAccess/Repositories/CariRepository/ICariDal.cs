using Core.DataAccess;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.CariRepository
{
    public interface ICariDal : IEntityRepository<Cari>
    {
        Task<List<CariDto>> GetListDto();
        Task  UpdateCariBakiye(CariBakiyeDto cariBakiyeDto);
    }
}
