using System;
using UnityEngine;

public static class MathExtensions
{
    /// <summary>
    /// Returns angle between points, taking ONLY X and Z axes for calculation.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="other"></param>
    /// <returns></returns>
    public static float AngleBetween(this Vector3 source, Vector3 other)
    {
        var p1 = new Vector2(source.x, source.z);
        var p2 = new Vector2(other.x, other.z);
        var angle = Mathf.Atan2(p2.y - p1.y, p2.x - p1.x) * 180 / Mathf.PI;
        return angle;
    }

    /// <summary>
    /// Reduces amount of decimal placements to 2.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static float To2DecimalPlaces(this float input)
    {
        return (float)Math.Round(input * 100f) / 100f;
    }

    /// <summary>
    /// Makes an equality comparison with the defined floating point error.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="error"></param>
    /// <returns></returns>
    public static bool Equal(this float a, float b, float error)
    {
        return Math.Abs(a - b) < error;
    }
}
