# Factory Design Pattern

Factory is another Creational design pattern. Instead of Builder, Factory is suitable when the object can be initialized/created in many different ways and we can not use overload for constructor to achieve the purpose in a well-structured way.

An example would be a Point class. Say we need a class to create Points:

```cs
public Class Point{
    float x;
    float y;
}
```

However, a Point can be created using different systems, such as Cartesian coordinate or Polar coordinates.

Since both system use same input parameters (two floats), we can not distinguish them by only using constructor.

In this case, a Factory design pattern will provide a cleaner way for other people uses this system to create Points according to their needs.

Unlike Builder which create an object piece by piece, Factory usually create the object as a whole at once.

## Factory Method

Use a Factory Method inside the class to create the object in different ways.

```cs
public class Something{
    private Something(){

    }
    public static Something CreateSomethingWithGood(){
        // create the object depending on the need
        Something result = new Something();
        result.balabala = banana;
        return result;
    }
    public static Something CreateSomethingWithWood(){
        // create the object depending on the need
        Something result = new Something();
        result.balabala = oak;
        return result;
    }
}
```

## Asynchronous Factory Method

When we need to perform some asynchronous tasks before create the object, it could be a problem since we can not use asynchronous functions inside constructor. So people may create a separate method to initialize the object. However, it's not clear and safe becasue people can forget to call the initialization function.

```cs
public class AsyncInitClass {
        public AsyncInitClass(){
        }

        public async Task<AsyncInitClass> InitAsync(){
            AsyncInitClass result = new AsyncInitClass();
            await Task.Delay(1000);
            return result;
        }
    }
```

Factory design pattern can be a great way here to provide a cleaner API for creating such objects.

## Inner Factory
