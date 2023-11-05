using System;

class Program 
{
  static void Main(string[] args)
  {

    int hydrogenBattery = 100; 
    bool hasMap = false;


    Console.WriteLine("Welcome to the Dark Cave Adventure Game!");
    Console.WriteLine("You are in a dark cave with three paths in front of you.");
    
    while (hydrogenBattery > 0) 
    {

      Console.WriteLine(string.Format("Your hydrogen battery is now at {0}%", hydrogenBattery));
      

      Console.WriteLine("Choose your path:");
      Console.WriteLine("1. Go left");
      Console.WriteLine("2. Go right"); 
      Console.WriteLine("3. Go center");
      

      Console.Write("Enter your choice (1/2/3): ");
      int path = Int32.Parse(Console.ReadLine());
      

      if (path == 1) 
      {
        Console.WriteLine("You chose to go left.");
        Console.WriteLine("You encounter a group of bats!");
        
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("1. Use the flashlight saber to scare them away");
        Console.WriteLine("2. Try to sneak past them in the dark");
        
        int choice = Int32.Parse(Console.ReadLine());
        
        if (choice == 1) {
          Console.WriteLine("You use the flashlight saber to scare the bats away.");
          hydrogenBattery -= 10;
        }
        else {
          Random rnd = new Random();
          int sneak = rnd.Next(1, 3);
          
          if (sneak == 1) {
            Console.WriteLine("You successfully sneak past the bats.");
          }
          else {
            Console.WriteLine("You make noise and alert the bats. They attack you.");
            hydrogenBattery = 0;
          }
        }
      }
      

      else if (path == 2)
      {
        Console.WriteLine("You chose to go right.");
        Console.WriteLine("You come across a stream with a narrow bridge.");
      
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("1. Cross the bridge carefully");
        Console.WriteLine("2. Try to swim across the stream");
        
        int choice = Int32.Parse(Console.ReadLine());
        
        if (choice == 1)
        {
          Random rnd = new Random();
          int result = rnd.Next(1, 3);
          
          if (result == 1) {
            Console.WriteLine("You cross the bridge successfully.");
          }
          else {
            Console.WriteLine("The bridge collapses, but you manage to swim to safety.");
            hydrogenBattery -= 10; 
          }
        }
        else {
          Console.WriteLine("You get swept away by the strong current.");
          hydrogenBattery = 0;
        }
      }
      

      else if (path == 3)
      {
        Console.WriteLine("You chose to go center.");
        Console.WriteLine("The path is dark, and you can't see anything.");
        
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("1. Use the flashlight saber to illuminate the path");
        Console.WriteLine("2. Take a chance and walk in the dark");
        
        int choice = Int32.Parse(Console.ReadLine());
        
        if (choice == 1) {
          if (!hasMap) {
            Console.WriteLine("You discover a hidden map on the cave wall!");
            hasMap = true;  
          }
          else {
            Console.WriteLine("You illuminate the path but find nothing.");
          }
        }
        else {
          Console.WriteLine("You stumble and get injured.");
          hydrogenBattery -= 15;
        }
        
      }
      
      Console.WriteLine();
    }
    

    Console.WriteLine("Your flashlight saber hydrogen Battery has run out. Game over.");
    Console.WriteLine("Thank you for playing!");
  }
}