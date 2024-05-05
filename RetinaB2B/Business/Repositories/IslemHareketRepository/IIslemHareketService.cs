using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Repositories.IslemHareketRepository
{
    public interface IIslemHareketService
    {
        Task<IResult> Add(IslemHareket ıslemHareket);
        Task<IResult> Update(IslemHareket ıslemHareket);
        Task<IResult> Delete(IslemHareket ıslemHareket);
        Task<IDataResult<List<IslemHareket>>> GetList();
        Task<IDataResult<IslemHareket>> GetById(int islemId);
        Task<IDataResult<List<IslemHareket>>> GetIslemHareketByIslemId(int islemId);

    }
}
