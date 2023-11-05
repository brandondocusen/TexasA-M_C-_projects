using System;

public class SumToOneHundred 
{
  public static void Main() 
  {
    int numberToAdd = 1;
    int runningTotal = 0;

    Console.WriteLine("halfway done...");

    for (numberToAdd = 1; numberToAdd <= 200; numberToAdd++)
    {
      runningTotal += numberToAdd;

      if (numberToAdd == 100)
      {
        Console.WriteLine("The total after adding the first 100 numbers is {0}", runningTotal); 
      }
    }

    Console.WriteLine("The sum of the integers 1 to 200 is {0}", runningTotal);

    Console.ReadKey();
  }
}