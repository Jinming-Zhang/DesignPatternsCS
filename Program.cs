using System;
using Builder;
namespace DesignPatternsC_
{
    class Program
    {
        static void Main(string[] args)
        {
            // Builder Demos
            new Builder.HTMLStringBuilder().Demo();
            new Builder.HTMLBuilder().Demo();
        }
    }
}
