using UnityEngine;

public static class PhysicsExtensions
{
    public static Vector3 AddX(this Vector3 input, float amount)
    {
        return new Vector3(input.x + amount, input.y, input.z);
    }

    public static Vector3 AddY(this Vector3 input, float amount)
    {
        return new Vector3(input.x, input.y + amount, input.z);
    }

    public static Vector3 AddZ(this Vector3 input, float amount)
    {
        return new Vector3(input.x + amount, input.y, input.z + amount);
    }

    public static Vector3 SetX(this Vector3 input, float amount)
    {
        return new Vector3(amount, input.y, input.z);
    }

    public static Vector3 SetY(this Vector3 input, float amount)
    {
        return new Vector3(input.x, amount, input.z);
    }

    public static Vector3 SetZ(this Vector3 input, float amount)
    {
        return new Vector3(input.x, input.y, amount);
    }

    public static Vector2 AddX(this Vector2 input, float amount)
    {
        return new Vector2(input.x + amount, input.y);
    }

    public static Vector2 AddY(this Vector2 input, float amount)
    {
        return new Vector2(input.x, input.y + amount);
    }

    public static Vector2 SetX(this Vector2 input, float amount)
    {
        return new Vector2(amount, input.y);
    }

    public static Vector2 SetY(this Vector2 input, float amount)
    {
        return new Vector2(input.x, amount);
    }
    
    public static Quaternion AddDegreesX(this Quaternion quaternion, float angles)
    {
        Vector3 euler = quaternion.eulerAngles;
        Quaternion newQuaternion = Quaternion.Euler(euler + new Vector3(angles, 0, 0));
        return newQuaternion;
    }

    public static Quaternion AddDegreesY(this Quaternion quaternion, float angles)
    {
        Vector3 euler = quaternion.eulerAngles;
        Quaternion newQuaternion = Quaternion.Euler(euler + new Vector3(0, angles, 0));
        return newQuaternion;
    }

    public static Quaternion AddDegreesZ(this Quaternion quaternion, float angles)
    {
        Vector3 euler = quaternion.eulerAngles;
        Quaternion newQuaternion = Quaternion.Euler(euler + new Vector3(0, 0, angles));
        return newQuaternion;
    }

    public static bool MoveTowards(this Rigidbody rb, Vector3 target, float amount)
    {
        Vector3 currentTopDownPos = new Vector3(rb.position.x, 0, rb.position.z);
        Vector3 worldTopDownPos = new Vector3(target.x, 0, target.z);

        float diff = (currentTopDownPos - worldTopDownPos).magnitude;

        bool targetReached = false;

        // To prevent overshooting final position.
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
