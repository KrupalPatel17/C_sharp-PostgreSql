
# C_sharp-PostgreSql

# Simple CRUD & Search Console Application In C# Using PostgreSql Database 
using System;<br>
using System.IO;

class ReadmeGenerator
{
    public static void CreateReadme(string projectName, string outputPath)
    {
        string readmeContent = $@"# {projectName}

## Description
A simple console-based CRUD (Create, Read, Update, Delete, Search) application using C# and PostgreSQL for managing user records.

## Prerequisites
- .NET SDK
- PostgreSQL
- Npgsql NuGet Package

## Features
- Insert new user records
- View all users
- Update existing user information
- Delete user records
- Search users by name or email

## Database Setup
1. Create a PostgreSQL database named `demodb`
2. Create `users` table with columns:
   ```sql
   CREATE TABLE users (
       id SERIAL PRIMARY KEY,
       name VARCHAR(100),
       email VARCHAR(100)
   );
   ```

## Configuration
Modify connection string in `Dbconnection2.cs`:
```csharp
private static readonly string connectionString = ""Host=localhost;Port=5432;Database=demodb;Username=postgres;Password=123"";
```

## How to Run
1. Clone the repository
2. Install Npgsql package
3. Build and run the application

## Menu Options
1. Insert New Record
2. Show All Records
3. Update Record
4. Delete Record
5. Search Record
6. Exit

## Dependencies
- Npgsql for PostgreSQL connection
- System.Data.SqlTypes

## Contributing
Pull requests are welcome. For major changes, please open an issue first.

>>>>>>> 71371b1e1f48d5388a01954010befad41914332d
