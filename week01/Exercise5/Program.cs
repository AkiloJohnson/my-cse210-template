using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Function to prompt the user for their name and return it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Function to prompt the user for a number and return it
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // Function to square a number and return it
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the final result
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }

    // Main function where everything is called
    static void Main()
    {

        string userName = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        int squared = SquareNumber(favoriteNumber);
        DisplayResult(userName, squared);
    }
}