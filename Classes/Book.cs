using System;

namespace TaskLibrary.Classes;

public class Book
{
    public int Article { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public int AvailableCopies { get; set; }
    public Book(int article, string author, string title, DateOnly releaseDate, int availableCopies)
    {
        Article = article;
        Author = author;
        Title = title;
        ReleaseDate = releaseDate;
        AvailableCopies = availableCopies;
    }
}