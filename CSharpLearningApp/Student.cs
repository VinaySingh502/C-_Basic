using System;
using System.Collections.Generic;

namespace CSharpLearningApp;

internal class Student
{
    private readonly List<string> _completedTopics = [];

    public string Name { get; }
    public int Age { get; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void AddCompletedTopic(string topic)
    {
        _completedTopics.Add(topic);
    }

    public void DisplayProfile()
    {
        Console.WriteLine($"Student: {Name} (Age {Age})");
        Console.WriteLine($"Completed topics: {string.Join(", ", _completedTopics)}");
    }
}
