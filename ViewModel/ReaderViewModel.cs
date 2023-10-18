using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TaskLibrary.Model;
using TaskLibrary.View;

namespace TaskLibrary.ViewModel;

public class ReaderViewModel : PropertyChanger
{
    private readonly BookViewModel _bookViewModel;
    private Reader? _selectedReader;
    public Reader? SelectedReader
    {
        get => _selectedReader;
        set => SetField(ref _selectedReader, value);
    }
    private ICommand? _addReaderCommand;
    public ICommand AddReaderCommand
    {
        get
        {
            return _addReaderCommand ??= new RelayCommand(o =>
            {
                var reader = new Reader();
                Readers.Insert(0, reader);
                SelectedReader = reader;
            });
        }
    }
    private ICommand? _removeReaderCommand;
    public ICommand RemoveReaderCommand
    {
        get
        {
            return _removeReaderCommand ??= new RelayCommand(o =>
            {
                Readers.Remove(SelectedReader!);
            });
        }
    }
    private ICommand? _giveBookToReaderCommand;
    public ICommand GiveBookToReaderCommand
    {
        get
        {
            return _giveBookToReaderCommand ??= new RelayCommand(o =>
            {
                var bookDistributorsWindow = new BookDistributorsWindow();

                if (bookDistributorsWindow.ShowDialog() is not true) return;
                if (!int.TryParse(bookDistributorsWindow.BookSearcher.Text, out int article))
                {
                    return;
                }

                var selectedBook = _bookViewModel.Find(article);
                if (selectedBook is null || selectedBook.AvailableCopies <= 0) return;

                SelectedReader!.Books!.Add(selectedBook);
                selectedBook.AvailableCopies--;
            });
        }
    }
    private ICommand? _searchReaderCommand;
    public ICommand SearchReaderCommand
    {
        get
        {
            return _searchReaderCommand ??= new RelayCommand(o =>
            {
                /*
                Команда в разработке
                */
            });
        }
    }
    public ObservableCollection<Reader> Readers { get; protected set; }

    public ReaderViewModel()
    {
        _bookViewModel = new BookViewModel();
        Readers = new ObservableCollection<Reader>
        {
            new Reader(1, "Олег", "Баклажанов", new List<Book>
            {
                _bookViewModel.Find(7890)!
            }),
            new Reader(5, "Джо", "Байден", new List<Book>
            {
                _bookViewModel.Find(2811)!,
                _bookViewModel.Find(2811)!
            }),
            new Reader(2, "Ахмед", "Исмаилов", new List<Book>
            {
                _bookViewModel.Find(7880)!,
                _bookViewModel.Find(2811)!
            }),
            new Reader(3, "Армэн", "Армэнов", new List<Book>
            {
                _bookViewModel.Find(7890)!,
                _bookViewModel.Find(7880)!
            }),
            new Reader(4, "Илон", "Маск", new List<Book>
            {
                _bookViewModel.Find(7880)!
            })
        };
    }
    public Reader? Find(int identifier) => Readers.FirstOrDefault(r => r.Id == identifier);
}
