using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Repositories.IslemRepository
{
    public interface IIslemService
    {
        Task<IResult> Add(Islem ıslem);
        Task<IResult> Update(Islem ıslem);
        Task<IResult> Delete(Islem ıslem);
        Task<IDataResult<List<Islem>>> GetList();
        Task<IDataResult<Islem>> GetById(int id);
        int GetLastIslemId();
    }
}
