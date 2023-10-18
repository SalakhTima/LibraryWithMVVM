using System.Windows;
using TaskLibrary.ViewModel;

namespace TaskLibrary.View;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Books.DataContext = new BookViewModel();
        Readers.DataContext = new ReaderViewModel();
        ReadersBooks.DataContext = new ReaderViewModel();
    }
}