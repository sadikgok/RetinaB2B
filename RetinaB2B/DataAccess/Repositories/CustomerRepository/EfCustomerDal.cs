using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.CustomerRepository
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, SimpleContextDb>, ICustomerDal
    {
        public async Task<List<CustomerDto>> GetListDto()
        {
            using (var context = new SimpleContextDb())
            {
                var result = from customer in context.Customers
                             select new CustomerDto
                             {
                                 Id = customer.Id,
                                 Email = customer.Email,
                                 Name = customer.Name,
                                 PasswordHash = customer.PasswordHash,
                                 PasswordSalt = customer.PasswordSalt,
                                 PriceListId = (context.CustomerReliationships.Where(p => p.CustomerId == customer.Id) != null
                                 ? context.CustomerReliationships.Where(p => p.CustomerId == customer.Id).Select(s => s.PriceListId).FirstOrDefault()
                                 : 0),
                                 PriceListName =
                                 (context.CustomerReliationships.Where(p => p.CustomerId == customer.Id) != null
                                 ? context.PriceLists.Where(p => p.Id == (context.CustomerReliationships.Where(p => p.CustomerId
                                 == customer.Id).Select(s => s.PriceListId).FirstOrDefault())).Select(s => s.Name).FirstOrDefault() : "")
                             };
                return await result.OrderBy(p => p.Name).ToListAsync();
            }
        }
    }
}
