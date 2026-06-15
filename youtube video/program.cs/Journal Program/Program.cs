using System;

/*
Creativity Feature:
- Added extra journal prompts beyond the required five.
- Added file existence checking before loading.
- Added success messages after saving and loading files.
*/

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Journal");
            Console.WriteLine("4. Load Journal");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine();
                Console.WriteLine(prompt);
                Console.Write("> ");

                string response = Console.ReadLine();

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = response;

                journal.AddEntry(entry);
            }
            else if (choice == 2)
            {
                journal.DisplayAll();
            }
            else if (choice == 3)
            {
                Console.Write("Filename: ");
                string fileName = Console.ReadLine();

                journal.SaveToFile(fileName);

                Console.WriteLine("Journal saved successfully.");
            }
            else if (choice == 4)
            {
                Console.Write("Filename: ");
                string fileName = Console.ReadLine();

                if (File.Exists(fileName))
                {
                    journal.LoadFromFile(fileName);
                    Console.WriteLine("Journal loaded successfully.");
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            }
        }
    }
}