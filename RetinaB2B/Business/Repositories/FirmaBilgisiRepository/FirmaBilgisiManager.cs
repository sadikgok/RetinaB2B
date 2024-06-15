using Business.Aspects.Secured;
using Business.Repositories.FirmaBilgisiRepository.Constants;
using Business.Repositories.FirmaBilgisiRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.FirmaBilgisiRepository;
using Entities.Concrete;

namespace Business.Repositories.FirmaBilgisiRepository
{
    public class FirmaBilgisiManager : IFirmaBilgisiService
    {
        private readonly IFirmaBilgisiDal _firmaBilgisiDal;

        public FirmaBilgisiManager(IFirmaBilgisiDal firmaBilgisiDal)
        {
            _firmaBilgisiDal = firmaBilgisiDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(FirmaBilgisiValidator))]
        [RemoveCacheAspect("IFirmaBilgisiService.Get")]

        public async Task<IResult> Add(FirmaBilgisi firmaBilgisi)
        {
            await _firmaBilgisiDal.Add(firmaBilgisi);
            return new SuccessResult(FirmaBilgisiMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(FirmaBilgisiValidator))]
        [RemoveCacheAspect("IFirmaBilgisiService.Get")]

        public async Task<IResult> Update(FirmaBilgisi firmaBilgisi)
        {
            await _firmaBilgisiDal.Update(firmaBilgisi);
            return new SuccessResult(FirmaBilgisiMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IFirmaBilgisiService.Get")]

        public async Task<IResult> Delete(FirmaBilgisi firmaBilgisi)
        {
            await _firmaBilgisiDal.Delete(firmaBilgisi);
            return new SuccessResult(FirmaBilgisiMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<FirmaBilgisi>>> GetList()
        {
            return new SuccessDataResult<List<FirmaBilgisi>>(await _firmaBilgisiDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<FirmaBilgisi>> GetById(int id)
        {
            return new SuccessDataResult<FirmaBilgisi>(await _firmaBilgisiDal.Get(p => p.FirmaId == id));
        }

    }
}
