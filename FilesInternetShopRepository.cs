using Models;
using Models.Filters;
using Repository.Abstract;
using Repository.Abstract.IModelsRepositories;
using System;
using System.Collections.Generic;

namespace Repository.Concrete.Files
{
    public class FilesInternetShopRepository : IInternetShopRepository
    {
        public List<InternetShop> Get(InternetShopFilter filter)
        {
            List<InternetShop> ResultInternetShop = new List<InternetShop>();
            FilesProvider.OpenReader("InternetShop");

            int peek = FilesProvider.Peek();
            while (peek != -1)
            {
                string IdRow = FilesProvider.ReadRow();
                if (string.IsNullOrEmpty(IdRow)) break; // means that if file is empty
                string[] IdParts = IdRow.Split(':');
                int id = Convert.ToInt32(IdParts[1].Trim());


                string NameRow = FilesProvider.ReadRow();
                string[] NameParts = NameRow.Split(':');
                string name = NameParts[1].Trim();


                string CategoryRow = FilesProvider.ReadRow();
                string[] CategoryParts = NameRow.Split(':');
                string category = CategoryParts[1].Trim();

                string PriceRow = FilesProvider.ReadRow();
                string[] PriceParts = PriceRow.Split(':');
                string price = PriceParts[1].Trim();


                InternetShop Collection = new InternetShop(id, name, category, price);
                ResultInternetShop.Add(Collection);

                peek = FilesProvider.Peek();
                if (FilesProvider.ReadRow() == "") continue;
            } // while

            FilesProvider.CloseReader();
            return ResultInternetShop;
        }

        public void Add(InternetShopFilter filter)
        {
            FilesProvider.OpenWriter("InternetShop");
            InternetShop newCollection = new InternetShop();

            if (filter.Id.HasValue)
            {
                newCollection.Id = (int)filter.Id;
            }
            if (!string.IsNullOrEmpty(filter.Name))
            {
                newCollection.Name = filter.Name;
            }
            if (!string.IsNullOrEmpty(filter.Category))
            {
                newCollection.Category = filter.Category;
            }
            if (!string.IsNullOrEmpty(filter.Price))
            {
                newCollection.Price = filter.Price;
            }

            FilesProvider.WriteMusicCollection(newCollection);
            FilesProvider.CloseWriter();
        }

        public void Update(InternetShopFilter filter)
        {
            Delete(filter);
            Add(filter);
        }

        public void Delete(InternetShopFilter filter)
        {
            List<InternetShop> currentCollections = Get(new InternetShopFilter()); // gets ALL the Collections, because the filter is empty here
            FilesProvider.OpenWriter("InternetShop", false);
            foreach (InternetShop Collection in currentCollections)
                if (Collection.Id != filter.Id)
                    FilesProvider.WriteMusicCollection(Collection);

            FilesProvider.CloseWriter();
        }
    }
}
