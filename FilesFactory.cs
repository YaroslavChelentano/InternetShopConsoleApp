using Repository.Abstract;
using Repository.Abstract.IFactory;
using Repository.Concrete.Files;
using Services.Abstract;
using Services.Concrete.FilesInternetShopServices;
namespace Repository.Concrete.Factory
{
    public class FilesFactory : IFactory
    {
        // Repository
        public IInternetShopRepository GetInternetShopRepository() => new FilesInternetShopRepository();
        //// Services
        public IInternetShopService GetInternetShopServices() => new FilesInternetShopServices();
    }
}
