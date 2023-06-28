using UnityEngine;

/// <summary>
/// Intended for usages of passing a primitive value as a reference.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Reference<T>
{
    [ReadOnly][SerializeField] private T value;

    public T Get()
    {
        return value;
    }

    public void Set(T value)
    {
        this.value = value;
    }
}
