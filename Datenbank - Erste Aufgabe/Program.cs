using Microsoft.Data.SqlClient;
using System.Collections.Generic;
namespace Datenbank___Erste_Aufgabe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
                @"Server=.\SQLEXPRESS;Database=NETDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            do
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("\t DB Edit Software");
                Console.WriteLine("");
                Console.WriteLine("\t 1 - ShowDB");
                Console.WriteLine("\t 2 - Add Data");
                Console.WriteLine("\t 3 - Edit Data");
                Console.WriteLine("\t 4 - Delete Data");
                Console.WriteLine("\t 5 - Exit");
                Console.WriteLine("\t 9 - RED BUTTON");
                Console.WriteLine();
                string input = Console.ReadLine();
                switch (input[0])
                {
                    case '1':
                        try
                        {
                            SqlConnection connection = new SqlConnection(connectionString);
                            connection.Open();
                            ReadData(connection);
                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case '2':
                        try
                        {
                            SqlConnection connection = new SqlConnection(connectionString);
                            connection.Open();
                            SaveData(connection);
                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case '3':
                        try
                        {
                            SqlConnection connection = new SqlConnection(connectionString);
                            connection.Open();
                            UpdateData(connection);
                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case '4':
                        try
                        {
                            SqlConnection connection = new SqlConnection(connectionString);
                            connection.Open();
                            DeleteData(connection);
                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case '5':
                        Environment.Exit(0);
                        break;
                    case '9':
                        try
                        {
                            SqlConnection connection = new SqlConnection(connectionString);
                            connection.Open();
                            DropTheMice(connection);
                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            } while (true);
       }
        
        private static void DropTheMice(SqlConnection connection)
        {
            SqlCommand muhaha = new SqlCommand(
                    @"DROP TABLE Contacts2", connection);
            muhaha.ExecuteNonQuery();
            Console.WriteLine("HAHAHA");
        }

        private static void UpdateData(SqlConnection connection)
        {
            // UPDATE table_name SET column1 = value1, column2 = value2, ... WHERE condition;
            Console.WriteLine("Update - ID eingeben ( das was wir editieren )");
            string was = Console.ReadLine();
            Console.WriteLine("Insert new First Name");
            string newFirstName = Console.ReadLine();
            SqlCommand updateCommand = new SqlCommand(
                @"UPDATE Contacts2 SET FirstName = @newFirstName WHERE ID = @was", connection);
            updateCommand.Parameters.AddWithValue("newFirstName", newFirstName);
            updateCommand.Parameters.AddWithValue("was", was);
            int rowaffected = updateCommand.ExecuteNonQuery();
            Console.WriteLine($"\n\t{rowaffected} Row Affected");
        }
        private static void DeleteData(SqlConnection connection)
        {
            // DELETE FROM Customers WHERE CustomerName = 'Alfreds Futterkiste';
            Console.WriteLine("Delete - ID eingeben");
            string id = Console.ReadLine();
            SqlCommand deleteCommand = new SqlCommand(
                            @"DELETE FROM Contacts2 WHERE ID = @id", connection);
            deleteCommand.Parameters.AddWithValue("id", id);
            int menge = deleteCommand.ExecuteNonQuery();
            Console.WriteLine($"\n\t{menge} Deleted");            
        }

        private static void SaveData(SqlConnection connection)
        {
            //INSERT INTO Contacts(LastName, FirstName) VALUES ('Kokot', 'jebat')
            Console.WriteLine("First Name");
            string name = Console.ReadLine();
            Console.WriteLine("Last Name");
            string firstname = Console.ReadLine(); 
            Console.WriteLine("Email");
            string email = Console.ReadLine();
            SqlCommand insertCommand = new SqlCommand(
                @"INSERT INTO Contacts2(LastName, FirstName, EMail) VALUES (@name, @firstname, @email)", connection);

            // Es ist wichtig!!! Basis schutz gegen SQL-Injections
            insertCommand.Parameters.AddWithValue("@name", name);
            insertCommand.Parameters.AddWithValue("@firstname", firstname);
            insertCommand.Parameters.AddWithValue("@email", email);

            int menge = insertCommand.ExecuteNonQuery();
            Console.WriteLine($"\n\t{menge} added");
        }

        private static void ReadData(SqlConnection connection)
        {

            //SQL command 
            SqlCommand command = new SqlCommand(
                @"SELECT ID, LastName, FirstName, EMail FROM dbo.Contacts2", connection);

            //SQL geschickt und executed
            SqlDataReader reader = command.ExecuteReader();

            // reading data
            while (reader.Read())
            {
                Console.WriteLine(
                    $"ID: {reader.GetInt32(0)}, LastName: {reader.GetString(1)}, FirstName: {reader.GetString(2)}, Email: {reader.GetString(3)}");
                // 0 1 2 sind spalten from command was habe ich selectiert
            }
            reader.Close();
        }
    }
}
