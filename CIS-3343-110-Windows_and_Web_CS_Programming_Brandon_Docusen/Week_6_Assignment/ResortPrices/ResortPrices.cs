using System;

public class ResortPrices
{
  public static void Main()
  {
    Console.Write("Please enter number of nights: ");
    string input = Console.ReadLine();
    int nightsStaying = int.Parse(input);

    int pricePerNight = 0; 
    int totalPrice = 0;

    if (nightsStaying >= 1 && nightsStaying <= 2) {
      pricePerNight = 200;
    } 
    else if (nightsStaying >= 3 && nightsStaying <= 4) {
      pricePerNight = 180;  
    }
    else if (nightsStaying >= 5 && nightsStaying <= 7) {
      pricePerNight = 160;
    }
    else if (nightsStaying >= 8) {
      pricePerNight = 145; 
    }

    totalPrice = nightsStaying * pricePerNight;

    Console.WriteLine("Price per night is ${0}", pricePerNight);
    Console.WriteLine("Total for {0} night(s) is ${1}", nightsStaying, totalPrice);

    Console.ReadLine();
  }
}