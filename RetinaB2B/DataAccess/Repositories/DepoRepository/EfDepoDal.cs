using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.DepoRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.DepoRepository
{
    public class EfDepoDal : EfEntityRepositoryBase<Depo, SimpleContextDb>, IDepoDal
    {
    }
}
