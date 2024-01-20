using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.CustomerReliationshipRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.CustomerReliationshipRepository
{
    public class EfCustomerReliationshipDal : EfEntityRepositoryBase<CustomerReliationship, SimpleContextDb>, ICustomerReliationshipDal
    {
    }
}
