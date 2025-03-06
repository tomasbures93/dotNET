using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Datenbank___Erste_Zugriff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            Console.WriteLine(configuration.GetConnectionString("NETDB"));

            string connectionString = configuration.GetConnectionString("NETDB");

            //string connectionString =
            //    @"Server=.\SQLEXPRESS;Database=NETDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            // @"Server=localhost;Database=NETDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                ReadData(connection);
                InsertData(connection);

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
        }

        private static void InsertData(SqlConnection connection)
        {
            //INSERT INTO Contacts(LastName, FirstName) VALUES ('Kokot', 'jebat')
            string name = Console.ReadLine();
            string firstname = Console.ReadLine();
            SqlCommand insertCommand = new SqlCommand(
                @"INSERT INTO Contacts(LastName, FirstName) VALUES (@name, @firstname)", connection);

            // Es ist wichtig!!! Basis schutz gegen SQL-Injections
            insertCommand.Parameters.AddWithValue("@name", name);
            insertCommand.Parameters.AddWithValue("@firstname", firstname);

            insertCommand.ExecuteNonQuery();
        }

        private static void ReadData(SqlConnection connection)
        {

            //SQL command 
            SqlCommand command = new SqlCommand(
                @"SELECT ID, LastName, FirstName FROM dbo.Contacts", connection);

            //SQL geschickt und executed
            SqlDataReader reader = command.ExecuteReader();

            // reading data
            while (reader.Read())
            {
                Console.WriteLine(
                    $"ID: {reader.GetInt32(0)}, LastName: {reader.GetString(1)}, FirstName: {reader.GetString(2)}");
                // 0 1 2 sind spalten from command was habe ich selectiert
            }
            reader.Close();
        }
    }
}
