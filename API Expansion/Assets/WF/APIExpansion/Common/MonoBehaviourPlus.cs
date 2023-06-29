using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Object = UnityEngine.Object;

public class MonoBehaviourPlus : MonoBehaviour
{
    HashSet<object> cachedComponents = new();
    HashSet<object> cachedObjects = new();

    /// <summary>
    /// Retrieves component of input type from game object's immediate components.
    /// Caches it for future use.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T CompCache<T>()
    {
        bool exists = cachedComponents.TryGetValue(typeof(T), out object actualVal);

        if (exists)
        {
            return (T)actualVal;
        }

        object foundComponent = GetComponent<T>();

        if (foundComponent == default)
            return default;

        cachedComponents.Add(foundComponent);
        return (T)foundComponent;
    }

    /// <summary>
    /// Retrieves component of input type from scene.
    /// Caches it for future use.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T SceneCache<T>() where T : Object
    {
        bool exists = cachedObjects.TryGetValue(typeof(T), out object actualVal);

        if (exists)
        {
            return (T)actualVal;
        }

        object foundObject = FindObjectOfType<T>();

        if (foundObject == default)
            return default;

        cachedObjects.Add(foundObject);
        return (T)foundObject;
    }

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
