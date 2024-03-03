using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.StokHareketRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.StokHareketRepository
{
    public class EfStokHareketDal : EfEntityRepositoryBase<StokHareket, SimpleContextDb>, IStokHareketDal
    {
    }
}
