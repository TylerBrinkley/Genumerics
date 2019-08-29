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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member, type should only really be used through the interface as a type constraint. I'd make all the members use explicit interface implementation but that would greatly increase the library's dll size.
    /// <summary>
    /// Defines the numeric operations for a nullable numeric type.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    /// <typeparam name="TNumericOperations">The numeric type's operations type.</typeparam>
    [CLSCompliant(false)]
    public struct NullableNumericOperations<T, TNumericOperations> : INumericOperations<T?>
        where T : struct
        where TNumericOperations : struct, INumericOperations<T>
    {
        public T? Zero => default(TNumericOperations).Zero;

        public T? One => default(TNumericOperations).One;

        public T? MinusOne => default(TNumericOperations).MinusOne;

        public T? MaxValue => default(TNumericOperations).MaxValue;

        public T? MinValue => default(TNumericOperations).MinValue;

#if ICONVERTIBLE
        public TypeCode TypeCode => default(TNumericOperations).TypeCode;
#endif

        public T? Add(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).Add(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? BitwiseAnd(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).BitwiseAnd(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? Divide(T? dividend, T? divisor) => dividend.HasValue && divisor.HasValue ? default(TNumericOperations).Divide(dividend.GetValueOrDefault(), divisor.GetValueOrDefault()) : (T?)null;

        public T? DivRem(T? dividend, T? divisor, out T? remainder)
        {
            if (dividend.HasValue && divisor.HasValue)
            {
                var result = default(TNumericOperations).DivRem(dividend.GetValueOrDefault(), divisor.GetValueOrDefault(), out T r);
                remainder = r;
                return result;
            }
            remainder = null;
            return null;
        }

        public bool Equals(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).Equals(left.GetValueOrDefault(), right.GetValueOrDefault()) : !left.HasValue && !right.HasValue;

        public bool GreaterThan(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).GreaterThan(left.GetValueOrDefault(), right.GetValueOrDefault()) : false;

        public bool GreaterThanOrEqual(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).GreaterThanOrEqual(left.GetValueOrDefault(), right.GetValueOrDefault()) : false;

        public T? LeftShift(T? value, int shift) => value.HasValue ? default(TNumericOperations).LeftShift(value.GetValueOrDefault(), shift) : value;

        public bool LessThan(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).LessThan(left.GetValueOrDefault(), right.GetValueOrDefault()) : false;

        public bool LessThanOrEqual(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).LessThanOrEqual(left.GetValueOrDefault(), right.GetValueOrDefault()) : false;

        public T? Multiply(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).Multiply(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? Negate(T? value) => value.HasValue ? default(TNumericOperations).Negate(value.GetValueOrDefault()) : value;

        public T? OnesComplement(T? value) => value.HasValue ? default(TNumericOperations).OnesComplement(value.GetValueOrDefault()) : value;

        public bool NotEquals(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).NotEquals(left.GetValueOrDefault(), right.GetValueOrDefault()) : left.HasValue || right.HasValue;

        public T? BitwiseOr(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).BitwiseOr(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? Parse(string value, NumberStyles? styles, IFormatProvider? provider) => default(TNumericOperations).Parse(value, styles, provider);

        public T? Remainder(T? dividend, T? divisor) => dividend.HasValue && divisor.HasValue ? default(TNumericOperations).Remainder(dividend.GetValueOrDefault(), divisor.GetValueOrDefault()) : (T?)null;

        public T? RightShift(T? value, int shift) => value.HasValue ? default(TNumericOperations).RightShift(value.GetValueOrDefault(), shift) : value;

        public T? Subtract(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).Subtract(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public bool TryParse(string value, NumberStyles? styles, IFormatProvider? provider, out T? result)
        {
            var success = default(TNumericOperations).TryParse(value, styles, provider, out T r);
            result = r;
            return success;
        }

#if SPAN
        public T? Parse(ReadOnlySpan<char> value, NumberStyles? styles, IFormatProvider? provider) => default(TNumericOperations).Parse(value, styles, provider);

        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? styles, IFormatProvider? provider, out T? result)
        {
            var success = default(TNumericOperations).TryParse(value, styles, provider, out T r);
            result = r;
            return success;
        }

        public bool TryFormat(T? value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        {
            if (value.HasValue)
            {
                return default(TNumericOperations).TryFormat(value.GetValueOrDefault(), destination, out charsWritten, format, provider);
            }
            charsWritten = 0;
            return false;
        }
#endif

        public T? Xor(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).Xor(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? Convert<TFrom>(TFrom value) => default(TNumericOperations).Convert(value);

        public T? Round(T? value, int digits, MidpointRounding mode) => value.HasValue ? default(TNumericOperations).Round(value.GetValueOrDefault(), digits, mode) : value;

        public T? Floor(T? value) => value.HasValue ? default(TNumericOperations).Floor(value.GetValueOrDefault()) : value;

        public T? Ceiling(T? value) => value.HasValue ? default(TNumericOperations).Ceiling(value.GetValueOrDefault()) : value;

        public T? Truncate(T? value) => value.HasValue ? default(TNumericOperations).Truncate(value.GetValueOrDefault()) : value;

        public int Compare(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).Compare(left.GetValueOrDefault(), right.GetValueOrDefault()) : (left.HasValue ? 1 : (right.HasValue ? -1 : 0));

        public T? Abs(T? value) => value.HasValue ? default(TNumericOperations).Abs(value.GetValueOrDefault()) : value;

        public T? Max(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).Max(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? Min(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).Min(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public int Sign(T? value) => value.HasValue ? default(TNumericOperations).Sign(value.GetValueOrDefault()) : -2;

        public string? ToString(T? value, string? format, IFormatProvider? provider) => value.HasValue ? default(TNumericOperations).ToString(value.GetValueOrDefault(), format, provider) : null;

        public sbyte ToSByte(T? value) => value.HasValue ? default(TNumericOperations).ToSByte(value.GetValueOrDefault()) : default;

        public byte ToByte(T? value) => value.HasValue ? default(TNumericOperations).ToByte(value.GetValueOrDefault()) : default;

        public short ToInt16(T? value) => value.HasValue ? default(TNumericOperations).ToInt16(value.GetValueOrDefault()) : default;

        public ushort ToUInt16(T? value) => value.HasValue ? default(TNumericOperations).ToUInt16(value.GetValueOrDefault()) : default;

        public int ToInt32(T? value) => value.HasValue ? default(TNumericOperations).ToInt32(value.GetValueOrDefault()) : default;

        public uint ToUInt32(T? value) => value.HasValue ? default(TNumericOperations).ToUInt32(value.GetValueOrDefault()) : default;

        public long ToInt64(T? value) => value.HasValue ? default(TNumericOperations).ToInt64(value.GetValueOrDefault()) : default;

        public ulong ToUInt64(T? value) => value.HasValue ? default(TNumericOperations).ToUInt64(value.GetValueOrDefault()) : default;

        public float ToSingle(T? value) => value.HasValue ? default(TNumericOperations).ToSingle(value.GetValueOrDefault()) : default;

        public double ToDouble(T? value) => value.HasValue ? default(TNumericOperations).ToDouble(value.GetValueOrDefault()) : default;

        public decimal ToDecimal(T? value) => value.HasValue ? default(TNumericOperations).ToDecimal(value.GetValueOrDefault()) : default;

#if BIG_INTEGER
        public BigInteger ToBigInteger(T? value) => value.HasValue ? default(TNumericOperations).ToBigInteger(value.GetValueOrDefault()) : default;
#endif

        public bool IsEven(T? value) => value.HasValue ? default(TNumericOperations).IsEven(value.GetValueOrDefault()) : false;

        public bool IsOdd(T? value) => value.HasValue ? default(TNumericOperations).IsOdd(value.GetValueOrDefault()) : false;

        public bool IsPowerOfTwo(T? value) => value.HasValue ? default(TNumericOperations).IsPowerOfTwo(value.GetValueOrDefault()) : false;

        public T? Clamp(T? value, T? min, T? max) => value.HasValue && min.HasValue && max.HasValue ? default(TNumericOperations).Clamp(value.GetValueOrDefault(), min.GetValueOrDefault(), max.GetValueOrDefault()) : (T?)null;
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}