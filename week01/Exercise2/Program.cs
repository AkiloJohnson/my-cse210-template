using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade : ");
        string input = Console.ReadLine();
        double grade = Convert.ToDouble(input);

        string letter;

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Don't give up! Keep working hard and try again next time.");
        }
    }
}