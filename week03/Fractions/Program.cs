using System;

class Program
{
    static void Main(string[] args)
    {
        // Using default constructor
        Fraction fraction1 = new Fraction();
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        // Using constructor with one parameter
        Fraction fraction2 = new Fraction(5);
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());

        // Using constructor with two parameters
        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());

        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());

        // Test the getters and setters
        Fraction testFraction = new Fraction(2, 3);

        testFraction.SetTop(5);
        testFraction.SetBottom(8);

        Console.WriteLine("\nTesting Getters and Setters:");

        Console.WriteLine($"Top: {testFraction.GetTop()}");
        Console.WriteLine($"Bottom: {testFraction.GetBottom()}");

        Console.WriteLine(testFraction.GetFractionString());
        Console.WriteLine(testFraction.GetDecimalValue());
    }
}