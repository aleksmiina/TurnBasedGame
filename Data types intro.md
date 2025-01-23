# Data types intro

According to the Copilot:


### Primitives
In C#, primitive data types are the most basic types. They hold simple values and are predefined by the language. Here are some key primitive data types you'll likely encounter:

1. **int**: Represents a 32-bit integer. Example: `int age = 25;`
2. **float**: Represents a single-precision floating point. Example: `float height = 1.75f;`
3. **double**: Represents a double-precision floating point. Example: `double distance = 123.45;`
4. **char**: Represents a single 16-bit Unicode character. Example: `char initial = 'A';`
5. **bool**: Represents a Boolean value (true or false). Example: `bool isActive = true;`
6. **byte**: Represents an 8-bit unsigned integer. Example: `byte level = 255;`
7. **short**: Represents a 16-bit integer. Example: `short count = 30000;`
8. **long**: Represents a 64-bit integer. Example: `long population = 7500000000L;`
9. **decimal**: Represents a 128-bit precise decimal value, usually used for financial calculations. Example: `decimal price = 99.99m;`

### Other Data Types
In addition to primitive data types, C# has several other data types that are also important:

1. **String**: Represents a sequence of characters. Strings in C# are immutable. Example: `string name = "Alice";`
2. **Array**: Represents a collection of items of the same type. Example: `int[] numbers = {1, 2, 3, 4, 5};`
3. **List<T>**: Represents a list of items of type T (generic). Example: `List<int> scores = new List<int> {90, 85, 70};`
4. **Dictionary<TKey, TValue>**: Represents a collection of key-value pairs. Example: `Dictionary<string, int> ages = new Dictionary<string, int> { {"Alice", 30}, {"Bob", 25} };`
5. **enum**: Represents a set of named constants. Example: 
```csharp
enum Days { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };
Days today = Days.Wednesday;
```
6. **Struct**: A value type that can contain data and methods. Useful for representing lightweight objects. Example:
```csharp
struct Point 
{
    public int x;
    public int y;
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
```
7. **Class**: Represents a reference type that can contain data and methods. Used to create objects. Example:
```csharp
class Person 
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Person(string name, int age) 
    {
        Name = name;
        Age = age;
    }
}
```

Understanding these data types will help you handle data more efficiently and write robust C# applications. If you need any specific examples or more detailed explanations on any of these, just let me know!