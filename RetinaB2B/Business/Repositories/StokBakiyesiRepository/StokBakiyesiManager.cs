using Business.Aspects.Secured;
using Business.Repositories.StokBakiyesiRepository.Constants;
using Business.Repositories.StokBakiyesiRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.StokBakiyesiRepository;
using Entities.Concrete;

namespace Business.Repositories.StokBakiyesiRepository
{
    public class StokBakiyesiManager : IStokBakiyesiService
    {
        private readonly IStokBakiyesiDal _stokBakiyesiDal;

        public StokBakiyesiManager(IStokBakiyesiDal stokBakiyesiDal)
        {
            _stokBakiyesiDal = stokBakiyesiDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(StokBakiyesiValidator))]
        [RemoveCacheAspect("IStokBakiyesiService.Get")]

        public async Task<IResult> Add(StokBakiyesi stokBakiyesi)
        {
            await _stokBakiyesiDal.Add(stokBakiyesi);
            return new SuccessResult(StokBakiyesiMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(StokBakiyesiValidator))]
        [RemoveCacheAspect("IStokBakiyesiService.Get")]

        public async Task<IResult> Update(StokBakiyesi stokBakiyesi)
        {
            await _stokBakiyesiDal.Update(stokBakiyesi);
            return new SuccessResult(StokBakiyesiMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IStokBakiyesiService.Get")]

        public async Task<IResult> Delete(StokBakiyesi stokBakiyesi)
        {
            await _stokBakiyesiDal.Delete(stokBakiyesi);
            return new SuccessResult(StokBakiyesiMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<StokBakiyesi>>> GetList()
        {
            return new SuccessDataResult<List<StokBakiyesi>>(await _stokBakiyesiDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<StokBakiyesi>> GetById(int id)
        {
            return new SuccessDataResult<StokBakiyesi>(await _stokBakiyesiDal.Get(p => p.StokId == id));
        }

    }
}
