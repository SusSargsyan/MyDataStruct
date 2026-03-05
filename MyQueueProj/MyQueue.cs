using System.Collections;
using System.Collections.Generic;

public class Queue<T> : IEnumerable<T>
{
    LinkedList<T> _items = new LinkedList<T>();

    public void Enqueue(T item)
    {
        _items.AddLast(item);
    }

    public T Dequeue()
    {
        T value = _items.First.Value;
        _items.RemoveFirst();
        return value;
    }

    public T Peek()
    {
        return _items.First.Value;
    }

    public int Count
    {
        get { return _items.Count; }
    }

    public void Clear()
    {
        _items.Clear();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}