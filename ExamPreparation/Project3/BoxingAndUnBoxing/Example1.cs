using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.BoxingAndUnBoxing
{
    static class Example1
    {
        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            object @int = 100;  // boxing: conversion of value type (int) to reference type (object)
            Console.WriteLine($"Initial value: {@int}");    // unboxing: conversion of reference type (object) to value type (int)
            ChangeValue(@int);  //  How will the parameter be passed???? after unboxing or boxed as it is?
            Console.WriteLine(@int);    // The value is passed after being unboxed
        }

        static void ChangeValue(object @int) => @int = (int)@int + 3;
    }
}
