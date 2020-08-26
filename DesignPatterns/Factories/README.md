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
