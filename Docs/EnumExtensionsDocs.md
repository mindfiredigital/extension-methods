# Enum Extension Methods
This contains Extension Methods that deal with `enum`. You can check the examples below for more details.
Followings are the Methods available for public use.

- [EnumToList()](#enumtolist)
- [GetAttribute()](#getattribute)
- [ToDescription()](#todescription)
- [ToHumanCase()](#tohumancase)

## Api Reference Details

- ### EnumToList()
  Converts an Enum type to a sequence containing all its values.

```csharp
public static IEnumerable<T> EnumToList<T>();
```

#### Example

```csharp
    public enum UserRole
    {
        Admin = 1,
        Editor = 2,
        Viewer = 3
    }

    var all = Extension.Methods.EnumExtensions.EnumToList<UserRole>();
    // all => { UserRole.Admin, UserRole.Editor, UserRole.Viewer }
```

- ### GetAttribute()
  Fetches a custom attribute of a specific type applied to a given enum value. Returns null if not found.

```csharp
/// value : Enum value that may have an attribute of type T
public static T GetAttribute<T>(this Enum value) where T : Attribute;
```

#### Example

```csharp
    using System.ComponentModel;

    public enum Status
    {
        [Description("Work in progress")]
        InProgress = 1,

        [Description("Finished successfully")]
        Completed = 2,

        [Description("Stopped due to errors")]
        Failed = 3
    }

    var attr = Status.Completed.GetAttribute<DescriptionAttribute>();
    // attr.Description == "Finished successfully"
```

- ### ToDescription()
  Returns the value of the `DescriptionAttribute` if present on the enum value; otherwise, returns the enum value's name.

```csharp
/// value : Enum value possibly decorated with DescriptionAttribute
public static string ToDescription(this Enum value);
```

#### Example

```csharp
    using System.ComponentModel;

    public enum EnvironmentType
    {
        [Description("Development Environment")]
        Dev,

        [Description("Quality Assurance Environment")]
        Qa,

        Prod
    }

    var devDesc = EnvironmentType.Dev.ToDescription();   // "Development Environment"
    var prodDesc = EnvironmentType.Prod.ToDescription(); // "Prod" (no Description attribute present)
```

- ### ToHumanCase()
  Converts an enum value name from PascalCase/UpperCamelCase (and sequences of capitals/digits) into a spaced human readable string.

```csharp
/// e : Enum value whose name will be converted to human readable spaced text
public static string ToHumanCase(this Enum e);
```

#### Example

```csharp
    public enum UserAccessLevel
    {
        SuperAdmin,
        ReadOnly,
        HTTP2Enabled,
        V2API
    }

    var a = UserAccessLevel.SuperAdmin.ToHumanCase();  // "Super Admin"
    var b = UserAccessLevel.ReadOnly.ToHumanCase();    // "Read Only"
    var c = UserAccessLevel.HTTP2Enabled.ToHumanCase(); // "HTTP 2 Enabled"
    var d = UserAccessLevel.V2API.ToHumanCase();        // "V2 API"