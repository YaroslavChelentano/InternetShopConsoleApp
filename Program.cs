using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Filters;
using Repository.Abstract;
using Repository.Abstract.IFactory;
using Repository.Concrete.Factory;
namespace MusicCollectionTask9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "InternetShop";
            Start newprogram = new Start();
            newprogram.Starts();
        }
    }
}
