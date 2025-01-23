namespace WebApplication1
{
    class Ifelse
    {
        public static void RunExample()
        {
            Console.WriteLine("You Login As User/Admin");
            string? user = (Console.ReadLine());

            if (user == "User" || user == "user")
            {
                Console.WriteLine("Hello! Welcome User");
            }
            else if(user == "Admin" || user == "admin"){
                Console.WriteLine("Hello! Welcome Admin");
            }
            else
            {
                Console.WriteLine("Please Select & Write Appropriate Type For Login");

            }
        }
    }
}