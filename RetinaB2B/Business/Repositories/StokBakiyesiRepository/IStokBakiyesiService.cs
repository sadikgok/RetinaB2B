using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Repositories.StokBakiyesiRepository
{
    public interface IStokBakiyesiService
    {
        Task<IResult> Add(StokBakiyesi stokBakiyesi);
        Task<IResult> Update(StokBakiyesi stokBakiyesi);
        Task<IResult> Delete(StokBakiyesi stokBakiyesi);
        Task<IDataResult<List<StokBakiyesi>>> GetList();
        Task<IDataResult<StokBakiyesi>> GetById(int id);
        Task<IResult> StokBakiyeDusur(StokBakiyesi stokBakiyesi);
        Task<IResult> StokBakiyeArtir(StokBakiyesi stokBakiyesi);
    }
}
 