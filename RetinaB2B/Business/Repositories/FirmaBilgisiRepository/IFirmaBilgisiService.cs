using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.FirmaBilgisiRepository
{
    public interface IFirmaBilgisiService
    {
        Task<IResult> Add(FirmaBilgisi firmaBilgisi);
        Task<IResult> Update(FirmaBilgisi firmaBilgisi);
        Task<IResult> Delete(FirmaBilgisi firmaBilgisi);
        Task<IDataResult<List<FirmaBilgisi>>> GetList();
        Task<IDataResult<FirmaBilgisi>> GetById(int id);
    }
}
