using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Genumerics;

public class Program
{
    static void Main() => BenchmarkRunner.Run<SumBenchmarks<int, DefaultNumericOperations>>();
}

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