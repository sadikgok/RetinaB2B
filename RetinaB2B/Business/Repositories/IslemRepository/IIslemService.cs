using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Repositories.IslemRepository
{
    public interface IIslemService
    {
        Task<int> Add(Islem entity);
        Task<IResult> Update(Islem ıslem);
        Task<IResult> Delete(int islemId);
        Task<IDataResult<List<Islem>>> GetList();
        Task<IDataResult<Islem>> GetById(int id);
        int GetLastIslemId();
    }
}
