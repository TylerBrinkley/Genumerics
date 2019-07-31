# Genumerics
Genumerics is a high-performance .NET library for generic numeric operations. It is compatible with .NET Framework 2.0+ and .NET Standard 1.0+.

## The Problem
You may have come across a point while working in .NET where you would like to perform numeric or mathematical operations over a generic numeric type. Unfortunately .NET doesn't provide a way to do that natively and so you must either specialize each case of numeric type or figure out another way of accomplishing this.

This library fills that gap by providing most standard numeric operations for the following built-in numeric types.

`sbyte, byte, short, ushort, int, uint, long, ulong, float, double, decimal, and BigInteger`

## Genumerics Demo
Below is a demo of some basic uses of Genumerics in the form of unit tests.
```c#
using Genumerics;
using NUnit.Framework;

class GenumericsDemo
{
    [TestCase(4, 5, 9)]
    [TestCase(2.25, 6.75, 9.0)]
    public void Add<T>(T left, T right, T expected)
    {
        Assert.AreEqual(expected, Number.Add(left, right));
        Assert.AreEqual(expected, AddWithOperator<T>(left, right));
    }

    private T AddWithOperator<T>(Number<T> left, Number<T> right) => left + right;

    [TestCase(9, 6, true)]
    [TestCase(3.56, 4.07, false)]
    public void GreaterThan<T>(T left, T right, bool expected)
    {
        Assert.AreEqual(expected, Number.GreaterThan(left, right));
        Assert.AreEqual(expected, GreaterThanWithOperator<T>(left, right));
    }

    private bool GreaterThanWithOperator<T>(Number<T> left, Number<T> right) => left > right;

    [TestCase(4, 4.0)]
    [TestCase(27.0, 27)]
    public void Convert<TFrom, TTo>(TFrom value, TTo expected)
    {
        Assert.AreEqual(expected, Number.Convert<TFrom, TTo>(value));
        Assert.AreEqual(expected, Number.Create(value).To<TTo>());
    }

    [TestCase("98765", 98765)]
    [TestCase("12.3456789", 12.3456789)]
    public void Parse<T>(string value, T expected)
    {
        Assert.AreEqual(expected, Number.Parse<T>(value));
    }

    [TestCase(123, null, "123")]
    [TestCase(255, "X", "FF")]
    public void ToString<T>(T value, string format, string expected)
    {
        Assert.AreEqual(expected, Number.ToString(value, format));
    }

    [TestCase(sbyte.MaxValue)]
    [TestCase(float.MaxValue)]
    public void MaxValue<T>(T expected)
    {
        Assert.AreEqual(expected, Number.MaxValue<T>());
    }
}
```

## Performance
The summation algorithms below were benchmarked in .NET Core to determine the relative performance of the library compared with an `int` specific algorithm. As can be seen in the results, the performance is equivalent when using the numeric operations as a `struct` interface generic type argument constraint but is an order of magnitude slower when only using the numeric type due to the interface method dispatch. In order to reach performance parity with the `int` specific algorithm the library makes use of an optimization for `struct` interface generic type argument constraints described in this [generic calculations article](https://www.codeproject.com/articles/8531/using-generics-for-calculations) that prevents the interface method dispatch.

### Results
|     Method |       Mean |      Error |     StdDev | Ratio | RatioSD |
|----------- |-----------:|-----------:|-----------:|------:|--------:|
|        Sum |   574.7 ns |   6.598 ns |   5.849 ns |  1.00 |    0.00 |
|  SumNumber | 6,003.0 ns | 114.548 ns | 101.544 ns | 10.45 |    0.19 |
| SumNumber2 |   577.5 ns |   3.821 ns |   3.574 ns |  1.00 |    0.01 |
|     SumAdd | 6,275.3 ns |  47.339 ns |  39.530 ns | 10.93 |    0.12 |
|    SumAdd2 |   580.6 ns |   9.845 ns |   8.221 ns |  1.01 |    0.02 |

### Code
```c#
using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Genumerics;

class Program
{
    static void Main() => BenchmarkRunner.Run<SumBenchmarks<int, DefaultNumericOperations>>();
}

public class SumBenchmarks<T, TNumericOperations>
    where TNumericOperations : struct, INumericOperations<T>
{
    private int[] intItems;
    private T[] items;

    [Benchmark(Baseline = true)]
    public int Sum()
    {
        int sum = 0;
        foreach (int item in intItems)
        {
            sum += item;
        }
        return sum;
    }

    [Benchmark]
    public T SumNumber()
    {
        Number<T> sum = default;
        foreach (T item in items)
        {
            sum += item;
        }
        return sum;
    }

    [Benchmark]
    public T SumNumber2()
    {
        Number<T, TNumericOperations> sum = default;
        foreach (T item in items)
        {
            sum += item;
        }
        return sum;
    }

    [Benchmark]
    public T SumAdd()
    {
        T sum = default;
        foreach (T item in items)
        {
            sum = Number.Add(sum, item);
        }
        return sum;
    }

    [Benchmark]
    public T SumAdd2()
    {
        T sum = default;
        TNumericOperations operations = default;
        foreach (T item in items)
        {
            sum = operations.Add(sum, item);
        }
        return sum;
    }

    [GlobalSetup]
    public void Setup()
    {
        intItems = new int[1000];
        items = new T[1000];
        Random rand = new Random();
        for (int i = 0; i < 1000; ++i)
        {
            int value = rand.Next(10);
            intItems[i] = value;
            items[i] = Number.Create(value).To<T>();
        }
    }
}
```