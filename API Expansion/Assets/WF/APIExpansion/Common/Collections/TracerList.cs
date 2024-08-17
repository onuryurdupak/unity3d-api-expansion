using System.Collections;
using System.Collections.Generic;

/// <summary>
/// An extension System.Collections.Generic.List of which keeps track of last deleted eleements.
/// </summary>
/// <typeparam name="T"></typeparam>
public class TracerList<T> : IEnumerable<T>
{
    readonly List<T> internalList;
    T lastDeletedItem;

    /// <summary>
    /// Returns the last deleted item from the list.
    /// </summary>
    public T LastDeletedItem => lastDeletedItem;
    public int Count => internalList.Count;

    public TracerList()
    {
        internalList = new();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return internalList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return internalList.GetEnumerator();
    }

    public void Add(T item)
    {
        internalList.Add(item);
    }

    public void Remove(T item)
    {
        bool contains = internalList.Contains(item);
        if (contains)
            lastDeletedItem = item;

        internalList.Remove(item);
    }

    public T At(int index)
    {
        return internalList[index];
    }

    public void Clear()
    {
        internalList.Clear();
    }
}
