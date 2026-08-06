using System;

public class Program
{
    public static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("=======================================");
            Console.WriteLine("        Mindfulness Program");
            Console.WriteLine("=======================================");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflecting Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            string? choice = Console.ReadLine();

            Activity? activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;

                case "2":
                    activity = new ReflectingActivity();
                    break;

                case "3":
                    activity = new ListingActivity();
                    break;

                case "4":
                    running = false;
                    continue;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid selection.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    continue;
            }

            Console.Clear();

            activity.Run();

            Console.WriteLine();
            Console.WriteLine("Press Enter to return to the menu...");
            Console.ReadLine();
        }

        Console.Clear();
        Console.WriteLine("Thank you for using the Mindfulness Program!");
    }
}