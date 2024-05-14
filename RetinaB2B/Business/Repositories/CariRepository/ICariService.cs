using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.CariRepository
{
    public interface ICariService
    {
        Task<IResult> Add(CariRegisterDto cariRegisterDto); 
        Task<IResult> Update(Cari cari);
        Task<IResult> Delete(Cari cari);
        Task<IDataResult<List<CariDto>>> GetListDto(); 
        Task<IDataResult<Cari>> GetById(int cariId);
        Task<IResult> UpdateCariBakiye(CariBakiyeDto cariBakiyeDto);
        Task<IResult> CariPasswordChange(CariPasswordChangeDto cariPasswordChangeDto);
        Task<Cari> GetByEmail(string email); 
    }
}
