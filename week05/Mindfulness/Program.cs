using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    continue;
            }

            activity.Run();
        }
    }
}

class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void EndActivity()
    {
        Console.WriteLine("\nGood job!");
        ShowSpinner(2);
        Console.WriteLine($"You completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(spinner[i % 4]);
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    public virtual void Run()
    {
        StartActivity();
        EndActivity();
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity",
        "This activity helps you relax by guiding you through slow breathing.") {}

    public override void Run()
    {
        StartActivity();

        int timePassed = 0;
        while (timePassed < _duration)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(3);
            Console.WriteLine();

            Console.Write("Breathe out... ");
            ShowCountdown(3);
            Console.WriteLine();

            timePassed += 6;
        }

        EndActivity();
    }
}

class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone.",
        "Think of a time when you did something difficult.",
        "Think of a time when you helped someone.",
        "Think of a time when you were selfless."
    };

    private string[] questions = {
        "Why was this meaningful?",
        "Have you done anything like this before?",
        "How did you get started?",
        "How did you feel afterward?",
        "What made this different from other times?",
        "What did you learn about yourself?"
    };

    public ReflectionActivity() : base("Reflection Activity",
        "This activity helps you reflect on times you've shown strength and resilience.") {}

    public override void Run()
    {
        StartActivity();
        Random rand = new Random();

        Console.WriteLine("\nPrompt:");
        Console.WriteLine(prompts[rand.Next(prompts.Length)]);
        ShowSpinner(3);

        int timePassed = 0;
        while (timePassed < _duration)
        {
            Console.WriteLine("\n" + questions[rand.Next(questions.Length)]);
            ShowSpinner(4);
            timePassed += 4;
        }

        EndActivity();
    }
}

class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are people you appreciate?",
        "What are your personal strengths?",
        "Who have you helped this week?",
        "When did you feel peace this month?",
        "Who are your heroes?"
    };

    public ListingActivity() : base("Listing Activity",
        "This activity helps you reflect on good things in your life by listing as many as you can.") {}

    public override void Run()
    {
        StartActivity();
        Random rand = new Random();

        Console.WriteLine("\nPrompt:");
        Console.WriteLine(prompts[rand.Next(prompts.Length)]);
        Console.WriteLine("You can begin in:");
        ShowCountdown(3);

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} items.");
        EndActivity();
    }
}
