using System;
using System.Collections.Generic;

public enum ListOpType
{
    Add,
    Remove,
    Update,
}

[Serializable]
public struct EventData<T>
{
    public T Data;
    public ListOpType OpType;
    public int TargetIndex;
}

/// <summary> 
/// Creates a reactive container that holds a list of given type.
/// Created instance can be registerd to receive changes in list elements.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ReactiveList<T>
{
    readonly List<Action<EventData<T>>> registeredHooks;
    readonly private List<T> reactiveValue;

    public ReactiveList()
    {
        reactiveValue = new List<T>();
        registeredHooks = new();
    }

    /// <summary>
    /// Hook is called at initial register for all elements.
    /// After that, hook will only be fired for changes in elements.
    /// </summary>
    /// <param name="hook"></param>
    public void Register(Action<EventData<T>> hook)
    {
        registeredHooks.Add(hook);

        for (int i = 0; i < reactiveValue.Count; i++)
        {
            EventData<T> eventData = new()
            {
                Data = reactiveValue[i],
                OpType = ListOpType.Add,
                TargetIndex = i,
            };
            hook.Invoke(eventData);
        }
    }

    /// <summary>
    /// Returns element at index.
    /// Modiying a returned reference will not notify registered hooks.
    /// Only assignments though Set() will trigger a notification on registered hooks.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public T At(int index)
    {
        return reactiveValue[index];
    }

    /// <summary>
    /// Updates list value at index and notifies hooks if element has changed.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    public void Set(int index, T value)
    {
        bool valueChanged = !EqualityComparer<T>.Default.Equals(value, reactiveValue[index]);
        reactiveValue[index] = value;

        if (valueChanged)
        {
            EventData<T> eventData = new()
            {
                Data = value,
                OpType = ListOpType.Update,
                TargetIndex = index,
            };

            NotifyHooks(eventData);
        }
    }

    /// <summary>
    /// Adds element to list and notifies registered hooks.
    /// </summary>
    /// <param name="value"></param>
    public void Add(T value)
    {
        reactiveValue.Add(value);
        int index = reactiveValue.Count - 1;

        EventData<T> eventData = new()
        {
            Data = value,
            OpType = ListOpType.Add,
            TargetIndex = index,
        };
        NotifyHooks(eventData);
    }

    /// <summary>
    /// Removes element from list if it exists and notifies registered hooks.
    /// </summary>
    /// <param name="value"></param>
    public void Remove(T value)
    {
        int index = reactiveValue.FindIndex(x => x.Equals(value));
        if (index == -1)
            return;

        reactiveValue.RemoveAt(index);

        EventData<T> eventData = new()
        {
            Data = default, // No need notify about removed data.
            OpType = ListOpType.Remove,
            TargetIndex = index,
        };
        NotifyHooks(eventData);
    }

    /// <summary>
    /// Removes element at target index and notifies registered hooks.
    /// </summary>
    /// <param name="index"></param>
    public void RemoveAt(int index)
    {
        reactiveValue.RemoveAt(index);
        EventData<T> eventData = new()
        {
            Data = default, // No need notify about removed data.
            OpType = ListOpType.Remove,
            TargetIndex = index,
        };
        NotifyHooks(eventData);
    }

    private void NotifyHooks(EventData<T> eventData)
    {
        /* Iterate backwards because we are also deleting null entries via index. */
        for (int i = registeredHooks.Count - 1; i >= 0; i--)
        {
            if (registeredHooks[i] != null)
                registeredHooks[i].Invoke(eventData);
            else
                registeredHooks.RemoveAt(i);
        }
    }
}
