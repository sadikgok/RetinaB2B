using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.IslemRepository
{
    public interface IIslemService
    {
        Task<IResult> Add(Islem ıslem);
        Task<IResult> Update(Islem ıslem);
        Task<IResult> Delete(Islem ıslem);
        Task<IDataResult<List<Islem>>> GetList();
        Task<IDataResult<Islem>> GetById(int id);
    }
}
