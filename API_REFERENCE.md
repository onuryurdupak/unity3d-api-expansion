# API Reference


## Common

### MonoBehaviourPlus

New base class to derive custom components from.

`protected Coroutine DoAfterFrames(int frameCount, Action action)`: Fires input action after input frame count has passed.

`protected Coroutine DoAfterDuration(float seconds, Action action)`: Fires input action after input time in seconds has passed.

`protected Coroutine DoPeriodically(float seconds, Action action)`: Fires input action periodically with input time in seconds interval.

`protected Coroutine DoWhen(Predicate<bool> condition, Action action)`: Fires input action when input condition returns true. Condition is checked per game frame.

`public void DestroyGameObject()`: Destroys the GameObject this component is attached to.

### Reference\<T\>

Allows passing any type of data as reference type (encapsulating input type in an object instance). Can be a replacement for usage of `ref` keyword in some cases.

`public Reference(T initialValue)`

`public T Get()`: Returns current value.

`public void Set(T value)`: Updates current value.

### FloatRange, IntRange

`Min`/`Max` pair types for cases where `Vector2`'s `X`/`Y` naming doesn't fit (e.g. a numeric range). Both are `[Serializable]` and use the same custom Inspector drawer, which renders them inline the same way Unity draws `Vector2`, but labeled `Min`/`Max` instead of `X`/`Y`.

```csharp
public struct FloatRange
{
    public float Min;
    public float Max;
}

public struct IntRange
{
    public int Min;
    public int Max;
}
```

---

## Common/Collections

### ReadOnlyArray\<T\>, ReadOnlyDictionary\<T1, T2\>

Read-only variants of array and dictionary types. Prevents tampering of internal data by means of assigning or updating values via keys or indices.

`public ReadOnlyArray(T[] array)`

`public T ElementAt(int index)`

`public int Length { get; }`

`public ReadOnlyDictionary(Dictionary<T1, T2> dictionary)`

`public T2 GetByKey(T1 key)`

`public bool TryGetValue(T1 key, out T2 value)`

`public int Count { get; }`

`public T1[] GetKeys()`

### TracerList\<T\>

A `List<T>` that keeps track of the last element removed from it.

`public T LastDeletedItem { get; }`

`public int Count { get; }`

`public void Add(T item)`

`public void Remove(T item)`

`public T At(int index)`

`public void Clear()`

---

## Common/ExecutionControl

### DoOnce

Ensures that the provided action is executed only once, regardless of how many times the method is called. Not thread-safe.

`public DoOnce(Action action)`

`public void Execute()`

---

## EventSystems

### Reactive\<T\>

An observable container for a single value.

`public Reactive(T initialValue)`

`public void Register(Action<T> hook)`: Accepts a hook to call immediately, and on every subsequent value change.

`public void Unregister(Action<T> hook)`: Removes a registered hook.

`public T Get()`: Returns current value.

`public void Set(T value)`: Updates the value. Registered hooks fire only if the new value differs from the old one.

### ReactiveList\<T\>

An observable container for a list of values. Hooks receive an `EventData<T>` describing what changed.

```csharp
public enum ListOpType { Add, Remove, Update }

public struct EventData<T>
{
    public T Data;
    public ListOpType OpType;
    public int TargetIndex;
}
```

`public void Register(Action<EventData<T>> hook)`: Hook is called immediately for all existing elements (as `Add` events), then for every subsequent change.

`public void Unregister(Action<EventData<T>> hook)`

`public T At(int index)`

`public void Set(int index, T value)`

`public void Add(T value)`

`public void Remove(T value)`

`public void RemoveAt(int index)`

---

## Extensions

### CollectionExtensions

`public static void Shuffle<T>(this T[] array)`

`public static void Shuffle<T>(this List<T> list)`

`public static T Find<T>(this T[] array, Predicate<T> match)`

`public static T[] FindAll<T>(this T[] array, Predicate<T> match)`

### ColorExtensions

`public static Color MultiplyExceptAlpha(this Color sourceColor, float multiplier)`

`public static Color SubtractExceptAlpha(this Color sourceColor, Color other)`

`public static Color SetR(this Color color, float r)`

`public static Color SetG(this Color color, float g)`

`public static Color SetB(this Color color, float b)`

`public static Color SetA(this Color color, float a)`

### LogicExtensions

More of a syntactic sugar. Can help long list of combined condition checks be more readable.

`public static bool MultipleAnd(this bool[] arr)`

`public static bool MultipleOr(this bool[] arr)`

`public static bool MultipleAnd(this List<bool> list)`

`public static bool MultipleOr(this List<bool> list)`

### MaterialExtensions

`public static Material GetMaterial(this MeshRenderer mr)`: Returns `material` in play mode and `sharedMaterial` in edit mode, to avoid Unity's resource-leak warning when accessing `.material` outside of play mode.

### MathExtensions

`public static float AngleBetween(this Vector3 source, Vector3 other)`: Angle between two points, taking only the X and Z axes into account.

`public static float To2DecimalPlaces(this float input)`

`public static bool Equal(this float a, float b, float error)`: Equality comparison with a defined floating point error margin.

### PhysicsExtensions

Makes `Vector3`, `Vector2` and `Quaternion` modifications easier by allowing you to modify a single field without redeclaring the whole struct.

`public static Vector3 AddX(this Vector3 input, float amount)`

`public static Vector3 AddY(this Vector3 input, float amount)`

`public static Vector3 AddZ(this Vector3 input, float amount)`

`public static Vector3 SetX(this Vector3 input, float amount)`

`public static Vector3 SetY(this Vector3 input, float amount)`

`public static Vector3 SetZ(this Vector3 input, float amount)`

`public static Vector2 AddX(this Vector2 input, float amount)`

`public static Vector2 AddY(this Vector2 input, float amount)`

`public static Vector2 SetX(this Vector2 input, float amount)`

`public static Vector2 SetY(this Vector2 input, float amount)`

`public static Vector2 LimitMaxX(this Vector2 input, float max)`

`public static Vector2 LimitMinX(this Vector2 input, float min)`

`public static Vector3 LimitMaxX(this Vector3 input, float max)`

`public static Vector3 LimitMinX(this Vector3 input, float min)`

`public static Vector3 LimitMaxY(this Vector3 input, float max)`

`public static Vector3 LimitMinY(this Vector3 input, float min)`

`public static Vector3 LimitMaxZ(this Vector3 input, float max)`

`public static Vector3 LimitMinZ(this Vector3 input, float min)`

`public static Quaternion AddDegreesX(this Quaternion quaternion, float angles)`

`public static Quaternion AddDegreesY(this Quaternion quaternion, float angles)`

`public static Quaternion AddDegreesZ(this Quaternion quaternion, float angles)`

`public static bool MoveUntilNear(this Rigidbody rb, Vector3 target, float amount)`: Moves a `Rigidbody` forward (in its current facing direction) by `amount`, clamped so it doesn't overshoot `target` in the horizontal (XZ) plane. Returns `true` once the target has been reached.

---

## Editor Tooling

### ReadOnlyAttribute

`[ReadOnly]` attribute for fields. It renders the field normally but disabled, so its value is visible but not editable in the Inspector.

### TransformEditor

`R` button next to `Position`, `Rotation` and `Scale` fields of `Transform` to quickly reset them.
