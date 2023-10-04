using System;
using System.Windows;
using TaskLibrary.Abstraction;
using TaskLibrary.Classes;
using TaskLibrary.Interfaces;

namespace TaskLibrary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IBase<Book> BooksContainer = new BooksContainer();
        public IBase<Reader> ReadersContainer = new ReadersContainer();
        public IBookDistributor BookDistributor = new BookDistributor();

        public MainWindow()
        {
            InitializeComponent();

            InitializeBooksContainer();
            InitializeReadersContainer();
            InitializeReadersBooks();

            BooksListView.ItemsSource = BooksContainer.Container;
            ReaderListView.ItemsSource = ReadersContainer.Container;
            ReadersBooksListView.ItemsSource = ReadersContainer.Container;
        }

        private void SearchBookButtonClick(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(FindBookInput.Text, out int article))
            {
                BookInfoTextBlock.Text = "Введены некорректные данные.";
                return;
            }

            var book = BooksContainer.Find(article);

            BookInfoTextBlock.Text = book is null
                ? "Такой книги не существует."
                : $"Артикул: {book.Article}\nАвтор: {book.Author}\nНазвание: {book.Title}\nДата выпуска: {book.ReleaseDate}\nДоступные копии: {book.AvailableCopies}";
        }

        private void SearchReaderButtonClick(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(FindReaderInput.Text, out int id))
            {
                ReaderInfoTextBlock.Text = "Введены некорректные данные.";
                return;
            }

            var reader = ReadersContainer.Find(id);

            ReaderInfoTextBlock.Text = reader is null
                ? "Такого читателя не существует."
                : $"Идентификатор: {reader.Id}\nИмя: {reader.FirstName}\nФамилия: {reader.LastName}";
        }

        private void GiveBookToReaderButtonClick(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(GetBookByArticleInput.Text, out int article) || !int.TryParse(GetReaderByIdInput.Text, out int id))
            {
                MessageTextBlock.Text = "Введены некорректные данные для артикля книги и/или идентификатора читателя.";
                return;
            }

            var reader = ReadersContainer.Find(id);
            var book = BooksContainer.Find(article);

            if (reader is null && book is null)
            {
                MessageTextBlock.Text = "Такого читателя и такой книги не существует.";
            }
            else if (reader is null)
            {
                MessageTextBlock.Text = "Такого читателя не существует.";
            }
            else if (book is null)
            {
                MessageTextBlock.Text = "Такой книги не существует.";
            }
            else if (book.AvailableCopies > 0)
            {
                BookDistributor.GiveBookToReader(reader.Books, book);
                RefreshTotalListsItems();
                MessageTextBlock.Text = "Книга успешно выдана читателю.";
            }
            else
            {
                MessageTextBlock.Text = "Нет доступных копий этой книги.";
            }
        }

        private void AddNewReaderButtonClick(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(NewReadersIdInput.Text, out int id))
            {
                AddNewReaderTextBlock.Text = "Идентификатор читателя должен быть числом.";
                return;
            }

            if (NewReadersFirstNameInput.Text is not "" && NewReadersLastNameInput.Text is not "")
            {
                ReadersContainer.Add(new Reader(id, NewReadersFirstNameInput.Text, NewReadersLastNameInput.Text));
                RefreshTotalListsItems();
                AddNewReaderTextBlock.Text = "Читатель успешно добавлен.";
            }
            else
            {
                AddNewReaderTextBlock.Text = "Вы должны ввести все данные.";
            }
        }

        private void AddNewBookButtonClick(object sender, RoutedEventArgs e)
        {
            var newArticleStatement = int.TryParse(NewBookArticleInput.Text, out int article);
            var newYearStatement = int.TryParse(NewBookYearInput.Text, out int year);
            var newCopiesStatement = int.TryParse(NewBookAvailableCopiesInput.Text, out int copies);

            if (!(newArticleStatement && newYearStatement && newCopiesStatement))
            {
                AddNewBookTextBlock.Text = "Введены некорректные данные для артикля и/или года выпуска и/или количества экземпляров книги";
                return;
            }

            if (NewBookAuthorInput.Text is not "" && NewBookTitleInput.Text is not "")
            {
                BooksContainer.Add(new Book(article, NewBookAuthorInput.Text, NewBookTitleInput.Text, new DateOnly(year, 1, 1), copies));
                RefreshTotalListsItems();
                AddNewBookTextBlock.Text = "Книга успешно добавлена.";
            }
            else
            {
                AddNewBookTextBlock.Text = "Вы должны ввести все данные.";
            }
        }

        private void RefreshTotalListsItems()
        {
            BooksListView.Items.Refresh();
            ReaderListView.Items.Refresh();
            ReadersBooksListView.Items.Refresh();
        }

        private void InitializeReadersContainer()
        {
            BooksContainer.Add(new Book(7890, "Лев Толстой", "Война и мир", new DateOnly(1865, 1, 1), 3));
            BooksContainer.Add(new Book(2811, "Федор Достоевский", "Идиот", new DateOnly(1868, 1, 1), 4));
            BooksContainer.Add(new Book(7880, "Александр Пушкин", "Евгений Онегин", new DateOnly(1825, 1, 1), 7));
            BooksContainer.Add(new Book(5895, "Михаил Лермонтов", "Герой нашего времени", new DateOnly(1840, 1, 1), 3));
        }
        private void InitializeBooksContainer()
        {
            ReadersContainer.Add(new Reader(1, "Олег", "Баклажанов"));
            ReadersContainer.Add(new Reader(2, "Ахмед", "Исмаилов"));
            ReadersContainer.Add(new Reader(3, "Армен", "Армянов"));
            ReadersContainer.Add(new Reader(4, "Илон", "Маск"));
            ReadersContainer.Add(new Reader(5, "Джо", "Байден"));
        }

        public void InitializeReadersBooks()
        {
            BookDistributor.GiveBookToReader(ReadersContainer.Find(1)!.Books, BooksContainer.Find(5895)!);
            BookDistributor.GiveBookToReader(ReadersContainer.Find(1)!.Books, BooksContainer.Find(7890)!);
            BookDistributor.GiveBookToReader(ReadersContainer.Find(2)!.Books, BooksContainer.Find(2811)!);
            BookDistributor.GiveBookToReader(ReadersContainer.Find(2)!.Books, BooksContainer.Find(2811)!);
            BookDistributor.GiveBookToReader(ReadersContainer.Find(3)!.Books, BooksContainer.Find(7880)!);
            BookDistributor.GiveBookToReader(ReadersContainer.Find(3)!.Books, BooksContainer.Find(2811)!);
            BookDistributor.GiveBookToReader(ReadersContainer.Find(4)!.Books, BooksContainer.Find(7890)!);
            BookDistributor.GiveBookToReader(ReadersContainer.Find(4)!.Books, BooksContainer.Find(7880)!);
            BookDistributor.GiveBookToReader(ReadersContainer.Find(5)!.Books, BooksContainer.Find(7880)!);
        }
    }
}
