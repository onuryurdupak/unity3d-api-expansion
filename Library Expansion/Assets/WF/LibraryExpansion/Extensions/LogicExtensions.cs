using System.Collections.Generic;

public static class LogicExtensions
{
    public static bool MultipleAnd(this List<bool> list)
    {
        foreach (bool b in list)
        {
            if (!b)
                return false;
        }
        return true;
    }

    public static bool MultipleOr(this List<bool> list)
    {
        foreach (bool b in list)
        {
            if (b)
                return true;
        }
        return false;
    }
}
