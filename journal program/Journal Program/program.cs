using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity:
        // 1. Each journal entry also stores a Mood Rating (1-5).
        // 2. PromptGenerator avoids repeating the same prompt twice in a row.
        // 3. When a journal is loaded, the program displays the total number of entries loaded.
        // These features exceed the core assignment requirements.

        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool quit = false;

        while (!quit)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();

                    Console.WriteLine();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("> ");

                    string response = Console.ReadLine();

                    Console.Write("Mood Rating (1-5): ");
                    string mood = Console.ReadLine();

                    Entry entry = new Entry();
                    entry._date = DateTime.Now.ToShortDateString();
                    entry._promptText = prompt;
                    entry._entryText = response;
                    entry._mood = mood;

                    journal.AddEntry(entry);

                    Console.WriteLine("Journal entry added successfully.");
                    break;

                case "2":
                    Console.WriteLine();
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();

                    journal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();

                    journal.SaveToFile(saveFile);
                    break;

                case "5":
                    quit = true;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}