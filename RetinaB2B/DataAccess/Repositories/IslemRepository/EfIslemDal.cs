using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.IslemRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.IslemRepository
{
    public class EfIslemDal : EfEntityRepositoryBase<Islem, SimpleContextDb>, IIslemDal
    {
    }
}
