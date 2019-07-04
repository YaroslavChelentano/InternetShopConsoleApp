using Models;
using System.IO;

namespace Repository.Abstract.IModelsRepositories
{
    public static class FilesProvider // FileHelper
    {
        static string path = @"C:\Users\Ярослав\source\repos\InternetTask9\";
        static string readPath;
        static string writePath;
        public static StreamReader Reader { get; private set; }
        public static StreamWriter Writer { get; private set; }


        public static void OpenReader(string filename)
        {
            readPath = path + filename + ".txt";
            Reader = new StreamReader(readPath);
        }

        public static void CloseReader()
        {
            Reader.Close();
        }

        public static string ReadRow()
        {
            return Reader.ReadLine();
        }

        public static string ReadAll()
        {
            return Reader.ReadToEnd();
        }

        public static int Peek()
        {
            return Reader.Peek();
        }

        public static bool End()
        {
            return Reader.EndOfStream;
        }





        public static void OpenWriter(string filename, bool append = true)
        {
            writePath = path + filename + ".txt";
            Writer = new StreamWriter(writePath, append);
        }

        public static void WriteLine(string line)
        {
            Writer.WriteLine(line);
        }

        public static void WriteMusicCollection(InternetShop collection)
        {
            Writer.WriteLine("Id: {0}", collection.Id);
            Writer.WriteLine("Name: {0}", collection.Name);
            Writer.WriteLine("Category: {0}", collection.Category);
            Writer.WriteLine("Price: {0}", collection.Price);
            Writer.WriteLine();
        }

        public static void CloseWriter()
        {
            Writer.Close();
        }
    }
}
