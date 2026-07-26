using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Evicts oldest entries first when entries are pushed past capacity.
/// </summary>
/// <typeparam name="T"></typeparam>
public class RollingStack<T> : IEnumerable<T>
{
    readonly LinkedList<T> internalList;

    /// <summary>Number of entries currently stored.</summary>
    public int Count => internalList.Count;

    /// <summary>Maximum number of entries before oldest ones are evicted.</summary>
    public int Capacity { get; private set; }

    /// <summary>Creates a stack that evicts oldest entries past <paramref name="cap"/> entries.</summary>
    public RollingStack(int cap)
    {
        if (cap <= 0)
            throw new ArgumentOutOfRangeException(nameof(cap), "Capacity must be greater than zero.");

        internalList = new LinkedList<T>();
        Capacity = cap;
    }

    /// <summary>Pushes a value, evicting the oldest entry if at capacity.</summary>
    public void Push(T value)
    {
        if (Count >= Capacity)
            internalList.RemoveFirst();

        internalList.AddLast(value);
    }

    /// <summary>Removes and returns the most recently pushed value.</summary>
    public T Pop()
    {
        if (internalList.Last == null)
            throw new InvalidOperationException("Stack is empty.");

        T value = internalList.Last.Value;
        internalList.RemoveLast();
        return value;
    }

    /// <summary>Returns the most recently pushed value without removing it.</summary>
    public T Peek()
    {
        if (internalList.Last == null)
            throw new InvalidOperationException("Stack is empty.");

        return internalList.Last.Value;
    }

    /// <summary>Attempts to remove and return the most recently pushed value.</summary>
    public bool TryPop(out T result)
    {
        result = default;

        if (internalList.Last == null)
            return false;

        result = internalList.Last.Value;
        internalList.RemoveLast();
        return true;
    }

    /// <summary>Attempts to return the most recently pushed value without removing it.</summary>
    public bool TryPeek(out T result)
    {
        result = default;

        if (internalList.Last == null)
            return false;

        result = internalList.Last.Value;
        return true;
    }

    /// <summary>Checks whether an item is present in the stack.</summary>
    public bool Contains(T item)
    {
        return internalList.Contains(item);
    }

    /// <summary>Removes all entries.</summary>
    public void Clear()
    {
        internalList.Clear();
    }

    /// <summary>Copies entries to a new array, newest first.</summary>
    public T[] ToArray()
    {
        T[] newArr = new T[Count];

        LinkedListNode<T> currentNode = internalList.Last;

        for (int i = 0; i < internalList.Count; i++)
        {
            newArr[i] = currentNode.Value;
            currentNode = currentNode.Previous;
        }

        return newArr;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = internalList.Last;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Previous;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
