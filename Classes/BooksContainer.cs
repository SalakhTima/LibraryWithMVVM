using System.Collections.Generic;
using System.Linq;
using TaskLibrary.Interfaces;

namespace TaskLibrary.Classes;

public class BooksContainer : IBase<Book>
{
    public List<Book> Container { get; protected set; } = new();
    public void Add(Book book) => Container.Add(book);
    public void Remove(Book book) => Container.Remove(book);
    public Book? Find(int identifier)
    {
        return Container.FirstOrDefault(r => r.Article == identifier);
    }
    //public override bool Find(int identifier, out Book result)
    //{
    //    result = Container.FirstOrDefault(r => r.Article == identifier);
    //    return result is not null;
    //}
}