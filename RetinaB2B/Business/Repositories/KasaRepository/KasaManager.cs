using Business.Aspects.Secured;
using Business.Repositories.KasaRepository.Constants;
using Business.Repositories.KasaRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.KasaRepository;
using Entities.Concrete;

namespace Business.Repositories.KasaRepository
{
    public class KasaManager : IKasaService
    {
        private readonly IKasaDal _kasaDal;

        public KasaManager(IKasaDal kasaDal)
        {
            _kasaDal = kasaDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(KasaValidator))]
        [RemoveCacheAspect("IKasaService.Get")]

        public async Task<IResult> Add(Kasa kasa)
        {
            await _kasaDal.Add(kasa);
            return new SuccessResult(KasaMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(KasaValidator))]
        [RemoveCacheAspect("IKasaService.Get")]

        public async Task<IResult> Update(Kasa kasa)
        {
            await _kasaDal.Update(kasa);
            return new SuccessResult(KasaMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IKasaService.Get")]

        public async Task<IResult> Delete(Kasa kasa)
        {
            await _kasaDal.Delete(kasa);
            return new SuccessResult(KasaMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<Kasa>>> GetList()
        {
            return new SuccessDataResult<List<Kasa>>(await _kasaDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<Kasa>> GetById(int id)
        {
            return new SuccessDataResult<Kasa>(await _kasaDal.Get(p => p.KasaId == id));
        }
    }
}
