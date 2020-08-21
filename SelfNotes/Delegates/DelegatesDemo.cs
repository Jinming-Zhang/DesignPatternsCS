using System;

namespace DelegateDemo
{
    /// <summary>
    /// Declare a delegate that can compare to generic types
    /// </summary>
    /// <param name="left">first element to compare</param>
    /// <param name="right">second element to compare</param>
    /// <typeparam name="T">a generic type</typeparam>
    /// /// <returns>negtive number if left > right
    ///           0  if left == right
    ///           positive number if left < right</returns>
    public delegate int Comparison<in T>(T left, T right);
    class DelegateDemo
    {
        // class fields
        public string Fir { get; set; }
        public string Sec { get; set; }
        public Comparison<string> stringLenghComparator;
        public DelegateDemo()
        {

        }
        public DelegateDemo(string fir, string sec)
        {
            this.Fir = fir;
            this.Sec = sec;
        }

        /// <summary>
        /// Use different function method to compare string, using delegate
        /// </summary>
        public void Demo()
        {
            DelegateDemo dm = new DelegateDemo("short", "longer");
            // rigister function that return s2-s1
            dm.stringLenghComparator += (string s1, string s2) =>
            {
                Console.WriteLine("Real compare invoked!");
                return s2.Length - s1.Length;
            };
            // oppsite
            dm.stringLenghComparator += (string s1, string s2) =>
            {
                Console.WriteLine("Fake compare invoked!");
                return s1.Length - s2.Length;
            };
            // invoke the delegate
            Console.Write("Final Result: ");
            Console.WriteLine(dm.stringLenghComparator(dm.Fir, dm.Sec));
        }
    }
}