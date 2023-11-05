using System;

class Program
{
  static void Main(string[] args)
  {
    string[] docusenBio = { 
      "Name: Brandon Docusen",
      "Birthdate: 01/01/1901", 
      "Work Phone Number: 1-800-95-Jenny",
      "Personal Phone Number: 911"
    };

    for (int i = 0; i < docusenBio.Length; i++)
    {
      Console.WriteLine(docusenBio[i]);
    }
  }
}