using Business.Aspects.Secured;
using Business.Repositories.StokGrupRepository.Constants;
using Business.Repositories.StokGrupRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.StokGrupRepository;
using Entities.Concrete;

namespace Business.Repositories.StokGrupRepository
{
    public class StokGrupManager : IStokGrupService
    {
        private readonly IStokGrupDal _stokGrupDal;

        public StokGrupManager(IStokGrupDal stokGrupDal)
        {
            _stokGrupDal = stokGrupDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(StokGrupValidator))]
        [RemoveCacheAspect("IStokGrupService.Get")]

        public async Task<IResult> Add(StokGrup stokGrup)
        {
            await _stokGrupDal.Add(stokGrup);
            return new SuccessResult(StokGrupMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(StokGrupValidator))]
        [RemoveCacheAspect("IStokGrupService.Get")]

        public async Task<IResult> Update(StokGrup stokGrup)
        {
            await _stokGrupDal.Update(stokGrup);
            return new SuccessResult(StokGrupMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IStokGrupService.Get")]

        public async Task<IResult> Delete(StokGrup stokGrup)
        {
            await _stokGrupDal.Delete(stokGrup);
            return new SuccessResult(StokGrupMessages.Deleted);
        }

        //[SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<StokGrup>>> GetList()
        {
            return new SuccessDataResult<List<StokGrup>>(await _stokGrupDal.GetAll());
        }

        //[SecuredAspect()]
        public async Task<IDataResult<StokGrup>> GetById(int id)
        {
            return new SuccessDataResult<StokGrup>(await _stokGrupDal.Get(p => p.StokGrupId == id));
        }

    }
}
