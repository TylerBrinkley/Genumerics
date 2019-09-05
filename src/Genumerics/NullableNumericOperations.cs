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
        /// <inheritdoc />
        public T? Zero => default(TNumericOperations).Zero;

        /// <inheritdoc />
        public T? One => default(TNumericOperations).One;

        /// <inheritdoc />
        public T? MinusOne => default(TNumericOperations).MinusOne;

        /// <inheritdoc />
        public T? MaxValue => default(TNumericOperations).MaxValue;

        /// <inheritdoc />
        public T? MinValue => default(TNumericOperations).MinValue;

#if ICONVERTIBLE
        /// <inheritdoc />
        public TypeCode TypeCode => default(TNumericOperations).TypeCode;
#endif

        /// <inheritdoc />
        public T? Add(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).Add(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        /// <inheritdoc />
        public T? BitwiseAnd(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).BitwiseAnd(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        /// <inheritdoc />
        public T? Divide(T? dividend, T? divisor) => dividend.HasValue && divisor.HasValue ? default(TNumericOperations).Divide(dividend.GetValueOrDefault(), divisor.GetValueOrDefault()) : (T?)null;

        /// <inheritdoc />
        public T? DivRem(T? dividend, T? divisor, out T? remainder)
        {
            if (dividend.HasValue && divisor.HasValue)
            {
                var result = default(TNumericOperations).DivRem(dividend.GetValueOrDefault(), divisor.GetValueOrDefault(), out var r);
                remainder = r;
                return result;
            }
            remainder = null;
            return null;
        }

        /// <inheritdoc />
        public bool Equals(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).Equals(left.GetValueOrDefault(), right.GetValueOrDefault()) : !left.HasValue && !right.HasValue;

        /// <inheritdoc />
        public bool GreaterThan(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).GreaterThan(left.GetValueOrDefault(), right.GetValueOrDefault()) : false;

        /// <inheritdoc />
        public bool GreaterThanOrEqual(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).GreaterThanOrEqual(left.GetValueOrDefault(), right.GetValueOrDefault()) : false;

        /// <inheritdoc />
        public T? LeftShift(T? value, int shift) => value.HasValue ? default(TNumericOperations).LeftShift(value.GetValueOrDefault(), shift) : value;

        /// <inheritdoc />
        public bool LessThan(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).LessThan(left.GetValueOrDefault(), right.GetValueOrDefault()) : false;

        /// <inheritdoc />
        public bool LessThanOrEqual(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).LessThanOrEqual(left.GetValueOrDefault(), right.GetValueOrDefault()) : false;

        /// <inheritdoc />
        public T? Multiply(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).Multiply(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        /// <inheritdoc />
        public T? Negate(T? value) => value.HasValue ? default(TNumericOperations).Negate(value.GetValueOrDefault()) : value;

        /// <inheritdoc />
        public T? OnesComplement(T? value) => value.HasValue ? default(TNumericOperations).OnesComplement(value.GetValueOrDefault()) : value;

        /// <inheritdoc />
        public bool NotEquals(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).NotEquals(left.GetValueOrDefault(), right.GetValueOrDefault()) : left.HasValue || right.HasValue;

        /// <inheritdoc />
        public T? BitwiseOr(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).BitwiseOr(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        /// <inheritdoc />
        public T? Parse(string value, NumberStyles? styles, IFormatProvider? provider) => default(TNumericOperations).Parse(value, styles, provider);

        /// <inheritdoc />
        public T? Remainder(T? dividend, T? divisor) => dividend.HasValue && divisor.HasValue ? default(TNumericOperations).Remainder(dividend.GetValueOrDefault(), divisor.GetValueOrDefault()) : (T?)null;

        /// <inheritdoc />
        public T? RightShift(T? value, int shift) => value.HasValue ? default(TNumericOperations).RightShift(value.GetValueOrDefault(), shift) : value;

        /// <inheritdoc />
        public T? Subtract(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).Subtract(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        /// <inheritdoc />
        public bool TryParse(string value, NumberStyles? styles, IFormatProvider? provider, out T? result)
        {
            var success = default(TNumericOperations).TryParse(value, styles, provider, out var r);
            result = r;
            return success;
        }

#if SPAN
        /// <inheritdoc />
        public T? Parse(ReadOnlySpan<char> value, NumberStyles? styles, IFormatProvider? provider) => default(TNumericOperations).Parse(value, styles, provider);

        /// <inheritdoc />
        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? styles, IFormatProvider? provider, out T? result)
        {
            var success = default(TNumericOperations).TryParse(value, styles, provider, out var r);
            result = r;
            return success;
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public T? Xor(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).Xor(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        /// <inheritdoc />
        public T? Convert<TFrom>(TFrom value) => value != null ? default(TNumericOperations).Convert(value) : (T?)null;

        /// <inheritdoc />
        public T? Round(T? value, int digits, MidpointRounding mode) => value.HasValue ? default(TNumericOperations).Round(value.GetValueOrDefault(), digits, mode) : value;

        /// <inheritdoc />
        public T? Floor(T? value) => value.HasValue ? default(TNumericOperations).Floor(value.GetValueOrDefault()) : value;

        /// <inheritdoc />
        public T? Ceiling(T? value) => value.HasValue ? default(TNumericOperations).Ceiling(value.GetValueOrDefault()) : value;

        /// <inheritdoc />
        public T? Truncate(T? value) => value.HasValue ? default(TNumericOperations).Truncate(value.GetValueOrDefault()) : value;

        /// <inheritdoc />
        public int Compare(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).Compare(left.GetValueOrDefault(), right.GetValueOrDefault()) : (left.HasValue ? 1 : (right.HasValue ? -1 : 0));

        /// <inheritdoc />
        public T? Abs(T? value) => value.HasValue ? default(TNumericOperations).Abs(value.GetValueOrDefault()) : value;

        /// <inheritdoc />
        public T? Max(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).Max(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        /// <inheritdoc />
        public T? Min(T? left, T? right) => left.HasValue && right.HasValue ? default(TNumericOperations).Min(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        /// <inheritdoc />
        public int Sign(T? value) => value.HasValue ? default(TNumericOperations).Sign(value.GetValueOrDefault()) : -2;

        /// <inheritdoc />
        public string? ToString(T? value, string? format, IFormatProvider? provider) => value.HasValue ? default(TNumericOperations).ToString(value.GetValueOrDefault(), format, provider) : null;

        /// <inheritdoc />
        public sbyte ToSByte(T? value) => value.HasValue ? default(TNumericOperations).ToSByte(value.GetValueOrDefault()) : default;

        /// <inheritdoc />
        public byte ToByte(T? value) => value.HasValue ? default(TNumericOperations).ToByte(value.GetValueOrDefault()) : default;

        /// <inheritdoc />
        public short ToInt16(T? value) => value.HasValue ? default(TNumericOperations).ToInt16(value.GetValueOrDefault()) : default;

        /// <inheritdoc />
        public ushort ToUInt16(T? value) => value.HasValue ? default(TNumericOperations).ToUInt16(value.GetValueOrDefault()) : default;

        /// <inheritdoc />
        public int ToInt32(T? value) => value.HasValue ? default(TNumericOperations).ToInt32(value.GetValueOrDefault()) : default;

        /// <inheritdoc />
        public uint ToUInt32(T? value) => value.HasValue ? default(TNumericOperations).ToUInt32(value.GetValueOrDefault()) : default;

        /// <inheritdoc />
        public long ToInt64(T? value) => value.HasValue ? default(TNumericOperations).ToInt64(value.GetValueOrDefault()) : default;

        /// <inheritdoc />
        public ulong ToUInt64(T? value) => value.HasValue ? default(TNumericOperations).ToUInt64(value.GetValueOrDefault()) : default;

        /// <inheritdoc />
        public float ToSingle(T? value) => value.HasValue ? default(TNumericOperations).ToSingle(value.GetValueOrDefault()) : default;

        /// <inheritdoc />
        public double ToDouble(T? value) => value.HasValue ? default(TNumericOperations).ToDouble(value.GetValueOrDefault()) : default;

        /// <inheritdoc />
        public decimal ToDecimal(T? value) => value.HasValue ? default(TNumericOperations).ToDecimal(value.GetValueOrDefault()) : default;

#if BIG_INTEGER
        /// <inheritdoc />
        public BigInteger ToBigInteger(T? value) => value.HasValue ? default(TNumericOperations).ToBigInteger(value.GetValueOrDefault()) : default;
#endif

        /// <inheritdoc />
        public bool IsEven(T? value) => value.HasValue ? default(TNumericOperations).IsEven(value.GetValueOrDefault()) : false;

        /// <inheritdoc />
        public bool IsOdd(T? value) => value.HasValue ? default(TNumericOperations).IsOdd(value.GetValueOrDefault()) : false;

        /// <inheritdoc />
        public bool IsPowerOfTwo(T? value) => value.HasValue ? default(TNumericOperations).IsPowerOfTwo(value.GetValueOrDefault()) : false;

        /// <inheritdoc />
        public T? Clamp(T? value, T? min, T? max) => value.HasValue && min.HasValue && max.HasValue ? default(TNumericOperations).Clamp(value.GetValueOrDefault(), min.GetValueOrDefault(), max.GetValueOrDefault()) : (T?)null;

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is NullableNumericOperations<T, TNumericOperations>;

        /// <inheritdoc />
        public override int GetHashCode() => nameof(NullableNumericOperations<T, TNumericOperations>).GetHashCode();

#pragma warning disable IDE0060 // Remove unused parameter
                               /// <inheritdoc />
        public static bool operator ==(NullableNumericOperations<T, TNumericOperations> left, NullableNumericOperations<T, TNumericOperations> right) => true;

        /// <inheritdoc />
        public static bool operator !=(NullableNumericOperations<T, TNumericOperations> left, NullableNumericOperations<T, TNumericOperations> right) => false;
#pragma warning restore IDE0060 // Remove unused parameter
    }
}