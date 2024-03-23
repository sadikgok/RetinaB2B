using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Authentication;
using Business.Repositories.EmailParameterRepository;
using Business.Repositories.OperationClaimRepository;
using Business.Repositories.UserOperationClaimRepository;
using Business.Repositories.UserRepository;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Repositories.EmailParameterRepository;
using DataAccess.Repositories.OperationClaimRepository;
using DataAccess.Repositories.UserOperationClaimRepository;
using Business.Repositories.BasketRepository;
using DataAccess.Repositories.BasketRepository;
using Business.Repositories.CustomerReliationshipRepository;
using DataAccess.Repositories.CustomerReliationshipRepository;
using Business.Repositories.CustomerRepository;
using DataAccess.Repositories.CustomerRepository;
using Business.Repositories.OrderDetailRepository;
using DataAccess.Repositories.OrderDetailRepository;
using Business.Repositories.OrderRepository;
using DataAccess.Repositories.OrderRepository;
using Business.Repositories.PriceListDetailRepository;
using DataAccess.Repositories.PriceListDetailRepository;
using Business.Repositories.ProductImageRepository;
using DataAccess.Repositories.ProductImageRepository;
using Business.Repositories.PriceListRepository;
using DataAccess.Repositories.PriceListRepository;
using Business.Repositories.ProductRepository;
using DataAccess.Repositories.ProductRepository;
using Business.Repositories.StokRepository;
using DataAccess.Repositories.StokRepository;
using Business.Repositories.StokBakiyesiRepository;
using DataAccess.Repositories.StokBakiyesiRepository;
using Business.Repositories.StokGrupRepository;
using DataAccess.Repositories.StokGrupRepository;
using Business.Repositories.StokHareketRepository;
using DataAccess.Repositories.StokHareketRepository;
using Business.Repositories.DepoRepository;
using DataAccess.Repositories.DepoRepository;
using Business.Repositories.KasaRepository;
using DataAccess.Repositories.KasaRepository;
using Business.Repositories.KasaHareketRepository;
using DataAccess.Repositories.KasaHareketRepository;
using Business.Repositories.IslemRepository;
using DataAccess.Repositories.IslemRepository;
using Business.Repositories.CariRepository;
using DataAccess.Repositories.CariRepository;
using Business.Repositories.CariHareketRepository;
using DataAccess.Repositories.CariHareketRepository;
using DataAccess.Repositories.UserRepository;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

            builder.RegisterType<EmailParameterManager>().As<IEmailParameterService>();
            builder.RegisterType<EfEmailParameterDal>().As<IEmailParameterDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<TokenHandler>().As<ITokenHandler>();

            builder.RegisterType<BasketManager>().As<IBasketService>().SingleInstance();
            builder.RegisterType<EfBasketDal>().As<IBasketDal>().SingleInstance();

            builder.RegisterType<CustomerReliationshipManager>().As<ICustomerReliationshipService>().SingleInstance();
            builder.RegisterType<EfCustomerReliationshipDal>().As<ICustomerReliationshipDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>().SingleInstance();
            builder.RegisterType<EfOrderDetailDal>().As<IOrderDetailDal>().SingleInstance();

            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();

            builder.RegisterType<PriceListDetailManager>().As<IPriceListDetailService>().SingleInstance();
            builder.RegisterType<EfPriceListDetailDal>().As<IPriceListDetailDal>().SingleInstance();

            builder.RegisterType<ProductImageManager>().As<IProductImageService>().SingleInstance();
            builder.RegisterType<EfProductImageDal>().As<IProductImageDal>().SingleInstance();

            builder.RegisterType<PriceListManager>().As<IPriceListService>().SingleInstance();
            builder.RegisterType<EfPriceListDal>().As<IPriceListDal>().SingleInstance();

            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<StokManager>().As<IStokService>().SingleInstance();
            builder.RegisterType<EfStokDal>().As<IStokDal>().SingleInstance();

            builder.RegisterType<StokBakiyesiManager>().As<IStokBakiyesiService>().SingleInstance();
            builder.RegisterType<EfStokBakiyesiDal>().As<IStokBakiyesiDal>().SingleInstance();

            builder.RegisterType<StokGrupManager>().As<IStokGrupService>().SingleInstance();
            builder.RegisterType<EfStokGrupDal>().As<IStokGrupDal>().SingleInstance();

            builder.RegisterType<StokHareketManager>().As<IStokHareketService>().SingleInstance();
            builder.RegisterType<EfStokHareketDal>().As<IStokHareketDal>().SingleInstance();

            builder.RegisterType<DepoManager>().As<IDepoService>().SingleInstance();
            builder.RegisterType<EfDepoDal>().As<IDepoDal>().SingleInstance();

            builder.RegisterType<KasaManager>().As<IKasaService>().SingleInstance();
            builder.RegisterType<EfKasaDal>().As<IKasaDal>().SingleInstance();

            builder.RegisterType<KasaHareketManager>().As<IKasaHareketService>().SingleInstance();
            builder.RegisterType<EfKasaHareketDal>().As<IKasaHareketDal>().SingleInstance();

            builder.RegisterType<IslemManager>().As<IIslemService>().SingleInstance();
            builder.RegisterType<EfIslemDal>().As<IIslemDal>().SingleInstance();

            builder.RegisterType<CariManager>().As<ICariService>().SingleInstance();
            builder.RegisterType<EfCariDal>().As<ICariDal>().SingleInstance();

            builder.RegisterType<CariHareketManager>().As<ICariHareketService>().SingleInstance();
            builder.RegisterType<EfCariHareketDal>().As<ICariHareketDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
