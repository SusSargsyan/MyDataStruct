using System.Collections;

namespace MyLinkedListLibrary;

public class MyStack<T> : IEnumerable<T>
{
    private MyLinkedList<T> _list = new MyLinkedList<T>();

    public void Push(T value) => _list.AddFirst(value);
    public T Pop()
    {
        T val = _list.GetFirst();
        _list.RemoveFirst();
        return val;
    }
    public T Peek() => _list.GetFirst();
    public bool IsEmpty() => _list.Count == 0;

    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
