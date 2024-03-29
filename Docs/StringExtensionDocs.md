# String Extension Methods
This contains Extension Methods that mostly deal with strings. You can check the examples below for more details. 
Followings are the Methods available for public use. 

- [IsNull()](#isnull)
- [IsNullOrEmpty()](#isnullorempty)
- [IsNullOrWhiteSpace()](#isnullorwhitespace)
- [IsDateTime()](#isdateTime)
- [IsInteger()](#isinteger)
- [IsDecimal()](#isdecimal)
- [IsNumeric()](#isnumeric)
- [IsGuid()](#isguid)
- [IsAlpha()](#isalpha)
- [IsAlphaNumeric()](#isalphanumeric)
- [IsEmailAddress()](#isemailaddress)
- [IsIPv4()](#isipv4)
- [IsMatch()](#ismatch)
- [ToCSVString()](#tocsvstring)
- [SplitTo()](#splitto)
- [ToBoolean()](#toboolean)
- [ToEnum()](#toenum)
- [GetNullIfEmptyString()](#getnullifemptystring)
- [FirstCharacter()](#firstcharacter)
- [LastCharacter()](#lastcharacter)
- [EndsWithIgnoreCase()](#endswithignorecase)
- [StartsWithIgnoreCase()](#startswithignorecase)
- [Capitalize()](#capitalize)
- [RemoveChars()](#removechars)
- [RemoveCharsIgnoreCase()](#removecharsignorecase)
- [RemoveString()](#removestring)
- [RemoveStringIgnoreCase()](#removestringignorecase)
- [Reverse()](#reverse)
- [ParseToCsv()](#parsetocsv)
- [CountOccurrences()](#countoccurrences)
- [CountOccurrencesIgnoreCase()](#countoccurrencesignorecase)
- [RemovePrefix()](#removeprefix)
- [RemoveSuffix()](#removesuffix)
- [AppendPrefixIfMissing()](#appendprefixifmissing)
- [AppendSuffixIfMissing()](#appendsuffixifmissing)
- [Left()](#left)
- [Right()](#right)
- [IsMinLength()](#isminlength)
- [IsMaxLength()](#ismaxlength)
- [IsBetweenLength()](#isbetweenlength)
- [SplitCamelCase()](#splitcamelcase)
- [ToHumanCase()](#tohumancase)
- [ToTitleCase()](#totitlecase)
- [Truncate()](#truncate)
- [Encrypt()](#encrypt)
- [Decrypt()](#decrypt)
- [RemoveLineFeeds()](#removelinefeeds)
- [DoesNotStartWith()](#doesnotstartwith)
- [DoesNotEndWith()](#doesnotendwith)
- [CreateHashSha512()](#createhashsha512)
- [CreateHashSha256()](#createhashsha256)
- [ToBytes()](#tobytes)
- [In()](#in)
- [InWithIgnoreCase()](#inwithignorecase)
- [SeoFriendlyURL()](#seofriendlyurl)
- [Format()](#format)
- [GetOnlyDigits()](#getonlydigits)
- [MaskEmail()](#maskemail)
- [MaskPhoneNumber()](#maskphonenumber)
- [ToPhoneNumber()](#tophonenumber)
- [ToColor()](#tocolor)
- [WordCount()](#wordcount)
- [NthIndexOf()](#nthindexof)

## Api Reference Details

* ### IsNull()
Checks if a string is null
```csharp
/// var : The input String
public static bool IsNull(this string val);
```
#### Example
```csharp
    var bar = "Swag".IsNull(); //Returns false
    var bar = "".IsNull(); //Returns false

    string bar=null;
    bar.IsNull();//Returns true
```

* ### IsNullOrEmpty()
Checks if a string is null or empty
```csharp
/// var : The input String
public static bool IsNullOrEmpty(this string val);
```
#### Example
```csharp
    var bar = "Swag".IsNullOrEmpty(); //Returns false
    var bar = "".IsNullOrEmpty(); //Returns true

    string bar=null;
    bar.IsNullOrEmpty();//Returns true
```
* ### IsNullOrWhiteSpace()
Checks if a string is null or whitespace
```csharp
/// var : The input String
public static bool IsNullOrWhiteSpace(this string val);
```
#### Example
```csharp
    var bar = "Swag".IsNullOrWhiteSpace(); //Returns false
    var bar = "".IsNullOrWhiteSpace(); //Returns true
    var bar = "     ".IsNullOrWhiteSpace(); //Returns true

    string bar=null;
    bar.IsNullOrWhiteSpace();//Returns true
```


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
    isDate = "11/28/2019".IsDateTime("MM/dd/yyyy"); // Returns true
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
* ### IsDecimal()
Checks if a string is a valid decimal value. Returns true if the string is a valid decimal, else returns false.
```csharp
/// val : string value
public static bool IsDecimal(this string val);
```
#### Example
```csharp
    var isDecimal = "-112.0".IsDecimal(); //Returns true.
    isDecimal = "112".IsDecimal(); // Returns true
    isDecimal = "".IsDecimal(); // Returns false
```
* ### IsNumeric()
Checks if a string is a valid floating value. Returns true if the string is a valid floating, else returns false.
```csharp
/// val : string value
public static bool IsNumeric(this string val);
```
#### Example
```csharp
    var isNumeric = "-112.0".IsNumeric(); //Returns true.
    isNumeric = "112".IsNumeric(); // Returns true
    isNumeric = "".IsNumeric(); // Returns false
```
* ### IsGuid()
Checks if a string is a valid Guid value. Returns true if the string is a valid Guid, else returns false.
```csharp
/// val : string value
public static bool IsGuid(this string val);
```
#### Example
```csharp
    var isGuid = "ABCDER".IsGuid(); //Returns False.
    isGuid = "7FB05CF8-1D45-4935-81C0-A4DD22264C34".IsGuid(); // Returns true
    isGuid = "A005041CCCFF4D349AA0FF48F384A0D3".IsGuid(); // Returns true
```
* ### IsAlpha()
Checks if the String contains only Unicode letters. ```null``` will return false. An empty String ("") will return false.
```csharp
/// val : string value
public static bool IsAlpha(this string val);
```
#### Example
```csharp
    var isAlpha = "Abc Das".IsAlpha(); //Returns true.
    isAlpha = "Abc90Das".IsAlpha(); // Returns false
    isAlpha = "Abc$#3Das".IsAlpha(); // Returns false
```
* ### IsAlphaNumeric()
Checks if the String contains only Unicode letters, digits. ```null``` will return false. An empty String ("") will return false.
```csharp
/// val : string value
public static bool IsAlphaNumeric(this string val);
```
#### Example
```csharp
    var isAlphaNumeric = "Abc Das".IsAlphaNumeric(); //Returns true.
    isAlphaNumeric = "1234".IsAlphaNumeric(); //Returns true.
    isAlphaNumeric = "Abc90Das".IsAlphaNumeric(); // Returns true
    isAlphaNumeric = "Abc90DasA#$".IsAlphaNumeric(); // Returns false
```
* ### IsEmailAddress()
Validates email address. Returns true, if a given string is a valid email address. Else returns false.
```csharp
/// val : string value
public static bool IsEmailAddress(this string val);
```
#### Example
```csharp
    var isEmail = "abc@gmail.com".IsEmailAddress(); //Returns true.
    isEmail = "1234".IsEmailAddress(); //Returns false.
    isEmail = "23@gmail.com".IsEmailAddress(); // Returns false
    isEmail = "23+12@gmail.co.in.com".IsEmailAddress(); // Returns false
```
* ### IsIPv4()
Validates if a string is valid IPv4 Returns true, if a given string is a valid IP. Else returns false.
```csharp
/// val : string value
public static bool IsIPv4(this string val);
```
#### Example
```csharp
    var isIpV4 = "1.1.1.1".IsIPv4(); //Returns true.
    isIpV4 = ".1.1".IsIPv4(); //Returns false.
    isIpV4 = "23@gmail.com".IsIPv4(); // Returns false
    isIpV4 = "192.168.1.1".IsIPv4(); // Returns true
```
* ### IsMatch()
Determines whether the specified string matches a regular expression or not. Returns true if the regex matches, else returns false.
```csharp
/// val : string value
/// regEx : The reg ex.
public static bool IsMatch(this string content, string regEx);
```
#### Example
```csharp
    var isRegexMatch = "ssswagatss@gmail.com".IsMatch("^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$"); //Returns true.
    isRegexMatch = "ssswagatss+09@gmail.com".IsMatch("^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$"); //Returns false.
```
* ### IsUrl()
Determines whether this string is URL. Returns true if URL, else returns false.
```csharp
/// val : string value
public static bool IsUrl(this string val);
```
#### Example
```csharp
    var isUrl = "http://google.com".IsUrl(); //Returns true.
    isUrl = "http://go ogle.com".IsUrl(); //Returns false.
    isUrl = "http://google.com/abc-ght?url=bar".IsUrl(); //Returns true.
```
* ### ToCSVString()
Converts an object to CSV String separated by a Separator.
```csharp
/// val : string value
/// separator : string separator, be default it separates with comma.
public static string ToCSVString(this object obj, string separator = ",");
```
#### Example
```csharp
    var user = new TestUser { Id = 1, Name = "Extension Methods", Age = 18 };
    var csv =user.ToCSVString(); //Returns "1,Extension Methods,18"
    csv =user.ToCSVString("|"); //Returns "1|Extension Methods|18"
```
* ### SplitTo()
Returns an enumerable collection of the specified type containing the substrings in this instance that are delimited by elements of a specified Char array
```csharp
/// val : string value
/// separator : An array of Unicode characters that delimit the substrings in this instance, an empty array containing no delimiters, or null
public static IEnumerable<T> SplitTo<T>(this string val, params char[] separator) where T : IConvertible ;
```
#### Example
```csharp
    var bar = "23,34,56,-2,33,100";
    var foo = bar.SplitTo<int>(',').ToArray();  //Returns new int[] { 23, 34, 56, -2, 33, 100 };
```
There is one more overloaded method of `Split()` that Returns an enumerable collection of the specified type containing the substrings in this instance that are delimited by elements of a specified Char array, but this time it does so taking the `StringSplitOptions` into consideration.
```csharp
/// val : string value
/// options : Represents StringSplitOptions like 'RemoveEmptyEntries' or 'None'
/// separator : An array of Unicode characters that delimit the substrings in this instance, an empty array containing no delimiters, or null
public static IEnumerable<T> SplitTo<T>(this string val, StringSplitOptions options, params char[] separator) where T : IConvertible;
```
#### Example
```csharp
    var bar = "23,34,,56,,-2,33,100";
    var foo = bar.SplitTo<int>(StringSplitOptions.RemoveEmptyEntries, ',').ToArray(); //Returns new int[] { 23, 34, 56, -2, 33, 100 };
```
* ### ToBoolean()
Converts string to its boolean equivalent. This checks ignoring cases and trimming the string.
```csharp
/// val : string value
public static bool ToBoolean(this string val);
```
#### Example
```csharp
    "false".ToBoolean(); //Returns false
    "f".ToBoolean(); //Returns false
    "n".ToBoolean(); //Returns false
    "no".ToBoolean(); //Returns false
    "False".ToBoolean(); //Returns false
    "True".ToBoolean(); //Returns true
    "True".ToBoolean(); //Returns true
    "Yes".ToBoolean(); //Returns true
    "y".ToBoolean(); //Returns true
```
* ### ToEnum()
Converts string to its Enum type. Checks of string is a member of type `T` enum before converting. If fails returns `default enum`
```csharp
/// val : string value
/// defaultValue : The default value of Type T
/// ignoreCase :  Indicates whether the compare should ignore case
public static T ToEnum<T>(this string val, T defaultValue = default(T), bool ignoreCase = false) where T : struct;
```
#### Example
```csharp
    public enum TestEnums
    {
        Admin = 1,
        PublicUser = 2,
        Supervisor = 3
    }
    
    "1".ToEnum<TestEnums>(); //Returns TestEnums.Admin
    "2".ToEnum<TestEnums>(); //Returns TestEnums.PublicUser
```
* ### GetNullIfEmptyString()
Checks if a string is Null or EmptyString (`string.Empty`), retuns NULL if the string is NULL or Empty and returns the same string if Not.
```csharp
/// val : string value
public static string GetNullIfEmptyString(this string val);
```
#### Example
```csharp
    var bar = " Swagat ".GetNullIfEmptyString(); //Returns Swagat
    bar = "".GetNullIfEmptyString(); //Returns null
```
* ### FirstCharacter()
 Gets first character in string
```csharp
/// val : string value
public static string FirstCharacter(this string val);
```
#### Example
```csharp
    var bar = "Royal College".FirstCharacter(); //Returns R
```
* ### LastCharacter()
 Gets Last character in string
```csharp
/// val : string value
public static string LastCharacter(this string val);
```
#### Example
```csharp
    var bar = "Royal College".LastCharacter(); //Returns e
```
* ### EndsWithIgnoreCase()
 Checks a String ends with another sub-string ignoring the case. If it does, returns true, else returns false.
```csharp
/// val : string value
public static bool EndsWithIgnoreCase(this string val, string suffix);
```
#### Example
```csharp
    var bar = "Royal College".EndsWithIgnoreCase("Ege"); //Returns true
```
* ### StartsWithIgnoreCase()
 Checks a String Starts with another sub-string ignoring the case. If it does, returns true, else returns false.
```csharp
/// val : string value
public static bool StartsWithIgnoreCase(this string val, string suffix);
```
#### Example
```csharp
    var bar = "Royal College".StartsWithIgnoreCase("royal"); //Returns true
    var bar = "Royal College".StartsWithIgnoreCase("College"); //Returns false
```

* ### Capitalize()
 Read in a sequence of words from standard input and capitalize each one (make first letter uppercase; make rest lowercase).
```csharp
/// s : string value
public static string Capitalize(this string s);
```
#### Example
```csharp
    var bar = "swagat".StartsWithIgnoreCase("Swagat"); //Returns true
    var bar = "swagat kumar swain".StartsWithIgnoreCase("Swagat kumar swain"); //Returns true
```

* ### RemoveChars()
 Replace specified characters with an empty string without ignoring the cases.
```csharp
/// s : string to remove characters from
/// chars : array of characters that are to be removed
public static string RemoveChars(this string s, params char[] chars);
```
#### Example
```csharp
    var bar = "swagat swain".RemoveChars("s","w","a","i","n"); //Returns "gt "
```

* ### RemoveCharsIgnoreCase()
 Replace specified characters with an empty string ignoring the cases.
```csharp
/// s : string to remove characters from
/// chars : array of characters that are to be removed
public static string RemoveCharsIgnoreCase(this string s, params char[] chars);
```
#### Example
```csharp
    string s = "Friends";
    s = s.Replace('f', 'r','i','s');// s becomes 'end'
```

* ### RemoveString()
 Remove string from string.
```csharp
/// s : string to remove characters from
/// replaceString : String  to be removed
public static string RemoveString(this string s, string replaceString);
```
#### Example
```csharp
    string s = "C# is hot".RemoveString("ho");//Returns 'C# is t'
```

* ### RemoveStringIgnoreCase()
 Remove string from string ignoring the case
```csharp
/// s : string to remove characters from
/// replaceString : String  to be removed
public static string RemoveString(this string s, string replaceString);
```
#### Example
```csharp
    string s = "C# is hot".RemoveString("HO");//Returns 'C# is t'
```

* ### Reverse()
 Reverse a given string
```csharp
/// val : string to be reversed
public static string Reverse(this string val);
```
#### Example
```csharp
    string s = "C# is hot".Reverse("HO");//Returns 'toh si #C'
```

* ### ParseToCsv()
 Appends String quotes for type CSV data
```csharp
/// val : string to be converted into CSV string
public static string ParseToCsv(this string val);
```
#### Example
```csharp
    string s = "C# is hot".ParseToCsv();//Returns "C# is hot" (With Quotes)
```

* ### CountOccurrences()
 Count number of occurrences in string
```csharp
/// val : string containing text
/// stringToMatch : string or pattern find
public static int CountOccurrences(this string val, string stringToMatch);
```
#### Example
```csharp
    "Mahesh Chand is a founder of C# CornerMahesh Chand is a founder of C# Corner".CountOccurrences("mahesh");// Returns 0
    "Mahesh Chand is a founder of C# CornerMahesh Chand is a founder of C# Corner".CountOccurrences("Mahesh");// Returns 2
```

* ### CountOccurrencesIgnoreCase()
 Count number of occurrences in string ignoring Case
```csharp
/// val : string containing text
/// stringToMatch : string or pattern find
public static int CountOccurrencesIgnoreCase(this string val, string stringToMatch);
```
#### Example
```csharp
    "Mahesh Chand is a founder of C# CornerMahesh Chand is a founder of C# Corner".CountOccurrences("mahesh");// Returns 0
    "Mahesh Chand is a founder of C# CornerMahesh Chand is a founder of C# Corner".CountOccurrences("Mahesh");// Returns 2
```

* ### RemovePrefix()
 Removes the first part of the string, if no match found return original string
```csharp
/// val : string to remove prefix
/// prefix : prefix
/// ignoreCase : Indicates whether the compare should ignore case
public static string RemovePrefix(this string val, string prefix, bool ignoreCase = true);
```
#### Example
```csharp
    "Swagat Kumar Swain".RemovePrefix("Swa",true);// Returns 'gat Kumar Swain'
    "Swagat Kumar Swain".RemovePrefix("swa",false);// Returns 'Swagat Kumar Swain'
```

* ### RemoveSuffix()
 Removes the first part of the string, if no match found return original string
```csharp
/// val : string to remove suffix
/// suffix : suffix
/// ignoreCase : Indicates whether the compare should ignore case
public static string RemoveSuffix(this string val, string suffix, bool ignoreCase = true);
```
#### Example
```csharp
    "Swagat Kumar Swain".RemovePrefix("Swa",true);// Returns 'Swagat Kumar Swain'
    "Swagat Kumar Swain".RemovePrefix("Swain",false);// Returns 'Swagat Kumar '
```

* ### AppendPrefixIfMissing()
 Appends the prefix to the start of the string if the string does not already start with prefix.
```csharp
/// val : string to append prefix
/// prefix : prefix
/// ignoreCase : Indicates whether the compare should ignore case
public static string AppendPrefixIfMissing(this string val, string prefix, bool ignoreCase = true);
```
#### Example
```csharp
    "Swagat Kumar".AppendPrefixIfMissing("Swagat",true);// Returns 'Swagat Kumar'
    "Swagat Kumar Swain".AppendPrefixIfMissing("swain",false);// Returns 'swagatSwagat Kumar Swain'
```

* ### AppendSuffixIfMissing()
 Appends the prefix to the start of the string if the string does not already start with prefix.
```csharp
/// val : string to append suffix
/// suffix : suffix
/// ignoreCase : Indicates whether the compare should ignore case
public static string AppendSuffixIfMissing(this string val, string suffix, bool ignoreCase = true);
```
#### Example
```csharp
    "Swagat Kumar".AppendSuffixIfMissing(" ,Swain",true);// Returns 'Swagat Kumar ,Swain'
    "Swagat Kumar Swain".AppendSuffixIfMissing("Swain",false);// Returns 'Swagat Kumar Swain'
```

* ### Left()
 Extracts the Left part of the input string limited with the length parameter
```csharp
/// val : The input string to take the Left part from
/// length : The total number characters to take from the input string
public static string Left(this string val, int length);
```
#### Example
```csharp
    "Swagat Kumar Swain".Left(8);// Returns 'Swagat K'
    "Swagat Kumar Swain".Left(0);// Returns ''
```

* ### Right()
 Extracts the right part of the input string limited with the length parameter
```csharp
/// val : The input string to take the right part from
/// length : The total number characters to take from the input string
public static string Right(this string val, int length);
```
#### Example
```csharp
    "Swagat Kumar Swain".Right(8);// Returns 'ar Swain'
    "Swagat Kumar Swain".Right(2);// Returns 'in'
```


* ### IsMinLength()
 Checks if string length is a certain minimum number of characters, does not ignore leading and trailing white-space. null strings will always evaluate to false.
```csharp
/// val : string to evaluate minimum length
/// minCharLength : minimum allowable string length
public static bool IsMinLength(this string val, int minCharLength);
```
#### Example
```csharp
    "Swag".IsMinLength(5);// Returns false
    "".IsMinLength(2);// Returns true
```

* ### IsMaxLength()
 Checks if string length is a certain maximum number of characters, does not ignore leading and trailing white-space. null strings will always evaluate to false.
```csharp
/// val : string to evaluate maximum length
/// maxCharLength : maximum allowable string length
public static bool IsMaxLength(this string val, int maxCharLength);
```
#### Example
```csharp
    "Swag".IsMaxLength(5);// Returns true
    "".IsMaxLength(2);// Returns false
```


* ### IsBetweenLength()
 Checks if string length is a certain maximum and minimum number of characters, does not ignore leading and trailing white-space. null strings will always evaluate to false.
```csharp
/// val : string to evaluate
/// minCharLength : minimum allowable string length
/// maxCharLength : maximum allowable string length
public static bool IsBetweenLength(this string val, int minCharLength, int maxCharLength);
```
#### Example
```csharp
    "Swag".IsBetweenLength(2, 5);// Returns true
    "Swag  t".IsBetweenLength(2, 5);// Returns false
```

* ### SplitCamelCase()
 Checks if string length satisfies minimum and maximum allowable char length. does not ignore leading and trailing white-space
```csharp
/// source : The camelcase string
public static IEnumerable<string> SplitCamelCase(this string source);
```
#### Example
```csharp
    var bar = "SwagatKumarSwain".SplitCamelCase();// Returns 'Swagat' 'Kumar' 'Swain' 
    "FirstName".SplitCamelCase(); // Returns 'First' 'Name' 
```

* ### ToHumanCase()
 Converts to humancase. If the input is "FirstName", It will return "First Name"
```csharp
/// source : the given string
public static string ToHumanCase(this string source);
```
#### Example
```csharp
    var bar = "SwagatKumarSwain".ToHumanCase();// Returns 'Swagat Kumar Swain' 
    "FirstName".SplitCamelCase(); // Returns 'First Name' 
```

* ### ToTitleCase()
Converts a string to Title Case
```csharp
/// source : the given string
public static string ToTitleCase(this string source);
```
#### Example
```csharp
    var bar = "my Name is Swagat swain".ToTitleCase();// Returns 'My Name Is Swagat Swain' 
    "tHiS is a sTring TesT".SplitCamelCase(); // Returns 'This Is A String Test' 
```

* ### Truncate()
Truncates a string to the specified maximum length.
```csharp
/// value : the given string
/// maxLength : The maximum length
public static string Truncate(this string value, int maxLength);
```
#### Example
```csharp
    var bar = "FirstName".Truncate(4);// Returns 'Firs' 
    var bar = "FirstName".Truncate(0);// Returns '' 
```

* ### Encrypt()
Encrypt a string using the supplied key. Encoding is done using RSA encryption.
```csharp
/// stringToEncrypt : the given string to encrypt
/// key : Encryption key
public static string Encrypt(this string stringToEncrypt, string key);
```
#### Example
```csharp
    var bar = "C#Extension Methods".Encrypt("myEncryptionKey");//Returns back the encrypted string
```

* ### Decrypt()
Decrypt a string using the supplied key. Decoding is done using RSA encryption.
```csharp
/// stringToDecrypt : the given string to encrypt
/// key : Encryption key
public static string Decrypt(this string stringToDecrypt, string key);
```
#### Example
```csharp
    var bar = "BB-AA-CC".Encrypt("myEncryptionKey");//Returns back original string
```


* ### QueryStringToDictionary()
Convert url query string to IDictionary value key pair
```csharp
/// queryString : The url or the pary of querystring starting with ?
public static IDictionary<string, string> QueryStringToDictionary(this string queryString);
```
#### Example
```csharp
    var bar = "https://abc.com/?name=swagat&page=12";
    bar.QueryStringToDictionary(); 
    //Returns Dictionary<string,string> with 
    //key = name, value = swagat
    //key = page, value = 12

     var foo = "?name=swagat&page=12";
    foo.QueryStringToDictionary(); 
    //Returns Dictionary<string,string> with 
    //key = name, value = swagat
    //key = page, value = 12
```

* ### RemoveLineFeeds()
 Remove Line Feeds
```csharp
/// val : The given string
public static string RemoveLineFeeds(this string val);
```
#### Example
```csharp
    var bar = "https://abc.com/?name=swagat&page=12";
    bar.RemoveLineFeeds(); //Removes linefeed from string.
```

* ### DoesNotStartWith()
 Remove Line Feeds
```csharp
/// val : The given string
/// prefix : The string which is to be measured.
/// ignoreCase :  Indicates whether the compare should ignore case
public static bool DoesNotStartWith(this string val, string prefix, bool ignoreCase = false)
```
#### Example
```csharp
    var bar = "C# is am amazing language";
    bar.DoesNotStartWith("c#",true); //Returns true
```

* ### DoesNotEndWith()
 Remove Line Feeds
```csharp
/// val : The given string
/// suffix : The string which is to be measured.
/// ignoreCase :  Indicates whether the compare should ignore case
public static bool DoesNotEndWith(this string val, string suffix, bool ignoreCase = false);
```
#### Example
```csharp
    var bar = "C# is am amazing language";
    bar.DoesNotEndWith("c#",true); //Returns false
```

* ### CreateHashSha512()
 Convert string to Hash using Sha512
```csharp
/// val : string to hash
public static string CreateHashSha512(this string val);
```
#### Example
```csharp
    var password = "YourPassword";
    password.CreateHashSha512(); //Returns Hashed string
```

* ### CreateHashSha256()
 Convert string to Hash using Sha256
```csharp
/// val : string to hash
public static string CreateHashSha256(this string val);
```
#### Example
```csharp
    var password = "YourPassword";
    password.CreateHashSha256(); //Returns Hashed string
```

* ### ToBytes()
 Convert a string to its equivalent byte array
```csharp
/// val : the given string
public static string ToBytes(this string val);
```
#### Example
```csharp
    var bar = "C# is an amazing Language".ToBytes();
```

* ### In()
 Checks string object's value to array of string values, does not ignore case sensitivity
```csharp
/// value : the given string
/// stringValues : Comma separates strings withing which the given string is to be searched for
public static bool In(this string value, params string[] stringValues);
```
#### Example
```csharp
    var bar = "Cuttack".In("Cuttack","Bhubaneswar","Jajpur");//Returns true
    var bar = "Puri".In("Cuttack","Bhubaneswar","Jajpur");//Returns false
````

* ### InWithIgnoreCase()
 Checks string object's value to array of string values, ignores case sensitivity
```csharp
/// value : the given string
/// stringValues : Comma separates strings withing which the given string is to be searched for
public static bool InWithIgnoreCase(this string value, params string[] stringValues);
```
#### Example
```csharp
    var bar = "cuttack".InWithIgnoreCase("Cuttack","Bhubaneswar","Jajpur");//Returns true
    var bar = "Puri".InWithIgnoreCase("Cuttack","Bhubaneswar","Jajpur");//Returns false
```

* ### SeoFriendlyURL()
 Converts a string to a SEO friendly URL.
```csharp
/// title : URL string
/// maxLength : Maximum allowed length of the URL
public static string SeoFriendlyURL(this string title, int maxLength);
```
#### Example
```csharp
    var bar = "C# is my favourite Language";
    bar.SeoFriendlyURL(255);//Returns 'c-sharp-is-my-favourite-language'

    bar = "10 reasons why we waste time on people & emotions";
    bar.SeoFriendlyURL(255);//Returns '10-reasons-why-we-waste-time-on-people-emotions'
```


* ### Format()
 Replaces the format item in a specified string with the string representation of a corresponding object in a specified object or array.
```csharp
/// value : A composite format string
/// arg0 : An System.Object to format
public static string Format(this string value, object arg0);


/// value :A composite format string
/// args : An object array that contains zero or more objects to format
public static string Format(this string value, params object[] args)
```
#### Example
```csharp
    var bar ="My name is {0}".Format("Swagat"); //Returns "My Name is Swagat"
    bar = "{0} is my favourite {1}".Format("C#","Language");//Returns "C# is my favourite Language"
```

* ### GetOnlyDigits()
 Gets the only digits from a specified string. If the string is "123-12-1234", returns "123121234".
```csharp
/// value : A given string
public static string GetOnlyDigits(this string value);
```
#### Example
```csharp
    var bar ="123-12-1234".GetOnlyDigits(); //Returns "123121234"
    bar ="Hello #@45 World".GetOnlyDigits(); //Returns "45"
```

* ### MaskEmail()
 Masks the email string. If an email address is "abc@gmail.com", the output is a#c@g####.com
```csharp
/// emailAddress :The email address
/// maskChar : The mask character, "*" by default
public static string MaskEmail(this string emailAddress, char maskChar = '*');
```
#### Example
```csharp
    var bar ="youremail@gmail.com".MaskEmail(); //Returns "y*******l@g****.com"
    bar ="ail@yahoo.com".MaskEmail('*'); //Returns "*@*.*"
```

* ### MaskPhoneNumber()
 Masks the email string. If an email address is "abc@gmail.com", the output is a#c@g####.com
```csharp
/// phoneNumber :The phone number
/// maskChar : The mask character, "*" by default
public static string MaskPhoneNumber(this string phoneNumber, char maskChar = '*');
```
#### Example
```csharp
    var bar ="(800) 555-1212".MaskPhoneNumber(); //Returns "(###) ###-1212"
    bar ="1234561111".MaskPhoneNumber('*'); //Returns "######1111"
```

* ### ToPhoneNumber()
 Transforms a string to phone number If a phone number is "1234567890", then the formatted string will be "(123) 456-7890"
```csharp
/// phoneNumber :The phone number
public static string ToPhoneNumber(this string phoneNumber);
```
#### Example
```csharp
    var bar ="1234567890".MaskPhoneNumber(); //Returns "(123) 456-7890"
```

* ### ToColor()
 Convert a (A)RGB string to a Color object
```csharp
/// argb : An RGB or an ARGB string
public static Color ToColor(this string argb);
```
#### Example
```csharp
    Color bar ="ffffcc88".ToColor();
```

* ### WordCount()
 Count all words in a given string excluding white spaces, tabs, line breaks
```csharp
/// input : string to begin with
public static int WordCount(this string input);
```
#### Example
```csharp
    Color bar ="the quick brown\r\nfox jumps over the lazy \tdog.".WordCount();//Returns 9
```

* ### NthIndexOf()
 Finds the index of the nth occurrence of a string in a string
```csharp
/// input : string to begin with
/// stringToBeFound : string whose index is to be found
/// occurrence : occurrence
public static int NthIndexOf(this string input, string stringToBeFound, int occurrence);
```
#### Example
```csharp
    var bar ="Emad Alashi found ash on his desk, he went mad, very mad".NthIndexOf("mad",2);//Returns 43
```
