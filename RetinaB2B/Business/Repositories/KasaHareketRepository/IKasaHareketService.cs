using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.KasaHareketRepository
{
    public interface IKasaHareketService
    {
        Task<IResult> Add(KasaHareket kasaHareket);
        Task<IResult> Update(KasaHareket kasaHareket);
        Task<IResult> Delete(KasaHareket kasaHareket);
        Task<IDataResult<List<KasaHareket>>> GetList();
        Task<IDataResult<KasaHareket>> GetById(int id);
        Task<IDataResult<List<KasaHareketDto>>> GetKasaHareketByKasaId(int kasaId);
    }
}
