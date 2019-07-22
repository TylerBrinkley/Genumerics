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
    internal interface INumericOperations<T>
    {
        T Zero { get; }
        T One { get; }
        T MinusOne { get; }
        T MaxValue { get; }
        T MinValue { get; }
#if TYPE_CODE
        TypeCode TypeCode { get; }
#endif
        bool Equals(T left, T right);
        bool NotEquals(T left, T right);
        bool LessThan(T left, T right);
        bool LessThanOrEquals(T left, T right);
        bool GreaterThan(T left, T right);
        bool GreaterThanOrEquals(T left, T right);
        T Add(T left, T right);
        T Subtract(T left, T right);
        T Multiply(T left, T right);
        T Divide(T dividend, T divisor);
        T Remainder(T dividend, T divisor);
        T Negate(T value);
        T And(T left, T right);
        T Or(T left, T right);
        T Xor(T left, T right);
        T Not(T value);
        T LeftShift(T value, int shift);
        T RightShift(T value, int shift);
        T Parse(ParseType value, NumberStyles? style, IFormatProvider provider);
        bool TryParse(ParseType value, NumberStyles? style, IFormatProvider provider, out T result);
        T Convert<TFrom>(TFrom value);
        T Round(T value, int digits, MidpointRounding mode);
        T Floor(T value);
        T Ceiling(T value);
        T Truncate(T value);
        int Compare(T left, T right);
        T Abs(T value);
        T Max(T left, T right);
        T Min(T left, T right);
        int Sign(T value);
        string ToString(T value, string format, IFormatProvider provider);
        sbyte ToSByte(T value);
        byte ToByte(T value);
        short ToInt16(T value);
        ushort ToUInt16(T value);
        int ToInt32(T value);
        uint ToUInt32(T value);
        long ToInt64(T value);
        ulong ToUInt64(T value);
        float ToSingle(T value);
        double ToDouble(T value);
        decimal ToDecimal(T value);
#if BIG_INTEGER
        BigInteger ToBigInteger(T value);
#endif
        bool IsEven(T value);
        bool IsOdd(T value);
        bool IsPowerOfTwo(T value);
        T Clamp(T value, T min, T max);
    }
}