using Services.Abstract;


namespace Repository.Abstract.IFactory
{
    public interface IFactory // interface for fabric which connects to the system, executes command, [ reads and writes information to the system(?) ]
    {
        // Repository
        IInternetShopRepository GetInternetShopRepository(); // to implement directly realization of queries for Db or Files.
        //// Services
        IInternetShopService GetInternetShopServices();
    }
}
