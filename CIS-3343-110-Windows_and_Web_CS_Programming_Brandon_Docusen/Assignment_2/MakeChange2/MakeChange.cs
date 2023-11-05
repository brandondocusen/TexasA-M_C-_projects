using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a monetary value in whole dollars");
        double dollars = Convert.ToDouble(Console.ReadLine());

        MakeChange(dollars);

        Console.ReadLine();
    }

    static void MakeChange(double dollars)
    {

        int twenties = 0;
        int tens = 0;
        int fives = 0;
        int ones = 0;

        twenties = (int)(dollars / 20);
        dollars %= 20;

        tens = (int)(dollars / 10);
        dollars %= 10;

        fives = (int)(dollars / 5);
        dollars %= 5;

        ones = (int)dollars;

Console.WriteLine("twenties: " + twenties + " tens: " + tens + " fives: " + fives + " ones: " + ones);
    }
}