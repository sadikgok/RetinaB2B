using Business.Aspects.Secured;
using Business.Repositories.CariHareketRepository.Constants;
using Business.Repositories.CariHareketRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.CariHareketRepository;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.CariHareketRepository
{
    public class CariHareketManager : ICariHareketService
    {
        private readonly ICariHareketDal _cariHareketDal;

        public CariHareketManager(ICariHareketDal cariHareketDal)
        {
            _cariHareketDal = cariHareketDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(CariHareketValidator))]
        [RemoveCacheAspect("ICariHareketService.Get")]

        public async Task<IResult> Add(CariHareket cariHareket)
        {
            await _cariHareketDal.Add(cariHareket);
            return new SuccessResult(CariHareketMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(CariHareketValidator))]
        [RemoveCacheAspect("ICariHareketService.Get")]

        public async Task<IResult> Update(CariHareket cariHareket)
        {
            await _cariHareketDal.Update(cariHareket);
            return new SuccessResult(CariHareketMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("ICariHareketService.Get")]

        public async Task<IResult> Delete(CariHareket cariHareket)
        {
            await _cariHareketDal.Delete(cariHareket);
            return new SuccessResult(CariHareketMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<CariHareket>>> GetList()
        {
            return new SuccessDataResult<List<CariHareket>>(await _cariHareketDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<CariHareket>> GetById(int cariId)
        {
            return new SuccessDataResult<CariHareket>(await _cariHareketDal.Get(p => p.CariId == cariId));
        }

        [SecuredAspect()]
        public async Task<IDataResult<List<CariHareketDto>>> GetCariHareketByCariId(int cariId)
        {
            return new SuccessDataResult<List<CariHareketDto>>(await _cariHareketDal.GetCariHareketByCariId(cariId));
        }
    }
}
