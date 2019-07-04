using Repository.Abstract.IFactory;
using System;

namespace Repository.Concrete.Factory
{
    // Fabric method [Pattern]
    public static class Factory
    {
        public static IFactory GetFactory(int factoryChoice)
        {
            switch (factoryChoice)
            {
                case 1:
                    return new DbFactory();
                case 2:
                    return new FilesFactory();
                default:
                    Console.WriteLine("You have inputted the wrong system's type. You will work with default system: Database.");
                    return new DbFactory();
            }

        }
    }
}
