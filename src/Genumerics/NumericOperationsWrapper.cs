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
using System.Numerics;

namespace Genumerics
{
    // A class wrapper instead of using struct directly for better performance when used as an interface
    internal sealed class NumericOperationsWrapper<T, TNumericOperations> : INumericOperations<T>
        where TNumericOperations : struct, INumericOperations<T>
    {
        public T Zero => default(TNumericOperations).Zero;

        public T One => default(TNumericOperations).One;

        public T MinusOne => default(TNumericOperations).MinusOne;

        public T MaxValue => default(TNumericOperations).MaxValue;

        public T MinValue => default(TNumericOperations).MinValue;

        public TypeCode TypeCode => default(TNumericOperations).TypeCode;

        public T Abs(T value) => default(TNumericOperations).Abs(value);

        public T Add(T left, T right) => default(TNumericOperations).Add(left, right);

        public T BitwiseAnd(T left, T right) => default(TNumericOperations).BitwiseAnd(left, right);

        public T Ceiling(T value) => default(TNumericOperations).Ceiling(value);

        public T Clamp(T value, T min, T max) => default(TNumericOperations).Clamp(value, min, max);

        public int Compare(T left, T right) => default(TNumericOperations).Compare(left, right);

        public T Convert<TFrom>(TFrom value) => default(TNumericOperations).Convert(value);

        public T Divide(T dividend, T divisor) => default(TNumericOperations).Divide(dividend, divisor);

        public T DivRem(T dividend, T divisor, out T remainder) => default(TNumericOperations).DivRem(dividend, divisor, out remainder);

        public bool Equals(T left, T right) => default(TNumericOperations).Equals(left, right);

        public T Floor(T value) => default(TNumericOperations).Floor(value);

        public bool GreaterThan(T left, T right) => default(TNumericOperations).GreaterThan(left, right);

        public bool GreaterThanOrEqual(T left, T right) => default(TNumericOperations).GreaterThanOrEqual(left, right);

        public bool IsEven(T value) => default(TNumericOperations).IsEven(value);

        public bool IsOdd(T value) => default(TNumericOperations).IsOdd(value);

        public bool IsPowerOfTwo(T value) => default(TNumericOperations).IsPowerOfTwo(value);

        public T LeftShift(T value, int shift) => default(TNumericOperations).LeftShift(value, shift);

        public bool LessThan(T left, T right) => default(TNumericOperations).LessThan(left, right);

        public bool LessThanOrEqual(T left, T right) => default(TNumericOperations).LessThanOrEqual(left, right);

        public T Max(T left, T right) => default(TNumericOperations).Max(left, right);

        public T Min(T left, T right) => default(TNumericOperations).Min(left, right);

        public T Multiply(T left, T right) => default(TNumericOperations).Multiply(left, right);

        public T Negate(T value) => default(TNumericOperations).Negate(value);

        public T OnesComplement(T value) => default(TNumericOperations).OnesComplement(value);

        public bool NotEquals(T left, T right) => default(TNumericOperations).NotEquals(left, right);

        public T BitwiseOr(T left, T right) => default(TNumericOperations).BitwiseOr(left, right);

        public T Parse(string value, NumberStyles? style, IFormatProvider? provider) => default(TNumericOperations).Parse(value, style, provider);

        public T Remainder(T dividend, T divisor) => default(TNumericOperations).Remainder(dividend, divisor);

        public T RightShift(T value, int shift) => default(TNumericOperations).RightShift(value, shift);

        public T Round(T value, int digits, MidpointRounding mode) => default(TNumericOperations).Round(value, digits, mode);

        public int Sign(T value) => default(TNumericOperations).Sign(value);

        public T Subtract(T left, T right) => default(TNumericOperations).Subtract(left, right);

        public BigInteger ToBigInteger(T value) => default(TNumericOperations).ToBigInteger(value);

        public byte ToByte(T value) => default(TNumericOperations).ToByte(value);

        public decimal ToDecimal(T value) => default(TNumericOperations).ToDecimal(value);

        public double ToDouble(T value) => default(TNumericOperations).ToDouble(value);

        public short ToInt16(T value) => default(TNumericOperations).ToInt16(value);

        public int ToInt32(T value) => default(TNumericOperations).ToInt32(value);

        public long ToInt64(T value) => default(TNumericOperations).ToInt64(value);

        public sbyte ToSByte(T value) => default(TNumericOperations).ToSByte(value);

        public float ToSingle(T value) => default(TNumericOperations).ToSingle(value);

        public string? ToString(T value, string? format, IFormatProvider? provider) => default(TNumericOperations).ToString(value, format, provider);

        public ushort ToUInt16(T value) => default(TNumericOperations).ToUInt16(value);

        public uint ToUInt32(T value) => default(TNumericOperations).ToUInt32(value);

        public ulong ToUInt64(T value) => default(TNumericOperations).ToUInt64(value);

        public T Truncate(T value) => default(TNumericOperations).Truncate(value);

        public bool TryParse(string? value, NumberStyles? style, IFormatProvider? provider, out T result) => default(TNumericOperations).TryParse(value, style, provider, out result);

        public T Xor(T left, T right) => default(TNumericOperations).Xor(left, right);

#if SPAN
        public T Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider) => default(TNumericOperations).Parse(value, style, provider);

        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider, out T result) => default(TNumericOperations).TryParse(value, style, provider, out result);

        public bool TryFormat(T value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => default(TNumericOperations).TryFormat(value, destination, out charsWritten, format, provider);
#endif
    }
}