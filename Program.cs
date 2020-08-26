﻿using System;
using DelegateDemo;
// builder demos
using SimpleBuilderDemo;
using FacetedBuilderDemo;
using FluentBuilderDemo;
using FluentBuilderInheritanceDemo;
using FunctionalBuilderDemo;
using FunctionalBuilderGeneralized;
using BuilderExcerciseDemo;
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
            // new FacetedBuilderDemo.FacetedBuilderDemo().Demo();
            // new WolfFluentBuilderDemo().Demo();
            // new FluentBuilderInheritanceDemo.FluentBulderInheritanceDemo().Demo();
            // new FunctionalBuilderDemo.FunctionalBuilderDemo().Demo();
            new FunctionalBuilderGeneralizedDemo().Demo();
            new BuilderExcerciseDemo.BuilderExcerciseDemo().Demo();
        }
    }
}
