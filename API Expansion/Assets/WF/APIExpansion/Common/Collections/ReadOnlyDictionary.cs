using System.Collections.Generic;
/// <summary>
/// A dictionary which can not be modified after initialization.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ReadOnlyDictionary<T1, T2>
{
    readonly Dictionary<T1, T2> innerDictionary;

    public ReadOnlyDictionary(Dictionary<T1, T2> dictionary)
    {
        innerDictionary = dictionary;
    }

    /// <summary>
    /// Returns element at given key.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public T2 GetByKey(T1 key)
    {
        return innerDictionary[key];
    }

    public bool TryGetValue(T1 key, out T2 value)
    {
        return innerDictionary.TryGetValue(key, out value);
    }

    public int Count => innerDictionary.Count;

    /// <summary>
    /// Returns keys in the dictionary.
    /// Can be used for iterating over dictionary.
    /// </summary>
    /// <returns></returns>
    public T1[] GetKeys()
    {
        T1[] keys = new T1[innerDictionary.Count];
        int i = 0;

        foreach (var pair in innerDictionary)
        {
            keys[i] = pair.Key;
            i++;
        }
        return keys;
    }
}
