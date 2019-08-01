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

namespace Genumerics
{
    internal sealed class NullableNumericOperations<T> : INumericOperations<T?>
        where T : struct
    {
        public T? Zero => Number<T>.s_operations.Zero;

        public T? One => Number<T>.s_operations.One;

        public T? MinusOne => Number<T>.s_operations.MinusOne;

        public T? MaxValue => Number<T>.s_operations.MaxValue;

        public T? MinValue => Number<T>.s_operations.MinValue;

#if ICONVERTIBLE
        public TypeCode TypeCode => Number<T>.s_operations.TypeCode;
#endif

        public T? Add(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.s_operations.Add(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? And(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.s_operations.And(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? Divide(T? dividend, T? divisor) => dividend.HasValue && divisor.HasValue ? Number<T>.s_operations.Divide(dividend.GetValueOrDefault(), divisor.GetValueOrDefault()) : (T?)null;

        public T? DivRem(T? dividend, T? divisor, out T? remainder)
        {
            if (dividend.HasValue && divisor.HasValue)
            {
                var result = Number<T>.s_operations.DivRem(dividend.GetValueOrDefault(), divisor.GetValueOrDefault(), out T r);
                remainder = r;
                return result;
            }
            remainder = null;
            return null;
        }

        public bool Equals(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.s_operations.Equals(left.GetValueOrDefault(), right.GetValueOrDefault()) : !left.HasValue && !right.HasValue;

        public bool GreaterThan(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.s_operations.GreaterThan(left.GetValueOrDefault(), right.GetValueOrDefault()) : false;

        public bool GreaterThanOrEquals(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.s_operations.GreaterThanOrEquals(left.GetValueOrDefault(), right.GetValueOrDefault()) : false;

        public T? LeftShift(T? value, int shift) => value.HasValue ? Number<T>.s_operations.LeftShift(value.GetValueOrDefault(), shift) : value;

        public bool LessThan(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.s_operations.LessThan(left.GetValueOrDefault(), right.GetValueOrDefault()) : false;

        public bool LessThanOrEquals(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.s_operations.LessThanOrEquals(left.GetValueOrDefault(), right.GetValueOrDefault()) : false;

        public T? Multiply(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.s_operations.Multiply(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? Negate(T? value) => value.HasValue ? Number<T>.s_operations.Negate(value.GetValueOrDefault()) : value;

        public T? Not(T? value) => value.HasValue ? Number<T>.s_operations.Not(value.GetValueOrDefault()) : value;

        public bool NotEquals(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.s_operations.NotEquals(left.GetValueOrDefault(), right.GetValueOrDefault()) : left.HasValue || right.HasValue;

        public T? Or(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.s_operations.Or(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? Parse(string value, NumberStyles? styles, IFormatProvider provider) => Number<T>.s_operations.Parse(value, styles, provider);

        public T? Remainder(T? dividend, T? divisor) => dividend.HasValue && divisor.HasValue ? Number<T>.s_operations.Remainder(dividend.GetValueOrDefault(), divisor.GetValueOrDefault()) : (T?)null;

        public T? RightShift(T? value, int shift) => value.HasValue ? Number<T>.s_operations.RightShift(value.GetValueOrDefault(), shift) : value;

        public T? Subtract(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.s_operations.Subtract(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public bool TryParse(string value, NumberStyles? styles, IFormatProvider provider, out T? result)
        {
            var success = Number<T>.s_operations.TryParse(value, styles, provider, out T r);
            result = r;
            return success;
        }

#if SPAN
        public T? Parse(ReadOnlySpan<char> value, NumberStyles? styles, IFormatProvider provider) => Number<T>.s_operations.Parse(value, styles, provider);

        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? styles, IFormatProvider provider, out T? result)
        {
            var success = Number<T>.s_operations.TryParse(value, styles, provider, out T r);
            result = r;
            return success;
        }

        public bool TryFormat(T? value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null)
        {
            if (value.HasValue)
            {
                return Number<T>.s_operations.TryFormat(value.GetValueOrDefault(), destination, out charsWritten, format, provider);
            }
            charsWritten = 0;
            return false;
        }
#endif

        public T? Xor(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.s_operations.Xor(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? Convert<TFrom>(TFrom value) => Number<T>.s_operations.Convert(value);

        public T? Round(T? value, int digits, MidpointRounding mode) => value.HasValue ? Number<T>.s_operations.Round(value.GetValueOrDefault(), digits, mode) : value;

        public T? Floor(T? value) => value.HasValue ? Number<T>.s_operations.Floor(value.GetValueOrDefault()) : value;

        public T? Ceiling(T? value) => value.HasValue ? Number<T>.s_operations.Ceiling(value.GetValueOrDefault()) : value;

        public T? Truncate(T? value) => value.HasValue ? Number<T>.s_operations.Truncate(value.GetValueOrDefault()) : value;

        public int Compare(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.s_operations.Compare(left.GetValueOrDefault(), right.GetValueOrDefault()) : (left.HasValue ? 1 : (right.HasValue ? -1 : 0));

        public T? Abs(T? value) => value.HasValue ? Number<T>.s_operations.Abs(value.GetValueOrDefault()) : value;

        public T? Max(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.s_operations.Max(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? Min(T? left, T? right) => left.HasValue && right.HasValue ? Number<T>.s_operations.Min(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public int Sign(T? value) => value.HasValue ? Number<T>.s_operations.Sign(value.GetValueOrDefault()) : -2;

        public string ToString(T? value, string format, IFormatProvider provider) => value.HasValue ? Number<T>.s_operations.ToString(value.GetValueOrDefault(), format, provider) : null;

        public sbyte ToSByte(T? value) => value.HasValue ? Number<T>.s_operations.ToSByte(value.GetValueOrDefault()) : default;

        public byte ToByte(T? value) => value.HasValue ? Number<T>.s_operations.ToByte(value.GetValueOrDefault()) : default;

        public short ToInt16(T? value) => value.HasValue ? Number<T>.s_operations.ToInt16(value.GetValueOrDefault()) : default;

        public ushort ToUInt16(T? value) => value.HasValue ? Number<T>.s_operations.ToUInt16(value.GetValueOrDefault()) : default;

        public int ToInt32(T? value) => value.HasValue ? Number<T>.s_operations.ToInt32(value.GetValueOrDefault()) : default;

        public uint ToUInt32(T? value) => value.HasValue ? Number<T>.s_operations.ToUInt32(value.GetValueOrDefault()) : default;

        public long ToInt64(T? value) => value.HasValue ? Number<T>.s_operations.ToInt64(value.GetValueOrDefault()) : default;

        public ulong ToUInt64(T? value) => value.HasValue ? Number<T>.s_operations.ToUInt64(value.GetValueOrDefault()) : default;

        public float ToSingle(T? value) => value.HasValue ? Number<T>.s_operations.ToSingle(value.GetValueOrDefault()) : default;

        public double ToDouble(T? value) => value.HasValue ? Number<T>.s_operations.ToDouble(value.GetValueOrDefault()) : default;

        public decimal ToDecimal(T? value) => value.HasValue ? Number<T>.s_operations.ToDecimal(value.GetValueOrDefault()) : default;

#if BIG_INTEGER
        public BigInteger ToBigInteger(T? value) => value.HasValue ? Number<T>.s_operations.ToBigInteger(value.GetValueOrDefault()) : default;
#endif

        public bool IsEven(T? value) => value.HasValue ? Number<T>.s_operations.IsEven(value.GetValueOrDefault()) : false;

        public bool IsOdd(T? value) => value.HasValue ? Number<T>.s_operations.IsOdd(value.GetValueOrDefault()) : false;

        public bool IsPowerOfTwo(T? value) => value.HasValue ? Number<T>.s_operations.IsPowerOfTwo(value.GetValueOrDefault()) : false;

        public T? Clamp(T? value, T? min, T? max) => value.HasValue && min.HasValue && max.HasValue ? Number<T>.s_operations.Clamp(value.GetValueOrDefault(), min.GetValueOrDefault(), max.GetValueOrDefault()) : (T?)null;
    }
}