using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video(
            "Learn C# in 20 Minutes",
            "CodeMaster",
            1200);

        video1.AddComment(new Comment("John", "Great tutorial!"));
        video1.AddComment(new Comment("Sarah", "Very easy to follow."));
        video1.AddComment(new Comment("Mike", "Helped me understand classes."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video(
            "Top 10 Programming Tips",
            "TechWorld",
            900);

        video2.AddComment(new Comment("Emma", "Excellent advice."));
        video2.AddComment(new Comment("David", "Loved tip number 5."));
        video2.AddComment(new Comment("Sophia", "Thanks for sharing."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video(
            "Object-Oriented Programming Explained",
            "Programming Hub",
            1500);

        video3.AddComment(new Comment("Chris", "Now OOP makes sense."));
        video3.AddComment(new Comment("Olivia", "Clear explanation."));
        video3.AddComment(new Comment("Daniel", "Very informative."));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video(
            "Data Structures Basics",
            "CS Academy",
            1800);

        video4.AddComment(new Comment("Grace", "Awesome content."));
        video4.AddComment(new Comment("James", "Looking forward to more."));
        video4.AddComment(new Comment("Lucas", "Well explained."));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("\nComments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine(
                    $"{comment.GetCommenterName()}: {comment.GetCommentText()}");
            }

            Console.WriteLine();
        }
    }
}