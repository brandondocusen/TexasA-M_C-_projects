using System;

class IntegerFacts
{
    static void Main(string[] args)
    {
        const int MaxNumbers = 10;
        int[] numbers = new int[MaxNumbers];
        int numberCount = FillArray(numbers, MaxNumbers);


        if (numberCount > 0)
        {

            Array.Resize(ref numbers, numberCount);
            

            int highestValue, lowestValue, sum, totalValues;
            double average;
            CalculateStatistics(numbers, out highestValue, out lowestValue, out sum, out average, out totalValues);


            Console.WriteLine("The array has " + totalValues + " values.");
            Console.WriteLine("The highest Value is " + highestValue);
            Console.WriteLine("The lowest Value is " + lowestValue);
            Console.WriteLine("The sum of values is " + sum);
            Console.WriteLine("The average is " + average);
        }
        else
        {
            Console.WriteLine("No valid integers were entered.");
        }


        Console.WriteLine("Press any key to close this window...");
        Console.ReadKey();
    }

    static int FillArray(int[] numbers, int maxNumbers)
    {
        int count = 0;
        Console.WriteLine("Enter up to " + maxNumbers + " integers or type '999' to quit.");

        while (count < maxNumbers)
        {
            Console.Write("Please enter an integer or '999' to quit. ");
            string input = Console.ReadLine();

            if (input == "999")
                break;

            int number;
            if (int.TryParse(input, out number))
            {
                numbers[count] = number;
                count++;
            }
            else
            {
                Console.WriteLine("Invalid entry - try again.");
            }
        }

        return count;
    }

    static void CalculateStatistics(int[] numbers, out int highestValue, out int lowestValue, out int sum, out double average, out int totalValues)
    {
        sum = 0;
        highestValue = int.MinValue;
        lowestValue = int.MaxValue;
        totalValues = numbers.Length;

        foreach (int number in numbers)
        {
            sum += number;
            if (number > highestValue)
                highestValue = number;
            if (number < lowestValue)
                lowestValue = number;
        }

        average = totalValues > 0 ? (double)sum / totalValues : 0;
    }
}