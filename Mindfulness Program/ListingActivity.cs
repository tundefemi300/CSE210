using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private readonly Random _random = new();

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by listing as many things as you can in a certain area.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();

        Console.WriteLine($"--- {GetRandomPrompt()} ---");

        Console.WriteLine();
        Console.Write("You may begin in: ");
        Countdown(5);

        Console.WriteLine();

        List<string> responses = new();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");

            string? response = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(response))
            {
                responses.Add(response.Trim());
            }

            if (DateTime.Now >= endTime)
            {
                break;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {responses.Count} item(s).");

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
}