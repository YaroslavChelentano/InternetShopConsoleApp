using System;

namespace Models
{
    public class InternetShop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }


        public InternetShop() { }

        public InternetShop(int id, string name, string category , string price)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
        }

        public InternetShop(InternetShop other)
        {
            this.Id = other.Id;
            this.Name = other.Name;
            this.Category = other.Category;
            this.Price = other.Price;
        }
    }
}