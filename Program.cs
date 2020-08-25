using System;
using DelegateDemo;
using SimpleBuilderDemo;
using FacetedBuilderDemo;
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
            // new SimpleBuilderDemo.HTMLStringBuilder().Demo();
            // new SimpleBuilderDemo.HTMLBuilder().Demo();
            new FacetedBuilderDemo.FacetedBuilderDemo().Demo();
            // new WolfFluentBuilderDemo().Demo();
            // new FluentBuilderInheritanceDemo.FluentBulderInheritanceDemo().Demo();
        }
    }
}
