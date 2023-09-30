using System;
using System.Collections.Generic;
using System.Linq;
using TaskLibrary.Abstraction;

namespace TaskLibrary.Classes;

public class ReadersContainer : VariableBase<Reader>
{
    public override List<Reader> Container { get; protected set; } = new();
    public override void Add(Reader reader) => Container.Add(reader);
    public override void Remove(Reader reader) => Container.Remove(reader);
    public override Reader? Find(int identifier)
    {
        return Container.FirstOrDefault(r => r.Id == identifier);
    }
}
