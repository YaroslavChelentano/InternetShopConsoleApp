using System;

namespace Models.Filters
{
    public class InternetShopFilter
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }


        public InternetShopFilter() => NullAll();

        public void NullAll()
        {
            Id = null;
            Name = null;
            Category = null;
            Price = null; 
        }

        public void SetConditions(bool needConditions = true)
        {
            if (needConditions)
            {
                Console.WriteLine("Input parameters which you would like to use for the row (input 'null' if you don't need it):");

                Console.Write("- Id: ");
                string id = Convert.ToString(Console.ReadLine());
                if (id == "null") Id = null;
                else Id = Convert.ToInt32(id);

                Console.Write("- Name: ");
                string name = Convert.ToString(Console.ReadLine());
                if (name == "null") Name = null;
                else Name = name;

                Console.Write("- Category: ");
                string category = Convert.ToString(Console.ReadLine());
                if (category == "null") Category = null;
                else Category = category;

                Console.Write("- Price: ");
                string price = Convert.ToString(Console.ReadLine());
                if (price == "null") Price = null;
                else Price = price;
            } // if (needConditions)
            else NullAll();
        }
    }
}