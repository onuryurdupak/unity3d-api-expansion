using System;
using System.Collections.Generic;

public static class CollectionExtensions
{
    private static readonly Random random = new();

    public static void Shuffle<T>(this T[] array)
    {
        int n = array.Length;
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            (array[j], array[i]) = (array[i], array[j]);
        }
    }

    public static void Shuffle<T>(this List<T> list)
    {
        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            (list[j], list[i]) = (list[i], list[j]);
        }
    }

    public static T Find<T>(this T[] array, Predicate<T> match)
    {
        foreach (T item in array)
        {
            if (match(item))
                return item;
        }

        return default;
    }

    public static T[] FindAll<T>(this T[] array, Predicate<T> match)
    {
        List<T> result = new();

        foreach (T item in array)
        {
            if (match(item))
                result.Add(item);
        }

        return result.ToArray();
    }
}
