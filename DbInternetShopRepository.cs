using Models;
using Models.Filters;
using Repository.Abstract;
using Repository.Abstract.IModelsRepositories;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Concrete.Db
{
    public class DbInternetShopRepository : IInternetShopRepository
    {
        public DbInternetShopRepository()
        {
            DatabaseProvider.InitializeFactory();
            DatabaseProvider.InitializeConnectionString();
        }


        public List<InternetShop> Get(InternetShopFilter filter)
        {
            List<InternetShop> ResultInternetShop = new List<InternetShop>();
            DatabaseProvider.CreateConnectionAndCommand();
            //
            string cmd = "SELECT * FROM Names";
            List<string> conditions = new List<string>();
            //
            if (filter.Id.HasValue)
            {
                conditions.Add("Id = " + filter.Id.ToString());
            }
            if (!string.IsNullOrEmpty(filter.Name))
            {
                conditions.Add(string.Format("Name = '{0}'", filter.Name));
            }
            if (!string.IsNullOrEmpty(filter.Category))
            {
                conditions.Add(string.Format("Category = '{0}'", filter.Category));
            }
            if (!string.IsNullOrEmpty(filter.Price))
            {
                conditions.Add(string.Format("Price = '{0}'", filter.Price));
            }

            if (conditions.Count() > 0)
            {
                cmd += " WHERE " + string.Join(" AND ", conditions.ToArray());
            }
            DatabaseProvider.ExecuteCommand(cmd);
            //
            DatabaseProvider.BeginReader();
            while (DatabaseProvider.Reader.Read())
            {
                int id = (int)DatabaseProvider.Reader["id"];
                string name = (string)DatabaseProvider.Reader["name"];
                string category = (string)DatabaseProvider.Reader["category"];
                string price = (string)DatabaseProvider.Reader["Price"];

                InternetShop collection = new InternetShop(id, name, category, price);
                ResultInternetShop.Add(collection);
            }
            DatabaseProvider.FinishReader();
            //
            DatabaseProvider.CloseConnection();
            return ResultInternetShop;
        }

        public void Add(InternetShopFilter filter)
        {
            DatabaseProvider.CreateConnectionAndCommand();
            //
            string cmd = "INSERT INTO Names (id, Name, Category, Price) VALUES ";
            cmd = cmd + "(";
            List<string> valueComponents = new List<string>();

            if (filter.Id.HasValue)
            {
                valueComponents.Add(filter.Id.ToString());
            }
            if (!string.IsNullOrEmpty(filter.Name))
            {
                valueComponents.Add(string.Format("'{0}'", filter.Name));
            }
            if (!string.IsNullOrEmpty(filter.Category))
            {
                valueComponents.Add(string.Format("'{0}'", filter.Category));
            }
            if (!string.IsNullOrEmpty(filter.Price))
            {
                valueComponents.Add(string.Format("'{0}'", filter.Price));
            }

            string join = string.Join(", ", valueComponents);
            cmd = cmd + join;
            cmd = cmd + ");";

            DatabaseProvider.ExecuteCommand(cmd);
            DatabaseProvider.CloseConnection();
        }

        public void Update(InternetShopFilter filter)
        {
            DatabaseProvider.CreateConnectionAndCommand();

            string cmd = "UPDATE Names SET ";
            List<string> columnsToUpdate = new List<string>();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                columnsToUpdate.Add(string.Format("Name = '{0}'", filter.Name));
            }
            if (!string.IsNullOrEmpty(filter.Category))
            {
                columnsToUpdate.Add(string.Format("Category = '{0}'", filter.Category));
            }
            if (!string.IsNullOrEmpty(filter.Price))
            {
                columnsToUpdate.Add(string.Format("Price = '{0}'", filter.Price));
            }

            string where = string.Format(" WHERE id = {0};", filter.Id);
            cmd = cmd + string.Join(", ", columnsToUpdate.ToArray()) + where;

            DatabaseProvider.ExecuteCommand(cmd);
            DatabaseProvider.CloseConnection();
        }

        public void Delete(InternetShopFilter filter)
        {
            DatabaseProvider.CreateConnectionAndCommand();

            string cmd = string.Format("DELETE FROM Names WHERE Id = {0}", filter.Id);

            DatabaseProvider.ExecuteCommand(cmd);
            DatabaseProvider.CloseConnection();
        }
    }
}