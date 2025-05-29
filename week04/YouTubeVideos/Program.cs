using System;
using System.Collections.Generic;

// Class to represent a comment
class Comment
{
    public string CommenterName { get; private set; }
    public string Text { get; private set; }

    public Comment(string name, string text)
    {
        CommenterName = name;
        Text = text;
    }
}

// Class to represent a YouTube video
class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int LengthInSeconds { get; private set; }

    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        LengthInSeconds = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        // Create a list of videos
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("C# Tutorial for Beginners", "TechWithTim", 600);
        video1.AddComment(new Comment("Alice", "This is so helpful! Thanks."));
        video1.AddComment(new Comment("Bob", "Nice explanation."));
        video1.AddComment(new Comment("Charlie", "Clear and concise."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Learn Object-Oriented Programming", "CodeAcademy", 900);
        video2.AddComment(new Comment("Dave", "OOP finally makes sense!"));
        video2.AddComment(new Comment("Eve", "Awesome breakdown of the concepts."));
        video2.AddComment(new Comment("Frank", "Saved my assignment."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("How to Build a Game in Unity", "GameDevHQ", 1200);
        video3.AddComment(new Comment("Grace", "Love this tutorial!"));
        video3.AddComment(new Comment("Heidi", "Can you do a follow-up on animation?"));
        video3.AddComment(new Comment("Ivan", "Unity is powerful."));
        videos.Add(video3);

        // Optional Video 4
        Video video4 = new Video("Cooking with AI: Smart Recipes", "FoodBot", 300);
        video4.AddComment(new Comment("Judy", "LOL this is amazing."));
        video4.AddComment(new Comment("Kevin", "AI chef? Count me in!"));
        video4.AddComment(new Comment("Leo", "Make more of these!"));
        videos.Add(video4);

        // Display all videos and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine(); // Blank line between videos
        }
    }
}
