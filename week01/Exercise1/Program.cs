using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your first name? ");
        string first  = Console.ReadLine();
        Console.WriteLine("What is your last name? ");
        string last = Console.ReadLine();
        Console.WriteLine("Your name is " + last +"," + "   " + first +" " + last);
        
    }
}