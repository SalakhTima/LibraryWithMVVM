using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TaskLibrary.Model;

namespace TaskLibrary.ViewModel;

public class BookViewModel : PropertyChanger
{
    private Book? _selectedBook;
    public Book? SelectedBook 
    {
        get => _selectedBook;
        set => SetField(ref _selectedBook, value);
    }
    private ICommand? _addBookCommand;
    public ICommand AddBookCommand
    {
        get
        {
            return _addBookCommand ??= new RelayCommand(o =>
            {
                var book = new Book();
                Books.Insert(0, book);
                SelectedBook = book;
            });
        }
    }
    private ICommand? _removeBookCommand;
    public ICommand RemoveBookCommand
    {
        get
        {
            return _removeBookCommand ??= new RelayCommand(o =>
            {
                Books.Remove(SelectedBook!);
            });
        }
    }
    private ICommand? _searchBookCommand;
    public ICommand SearchBookCommand
    {
        get
        {
            return _searchBookCommand ??= new RelayCommand(o =>
            {
                /*
                Команда в разработке
                */
            });
        }
    }
    public ObservableCollection<Book> Books { get; protected set; }

    public BookViewModel()
    {
        Books = new ObservableCollection<Book>
        {
            new Book(7890, "Лев Толстой", "Война и мир", new DateOnly(1865, 1, 1), 3),
            new Book(2811, "Федор Достоевский", "Идиот", new DateOnly(1868, 1, 1), 4),
            new Book(7880, "Александр Пушкин", "Евгений Онегин", new DateOnly(1825, 1, 1), 7),
            new Book(5895, "Михаил Лермонтов", "Герой нашего времени", new DateOnly(1840, 1, 1), 3)
        };
    }
    public Book? Find(int identifier) => Books.FirstOrDefault(r => r.Article == identifier);
}