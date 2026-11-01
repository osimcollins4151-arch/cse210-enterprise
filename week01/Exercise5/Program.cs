using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");

        // Call the welcome function
        DisplayWelcome();

        // Get the user's name
        string name = PromptUserName();

        // Get the user's favorite number
        int number = PromptUserNumber();

        // Calculate the square of the number
        int squaredNumber = SquareNumber(number);

        // Display the result
        DisplayResult(name, squaredNumber);
    }

    // Function to display the welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function to prompt for the user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    // Function to prompt for the user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    // Function to calculate the square of a number
    static int SquareNumber(int number)
    {
        int square = number * number;

        return square;
    }

    // Function to display the final result
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}