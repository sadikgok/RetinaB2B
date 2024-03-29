using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.StokRepository
{
    public interface IStokDal : IEntityRepository<Stok>
    {
        Task<List<DepoStokDto>> GetStokByDepoId(int depoId);
        Task<List<DepoStokDto>> GetStokByGroupId(int groupId);
        int GetLastStokId();

        //List<Stoklar> StoklariAdinaGoreGetir(string stokAdi);

        //List<StokModel> GunlukSatilanStoklariGetir();

        //Stok BarcodeyeGoreStokSorgula(string barcode);

        //decimal GetStokBakiyeById(int stokId);

        //decimal GetStokAlisFiyatiById(int stokId);

        //void AddStokAlisFiyati(int stokId, decimal alisFiyati);
        //decimal StokIndirimliSatisFiyatiGetir(string barcode, int miktar, string cariGurubu);
    }
}
