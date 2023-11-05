using System;

class StudentGradebook {

  // one of the requirements was to create two arrays with these names
  static string[] studentNames;
  static double[] studentGrades;
  
  static void Main(string[] args) {

    // initiallizes the two arrays
    studentNames = new string[100]; 
    studentGrades = new double[100];

    bool keepGoing = true;

    while (keepGoing) {
      Console.WriteLine("Student Gradebook");
      Console.WriteLine("1. Add Student");
      Console.WriteLine("2. Display Students");
      Console.WriteLine("3. Calculate Average");
      Console.WriteLine("4. Display Min and Max");
      Console.WriteLine("5. Exit");
      Console.Write("Enter option: ");

      string input = Console.ReadLine();
      int option = int.Parse(input);

      switch(option) {
        case 1:
          AddStudent();
          break;
        case 2:
          DisplayStudents();
          break;
        case 3:
          CalculateAverage();
          break;
        case 4:  
          DisplayMinMax();
          break;
        case 5:
          keepGoing = false;
          break;
        default:
          Console.WriteLine("Invalid option");
          break;
      }
    }

  }

  static void AddStudent() {
    Console.Write("Enter student name ");
    string name = Console.ReadLine();

    Console.Write("Enter student grade ");
    double grade = double.Parse(Console.ReadLine());

    for (int i = 0; i < studentNames.Length; i++) {
      if (studentNames[i] == null) {
        studentNames[i] = name;
        studentGrades[i] = grade;
        break;
      }
    }
  }

  static void DisplayStudents() {
    Console.WriteLine("\nStudent Grades ");
    for (int i = 0; i < studentNames.Length; i++) {
      if (studentNames[i] != null) {
        Console.WriteLine(studentNames[i] + ": " + studentGrades[i]); 
      }
    }
  }

  static void CalculateAverage() {
    double sum = 0;
    int count = 0;

    for (int i = 0; i < studentGrades.Length; i++) {
      if (studentGrades[i] > 0) {
        sum += studentGrades[i];
        count++;  
      }
    }

    double average = sum / count;
    Console.WriteLine("\nAverage Grade " + average);
  }

  static void DisplayMinMax() {
    double min = 100;
    double max = 0;
    string minName = "";
    string maxName = "";

    for (int i = 0; i < studentGrades.Length; i++) {
      if (studentGrades[i] > 0) {
        if (studentGrades[i] < min) {
          min = studentGrades[i];
          minName = studentNames[i];
        }
        if (studentGrades[i] > max) {
          max = studentGrades[i];
          maxName = studentNames[i];
        }
      }
    }

    Console.WriteLine("\nMinimum Grade " + min + " (" + minName + ")"); 
    Console.WriteLine("Maximum Grade " + max + " (" + maxName + ")");
  }

}