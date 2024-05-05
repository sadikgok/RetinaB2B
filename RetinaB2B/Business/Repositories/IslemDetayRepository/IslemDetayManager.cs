using Business.Aspects.Secured;
using Business.Repositories.IslemDetayRepository.Constants;
using Business.Repositories.IslemDetayRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.IslemDetayRepository;
using Entities.Concrete;

namespace Business.Repositories.IslemDetayRepository
{
    public class IslemDetayManager : IIslemDetayService
    {
        private readonly IIslemDetayDal _ıslemDetayDal;

        public IslemDetayManager(IIslemDetayDal ıslemDetayDal)
        {
            _ıslemDetayDal = ıslemDetayDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(IslemDetayValidator))]
        [RemoveCacheAspect("IIslemDetayService.Get")]

        public async Task<IResult> Add(IslemDetay ıslemDetay)
        {
            await _ıslemDetayDal.Add(ıslemDetay);
            return new SuccessResult(IslemDetayMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(IslemDetayValidator))]
        [RemoveCacheAspect("IIslemDetayService.Get")]

        public async Task<IResult> Update(IslemDetay ıslemDetay)
        {
            await _ıslemDetayDal.Update(ıslemDetay);
            return new SuccessResult(IslemDetayMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IIslemDetayService.Get")]

        public async Task<IResult> Delete(IslemDetay ıslemDetay)
        {
            var result = await _ıslemDetayDal.Get(p => p.IslemId == ıslemDetay.IslemId);
            await _ıslemDetayDal.Delete(result);
            return new SuccessResult(IslemDetayMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<IslemDetay>>> GetList()
        {
            return new SuccessDataResult<List<IslemDetay>>(await _ıslemDetayDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<IslemDetay>> GetById(int islemId)
        {
            return new SuccessDataResult<IslemDetay>(await _ıslemDetayDal.Get(p => p.IslemId == islemId));
        }

    }
}
