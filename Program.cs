using System;
using AsyncDemo;
using DelegateDemo;
using Event;
//************** Creational Design Patterns **************//
// builder demos
using BuilderExcerciseDemo;
using FacetedBuilderDemo;
using FluentBuilderDemo;
using FluentBuilderInheritanceDemo;
using FunctionalBuilderDemo;
using FunctionalBuilderGeneralized;
using SimpleBuilderDemo;
// Factory demos
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AbstractFactoryDemo;
using AsyncFactoryMethodDemo;
using FactoryMethodDemo;
// Prototype
using static SimplePrototype.SimplePrototype;
using static SerializationPrototype.SerializationPrototype;
// Singleton
//************** Structural Design Patterns **************//
// Adapter
using static AdapterExercise.AdapterExercise;
// Bridge
using static BridgeExercise.BridgeExercise;
// Composite
// Decorator
// Facade
// Flyweight
using static FlyweightExercise.FlyweightExercise;
// Proxy
//************** Behavior Design Patterns **************//
// Chain of responsibility
namespace DesignPatternsC_ {
    class Program {
        static void Main (string[] args) {
            // new DelegateDemo.DelegateDemo().Demo();
            // await AsyncDemo.AsyncDemo.Demo();
            Event.Event.EventDemo ();
            //%%%%%%%%%%%%%%% Builder Demos %%%%%%%%%%%%%%%%%%//
            // new SimpleBuilderDemo.HTMLStringBuilder().Demo();
            // new SimpleBuilderDemo.HTMLBuilder().Demo();
            // new FacetedBuilderDemo.FacetedBuilderDemo().Demo();
            // new WolfFluentBuilderDemo().Demo();
            // new FluentBuilderInheritanceDemo.FluentBulderInheritanceDemo().Demo();
            // new FunctionalBuilderDemo.FunctionalBuilderDemo().Demo();
            // new FunctionalBuilderGeneralizedDemo().Demo();
            // new BuilderExcerciseDemo.BuilderExcerciseDemo().Demo();
            //%%%%%%%%%%%% Factory Demos %%%%%%%%%%//
            // FactoryMethodDemo.FactoryMethodDemo.Demo();
            // string result = await AsyncFactoryMethodDemo.AsyncFactoryMethodDemo.Demo();
            // Console.WriteLine(result);
            // AbstractFactoryDemo.AbstractFactoryDemo.Demo();
            //%%%%%%%%%%%%%%  Prototype  %%%%%%%%%%%%%%%%%%%%%//
            // SimplePrototypeDemo();
            // SerializationPrototypeDemo();
            //%%%%%%%%%%%%%%  Adapter  %%%%%%%%%%%%%%%%%%%%%//
            // AdapterExerciseDemo ();
            //%%%%%%%%%%%%%%  Bridge  %%%%%%%%%%%%%%%%%%%%%//
            // BridgeExerciseDemo ();
            //%%%%%%%%%%%%%%  Flyweight  %%%%%%%%%%%%%%%%%%%%%//
            // FlyweightExerciseDemo ();
            List<int> intLst = new List<int> { 6, 6, 6, 6, 6 };
            TryList (intLst);
            Console.WriteLine (intLst[1]);
        }

        static void TryList (List<int> intlst) {
            intlst[1] = 2;
        }

    }
}