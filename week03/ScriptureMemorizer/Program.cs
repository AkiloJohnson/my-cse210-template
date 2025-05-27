using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Reference
{
    public string Book { get; private set; }
    public int StartChapter { get; private set; }
    public int StartVerse { get; private set; }
    public int? EndVerse { get; private set; }

    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        StartChapter = chapter;
        StartVerse = verse;
        EndVerse = null;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        StartChapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        if (EndVerse.HasValue)
            return $"{Book} {StartChapter}:{StartVerse}-{EndVerse}";
        else
            return $"{Book} {StartChapter}:{StartVerse}";
    }
}

class Word
{
    private string text;
    private bool isHidden;

    public Word(string word)
    {
        text = word;
        isHidden = false;
    }

    public bool IsHidden => isHidden;

    public void Hide()
    {
        isHidden = true;
    }

    public string GetDisplayText()
    {
        return isHidden ? new string('_', text.Length) : text;
    }
}

class Scripture
{
    private Reference reference;
    private List<Word> words;
    private Random random = new Random();

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int count)
    {
        List<Word> visibleWords = words.Where(w => !w.IsHidden).ToList();

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(reference.ToString());
        Console.WriteLine();

        foreach (var word in words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }

        Console.WriteLine("\n");
    }

    public bool AllWordsHidden()
    {
        return words.All(w => w.IsHidden);
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding";

        Scripture scripture = new Scripture(reference, text);

        while (!scripture.AllWordsHidden())
        {
            scripture.Display();
            Console.Write("Press Enter to hide words or type 'quit' to exit: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); 
        }

        scripture.Display(); 
        Console.WriteLine("All words are hidden. Program ended.");
    }
}
