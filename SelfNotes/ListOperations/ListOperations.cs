using System;
using System.Collections.Generic;
using static System.Console;

namespace ListOperations {

    public static class ListOperations {
        public static void PrintLst<T> (this List<T> lst) {
            Write ("[");
            for (int i1 = 0; i1 < lst.Count; i1++) {
                T i = lst[i1];
                Console.Write (i);
                if (i1 < lst.Count - 1) {
                    Console.Write (", ");
                }
            }
            Write ("]");
            Console.WriteLine ();
        }
        private static List<int> GenerateList (int size) {
            List<int> result = new List<int> (size);
            Random rand = new Random ();
            for (int i = 0; i < size; i++) {
                result.Add (rand.Next (0, size));
            }
            return result;
        }

        public static void ListOperationsDemo () {
            List<int> lst = new List<int> ();
            //*** Add elements to the list ***//
            WriteLine ("//*** Add elements to the list ***//");
            WriteLine ("Add single element using Add");
            WriteLine ("public void Add (T item);");
            lst.Add (1);
            lst.PrintLst ();
            Console.WriteLine ();

            WriteLine ("Add a collection of elements using AddRange");
            WriteLine ("public void AddRange (IEnumerable<T> collection);");
            lst.AddRange (GenerateList (3));
            lst.PrintLst ();
            Console.WriteLine ();

            WriteLine ("Insert single element using Insert");
            WriteLine ("Insert at begining");
            lst.Insert (0, 100);
            lst.PrintLst ();
            WriteLine ("Insert at end");
            lst.Insert (lst.Count, 999);
            lst.PrintLst ();
            Console.WriteLine ();

            WriteLine ("Insert a collection of elements using InsertRange");
            WriteLine ("Insert collection [1,2,3,4,5] at begining");
            lst.InsertRange (0, new List<int> () { 1, 2, 3, 4, 5 });
            lst.PrintLst ();
            WriteLine ("Insert collection [1,2,3,4,5] at end");
            lst.InsertRange (lst.Count, new List<int> () { 1, 2, 3, 4, 5 });
            lst.PrintLst ();
            Console.WriteLine ();

            //*** Remove elements to the list ***//
            WriteLine ("//*** Remove elements to the list ***//");
            WriteLine ("Remove single element by value using Remove");
            WriteLine ("public bool Remove (T item);");
            WriteLine ("Element exist in the list:");
            bool removed = lst.Remove (lst[0]);
            lst.PrintLst ();
            WriteLine ($"Result returned by Remove: {removed}");
            WriteLine ("Element does not exist in the list:");
            removed = lst.Remove (-1);
            lst.PrintLst ();
            WriteLine ($"Result returned by Remove: {removed}");
            Console.WriteLine ();

            WriteLine ($"Remove elements by providing custom matching function using RemoveAll");
            WriteLine ("public int RemoveAll (Predicate<T> match);");
            WriteLine ($"Remove elements greater than 3");
            int removedCount = lst.RemoveAll ((int e) => e > 3);
            lst.PrintLst ();
            WriteLine ($"Result returned by Remove all (number of elements removed): {removedCount}");
            WriteLine ();

            WriteLine ("Remove element by index using RemoveAt");
            WriteLine ("public void RemoveAt (int index);");
            WriteLine ("Remove second element in the list");
            lst.RemoveAt (1);
            lst.PrintLst ();
            WriteLine ();

            WriteLine ("Remove range of elements using RemoveRange(int index, int count)");
            WriteLine ("public void RemoveRange (int index, int count);");
            WriteLine ("Remove 3 elements start from index 1");
            lst.RemoveRange (1, 3);
            lst.PrintLst ();
            WriteLine ();

            WriteLine ("Remove all elements using Clear");
            WriteLine ("public void Clear ();");
            lst.Clear ();
            lst.PrintLst ();
            WriteLine ();

            //*** Search elements in the list ***//
            WriteLine ("//*** Search elements in the list ***//");
            lst = GenerateList (10);
            lst.PrintLst ();
            WriteLine ();
            WriteLine ("Check if an element is in a list using Contains");
            WriteLine ("public bool Contains (T item);");
            WriteLine ($"{lst[3]} is in the list: {lst.Contains (lst[3])}");
            WriteLine ($"100 is in the list: {lst.Contains (100)}");
            WriteLine ();

            WriteLine ($"Check if elements in the list by providing custom matching function using Exists");
            WriteLine ("public bool Exists (Predicate<T> match);");
            WriteLine ($"if the list contains number less than 5 :{lst.Exists((int e)=>e<5)}");
            WriteLine ($"if the list contains number greater than 10 :{lst.Exists((int e)=>e>10)}");
            WriteLine ();

            WriteLine ($"Find the first occurrence of an element that satisfies a custom matching function in the list using Find, will return the default value of the type if non element satisfies the condition");
            WriteLine ("public T Find (Predicate<T> match);");
            WriteLine ($"First occurrence in the list which the value greater than 5:{lst.Find((int e)=> e>5)}");
            WriteLine ($"First occurrence in the list which the value greater than 15:{lst.Find((int e)=> e>15)}");
            WriteLine ();

            WriteLine ($"Find the last occurrence of an element that satisfies a custom matching function in the list using Find, will return the default value of the type if non element satisfies the condition");
            WriteLine ("public int FindLast (Predicate<T> match);");
            WriteLine ($"Last occurrence of element which the value greater than 5: {lst.FindLast ((int e) => e > 5)}");
            WriteLine ($"Last occurrence of element which the value greater than 15: {lst.FindLast ((int e) => e > 15)}");
            WriteLine ();

            WriteLine ($"Find a collection of elements that satisfies a custom matching function in the list using Find, will return the empty list if non element satisfies the condition");
            WriteLine ("public System.Collections.Generic.List<T> FindAll (Predicate<T> match);");
            WriteLine ($"Collection which the value greater than 5:");
            lst.FindAll ((int e) => e > 5).PrintLst ();
            WriteLine ($"Collection which the value greater than 15:");
            lst.FindAll ((int e) => e > 15).PrintLst ();
            WriteLine ();

            //*** Search elements' index in the list ***//
            WriteLine ("//*** Search elements' index in the list ***//");
            WriteLine ($"Find the index of the first occurrence of an element that satisfies a custom matching function in the list using FindIndex, will return -1 if non element satisfies the condition");
            WriteLine ("public int FindIndex (Predicate<T> match);");
            WriteLine ($"Index of first occurrence of element which the value greater than 5: {lst.FindIndex ((int e) => e > 5)}");
            WriteLine ($"Index of first occurrence of element which the value greater than 15: {lst.FindIndex ((int e) => e > 15)}");
            WriteLine ();

            WriteLine ($"Find the index of the last occurrence of an element that satisfies a custom matching function in the list using FindLast, will return -1 if non element satisfies the condition");
            WriteLine ("public int FindLastIndex (Predicate<T> match);");
            WriteLine ($"Index of last occurrence of element which the value greater than 5: {lst.FindLastIndex ((int e) => e > 5)}");
            WriteLine ($"Index of last occurrence of element which the value greater than 15: {lst.FindLastIndex ((int e) => e > 15)}");
            WriteLine ();

            WriteLine ("Find the firt index of a given value using IndexOf");
            lst.PrintLst ();
            WriteLine ($"Index of {lst[4]} is: {lst.IndexOf(lst[4])}");
            WriteLine ($"Index of 100 is: {lst.IndexOf(100)}");
            WriteLine ();

            WriteLine ("Find the last index of a given value using IndexOf");
            lst.PrintLst ();
            WriteLine ($"Index of {lst[4]} is: {lst.LastIndexOf(lst[4])}");
            WriteLine ($"Index of 100 is: {lst.LastIndexOf(100)}");
            WriteLine ();

            //*** Manipulating the list ***//
            WriteLine ("//*** Manipulating the list ***//");
            lst = GenerateList (10);
            lst.PrintLst ();
            WriteLine ("Sort the list using Sort");
            lst.Sort ();
            lst.PrintLst ();
            WriteLine ();

            WriteLine ("Reverse the list using Reverse");
            WriteLine ("public void Reverse ();");
            WriteLine ("public void Reverse (int index, int count);");
            WriteLine ("Reverse the whole list");
            lst.Reverse ();
            lst.PrintLst ();
            WriteLine ("Reverse the list start at index 2 of length 4");
            lst.Reverse (2, 4);
            lst.PrintLst ();
            WriteLine ();

            WriteLine ("Apply actions to list element using ForEach, can not change original list element");
            WriteLine ("public void ForEach (Action<T> action);");
            WriteLine ("Print elements that are greater then 5");
            lst.ForEach ((int e) => { if (e > 5) WriteLine (e); });
            WriteLine ();

            WriteLine ("Convert elements to another type using ConvertAll");
            WriteLine ("public System.Collections.Generic.List<TOutput> ConvertAll<TOutput>(Converter<T,TOutput> converter);");
            WriteLine ("Increment each element by 1 and convert int list to string list");
            List<string> convertedLst = lst.ConvertAll<string> ((int e) => {
                return (e + 1).ToString ();
            });
            convertedLst.PrintLst ();

            WriteLine ("Copy elements from this list to other Array using CopyTo");
            lst.PrintLst ();
            int[] anotherLst = GenerateList (15).ToArray ();
            WriteLine("Array before copying");
            for (int i1 = 0; i1 < anotherLst.Length; i1++) {
                int i = anotherLst[i1];
                Write (i);
                if (i != anotherLst.Length - 1) {
                    Write (", ");
                }
            }
            WriteLine();
            WriteLine();
            WriteLine("Array after copying");
            lst.CopyTo (anotherLst);
            for (int i1 = 0; i1 < anotherLst.Length; i1++) {
                int i = anotherLst[i1];
                Write (i);
                if (i != anotherLst.Length - 1) {
                    Write (", ");
                }
            }
            WriteLine ();

        }
    }
}