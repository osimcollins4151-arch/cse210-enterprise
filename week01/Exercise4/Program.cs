using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        // Create a list to store numbers
        List<int> numbers = new List<int>();

        // Collect numbers from the user
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number = -1;

        while (number != 0)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        // Check whether the list contains numbers
        if (numbers.Count > 0)
        {
            // Calculate the sum
            int sum = 0;

            foreach (int item in numbers)
            {
                sum += item;
            }

            Console.WriteLine($"The sum is: {sum}");

            // Calculate the average
            double average = (double)sum / numbers.Count;

            Console.WriteLine($"The average is: {average}");

            // Find the largest number
            int largest = numbers.Max();

            Console.WriteLine($"The largest number is: {largest}");

            // Find the smallest positive number
            var positiveNumbers = numbers.Where(n => n > 0);

            if (positiveNumbers.Any())
            {
                int smallestPositive = positiveNumbers.Min();

                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }
            else
            {
                Console.WriteLine("There are no positive numbers in the list.");
            }

            // Sort and display the numbers
            numbers.Sort();

            Console.WriteLine("The sorted list is:");

            foreach (int item in numbers)
            {
                Console.WriteLine(item);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}