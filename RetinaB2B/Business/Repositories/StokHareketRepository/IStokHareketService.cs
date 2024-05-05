using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.StokHareketRepository
{
    public interface IStokHareketService
    {
        Task<IResult> Add(StokHareket stokHareket);
        Task<IResult> Update(StokHareket stokHareket);
        Task<IResult> Delete(StokHareket stokHareket);
        Task<IDataResult<List<StokHareket>>> GetList();
        Task<IDataResult<StokHareket>> GetById(int id);
        Task<IDataResult<List<StokHareketDto>>> GetStokHareketByStokId(int stokId);
        Task<IDataResult<List<StokHareket>>>GetStokHareketByIslemId(int islemId);
    }
}
