using System;

namespace EternalQuest;

public class Program
{
    /*
     * CREATIVITY / EXCEEDING REQUIREMENTS:
     *
     * In addition to the required goal types, scoring, saving/loading,
     * inheritance, encapsulation, abstraction, and polymorphism, this
     * program includes a gamification level system.
     *
     * The user levels up every 500 points. The program displays the
     * current level and the number of points needed to reach the next
     * level. This gives the user an additional reward for continuing
     * to work toward their goals.
     */

    public static void Main()
    {
        GoalManager goalManager = new GoalManager();
        bool running = true;

        Console.WriteLine("=================================");
        Console.WriteLine("        ETERNAL QUEST");
        Console.WriteLine("=================================");
        Console.WriteLine("Turn your goals into a quest!");

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine(
                $"Current Score: {goalManager.Score} points");
            Console.WriteLine($"Level: {goalManager.GetLevel()}");
            Console.WriteLine();

            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Goal Event");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");

            Console.Write("Select an option: ");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    CreateGoal(goalManager);
                    break;

                case "2":
                    goalManager.DisplayGoals();
                    break;

                case "3":
                    goalManager.RecordEvent();
                    break;

                case "4":
                    goalManager.DisplayScore();
                    break;

                case "5":
                    goalManager.SaveGoals();
                    break;

                case "6":
                    goalManager.LoadGoals();
                    break;

                case "7":
                    running = false;
                    Console.WriteLine(
                        "Keep working on your Eternal Quest. Goodbye!");
                    break;

                default:
                    Console.WriteLine(
                        "Invalid option. Please choose 1-7.");
                    break;
            }
        }
    }

    private static void CreateGoal(GoalManager goalManager)
    {
        Console.WriteLine();
        Console.WriteLine("Choose a goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Select a goal type: ");
        string type = Console.ReadLine() ?? "";

        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter a short description: ");
        string description = Console.ReadLine() ?? "";

        if (!TryReadPositiveInt(
            "Enter the number of points: ",
            out int points))
        {
            return;
        }

        switch (type)
        {
            case "1":
                goalManager.AddGoal(
                    new SimpleGoal(
                        name,
                        description,
                        points));

                Console.WriteLine("Simple goal created!");
                break;

            case "2":
                goalManager.AddGoal(
                    new EternalGoal(
                        name,
                        description,
                        points));

                Console.WriteLine("Eternal goal created!");
                break;

            case "3":
                if (!TryReadPositiveInt(
                    "How many times must you complete it? ",
                    out int target))
                {
                    return;
                }

                if (!TryReadPositiveInt(
                    "How many bonus points are awarded when finished? ",
                    out int bonus))
                {
                    return;
                }

                goalManager.AddGoal(
                    new ChecklistGoal(
                        name,
                        description,
                        points,
                        target,
                        bonus));

                Console.WriteLine("Checklist goal created!");
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    private static bool TryReadPositiveInt(
        string prompt,
        out int value)
    {
        Console.Write(prompt);

        if (int.TryParse(
            Console.ReadLine(),
            out value) &&
            value > 0)
        {
            return true;
        }

        Console.WriteLine(
            "Please enter a positive whole number.");

        return false;
    }
} 