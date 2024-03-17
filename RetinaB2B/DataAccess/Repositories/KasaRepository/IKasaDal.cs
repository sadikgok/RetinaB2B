using Core.DataAccess;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace DataAccess.Repositories.KasaRepository
{
    public interface IKasaDal : IEntityRepository<Kasa>
    {
        void KasaBakiyeArtir(int kasaId, decimal islemTutari);
        void KasaBakiyeDusur(int kasaId, decimal islemTutari);
    }
}
