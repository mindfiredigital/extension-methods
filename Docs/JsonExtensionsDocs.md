# JSON Extension Methods
This contains Extension Methods that mostly deal with JSON Data. You can check the examples below for more details. 
Followings are the Methods available for public use. 

- [JsonToObject()](#jsontoobject)

## Api Reference Details
* ### JsonToObject()
Converts a Json string to object of type T method applicable for multi hierarchy objects i.e having zero or many parent child relationships, Ignore loop references and do not serialize if cycles are detected.
```csharp
/// json : JSON String
public static T JsonToObject<T>(this string json);
```
#### Example
```csharp
    //Example goes here.
```