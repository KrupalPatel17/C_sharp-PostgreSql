namespace WebApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            bool exitProgram = false;

            while (!exitProgram)
            {
                Console.WriteLine("\n1) Insert New Record");
                Console.WriteLine("2) Show All Record");
                Console.WriteLine("3) Update Record");
                Console.WriteLine("4) Delete Record");
                Console.WriteLine("5) Search Record");
                Console.WriteLine("6) Exit");

                Console.WriteLine("\nEnter Your Choice:");
                if (!int.TryParse(Console.ReadLine(), out int select))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (select)
                {
                    case 1:
                        Dbconnection2.ConnectToDatabase();
                        Dbconnection2.Insertuser();
                        break;

                    case 2:
                        Dbconnection2.ConnectToDatabase();
                        Dbconnection2.Getusers();
                        break;

                    case 3:
                        Dbconnection2.ConnectToDatabase();
                        Dbconnection2.Updateuser();
                        break;

                    case 4:
                        Dbconnection2.ConnectToDatabase();
                        Dbconnection2.Deleteuser();
                        break;

                    case 5:
                        Dbconnection2.ConnectToDatabase();
                        Dbconnection2.Searchuser();
                        break;

                    case 6:
                        exitProgram = true;
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Please Select Valid Choice");
                        break;
                }

                if (select >= 1 && select <= 5)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }



            //Crud.cs CODE 


            // Test database connection
            // DbConnection.ConnectToDatabase();

            // // Example CRUD operations
            // Console.WriteLine("\nCreating a new user...");
            // DbConnection.CreateUser("Krupal", "krupal@example.com");

            // Console.WriteLine("\nRetrieving all users...");
            // DbConnection.GetAllUsers();

            // Console.WriteLine("\nRetrieving user with ID 1...");
            // DbConnection.GetUserById(1);

            // Console.WriteLine("\nUpdating user with ID 1...");
            // DbConnection.UpdateUser(1, "John Smith", "john.smith@example.com");

            // Console.WriteLine("\nRetrieving updated user list...");
            // DbConnection.GetAllUsers();

            // // Console.WriteLine("\nDeleting user with ID 1...");
            // // DbConnection.DeleteUser(1);

            // Console.WriteLine("\nFinal user list...");
            // DbConnection.GetAllUsers();

            // Console.ReadLine();
        }
    }
}