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
        private readonly INumericOperations<T> _operations = Number<T>.GetOperations();

        public T? Zero => _operations.Zero;

        public T? One => _operations.One;

        public T? MinusOne => _operations.MinusOne;

        public T? MaxValue => _operations.MaxValue;

        public T? MinValue => _operations.MinValue;

#if ICONVERTIBLE
        public TypeCode TypeCode => _operations.TypeCode;
#endif

        public T? Add(T? left, T? right) => left.HasValue && right.HasValue ? _operations.Add(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? BitwiseAnd(T? left, T? right) => left.HasValue && right.HasValue ? _operations.BitwiseAnd(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? Divide(T? dividend, T? divisor) => dividend.HasValue && divisor.HasValue ? _operations.Divide(dividend.GetValueOrDefault(), divisor.GetValueOrDefault()) : (T?)null;

        public T? DivRem(T? dividend, T? divisor, out T? remainder)
        {
            if (dividend.HasValue && divisor.HasValue)
            {
                var result = _operations.DivRem(dividend.GetValueOrDefault(), divisor.GetValueOrDefault(), out T r);
                remainder = r;
                return result;
            }
            remainder = null;
            return null;
        }

        public bool Equals(T? left, T? right) => left.HasValue && right.HasValue ? _operations.Equals(left.GetValueOrDefault(), right.GetValueOrDefault()) : !left.HasValue && !right.HasValue;

        public bool GreaterThan(T? left, T? right) => left.HasValue && right.HasValue ? _operations.GreaterThan(left.GetValueOrDefault(), right.GetValueOrDefault()) : false;

        public bool GreaterThanOrEqual(T? left, T? right) => left.HasValue && right.HasValue ? _operations.GreaterThanOrEqual(left.GetValueOrDefault(), right.GetValueOrDefault()) : false;

        public T? LeftShift(T? value, int shift) => value.HasValue ? _operations.LeftShift(value.GetValueOrDefault(), shift) : value;

        public bool LessThan(T? left, T? right) => left.HasValue && right.HasValue ? _operations.LessThan(left.GetValueOrDefault(), right.GetValueOrDefault()) : false;

        public bool LessThanOrEqual(T? left, T? right) => left.HasValue && right.HasValue ? _operations.LessThanOrEqual(left.GetValueOrDefault(), right.GetValueOrDefault()) : false;

        public T? Multiply(T? left, T? right) => left.HasValue && right.HasValue ? _operations.Multiply(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? Negate(T? value) => value.HasValue ? _operations.Negate(value.GetValueOrDefault()) : value;

        public T? OnesComplement(T? value) => value.HasValue ? _operations.OnesComplement(value.GetValueOrDefault()) : value;

        public bool NotEquals(T? left, T? right) => left.HasValue && right.HasValue ? _operations.NotEquals(left.GetValueOrDefault(), right.GetValueOrDefault()) : left.HasValue || right.HasValue;

        public T? BitwiseOr(T? left, T? right) => left.HasValue && right.HasValue ? _operations.BitwiseOr(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? Parse(string value, NumberStyles? styles, IFormatProvider? provider) => _operations.Parse(value, styles, provider);

        public T? Remainder(T? dividend, T? divisor) => dividend.HasValue && divisor.HasValue ? _operations.Remainder(dividend.GetValueOrDefault(), divisor.GetValueOrDefault()) : (T?)null;

        public T? RightShift(T? value, int shift) => value.HasValue ? _operations.RightShift(value.GetValueOrDefault(), shift) : value;

        public T? Subtract(T? left, T? right) => left.HasValue && right.HasValue ? _operations.Subtract(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public bool TryParse(string value, NumberStyles? styles, IFormatProvider? provider, out T? result)
        {
            var success = _operations.TryParse(value, styles, provider, out T r);
            result = r;
            return success;
        }

#if SPAN
        public T? Parse(ReadOnlySpan<char> value, NumberStyles? styles, IFormatProvider? provider) => _operations.Parse(value, styles, provider);

        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? styles, IFormatProvider? provider, out T? result)
        {
            var success = _operations.TryParse(value, styles, provider, out T r);
            result = r;
            return success;
        }

        public bool TryFormat(T? value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        {
            if (value.HasValue)
            {
                return _operations.TryFormat(value.GetValueOrDefault(), destination, out charsWritten, format, provider);
            }
            charsWritten = 0;
            return false;
        }
#endif

        public T? Xor(T? left, T? right) => left.HasValue && right.HasValue ? _operations.Xor(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? Convert<TFrom>(TFrom value) => _operations.Convert(value);

        public T? Round(T? value, int digits, MidpointRounding mode) => value.HasValue ? _operations.Round(value.GetValueOrDefault(), digits, mode) : value;

        public T? Floor(T? value) => value.HasValue ? _operations.Floor(value.GetValueOrDefault()) : value;

        public T? Ceiling(T? value) => value.HasValue ? _operations.Ceiling(value.GetValueOrDefault()) : value;

        public T? Truncate(T? value) => value.HasValue ? _operations.Truncate(value.GetValueOrDefault()) : value;

        public int Compare(T? left, T? right) => left.HasValue && right.HasValue ? _operations.Compare(left.GetValueOrDefault(), right.GetValueOrDefault()) : (left.HasValue ? 1 : (right.HasValue ? -1 : 0));

        public T? Abs(T? value) => value.HasValue ? _operations.Abs(value.GetValueOrDefault()) : value;

        public T? Max(T? left, T? right) => left.HasValue && right.HasValue ? _operations.Max(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public T? Min(T? left, T? right) => left.HasValue && right.HasValue ? _operations.Min(left.GetValueOrDefault(), right.GetValueOrDefault()) : (T?)null;

        public int Sign(T? value) => value.HasValue ? _operations.Sign(value.GetValueOrDefault()) : -2;

        public string? ToString(T? value, string? format, IFormatProvider? provider) => value.HasValue ? _operations.ToString(value.GetValueOrDefault(), format, provider) : null;

        public sbyte ToSByte(T? value) => value.HasValue ? _operations.ToSByte(value.GetValueOrDefault()) : default;

        public byte ToByte(T? value) => value.HasValue ? _operations.ToByte(value.GetValueOrDefault()) : default;

        public short ToInt16(T? value) => value.HasValue ? _operations.ToInt16(value.GetValueOrDefault()) : default;

        public ushort ToUInt16(T? value) => value.HasValue ? _operations.ToUInt16(value.GetValueOrDefault()) : default;

        public int ToInt32(T? value) => value.HasValue ? _operations.ToInt32(value.GetValueOrDefault()) : default;

        public uint ToUInt32(T? value) => value.HasValue ? _operations.ToUInt32(value.GetValueOrDefault()) : default;

        public long ToInt64(T? value) => value.HasValue ? _operations.ToInt64(value.GetValueOrDefault()) : default;

        public ulong ToUInt64(T? value) => value.HasValue ? _operations.ToUInt64(value.GetValueOrDefault()) : default;

        public float ToSingle(T? value) => value.HasValue ? _operations.ToSingle(value.GetValueOrDefault()) : default;

        public double ToDouble(T? value) => value.HasValue ? _operations.ToDouble(value.GetValueOrDefault()) : default;

        public decimal ToDecimal(T? value) => value.HasValue ? _operations.ToDecimal(value.GetValueOrDefault()) : default;

#if BIG_INTEGER
        public BigInteger ToBigInteger(T? value) => value.HasValue ? _operations.ToBigInteger(value.GetValueOrDefault()) : default;
#endif

        public bool IsEven(T? value) => value.HasValue ? _operations.IsEven(value.GetValueOrDefault()) : false;

        public bool IsOdd(T? value) => value.HasValue ? _operations.IsOdd(value.GetValueOrDefault()) : false;

        public bool IsPowerOfTwo(T? value) => value.HasValue ? _operations.IsPowerOfTwo(value.GetValueOrDefault()) : false;

        public T? Clamp(T? value, T? min, T? max) => value.HasValue && min.HasValue && max.HasValue ? _operations.Clamp(value.GetValueOrDefault(), min.GetValueOrDefault(), max.GetValueOrDefault()) : (T?)null;
    }
}