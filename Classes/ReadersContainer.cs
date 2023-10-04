using System;
using System.Collections.Generic;
using System.Linq;
using TaskLibrary.Interfaces;

namespace TaskLibrary.Classes;

public class ReadersContainer : IBase<Reader>
{
    public List<Reader> Container { get; protected set; } = new();
    public void Add(Reader reader) => Container.Add(reader);
    public void Remove(Reader reader) => Container.Remove(reader);
    public Reader? Find(int identifier)
    {
        return Container.FirstOrDefault(r => r.Id == identifier);
    }
}
