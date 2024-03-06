using Business.Aspects.Secured;
using Business.Repositories.KasaHareketRepository.Constants;
using Business.Repositories.KasaHareketRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.KasaHareketRepository;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.KasaHareketRepository
{
    public class KasaHareketManager : IKasaHareketService
    {
        private readonly IKasaHareketDal _kasaHareketDal;

        public KasaHareketManager(IKasaHareketDal kasaHareketDal)
        {
            _kasaHareketDal = kasaHareketDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(KasaHareketValidator))]
        [RemoveCacheAspect("IKasaHareketService.Get")]

        public async Task<IResult> Add(KasaHareket kasaHareket)
        {
            await _kasaHareketDal.Add(kasaHareket);
            return new SuccessResult(KasaHareketMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(KasaHareketValidator))]
        [RemoveCacheAspect("IKasaHareketService.Get")]

        public async Task<IResult> Update(KasaHareket kasaHareket)
        {
            await _kasaHareketDal.Update(kasaHareket);
            return new SuccessResult(KasaHareketMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IKasaHareketService.Get")]

        public async Task<IResult> Delete(KasaHareket kasaHareket)
        {
            await _kasaHareketDal.Delete(kasaHareket);
            return new SuccessResult(KasaHareketMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<KasaHareket>>> GetList()
        {
            return new SuccessDataResult<List<KasaHareket>>(await _kasaHareketDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<KasaHareket>> GetById(int id)
        {
            return new SuccessDataResult<KasaHareket>(await _kasaHareketDal.Get(p => p.KasaId == id));
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<KasaHareketDto>>> GetKasaHareketByKasaId(int kasaId)
        {
            return new SuccessDataResult<List<KasaHareketDto>>(await _kasaHareketDal.GetKasaHareketByKasaId(kasaId));
        }

    }
}
