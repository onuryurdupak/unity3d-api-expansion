using UnityEngine;

public static class ColorExtensions
{
    public static Color MultiplyExceptAlpha(this Color sourceColor, float multiplier)
    {
        return new Color(sourceColor.r * multiplier, sourceColor.g * multiplier, sourceColor.b * multiplier, sourceColor.a);
    }

    public static Color SubtractExceptAlpha(this Color sourceColor, Color other)
    {
        return new Color(sourceColor.r - other.r, sourceColor.g - other.g, sourceColor.b - other.b, sourceColor.a);
    }
}
