using System;
namespace MusicCollectionTask9
{
    public class Menu
    {
        public void EmptyRows(int count)
        {
            for (int i = 0; i < count; i++)
                Console.WriteLine();
        }
        public void ChooseRepository()
        {
            Console.WriteLine("Choose repository to work with:");
            Console.WriteLine("1. Database");
            Console.WriteLine("2. TXT-files");
        }

        public void ChooseModel()
        {
            Console.WriteLine("Choose model");
            Console.WriteLine("1. InternetShop");
        }

        public void ChooseOperation()
        {
            Console.WriteLine("Choose action");
            Console.WriteLine("1. Select ");
            Console.WriteLine("2. Add ");
            Console.WriteLine("3. Update ");
            Console.WriteLine("4. Delete ");
        }
        public void UseServices()
        {
            Console.WriteLine("Use services?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
        }
        public void CurrentInternetShop()
        {
            Console.WriteLine("\tCurrent InternetShop:");
        }

        public void InputInternetShopId()
        {
            Console.WriteLine("Input the collection's id you would like to delete: ");
            Console.Write("Id = ");
        }

        public void InternetShopAfter()
        {
            Console.WriteLine("\tHow 'InternetShop' looks now:");
        }
        public void SuccessfullyDone()
        {
            Console.WriteLine("Success");
        }

        public void AskToContinue()
        {
            Console.WriteLine("Continue to work?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");

        }

        public void Bye()
        {
            Console.WriteLine("Good bye!");
        }
    }
}

