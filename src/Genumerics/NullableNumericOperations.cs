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
using System.Globalization;
#if BIG_INTEGER
using System.Numerics;
#endif

#if SPAN
using ParseType = System.ReadOnlySpan<char>;
#else
using ParseType = System.String;
#endif

namespace Genumerics
{
    internal sealed class NullableNumericOperations<T> : INumericOperations<T?>
        where T : struct
    {
        public T? Zero => Number<T>.Operations.Zero;

        public T? One => Number<T>.Operations.One;

        public T? MinusOne => Number<T>.Operations.MinusOne;

        public T? MaxValue => Number<T>.Operations.MaxValue;

        public T? MinValue => Number<T>.Operations.MinValue;

#if TYPE_CODE
        public TypeCode TypeCode => Number<T>.Operations.TypeCode;
#endif

        public T? Add(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.Operations.Add(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? And(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.Operations.And(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? Divide(T? dividend, T? divisor) => dividend.HasValue && divisor.HasValue ? Number<T>.Operations.Divide(dividend.GetValueOrDefault(), divisor.GetValueOrDefault()) : (T?)null;

        public bool Equals(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.Operations.Equals(left.GetValueOrDefault(), right.GetValueOrDefault()) : !left.HasValue && !right.HasValue;

        public bool GreaterThan(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.Operations.GreaterThan(left.GetValueOrDefault(), right.GetValueOrDefault()) : false;

        public bool GreaterThanOrEquals(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.Operations.GreaterThanOrEquals(left.GetValueOrDefault(), right.GetValueOrDefault()) : false;

        public T? LeftShift(T? value, int shift) => value.HasValue ? Number<T>.Operations.LeftShift(value.GetValueOrDefault(), shift) : value;

        public bool LessThan(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.Operations.LessThan(left.GetValueOrDefault(), right.GetValueOrDefault()) : false;

        public bool LessThanOrEquals(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.Operations.LessThanOrEquals(left.GetValueOrDefault(), right.GetValueOrDefault()) : false;

        public T? Multiply(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.Operations.Multiply(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? Negate(T? value) => value.HasValue ? Number<T>.Operations.Negate(value.GetValueOrDefault()) : value;

        public T? Not(T? value) => value.HasValue ? Number<T>.Operations.Not(value.GetValueOrDefault()) : value;

        public bool NotEquals(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.Operations.NotEquals(left.GetValueOrDefault(), right.GetValueOrDefault()) : left.HasValue || right.HasValue;

        public T? Or(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.Operations.Or(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? Parse(ParseType value, NumberStyles? styles, IFormatProvider provider) => Number<T>.Operations.Parse(value, styles, provider);

        public T? Remainder(T? dividend, T? divisor) => dividend.HasValue && divisor.HasValue ? Number<T>.Operations.Remainder(dividend.GetValueOrDefault(), divisor.GetValueOrDefault()) : (T?)null;

        public T? RightShift(T? value, int shift) => value.HasValue ? Number<T>.Operations.RightShift(value.GetValueOrDefault(), shift) : value;

        public T? Subtract(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.Operations.Subtract(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public bool TryParse(ParseType value, NumberStyles? styles, IFormatProvider provider, out T? result)
        {
            var success = Number<T>.Operations.TryParse(value, styles, provider, out T r);
            result = r;
            return success;
        }

        public T? Xor(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.Operations.Xor(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? Convert<TFrom>(TFrom value) => Number<T>.Operations.Convert(value);

        public T? Round(T? value, int digits, MidpointRounding mode) => value.HasValue ? Number<T>.Operations.Round(value.GetValueOrDefault(), digits, mode) : value;

        public T? Floor(T? value) => value.HasValue ? Number<T>.Operations.Floor(value.GetValueOrDefault()) : value;

        public T? Ceiling(T? value) => value.HasValue ? Number<T>.Operations.Ceiling(value.GetValueOrDefault()) : value;

        public T? Truncate(T? value) => value.HasValue ? Number<T>.Operations.Truncate(value.GetValueOrDefault()) : value;

        public int Compare(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.Operations.Compare(left.GetValueOrDefault(), right.GetValueOrDefault()) : (left.HasValue ? 1 : (right.HasValue ? -1 : 0));

        public T? Abs(T? value) => value.HasValue ? Number<T>.Operations.Abs(value.GetValueOrDefault()) : value;

        public T? Max(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.Operations.Max(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? Min(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.Operations.Min(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public int Sign(T? value) => value.HasValue ? Number<T>.Operations.Sign(value.GetValueOrDefault()) : -2;

        public string ToString(T? value, string format, IFormatProvider provider) => value.HasValue ? Number<T>.Operations.ToString(value.GetValueOrDefault(), format, provider) : null;

        public sbyte ToSByte(T? value) => value.HasValue ? Number<T>.Operations.ToSByte(value.GetValueOrDefault()) : default;

        public byte ToByte(T? value) => value.HasValue ? Number<T>.Operations.ToByte(value.GetValueOrDefault()) : default;

        public short ToInt16(T? value) => value.HasValue ? Number<T>.Operations.ToInt16(value.GetValueOrDefault()) : default;

        public ushort ToUInt16(T? value) => value.HasValue ? Number<T>.Operations.ToUInt16(value.GetValueOrDefault()) : default;

        public int ToInt32(T? value) => value.HasValue ? Number<T>.Operations.ToInt32(value.GetValueOrDefault()) : default;

        public uint ToUInt32(T? value) => value.HasValue ? Number<T>.Operations.ToUInt32(value.GetValueOrDefault()) : default;

        public long ToInt64(T? value) => value.HasValue ? Number<T>.Operations.ToInt64(value.GetValueOrDefault()) : default;

        public ulong ToUInt64(T? value) => value.HasValue ? Number<T>.Operations.ToUInt64(value.GetValueOrDefault()) : default;

        public float ToSingle(T? value) => value.HasValue ? Number<T>.Operations.ToSingle(value.GetValueOrDefault()) : default;

        public double ToDouble(T? value) => value.HasValue ? Number<T>.Operations.ToDouble(value.GetValueOrDefault()) : default;

        public decimal ToDecimal(T? value) => value.HasValue ? Number<T>.Operations.ToDecimal(value.GetValueOrDefault()) : default;

#if BIG_INTEGER
        public BigInteger ToBigInteger(T? value) => value.HasValue ? Number<T>.Operations.ToBigInteger(value.GetValueOrDefault()) : default;
#endif

        public bool IsEven(T? value) => value.HasValue ? Number<T>.Operations.IsEven(value.GetValueOrDefault()) : false;

        public bool IsOdd(T? value) => value.HasValue ? Number<T>.Operations.IsOdd(value.GetValueOrDefault()) : false;

        public bool IsPowerOfTwo(T? value) => value.HasValue ? Number<T>.Operations.IsPowerOfTwo(value.GetValueOrDefault()) : false;

        public T? Clamp(T? value, T? min, T? max) => value.HasValue && min.HasValue && max.HasValue ? Number<T>.Operations.Clamp(value.GetValueOrDefault(), min.GetValueOrDefault(), max.GetValueOrDefault()) : (T?)null;
    }

    internal static class NullableNumericOperationsStore<T>
    {
        internal static INumericOperations<T> Instance;
    }
}