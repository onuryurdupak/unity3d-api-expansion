using System;

/// <summary>
/// Ensures that the provided action is executed only once, regardless of how many times the method is called.
/// </summary>
/// <remarks>
/// Implementation is not thread-safe.
/// </remarks>
public class DoOnce
{
    readonly Action action;
    bool hasExecuted = false;

    public DoOnce(Action action)
    {
        this.action = action;
    }

    public void Execute()
    {
        if (hasExecuted)
            return;

        action.Invoke();
        hasExecuted = true;
    }
}
