using System;
using Builder;
using DelegateDemo;
using FluentBuilderDemo;
using FluentBuilderInheritanceDemo;
namespace DesignPatternsC_
{
    class Program
    {
        static void Main(string[] args)
        {
            // new DelegateDemo.DelegateDemo().Demo();
            //%%%%%%%%%%%%%%% Builder Demos %%%%%%%%%%%%%%%%%%//
            // new Builder.HTMLStringBuilder().Demo();
            // new Builder.HTMLBuilder().Demo();
            // new WolfFluentBuilderDemo().Demo();
            new FluentBuilderInheritanceDemo.FluentBulderInheritanceDemo().Demo();
        }
    }
}
