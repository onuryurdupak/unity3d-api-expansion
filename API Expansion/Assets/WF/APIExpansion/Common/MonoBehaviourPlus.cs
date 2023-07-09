using System;
using System.Collections;
using UnityEngine;

public class MonoBehaviourPlus : MonoBehaviour
{
    /// <summary>
    /// Executes action after input frame counts pass.
    /// </summary>
    /// <param name="frameCount"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    protected Coroutine DoAfterFrames(int frameCount, Action action)
    {
        return StartCoroutine(CountFramesAndExecute(frameCount, action));
    }

    /// <summary>
    /// Executes action after input time (as seconds) pass.
    /// </summary>
    /// <param name="seconds"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    protected Coroutine DoAfterDuration(float seconds, Action action)
    {
        return StartCoroutine(CountSecondsAndExecute(seconds, action));
    }

    /// <summary>
    /// Executes input action per input seconds repeatedly.
    /// </summary>
    /// <param name="seconds"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    protected Coroutine DoPeriodically(float seconds, Action action)
    {
        return StartCoroutine(CountSecondsAndExecutePeriodically(seconds, action));
    }

    /// <summary>
    /// Continuously checks condition per frame. Executes action first time it returns true.
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    protected Coroutine DoWhen(Func<bool> condition, Action action)
    {
        return StartCoroutine(CheckDoWhen(condition, action));
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    private IEnumerator CountFramesAndExecute(int frameCount, Action action)
    {
        for (int i = 0; i < frameCount; i++)
        {
            yield return null;
        }

        action();
    }

    private IEnumerator CountSecondsAndExecute(float seconds, Action action)
    {
        float accumulated = 0;

        while (accumulated < seconds)
        {
            accumulated += Time.deltaTime;
            yield return null;
        }

        action();
    }

    private IEnumerator CountSecondsAndExecutePeriodically(float seconds, Action action)
    {
        while (true)
        {
            float accumulated = 0;

            while (accumulated < seconds)
            {
                accumulated += Time.deltaTime;
                yield return null;
            }

            action();
        }
    }

    private IEnumerator CheckDoWhen(Func<bool> condition, Action action)
    {
        while (true)
        {
            bool result = condition.Invoke();

            if (result)
            {
                action.Invoke();
                yield break;
            }

            yield return null;
        }
    }
}
