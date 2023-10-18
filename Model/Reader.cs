using System.Collections.Generic;

namespace TaskLibrary.Model;

public class Reader : PropertyChanger
{
    private int _id;
    private string? _firstName;
    private string? _lastName;
    private List<Book>? _books;

    public int Id
    {
        get => _id;
        set => SetField(ref _id, value);
    }
    public string? FirstName
    {
        get => _firstName;
        set => SetField(ref _firstName, value);
    }
    public string? LastName
    {
        get => _lastName;
        set => SetField(ref _lastName, value);
    }
    public List<Book>? Books
    {
        get => _books;
        set => SetField(ref _books, value);
    }
    public Reader() { }
    public Reader(int id, string? firstName, string? lastName, List<Book>? books)
    {
        _id = id;
        _firstName = firstName;
        _lastName = lastName;
        _books = books;
    }
}