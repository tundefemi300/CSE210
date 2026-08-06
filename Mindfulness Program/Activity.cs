using System;

public abstract class Activity
{
    private readonly string _name;
    private readonly string _description;
    private int _duration;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected int Duration => _duration;

    public void DisplayStartingMessage()
    {
        Console.Clear();

        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("Enter the duration in seconds: ");

        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a valid positive number: ");
        }

        Console.WriteLine();
        Console.WriteLine("Prepare to begin...");
        Animation.Spinner(3);

        Console.Clear();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");

        Animation.Spinner(2);

        Console.WriteLine();
        Console.WriteLineConsole.($"You have completed {_duration} seconds of the {_name}.");

        Animation.Spinner(3);
    }

    protected void Spinner(int seconds)
    {
        Animation.Spinner(seconds);
    }

    protected void Countdown(int seconds)
    {
        Animation.Countdown(seconds);
    }

    public abstract void Run();
}