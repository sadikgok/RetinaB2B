using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.StokBakiyesiRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.StokBakiyesiRepository
{
    public class EfStokBakiyesiDal : EfEntityRepositoryBase<StokBakiyesi, SimpleContextDb>, IStokBakiyesiDal
    {
    }
}
