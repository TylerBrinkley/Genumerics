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

#if UNSAFE || AGGRESSIVE_INLINING
using System.Runtime.CompilerServices;
#endif

namespace Genumerics
{
    internal sealed class EnumOperations<TEnum, TUnderlying, TUnderlyingOperations> : INumericOperations<TEnum>
        where TEnum : struct, Enum
        where TUnderlying : struct
        where TUnderlyingOperations : struct, INumericOperations<TUnderlying>
    {
#if AGGRESSIVE_INLINING
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        private static TEnum ToEnum(TUnderlying value) => Unsafe.As<TUnderlying, TEnum>(ref value);

#if AGGRESSIVE_INLINING
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        private static TUnderlying ToUnderlying(TEnum value) => Unsafe.As<TEnum, TUnderlying>(ref value);

        public TEnum Zero => ToEnum(default(TUnderlyingOperations).Zero);

        public TEnum One => ToEnum(default(TUnderlyingOperations).One);

        public TEnum MinusOne => ToEnum(default(TUnderlyingOperations).MinusOne);

        public TEnum MaxValue => ToEnum(default(TUnderlyingOperations).MaxValue);

        public TEnum MinValue => ToEnum(default(TUnderlyingOperations).MinValue);

#if ICONVERTIBLE
        public TypeCode TypeCode => default(TUnderlyingOperations).TypeCode;
#endif

        public TEnum Abs(TEnum value) => ToEnum(default(TUnderlyingOperations).Abs(ToUnderlying(value)));
        public TEnum Add(TEnum left, TEnum right) => ToEnum(default(TUnderlyingOperations).Add(ToUnderlying(left), ToUnderlying(right)));
        public TEnum BitwiseAnd(TEnum left, TEnum right) => ToEnum(default(TUnderlyingOperations).BitwiseAnd(ToUnderlying(left), ToUnderlying(right)));
        public TEnum Ceiling(TEnum value) => ToEnum(default(TUnderlyingOperations).Ceiling(ToUnderlying(value)));
        public TEnum Clamp(TEnum value, TEnum min, TEnum max) => ToEnum(default(TUnderlyingOperations).Clamp(ToUnderlying(value), ToUnderlying(min), ToUnderlying(max)));
        public int Compare(TEnum left, TEnum right) => default(TUnderlyingOperations).Compare(ToUnderlying(left), ToUnderlying(right));
        public TEnum Convert<TFrom>(TFrom value) => ToEnum(default(TUnderlyingOperations).Convert(value));
        public TEnum Divide(TEnum dividend, TEnum divisor) => ToEnum(default(TUnderlyingOperations).Divide(ToUnderlying(dividend), ToUnderlying(divisor)));
        public TEnum DivRem(TEnum dividend, TEnum divisor, out TEnum remainder)
        {
            var result = ToEnum(default(TUnderlyingOperations).DivRem(ToUnderlying(dividend), ToUnderlying(divisor), out TUnderlying r));
            remainder = ToEnum(r);
            return result;
        }
        public bool Equals(TEnum left, TEnum right) => default(TUnderlyingOperations).Equals(ToUnderlying(left), ToUnderlying(right));
        public TEnum Floor(TEnum value) => ToEnum(default(TUnderlyingOperations).Floor(ToUnderlying(value)));
        public bool GreaterThan(TEnum left, TEnum right) => default(TUnderlyingOperations).GreaterThan(ToUnderlying(left), ToUnderlying(right));
        public bool GreaterThanOrEqual(TEnum left, TEnum right) => default(TUnderlyingOperations).GreaterThanOrEqual(ToUnderlying(left), ToUnderlying(right));
        public bool IsEven(TEnum value) => default(TUnderlyingOperations).IsEven(ToUnderlying(value));
        public bool IsOdd(TEnum value) => default(TUnderlyingOperations).IsOdd(ToUnderlying(value));
        public bool IsPowerOfTwo(TEnum value) => default(TUnderlyingOperations).IsPowerOfTwo(ToUnderlying(value));
        public TEnum LeftShift(TEnum value, int shift) => ToEnum(default(TUnderlyingOperations).LeftShift(ToUnderlying(value), shift));
        public bool LessThan(TEnum left, TEnum right) => default(TUnderlyingOperations).LessThan(ToUnderlying(left), ToUnderlying(right));
        public bool LessThanOrEqual(TEnum left, TEnum right) => default(TUnderlyingOperations).LessThanOrEqual(ToUnderlying(left), ToUnderlying(right));
        public TEnum Max(TEnum left, TEnum right) => ToEnum(default(TUnderlyingOperations).Max(ToUnderlying(left), ToUnderlying(right)));
        public TEnum Min(TEnum left, TEnum right) => ToEnum(default(TUnderlyingOperations).Min(ToUnderlying(left), ToUnderlying(right)));
        public TEnum Multiply(TEnum left, TEnum right) => ToEnum(default(TUnderlyingOperations).Multiply(ToUnderlying(left), ToUnderlying(right)));
        public TEnum Negate(TEnum value) => ToEnum(default(TUnderlyingOperations).Negate(ToUnderlying(value)));
        public TEnum OnesComplement(TEnum value) => ToEnum(default(TUnderlyingOperations).OnesComplement(ToUnderlying(value)));
        public bool NotEquals(TEnum left, TEnum right) => default(TUnderlyingOperations).NotEquals(ToUnderlying(left), ToUnderlying(right));
        public TEnum BitwiseOr(TEnum left, TEnum right) => ToEnum(default(TUnderlyingOperations).BitwiseOr(ToUnderlying(left), ToUnderlying(right)));
        public TEnum Parse(string value, NumberStyles? style, IFormatProvider? provider) => style.HasValue ?
            ToEnum(default(TUnderlyingOperations).Parse(value, style, provider)) :
#if GENERIC_ENUM_PARSE
            Enum.Parse<TEnum>(value);
#else
            (TEnum)Enum.Parse(typeof(TEnum), value);
#endif
#if SPAN
        public TEnum Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider) => style.HasValue ?
            ToEnum(default(TUnderlyingOperations).Parse(value, style, provider)) :
            Enum.Parse<TEnum>(value.ToString());
#endif
        public TEnum Remainder(TEnum dividend, TEnum divisor) => ToEnum(default(TUnderlyingOperations).Remainder(ToUnderlying(dividend), ToUnderlying(divisor)));
        public TEnum RightShift(TEnum value, int shift) => ToEnum(default(TUnderlyingOperations).RightShift(ToUnderlying(value), shift));
        public TEnum Round(TEnum value, int digits, MidpointRounding mode) => ToEnum(default(TUnderlyingOperations).Round(ToUnderlying(value), digits, mode));
        public int Sign(TEnum value) => default(TUnderlyingOperations).Sign(ToUnderlying(value));
        public TEnum Subtract(TEnum left, TEnum right) => ToEnum(default(TUnderlyingOperations).Subtract(ToUnderlying(left), ToUnderlying(right)));
#if BIG_INTEGER
        public BigInteger ToBigInteger(TEnum value) => default(TUnderlyingOperations).ToBigInteger(ToUnderlying(value));
#endif
        public byte ToByte(TEnum value) => default(TUnderlyingOperations).ToByte(ToUnderlying(value));
        public decimal ToDecimal(TEnum value) => default(TUnderlyingOperations).ToDecimal(ToUnderlying(value));
        public double ToDouble(TEnum value) => default(TUnderlyingOperations).ToDouble(ToUnderlying(value));
        public short ToInt16(TEnum value) => default(TUnderlyingOperations).ToInt16(ToUnderlying(value));
        public int ToInt32(TEnum value) => default(TUnderlyingOperations).ToInt32(ToUnderlying(value));
        public long ToInt64(TEnum value) => default(TUnderlyingOperations).ToInt64(ToUnderlying(value));
        public sbyte ToSByte(TEnum value) => default(TUnderlyingOperations).ToSByte(ToUnderlying(value));
        public float ToSingle(TEnum value) => default(TUnderlyingOperations).ToSingle(ToUnderlying(value));
        public string ToString(TEnum value, string? format, IFormatProvider? provider) => value.ToString(format);
        public ushort ToUInt16(TEnum value) => default(TUnderlyingOperations).ToUInt16(ToUnderlying(value));
        public uint ToUInt32(TEnum value) => default(TUnderlyingOperations).ToUInt32(ToUnderlying(value));
        public ulong ToUInt64(TEnum value) => default(TUnderlyingOperations).ToUInt64(ToUnderlying(value));
        public TEnum Truncate(TEnum value) => ToEnum(default(TUnderlyingOperations).Truncate(ToUnderlying(value)));
#if SPAN
        public bool TryFormat(TEnum value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        {
            var str = value.ToString(format.ToString());
            str.AsSpan().CopyTo(destination);
            charsWritten = str.Length;
            return true;
        }
#endif
        public bool TryParse(string value, NumberStyles? style, IFormatProvider? provider, out TEnum result)
        {
            if (style.HasValue)
            {
                var success = default(TUnderlyingOperations).TryParse(value, style, provider, out TUnderlying r);
                result = ToEnum(r);
                return success;
            }
#if ENUM_TRYPARSE
            return Enum.TryParse(value, out result);
#else
            try
            {
                result = (TEnum)Enum.Parse(typeof(TEnum), value);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
#endif
        }
#if SPAN
        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider, out TEnum result)
        {
            if (style.HasValue)
            {
                var success = default(TUnderlyingOperations).TryParse(value, style, provider, out TUnderlying r);
                result = ToEnum(r);
                return success;
            }
            return Enum.TryParse(value.ToString(), out result);
        }
#endif
        public TEnum Xor(TEnum left, TEnum right) => ToEnum(default(TUnderlyingOperations).Xor(ToUnderlying(left), ToUnderlying(right)));
    }
}