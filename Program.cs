using System;
using DelegateDemo;
using AsyncDemo;
// builder demos
using SimpleBuilderDemo;
using FacetedBuilderDemo;
using FluentBuilderDemo;
using FluentBuilderInheritanceDemo;
using FunctionalBuilderDemo;
using FunctionalBuilderGeneralized;
using BuilderExcerciseDemo;
// Factory demos
using FactoryMethodDemo;
using AsyncFactoryMethodDemo;
using AbstractFactoryDemo;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
// Prototype
using static SimplePrototype.SimplePrototype;
using static SerializationPrototype.SerializationPrototype;
namespace DesignPatternsC_
{
    static class Test
    {
        public static string GetPasscode(string keypad, string instructions)
        {
            // keypad never empty or null
            string passcode = "";
            // todo
            // parse keypad into 2d arrays
            string[] keypadRows = keypad.Split("\n");
            List<string[]> keypadMatrix = new List<string[]>();
            foreach (string r in keypadRows)
            {
                keypadMatrix.Add(r.Split(" "));
                Console.WriteLine(r);
            }
            // find the index of first instruction
            string begin = instructions[0].ToString();
            int[] index = new int[] { -1, -1 };
            for (int i = 0; i < keypadMatrix.Count; i++)
            {
                string[] row = keypadMatrix[i];
                for (int j = 0; j < row.Length; j++)
                {
                    if (row[j] == begin)
                    {
                        index[0] = i;
                        index[1] = j;
                        break;
                    }
                }
            }
            Console.WriteLine($"key begins at: {index[0]}, {index[1]}");
            // walk through instructions
            string[] instructionArray = instructions.Split("\n");
            // skip the first initial character
            for (int i = 1; i < instructionArray.Length; i++)
            {
                // for each series of instructions

                // walk through each instruction
                int[] nextIndex = new int[] { index[0], index[1] };
                foreach (char ins in instructionArray[i])
                {
                    int[] oldIndex = new int[] { nextIndex[0], nextIndex[1] };
                    Console.WriteLine(ins);
                    // operations
                    if (ins == 'U')
                    {
                        nextIndex[0] -= 1;
                    }
                    else if (ins == 'D')
                    {
                        nextIndex[0] += 1;
                    }
                    else if (ins == 'L')
                    {
                        nextIndex[1] -= 1;
                    }
                    else if (ins == 'R')
                    {
                        nextIndex[1] += 1;
                    }
                    // validate if still inside board
                    if (nextIndex[0] >= 0 && nextIndex[0] <= keypadMatrix.Count && nextIndex[1] >= 0 && nextIndex[1] <= keypadMatrix[nextIndex[0]].Length)
                    {

                    }
                    else
                    {
                        nextIndex[0] = oldIndex[0];
                        nextIndex[1] = oldIndex[1];
                    }
                }
                index[0] = nextIndex[0];
                index[1] = nextIndex[1];
                passcode += keypadMatrix[index[0]][index[1]];
                Console.WriteLine($"passcode is {passcode}");
                Console.WriteLine("next");
            }
            return passcode;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // new DelegateDemo.DelegateDemo().Demo();
            // await AsyncDemo.AsyncDemo.Demo();
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
        }

    }
}
