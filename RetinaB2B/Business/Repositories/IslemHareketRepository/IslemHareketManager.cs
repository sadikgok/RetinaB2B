using Business.Aspects.Secured;
using Business.Repositories.IslemHareketRepository.Constants;
using Business.Repositories.IslemHareketRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.IslemHareketRepository;
using Entities.Concrete;

namespace Business.Repositories.IslemHareketRepository
{
    public class IslemHareketManager : IIslemHareketService
    {
        private readonly IIslemHareketDal _ıslemHareketDal;

        public IslemHareketManager(IIslemHareketDal ıslemHareketDal)
        {
            _ıslemHareketDal = ıslemHareketDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(IslemHareketValidator))]
        [RemoveCacheAspect("IIslemHareketService.Get")]

        public async Task<IResult> Add(IslemHareket ıslemHareket)
        {
            await _ıslemHareketDal.Add(ıslemHareket);
            return new SuccessResult(IslemHareketMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(IslemHareketValidator))]
        [RemoveCacheAspect("IIslemHareketService.Get")]

        public async Task<IResult> Update(IslemHareket ıslemHareket)
        {
            await _ıslemHareketDal.Update(ıslemHareket);
            return new SuccessResult(IslemHareketMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IIslemHareketService.Get")]

        public async Task<IResult> Delete(IslemHareket ıslemHareket)
        {
            await _ıslemHareketDal.Delete(ıslemHareket);
            return new SuccessResult(IslemHareketMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<IslemHareket>>> GetList()
        {
            return new SuccessDataResult<List<IslemHareket>>(await _ıslemHareketDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<IslemHareket>> GetById(int islemId)
        {
            return new SuccessDataResult<IslemHareket>(await _ıslemHareketDal.Get(p => p.IslemId == islemId));
        }

        [SecuredAspect()]
        public async Task<IDataResult<List<IslemHareket>>> GetIslemHareketByIslemId(int islemId)
        {
            return new SuccessDataResult<List<IslemHareket>>(await _ıslemHareketDal.GetIslemHareketByIslemId(islemId));
        }
    }
}
