using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private readonly Random _random = new();

    public ReflectingActivity()
        : base(
            "Reflecting Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This helps you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();

        Console.WriteLine($"--- {GetRandomPrompt()} ---");

        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Now ponder each of the following questions.");
        Console.Write("You may begin in: ");
        Countdown(5);

        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        List<string> availableQuestions = new(_questions);

        while (DateTime.Now < endTime)
        {
            if (availableQuestions.Count == 0)
            {
                availableQuestions = new List<string>(_questions);
            }

            int index = _random.Next(availableQuestions.Count);

            Console.WriteLine();
            Console.WriteLine("> " + availableQuestions[index]);

            availableQuestions.RemoveAt(index);

            Spinner(5);
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
}