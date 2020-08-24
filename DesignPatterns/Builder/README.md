# Builder Design Pattern

Builder design pattern is used when the objects we want to build are kind of complecated, ie, has a lot of fields.

## Fluent Builder

## Fluent Builder with Inheritance

The problem with inheriting in basic Fluent Builder is that the parent-builder will not have the information of the methods of their sub-builder, and so we cannot chain the methods in all the builders together.
To solve this, we can use recursive generic types to provide more type information when creating the parent builder, and enables the ability to call methods in its sub-builder.
