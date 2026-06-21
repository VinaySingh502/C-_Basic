using System;
using System.Collections.Generic;

namespace CSharpLearningApp;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== C# Learning Console App ===\n");

        // 1. Variables and data types
        string learnerName = "Vinay Singh";
        int age = 25;
        double courseProgress = 42.5;
        bool enjoysCSharp = true;

        Console.WriteLine("1. Variables and data types");
        Console.WriteLine($"Name: {learnerName}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Course progress: {courseProgress}%");
        Console.WriteLine($"Enjoys C#: {enjoysCSharp}\n");

        // 2. Arithmetic and methods
        int firstNumber = 10;
        int secondNumber = 20;
        Console.WriteLine("2. Arithmetic and methods");
        Console.WriteLine($"{firstNumber} + {secondNumber} = {Add(firstNumber, secondNumber)}\n");

        // 3. If/else condition
        Console.WriteLine("3. If/else condition");
        if (age >= 18)
        {
            Console.WriteLine("The learner is an adult.\n");
        }
        else
        {
            Console.WriteLine("The learner is under 18.\n");
        }

        // 4. Loop and collection
        List<string> topics =
        [
            "Variables",
            "Conditions",
            "Loops",
            "Methods",
            "Classes"
        ];

        Console.WriteLine("4. List and foreach loop");
        foreach (string topic in topics)
        {
            Console.WriteLine($"- {topic}");
        }

        // 5. Object-oriented programming
        Student student = new(learnerName, age);
        student.AddCompletedTopic("Variables");
        student.AddCompletedTopic("Methods");

        Console.WriteLine("\n5. Class and object");
        student.DisplayProfile();

        Console.WriteLine("\nChange the values and examples in Program.cs, then run the app again!");
    }

    private static int Add(int firstNumber, int secondNumber)
    {
        return firstNumber + secondNumber;
    }
}
