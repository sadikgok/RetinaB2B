using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.CariHareketRepository
{
    public interface ICariHareketService
    {
        Task<IResult> Add(CariHareket cariHareket);
        Task<IResult> Update(CariHareket cariHareket);
        Task<IResult> Delete(CariHareket cariHareket);
        Task<IDataResult<List<CariHareket>>> GetList();
        Task<IDataResult<CariHareket>> GetById(int id);
        Task<IDataResult<List<CariHareketDto>>> GetCariHareketByCariId(int cariId);
    }
}
