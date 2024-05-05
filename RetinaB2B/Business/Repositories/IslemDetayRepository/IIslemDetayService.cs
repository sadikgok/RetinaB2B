using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Repositories.IslemDetayRepository
{
    public interface IIslemDetayService
    {
        Task<IResult> Add(IslemDetay ıslemDetay);
        Task<IResult> Update(IslemDetay ıslemDetay);
        Task<IResult> Delete(IslemDetay ıslemDetay);
        Task<IDataResult<List<IslemDetay>>> GetList();
        Task<IDataResult<IslemDetay>> GetById(int islemId);
    }
}
