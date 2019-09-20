# Generic Extension Methods
This contains Extension Methods that mostly deal with all kinds of data type (`T`). You can check the examples below for more details. 
Followings are the Methods available for public use. 

- [ForEach()](#foreach)

## Api Reference Details
* ### ForEach()
Itterates over any collection that implements IEnumerable
```csharp
/// source : The source.
/// action : The action.
public static void ForEach<T>(this IEnumerable<T> source, Action<T> action);
```
#### Example
```csharp
    //Example goes here.
```