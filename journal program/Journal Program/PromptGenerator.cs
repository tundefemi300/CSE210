using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What made me smile today?",
        "What is one thing I learned today?"
    };

    private Random _random = new Random();
    private int _lastPromptIndex = -1;

    public string GetRandomPrompt()
    {
        int index;

        do
        {
            index = _random.Next(_prompts.Count);
        }
        while (index == _lastPromptIndex);

        _lastPromptIndex = index;

        return _prompts[index];
    }
}