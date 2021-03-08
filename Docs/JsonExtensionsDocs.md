# JSON Extension Methods

This contains Extension Methods that mostly deal with JSON Data. You can check the examples below for more details.
Followings are the Methods available for public use.

- [JsonToObject()](#jsontoobject)

## Api Reference Details

- ### JsonToObject()
  Converts a Json string to object of type T method applicable for multi hierarchy objects i.e having zero or many parent child relationships, Ignore loop references and do not serialize if cycles are detected.

```csharp
/// json : JSON String
public static T JsonToObject<T>(this string json);
```

#### Example

```csharp
    public class Bar
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    //Your code

    var jsonString = "{\"FirstName\":\"Swagat\",\"LastName\":\"Swain\",\"Age\":29}";
    var bar = jsonString.JsonToObject<Bar>();
```

- ### ToJson()
  Converts an object of type T to Json String. Method applicable for multi hierarchy objects i.e having zero or many parent child relationships, Ignore loop references and do not serialize if cycles are detected.

```csharp
/// obj : C# object
public static string ToJson<T>(this T obj);
```

#### Example

```csharp
    public class Bar
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    //Your code

    var obj = new Bar()
    {
        FirstName = "Swagat",
        LastName = "Swain",
        Age = 29
    };
    var jsonString = obj.ToJson();//Output - "{\"FirstName\":\"Swagat\",\"LastName\":\"Swain\",\"Age\":29}"
```

- ### JsonToDictionary()
  Converts a Json string to dictionary object method applicable for single hierarchy objects i.e no parent child relationships, for parent child relationships

```csharp
/// val : JSON String
public static IDictionary<string, object> JsonToDictionary(this string val);
```

#### Example

```csharp

    //Your code

    var jsonString = "{\"FirstName\":\"Swagat\",\"LastName\":\"Swain\",\"Age\":29}";
    var foo = jsonString.JsonToDictionary();
    //Outputs : Key - FirstName, Value - Swagat
    //          Key - LastName, Value - Swain
    //          Key - Age, Value - 29
```
