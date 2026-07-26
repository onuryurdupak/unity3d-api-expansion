# Unity3D - API Expansion

#### DESCRIPTION:

A collection of small, self-contained utilities that fill in gaps in Unity's built-in engine API; execution control helpers, read-only and observable collections, Inspector tooling, and extension methods for common types like `Vector2`, `Vector3`, `Quaternion` and `Color`.

#### FEATURES:

**Execution control**

Run code after a delay, on a repeating interval, once a condition becomes true, or exactly once; without hand-writing a coroutine every time. See `MonoBehaviourPlus`, `DoOnce`.

**Read-only collections**

Wrap an array or dictionary so consumers can read but never mutate it after construction. See `ReadOnlyArray<T>`, `ReadOnlyDictionary<T1, T2>`.

**Reactive containers**

Observe a value or a list, and get notified on every change. See `Reactive<T>`, `ReactiveList<T>`.

**TracerList<T>**

A `List<T>` that remembers the last item removed from it.

**RollingStack<T>**

A capacity-bounded stack that evicts its oldest entry once full, instead of rejecting new pushes.


**Transform reset buttons**

Extends the built-in Transform inspector with a small `R` button next to Position, Rotation and Scale. Each button resets just that field to its default value.

**[ReadOnly] attribute**

Mark a field `[ReadOnly]` to have it shown, but disabled, in the Inspector.

**Extension methods**

Shuffle and search arrays/lists, tweak individual fields of `Vector2`/`Vector3`/`Quaternion` without rebuilding the whole struct, adjust `Color` channels, aggregate lists of `bool`, round/compare floats, and move a `Rigidbody` toward a target.

For every method signature, see [API_REFERENCE.md](API_REFERENCE.md).

#### USAGE:

- Download the asset from releases page and import into your project.

- Scripts should compile and be ready for usage.

> **WARNING**: For ease of accessability `API Expansion` scripts are not put under any custom namespace by design (except contents of the Metadata.cs).
In case of class name collisions, scripts can be manually put into a namespace.

#### DOCUMENTATION:

[API_REFERENCE.md](API_REFERENCE.md) documents every type and method exposed by this package, organized to match the source layout under `Assets/WF/APIExpansion`.
