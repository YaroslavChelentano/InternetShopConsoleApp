using Repository.Abstract;
using Repository.Abstract.IFactory;
using Repository.Concrete.Db;
using Services.Abstract;
using Services.Concrete;

namespace Repository.Concrete.Factory
{
    public class DbFactory : IFactory
    {
        // Repository
        public IInternetShopRepository GetInternetShopRepository() => new DbInternetShopRepository();
        //// Services
        public IInternetShopService GetInternetShopServices() => new DbInternetShopServices();
    }
}