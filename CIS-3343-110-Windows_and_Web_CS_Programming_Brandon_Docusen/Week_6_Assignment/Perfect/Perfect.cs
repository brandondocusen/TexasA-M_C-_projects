using System;

public class PerfectNumberFinder 
{
  public static void Main()
  { 
    int upperLimit = 10000;

    for (int numberToCheck = 1; numberToCheck <= upperLimit; numberToCheck++)
    {
      int sumOfFactors = 0; 

      for (int factor = 1; factor < numberToCheck; factor++)  
      {
        if (numberToCheck % factor == 0)
        {
          sumOfFactors += factor;
        }
      }

      if (sumOfFactors == numberToCheck) 
      {
        Console.WriteLine(numberToCheck + " is perfect");
      }
    }

    Console.ReadLine();
  }
}