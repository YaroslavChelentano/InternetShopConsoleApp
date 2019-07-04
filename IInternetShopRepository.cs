using Models;
using Models.Filters;
using System.Collections.Generic;

namespace Repository.Abstract
{
    public interface IInternetShopRepository
    {
        List<InternetShop> Get(InternetShopFilter filter);
        void Add(InternetShopFilter filter);
        void Update(InternetShopFilter filter);
        void Delete(InternetShopFilter filter);
    }
}
