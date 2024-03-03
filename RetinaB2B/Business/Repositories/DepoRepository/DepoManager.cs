using Business.Aspects.Secured;
using Business.Repositories.DepoRepository.Constants;
using Business.Repositories.DepoRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.DepoRepository;
using Entities.Concrete;

namespace Business.Repositories.DepoRepository
{
    public class DepoManager : IDepoService
    {
        private readonly IDepoDal _depoDal;

        public DepoManager(IDepoDal depoDal)
        {
            _depoDal = depoDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(DepoValidator))]
        [RemoveCacheAspect("IDepoService.Get")]

        public async Task<IResult> Add(Depo depo)
        {
            await _depoDal.Add(depo);
            return new SuccessResult(DepoMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(DepoValidator))]
        [RemoveCacheAspect("IDepoService.Get")]

        public async Task<IResult> Update(Depo depo)
        {
            await _depoDal.Update(depo);
            return new SuccessResult(DepoMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IDepoService.Get")]

        public async Task<IResult> Delete(Depo depo)
        {
            await _depoDal.Delete(depo);
            return new SuccessResult(DepoMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<Depo>>> GetList()
        {
            return new SuccessDataResult<List<Depo>>(await _depoDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<Depo>> GetById(int id)
        {
            return new SuccessDataResult<Depo>(await _depoDal.Get(p => p.DepoId == id));
        }

    }
}
