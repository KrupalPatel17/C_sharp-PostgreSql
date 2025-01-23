namespace WebApplication1
{
    class Forloop
    {
        public static void RunExample()
        {
            Console.WriteLine("Basic counting:");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Count: {i}");
            }

            Console.WriteLine("\nCounting backwards:");
            for (int i = 5; i >= 1; i--)
            {
                Console.WriteLine($"Countdown: {i}");
            }

            Console.WriteLine("\nMaking a triangle:");
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
    }
}