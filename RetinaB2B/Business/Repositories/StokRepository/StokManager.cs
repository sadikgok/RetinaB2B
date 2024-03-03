using Business.Aspects.Secured;
using Business.Repositories.StokRepository.Constants;
using Business.Repositories.StokRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.StokRepository;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.StokRepository
{
    public class StokManager : IStokService
    {
        private readonly IStokDal _stokDal;

        public StokManager(IStokDal stokDal)
        {
            _stokDal = stokDal;
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(StokValidator))]
        [RemoveCacheAspect("IStokService.Get")]

        public async Task<IResult> Add(Stok stok)
        {
            await _stokDal.Add(stok);
            return new SuccessResult(StokMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(StokValidator))]
        [RemoveCacheAspect("IStokService.Get")]

        public async Task<IResult> Update(Stok stok)
        {
            await _stokDal.Update(stok);
            return new SuccessResult(StokMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IStokService.Get")]

        public async Task<IResult> Delete(Stok stok)
        {
            await _stokDal.Delete(stok);
            return new SuccessResult(StokMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<Stok>>> GetList()
        {
            return new SuccessDataResult<List<Stok>>(await _stokDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<Stok>> GetById(int stokId)
        {
            return new SuccessDataResult<Stok>(await _stokDal.Get(p => p.StokId == stokId));
        }

        public async Task<IDataResult<List<DepoStokDto>>> GetStokByDepoId(int depoId)
        {
            return new SuccessDataResult<List<DepoStokDto>>(await _stokDal.GetStokByDepoId(depoId));
        }

        public async Task<IDataResult<List<DepoStokDto>>> GetStokByGroupId(int groupId)
        {
            return new SuccessDataResult<List<DepoStokDto>>(await _stokDal.GetStokByGroupId(groupId));
        }

        public int GetLastStokId()
        {
            return  _stokDal.GetLastStokId();
        }
    }
}
