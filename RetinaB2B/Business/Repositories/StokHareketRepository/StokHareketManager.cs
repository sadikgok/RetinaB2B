using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.StokHareketRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.StokHareketRepository.Validation;
using Business.Repositories.StokHareketRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.StokHareketRepository;

namespace Business.Repositories.StokHareketRepository
{
    public class StokHareketManager : IStokHareketService
    {
        private readonly IStokHareketDal _stokHareketDal;

        public StokHareketManager(IStokHareketDal stokHareketDal)
        {
            _stokHareketDal = stokHareketDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(StokHareketValidator))]
        [RemoveCacheAspect("IStokHareketService.Get")]

        public async Task<IResult> Add(StokHareket stokHareket)
        {
            await _stokHareketDal.Add(stokHareket);
            return new SuccessResult(StokHareketMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(StokHareketValidator))]
        [RemoveCacheAspect("IStokHareketService.Get")]

        public async Task<IResult> Update(StokHareket stokHareket)
        {
            await _stokHareketDal.Update(stokHareket);
            return new SuccessResult(StokHareketMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IStokHareketService.Get")]

        public async Task<IResult> Delete(StokHareket stokHareket)
        {
            await _stokHareketDal.Delete(stokHareket);
            return new SuccessResult(StokHareketMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<StokHareket>>> GetList()
        {
            return new SuccessDataResult<List<StokHareket>>(await _stokHareketDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<StokHareket>> GetById(int id)
        {
            return new SuccessDataResult<StokHareket>(await _stokHareketDal.Get(p => p.StokId == id));
        }

    }
}
