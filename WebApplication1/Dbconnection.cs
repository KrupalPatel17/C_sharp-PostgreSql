using Npgsql;

namespace WebApplication1
{
    class Dbconnection
    {
        public static void ConnectToDatabase()
        {
            // Connection string
           string connectionString = "Host=localhost;Port=5432;Database=demodb;Username=postgres;Password=123";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Successfully connected to PostgreSQL.");

                    // Example: Simple query
                    using (var cmd = new NpgsqlCommand("SELECT version()", connection))
                    {
                        string version = cmd.ExecuteScalar().ToString();
                        Console.WriteLine($"PostgreSQL version: {version}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}