using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.DepoRepository
{
    public interface IDepoService
    {
        Task<IResult> Add(Depo depo);
        Task<IResult> Update(Depo depo);
        Task<IResult> Delete(Depo depo);
        Task<IDataResult<List<Depo>>> GetList();
        Task<IDataResult<Depo>> GetById(int id);
    }
}
