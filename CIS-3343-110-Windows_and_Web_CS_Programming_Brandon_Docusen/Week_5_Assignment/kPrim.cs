using System;

class KthPrime {

  static bool IsPrime(int num) {
    if(num <= 1) return false;
    for(int i = 2; i <= Math.Sqrt(num); i++) {
      if(num % i == 0) return false; 
    }
    return true;
  }

  static int GetKthPrime(int k) {
    int num = 2, count = 0;
    while(count < k) {
      if(IsPrime(num)) count++;
      num++;
    } 
    return num-1;
  }

  static void Main(string[] args) {
    Console.Write("Enter a number to find the Kth prime - ");
    int k = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(GetKthPrime(k)); 
  }

}