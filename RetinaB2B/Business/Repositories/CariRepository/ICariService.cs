using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.CariRepository
{
    public interface ICariService
    {
        Task<IResult> Add(CustomerRegisterDto customerRegisterDto);
        Task<IResult> Update(Cari cari);
        Task<IResult> Delete(Cari cari);
        Task<IDataResult<List<CariDto>>> GetList(); 
        Task<IDataResult<Cari>> GetById(int cariId);
        Task<IResult> UpdateCariBakiye(CariBakiyeDto cariBakiyeDto);
    }
}
