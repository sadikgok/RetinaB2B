using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;

namespace Business.Repositories.StokHareketRepository
{
    public interface IStokHareketService
    {
        Task<IResult> Add(StokHareket stokHareket);
        Task<IResult> Update(StokHareket stokHareket);
        Task<IResult> Delete(StokHareket stokHareket);
        Task<IDataResult<List<StokHareket>>> GetList();
        Task<IDataResult<StokHareket>> GetById(int id);
        Task<IDataResult<List<StokHareketDto>>> GetStokHareketByStokId(int stokId);
    }
}
