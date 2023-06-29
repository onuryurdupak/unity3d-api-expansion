# Unity3D - API Expansion

#### DESCRIPTION:

Contains utilities not covered by the built-in engine API.

#### USAGE:

- Download the asset from releases page and import into your project.

- Scripts should compile and be ready for usage.

> **WARNING**: For ease of accessability `API Expansion` scripts are not put under any custom namespace by design (except contents of the Metadata.cs).
In case of class name collisions, scripts can be manually put into a namespace.

#### FEATURES:

**MonoBehaviourPlus:**

New base class to derive custom components from.

`public T CompCache<T>()`: Makes a GetComponent<T> call and caches the result for future reuse. Consequent calls for same type will return cached component instance.

`public T SceneCache<T>()`: Makes a FindObjectOfType<T> call and caches the result for future reuse. Consequent calls for same type will return cached component instance.

`protected Coroutine DoAfterFrames(int frameCount, Action action)`: Fires input action after input frame count has passed.

`protected Coroutine DoAfterDuration(float seconds, Action action)`: Fires input action after input time in seconds has passed.

`protected Coroutine DoPeriodically(float seconds, Action action)`: Fires input action periodically with input time in seconds interval.

`protected Coroutine DoWhen(Func<bool> condition, Action action)`: Fires input action when input condition returns true. Condition is checked per game frame.


**ReadOnlyArray\<T\>, ReadOnlyDictionary\<T1, T2\>:**

Provides read-only variant of array and dictionay types. Prevents tampering of internal data by means of assigning or updating values via keys or indices.

**Reference\<T\>:**

Allows passing any type of data as reference type (encapsulating input type in an object instance).
Can be a replacement for usage of `ref` keyword in some cases.

**ReadOnlyAttribute:**

Allows usage of `[ReadOnly]` attribute in scripts which will make fields read-only in Unity inspector.

**Reactive\<T\>, ReactiveList\<T\>:**

Enables having observable data containers.

`public void Register(Action<T> hook)`: Accepts a hook action to call when reactive changes.

`public void Unregister(Action<T> hook)`: Removes reference hook action from registered actions.

`public T Get()`: Returns current value of the reactive.

`public void Set(T value)`: Updates the value. Registered hooks are fired to notify value change.


`public T At(int index)`: (List only)

`public void Set(int index, T value)`: (List only)

`public void Add(T value)`: (List only): Operation triggers firing of registered hooks.

`public void Remove(T value)`: (List only) Operation triggers firing of registered hooks.

`public void RemoveAt(int index)`: (List only) Operation triggers firing of registered hooks.


**Extension Methods:**

`public static void Shuffle<T>(this T[] array)`

`public static void Shuffle<T>(this List<T> list)`

`public static Color MultiplyExceptAlpha(this Color sourceColor, float multiplier)`

`public static Color SubtractExceptAlpha(this Color sourceColor, Color other)`

---

More of syntactic sugar. Can help long list of combined condition checks be more readable.

`public static bool MultipleAnd(this bool[] arr)`

`public static bool MultipleOr(this bool[] arr)`

`public static bool MultipleAnd(this List<bool> list)`

`public static bool MultipleOr(this List<bool> list)`

---

`public static float AngleBetween(this Vector3 source, Vector3 other)`

`public static float To2DecimalPlaces(this float input)`

`public static bool Equal(this float a, float b, float error)`

---

Makes Vecto3, Vector2, Quaternion modifications easier by allowing you to modify single field without redeclaring the whole struct.

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

`public static Quaternion AddDegreesX(this Quaternion quaternion, float angles)`

`public static Quaternion AddDegreesY(this Quaternion quaternion, float angles)`

`public static Quaternion AddDegreesZ(this Quaternion quaternion, float angles)`

`public static bool MoveTowards(this Rigidbody rb, Vector3 target, float amount)`