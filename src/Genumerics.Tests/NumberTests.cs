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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EnumsNET;
using NUnit.Framework;

#if BIG_INTEGER
using System.Numerics;
#endif

namespace Genumerics.Tests
{
    public class NumberTests
    {
        static NumberTests()
        {
            Number<IntWrapper>.Operations = new IntWrapperOperations();
        }

        private static TestCaseData CreateTestCase<T>(object expectedResult, params object[] args) => new TestCaseData(new[] { (object)default(T) }.Concat(args ?? new object[] { null }).ToArray()) { ExpectedResult = expectedResult };

        private static TestCaseData CreateTestCase<T>() => new TestCaseData(default(T));

        private static TestCaseData CreateTestCase<T>(object[] args) => new TestCaseData(new[] { (object)default(T) }.Concat(args).ToArray());

        [Test]
        public void UnsupportedType() => Assert.Throws<NotSupportedException>(() => Number.Zero<string>());

        [TestCaseSource(nameof(ZeroCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T Zero<T>(T valueToInferType) => Number.Zero<T>();
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ZeroCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? ZeroNullable<T>(T valueToInferType) where T : struct => Number.Zero<T?>();
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> ZeroCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)0);
            yield return CreateTestCase<byte>((byte)0);
            yield return CreateTestCase<short>((short)0);
            yield return CreateTestCase<ushort>((ushort)0);
            yield return CreateTestCase<int>(0);
            yield return CreateTestCase<uint>(0U);
            yield return CreateTestCase<long>(0L);
            yield return CreateTestCase<ulong>(0UL);
            yield return CreateTestCase<float>(0F);
            yield return CreateTestCase<double>(0D);
            yield return CreateTestCase<decimal>(0M);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(BigInteger.Zero);
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(0));
        }

        [TestCaseSource(nameof(OneCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T One<T>(T valueToInferType) => Number.One<T>();
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(OneCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? OneNullable<T>(T valueToInferType) where T : struct => Number.One<T?>();
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> OneCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)1);
            yield return CreateTestCase<byte>((byte)1);
            yield return CreateTestCase<short>((short)1);
            yield return CreateTestCase<ushort>((ushort)1);
            yield return CreateTestCase<int>(1);
            yield return CreateTestCase<uint>(1U);
            yield return CreateTestCase<long>(1L);
            yield return CreateTestCase<ulong>(1UL);
            yield return CreateTestCase<float>(1F);
            yield return CreateTestCase<double>(1D);
            yield return CreateTestCase<decimal>(1M);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(BigInteger.One);
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(1));
        }

        [TestCaseSource(nameof(MinusOneCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T MinusOne<T>(T valueToInferType) => Number.MinusOne<T>();
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(MinusOneCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? MinusOneNullable<T>(T valueToInferType) where T : struct => Number.MinusOne<T?>();
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> MinusOneCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)-1);
            yield return CreateTestCase<short>((short)-1);
            yield return CreateTestCase<int>(-1);
            yield return CreateTestCase<long>(-1L);
            yield return CreateTestCase<float>(-1F);
            yield return CreateTestCase<double>(-1D);
            yield return CreateTestCase<decimal>(-1M);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(BigInteger.MinusOne);
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(-1));
        }

        [TestCaseSource(nameof(MinusOneThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void MinusOneThrows<T>(T valueToInferType) => Assert.Throws<NotSupportedException>(() => Number.MinusOne<T>());
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(MinusOneThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void MinusOneNullableThrows<T>(T valueToInferType) where T : struct => Assert.Throws<NotSupportedException>(() => Number.MinusOne<T?>());
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> MinusOneThrowsCases()
        {
            yield return CreateTestCase<byte>();
            yield return CreateTestCase<ushort>();
            yield return CreateTestCase<uint>();
            yield return CreateTestCase<ulong>();
        }

        [TestCaseSource(nameof(MaxValueCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T MaxValue<T>(T valueToInferType) => Number.MaxValue<T>();
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(MaxValueCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? MaxValueNullable<T>(T valueToInferType) where T : struct => Number.MaxValue<T?>();
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> MaxValueCases()
        {
            yield return CreateTestCase<sbyte>(sbyte.MaxValue);
            yield return CreateTestCase<byte>(byte.MaxValue);
            yield return CreateTestCase<short>(short.MaxValue);
            yield return CreateTestCase<ushort>(ushort.MaxValue);
            yield return CreateTestCase<int>(int.MaxValue);
            yield return CreateTestCase<uint>(uint.MaxValue);
            yield return CreateTestCase<long>(long.MaxValue);
            yield return CreateTestCase<ulong>(ulong.MaxValue);
            yield return CreateTestCase<float>(float.MaxValue);
            yield return CreateTestCase<double>(double.MaxValue);
            yield return CreateTestCase<decimal>(decimal.MaxValue);
            yield return CreateTestCase<IntWrapper>(new IntWrapper(int.MaxValue));
        }

#if BIG_INTEGER
        [TestCaseSource(nameof(MaxMinValueThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void MaxValueThrows<T>(T valueToInferType) => Assert.Throws<NotSupportedException>(() => Number.MaxValue<T>());
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(MaxMinValueThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void MaxValueNullableThrows<T>(T valueToInferType) where T : struct => Assert.Throws<NotSupportedException>(() => Number.MaxValue<T?>());
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> MaxMinValueThrowsCases()
        {
            yield return CreateTestCase<BigInteger>();
        }
#endif

        [TestCaseSource(nameof(MinValueCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T MinValue<T>(T valueToInferType) => Number.MinValue<T>();
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(MinValueCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? MinValueNullable<T>(T valueToInferType) where T : struct => Number.MinValue<T?>();
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> MinValueCases()
        {
            yield return CreateTestCase<sbyte>(sbyte.MinValue);
            yield return CreateTestCase<byte>(byte.MinValue);
            yield return CreateTestCase<short>(short.MinValue);
            yield return CreateTestCase<ushort>(ushort.MinValue);
            yield return CreateTestCase<int>(int.MinValue);
            yield return CreateTestCase<uint>(uint.MinValue);
            yield return CreateTestCase<long>(long.MinValue);
            yield return CreateTestCase<ulong>(ulong.MinValue);
            yield return CreateTestCase<float>(float.MinValue);
            yield return CreateTestCase<double>(double.MinValue);
            yield return CreateTestCase<decimal>(decimal.MinValue);
            yield return CreateTestCase<IntWrapper>(new IntWrapper(int.MinValue));
        }

#if BIG_INTEGER
        [TestCaseSource(nameof(MaxMinValueThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void MinValueThrows<T>(T valueToInferType) => Assert.Throws<NotSupportedException>(() => Number.MinValue<T>());
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(MaxMinValueThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void MinValueNullableThrows<T>(T valueToInferType) where T : struct => Assert.Throws<NotSupportedException>(() => Number.MinValue<T?>());
#pragma warning restore IDE0060 // Remove unused parameter
#endif

        [TestCaseSource(nameof(GetTypeCodeCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public TypeCode GetTypeCode<T>(T valueToInferType) => Number.GetTypeCode<T>();
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(GetTypeCodeCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public TypeCode GetTypeCodeNumber<T>(T valueToInferType) => Number.Create(valueToInferType).GetTypeCode();
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(GetTypeCodeCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public TypeCode GetTypeCodeNullable<T>(T valueToInferType) where T : struct => Number.GetTypeCode<T?>();
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(GetTypeCodeCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public TypeCode GetTypeCodeNullableNumber<T>(T valueToInferType) where T : struct => Number.Create<T?>(valueToInferType).GetTypeCode();
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> GetTypeCodeCases()
        {
            yield return CreateTestCase<sbyte>(TypeCode.SByte);
            yield return CreateTestCase<byte>(TypeCode.Byte);
            yield return CreateTestCase<short>(TypeCode.Int16);
            yield return CreateTestCase<ushort>(TypeCode.UInt16);
            yield return CreateTestCase<int>(TypeCode.Int32);
            yield return CreateTestCase<uint>(TypeCode.UInt32);
            yield return CreateTestCase<long>(TypeCode.Int64);
            yield return CreateTestCase<ulong>(TypeCode.UInt64);
            yield return CreateTestCase<float>(TypeCode.Single);
            yield return CreateTestCase<double>(TypeCode.Double);
            yield return CreateTestCase<decimal>(TypeCode.Decimal);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(TypeCode.Object);
#endif
            yield return CreateTestCase<IntWrapper>(TypeCode.Int32);
        }

        [TestCaseSource(nameof(EqualsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool Equals<T>(T valueToInferType, T left, T right) => Number.Equals(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(EqualsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool EqualsNumber<T>(T valueToInferType, T left, T right) => Number.Create(left) == right;
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(EqualsNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool EqualsNullable<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Equals(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(EqualsNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool EqualsNullableNumber<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Create(left) == right;
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> EqualsCases()
        {
            yield return CreateTestCase<sbyte>(true, sbyte.MaxValue, sbyte.MaxValue);
            yield return CreateTestCase<sbyte>(false, sbyte.MaxValue, sbyte.MinValue);
            yield return CreateTestCase<byte>(true, byte.MaxValue, byte.MaxValue);
            yield return CreateTestCase<byte>(false, byte.MaxValue, byte.MinValue);
            yield return CreateTestCase<short>(true, short.MaxValue, short.MaxValue);
            yield return CreateTestCase<short>(false, short.MaxValue, short.MinValue);
            yield return CreateTestCase<ushort>(true, ushort.MaxValue, ushort.MaxValue);
            yield return CreateTestCase<ushort>(false, ushort.MaxValue, ushort.MinValue);
            yield return CreateTestCase<int>(true, int.MaxValue, int.MaxValue);
            yield return CreateTestCase<int>(false, int.MaxValue, int.MinValue);
            yield return CreateTestCase<uint>(true, uint.MaxValue, uint.MaxValue);
            yield return CreateTestCase<uint>(false, uint.MaxValue, uint.MinValue);
            yield return CreateTestCase<long>(true, long.MaxValue, long.MaxValue);
            yield return CreateTestCase<long>(false, long.MaxValue, long.MinValue);
            yield return CreateTestCase<ulong>(true, ulong.MaxValue, ulong.MaxValue);
            yield return CreateTestCase<ulong>(false, ulong.MaxValue, ulong.MinValue);
            yield return CreateTestCase<float>(true, float.MaxValue, float.MaxValue);
            yield return CreateTestCase<float>(false, float.MaxValue, float.MinValue);
            yield return CreateTestCase<double>(true, double.MaxValue, double.MaxValue);
            yield return CreateTestCase<double>(false, double.MaxValue, double.MinValue);
            yield return CreateTestCase<decimal>(true, decimal.MaxValue, decimal.MaxValue);
            yield return CreateTestCase<decimal>(false, decimal.MaxValue, decimal.MinValue);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(true, BigInteger.One, BigInteger.One);
            yield return CreateTestCase<BigInteger>(false, BigInteger.One, BigInteger.Zero);
#endif
            yield return CreateTestCase<IntWrapper>(true, new IntWrapper(int.MaxValue), new IntWrapper(int.MaxValue));
            yield return CreateTestCase<IntWrapper>(false, new IntWrapper(int.MaxValue), new IntWrapper(int.MinValue));
        }

        public static IEnumerable<TestCaseData> EqualsNullableCases() => EqualsCases().Concat(BinaryNullableCases(true, false, false));

        [TestCaseSource(nameof(NotEqualsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool NotEquals<T>(T valueToInferType, T left, T right) => Number.NotEquals(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(NotEqualsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool NotEqualsNumber<T>(T valueToInferType, T left, T right) => Number.Create(left) != right;
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(NotEqualsNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool NotEqualsNullable<T>(T valueToInferType, T? left, T? right) where T : struct => Number.NotEquals(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(NotEqualsNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool NotEqualsNullableNumber<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Create(left) != right;
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> NotEqualsCases()
        {
            yield return CreateTestCase<sbyte>(false, sbyte.MaxValue, sbyte.MaxValue);
            yield return CreateTestCase<sbyte>(true, sbyte.MaxValue, sbyte.MinValue);
            yield return CreateTestCase<byte>(false, byte.MaxValue, byte.MaxValue);
            yield return CreateTestCase<byte>(true, byte.MaxValue, byte.MinValue);
            yield return CreateTestCase<short>(false, short.MaxValue, short.MaxValue);
            yield return CreateTestCase<short>(true, short.MaxValue, short.MinValue);
            yield return CreateTestCase<ushort>(false, ushort.MaxValue, ushort.MaxValue);
            yield return CreateTestCase<ushort>(true, ushort.MaxValue, ushort.MinValue);
            yield return CreateTestCase<int>(false, int.MaxValue, int.MaxValue);
            yield return CreateTestCase<int>(true, int.MaxValue, int.MinValue);
            yield return CreateTestCase<uint>(false, uint.MaxValue, uint.MaxValue);
            yield return CreateTestCase<uint>(true, uint.MaxValue, uint.MinValue);
            yield return CreateTestCase<long>(false, long.MaxValue, long.MaxValue);
            yield return CreateTestCase<long>(true, long.MaxValue, long.MinValue);
            yield return CreateTestCase<ulong>(false, ulong.MaxValue, ulong.MaxValue);
            yield return CreateTestCase<ulong>(true, ulong.MaxValue, ulong.MinValue);
            yield return CreateTestCase<float>(false, float.MaxValue, float.MaxValue);
            yield return CreateTestCase<float>(true, float.MaxValue, float.MinValue);
            yield return CreateTestCase<double>(false, double.MaxValue, double.MaxValue);
            yield return CreateTestCase<double>(true, double.MaxValue, double.MinValue);
            yield return CreateTestCase<decimal>(false, decimal.MaxValue, decimal.MaxValue);
            yield return CreateTestCase<decimal>(true, decimal.MaxValue, decimal.MinValue);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(false, BigInteger.One, BigInteger.One);
            yield return CreateTestCase<BigInteger>(true, BigInteger.One, BigInteger.Zero);
#endif
            yield return CreateTestCase<IntWrapper>(false, new IntWrapper(int.MaxValue), new IntWrapper(int.MaxValue));
            yield return CreateTestCase<IntWrapper>(true, new IntWrapper(int.MaxValue), new IntWrapper(int.MinValue));
        }

        public static IEnumerable<TestCaseData> NotEqualsNullableCases() => NotEqualsCases().Concat(BinaryNullableCases(false, true, true));

        [TestCaseSource(nameof(LessThanCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool LessThan<T>(T valueToInferType, T left, T right) => Number.LessThan(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(LessThanCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool LessThanNumber<T>(T valueToInferType, T left, T right) => Number.Create(left) < right;
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(LessThanNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool LessThanNullable<T>(T valueToInferType, T? left, T? right) where T : struct => Number.LessThan(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(LessThanNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool LessThanNullableNumber<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Create(left) < right;
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> LessThanCases()
        {
            yield return CreateTestCase<sbyte>(false, sbyte.MinValue, sbyte.MinValue);
            yield return CreateTestCase<sbyte>(true, sbyte.MinValue, sbyte.MaxValue);
            yield return CreateTestCase<byte>(false, byte.MinValue, byte.MinValue);
            yield return CreateTestCase<byte>(true, byte.MinValue, byte.MaxValue);
            yield return CreateTestCase<short>(false, short.MinValue, short.MinValue);
            yield return CreateTestCase<short>(true, short.MinValue, short.MaxValue);
            yield return CreateTestCase<ushort>(false, ushort.MinValue, ushort.MinValue);
            yield return CreateTestCase<ushort>(true, ushort.MinValue, ushort.MaxValue);
            yield return CreateTestCase<int>(false, int.MinValue, int.MinValue);
            yield return CreateTestCase<int>(true, int.MinValue, int.MaxValue);
            yield return CreateTestCase<uint>(false, uint.MinValue, uint.MinValue);
            yield return CreateTestCase<uint>(true, uint.MinValue, uint.MaxValue);
            yield return CreateTestCase<long>(false, long.MinValue, long.MinValue);
            yield return CreateTestCase<long>(true, long.MinValue, long.MaxValue);
            yield return CreateTestCase<ulong>(false, ulong.MinValue, ulong.MinValue);
            yield return CreateTestCase<ulong>(true, ulong.MinValue, ulong.MaxValue);
            yield return CreateTestCase<float>(false, float.MinValue, float.MinValue);
            yield return CreateTestCase<float>(true, float.MinValue, float.MaxValue);
            yield return CreateTestCase<double>(false, double.MinValue, double.MinValue);
            yield return CreateTestCase<double>(true, double.MinValue, double.MaxValue);
            yield return CreateTestCase<decimal>(false, decimal.MinValue, decimal.MinValue);
            yield return CreateTestCase<decimal>(true, decimal.MinValue, decimal.MaxValue);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(false, BigInteger.Zero, BigInteger.Zero);
            yield return CreateTestCase<BigInteger>(true, BigInteger.Zero, BigInteger.One);
#endif
            yield return CreateTestCase<IntWrapper>(false, new IntWrapper(int.MinValue), new IntWrapper(int.MinValue));
            yield return CreateTestCase<IntWrapper>(true, new IntWrapper(int.MinValue), new IntWrapper(int.MaxValue));
        }

        public static IEnumerable<TestCaseData> LessThanNullableCases() => LessThanCases().Concat(BinaryNullableCases(false, false, false));

        [TestCaseSource(nameof(LessThanOrEqualsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool LessThanOrEquals<T>(T valueToInferType, T left, T right) => Number.LessThanOrEquals(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(LessThanOrEqualsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool LessThanOrEqualsNumber<T>(T valueToInferType, T left, T right) => Number.Create(left) <= right;
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(LessThanOrEqualsNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool LessThanOrEqualsNullable<T>(T valueToInferType, T? left, T? right) where T : struct => Number.LessThanOrEquals(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(LessThanOrEqualsNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool LessThanOrEqualsNullableNumber<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Create(left) <= right;
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> LessThanOrEqualsCases()
        {
            yield return CreateTestCase<sbyte>(true, sbyte.MaxValue, sbyte.MaxValue);
            yield return CreateTestCase<sbyte>(false, sbyte.MaxValue, sbyte.MinValue);
            yield return CreateTestCase<byte>(true, byte.MaxValue, byte.MaxValue);
            yield return CreateTestCase<byte>(false, byte.MaxValue, byte.MinValue);
            yield return CreateTestCase<short>(true, short.MaxValue, short.MaxValue);
            yield return CreateTestCase<short>(false, short.MaxValue, short.MinValue);
            yield return CreateTestCase<ushort>(true, ushort.MaxValue, ushort.MaxValue);
            yield return CreateTestCase<ushort>(false, ushort.MaxValue, ushort.MinValue);
            yield return CreateTestCase<int>(true, int.MaxValue, int.MaxValue);
            yield return CreateTestCase<int>(false, int.MaxValue, int.MinValue);
            yield return CreateTestCase<uint>(true, uint.MaxValue, uint.MaxValue);
            yield return CreateTestCase<uint>(false, uint.MaxValue, uint.MinValue);
            yield return CreateTestCase<long>(true, long.MaxValue, long.MaxValue);
            yield return CreateTestCase<long>(false, long.MaxValue, long.MinValue);
            yield return CreateTestCase<ulong>(true, ulong.MaxValue, ulong.MaxValue);
            yield return CreateTestCase<ulong>(false, ulong.MaxValue, ulong.MinValue);
            yield return CreateTestCase<float>(true, float.MaxValue, float.MaxValue);
            yield return CreateTestCase<float>(false, float.MaxValue, float.MinValue);
            yield return CreateTestCase<double>(true, double.MaxValue, double.MaxValue);
            yield return CreateTestCase<double>(false, double.MaxValue, double.MinValue);
            yield return CreateTestCase<decimal>(true, decimal.MaxValue, decimal.MaxValue);
            yield return CreateTestCase<decimal>(false, decimal.MaxValue, decimal.MinValue);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(true, BigInteger.One, BigInteger.One);
            yield return CreateTestCase<BigInteger>(false, BigInteger.One, BigInteger.Zero);
#endif
            yield return CreateTestCase<IntWrapper>(true, new IntWrapper(int.MaxValue), new IntWrapper(int.MaxValue));
            yield return CreateTestCase<IntWrapper>(false, new IntWrapper(int.MaxValue), new IntWrapper(int.MinValue));
        }

        public static IEnumerable<TestCaseData> LessThanOrEqualsNullableCases() => LessThanOrEqualsCases().Concat(BinaryNullableCases(false, false, false));

        [TestCaseSource(nameof(GreaterThanCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool GreaterThan<T>(T valueToInferType, T left, T right) => Number.GreaterThan(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(GreaterThanCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool GreaterThanNumber<T>(T valueToInferType, T left, T right) => Number.Create(left) > right;
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(GreaterThanNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool GreaterThanNullable<T>(T valueToInferType, T? left, T? right) where T : struct => Number.GreaterThan(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(GreaterThanNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool GreaterThanNullableNumber<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Create(left) > right;
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> GreaterThanCases()
        {
            yield return CreateTestCase<sbyte>(false, sbyte.MaxValue, sbyte.MaxValue);
            yield return CreateTestCase<sbyte>(true, sbyte.MaxValue, sbyte.MinValue);
            yield return CreateTestCase<byte>(false, byte.MaxValue, byte.MaxValue);
            yield return CreateTestCase<byte>(true, byte.MaxValue, byte.MinValue);
            yield return CreateTestCase<short>(false, short.MaxValue, short.MaxValue);
            yield return CreateTestCase<short>(true, short.MaxValue, short.MinValue);
            yield return CreateTestCase<ushort>(false, ushort.MaxValue, ushort.MaxValue);
            yield return CreateTestCase<ushort>(true, ushort.MaxValue, ushort.MinValue);
            yield return CreateTestCase<int>(false, int.MaxValue, int.MaxValue);
            yield return CreateTestCase<int>(true, int.MaxValue, int.MinValue);
            yield return CreateTestCase<uint>(false, uint.MaxValue, uint.MaxValue);
            yield return CreateTestCase<uint>(true, uint.MaxValue, uint.MinValue);
            yield return CreateTestCase<long>(false, long.MaxValue, long.MaxValue);
            yield return CreateTestCase<long>(true, long.MaxValue, long.MinValue);
            yield return CreateTestCase<ulong>(false, ulong.MaxValue, ulong.MaxValue);
            yield return CreateTestCase<ulong>(true, ulong.MaxValue, ulong.MinValue);
            yield return CreateTestCase<float>(false, float.MaxValue, float.MaxValue);
            yield return CreateTestCase<float>(true, float.MaxValue, float.MinValue);
            yield return CreateTestCase<double>(false, double.MaxValue, double.MaxValue);
            yield return CreateTestCase<double>(true, double.MaxValue, double.MinValue);
            yield return CreateTestCase<decimal>(false, decimal.MaxValue, decimal.MaxValue);
            yield return CreateTestCase<decimal>(true, decimal.MaxValue, decimal.MinValue);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(false, BigInteger.One, BigInteger.One);
            yield return CreateTestCase<BigInteger>(true, BigInteger.One, BigInteger.Zero);
#endif
            yield return CreateTestCase<IntWrapper>(false, new IntWrapper(int.MaxValue), new IntWrapper(int.MaxValue));
            yield return CreateTestCase<IntWrapper>(true, new IntWrapper(int.MaxValue), new IntWrapper(int.MinValue));
        }

        public static IEnumerable<TestCaseData> GreaterThanNullableCases() => GreaterThanCases().Concat(BinaryNullableCases(false, false, false));

        [TestCaseSource(nameof(GreaterThanOrEqualsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool GreaterThanOrEquals<T>(T valueToInferType, T left, T right) => Number.GreaterThanOrEquals(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(GreaterThanOrEqualsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool GreaterThanOrEqualsNumber<T>(T valueToInferType, T left, T right) => Number.Create(left) >= right;
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(GreaterThanOrEqualsNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool GreaterThanOrEqualsNullable<T>(T valueToInferType, T? left, T? right) where T : struct => Number.GreaterThanOrEquals(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(GreaterThanOrEqualsNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool GreaterThanOrEqualsNullableNumber<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Create(left) >= right;
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> GreaterThanOrEqualsCases()
        {
            yield return CreateTestCase<sbyte>(true, sbyte.MinValue, sbyte.MinValue);
            yield return CreateTestCase<sbyte>(false, sbyte.MinValue, sbyte.MaxValue);
            yield return CreateTestCase<byte>(true, byte.MinValue, byte.MinValue);
            yield return CreateTestCase<byte>(false, byte.MinValue, byte.MaxValue);
            yield return CreateTestCase<short>(true, short.MinValue, short.MinValue);
            yield return CreateTestCase<short>(false, short.MinValue, short.MaxValue);
            yield return CreateTestCase<ushort>(true, ushort.MinValue, ushort.MinValue);
            yield return CreateTestCase<ushort>(false, ushort.MinValue, ushort.MaxValue);
            yield return CreateTestCase<int>(true, int.MinValue, int.MinValue);
            yield return CreateTestCase<int>(false, int.MinValue, int.MaxValue);
            yield return CreateTestCase<uint>(true, uint.MinValue, uint.MinValue);
            yield return CreateTestCase<uint>(false, uint.MinValue, uint.MaxValue);
            yield return CreateTestCase<long>(true, long.MinValue, long.MinValue);
            yield return CreateTestCase<long>(false, long.MinValue, long.MaxValue);
            yield return CreateTestCase<ulong>(true, ulong.MinValue, ulong.MinValue);
            yield return CreateTestCase<ulong>(false, ulong.MinValue, ulong.MaxValue);
            yield return CreateTestCase<float>(true, float.MinValue, float.MinValue);
            yield return CreateTestCase<float>(false, float.MinValue, float.MaxValue);
            yield return CreateTestCase<double>(true, double.MinValue, double.MinValue);
            yield return CreateTestCase<double>(false, double.MinValue, double.MaxValue);
            yield return CreateTestCase<decimal>(true, decimal.MinValue, decimal.MinValue);
            yield return CreateTestCase<decimal>(false, decimal.MinValue, decimal.MaxValue);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(true, BigInteger.Zero, BigInteger.Zero);
            yield return CreateTestCase<BigInteger>(false, BigInteger.Zero, BigInteger.One);
#endif
            yield return CreateTestCase<IntWrapper>(true, new IntWrapper(int.MinValue), new IntWrapper(int.MinValue));
            yield return CreateTestCase<IntWrapper>(false, new IntWrapper(int.MinValue), new IntWrapper(int.MaxValue));
        }

        public static IEnumerable<TestCaseData> GreaterThanOrEqualsNullableCases() => GreaterThanOrEqualsCases().Concat(BinaryNullableCases(false, false, false));

        [TestCaseSource(nameof(AddCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T Add<T>(T valueToInferType, T left, T right) => Number.Add(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(AddCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T AddNumber<T>(T valueToInferType, T left, T right) => Number.Create(left) + right;
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(AddNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? AddNullable<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Add(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(AddNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? AddNullableNumber<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Create(left) + right;
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> AddCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)5, (sbyte)3, (sbyte)2);
            yield return CreateTestCase<byte>((byte)5, (byte)3, (byte)2);
            yield return CreateTestCase<short>((short)5, (short)3, (short)2);
            yield return CreateTestCase<ushort>((ushort)5, (ushort)3, (ushort)2);
            yield return CreateTestCase<int>(5, 3, 2);
            yield return CreateTestCase<uint>(5U, 3U, 2U);
            yield return CreateTestCase<long>(5L, 3L, 2L);
            yield return CreateTestCase<ulong>(5UL, 3UL, 2UL);
            yield return CreateTestCase<float>(5F, 3F, 2F);
            yield return CreateTestCase<double>(5D, 3D, 2D);
            yield return CreateTestCase<decimal>(5M, 3M, 2M);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(5), new BigInteger(3), new BigInteger(2));
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(5), new IntWrapper(3), new IntWrapper(2));
        }

        public static IEnumerable<TestCaseData> AddNullableCases() => AddCases().Concat(BinaryNullableCases());

        [TestCaseSource(nameof(SubtractCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T Subtract<T>(T valueToInferType, T left, T right) => Number.Subtract(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(SubtractCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T SubtractNumber<T>(T valueToInferType, T left, T right) => Number.Create(left) - right;
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(SubtractNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? SubtractNullable<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Subtract(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(SubtractNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? SubtractNullableNumber<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Create(left) - right;
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> SubtractCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)1, (sbyte)3, (sbyte)2);
            yield return CreateTestCase<byte>((byte)1, (byte)3, (byte)2);
            yield return CreateTestCase<short>((short)1, (short)3, (short)2);
            yield return CreateTestCase<ushort>((ushort)1, (ushort)3, (ushort)2);
            yield return CreateTestCase<int>(1, 3, 2);
            yield return CreateTestCase<uint>(1U, 3U, 2U);
            yield return CreateTestCase<long>(1L, 3L, 2L);
            yield return CreateTestCase<ulong>(1UL, 3UL, 2UL);
            yield return CreateTestCase<float>(1F, 3F, 2F);
            yield return CreateTestCase<double>(1D, 3D, 2D);
            yield return CreateTestCase<decimal>(1M, 3M, 2M);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(1), new BigInteger(3), new BigInteger(2));
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(1), new IntWrapper(3), new IntWrapper(2));
        }

        public static IEnumerable<TestCaseData> SubtractNullableCases() => SubtractCases().Concat(BinaryNullableCases());

        [TestCaseSource(nameof(MultiplyCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T Multiply<T>(T valueToInferType, T left, T right) => Number.Multiply(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(MultiplyCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T MultiplyNumber<T>(T valueToInferType, T left, T right) => Number.Create(left) * right;
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(MultiplyNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? MultiplyNullable<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Multiply(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(MultiplyNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? MultiplyNullableNumber<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Create(left) * right;
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> MultiplyCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)6, (sbyte)3, (sbyte)2);
            yield return CreateTestCase<byte>((byte)6, (byte)3, (byte)2);
            yield return CreateTestCase<short>((short)6, (short)3, (short)2);
            yield return CreateTestCase<ushort>((ushort)6, (ushort)3, (ushort)2);
            yield return CreateTestCase<int>(6, 3, 2);
            yield return CreateTestCase<uint>(6U, 3U, 2U);
            yield return CreateTestCase<long>(6L, 3L, 2L);
            yield return CreateTestCase<ulong>(6UL, 3UL, 2UL);
            yield return CreateTestCase<float>(6F, 3F, 2F);
            yield return CreateTestCase<double>(6D, 3D, 2D);
            yield return CreateTestCase<decimal>(6M, 3M, 2M);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(6), new BigInteger(3), new BigInteger(2));
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(6), new IntWrapper(3), new IntWrapper(2));
        }

        public static IEnumerable<TestCaseData> MultiplyNullableCases() => MultiplyCases().Concat(BinaryNullableCases());

        [TestCaseSource(nameof(DivideCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T Divide<T>(T valueToInferType, T left, T right) => Number.Divide(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(DivideCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T DivideNumber<T>(T valueToInferType, T left, T right) => Number.Create(left) / right;
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(DivideNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? DivideNullable<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Divide(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(DivideNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? DivideNullableNumber<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Create(left) / right;
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> DivideCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)3, (sbyte)6, (sbyte)2);
            yield return CreateTestCase<byte>((byte)3, (byte)6, (byte)2);
            yield return CreateTestCase<short>((short)3, (short)6, (short)2);
            yield return CreateTestCase<ushort>((ushort)3, (ushort)6, (ushort)2);
            yield return CreateTestCase<int>(3, 6, 2);
            yield return CreateTestCase<uint>(3U, 6U, 2U);
            yield return CreateTestCase<long>(3L, 6L, 2L);
            yield return CreateTestCase<ulong>(3UL, 6UL, 2UL);
            yield return CreateTestCase<float>(3F, 6F, 2F);
            yield return CreateTestCase<double>(3D, 6D, 2D);
            yield return CreateTestCase<decimal>(3M, 6M, 2M);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(3), new BigInteger(6), new BigInteger(2));
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(3), new IntWrapper(6), new IntWrapper(2));
        }

        public static IEnumerable<TestCaseData> DivideNullableCases() => DivideCases().Concat(BinaryNullableCases());

        [TestCaseSource(nameof(RemainderCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T Remainder<T>(T valueToInferType, T left, T right) => Number.Remainder(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(RemainderCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T RemainderNumber<T>(T valueToInferType, T left, T right) => Number.Create(left) % right;
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(RemainderNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? RemainderNullable<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Remainder(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(RemainderNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? RemainderNullableNumber<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Create(left) % right;
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> RemainderCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)2, (sbyte)5, (sbyte)3);
            yield return CreateTestCase<byte>((byte)2, (byte)5, (byte)3);
            yield return CreateTestCase<short>((short)2, (short)5, (short)3);
            yield return CreateTestCase<ushort>((ushort)2, (ushort)5, (ushort)3);
            yield return CreateTestCase<int>(2, 5, 3);
            yield return CreateTestCase<uint>(2U, 5U, 3U);
            yield return CreateTestCase<long>(2L, 5L, 3L);
            yield return CreateTestCase<ulong>(2UL, 5UL, 3UL);
            yield return CreateTestCase<float>(2F, 5F, 3F);
            yield return CreateTestCase<double>(2D, 5D, 3D);
            yield return CreateTestCase<decimal>(2M, 5M, 3M);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(2), new BigInteger(5), new BigInteger(3));
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(2), new IntWrapper(5), new IntWrapper(3));
        }

        public static IEnumerable<TestCaseData> RemainderNullableCases() => RemainderCases().Concat(BinaryNullableCases());

        [TestCaseSource(nameof(NegateCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T Negate<T>(T valueToInferType, T value) => Number.Negate(value);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(NegateCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T NegateNumber<T>(T valueToInferType, T value) => -Number.Create(value);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(NegateNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? NegateNullable<T>(T valueToInferType, T? value) where T : struct => Number.Negate(value);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(NegateNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? NegateNullableNumber<T>(T valueToInferType, T? value) where T : struct => -Number.Create(value);
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> NegateCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)-3, (sbyte)3);
            yield return CreateTestCase<sbyte>((sbyte)2, (sbyte)-2);
            yield return CreateTestCase<short>((short)-3, (short)3);
            yield return CreateTestCase<short>((short)2, (short)-2);
            yield return CreateTestCase<int>(-3, 3);
            yield return CreateTestCase<int>(2, -2);
            yield return CreateTestCase<long>(-3L, 3L);
            yield return CreateTestCase<long>(2L, -2L);
            yield return CreateTestCase<float>(-3F, 3F);
            yield return CreateTestCase<float>(2F, -2F);
            yield return CreateTestCase<double>(-3D, 3D);
            yield return CreateTestCase<double>(2D, -2D);
            yield return CreateTestCase<decimal>(-3M, 3M);
            yield return CreateTestCase<decimal>(2M, -2M);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(-3), new BigInteger(3));
            yield return CreateTestCase<BigInteger>(new BigInteger(2), new BigInteger(-2));
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(-3), new IntWrapper(3));
            yield return CreateTestCase<IntWrapper>(new IntWrapper(2), new IntWrapper(-2));
        }

        public static IEnumerable<TestCaseData> NegateNullableCases() => NegateCases().Concat(UnaryNullableCases(types: Types.Signed));

        [TestCaseSource(nameof(NegateThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void NegateThrows<T>(T valueToInferType, T value) => Assert.Throws<NotSupportedException>(() => Number.Negate(value));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(NegateThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void NegateThrowsNumber<T>(T valueToInferType, T value) => Assert.Throws<NotSupportedException>(() => _ = -Number.Create(value));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(NegateThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void NegateNullableThrows<T>(T valueToInferType, T? value) where T : struct => Assert.Throws<NotSupportedException>(() => Number.Negate(value));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(NegateThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void NegateNullableThrowsNumber<T>(T valueToInferType, T? value) where T : struct => Assert.Throws<NotSupportedException>(() => _ = -Number.Create(value));
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> NegateThrowsCases()
        {
            yield return CreateTestCase<byte>(new object[] { (byte)3 });
            yield return CreateTestCase<ushort>(new object[] { (ushort)3 });
            yield return CreateTestCase<uint>(new object[] { (uint)3 });
            yield return CreateTestCase<ulong>(new object[] { (ulong)3 });
        }

        [TestCaseSource(nameof(MaxCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T Max<T>(T valueToInferType, T left, T right) => Number.Max(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(MaxNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? MaxNullable<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Max(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> MaxCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)3, (sbyte)3, (sbyte)2);
            yield return CreateTestCase<byte>((byte)3, (byte)3, (byte)2);
            yield return CreateTestCase<short>((short)3, (short)3, (short)2);
            yield return CreateTestCase<ushort>((ushort)3, (ushort)3, (ushort)2);
            yield return CreateTestCase<int>(3, 3, 2);
            yield return CreateTestCase<uint>(3U, 3U, 2U);
            yield return CreateTestCase<long>(3L, 3L, 2L);
            yield return CreateTestCase<ulong>(3UL, 3UL, 2UL);
            yield return CreateTestCase<float>(3F, 3F, 2F);
            yield return CreateTestCase<double>(3D, 3D, 2D);
            yield return CreateTestCase<decimal>(3M, 3M, 2M);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(3), new BigInteger(3), new BigInteger(2));
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(3), new IntWrapper(3), new IntWrapper(2));
        }

        public static IEnumerable<TestCaseData> MaxNullableCases() => MaxCases().Concat(BinaryNullableCases());

        [TestCaseSource(nameof(MinCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T Min<T>(T valueToInferType, T left, T right) => Number.Min(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(MinNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? MinNullable<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Min(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> MinCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)2, (sbyte)3, (sbyte)2);
            yield return CreateTestCase<byte>((byte)2, (byte)3, (byte)2);
            yield return CreateTestCase<short>((short)2, (short)3, (short)2);
            yield return CreateTestCase<ushort>((ushort)2, (ushort)3, (ushort)2);
            yield return CreateTestCase<int>(2, 3, 2);
            yield return CreateTestCase<uint>(2U, 3U, 2U);
            yield return CreateTestCase<long>(2L, 3L, 2L);
            yield return CreateTestCase<ulong>(2UL, 3UL, 2UL);
            yield return CreateTestCase<float>(2F, 3F, 2F);
            yield return CreateTestCase<double>(2D, 3D, 2D);
            yield return CreateTestCase<decimal>(2M, 3M, 2M);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(2), new BigInteger(3), new BigInteger(2));
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(2), new IntWrapper(3), new IntWrapper(2));
        }

        public static IEnumerable<TestCaseData> MinNullableCases() => MinCases().Concat(BinaryNullableCases());

        [TestCaseSource(nameof(AndCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T And<T>(T valueToInferType, T left, T right) => Number.And(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(AndCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T AndNumber<T>(T valueToInferType, T left, T right) => Number.Create(left) & right;
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(AndNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? AndNullable<T>(T valueToInferType, T? left, T? right) where T : struct => Number.And(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(AndNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? AndNullableNumber<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Create(left) & right;
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> AndCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)2, (sbyte)3, (sbyte)6);
            yield return CreateTestCase<byte>((byte)2, (byte)3, (byte)6);
            yield return CreateTestCase<short>((short)2, (short)3, (short)6);
            yield return CreateTestCase<ushort>((ushort)2, (ushort)3, (ushort)6);
            yield return CreateTestCase<int>(2, 3, 6);
            yield return CreateTestCase<uint>(2U, 3U, 6U);
            yield return CreateTestCase<long>(2L, 3L, 6L);
            yield return CreateTestCase<ulong>(2UL, 3UL, 6UL);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(2), new BigInteger(3), new BigInteger(6));
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(2), new IntWrapper(3), new IntWrapper(6));
        }

        public static IEnumerable<TestCaseData> AndNullableCases() => AndCases().Concat(BinaryNullableCases(types: Types.Integral));

        [TestCaseSource(nameof(BinaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void AndThrows<T>(T valueToInferType, T left, T right) => Assert.Throws<NotSupportedException>(() => Number.And(left, right));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(BinaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void AndThrowsNumber<T>(T valueToInferType, T left, T right) => Assert.Throws<NotSupportedException>(() => _ = Number.Create(left) & right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(BinaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void AndNullableThrows<T>(T valueToInferType, T? left, T? right) where T : struct => Assert.Throws<NotSupportedException>(() => Number.And(left, right));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(BinaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void AndNullableThrowsNumber<T>(T valueToInferType, T? left, T? right) where T : struct => Assert.Throws<NotSupportedException>(() => _ = Number.Create(left) & right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(OrCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T Or<T>(T valueToInferType, T left, T right) => Number.Or(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(OrCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T OrNumber<T>(T valueToInferType, T left, T right) => Number.Create(left) | right;
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(OrNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? OrNullable<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Or(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(OrNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? OrNullableNumber<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Create(left) | right;
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> OrCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)7, (sbyte)3, (sbyte)5);
            yield return CreateTestCase<byte>((byte)7, (byte)3, (byte)5);
            yield return CreateTestCase<short>((short)7, (short)3, (short)5);
            yield return CreateTestCase<ushort>((ushort)7, (ushort)3, (ushort)5);
            yield return CreateTestCase<int>(7, 3, 5);
            yield return CreateTestCase<uint>(7U, 3U, 5U);
            yield return CreateTestCase<long>(7L, 3L, 5L);
            yield return CreateTestCase<ulong>(7UL, 3UL, 5UL);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(7), new BigInteger(3), new BigInteger(5));
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(7), new IntWrapper(3), new IntWrapper(5));
        }

        public static IEnumerable<TestCaseData> OrNullableCases() => OrCases().Concat(BinaryNullableCases(types: Types.Integral));

        [TestCaseSource(nameof(BinaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void OrThrows<T>(T valueToInferType, T left, T right) => Assert.Throws<NotSupportedException>(() => Number.Or(left, right));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(BinaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void OrThrowsNumber<T>(T valueToInferType, T left, T right) => Assert.Throws<NotSupportedException>(() => _ = Number.Create(left) | right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(BinaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void OrNullableThrows<T>(T valueToInferType, T? left, T? right) where T : struct => Assert.Throws<NotSupportedException>(() => Number.Or(left, right));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(BinaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void OrNullableThrowsNumber<T>(T valueToInferType, T? left, T? right) where T : struct => Assert.Throws<NotSupportedException>(() => _ = Number.Create(left) | right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(XorCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T Xor<T>(T valueToInferType, T left, T right) => Number.Xor(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(XorCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T XorNumber<T>(T valueToInferType, T left, T right) => Number.Create(left) ^ right;
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(XorNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? XorNullable<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Xor(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(XorNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? XorNullableNumber<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Create(left) ^ right;
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> XorCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)6, (sbyte)3, (sbyte)5);
            yield return CreateTestCase<byte>((byte)6, (byte)3, (byte)5);
            yield return CreateTestCase<short>((short)6, (short)3, (short)5);
            yield return CreateTestCase<ushort>((ushort)6, (ushort)3, (ushort)5);
            yield return CreateTestCase<int>(6, 3, 5);
            yield return CreateTestCase<uint>(6U, 3U, 5U);
            yield return CreateTestCase<long>(6L, 3L, 5L);
            yield return CreateTestCase<ulong>(6UL, 3UL, 5UL);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(6), new BigInteger(3), new BigInteger(5));
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(6), new IntWrapper(3), new IntWrapper(5));
        }

        public static IEnumerable<TestCaseData> XorNullableCases() => XorCases().Concat(BinaryNullableCases(types: Types.Integral));

        [TestCaseSource(nameof(BinaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void XorThrows<T>(T valueToInferType, T left, T right) => Assert.Throws<NotSupportedException>(() => Number.Xor(left, right));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(BinaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void XorThrowsNumber<T>(T valueToInferType, T left, T right) => Assert.Throws<NotSupportedException>(() => _ = Number.Create(left) ^ right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(BinaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void XorNullableThrows<T>(T valueToInferType, T? left, T? right) where T : struct => Assert.Throws<NotSupportedException>(() => Number.Xor(left, right));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(BinaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void XorNullableThrowsNumber<T>(T valueToInferType, T? left, T? right) where T : struct => Assert.Throws<NotSupportedException>(() => _ = Number.Create(left) ^ right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(NotCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T Not<T>(T valueToInferType, T value) => Number.Not(value);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(NotCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T NotNumber<T>(T valueToInferType, T value) => ~Number.Create(value);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(NotNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? NotNullable<T>(T valueToInferType, T? value) where T : struct => Number.Not(value);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(NotNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? NotNullableNumber<T>(T valueToInferType, T? value) where T : struct => ~Number.Create(value);
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> NotCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)-4, (sbyte)3);
            yield return CreateTestCase<sbyte>((sbyte)1, (sbyte)-2);
            yield return CreateTestCase<byte>((byte)252, (byte)3);
            yield return CreateTestCase<byte>((byte)1, (byte)254);
            yield return CreateTestCase<short>((short)-4, (short)3);
            yield return CreateTestCase<short>((short)1, (short)-2);
            yield return CreateTestCase<ushort>((ushort)65532, (ushort)3);
            yield return CreateTestCase<ushort>((ushort)1, (ushort)65534);
            yield return CreateTestCase<int>(-4, 3);
            yield return CreateTestCase<int>(1, -2);
            yield return CreateTestCase<uint>(4294967292U, 3U);
            yield return CreateTestCase<uint>(1U, 4294967294U);
            yield return CreateTestCase<long>(-4L, 3L);
            yield return CreateTestCase<long>(1L, -2L);
            yield return CreateTestCase<ulong>(18446744073709551612UL, 3UL);
            yield return CreateTestCase<ulong>(1UL, 18446744073709551614UL);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(-4), new BigInteger(3));
            yield return CreateTestCase<BigInteger>(new BigInteger(1), new BigInteger(-2));
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(-4), new IntWrapper(3));
            yield return CreateTestCase<IntWrapper>(new IntWrapper(1), new IntWrapper(-2));
        }

        public static IEnumerable<TestCaseData> NotNullableCases() => NotCases().Concat(UnaryNullableCases(types: Types.Integral));

        [TestCaseSource(nameof(UnaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void NotThrows<T>(T valueToInferType, T value) => Assert.Throws<NotSupportedException>(() => Number.Not(value));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(UnaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void NotThrowsNumber<T>(T valueToInferType, T value) => Assert.Throws<NotSupportedException>(() => _ = ~Number.Create(value));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(UnaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void NotNullableThrows<T>(T valueToInferType, T? value) where T : struct => Assert.Throws<NotSupportedException>(() => Number.Not(value));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(UnaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void NotNullableThrowsNumber<T>(T valueToInferType, T? value) where T : struct => Assert.Throws<NotSupportedException>(() => _ = ~Number.Create(value));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(LeftShiftCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T LeftShift<T>(T valueToInferType, T value, int shift) => Number.LeftShift(value, shift);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(LeftShiftCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T LeftShiftNumber<T>(T valueToInferType, T value, int shift) => Number.Create(value) << shift;
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(LeftShiftNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? LeftShiftNullable<T>(T valueToInferType, T? value, int shift) where T : struct => Number.LeftShift(value, shift);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(LeftShiftNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? LeftShiftNullableNumber<T>(T valueToInferType, T? value, int shift) where T : struct => Number.Create(value) << shift;
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> LeftShiftCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)12, (sbyte)3, 2);
            yield return CreateTestCase<byte>((byte)12, (byte)3, 2);
            yield return CreateTestCase<short>((short)12, (short)3, 2);
            yield return CreateTestCase<ushort>((ushort)12, (ushort)3, 2);
            yield return CreateTestCase<int>(12, 3, 2);
            yield return CreateTestCase<uint>(12U, 3U, 2);
            yield return CreateTestCase<long>(12L, 3L, 2);
            yield return CreateTestCase<ulong>(12UL, 3UL, 2);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(12), new BigInteger(3), 2);
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(12), new IntWrapper(3), 2);
        }

        [TestCaseSource(nameof(ShiftThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void LeftShiftThrows<T>(T valueToInferType, T value, int shift) => Assert.Throws<NotSupportedException>(() => Number.LeftShift(value, shift));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ShiftThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void LeftShiftThrowsNumber<T>(T valueToInferType, T value, int shift) => Assert.Throws<NotSupportedException>(() => _ = Number.Create(value) << shift);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ShiftThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void LeftShiftNullableThrows<T>(T valueToInferType, T? value, int shift) where T : struct => Assert.Throws<NotSupportedException>(() => Number.LeftShift(value, shift));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ShiftThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void LeftShiftNullableThrowsNumber<T>(T valueToInferType, T? value, int shift) where T : struct => Assert.Throws<NotSupportedException>(() => _ = Number.Create(value) << shift);
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> LeftShiftNullableCases() => LeftShiftCases().Concat(UnaryNullableCases(null, Types.Integral, 2));

        [TestCaseSource(nameof(RightShiftCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T RightShift<T>(T valueToInferType, T value, int shift) => Number.RightShift(value, shift);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(RightShiftCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T RightShiftNumber<T>(T valueToInferType, T value, int shift) => Number.Create(value) >> shift;
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(RightShiftNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? RightShiftNullable<T>(T valueToInferType, T? value, int shift) where T : struct => Number.RightShift(value, shift);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(RightShiftNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? RightShiftNullableNumber<T>(T valueToInferType, T? value, int shift) where T : struct => Number.Create(value) >> shift;
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> RightShiftCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)3, (sbyte)13, 2);
            yield return CreateTestCase<byte>((byte)3, (byte)13, 2);
            yield return CreateTestCase<short>((short)3, (short)13, 2);
            yield return CreateTestCase<ushort>((ushort)3, (ushort)13, 2);
            yield return CreateTestCase<int>(3, 13, 2);
            yield return CreateTestCase<uint>(3U, 13U, 2);
            yield return CreateTestCase<long>(3L, 13L, 2);
            yield return CreateTestCase<ulong>(3UL, 13UL, 2);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(3), new BigInteger(13), 2);
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(3), new IntWrapper(13), 2);
        }

        [TestCaseSource(nameof(ShiftThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void RightShiftThrows<T>(T valueToInferType, T value, int shift) => Assert.Throws<NotSupportedException>(() => Number.RightShift(value, shift));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ShiftThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void RightShiftThrowsNumber<T>(T valueToInferType, T value, int shift) => Assert.Throws<NotSupportedException>(() => _ = Number.Create(value) >> shift);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ShiftThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void RightShiftNullableThrows<T>(T valueToInferType, T? value, int shift) where T : struct => Assert.Throws<NotSupportedException>(() => Number.RightShift(value, shift));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ShiftThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void RightShiftNullableThrowsNumber<T>(T valueToInferType, T? value, int shift) where T : struct => Assert.Throws<NotSupportedException>(() => _ = Number.Create(value) >> shift);
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> RightShiftNullableCases() => RightShiftCases().Concat(UnaryNullableCases(null, Types.Integral, 2));

        public static IEnumerable<TestCaseData> ShiftThrowsCases()
        {
            yield return CreateTestCase<float>(new object[] { 3F, 2 });
            yield return CreateTestCase<double>(new object[] { 3D, 2 });
            yield return CreateTestCase<decimal>(new object[] { 3M, 2 });
        }

        [TestCaseSource(nameof(IsEvenCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool IsEven<T>(T valueToInferType, T value) => Number.IsEven(value);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(IsEvenNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool IsEvenNullable<T>(T valueToInferType, T? value) where T : struct => Number.IsEven(value);
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> IsEvenCases()
        {
            yield return CreateTestCase<sbyte>(false, (sbyte)3);
            yield return CreateTestCase<sbyte>(true, (sbyte)2);
            yield return CreateTestCase<byte>(false, (byte)3);
            yield return CreateTestCase<byte>(true, (byte)254);
            yield return CreateTestCase<short>(false, (short)3);
            yield return CreateTestCase<short>(true, (short)2);
            yield return CreateTestCase<ushort>(false, (ushort)3);
            yield return CreateTestCase<ushort>(true, (ushort)65534);
            yield return CreateTestCase<int>(false, 3);
            yield return CreateTestCase<int>(true, 2);
            yield return CreateTestCase<uint>(false, 3U);
            yield return CreateTestCase<uint>(true, 4294967294U);
            yield return CreateTestCase<long>(false, 3L);
            yield return CreateTestCase<long>(true, 2L);
            yield return CreateTestCase<ulong>(false, 3UL);
            yield return CreateTestCase<ulong>(true, 18446744073709551614UL);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(false, new BigInteger(3));
            yield return CreateTestCase<BigInteger>(true, new BigInteger(2));
#endif
            yield return CreateTestCase<IntWrapper>(false, new IntWrapper(3));
            yield return CreateTestCase<IntWrapper>(true, new IntWrapper(2));
        }

        public static IEnumerable<TestCaseData> IsEvenNullableCases() => IsEvenCases().Concat(UnaryNullableCases(false, types: Types.Integral));

        [TestCaseSource(nameof(UnaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void IsEvenThrows<T>(T valueToInferType, T value) => Assert.Throws<NotSupportedException>(() => Number.IsEven(value));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(UnaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void IsEvenNullableThrows<T>(T valueToInferType, T? value) where T : struct => Assert.Throws<NotSupportedException>(() => Number.IsEven(value));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(IsOddCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool IsOdd<T>(T valueToInferType, T value) => Number.IsOdd(value);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(IsOddNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool IsOddNullable<T>(T valueToInferType, T? value) where T : struct => Number.IsOdd(value);
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> IsOddCases()
        {
            yield return CreateTestCase<sbyte>(true, (sbyte)3);
            yield return CreateTestCase<sbyte>(false, (sbyte)2);
            yield return CreateTestCase<byte>(true, (byte)3);
            yield return CreateTestCase<byte>(false, (byte)254);
            yield return CreateTestCase<short>(true, (short)3);
            yield return CreateTestCase<short>(false, (short)2);
            yield return CreateTestCase<ushort>(true, (ushort)3);
            yield return CreateTestCase<ushort>(false, (ushort)65534);
            yield return CreateTestCase<int>(true, 3);
            yield return CreateTestCase<int>(false, 2);
            yield return CreateTestCase<uint>(true, 3U);
            yield return CreateTestCase<uint>(false, 4294967294U);
            yield return CreateTestCase<long>(true, 3L);
            yield return CreateTestCase<long>(false, 2L);
            yield return CreateTestCase<ulong>(true, 3UL);
            yield return CreateTestCase<ulong>(false, 18446744073709551614UL);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(true, new BigInteger(3));
            yield return CreateTestCase<BigInteger>(false, new BigInteger(2));
#endif
            yield return CreateTestCase<IntWrapper>(true, new IntWrapper(3));
            yield return CreateTestCase<IntWrapper>(false, new IntWrapper(2));
        }

        public static IEnumerable<TestCaseData> IsOddNullableCases() => IsOddCases().Concat(UnaryNullableCases(false, types: Types.Integral));

        [TestCaseSource(nameof(UnaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void IsOddThrows<T>(T valueToInferType, T value) => Assert.Throws<NotSupportedException>(() => Number.IsOdd(value));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(UnaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void IsOddNullableThrows<T>(T valueToInferType, T? value) where T : struct => Assert.Throws<NotSupportedException>(() => Number.IsOdd(value));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(IsPowerOfTwoCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool IsPowerOfTwo<T>(T valueToInferType, T value) => Number.IsPowerOfTwo(value);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(IsPowerOfTwoNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public bool IsPowerOfTwoNullable<T>(T valueToInferType, T? value) where T : struct => Number.IsPowerOfTwo(value);
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> IsPowerOfTwoCases()
        {
            yield return CreateTestCase<sbyte>(false, (sbyte)3);
            yield return CreateTestCase<sbyte>(true, (sbyte)2);
            yield return CreateTestCase<byte>(false, (byte)3);
            yield return CreateTestCase<byte>(true, (byte)2);
            yield return CreateTestCase<short>(false, (short)3);
            yield return CreateTestCase<short>(true, (short)2);
            yield return CreateTestCase<ushort>(false, (ushort)3);
            yield return CreateTestCase<ushort>(true, (ushort)2);
            yield return CreateTestCase<int>(false, 3);
            yield return CreateTestCase<int>(true, 2);
            yield return CreateTestCase<uint>(false, 3U);
            yield return CreateTestCase<uint>(true, 2U);
            yield return CreateTestCase<long>(false, 3L);
            yield return CreateTestCase<long>(true, 2L);
            yield return CreateTestCase<ulong>(false, 3UL);
            yield return CreateTestCase<ulong>(true, 2UL);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(false, new BigInteger(3));
            yield return CreateTestCase<BigInteger>(true, new BigInteger(2));
#endif
            yield return CreateTestCase<IntWrapper>(false, new IntWrapper(3));
            yield return CreateTestCase<IntWrapper>(true, new IntWrapper(2));
        }

        public static IEnumerable<TestCaseData> IsPowerOfTwoNullableCases() => IsPowerOfTwoCases().Concat(UnaryNullableCases(false, types: Types.Integral));

        [TestCaseSource(nameof(UnaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void IsPowerOfTwoThrows<T>(T valueToInferType, T value) => Assert.Throws<NotSupportedException>(() => Number.IsPowerOfTwo(value));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(UnaryBitwiseThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void IsPowerOfTwoNullableThrows<T>(T valueToInferType, T? value) where T : struct => Assert.Throws<NotSupportedException>(() => Number.IsPowerOfTwo(value));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(SignCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public int Sign<T>(T valueToInferType, T value) => Number.Sign(value);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(SignNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public int SignNullable<T>(T valueToInferType, T? value) where T : struct => Number.Sign(value);
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> SignCases()
        {
            yield return CreateTestCase<sbyte>(1, (sbyte)3);
            yield return CreateTestCase<sbyte>(0, (sbyte)0);
            yield return CreateTestCase<sbyte>(-1, (sbyte)-2);
            yield return CreateTestCase<byte>(1, (byte)3);
            yield return CreateTestCase<byte>(0, (byte)0);
            yield return CreateTestCase<short>(1, (short)3);
            yield return CreateTestCase<short>(0, (short)0);
            yield return CreateTestCase<short>(-1, (short)-2);
            yield return CreateTestCase<ushort>(1, (ushort)3);
            yield return CreateTestCase<ushort>(0, (ushort)0);
            yield return CreateTestCase<int>(1, 3);
            yield return CreateTestCase<int>(0, 0);
            yield return CreateTestCase<int>(-1, -2);
            yield return CreateTestCase<uint>(1, 3U);
            yield return CreateTestCase<uint>(0, 0U);
            yield return CreateTestCase<long>(1, 3L);
            yield return CreateTestCase<long>(0, 0L);
            yield return CreateTestCase<long>(-1, -2L);
            yield return CreateTestCase<ulong>(1, 3UL);
            yield return CreateTestCase<ulong>(0, 0UL);
            yield return CreateTestCase<float>(1, 3F);
            yield return CreateTestCase<float>(0, 0F);
            yield return CreateTestCase<float>(-1, -2F);
            yield return CreateTestCase<double>(1, 3D);
            yield return CreateTestCase<double>(0, 0D);
            yield return CreateTestCase<double>(-1, -2D);
            yield return CreateTestCase<decimal>(1, 3M);
            yield return CreateTestCase<decimal>(0, 0M);
            yield return CreateTestCase<decimal>(-1, -2M);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(1, new BigInteger(3));
            yield return CreateTestCase<BigInteger>(0, new BigInteger(0));
            yield return CreateTestCase<BigInteger>(-1, new BigInteger(-2));
#endif
            yield return CreateTestCase<IntWrapper>(1, new IntWrapper(3));
            yield return CreateTestCase<IntWrapper>(0, new IntWrapper(0));
            yield return CreateTestCase<IntWrapper>(-1, new IntWrapper(-2));
        }

        public static IEnumerable<TestCaseData> SignNullableCases() => SignCases().Concat(UnaryNullableCases(-2));

        [TestCaseSource(nameof(AbsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T Abs<T>(T valueToInferType, T value) => Number.Abs(value);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(AbsNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? AbsNullable<T>(T valueToInferType, T? value) where T : struct => Number.Abs(value);
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> AbsCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)3, (sbyte)3);
            yield return CreateTestCase<sbyte>((sbyte)2, (sbyte)-2);
            yield return CreateTestCase<byte>((byte)3, (byte)3);
            yield return CreateTestCase<short>((short)3, (short)3);
            yield return CreateTestCase<short>((short)2, (short)-2);
            yield return CreateTestCase<ushort>((ushort)3, (ushort)3);
            yield return CreateTestCase<int>(3, 3);
            yield return CreateTestCase<int>(2, -2);
            yield return CreateTestCase<uint>(3U, 3U);
            yield return CreateTestCase<long>(3L, 3L);
            yield return CreateTestCase<long>(2L, -2L);
            yield return CreateTestCase<ulong>(3UL, 3UL);
            yield return CreateTestCase<float>(3F, 3F);
            yield return CreateTestCase<float>(2F, -2F);
            yield return CreateTestCase<double>(3D, 3D);
            yield return CreateTestCase<double>(2D, -2D);
            yield return CreateTestCase<decimal>(3M, 3M);
            yield return CreateTestCase<decimal>(2M, -2M);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(3), new BigInteger(3));
            yield return CreateTestCase<BigInteger>(new BigInteger(2), new BigInteger(-2));
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(3), new IntWrapper(3));
            yield return CreateTestCase<IntWrapper>(new IntWrapper(2), new IntWrapper(-2));
        }

        public static IEnumerable<TestCaseData> AbsNullableCases() => AbsCases().Concat(UnaryNullableCases());

        [TestCaseSource(nameof(FloorCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T Floor<T>(T valueToInferType, T value) => Number.Floor(value);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(FloorNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? FloorNullable<T>(T valueToInferType, T? value) where T : struct => Number.Floor(value);
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> FloorCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)3, (sbyte)3);
            yield return CreateTestCase<byte>((byte)3, (byte)3);
            yield return CreateTestCase<short>((short)3, (short)3);
            yield return CreateTestCase<ushort>((ushort)3, (ushort)3);
            yield return CreateTestCase<int>(3, 3);
            yield return CreateTestCase<uint>(3U, 3U);
            yield return CreateTestCase<long>(3L, 3L);
            yield return CreateTestCase<ulong>(3UL, 3UL);
            yield return CreateTestCase<float>(3F, 3.9F);
            yield return CreateTestCase<float>(-3F, -2.9F);
            yield return CreateTestCase<double>(3D, 3.9);
            yield return CreateTestCase<double>(-3D, -2.9);
            yield return CreateTestCase<decimal>(3M, 3.9M);
            yield return CreateTestCase<decimal>(-3M, -2.9M);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(3), new BigInteger(3));
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(3), new IntWrapper(3));
        }

        public static IEnumerable<TestCaseData> FloorNullableCases() => FloorCases().Concat(UnaryNullableCases());

        [TestCaseSource(nameof(CeilingCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T Ceiling<T>(T valueToInferType, T value) => Number.Ceiling(value);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(CeilingNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? CeilingNullable<T>(T valueToInferType, T? value) where T : struct => Number.Ceiling(value);
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> CeilingCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)3, (sbyte)3);
            yield return CreateTestCase<byte>((byte)3, (byte)3);
            yield return CreateTestCase<short>((short)3, (short)3);
            yield return CreateTestCase<ushort>((ushort)3, (ushort)3);
            yield return CreateTestCase<int>(3, 3);
            yield return CreateTestCase<uint>(3U, 3U);
            yield return CreateTestCase<long>(3L, 3L);
            yield return CreateTestCase<ulong>(3UL, 3UL);
            yield return CreateTestCase<float>(4F, 3.9F);
            yield return CreateTestCase<float>(-2F, -2.9F);
            yield return CreateTestCase<double>(4D, 3.9);
            yield return CreateTestCase<double>(-2D, -2.9);
            yield return CreateTestCase<decimal>(4M, 3.9M);
            yield return CreateTestCase<decimal>(-2M, -2.9M);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(3), new BigInteger(3));
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(3), new IntWrapper(3));
        }

        public static IEnumerable<TestCaseData> CeilingNullableCases() => CeilingCases().Concat(UnaryNullableCases());

        [TestCaseSource(nameof(TruncateCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T Truncate<T>(T valueToInferType, T value) => Number.Truncate(value);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(TruncateNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? TruncateNullable<T>(T valueToInferType, T? value) where T : struct => Number.Truncate(value);
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> TruncateCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)3, (sbyte)3);
            yield return CreateTestCase<byte>((byte)3, (byte)3);
            yield return CreateTestCase<short>((short)3, (short)3);
            yield return CreateTestCase<ushort>((ushort)3, (ushort)3);
            yield return CreateTestCase<int>(3, 3);
            yield return CreateTestCase<uint>(3U, 3U);
            yield return CreateTestCase<long>(3L, 3L);
            yield return CreateTestCase<ulong>(3UL, 3UL);
            yield return CreateTestCase<float>(3F, 3.9F);
            yield return CreateTestCase<float>(-2F, -2.9F);
            yield return CreateTestCase<double>(3D, 3.9);
            yield return CreateTestCase<double>(-2D, -2.9);
            yield return CreateTestCase<decimal>(3M, 3.9M);
            yield return CreateTestCase<decimal>(-2M, -2.9M);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(3), new BigInteger(3));
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(3), new IntWrapper(3));
        }

        public static IEnumerable<TestCaseData> TruncateNullableCases() => TruncateCases().Concat(UnaryNullableCases());

        [TestCaseSource(nameof(RoundCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T Round<T>(T valueToInferType, T value, int digits, MidpointRounding mode) => Number.Round(value, digits, mode);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(RoundNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? RoundNullable<T>(T valueToInferType, T? value, int digits, MidpointRounding mode) where T : struct => Number.Round(value, digits, mode);
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> RoundCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)3, (sbyte)3, 0, MidpointRounding.ToEven);
            yield return CreateTestCase<byte>((byte)3, (byte)3, 0, MidpointRounding.ToEven);
            yield return CreateTestCase<short>((short)3, (short)3, 0, MidpointRounding.ToEven);
            yield return CreateTestCase<ushort>((ushort)3, (ushort)3, 0, MidpointRounding.ToEven);
            yield return CreateTestCase<int>(3, 3, 0, MidpointRounding.ToEven);
            yield return CreateTestCase<uint>(3U, 3U, 0, MidpointRounding.ToEven);
            yield return CreateTestCase<long>(3L, 3L, 0, MidpointRounding.ToEven);
            yield return CreateTestCase<ulong>(3UL, 3UL, 0, MidpointRounding.ToEven);
            yield return CreateTestCase<float>(3.2F, 3.25F, 1, MidpointRounding.ToEven);
            yield return CreateTestCase<float>(3.3F, 3.25F, 1, MidpointRounding.AwayFromZero);
            yield return CreateTestCase<float>(-2F, -2.5F, 0, MidpointRounding.ToEven);
            yield return CreateTestCase<float>(-3F, -2.5F, 0, MidpointRounding.AwayFromZero);
            yield return CreateTestCase<double>(3.2, 3.25, 1, MidpointRounding.ToEven);
            yield return CreateTestCase<double>(3.3, 3.25, 1, MidpointRounding.AwayFromZero);
            yield return CreateTestCase<double>(-2D, -2.5, 0, MidpointRounding.ToEven);
            yield return CreateTestCase<double>(-3D, -2.5, 0, MidpointRounding.AwayFromZero);
            yield return CreateTestCase<decimal>(3.2M, 3.25M, 1, MidpointRounding.ToEven);
            yield return CreateTestCase<decimal>(3.3M, 3.25M, 1, MidpointRounding.AwayFromZero);
            yield return CreateTestCase<decimal>(-2M, -2.5M, 0, MidpointRounding.ToEven);
            yield return CreateTestCase<decimal>(-3M, -2.5M, 0, MidpointRounding.AwayFromZero);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(3), new BigInteger(3), 0, MidpointRounding.ToEven);
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(3), new IntWrapper(3), 0, MidpointRounding.ToEven);
        }

        public static IEnumerable<TestCaseData> RoundNullableCases() => RoundCases().Concat(UnaryNullableCases(additionalArgs: new object[] { 0, MidpointRounding.ToEven }));

        [TestCaseSource(nameof(CompareCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public int Compare<T>(T valueToInferType, T left, T right) => Number.Compare(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(CompareCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public int CompareNumber<T>(T valueToInferType, T left, T right) => Number.Create(left).CompareTo(right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(CompareNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public int CompareNullable<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Compare(left, right);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(CompareNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public int CompareNullableNumber<T>(T valueToInferType, T? left, T? right) where T : struct => Number.Create(left).CompareTo(right);
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> CompareCases()
        {
            yield return CreateTestCase<sbyte>(1, (sbyte)3, (sbyte)2);
            yield return CreateTestCase<sbyte>(-3, (sbyte)3, (sbyte)6);
            yield return CreateTestCase<sbyte>(0, (sbyte)3, (sbyte)3);
            yield return CreateTestCase<byte>(1, (byte)3, (byte)2);
            yield return CreateTestCase<byte>(-3, (byte)3, (byte)6);
            yield return CreateTestCase<byte>(0, (byte)3, (byte)3);
            yield return CreateTestCase<short>(1, (short)3, (short)2);
            yield return CreateTestCase<short>(-3, (short)3, (short)6);
            yield return CreateTestCase<short>(0, (short)3, (short)3);
            yield return CreateTestCase<ushort>(1, (ushort)3, (ushort)2);
            yield return CreateTestCase<ushort>(-3, (ushort)3, (ushort)6);
            yield return CreateTestCase<ushort>(0, (ushort)3, (ushort)3);
            yield return CreateTestCase<int>(1, 3, 2);
            yield return CreateTestCase<int>(-1, 3, 6);
            yield return CreateTestCase<int>(0, 3, 3);
            yield return CreateTestCase<uint>(1, 3U, 2U);
            yield return CreateTestCase<uint>(-1, 3U, 6U);
            yield return CreateTestCase<uint>(0, 3U, 3U);
            yield return CreateTestCase<long>(1, 3L, 2L);
            yield return CreateTestCase<long>(-1, 3L, 6L);
            yield return CreateTestCase<long>(0, 3L, 3L);
            yield return CreateTestCase<ulong>(1, 3UL, 2UL);
            yield return CreateTestCase<ulong>(-1, 3UL, 6UL);
            yield return CreateTestCase<ulong>(0, 3UL, 3UL);
            yield return CreateTestCase<float>(1, 3F, 2F);
            yield return CreateTestCase<float>(-1, 3F, 6F);
            yield return CreateTestCase<float>(0, 3F, 3F);
            yield return CreateTestCase<double>(1, 3D, 2D);
            yield return CreateTestCase<double>(-1, 3D, 6D);
            yield return CreateTestCase<double>(0, 3D, 3D);
            yield return CreateTestCase<decimal>(1, 3M, 2M);
            yield return CreateTestCase<decimal>(-1, 3M, 6M);
            yield return CreateTestCase<decimal>(0, 3M, 3M);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(1, new BigInteger(3), new BigInteger(2));
            yield return CreateTestCase<BigInteger>(-1, new BigInteger(3), new BigInteger(6));
            yield return CreateTestCase<BigInteger>(0, new BigInteger(3), new BigInteger(3));
#endif
            yield return CreateTestCase<IntWrapper>(1, new IntWrapper(3), new IntWrapper(2));
            yield return CreateTestCase<IntWrapper>(-1, new IntWrapper(3), new IntWrapper(6));
            yield return CreateTestCase<IntWrapper>(0, new IntWrapper(3), new IntWrapper(3));
        }

        public static IEnumerable<TestCaseData> CompareNullableCases() => CompareCases().Concat(BinaryNullableCases(0, -1, 1));

        [TestCaseSource(nameof(ConvertCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public TTo Convert<TFrom, TTo>(TFrom valueToInferFromType, TTo valueToInferToType, TFrom value) => Number.Convert<TFrom, TTo>(value);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ConvertCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public TTo ConvertNumber<TFrom, TTo>(TFrom valueToInferFromType, TTo valueToInferToType, TFrom value) => Number.Create(value).To<TTo>();
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ConvertNullableCases1))]
#pragma warning disable IDE0060 // Remove unused parameter
        public TTo? ConvertNullable1<TFrom, TTo>(TFrom valueToInferFromType, TTo valueToInferToType, TFrom? value)
            where TFrom : struct
            where TTo : struct => Number.Convert<TFrom?, TTo?>(value);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ConvertNullableCases1))]
#pragma warning disable IDE0060 // Remove unused parameter
        public TTo? ConvertNullable1Number<TFrom, TTo>(TFrom valueToInferFromType, TTo valueToInferToType, TFrom? value)
            where TFrom : struct
            where TTo : struct => Number.Create(value).To<TTo?>();
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ConvertNullableCases2))]
#pragma warning disable IDE0060 // Remove unused parameter
        public TTo ConvertNullable2<TFrom, TTo>(TFrom valueToInferFromType, TTo valueToInferToType, TFrom? value) where TFrom : struct => Number.Convert<TFrom?, TTo>(value);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ConvertNullableCases2))]
#pragma warning disable IDE0060 // Remove unused parameter
        public TTo ConvertNullable2Number<TFrom, TTo>(TFrom valueToInferFromType, TTo valueToInferToType, TFrom? value) where TFrom : struct => Number.Create(value).To<TTo>();
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ConvertCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public TTo? ConvertNullable3<TFrom, TTo>(TFrom valueToInferFromType, TTo valueToInferToType, TFrom value) where TTo : struct => Number.Convert<TFrom, TTo?>(value);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ConvertCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public TTo? ConvertNullable3Number<TFrom, TTo>(TFrom valueToInferFromType, TTo valueToInferToType, TFrom value) where TTo : struct => Number.Create(value).To<TTo?>();
#pragma warning restore IDE0060 // Remove unused parameter

        private static readonly TypeAndValue[] s_conversionTypes = { TypeAndValue.Create((sbyte)1), TypeAndValue.Create((byte)1), TypeAndValue.Create((short)1), TypeAndValue.Create((ushort)1), TypeAndValue.Create(1), TypeAndValue.Create(1U), TypeAndValue.Create(1L), TypeAndValue.Create(1UL), TypeAndValue.Create(1F), TypeAndValue.Create(1D), TypeAndValue.Create(1M)
#if BIG_INTEGER
            , TypeAndValue.Create(new BigInteger(1))
#endif
            , TypeAndValue.Create(new IntWrapper(1))
        };

        public static IEnumerable<TestCaseData> ConvertCases()
        {
            foreach (var (fromType, value) in s_conversionTypes)
            {
                foreach (var (toType, expectedValue) in s_conversionTypes)
                {
                    yield return CreateConvertCase(fromType, toType, value, expectedValue);
                }
            }
        }

        public static TestCaseData CreateConvertCase(Type fromType, Type toType, object value, object expectedValue) => new TestCaseData(new object[] { Activator.CreateInstance(fromType), Activator.CreateInstance(toType), value }) { ExpectedResult = expectedValue };

        public static IEnumerable<TestCaseData> ConvertNullableCases1()
        {
            foreach (var data in ConvertCases())
            {
                yield return data;
            }
            foreach (var (fromType, value) in s_conversionTypes)
            {
                foreach (var (toType, expectedValue) in s_conversionTypes)
                {
                    yield return CreateConvertCase(fromType, toType, null, null);
                }
            }
        }

        public static IEnumerable<TestCaseData> ConvertNullableCases2()
        {
            foreach (var data in ConvertCases())
            {
                yield return data;
            }
            foreach (var (fromType, value) in s_conversionTypes)
            {
                foreach (var (toType, expectedValue) in s_conversionTypes)
                {
                    yield return CreateConvertCase(fromType, toType, null, Activator.CreateInstance(toType));
                }
            }
        }

        [TestCaseSource(nameof(ToStringCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public string ToString<T>(T valueToInferType, T value, string format) => Number.ToString(value, format);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ToStringCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public string ToStringNumber<T>(T valueToInferType, T value, string format) => Number.Create(value).ToString(format);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ToStringNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public string ToStringNullable<T>(T valueToInferType, T? value, string format) where T : struct => Number.ToString(value, format);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ToStringNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public string ToStringNullableNumber<T>(T valueToInferType, T? value, string format) where T : struct => Number.Create(value).ToString(format);
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> ToStringCases()
        {
            yield return CreateTestCase<sbyte>("-3", (sbyte)-3, null);
            yield return CreateTestCase<sbyte>("2", (sbyte)2, "D");
            yield return CreateTestCase<sbyte>("F", (sbyte)15, "X");
            yield return CreateTestCase<byte>("2", (byte)2, null);
            yield return CreateTestCase<byte>("F", (byte)15, "X");
            yield return CreateTestCase<short>("-3", (short)-3, null);
            yield return CreateTestCase<short>("2", (short)2, "D");
            yield return CreateTestCase<short>("F", (short)15, "X");
            yield return CreateTestCase<ushort>("2", (ushort)2, null);
            yield return CreateTestCase<ushort>("F", (ushort)15, "X");
            yield return CreateTestCase<int>("-3", -3, null);
            yield return CreateTestCase<int>("2", 2, "D");
            yield return CreateTestCase<int>("F", 15, "X");
            yield return CreateTestCase<uint>("2", 2U, null);
            yield return CreateTestCase<uint>("F", 15U, "X");
            yield return CreateTestCase<long>("-3", -3L, null);
            yield return CreateTestCase<long>("2", 2L, "D");
            yield return CreateTestCase<long>("F", 15L, "X");
            yield return CreateTestCase<ulong>("2", 2UL, null);
            yield return CreateTestCase<ulong>("F", 15UL, "X");
            yield return CreateTestCase<float>("3.9", 3.9F, null);
            yield return CreateTestCase<float>("-3,987.90", -3987.9F, "N");
            yield return CreateTestCase<double>("3.9", 3.9, null);
            yield return CreateTestCase<double>("-3,987.90", -3987.9, "N");
            yield return CreateTestCase<decimal>("3.9", 3.9M, null);
            yield return CreateTestCase<decimal>("-3,987.90", -3987.9M, "N");
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>("-3", new BigInteger(-3), null);
            yield return CreateTestCase<BigInteger>("2", new BigInteger(2), "D");
            yield return CreateTestCase<BigInteger>("0F", new BigInteger(15), "X");
#endif
            yield return CreateTestCase<IntWrapper>("-3", new IntWrapper(-3), null);
            yield return CreateTestCase<IntWrapper>("2", new IntWrapper(2), "D");
            yield return CreateTestCase<IntWrapper>("F", new IntWrapper(15), "X");
        }

        public static IEnumerable<TestCaseData> ToStringNullableCases() => ToStringCases().Concat(UnaryNullableCases(additionalArgs: new object[] { null }));

        [TestCaseSource(nameof(ParseCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T Parse<T>(T valueToInferType, string value, NumberStyles? style) => style.HasValue ? Number.Parse<T>(value, style.GetValueOrDefault(), CultureInfo.InvariantCulture) : Number.Parse<T>(value, CultureInfo.InvariantCulture);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ParseCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? ParseNullable<T>(T valueToInferType, string value, NumberStyles? style) where T : struct => style.HasValue ? Number.Parse<T?>(value, style.GetValueOrDefault(), CultureInfo.InvariantCulture) : Number.Parse<T?>(value, CultureInfo.InvariantCulture);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ParseCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T TryParse<T>(T valueToInferType, string value, NumberStyles? style)
        {
            Assert.IsTrue(style.HasValue ? Number.TryParse(value, style.GetValueOrDefault(), CultureInfo.InvariantCulture, out T result) : Number.TryParse(value, CultureInfo.InvariantCulture, out result));
            return result;
        }
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ParseCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? TryParseNullable<T>(T valueToInferType, string value, NumberStyles? style)
            where T : struct
        {
            Assert.IsTrue(style.HasValue ? Number.TryParse(value, style.GetValueOrDefault(), CultureInfo.InvariantCulture, out T? result) : Number.TryParse(value, CultureInfo.InvariantCulture, out result));
            return result;
        }
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> ParseCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)8, "8", null);
            yield return CreateTestCase<sbyte>((sbyte)-128, " -128 ", NumberStyles.Integer);
            yield return CreateTestCase<sbyte>((sbyte)-1, " FF ", NumberStyles.HexNumber);
            yield return CreateTestCase<byte>((byte)8, "8", null);
            yield return CreateTestCase<byte>(byte.MaxValue, " FF ", NumberStyles.HexNumber);
            yield return CreateTestCase<short>((short)8, "8", null);
            yield return CreateTestCase<short>((short)-128, " -128 ", NumberStyles.Integer);
            yield return CreateTestCase<short>((short)-1, " FFFF ", NumberStyles.HexNumber);
            yield return CreateTestCase<ushort>((ushort)8, "8", null);
            yield return CreateTestCase<ushort>(ushort.MaxValue, " FFFF ", NumberStyles.HexNumber);
            yield return CreateTestCase<int>(8, "8", null);
            yield return CreateTestCase<int>(-128, " -128 ", NumberStyles.Integer);
            yield return CreateTestCase<int>(-1, " FFFFFFFF ", NumberStyles.HexNumber);
            yield return CreateTestCase<uint>(8U, "8", null);
            yield return CreateTestCase<uint>(uint.MaxValue, " FFFFFFFF ", NumberStyles.HexNumber);
            yield return CreateTestCase<long>(8L, "8", null);
            yield return CreateTestCase<long>(-128L, " -128 ", NumberStyles.Integer);
            yield return CreateTestCase<long>(-1L, " FFFFFFFFFFFFFFFF ", NumberStyles.HexNumber);
            yield return CreateTestCase<ulong>(8U, "8", null);
            yield return CreateTestCase<ulong>(ulong.MaxValue, " FFFFFFFFFFFFFFFF ", NumberStyles.HexNumber);
            yield return CreateTestCase<float>(3.9F, "3.9", null);
            yield return CreateTestCase<float>(-3987.9F, " -3,987.90 ", NumberStyles.Float | NumberStyles.AllowThousands);
            yield return CreateTestCase<double>(3.9, "3.9", null);
            yield return CreateTestCase<double>(-3987.9, " -3,987.90 ", NumberStyles.Float | NumberStyles.AllowThousands);
            yield return CreateTestCase<decimal>(3.9M, "3.9", null);
            yield return CreateTestCase<decimal>(-3987.9M, " -3,987.90 ", NumberStyles.Float | NumberStyles.AllowThousands);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(8), "8", null);
            yield return CreateTestCase<BigInteger>(new BigInteger(-128), " -128 ", NumberStyles.Integer);
            yield return CreateTestCase<BigInteger>(new BigInteger(uint.MaxValue), " 00000000FFFFFFFF ", NumberStyles.HexNumber);
            yield return CreateTestCase<BigInteger>(new BigInteger(-1), " FFFFFFFF ", NumberStyles.HexNumber);
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(8), "8", null);
            yield return CreateTestCase<IntWrapper>(new IntWrapper(-128), " -128 ", NumberStyles.Integer);
            yield return CreateTestCase<IntWrapper>(new IntWrapper(-1), " FFFFFFFF ", NumberStyles.HexNumber);
        }

        [TestCaseSource(nameof(ParseFailCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void ParseFail<T>(T valueToInferType, string value, NumberStyles? style, Type exceptionType)
        {
            if (style.HasValue)
            {
                Assert.Throws(exceptionType, () => Number.Parse<T>(value, style.GetValueOrDefault(), CultureInfo.InvariantCulture));
            }
            else
            {
                Assert.Throws(exceptionType, () => Number.Parse<T>(value, CultureInfo.InvariantCulture));
            }
        }
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ParseFailCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void ParseNullableFail<T>(T valueToInferType, string value, NumberStyles? style, Type exceptionType) where T : struct
        {
            if (style.HasValue)
            {
                Assert.Throws(exceptionType, () => Number.Parse<T?>(value, style.GetValueOrDefault(), CultureInfo.InvariantCulture));
            }
            else
            {
                Assert.Throws(exceptionType, () => Number.Parse<T?>(value, CultureInfo.InvariantCulture));
            }
        }
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ParseFailCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void TryParseFail<T>(T valueToInferType, string value, NumberStyles? style, Type exceptionType) => Assert.IsFalse(style.HasValue ? Number.TryParse(value, style.GetValueOrDefault(), CultureInfo.InvariantCulture, out T _) : Number.TryParse(value, CultureInfo.InvariantCulture, out T _));
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ParseFailCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void TryParseNullableFail<T>(T valueToInferType, string value, NumberStyles? style, Type exceptionType)
            where T : struct => Assert.IsFalse(style.HasValue ? Number.TryParse(value, style.GetValueOrDefault(), CultureInfo.InvariantCulture, out T? _) : Number.TryParse(value, CultureInfo.InvariantCulture, out T? _));
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> ParseFailCases()
        {
            yield return CreateTestCase<sbyte>(new object[] { byte.MaxValue.ToString(), null, typeof(OverflowException) });
            yield return CreateTestCase<byte>(new object[] { sbyte.MinValue.ToString(), null, typeof(OverflowException) });
            yield return CreateTestCase<short>(new object[] { ushort.MaxValue.ToString(), null, typeof(OverflowException) });
            yield return CreateTestCase<ushort>(new object[] { short.MinValue.ToString(), null, typeof(OverflowException) });
            yield return CreateTestCase<int>(new object[] { uint.MaxValue.ToString(), null, typeof(OverflowException) });
            yield return CreateTestCase<uint>(new object[] { int.MinValue.ToString(), null, typeof(OverflowException) });
            yield return CreateTestCase<long>(new object[] { ulong.MaxValue.ToString(), null, typeof(OverflowException) });
            yield return CreateTestCase<ulong>(new object[] { long.MinValue.ToString(), null, typeof(OverflowException) });
            yield return CreateTestCase<float>(new object[] { double.MaxValue.ToString(), null, typeof(OverflowException) });
            yield return CreateTestCase<double>(new object[] { "1.79769313486232E+309", null, typeof(OverflowException) });
            yield return CreateTestCase<IntWrapper>(new object[] { uint.MaxValue.ToString(), null, typeof(OverflowException) });
            yield return CreateTestCase<sbyte>(new object[] { "a", null, typeof(FormatException) });
            yield return CreateTestCase<byte>(new object[] { "a", null, typeof(FormatException) });
            yield return CreateTestCase<short>(new object[] { "a", null, typeof(FormatException) });
            yield return CreateTestCase<ushort>(new object[] { "a", null, typeof(FormatException) });
            yield return CreateTestCase<int>(new object[] { "a", null, typeof(FormatException) });
            yield return CreateTestCase<uint>(new object[] { "a", null, typeof(FormatException) });
            yield return CreateTestCase<long>(new object[] { "a", null, typeof(FormatException) });
            yield return CreateTestCase<ulong>(new object[] { "a", null, typeof(FormatException) });
            yield return CreateTestCase<float>(new object[] { "a", null, typeof(FormatException) });
            yield return CreateTestCase<double>(new object[] { "a", null, typeof(FormatException) });
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new object[] { "a", null, typeof(FormatException) });
#endif
            yield return CreateTestCase<IntWrapper>(new object[] { "a", null, typeof(FormatException) });
        }

        [TestCaseSource(nameof(ClampCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T Clamp<T>(T valueToInferType, T value, T min, T max) => Number.Clamp(value, min, max);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ClampNullableCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public T? ClampNullable<T>(T valueToInferType, T? value, T? min, T? max) where T : struct => Number.Clamp(value, min, max);
#pragma warning restore IDE0060 // Remove unused parameter

        [TestCaseSource(nameof(ClampThrowsCases))]
#pragma warning disable IDE0060 // Remove unused parameter
        public void ClampThrows<T>(T valueToInferType, T value, T min, T max) => Assert.Throws<ArgumentException>(() => Number.Clamp(value, min, max));
#pragma warning restore IDE0060 // Remove unused parameter

        public static IEnumerable<TestCaseData> ClampCases()
        {
            yield return CreateTestCase<sbyte>((sbyte)3, (sbyte)3, (sbyte)2, (sbyte)5);
            yield return CreateTestCase<sbyte>((sbyte)2, (sbyte)1, (sbyte)2, (sbyte)5);
            yield return CreateTestCase<sbyte>((sbyte)5, (sbyte)8, (sbyte)2, (sbyte)5);
            yield return CreateTestCase<byte>((byte)3, (byte)3, (byte)2, (byte)5);
            yield return CreateTestCase<byte>((byte)2, (byte)1, (byte)2, (byte)5);
            yield return CreateTestCase<byte>((byte)5, (byte)8, (byte)2, (byte)5);
            yield return CreateTestCase<short>((short)3, (short)3, (short)2, (short)5);
            yield return CreateTestCase<short>((short)2, (short)1, (short)2, (short)5);
            yield return CreateTestCase<short>((short)5, (short)8, (short)2, (short)5);
            yield return CreateTestCase<ushort>((ushort)3, (ushort)3, (ushort)2, (ushort)5);
            yield return CreateTestCase<ushort>((ushort)2, (ushort)1, (ushort)2, (ushort)5);
            yield return CreateTestCase<ushort>((ushort)5, (ushort)8, (ushort)2, (ushort)5);
            yield return CreateTestCase<int>(3, 3, 2, 5);
            yield return CreateTestCase<int>(2, 1, 2, 5);
            yield return CreateTestCase<int>(5, 8, 2, 5);
            yield return CreateTestCase<uint>(3U, 3U, 2U, 5U);
            yield return CreateTestCase<uint>(2U, 1U, 2U, 5U);
            yield return CreateTestCase<uint>(5U, 8U, 2U, 5U);
            yield return CreateTestCase<long>(3L, 3L, 2L, 5L);
            yield return CreateTestCase<long>(2L, 1L, 2L, 5L);
            yield return CreateTestCase<long>(5L, 8L, 2L, 5L);
            yield return CreateTestCase<ulong>(3UL, 3UL, 2UL, 5UL);
            yield return CreateTestCase<ulong>(2UL, 1UL, 2UL, 5UL);
            yield return CreateTestCase<ulong>(5UL, 8UL, 2UL, 5UL);
            yield return CreateTestCase<float>(3F, 3F, 2F, 5F);
            yield return CreateTestCase<float>(2F, 1F, 2F, 5F);
            yield return CreateTestCase<float>(5F, 8F, 2F, 5F);
            yield return CreateTestCase<double>(3D, 3D, 2D, 5D);
            yield return CreateTestCase<double>(2D, 1D, 2D, 5D);
            yield return CreateTestCase<double>(5D, 8D, 2D, 5D);
            yield return CreateTestCase<decimal>(3M, 3M, 2M, 5M);
            yield return CreateTestCase<decimal>(2M, 1M, 2M, 5M);
            yield return CreateTestCase<decimal>(5M, 8M, 2M, 5M);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new BigInteger(3), new BigInteger(3), new BigInteger(2), new BigInteger(5));
            yield return CreateTestCase<BigInteger>(new BigInteger(2), new BigInteger(1), new BigInteger(2), new BigInteger(5));
            yield return CreateTestCase<BigInteger>(new BigInteger(5), new BigInteger(8), new BigInteger(2), new BigInteger(5));
#endif
            yield return CreateTestCase<IntWrapper>(new IntWrapper(3), new IntWrapper(3), new IntWrapper(2), new IntWrapper(5));
            yield return CreateTestCase<IntWrapper>(new IntWrapper(2), new IntWrapper(1), new IntWrapper(2), new IntWrapper(5));
            yield return CreateTestCase<IntWrapper>(new IntWrapper(5), new IntWrapper(8), new IntWrapper(2), new IntWrapper(5));
        }

        public static IEnumerable<TestCaseData> ClampNullableCases()
        {
            foreach (var data in ClampCases())
            {
                yield return data;
            }
            yield return CreateTestCase<sbyte>(null, null, (sbyte)2, (sbyte)5);
            yield return CreateTestCase<sbyte>(null, (sbyte)3, null, (sbyte)5);
            yield return CreateTestCase<sbyte>(null, (sbyte)3, (sbyte)2, null);
            yield return CreateTestCase<byte>(null, null, (byte)2, (byte)5);
            yield return CreateTestCase<byte>(null, (byte)1, null, (byte)5);
            yield return CreateTestCase<byte>(null, (byte)8, (byte)2, null);
            yield return CreateTestCase<short>(null, null, (short)2, (short)5);
            yield return CreateTestCase<short>(null, (short)1, null, (short)5);
            yield return CreateTestCase<short>(null, (short)8, (short)2, null);
            yield return CreateTestCase<ushort>(null, null, (ushort)2, (ushort)5);
            yield return CreateTestCase<ushort>(null, (ushort)1, null, (ushort)5);
            yield return CreateTestCase<ushort>(null, (ushort)8, (ushort)2, null);
            yield return CreateTestCase<int>(null, null, 2, 5);
            yield return CreateTestCase<int>(null, 1, null, 5);
            yield return CreateTestCase<int>(null, 8, 2, null);
            yield return CreateTestCase<uint>(null, null, 2U, 5U);
            yield return CreateTestCase<uint>(null, 1U, null, 5U);
            yield return CreateTestCase<uint>(null, 8U, 2U, null);
            yield return CreateTestCase<long>(null, null, 2L, 5L);
            yield return CreateTestCase<long>(null, 1L, null, 5L);
            yield return CreateTestCase<long>(null, 8L, 2L, null);
            yield return CreateTestCase<ulong>(null, null, 2UL, 5UL);
            yield return CreateTestCase<ulong>(null, 1UL, null, 5UL);
            yield return CreateTestCase<ulong>(null, 8UL, 2UL, null);
            yield return CreateTestCase<float>(null, null, 2F, 5F);
            yield return CreateTestCase<float>(null, 1F, null, 5F);
            yield return CreateTestCase<float>(null, 8F, 2F, null);
            yield return CreateTestCase<double>(null, null, 2D, 5D);
            yield return CreateTestCase<double>(null, 1D, null, 5D);
            yield return CreateTestCase<double>(null, 8D, 2D, null);
            yield return CreateTestCase<decimal>(null, null, 2M, 5M);
            yield return CreateTestCase<decimal>(null, 1M, null, 5M);
            yield return CreateTestCase<decimal>(null, 8M, 2M, null);
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(null, null, new BigInteger(2), new BigInteger(5));
            yield return CreateTestCase<BigInteger>(null, new BigInteger(1), null, new BigInteger(5));
            yield return CreateTestCase<BigInteger>(null, new BigInteger(8), new BigInteger(2), null);
#endif
            yield return CreateTestCase<IntWrapper>(null, null, new IntWrapper(2), new IntWrapper(5));
            yield return CreateTestCase<IntWrapper>(null, new IntWrapper(1), null, new IntWrapper(5));
            yield return CreateTestCase<IntWrapper>(null, new IntWrapper(8), new IntWrapper(2), null);
        }

        public static IEnumerable<TestCaseData> ClampThrowsCases()
        {
            yield return CreateTestCase<sbyte>(new object[] { (sbyte)3, (sbyte)8, (sbyte)5 });
            yield return CreateTestCase<byte>(new object[] { (byte)3, (byte)8, (byte)5 });
            yield return CreateTestCase<short>(new object[] { (short)3, (short)8, (short)5 });
            yield return CreateTestCase<ushort>(new object[] { (ushort)3, (ushort)8, (ushort)5 });
            yield return CreateTestCase<int>(new object[] { 3, 8, 5 });
            yield return CreateTestCase<uint>(new object[] { 3U, 8U, 5U });
            yield return CreateTestCase<long>(new object[] { 3L, 8L, 5L });
            yield return CreateTestCase<ulong>(new object[] { 3UL, 8UL, 5UL });
            yield return CreateTestCase<float>(new object[] { 3F, 8F, 5F });
            yield return CreateTestCase<double>(new object[] { 3D, 8D, 5D });
            yield return CreateTestCase<decimal>(new object[] { 3M, 8M, 5M });
#if BIG_INTEGER
            yield return CreateTestCase<BigInteger>(new object[] { new BigInteger(3), new BigInteger(8), new BigInteger(5) });
#endif
            yield return CreateTestCase<IntWrapper>(new object[] { new IntWrapper(3), new IntWrapper(8), new IntWrapper(5) });
        }

        public static IEnumerable<TestCaseData> BinaryBitwiseThrowsCases()
        {
            yield return CreateTestCase<float>(new object[] { 3F, 6F });
            yield return CreateTestCase<double>(new object[] { 3D, 6D });
            yield return CreateTestCase<decimal>(new object[] { 3M, 6M });
        }

        public static IEnumerable<TestCaseData> UnaryBitwiseThrowsCases()
        {
            yield return CreateTestCase<float>(new object[] { 3.9F });
            yield return CreateTestCase<double>(new object[] { 3.5 });
            yield return CreateTestCase<decimal>(new object[] { 3.2M });
        }

        public static IEnumerable<TestCaseData> BinaryNullableCases(object bothNullResult = null, object firstNullResult = null, object secondNullResult = null, Types types = Types.All)
        {
            if (types.HasAnyFlags(Types.SByte))
            {
                yield return CreateTestCase<sbyte>(bothNullResult, null, null);
                yield return CreateTestCase<sbyte>(firstNullResult, null, sbyte.MinValue);
                yield return CreateTestCase<sbyte>(secondNullResult, sbyte.MaxValue, null);
            }
            if (types.HasAnyFlags(Types.Byte))
            {
                yield return CreateTestCase<byte>(bothNullResult, null, null);
                yield return CreateTestCase<byte>(firstNullResult, null, byte.MinValue);
                yield return CreateTestCase<byte>(secondNullResult, byte.MaxValue, null);
            }
            if (types.HasAnyFlags(Types.Int16))
            {
                yield return CreateTestCase<short>(bothNullResult, null, null);
                yield return CreateTestCase<short>(firstNullResult, null, short.MinValue);
                yield return CreateTestCase<short>(secondNullResult, short.MaxValue, null);
            }
            if (types.HasAnyFlags(Types.UInt16))
            {
                yield return CreateTestCase<ushort>(bothNullResult, null, null);
                yield return CreateTestCase<ushort>(firstNullResult, null, ushort.MinValue);
                yield return CreateTestCase<ushort>(secondNullResult, ushort.MaxValue, null);
            }
            if (types.HasAnyFlags(Types.Int32))
            {
                yield return CreateTestCase<int>(bothNullResult, null, null);
                yield return CreateTestCase<int>(firstNullResult, null, int.MinValue);
                yield return CreateTestCase<int>(secondNullResult, int.MaxValue, null);
            }
            if (types.HasAnyFlags(Types.UInt32))
            {
                yield return CreateTestCase<uint>(bothNullResult, null, null);
                yield return CreateTestCase<uint>(firstNullResult, null, uint.MinValue);
                yield return CreateTestCase<uint>(secondNullResult, uint.MaxValue, null);
            }
            if (types.HasAnyFlags(Types.Int64))
            {
                yield return CreateTestCase<long>(bothNullResult, null, null);
                yield return CreateTestCase<long>(firstNullResult, null, long.MinValue);
                yield return CreateTestCase<long>(secondNullResult, long.MaxValue, null);
            }
            if (types.HasAnyFlags(Types.UInt64))
            {
                yield return CreateTestCase<ulong>(bothNullResult, null, null);
                yield return CreateTestCase<ulong>(firstNullResult, null, ulong.MinValue);
                yield return CreateTestCase<ulong>(secondNullResult, ulong.MaxValue, null);
            }
            if (types.HasAnyFlags(Types.Single))
            {
                yield return CreateTestCase<float>(bothNullResult, null, null);
                yield return CreateTestCase<float>(firstNullResult, null, float.MinValue);
                yield return CreateTestCase<float>(secondNullResult, float.MaxValue, null);
            }
            if (types.HasAnyFlags(Types.Double))
            {
                yield return CreateTestCase<double>(bothNullResult, null, null);
                yield return CreateTestCase<double>(firstNullResult, null, double.MinValue);
                yield return CreateTestCase<double>(secondNullResult, double.MaxValue, null);
            }
            if (types.HasAnyFlags(Types.Decimal))
            {
                yield return CreateTestCase<decimal>(bothNullResult, null, null);
                yield return CreateTestCase<decimal>(firstNullResult, null, decimal.MinValue);
                yield return CreateTestCase<decimal>(secondNullResult, decimal.MaxValue, null);
            }
#if BIG_INTEGER
            if (types.HasAnyFlags(Types.BigInteger))
            {
                yield return CreateTestCase<BigInteger>(bothNullResult, null, null);
                yield return CreateTestCase<BigInteger>(firstNullResult, null, BigInteger.Zero);
                yield return CreateTestCase<BigInteger>(secondNullResult, BigInteger.One, null);
            }
#endif
            if (types.HasAnyFlags(Types.IntWrapper))
            {
                yield return CreateTestCase<IntWrapper>(bothNullResult, null, null);
                yield return CreateTestCase<IntWrapper>(firstNullResult, null, new IntWrapper(0));
                yield return CreateTestCase<IntWrapper>(secondNullResult, new IntWrapper(1), null);
            }
        }

        public static IEnumerable<TestCaseData> UnaryNullableCases(object nullResult = null, Types types = Types.All, params object[] additionalArgs)
        {
            var args = new object[] { null }.Concat(additionalArgs ?? new object[0]).ToArray();
            if (types.HasAnyFlags(Types.SByte))
            {
                yield return CreateTestCase<sbyte>(nullResult, args);
            }
            if (types.HasAnyFlags(Types.Byte))
            {
                yield return CreateTestCase<byte>(nullResult, args);
            }
            if (types.HasAnyFlags(Types.Int16))
            {
                yield return CreateTestCase<short>(nullResult, args);
            }
            if (types.HasAnyFlags(Types.UInt16))
            {
                yield return CreateTestCase<ushort>(nullResult, args);
            }
            if (types.HasAnyFlags(Types.Int32))
            {
                yield return CreateTestCase<int>(nullResult, args);
            }
            if (types.HasAnyFlags(Types.UInt32))
            {
                yield return CreateTestCase<uint>(nullResult, args);
            }
            if (types.HasAnyFlags(Types.Int64))
            {
                yield return CreateTestCase<long>(nullResult, args);
            }
            if (types.HasAnyFlags(Types.UInt64))
            {
                yield return CreateTestCase<ulong>(nullResult, args);
            }
            if (types.HasAnyFlags(Types.Single))
            {
                yield return CreateTestCase<float>(nullResult, args);
            }
            if (types.HasAnyFlags(Types.Double))
            {
                yield return CreateTestCase<double>(nullResult, args);
            }
            if (types.HasAnyFlags(Types.Decimal))
            {
                yield return CreateTestCase<decimal>(nullResult, args);
            }
#if BIG_INTEGER
            if (types.HasAnyFlags(Types.BigInteger))
            {
                yield return CreateTestCase<BigInteger>(nullResult, args);
            }
#endif
            if (types.HasAnyFlags(Types.IntWrapper))
            {
                yield return CreateTestCase<IntWrapper>(nullResult, args);
            }
        }
    }

    [Flags]
    public enum Types
    {
        None = 0,
        SByte = 1,
        Byte = 2,
        Int16 = 4,
        UInt16 = 8,
        Int32 = 16,
        UInt32 = 32,
        Int64 = 64,
        UInt64 = 128,
        Unsigned = Byte | UInt16 | UInt32 | UInt64,
        Single = 256,
        Double = 512,
        Decimal = 1024,
        Floating = Single | Double | Decimal,
        BigInteger = 2048,
        IntWrapper = 4096,
        Integral = SByte | Byte | Int16 | UInt16 | Int32 | UInt32 | Int64 | UInt64 | BigInteger | IntWrapper,
        Signed = SByte | Int16 | Int32 | Int64 | Floating | BigInteger | IntWrapper,
        All = Integral | Floating
    }

    public sealed class TypeAndValue
    {
        public static TypeAndValue Create<T>(T value) => new TypeAndValue(typeof(T), value);

        public Type Type { get; }

        public object Value { get; }

        public TypeAndValue(Type type, object value)
        {
            Type = type;
            Value = value;
        }

        public void Deconstruct(out Type type, out object value)
        {
            type = Type;
            value = Value;
        }
    }
}