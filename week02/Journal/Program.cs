using System;

class Program
{
    // Abstraction: Program coordinates the menu while Journal, Entry, and PromptGenerator manage their own responsibilities.
    // Beyond the core requirements, CSV storage supports spreadsheet use and preserves commas, quotes, and line breaks.
    static void Main(string[] args)
    {
        Journal journal = new();
        PromptGenerator promptGenerator = new();

        while (true)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            if (choice == null || choice == "5")
            {
                break;
            }

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    promptGenerator.Display(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    journal.AddEntry(new Entry(DateTime.Now.ToShortDateString(), prompt, response ?? ""));
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    string loadFilename = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(loadFilename))
                    {
                        journal.LoadFromFile(loadFilename);
                        Console.WriteLine("Journal loaded.");
                    }
                    else
                    {
                        Console.WriteLine("A filename is required.");
                    }
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    string saveFilename = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(saveFilename))
                    {
                        journal.SaveToFile(saveFilename);
                        Console.WriteLine("Journal saved.");
                    }
                    else
                    {
                        Console.WriteLine("A filename is required.");
                    }
                    break;
                default:
                    Console.WriteLine("Please enter a number from 1 to 5.");
                    break;
            }
        }
    }
}