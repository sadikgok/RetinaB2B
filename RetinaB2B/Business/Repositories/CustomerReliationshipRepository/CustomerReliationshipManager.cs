using Business.Aspects.Secured;
using Business.Repositories.CustomerReliationshipRepository.Constants;
using Business.Repositories.CustomerReliationshipRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.CustomerReliationshipRepository;
using Entities.Concrete;

namespace Business.Repositories.CustomerReliationshipRepository
{
    public class CustomerReliationshipManager : ICustomerReliationshipService
    {
        private readonly ICustomerReliationshipDal _customerReliationshipDal;

        public CustomerReliationshipManager(ICustomerReliationshipDal customerReliationshipDal)
        {
            _customerReliationshipDal = customerReliationshipDal;
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(CustomerReliationshipValidator))]
        [RemoveCacheAspect("ICustomerReliationshipService.Get")]

        public async Task<IResult> Add(CustomerReliationship customerReliationship)
        {
            await _customerReliationshipDal.Add(customerReliationship);
            return new SuccessResult(CustomerReliationshipMessages.Added);
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(CustomerReliationshipValidator))]
        [RemoveCacheAspect("ICustomerReliationshipService.Get")]
        [RemoveCacheAspect("ICustomerService.Get")]
        public async Task<IResult> Update(CustomerReliationship customerReliationship)
        {
            var result = await _customerReliationshipDal.Get(p => p.CustomerId == customerReliationship.CustomerId);
            if (result != null)
            {
                customerReliationship.Id = result.Id;
                await _customerReliationshipDal.Update(customerReliationship);
            }
            else
            {
                await _customerReliationshipDal.Add(customerReliationship);
            }
            await _customerReliationshipDal.Update(customerReliationship);
            return new SuccessResult(CustomerReliationshipMessages.Updated);
        }

        //[SecuredAspect()]
        [RemoveCacheAspect("ICustomerReliationshipService.Get")]

        public async Task<IResult> Delete(CustomerReliationship customerReliationship)
        {
            await _customerReliationshipDal.Delete(customerReliationship);
            return new SuccessResult(CustomerReliationshipMessages.Deleted);
        }

        //[SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<CustomerReliationship>>> GetList()
        {
            return new SuccessDataResult<List<CustomerReliationship>>(await _customerReliationshipDal.GetAll());
        }

        //[SecuredAspect()]
        public async Task<IDataResult<CustomerReliationship>> GetById(int id)
        {
            return new SuccessDataResult<CustomerReliationship>(await _customerReliationshipDal.Get(p => p.Id == id));
        }

        //[SecuredAspect()]
        public async Task<IDataResult<CustomerReliationship>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<CustomerReliationship>(await _customerReliationshipDal.Get(p => p.CustomerId == customerId));
        }
    }
}
