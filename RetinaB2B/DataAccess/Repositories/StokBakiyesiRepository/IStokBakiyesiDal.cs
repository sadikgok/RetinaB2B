using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Repositories.StokBakiyesiRepository
{
    public interface IStokBakiyesiDal : IEntityRepository<StokBakiyesi>
    {
        Task StokBakiyeDusur(StokBakiyesi stokBakiyesi);
        Task StokBakiyeArtir(StokBakiyesi stokBakiyesi); 
    }
}
