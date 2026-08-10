using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public int Score => _score;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayGoals()
    {
        Console.WriteLine();

        if (_goals.Count == 0)
        {
            Console.WriteLine(
                "No goals have been created yet.");

            return;
        }

        Console.WriteLine("Your Goals:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];

            Console.WriteLine(
                $"{i + 1}. {goal.GetStatus()} {goal.Name}");

            Console.WriteLine(
                $"   {goal.Description} ({goal.Points} points)");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine(
                "You do not have any goals to record.");

            return;
        }

        DisplayGoals();

        Console.Write(
            "Which goal did you accomplish? Enter its number: ");

        if (!int.TryParse(
            Console.ReadLine(),
            out int goalNumber) ||
            goalNumber < 1 ||
            goalNumber > _goals.Count)
        {
            Console.WriteLine(
                "Invalid goal number.");

            return;
        }

        Goal selectedGoal = _goals[goalNumber - 1];

        int earnedPoints =
            selectedGoal.RecordEvent();

        if (earnedPoints == 0)
        {
            if (selectedGoal.IsComplete())
            {
                Console.WriteLine(
                    "That goal is already complete.");
            }
            else
            {
                Console.WriteLine(
                    "No points were awarded.");
            }

            return;
        }

        _score += earnedPoints;

        Console.WriteLine(
            $"Great job! You earned {earnedPoints} points.");

        Console.WriteLine(
            $"Your total score is now {_score} points.");

        if (selectedGoal is ChecklistGoal &&
            selectedGoal.IsComplete())
        {
            Console.WriteLine(
                "Checklist goal completed! Bonus points included!");
        }

        CheckForLevelUp();
    }

    public void DisplayScore()
    {
        Console.WriteLine();

        Console.WriteLine(
            $"Your total score is: {_score} points");

        Console.WriteLine(
            $"Your current level is: {GetLevel()}");

        Console.WriteLine(
            $"Points until next level: {GetPointsUntilNextLevel()}");
    }

    public string GetLevel()
    {
        int level = (_score / 500) + 1;

        return $"Level {level}";
    }

    public int GetPointsUntilNextLevel()
    {
        int nextLevelScore =
            ((_score / 500) + 1) * 500;

        return nextLevelScore - _score;
    }

    private void CheckForLevelUp()
    {
        if (_score > 0 && _score % 500 == 0)
        {
            Console.WriteLine(
                "LEVEL UP! You reached a new level!");
        }
    }

    public void SaveGoals()
    {
        try
        {
            using StreamWriter writer =
                new StreamWriter("eternalquest.txt");

            writer.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(
                    goal.GetSaveString());
            }

            Console.WriteLine(
                "Goals and score saved successfully.");
        }
        catch (IOException)
        {
            Console.WriteLine(
                "There was a problem saving your goals.");
        }
    }

    public void LoadGoals()
    {
        if (!File.Exists("eternalquest.txt"))
        {
            Console.WriteLine(
                "No save file was found.");

            return;
        }

        try
        {
            string[] lines =
                File.ReadAllLines("eternalquest.txt");

            if (lines.Length == 0 ||
                !int.TryParse(
                    lines[0],
                    out int loadedScore))
            {
                Console.WriteLine(
                    "The save file is invalid.");

                return;
            }

            List<Goal> loadedGoals =
                new List<Goal>();

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }

                string[] parts =
                    lines[i].Split('|');

                if (parts.Length < 5)
                {
                    continue;
                }

                string goalType = parts[0];
                string name = parts[1];
                string description = parts[2];

                if (!int.TryParse(
                    parts[3],
                    out int points))
                {
                    continue;
                }

                switch (goalType)
                {
                    case "SimpleGoal":

                        if (bool.TryParse(
                            parts[4],
                            out bool isComplete))
                        {
                            loadedGoals.Add(
                                new SimpleGoal(
                                    name,
                                    description,
                                    points,
                                    isComplete));
                        }

                        break;

                    case "EternalGoal":

                        if (int.TryParse(
                            parts[4],
                            out int timesCompleted))
                        {
                            loadedGoals.Add(
                                new EternalGoal(
                                    name,
                                    description,
                                    points,
                                    timesCompleted));
                        }

                        break;

                    case "ChecklistGoal":

                        if (parts.Length >= 7 &&
                            int.TryParse(
                                parts[4],
                                out int targetCount) &&
                            int.TryParse(
                                parts[5],
                                out int bonusPoints) &&
                            int.TryParse(
                                parts[6],
                                out int completedCount))
                        {
                            loadedGoals.Add(
                                new ChecklistGoal(
                                    name,
                                    description,
                                    points,
                                    targetCount,
                                    bonusPoints,
                                    completedCount));
                        }

                        break;
                }
            }

            _score = loadedScore;
            _goals = loadedGoals;

            Console.WriteLine(
                "Goals and score loaded successfully.");
        }
        catch (IOException)
        {
            Console.WriteLine(
                "There was a problem loading your goals.");
        }
    }
}