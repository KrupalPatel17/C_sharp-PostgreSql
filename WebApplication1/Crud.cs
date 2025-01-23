using Npgsql;
using System;
using System.Collections.Generic;

namespace WebApplication1
{
    // Model class for our example
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    class DbConnection
    {
        private static readonly string connectionString = "Host=localhost;Port=5432;Database=demodb;Username=postgres;Password=123";

        // Your existing connection test method
        public static void ConnectToDatabase()
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Successfully connected to PostgreSQL.");

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

        // CREATE - Insert a new user
        public static void CreateUser(string name, string email)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    
                    string sql = "INSERT INTO users (name, email) VALUES (@name, @email)";
                    using (var cmd = new NpgsqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("name", name);
                        cmd.Parameters.AddWithValue("email", email);
                        
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("User created successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating user: {ex.Message}");
            }
        }

        // READ - Get all users
        public static void GetAllUsers()
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    
                    string sql = "SELECT * FROM users";
                    using (var cmd = new NpgsqlCommand(sql, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"ID: {reader.GetInt32(0)}, Name: {reader.GetString(1)}, Email: {reader.GetString(2)}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving users: {ex.Message}");
            }
        }

        // READ - Get user by ID
        public static void GetUserById(int id)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    
                    string sql = "SELECT * FROM users WHERE id = @id";
                    using (var cmd = new NpgsqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Console.WriteLine($"ID: {reader.GetInt32(0)}, Name: {reader.GetString(1)}, Email: {reader.GetString(2)}");
                            }
                            else
                            {
                                Console.WriteLine("User not found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving user: {ex.Message}");
            }
        }

        // UPDATE - Update a user
        public static void UpdateUser(int id, string name, string email)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
            }
        }

        // DELETE - Delete a user
        // public static void DeleteUser(int id)
        // {
        //     try
        //     {
        //         using (var connection = new NpgsqlConnection(connectionString))
        //         {
        //             connection.Open();
                    
        //             string sql = "DELETE FROM users WHERE id = @id";
        //             using (var cmd = new NpgsqlCommand(sql, connection))
        //             {
        //                 cmd.Parameters.AddWithValue("id", id);
        //                 int rowsAffected = cmd.ExecuteNonQuery();
        //                 if (rowsAffected > 0)
        //                     Console.WriteLine("User deleted successfully!");
        //                 else
        //                     Console.WriteLine("User not found.");
        //             }
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Error deleting user: {ex.Message}");
        //     }
        // }
    }

    
}