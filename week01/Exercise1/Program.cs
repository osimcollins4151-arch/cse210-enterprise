using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is my first program in C#");

        Console.Write("What is your first name? ");
        string FirstName = Console.ReadLine("");

        Console.Write("What is your last name? ");
        string LastName = Console.ReadLine("");

        Console.WriteLine($"Your name is {LastName}, {FirstName} {LastName}.");
    }
}