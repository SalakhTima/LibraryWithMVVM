using System.Collections.Generic;
using TaskLibrary.Classes;

namespace TaskLibrary.Abstraction;

public interface IBookDistributor
{
    void GiveBookToReader(List<Book> container, Book book);
}