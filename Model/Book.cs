using System;

namespace TaskLibrary.Model;

public class Book : PropertyChanger
{
    private int _article;
    private string? _author;
    private string? _title;
    private DateOnly _releaseDate;
    private int _availableCopies;

    public int Article
    {
        get => _article;
        set => SetField(ref _article, value);
    }
    public string? Author
    {
        get => _author;
        set => SetField(ref _author, value);
    }
    public string? Title
    {
        get => _title;
        set => SetField(ref _title, value);
    }
    public DateOnly ReleaseDate
    {
        get => _releaseDate;
        set => SetField(ref _releaseDate, value);
    }
    public int AvailableCopies
    {
        get => _availableCopies;
        set => SetField(ref _availableCopies, value);
    }

    public Book() { }
    public Book(int article, string? author, string? title, DateOnly releaseDate, int availableCopies)
    {
        _article = article;
        _author = author;
        _title = title;
        _releaseDate = releaseDate;
        _availableCopies = availableCopies;
    }
}