using System;
using System.Collections.Generic;

/// <summary>
/// Creates a reactive container that holds a given type of value.
/// Created instance can be registerd to receive changes in stored value.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Reactive<T>
{
    readonly List<Action<T>> registeredHooks;
    private T reactiveValue;

    public Reactive(T initialValue)
    {
        reactiveValue = initialValue;
        registeredHooks = new();
    }

    /// <summary>
    /// Hook is called at initial register and whenever the underlying value changes to a different value.
    /// </summary>
    /// <param name="hook"></param>
    public void Register(Action<T> hook)
    {
        registeredHooks.Add(hook);
        hook.Invoke(reactiveValue);
    }

    /// <summary>
    /// Returns element.
    /// Modiying a returned reference will not notify registered hooks.
    /// Only assignments though Set() will trigger a notification on registered hooks.
    /// </summary>
    /// <returns></returns>
    public T Get()
    {
        return reactiveValue;
    }

    /// <summary>
    /// Updates the stored value and notifies hooks if value has changed.
    /// </summary>
    /// <param name="value"></param>
    public void Set(T value)
    {
        bool valueChanged = !EqualityComparer<T>.Default.Equals(value, reactiveValue);
        reactiveValue = value;

        if (valueChanged)
        {
            /* Iterate backwards because we are also deleting null entries via index. */
            for (int i = registeredHooks.Count - 1; i >= 0; i--)
            {
                if (registeredHooks[i] != null)
                    registeredHooks[i].Invoke(value);
                else
                    registeredHooks.RemoveAt(i);
            }
        }
    }
}
