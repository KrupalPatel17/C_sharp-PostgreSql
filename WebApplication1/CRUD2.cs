using Microsoft.VisualBasic;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace WebApplication1
{
    class Dbconnection2
    {
        private static readonly string connectionString = "Host=localhost;Port=5432;Database=demodb;Username=postgres;Password=123";

        public static void ConnectToDatabase()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connection Establish Sucessfully");

            }
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public static void Insertuser()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                Console.WriteLine("Enter Your Name:");
                string name = Console.ReadLine()?.Trim();

                Console.WriteLine("Enter Your Email:");
                string email = Console.ReadLine()?.Trim();

                // Validate name and email
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
                {
                    Console.WriteLine("Error: Name and Email cannot be empty.");
                    return;
                }

                // Optional: Add email format validation
                if (!IsValidEmail(email))
                {
                    Console.WriteLine("Error: Invalid email format.");
                    return;
                }

                string sql = "INSERT INTO users (name, email) VALUES (@name, @email)";

                using (var cmd = new NpgsqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("User Created Successfully");
                }
            }
        }

        public static void Getusers()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM users";
                using (var cmd = new NpgsqlCommand(sql, connection))
                {
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    int i = 0;
                    while (reader.Read())
                    {
                        i++;
                        Console.WriteLine(reader["id"] + ") |" + reader["name"] + "  |   " + reader["email"]);
                    }
                }
            }

        }


        public static void Updateuser()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Enter the id of user you want to update:");

                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Error: Invalid id.");
                    return;
                }

                // Option 2: Check for zero or negative values
                if (id <= 0)
                {
                    Console.WriteLine("Error: Invalid id.");
                    return;
                }

                Console.WriteLine("Enter the new name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the new email:");
                string email = Console.ReadLine();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
                {
                    Console.WriteLine("Error: Name and Email cannot be empty.");
                    return;
                }

                // Optional: Add email format validation
                if (!IsValidEmail(email))
                {
                    Console.WriteLine("Error: Invalid email format.");
                    return;
                }
                string sql = "UPDATE users SET name = @name, email = @email WHERE id = @id";

                using (var cmd = new NpgsqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("email", email);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("User updated successfully!");
                    else
                        Console.WriteLine("User not found.");
                }


            }
        }

        public static void Deleteuser()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Enter the id of user you want to delete:");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Error: Invalid id.");
                    return;
                }

                // Option 2: Check for zero or negative values
                if (id <= 0)
                {
                    Console.WriteLine("Error: Invalid id.");
                    return;
                }

                string sql = "DELETE FROM users WHERE id = @id";

                using (var cmd = new NpgsqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("User Deleted Successfully");
                    }
                    else
                    {
                        Console.WriteLine("User not found");
                    }
                }
            }
        }

        public static void Searchuser()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Enter You Want To Search:");
                string Search = Console.ReadLine();

                if (string.IsNullOrEmpty(Search))
                {
                    Console.WriteLine("Error: Please Search With Appropriate Name & Email.");
                    return;
                }

                string sql = "SELECT * FROM users WHERE name LIKE @search OR email LIKE @search";
                using (var cmd = new NpgsqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("search", "%" + Search + "%");
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    int i = 0;
                    while (reader.Read())
                    {
                        i++;
                        Console.WriteLine(reader["id"] + ") |" + reader["name"] + "  |   " + reader["email"]);
                    }
                }
            }
        }
    }
}