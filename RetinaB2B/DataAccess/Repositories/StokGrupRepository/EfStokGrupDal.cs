using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.StokGrupRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.StokGrupRepository
{
    public class EfStokGrupDal : EfEntityRepositoryBase<StokGrup, SimpleContextDb>, IStokGrupDal
    {
    }
}
