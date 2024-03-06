using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Repositories.KasaRepository
{
    public interface IKasaService
    {
        Task<IResult> Add(Kasa kasa);
        Task<IResult> Update(Kasa kasa);
        Task<IResult> Delete(Kasa kasa);
        Task<IDataResult<List<Kasa>>> GetList();
        Task<IDataResult<Kasa>> GetById(int id);
        
    }
}
