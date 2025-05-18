using System;

class Program
{
    static void Main(string[] args)
     {
        Random random = new Random();
        int magicNumber = random.Next(1, 101); 

        int guess;
        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }

        } while (guess != magicNumber);

        Console.WriteLine("You guessed it!");
    }
}