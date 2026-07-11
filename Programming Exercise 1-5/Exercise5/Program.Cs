using System;

class Program
{
    static void Main(string[] args)
    {
        // Display the welcome message
        DisplayWelcome();

        // Get the user's name
        string userName = PromptUserName();

        // Get the user's favorite number
        int favoriteNumber = PromptUserNumber();

        // Square the number
        int squaredNumber = SquareNumber(favoriteNumber);

        // Display the result
        DisplayResult(userName, squaredNumber);
    }

    // Displays a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Prompts the user for their name and returns it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    // Prompts the user for their favorite number and returns it
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    // Squares the user's favorite number and returns the result
    static int SquareNumber(int number)
    {
        int square = number * number;

        return square;
    }

    // Displays the final result
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}