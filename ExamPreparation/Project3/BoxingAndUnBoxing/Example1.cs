using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.BoxingAndUnBoxing
{
    static class Example1
    {
        static object boxedValue;

        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            boxedValue = 100;  // boxing: conversion of value type (int) to reference type (object)
            Console.WriteLine($"Initial value: {boxedValue}");    // unboxing: conversion of reference type (object) to value type (int)
            ChangeValue(boxedValue);  //  How will the parameter be passed???? after unboxing or boxed as it is? In this statement, the value is reboxed and that reboxed value is passed to the invoked method
            Console.WriteLine(boxedValue);    // The value is passed after being unboxed
        }

        static void ChangeValue(object @int)
        {
            @int = (int)@int + 3;
            Console.WriteLine($"Passed value and received value are same: {ReferenceEquals(@int, boxedValue)}");
        }
    }
}
