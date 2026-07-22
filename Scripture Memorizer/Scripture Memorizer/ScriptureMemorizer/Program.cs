using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        /*
         * Exceeding Requirements:
         * - Loads scriptures from a text file instead of hardcoding one scripture.
         * - Randomly selects a scripture each time the program runs.
         */

        string filePath = "scriptures.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Error: scriptures.txt not found.");
            return;
        }

        List<Scripture> scriptures = LoadScriptures(filePath);

        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found.");
            return;
        }

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Great job!");
                break;
            }

            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }

    static List<Scripture> LoadScriptures(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            if (parts.Length != 4)
            {
                continue;
            }

            string book = parts[0];
            int chapter = int.Parse(parts[1]);
            string verseInfo = parts[2];
            string text = parts[3];

            Reference reference;

            if (verseInfo.Contains("-"))
            {
                string[] verses = verseInfo.Split('-');

                int startVerse = int.Parse(verses[0]);
                int endVerse = int.Parse(verses[1]);

                reference = new Reference(book, chapter, startVerse, endVerse);
            }
            else
            {
                int verse = int.Parse(verseInfo);

                reference = new Reference(book, chapter, verse);
            }

            scriptures.Add(new Scripture(reference, text));
        }

        return scriptures;
    }
}