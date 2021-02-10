using System;
using AsyncDemo;
using DelegateDemo;
using Event;
using ListOperations;
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
using static DecoratorExercise.DecoratorDemo;
// Facade
// Flyweight
using static FlyweightExercise.FlyweightExercise;
// Proxy
//************** Behavior Design Patterns **************//
// Chain of responsibility
//************** Problems **************//
// using interviewAsyncLoadingGame;
namespace DesignPatternsC_
{
    class Program
    {
        static void Main(string[] args)
        {
            // new DelegateDemo.DelegateDemo().Demo();
            // await AsyncDemo.AsyncDemo.Demo();
            // Event.Event.EventDemo ();
            // ListOperations.ListOperations.ListOperationsDemo ();
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
            // %%%%%%%%%%%%% Interview Problems %%%%%%%%%%%%%//
            // interviewAsyncLoadingGame.SolutionDemo.Demo ();
            System.DateTime now = System.DateTime.Now;
            System.DateTime utcNow = System.DateTime.UtcNow;

            Console.WriteLine((utcNow - now).ToString("h'h 'm'm 's's'"));
            Demo();
        }

        static int[,] MagicSquare(int[,] square, int index)
        {
            // validate square
            if (IsMagicSquare(square))
            {
                return square;
            }

            int[,] result = new int[3, 3];
            for (int r = 0; r < square.GetLength(0); r++)
            {
                for (int c = 0; c < square.GetLength(1); c++)
                {
                    result[r, c] = square[r, c];
                }
            }
            int row = index / result.GetLength(1);
            int col = index % result.GetLength(1);
            List<int> availableNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            availableNumbers.Remove(result[row, col]);
            foreach (int candidate in availableNumbers)
            {
                result[row, col] = candidate;
                if (IsMagicSquare(result))
                {
                    return result;
                }
            }
            for (int r = 0; r < result.GetLength(0); r++)
            {
                for (int c = 0; c < result.GetLength(1); c++)
                {
                    int elmt = result[r, c];
                }
            }

            return null;
        }
        static bool IsMagicSquare(int[,] square)
        {
            int sum = 0;
            for (int i = 0; i < square.GetLength(1); i++)
            {
                sum += square[0, i];
            }

            // check for rest of rows
            for (int r = 1; r < square.GetLength(0); r++)
            {
                int rowSum = 0;
                for (int c = 0; c < square.GetLength(1); c++)
                {
                    rowSum += square[r, c];
                }
                if (rowSum != sum)
                {
                    return false;
                }
            }

            // check for cols
            for (int c = 0; c < square.GetLength(1); c++)
            {
                int colSum = 0;
                for (int r = 0; r < square.GetLength(0); r++)
                {
                    colSum += square[r, c];
                }
                if (colSum != sum)
                {
                    return false;
                }
            }

            // check for diago
            int diagSum = 0;
            for (int d = 0; d < square.GetLength(0); d++)
            {
                diagSum += square[d, d];
            }
            if (diagSum != sum)
            {
                return false;
            }
            diagSum = 0;
            for (int d = 0; d < square.GetLength(0); d++)
            {
                diagSum += square[d, square.GetLength(0) - d];
            }
            if (diagSum != sum)
            {
                return false;
            }
            return true;
        }
        static void TryList(List<int> intlst)
        {
            intlst[1] = 2;
        }

    }
}