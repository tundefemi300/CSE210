using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            Countdown(4);

            if (DateTime.Now >= endTime)
                break;

            Console.WriteLine();
            Console.Write("Breathe out... ");
            Countdown(6);
        }

        DisplayEndingMessage();
    }
}