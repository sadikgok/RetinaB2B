using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.StokGrupRepository
{
    public interface IStokGrupService
    {
        Task<IResult> Add(StokGrup stokGrup);
        Task<IResult> Update(StokGrup stokGrup);
        Task<IResult> Delete(StokGrup stokGrup);
        Task<IDataResult<List<StokGrup>>> GetList();
        Task<IDataResult<StokGrup>> GetById(int id);
    }
}
