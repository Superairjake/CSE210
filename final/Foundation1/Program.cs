using System;

using System.Collections.Generic;


class Comment
{
    public string Commenter { get; set; }
    public string Text { get; set; }

    public Comment(string commenter, string text)
    {
        Commenter = commenter;
        Text = text;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(string commenter, string text)
    {
        Comment newComment = new Comment(commenter, text);
        Comments.Add(newComment);
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} minutes");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"\t{comment.Commenter}: {comment.Text}");
        }
        Console.WriteLine("\n");
    }
}

class Program
{
    static void Main()
    {
        // Creating videos
        Video video1 = new Video("Introduction to C#", "C# Guru", 10);
        Video video2 = new Video("ASP.NET Core Basics", "WebMaster", 15);
        Video video3 = new Video("Machine Learning in C#", "ML Enthusiast", 20);

        // Adding comments to videos
        video1.AddComment("Viewer1", "Great tutorial!");
        video1.AddComment("Viewer2", "I learned a lot, thanks!");

        video2.AddComment("Viewer3", "Nice explanation of MVC.");
        video2.AddComment("Viewer4", "Looking forward to more tutorials!");

        video3.AddComment("Viewer5", "This is amazing!");
        video3.AddComment("Viewer6", "Could you cover neural networks in more detail?");

        // Displaying information about videos
        video1.DisplayInfo();
        video2.DisplayInfo();
        video3.DisplayInfo();
    }
}
