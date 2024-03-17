using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Repositories.KasaRepository
{
    public class EfKasaDal : EfEntityRepositoryBase<Kasa, SimpleContextDb>, IKasaDal
    {
        public void KasaBakiyeArtir(int kasaId, decimal islemTutari)
        {
            using (var context = new SimpleContextDb())
            {
                var kasa = context.Kasalar.SingleOrDefault(k => k.KasaId == kasaId);
                if (kasa != null)
                {
                    kasa.KasaBakiye += islemTutari;
                    context.SaveChanges();
                }
            }
        }

        public void KasaBakiyeDusur(int kasaId, decimal islemTutari)
        {
            using (var context = new SimpleContextDb())
            {
                var kasa = context.Kasalar.SingleOrDefault(k => k.KasaId == kasaId);
                if (kasa != null)
                {
                    kasa.KasaBakiye = islemTutari;
                    context.SaveChanges();
                }
            }
        }
    }
}
