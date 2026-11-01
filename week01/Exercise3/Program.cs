using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        string playAgain;

        do
        {
            // Generate a random magic number
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            // Initialize the guess counter
            int guessCount = 0;

            // Ask for the first guess
            Console.Write("What is your guess? ");
            int guess = int.Parse(Console.ReadLine());

            guessCount++;

            // Continue guessing until the correct number is found
            while (guess != magicNumber)
            {
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("Lower");
                }

                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                guessCount++;
            }

            // Display success message and number of attempts
            Console.WriteLine("You guessed it!");
            Console.WriteLine($"You guessed it in {guessCount} attempts!");

            // Ask whether the user wants another game
            Console.Write("Do you want to play again? ");
            playAgain = Console.ReadLine().Trim().ToLower();

        } while (playAgain == "yes");

        Console.WriteLine("Thank you for playing Guess My Number!");
    }
}