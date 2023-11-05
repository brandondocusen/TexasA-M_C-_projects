using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the amount in dollars: ");
        double dollars = Convert.ToDouble(Console.ReadLine());

        MakeChange(dollars);

        Console.ReadLine(); // Pause to keep the console window open
    }

    static void MakeChange(double dollars)
    {
        // Define currency denominations
        int twenties = 0;
        int tens = 0;
        int fives = 0;
        int ones = 0;

        // Calculate the number of twenties
        twenties = (int)(dollars / 20);
        dollars %= 20;

        // Calculate the number of tens
        tens = (int)(dollars / 10);
        dollars %= 10;

        // Calculate the number of fives
        fives = (int)(dollars / 5);
        dollars %= 5;

        // The remaining dollars are ones
        ones = (int)dollars;

        // Display the results
        Console.WriteLine($"{dollars:C} is {twenties} twenties, {tens} tens, {fives} fives, and {ones} ones.");
    }
}