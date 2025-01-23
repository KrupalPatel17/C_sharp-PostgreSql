namespace WebApplication1
{
    class Ifcondiction
    {
        public static void RunExample()
        {
            Console.WriteLine("Enter your age:");
            int age = Convert.ToInt32(Console.ReadLine());

            if (age >= 18)
            {
                    Console.WriteLine("You are an adult!");
            }
            else
            {
                Console.WriteLine("You are a minor!");
            }
        }
    }
}