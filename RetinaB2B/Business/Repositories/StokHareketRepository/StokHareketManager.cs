using Business.Aspects.Secured;
using Business.Repositories.StokHareketRepository.Constants;
using Business.Repositories.StokHareketRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.StokHareketRepository;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.StokHareketRepository
{
    public class StokHareketManager : IStokHareketService
    {
        private readonly IStokHareketDal _stokHareketDal;

        public StokHareketManager(IStokHareketDal stokHareketDal)
        {
            _stokHareketDal = stokHareketDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(StokHareketValidator))]
        [RemoveCacheAspect("IStokHareketService.Get")]

        public async Task<IResult> Add(StokHareket stokHareket)
        {
            await _stokHareketDal.Add(stokHareket);
            return new SuccessResult(StokHareketMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(StokHareketValidator))]
        [RemoveCacheAspect("IStokHareketService.Get")]

        public async Task<IResult> Update(StokHareket stokHareket)
        {
            await _stokHareketDal.Update(stokHareket);
            return new SuccessResult(StokHareketMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IStokHareketService.Get")]

        public async Task<IResult> Delete(StokHareket stokHareket) 
        {
            await _stokHareketDal.Delete(stokHareket);
            return new SuccessResult(StokHareketMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<StokHareket>>> GetList()
        {
            return new SuccessDataResult<List<StokHareket>>(await _stokHareketDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<StokHareket>> GetById(int id)
        {
            return new SuccessDataResult<StokHareket>(await _stokHareketDal.Get(p => p.StokId == id));
        }

        [SecuredAspect()]
        public async Task<IDataResult<List<StokHareketDto>>> GetStokHareketByStokId(int stokId)
        {
            return new SuccessDataResult<List<StokHareketDto>>(await _stokHareketDal.GetStokHareketByStokId(stokId));
        }

        public async Task<IDataResult<List<StokHareket>>> GetStokHareketByIslemId(int islemId)
        {
            return new SuccessDataResult<List<StokHareket>>(await _stokHareketDal.GetStokHareketByIslemId(islemId));    
        }
    }
}
