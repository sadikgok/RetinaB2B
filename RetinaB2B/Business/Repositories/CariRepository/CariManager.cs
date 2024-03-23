using Business.Aspects.Secured;
using Business.Repositories.CariRepository.Constants;
using Business.Repositories.CariRepository.Validation;
using Business.Repositories.CustomerRepository.Constants;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Business;
using Core.Utilities.Hashing;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.CariRepository;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.CariRepository
{
    public class CariManager : ICariService
    {
        private readonly ICariDal _cariDal;

        public CariManager(ICariDal cariDal)
        {
            _cariDal = cariDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(CariValidator))]
        [RemoveCacheAspect("ICariService.Get")]

        public async Task<IResult> Add(CustomerRegisterDto customerRegisterDto)
        {
            IResult result = BusinessRules.Run(await CheckIfEmailExist(customerRegisterDto.Email));
            if (result != null)
            {
                return result;
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePassword(customerRegisterDto.Password, out passwordHash, out passwordSalt);
            Cari cari = new Cari
            {
                CariId = 0,
                CariAdi = customerRegisterDto.CariAdi,
                CariAdres = customerRegisterDto.CariAdres,
                CariCepTelefon = customerRegisterDto.CariCepTelefon,
                CariGrubu = customerRegisterDto.CariGrubu,
                CariTelefon = customerRegisterDto.CariTelefon,
                CariIl = customerRegisterDto.CariIl,
                CariYetkiliKisi = customerRegisterDto.CariYetkiliKisi,
                VergiDairesi = customerRegisterDto.VergiDairesi,
                VergiNo = customerRegisterDto.VergiNo,
                Email = customerRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CariDovizBakiye = 0,
                CariTlBakiye = 0,
                CariEskiDovizBakiye = 0,
                CariEskiTlBakiye = 0
            };
            await _cariDal.Add(cari);
            return new SuccessResult(CustomerMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(CariValidator))]
        [RemoveCacheAspect("ICariService.Get")]

        public async Task<IResult> Update(Cari cari)
        {
            await _cariDal.Update(cari);
            return new SuccessResult(CariMessages.Updated);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(CariValidator))]
        [RemoveCacheAspect("ICariService.Get")]
        public async Task<IResult> UpdateCariBakiye(CariBakiyeDto cariBakiyeDto)
        {
            await _cariDal.UpdateCariBakiye(cariBakiyeDto);
            return new SuccessResult(CariMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("ICariService.Get")]

        public async Task<IResult> Delete(Cari cari)
        {
            await _cariDal.Delete(cari);
            return new SuccessResult(CariMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<CariDto>>> GetList()
        {
            return new SuccessDataResult<List<CariDto>>(await _cariDal.GetListDto());
        }

        //[SecuredAspect()]
        public async Task<IDataResult<Cari>> GetById(int cariId)
        {
            return new SuccessDataResult<Cari>(await _cariDal.Get(p => p.CariId == cariId));
        }

        public async Task<Cari> GetByEmail(string email)
        {
            var result = await _cariDal.Get(p => p.Email == email);
            return result;
        }

        private async Task<IResult> CheckIfEmailExist(string email)
        {
            var list = await GetByEmail(email);
            if (list != null)
            {
                return new ErrorResult("Bu mail adresi daha önce kullanýlmýþ");
            }
            return new SuccessResult();
        }
    }
}
