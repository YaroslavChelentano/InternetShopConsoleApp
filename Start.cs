using Models;
using Models.Filters;
using Repository.Abstract;
using Repository.Abstract.IFactory;
using Repository.Concrete.Factory;
using Services.Abstract;
using System;
using System.Collections.Generic;

namespace MusicCollectionTask9
{
    public class Start
    {
        Menu menu = new Menu();
        IFactory factory;     // повертає модель 

        int repositoryChoice; // вибираєм репозиторія тхт чи базу даних
        int modelChoice;      // з якою моделюю працюєм
        int operationChoice;  // вибрати що роити з нею
        bool serviceUse = false;   
        int reset;       

        public void Starts()
        {
            Console.WriteLine("Hello to my mp3Player program .");
            menu.EmptyRows(2);
            do
            {
                // вибираєм директорію для роботи
                menu.ChooseRepository();
                repositoryChoice = Convert.ToInt32(Console.ReadLine());
                factory = Factory.GetFactory(repositoryChoice);
                menu.EmptyRows(1);

                // тепер модель
                menu.ChooseModel();
                modelChoice = Convert.ToInt32(Console.ReadLine());
                menu.EmptyRows(1);

                // choose the operation: Get, Add, Update or Delete raw?
                menu.ChooseOperation();
                operationChoice = Convert.ToInt32(Console.ReadLine());
                menu.EmptyRows(1);

                // realization of operations with definite model
                operationRealization(operationChoice);
                menu.EmptyRows(1);
                menu.SuccessfullyDone();

                //// додаткові функції
                menu.UseServices();
                int useServices = int.Parse(Console.ReadLine());
                serviceUse = true ? useServices == 1 : false;
                Console.WriteLine("Please enter 1: if you want to open website)");
                if (serviceUse)
                    servicesRealization(modelChoice);
                menu.AskToContinue();
                reset = Convert.ToInt32(Console.ReadLine());

                menu.EmptyRows(2);
            } while (reset == 1);

            menu.Bye();

        }

        void servicesRealization(int modelChoice)
        {
            switch (modelChoice)
            {
                case 1:
                default:
                    InternetShopService();
                    break;
            }
        }
        void operationRealization(int operationChoice)
        {
            switch (operationChoice)
            {
                case 1: // Get
                default:
                    getModel(modelChoice);
                    break;

                case 2: // Add
                    addToModel(modelChoice);
                    break;

                case 3: // Update
                    updateModel(modelChoice);
                    break;

                case 4: // Delete
                    deleteFromModel(modelChoice);
                    break;
            }
        }

        void getModel(int modelChoice)
        {
            switch (modelChoice)
            {
                case 1:
                    getInternetShop();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        void addToModel(int modelChoice)
        {
            switch (modelChoice)
            {
                case 1:
                    addToInternetShop();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        void updateModel(int modelChoice)
        {
            switch (modelChoice)
            {
                case 1:
                    updateInternetShop();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        void deleteFromModel(int modelChoice)
        {
            switch (modelChoice)
            {
                case 1:
                    deleteFromInternetShop();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
        void getInternetShop()
        {
            IInternetShopRepository InternetShopRepo = factory.GetInternetShopRepository();

            InternetShopFilter filter = new InternetShopFilter();
            menu.EmptyRows(1);

            List<InternetShop> chosenCollections = new List<InternetShop>(InternetShopRepo.Get(filter));
            // console output
            showInternetShop(chosenCollections);
        }

        void addToInternetShop()
        {
            IInternetShopRepository InternetShopRepo = factory.GetInternetShopRepository();

            menu.CurrentInternetShop();
            showInternetShop(new List<InternetShop>(InternetShopRepo.Get(new InternetShopFilter())));

            InternetShopFilter filter = new InternetShopFilter();
            filter.SetConditions();
            menu.EmptyRows(1);
            InternetShopRepo.Add(filter);

            menu.InternetShopAfter();
            showInternetShop(new List<InternetShop>(InternetShopRepo.Get(new InternetShopFilter())));
        }

        void updateInternetShop()
        {
            IInternetShopRepository InternetShopRepo = factory.GetInternetShopRepository();

            menu.CurrentInternetShop();
            showInternetShop(new List<InternetShop>(InternetShopRepo.Get(new InternetShopFilter())));

            InternetShopFilter filter = new InternetShopFilter();
            filter.SetConditions();
            menu.EmptyRows(1);
            InternetShopRepo.Update(filter);

            menu.InternetShopAfter();
            showInternetShop(new List<InternetShop>(InternetShopRepo.Get(new InternetShopFilter())));
        }

        void deleteFromInternetShop()
        {
            IInternetShopRepository InternetShopRepo = factory.GetInternetShopRepository();

            menu.CurrentInternetShop();
            showInternetShop(new List<InternetShop>(InternetShopRepo.Get(new InternetShopFilter())));

            menu.InputInternetShopId();
            InternetShopFilter filter = new InternetShopFilter();
            filter.Id = Convert.ToInt32(Console.ReadLine());
            menu.EmptyRows(1);
            InternetShopRepo.Delete(filter);

            menu.InternetShopAfter();
            showInternetShop(new List<InternetShop>(InternetShopRepo.Get(new InternetShopFilter())));
        }
        void InternetShopService()
        {
            int InternetShopServiceChoice = Convert.ToInt32(Console.ReadLine());
            chooseInternetShopService(InternetShopServiceChoice);
        }

        void chooseInternetShopService(int InternetShopServiceChoice)
        {
            IInternetShopService InternetShopServices = factory.GetInternetShopServices();
            switch (InternetShopServiceChoice)
            {
                case 1:
                default:
                    InternetShopServices.openHref();
                    break;
            }
        }
        void showInternetShop(List<InternetShop> CollectionsList)
        {
            Console.WriteLine("|_________________________________________|");
            foreach (InternetShop member in CollectionsList)
            {
                Console.WriteLine("Id: {0}", member.Id);
                Console.WriteLine("Name: {0}", member.Name);
                Console.WriteLine("Category: {0}", member.Category);
                Console.WriteLine("Price: {0}", member.Price);
                Console.WriteLine();
            }
            Console.WriteLine("|_________________________________________|");
            menu.EmptyRows(1);
        }
    }
}