using Models;
using Models.Filters;
using Repository.Concrete.Db;
using Services.Abstract;
using System.Collections.Generic;
using System;
namespace Services.Concrete
{
    public class DbInternetShopServices : IInternetShopService
    {
        public void openHref()
        {
            Console.WriteLine("Choose id of wares you want to see");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                System.Diagnostics.Process.Start("https://rozetka.com.ua/xiaomi_redmi_6a_2_16gb_black_eu/p53975310/");
            }
            if (choice == 2)
            {
                System.Diagnostics.Process.Start("https://rozetka.com.ua/asus_d540na_gq211t/p70599548/");
            }
            if (choice == 3)
            {
                System.Diagnostics.Process.Start("https://rozetka.com.ua/intertool_gb-0001/p290372/");
            }
            else
                Console.WriteLine("We dont have this reference");
        }
    }
}
