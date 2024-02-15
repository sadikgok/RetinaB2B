using Business.Aspects.Secured;
using Business.Repositories.CustomerReliationshipRepository;
using Business.Repositories.CustomerRepository.Constants;
using Business.Repositories.CustomerRepository.Validation;
using Business.Repositories.OrderRepository;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Business;
using Core.Utilities.Hashing;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.CustomerRepository;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.CustomerRepository
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly ICustomerReliationshipService _customerReliationshipService;
        private readonly IOrderService _orderService;
        public CustomerManager(ICustomerDal customerDal, ICustomerReliationshipService customerReliationshipService, IOrderService orderService)
        {
            _customerDal = customerDal;
            _customerReliationshipService = customerReliationshipService;
            _orderService = orderService;
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(CustomerValidator))]
        [RemoveCacheAspect("ICustomerService.Get")]

        public async Task<IResult> Add(CustomerRegisterDto customerRegisterDto)
        {
            IResult result = BusinessRules.Run(
                await CheckIfEmailExist(customerRegisterDto.Email));
            if (result != null)
            {
                return result;
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePassword(customerRegisterDto.Password, out passwordHash, out passwordSalt);
            Customer customer = new Customer
            {
                Id = 0,
                Email = customerRegisterDto.Email,
                Name = customerRegisterDto.Name,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,

            };

            await _customerDal.Add(customer);
            return new SuccessResult(CustomerMessages.Added);
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(CustomerValidator))]
        [RemoveCacheAspect("ICustomerService.Get")]

        public async Task<IResult> Update(Customer customer)
        {
            await _customerDal.Update(customer);
            return new SuccessResult(CustomerMessages.Updated);
        }

        //[SecuredAspect()]
        [RemoveCacheAspect("ICustomerService.Get")]

        public async Task<IResult> Delete(Customer customer)
        {
            IResult result = BusinessRules.Run(await CheckIfCustomerOrderExist(customer.Id));
            if (result != null)
            {
                return result;
            }

            var customerRelationship = await _customerReliationshipService.GetByCustomerId(customer.Id);
            if (customerRelationship.Data != null)
            {
                await _customerReliationshipService.Delete(customerRelationship.Data);
            }
            await _customerDal.Delete(customer);
            return new SuccessResult(CustomerMessages.Deleted);
        }

        public async Task<IResult> CheckIfCustomerOrderExist(int customerId)
        {
            var result
                = await _orderService.GetListByCustomerId(customerId);
            if (result.Data.Count > 0)
            {
                return new ErrorResult("Sipariþi bulunan müþteri kaydý silinemez");
            }
            return new SuccessResult();
        }

        //[SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<CustomerDto>>> GetList()
        {
            return new SuccessDataResult<List<CustomerDto>>(await _customerDal.GetListDto());
        }

        //[SecuredAspect()]
        public async Task<IDataResult<Customer>> GetById(int id)
        {
            return new SuccessDataResult<Customer>(await _customerDal.Get(p => p.Id == id));
        }

        //[SecuredAspect()]
        public async Task<IDataResult<CustomerDto>> GetDtoById(int id)
        {
            return new SuccessDataResult<CustomerDto>(await _customerDal.GetDto(id));
        }
        public async Task<Customer> GetByEmail(string email)
        {
            var result = await _customerDal.Get(p => p.Email == email);
            return result;
        }

        private async Task<IResult> CheckIfEmailExist(string email)
        {
            var list = await GetByEmail(email);
            if (list != null)
            {
                return new ErrorResult("Bu mail adresi daha önce kullanýlmýþ");
            }
            return new SuccessResult();
        }

        //[SecuredAspect()]
        public async Task<IResult> ChangePasswordByAdminPanel(CustomerChangePasswordByAdminPanelDto customerDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePassword(customerDto.Password, out passwordHash, out passwordSalt);
            var customer = await _customerDal.Get(p => p.Id == customerDto.Id);
            customer.PasswordHash = passwordHash;
            customer.PasswordSalt = passwordSalt;
            await _customerDal.Update(customer);
            return new SuccessResult(CustomerMessages.ChangePassword);
        }
    }
}
