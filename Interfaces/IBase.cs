using System.Collections.Generic;

namespace TaskLibrary.Interfaces;

public interface IBase<T> where T : class
{
    List<T> Container { get; }
    void Add(T obj);
    void Remove(T obj);
    T? Find(int identifier);
}