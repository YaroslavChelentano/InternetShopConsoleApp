using System.Configuration;
using System.Data.Common;

namespace Repository.Abstract.IModelsRepositories
{
    public static class DatabaseProvider
    {
        static string Provider = "Npgsql";
        static string ConnectionString = "Internet";

        public static DbProviderFactory Factory { get; set; }
        public static DbConnection Connection { get; set; }
        public static DbCommand Command { get; set; }
        public static DbDataReader Reader { get; set; }


        public static void InitializeFactory(string provider = "Npgsql")
        {
            Provider = provider;
            Factory = DbProviderFactories.GetFactory(Provider);
        }

        public static void InitializeConnectionString(string connectionString = "Accounting")
        {
            ConnectionString = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
        }

        public static void BeginReader()
        {
            Reader = Command.ExecuteReader();
        }

        public static void FinishReader()
        {
            Reader.Close();
        }

        public static void ExecuteCommand(string commandText)
        {
            Command.CommandText = commandText;
            Command.ExecuteNonQuery();
        }

        public static void CreateConnectionAndCommand()
        {
            Connection = Factory.CreateConnection();
            Connection.ConnectionString = ConnectionString;
            Connection.Open();
            //
            createCommand();
        }

        public static void CloseConnection()
        {
            Connection.Close();
        }

        private static void createCommand()
        {
            Command = Factory.CreateCommand();
            Command.Connection = Connection;
        }
    }
}
