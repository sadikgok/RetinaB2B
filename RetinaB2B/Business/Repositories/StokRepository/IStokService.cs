using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.StokRepository
{
    public interface IStokService
    {
        Task<IResult> Add(Stok stok);
        Task<IResult> Update(Stok stok);
        Task<IResult> Delete(Stok stok);
        Task<IDataResult<List<Stok>>> GetList();
        Task<IDataResult<Stok>> GetById(int stokId);
        Task<IDataResult<List<DepoStokDto>>> GetStokByDepoId(int depoId);
        Task<IDataResult<List<DepoStokDto>>> GetStokByGroupId(int groupId);
        int GetLastStokId();
        Task <IDataResult<Stok>> GetStokByBarcode(string barcode);
    } 
}
