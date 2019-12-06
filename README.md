![GitHub last commit (master)](https://img.shields.io/github/last-commit/TylerBrinkley/Genumerics/master.svg?logo=github)
[![NuGet Version](https://img.shields.io/nuget/v/Genumerics.svg?logo=nuget)](https://www.nuget.org/packages/Genumerics/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Genumerics.svg?logo=nuget)](https://www.nuget.org/packages/Genumerics/)

# Genumerics
Genumerics is a high-performance .NET library for generic numeric operations. It is compatible with .NET Framework 4.5+ and .NET Standard 2.0+.

## The Problem
You may have come across while working in .NET where you would like to perform numeric operations over a generic numeric type. Unfortunately .NET doesn't provide a way to do that natively.

This library fills that gap by providing most standard numeric operations for the following built-in numeric types and their nullable equivalents with the ability to add support for other numeric types.

`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `float`, `double`, `decimal`, and `BigInteger`

## Genumerics Demo
Below is a demo of some basic uses of Genumerics in the form of unit tests.
```c#
using Genumerics;
using NUnit.Framework;

public class GenumericsDemo
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
    public void ToString<T>(T value, string? format, string expected)
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

## Performance Comparison
The summation algorithms below were benchmarked in .NET Core 3.0 and .NET 4.8 to determine the relative performance of the library compared with an `int` specific algorithm. As can be seen in the results, the performance is equivalent.

### Results
|     Method |       Mean |   Error |  StdDev | Ratio |
|----------- |-----------:|--------:|--------:|------:|
|        Sum |   531.0 ns | 1.40 ns | 1.31 ns |  1.00 |
|  SumNumber |   521.2 ns | 1.41 ns | 1.32 ns |  0.98 |
| SumNumber2 |   531.7 ns | 0.81 ns | 0.76 ns |  1.00 |
|     SumAdd |   530.1 ns | 1.04 ns | 0.97 ns |  1.00 |
|    SumAdd2 |   532.2 ns | 1.60 ns | 1.33 ns |  1.00 |

### Code
```c#
using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Genumerics;

public class Program
{
    static void Main() => BenchmarkRunner.Run<SumBenchmarks<int, DefaultNumericOperations>>();
}

[SimpleJob(RuntimeMoniker.Net461), SimpleJob(RuntimeMoniker.NetCoreApp30), LegacyJitX86Job]
public class SumBenchmarks<T, TNumericOperations>
    where TNumericOperations : struct, INumericOperations<T>
{
    private int[] _intItems;
    private T[] _items;

    [Benchmark(Baseline = true)]
    public int Sum()
    {
        int sum = 0;
        foreach (int item in _intItems)
        {
            sum += item;
        }
        return sum;
    }

    [Benchmark]
    public T SumNumber()
    {
        Number<T> sum = default;
        foreach (T item in _items)
        {
            sum += item;
        }
        return sum;
    }

    [Benchmark]
    public T SumNumber2()
    {
        Number<T, TNumericOperations> sum = default;
        foreach (T item in _items)
        {
            sum += item;
        }
        return sum;
    }

    [Benchmark]
    public T SumAdd()
    {
        T sum = default;
        foreach (T item in _items)
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
        foreach (T item in _items)
        {
            sum = operations.Add(sum, item);
        }
        return sum;
    }

    [GlobalSetup]
    public void Setup()
    {
        _intItems = new int[1000];
        _items = new T[1000];
        Random rand = new Random();
        for (int i = 0; i < 1000; ++i)
        {
            int value = rand.Next(10);
            _intItems[i] = value;
            _items[i] = Number.Create(value).To<T>();
        }
    }
}
```

## Interface

See [fuget](https://www.fuget.org/packages/Genumerics/1.0.1/lib/netcoreapp3.0/Genumerics.dll/Genumerics/Number) for exploring the interface.
