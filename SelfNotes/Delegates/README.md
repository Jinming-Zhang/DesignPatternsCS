# Some Notes while learning Delegate concept in C [(Docs)](https://docs.microsoft.com/en-us/dotnet/csharp/delegates-overview)

delegate is a type in C#. Think of it as a class which can hold a set of functions with certain signatures. The signature of functions should match what was declared when creating the corresponding delegate. Example to create a delegate type:

```cs
public delegate int Comparison<in T>(T left, T right);
```

The code creats a delegate of type Comparison<T>, which accepts registration of functions with signature:

```cs
 int FunctionName(int a, int b)
```

After defined a delegate type (Comparison<T>), think of it as created a:

```cs
class Comparison<T>{}
```

To declare an instance of the delegate (like create an instance of a class), use the syntax: **public Comparison<T> comparator**, for example

```cs
public Comparison<int> comparator;
```

will create a delegate instance that compares int, that will accept registration for functions with signature that takes two ints as parameter and returns a int:

```cs
public int CompareInt(int a, int b){
return a>b;
}

// register the function to the delegate
comparator += CompareInt;
// or remvoe the function from the delegate
comparator -= CompareInt;
```

To execute the delegate instance, simply invoke it with the parameter as specified when defining the delegate:

```cs
int result = comparator(1,2);
```

This will invoke all the functions that are registered to the delegate. However, the final result returned by the delegate is the result of the last registered function;
