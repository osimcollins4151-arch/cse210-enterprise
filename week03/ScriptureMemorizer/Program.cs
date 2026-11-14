using System;
using System.Collections.Generic;

class Program
{
    // This program exceeds the assignment requirements by using a library of
    // several scriptures chosen at random, which creates more variety and a
    // stronger memorization challenge than a single fixed scripture.
    static void Main(string[] args)
    {
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),

            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths."),

            new Scripture(
                new Reference("Psalm", 23, 1, 6),
                "The Lord is my shepherd; I shall not want. He maketh me to lie down in green pastures: he leadeth me beside the still waters. He restoreth my soul: he leadeth me in the paths of righteousness for his name's sake."),

            new Scripture(
                new Reference("Alma", 32, 21),
                "And now as I said concerning faith—faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true."),

            new Scripture(
                new Reference("Ether", 12, 27),
                "And if men come unto me I will show unto them their weakness. Then they become humble; then they are in a state to be taught by the Spirit."),

            new Scripture(
                new Reference("Doctrine and Covenants", 88, 118),
                "And now, I would that ye should be humble, and be submissive and gentle; easy to be entreated, full of patience and long-suffering; being temperate in all things."),

            new Scripture(
                new Reference("Matthew", 5, 14, 16),
                "Ye are the light of the world. A city that is set on an hill cannot be hid. Neither do men light a candle, and put it under a bushel, but on a candlestick; and it giveth light unto all that are in the house.")
        };

        Random random = new Random();

        while (true)
        {
            Scripture scripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];
            PracticeScripture(scripture);

            Console.Write("Would you like to try another scripture? (y/n): ");
            string choice = Console.ReadLine() ?? string.Empty;

            if (choice.Trim().Equals("n", StringComparison.OrdinalIgnoreCase) ||
                choice.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
        }
    }

    static void PracticeScripture(Scripture scripture)
    {
        while (!scripture.IsCompletelyHidden())
        {
            ClearConsoleIfAvailable();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to end: ");

            string input = Console.ReadLine();

            if (input != null && input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                ClearConsoleIfAvailable();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                Console.WriteLine("You chose to end the practice session.");
                return;
            }

            scripture.HideRandomWords(3);
        }

        ClearConsoleIfAvailable();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("Great job! You hid every word in the scripture.");
        Console.WriteLine();
    }

    static void ClearConsoleIfAvailable()
    {
        if (!Console.IsOutputRedirected)
        {
            Console.Clear();
        }
    }
}