using System.Collections.Generic;

namespace TaskLibrary.Abstraction;

public abstract class VariableBase<T> where T : class
{
    public abstract List<T> Container { get; protected set; }
    public abstract void Add(T obj);
    public abstract void Remove(T obj);
    public abstract T? Find(int identifier);
}