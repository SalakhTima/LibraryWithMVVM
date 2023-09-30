using System.Collections.Generic;
using TaskLibrary.Abstraction;

namespace TaskLibrary.Classes;

public class BookDistributor : IBookDistributor
{
    public void GiveBookToReader(List<Book> container, Book book)
    {
        container.Add(book);
        book.AvailableCopies--;
    }
}