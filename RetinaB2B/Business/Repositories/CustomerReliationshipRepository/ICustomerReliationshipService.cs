using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.CustomerReliationshipRepository
{
    public interface ICustomerReliationshipService
    {
        Task<IResult> Add(CustomerReliationship customerReliationship);
        Task<IResult> Update(CustomerReliationship customerReliationship);
        Task<IResult> Delete(CustomerReliationship customerReliationship);
        Task<IDataResult<List<CustomerReliationship>>> GetList();
        Task<IDataResult<CustomerReliationship>> GetById(int id);
        Task<IDataResult<CustomerReliationship>> GetByCustomerId(int customerId); 
    }
}
