using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Repositories.KasaRepository
{
    public class EfKasaDal : EfEntityRepositoryBase<Kasa, SimpleContextDb>, IKasaDal
    {
    
    }
}
