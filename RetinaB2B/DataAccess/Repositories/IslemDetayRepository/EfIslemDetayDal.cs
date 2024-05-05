using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.IslemDetayRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.IslemDetayRepository
{
    public class EfIslemDetayDal : EfEntityRepositoryBase<IslemDetay, SimpleContextDb>, IIslemDetayDal
    {
    }
}
