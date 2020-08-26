using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalBuilderGeneralized
{
    public class Builder<T>
    where T : new()
        // where BUILDER : Builder<T, BUILDER>
    {
        public List<Func<T, T>> builderMethods = new List<Func<T, T>>();
        public Builder<T> addBuilderMethod(Action<T> method)
        {
            builderMethods.Add((T objToBuild) =>
            {
                method(objToBuild);
                return objToBuild;
            });
            return this;
        }
        public T Build()
        {
            return builderMethods.Aggregate(new T(), (objBuilding, builderMethod) => builderMethod(objBuilding));
        }
    }
    public class Wolf
    {
        public string name, age, gender;
        public bool hasPack, isSingle;
        public override string ToString()
        {
            string packInfo = hasPack ? "have a pack" : "do not have a pack";
            string statusInfo = isSingle ? "I'm single" : "I'm married";
            return $"I'm {name}, I'm a  {age} years old {gender} wolf. I {packInfo}. {statusInfo}.";
        }
    }
    public static class WolfBuilderExtension
    {
        public static Builder<Wolf> Name(this Builder<Wolf> wolfBuilder, string name)
        {
            return wolfBuilder.addBuilderMethod((Wolf w) =>
            {
                w.name = name;
            });
        }

        public static Builder<Wolf> Age(this Builder<Wolf> wolfBuilder, string age)
        {
            return wolfBuilder.addBuilderMethod((Wolf w) =>
            {
                w.age = age;
            });
        }

        public static Builder<Wolf> Gender(this Builder<Wolf> wolfBuilder, string gender)
        {
            return wolfBuilder.addBuilderMethod((Wolf w) =>
            {
                w.gender = gender;
            });
        }

    }
    public class FunctionalBuilderGeneralizedDemo
    {
        public void Demo()
        {
            Builder<Wolf> wolfBuilder = new Builder<Wolf>();
            Wolf w = wolfBuilder.Name("wolfy").Gender("male").Age("20").Build();
            Console.WriteLine(w);
        }
    }
}