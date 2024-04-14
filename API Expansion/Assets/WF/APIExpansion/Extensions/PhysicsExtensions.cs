using UnityEngine;

public static class PhysicsExtensions
{
    /// <summary>
    /// Adds to X field of a Vector3 the specified amount.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static Vector3 AddX(this Vector3 input, float amount)
    {
        return new Vector3(input.x + amount, input.y, input.z);
    }

    /// <summary>
    /// Adds to Y field of a Vector3 by specified amount.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static Vector3 AddY(this Vector3 input, float amount)
    {
        return new Vector3(input.x, input.y + amount, input.z);
    }

    /// <summary>
    /// Adds to Z field of a Vector3 by specified amount.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static Vector3 AddZ(this Vector3 input, float amount)
    {
        return new Vector3(input.x + amount, input.y, input.z + amount);
    }

    /// <summary>
    /// Sets X field of a Vector3 to the specified amount.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static Vector3 SetX(this Vector3 input, float amount)
    {
        return new Vector3(amount, input.y, input.z);
    }

    /// <summary>
    /// Sets Y field of a Vector3 to the specified amount.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static Vector3 SetY(this Vector3 input, float amount)
    {
        return new Vector3(input.x, amount, input.z);
    }

    /// <summary>
    /// Sets Z field of a Vector3 to the specified amount.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static Vector3 SetZ(this Vector3 input, float amount)
    {
        return new Vector3(input.x, input.y, amount);
    }

    /// <summary>
    /// Adds to X field of a Vector2 by specified amount.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static Vector2 AddX(this Vector2 input, float amount)
    {
        return new Vector2(input.x + amount, input.y);
    }

    /// <summary>
    /// Adds to Y field of a Vector2 by specified amount.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static Vector2 AddY(this Vector2 input, float amount)
    {
        return new Vector2(input.x, input.y + amount);
    }

    /// <summary>
    /// Sets X field of a Vector2 to the specified amount.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static Vector2 SetX(this Vector2 input, float amount)
    {
        return new Vector2(amount, input.y);
    }

    /// <summary>
    /// Sets Y field of a Vector2 to the specified amount.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static Vector2 SetY(this Vector2 input, float amount)
    {
        return new Vector2(input.x, amount);
    }

    /// <summary>
    /// Limits X field of a Vector2 to the specified amount.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static Vector2 LimitMaxX(this Vector2 input, float max)
    {
        if (input.x > max)
            input.x = max;

        return input;
    }

    /// <summary>
    /// Limits X field of a Vector2 to the specified limit.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="min"></param>
    /// <returns></returns>
    public static Vector2 LimitMinX(this Vector2 input, float min)
    {
        if (input.x < min)
            input.x = min;

        return input;
    }

    /// <summary>
    /// Limits Y field of a Vector3 to the specified amount.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static Vector3 LimitMaxX(this Vector3 input, float max)
    {
        if (input.x > max)
            input.x = max;

        return input;
    }

    /// <summary>
    /// Limits X field of a Vector3 to the specified amount.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="min"></param>
    /// <returns></returns>
    public static Vector3 LimitMinX(this Vector3 input, float min)
    {
        if (input.x < min)
            input.x = min;

        return input;
    }

    /// <summary>
    /// Limits Y field of a Vector3 to the specified amount.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static Vector3 LimitMaxY(this Vector3 input, float max)
    {
        if (input.y > max)
            input.y = max;

        return input;
    }

    /// <summary>
    /// Limits Y field of a Vector3 to the specified amount.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="min"></param>
    /// <returns></returns>
    public static Vector3 LimitMinY(this Vector3 input, float min)
    {
        if (input.y < min)
            input.y = min;

        return input;
    }

    /// <summary>
    /// Limits Z field of a Vector3 to the specified amount.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static Vector3 LimitMaxZ(this Vector3 input, float max)
    {
        if (input.z > max)
            input.z = max;

        return input;
    }

    /// <summary>
    /// Limits Z field of a Vector3 to the specified amount.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="min"></param>
    /// <returns></returns>
    public static Vector3 LimitMinZ(this Vector3 input, float min)
    {
        if (input.z < min)
            input.z = min;

        return input;
    }

    /// <summary>
    /// Adds a specified number of degrees to the X-axis rotation of a Quaternion.
    /// </summary>
    /// <param name="quaternion"></param>
    /// <param name="angles"></param>
    /// <returns></returns>
    public static Quaternion AddDegreesX(this Quaternion quaternion, float angles)
    {
        Vector3 euler = quaternion.eulerAngles;
        Quaternion newQuaternion = Quaternion.Euler(euler + new Vector3(angles, 0, 0));
        return newQuaternion;
    }

    /// <summary>
    /// Adds a specified number of degrees to the Y-axis rotation of a Quaternion.
    /// </summary>
    /// <param name="quaternion"></param>
    /// <param name="angles"></param>
    /// <returns></returns>
    public static Quaternion AddDegreesY(this Quaternion quaternion, float angles)
    {
        Vector3 euler = quaternion.eulerAngles;
        Quaternion newQuaternion = Quaternion.Euler(euler + new Vector3(0, angles, 0));
        return newQuaternion;
    }

    /// <summary>
    /// Adds a specified number of degrees to the Z-axis rotation of a Quaternion.
    /// </summary>
    /// <param name="quaternion"></param>
    /// <param name="angles"></param>
    /// <returns></returns>
    public static Quaternion AddDegreesZ(this Quaternion quaternion, float angles)
    {
        Vector3 euler = quaternion.eulerAngles;
        Quaternion newQuaternion = Quaternion.Euler(euler + new Vector3(0, 0, angles));
        return newQuaternion;
    }

    /// <summary>
    /// Moves a Rigidbody towards a target position in the horizontal plane (XZ) by a specified amount.
    /// </summary>
    /// <param name="rb"></param>
    /// <param name="target"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static bool MoveTowards(this Rigidbody rb, Vector3 target, float amount)
    {
        Vector3 currentTopDownPos = new(rb.position.x, 0, rb.position.z);
        Vector3 worldTopDownPos = new(target.x, 0, target.z);

        float diff = (currentTopDownPos - worldTopDownPos).magnitude;

        bool targetReached = false;

        if (amount > diff)
        {
            amount = diff;
            targetReached = true;
        }

        Vector3 newPos = rb.position + (rb.transform.forward * amount);
        rb.MovePosition(newPos);

        return targetReached;
    }
}
