using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learn C# in 20 Minutes", "Code Academy", 1200);
        video1.AddComment(new Comment("John", "Very helpful tutorial!"));
        video1.AddComment(new Comment("Sarah", "I finally understand classes."));
        video1.AddComment(new Comment("Michael", "Great explanation."));
        video1.AddComment(new Comment("Grace", "Please make a part 2."));
        videos.Add(video1);

        Video video2 = new Video("Top 10 Programming Tips", "Tech World", 850);
        video2.AddComment(new Comment("David", "Excellent advice."));
        video2.AddComment(new Comment("Emily", "I learned a lot."));
        video2.AddComment(new Comment("James", "Subscribed!"));
        video2.AddComment(new Comment("Sophia", "Very informative."));
        videos.Add(video2);

        Video video3 = new Video("Object-Oriented Programming Explained", "Programming Hub", 1500);
        video3.AddComment(new Comment("Daniel", "Best OOP video."));
        video3.AddComment(new Comment("Emma", "Encapsulation is much clearer now."));
        video3.AddComment(new Comment("Chris", "Thank you!"));
        video3.AddComment(new Comment("Olivia", "Fantastic content."));
        videos.Add(video3);

        Video video4 = new Video("Visual Studio Code for Beginners", "Dev Tutorials", 900);
        video4.AddComment(new Comment("Noah", "Exactly what I needed."));
        video4.AddComment(new Comment("Liam", "Very easy to follow."));
        video4.AddComment(new Comment("Ava", "Thanks for sharing."));
        video4.AddComment(new Comment("Mia", "Awesome tutorial."));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Comments: {video.GetNumberOfComments()}");
            Console.WriteLine();

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}