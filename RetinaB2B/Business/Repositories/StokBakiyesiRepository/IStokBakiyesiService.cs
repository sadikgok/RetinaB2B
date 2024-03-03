using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.StokBakiyesiRepository
{
    public interface IStokBakiyesiService
    {
        Task<IResult> Add(StokBakiyesi stokBakiyesi);
        Task<IResult> Update(StokBakiyesi stokBakiyesi);
        Task<IResult> Delete(StokBakiyesi stokBakiyesi);
        Task<IDataResult<List<StokBakiyesi>>> GetList();
        Task<IDataResult<StokBakiyesi>> GetById(int id);
    }
}
