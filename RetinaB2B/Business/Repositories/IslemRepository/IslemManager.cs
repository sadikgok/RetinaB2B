using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.IslemRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.IslemRepository.Validation;
using Business.Repositories.IslemRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.IslemRepository;

namespace Business.Repositories.IslemRepository
{
    public class IslemManager : IIslemService
    {
        private readonly IIslemDal _ıslemDal;

        public IslemManager(IIslemDal ıslemDal)
        {
            _ıslemDal = ıslemDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(IslemValidator))]
        [RemoveCacheAspect("IIslemService.Get")]

        public async Task<IResult> Add(Islem ıslem)
        {
            await _ıslemDal.Add(ıslem);
            return new SuccessResult(IslemMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(IslemValidator))]
        [RemoveCacheAspect("IIslemService.Get")]

        public async Task<IResult> Update(Islem ıslem)
        {
            await _ıslemDal.Update(ıslem);
            return new SuccessResult(IslemMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IIslemService.Get")]

        public async Task<IResult> Delete(Islem ıslem)
        {
            await _ıslemDal.Delete(ıslem);
            return new SuccessResult(IslemMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<Islem>>> GetList()
        {
            return new SuccessDataResult<List<Islem>>(await _ıslemDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<Islem>> GetById(int id)
        {
            return new SuccessDataResult<Islem>(await _ıslemDal.Get(p => p.Id == id));
        }

    }
}
