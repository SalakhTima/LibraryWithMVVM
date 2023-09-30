using System.Collections.Generic;
using System.Linq;
using TaskLibrary.Abstraction;

namespace TaskLibrary.Classes;

public class BooksContainer : VariableBase<Book>
{
    public override List<Book> Container { get; protected set; } = new();
    public override void Add(Book book) => Container.Add(book);
    public override void Remove(Book book) => Container.Remove(book);
    public override Book? Find(int identifier)
    {
        return Container.FirstOrDefault(r => r.Article == identifier);
    }
}