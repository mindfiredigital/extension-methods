# Extension.Methods

**Extension.Methods** is a C# library built on top of .Net Standard 2.0. This library contains most of the extension methods that you would use in everyday life. We are committed to adding new methods.

The reason why we started this project is very simple. Mostly to automate a redundant process. Each time we used to start a new project, we had to copy and paste these lines of codes to our project. Though most of the extension methods are available in the internet, they are not present under a single library. So we added everything to one place and created a package out of it. Adding this package to your existing/new project is as easy as adding any other NuGet package.

## Installation

The library is hosted on NuGet. You can install the same to your project using both Package Manager and .Net CLI. 

Installing **Extension.Methods** using [NuGet Package Manager Console](https://www.nuget.org/) 

    PM>Install-Package Extension.Methods

Installing **Extension.Methods** using [.Net CLI](https://dotnet.microsoft.com/download)

    >dotnet add package Extension.Methods

This will install the packages and its dependencies to your project and you can start using the methods just by importing the **Extension.Methods** namespace. 

## Example

```csharp
    using System;
    using System.Collections.Generic;
    using Extension.Methods; // This is important
    
    namespace YourProject.TestApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var l = new List<int>() { 1, 2, 4, 8, 5, 3 };
                l.Sort();
                l.InsertSorted(0); // You can use all the available extension methods like this.
                Console.ReadKey();
            }
        }
    }
```
    

## API References

The project contains extension methods for the followings. 

- [StringExtensions](#string-extensions)
- NumberExtensions
- DateTimeExtensions
- EnumExtensions
- JsonExtensions
- GenericExtensions

## String Extensions
* ### IsDateTime()
Checks if date string with dateFormat is parsable to ```System.DateTime``` format. True if is valid ```System.DateTime``` else returns false.
```csharp
/// data : datetime string
/// dateFormat : date format "dd/MM/yyyy" by default
public static bool IsDateTime(this string data, string dateFormat = "dd/MM/yyyy");
```
#### Example
```csharp
    var isDate = "09/10/2019".IsDateTime(); //Returns true.
    isDate = "11/28/2019".IsDateTime("MM/dd/yyyy"); // Returns false
    isDate = "11/28/2019".IsDateTime("dd/MM/yyyy"); // Returns false
```
* ### IsInteger()
Checks if a string is a valid int32 value. Returns true if the string is a valid Integer, else returns false.
```csharp
/// val : string value
public static bool IsInteger(this string val);
```
#### Example
```csharp
    var isNumber = "112".IsInteger(); //Returns true.
    isNumber = "-23".IsInteger(); // Returns true
    isNumber = "".IsInteger(); // Returns false
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
Please make sure to update tests as appropriate.

## License
Copyright (c) Swagat Swain. All rights reserved.

Licensed under the [MIT](https://choosealicense.com/licenses/mit/) license.
