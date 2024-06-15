using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context.EntityFramework
{
    public class SimpleContextDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=RetinaB2B;Integrated Security=true;");
            optionsBuilder.UseSqlServer("Server=server.retinabilisim.com.tr;Database=technoboxb2b;User Id=sadikgok;  Password=HasanSadik5481!!;TrustServerCertificate=true;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<EmailParameter> EmailParameters { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<CustomerReliationship> CustomerReliationships { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PriceListDetail> PriceListDetails { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stok> Stoklar { get; set; }
        public DbSet<StokBakiyesi> StokBakiyeleri { get; set; }
        public DbSet<StokGrup> StokGruplari { get; set; }
        public DbSet<StokHareket> StokHareketleri { get; set; }
        public DbSet<Depo> Depolar { get; set; }
        public DbSet<Kasa> Kasalar { get; set; }
        public DbSet<KasaHareket> KasaHareketleri { get; set; }
        public DbSet<Islem> Islemler { get; set; }
        public DbSet<Cari> Cariler { get; set; }
        public DbSet<CariHareket> CariHareketleri { get; set; }
        public DbSet<IslemHareket> IslemHareketleri { get; set; }
        public DbSet<IslemDetay> IslemDetaylari { get; set; }
        public DbSet<FirmaBilgisi> FirmaBilgileri { get; set; } 
    }
}
