#region License
// Copyright (c) 2019 Tyler Brinkley
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Diagnostics;
using System.Reflection;

namespace Genumerics
{
    /// <summary>
    /// The numeric operations factory base class.
    /// </summary>
    public abstract class NumericOperationsFactory
    {
        /// <summary>
        /// Gets the numeric operations type that handles the numeric type <typeparamref name="T"/> or else returns <c>null</c>.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <returns></returns>
        public abstract Type? GetOperationsType<T>();
    }

    internal sealed class DefaultNumericOperationsFactory : NumericOperationsFactory
    {
        public override Type? GetOperationsType<T>() => default(DefaultNumericOperations) is INumericOperations<T> ? typeof(DefaultNumericOperations) : null;
    }

    internal sealed class NullableNumericOperationsFactory : NumericOperationsFactory
    {
        public override Type? GetOperationsType<T>()
        {
            var numericType = typeof(T);
            if (default(T)! == null && numericType.IsValueType)
            {
                var underlyingType = numericType.GetGenericArguments()[0];
                var underlyingOperations = typeof(Number)
                    .GetMethod(nameof(Number.GetOperationsInternal), BindingFlags.Static | BindingFlags.NonPublic)!
                    .MakeGenericMethod(underlyingType).Invoke(null, null)!;
                Debug.Assert(underlyingOperations.GetType().Name == "NumericOperationsWrapper`2");
                var underlyingOperationsType = underlyingOperations.GetType().GetGenericArguments()[1];
                return typeof(NullableNumericOperations<,>).MakeGenericType(underlyingType, underlyingOperationsType);
            }
            return null;
        }
    }

    internal sealed class FuncNumericOperationsFactory : NumericOperationsFactory
    {
        private readonly Func<Type, Type?> _operationsFactory;

        public FuncNumericOperationsFactory(Func<Type, Type?> operationsFactory)
        {
            _operationsFactory = operationsFactory;
        }

        public override Type? GetOperationsType<T>() => _operationsFactory(typeof(T));
    }
}