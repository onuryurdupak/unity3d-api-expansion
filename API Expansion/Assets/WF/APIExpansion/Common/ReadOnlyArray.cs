/// <summary>
/// An array which can not be modified after initialization.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ReadOnlyArray<T>
{
    readonly T[] innerArr;

    public ReadOnlyArray(T[] array)
    {
        innerArr = array;
    }

    /// <summary>
    /// Returns element at given index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public T ElementAt(int index)
    {
        return innerArr[index];
    }

    public int Length => innerArr.Length;
}