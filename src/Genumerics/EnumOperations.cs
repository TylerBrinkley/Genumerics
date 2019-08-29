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
    /// Defines the numeric operations for enums.
    /// </summary>
    /// <typeparam name="TEnum">The enum type.</typeparam>
    /// <typeparam name="TUnderlying">The enum's underlying type.</typeparam>
    /// <typeparam name="TUnderlyingOperations">The underlying type's operations type.</typeparam>
    [CLSCompliant(false)]
    public struct EnumOperations<TEnum, TUnderlying, TUnderlyingOperations> : INumericOperations<TEnum>
        where TEnum : struct, Enum
        where TUnderlying : struct
        where TUnderlyingOperations : struct, INumericOperations<TUnderlying>
    {
#pragma warning disable IDE0052 // Remove unread private members, this will ensure a TypeInitializationException will occur when used improperly
        private static readonly bool s_initialized = Enum.GetUnderlyingType(typeof(TEnum)) == typeof(TUnderlying) ? true : throw new InvalidOperationException("TUnderlying must be TEnum's underlying type");
#pragma warning restore IDE0052 // Remove unread private members

        public TEnum Zero => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).Zero);

        public TEnum One => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).One);

        public TEnum MinusOne => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).MinusOne);

        public TEnum MaxValue => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).MaxValue);

        public TEnum MinValue => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).MinValue);

#if ICONVERTIBLE
        public TypeCode TypeCode => default(TUnderlyingOperations).TypeCode;
#endif

        public TEnum Abs(TEnum value) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).Abs(Unsafe.As<TEnum, TUnderlying>(value)));
        public TEnum Add(TEnum left, TEnum right) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).Add(Unsafe.As<TEnum, TUnderlying>(left), Unsafe.As<TEnum, TUnderlying>(right)));
        public TEnum BitwiseAnd(TEnum left, TEnum right) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).BitwiseAnd(Unsafe.As<TEnum, TUnderlying>(left), Unsafe.As<TEnum, TUnderlying>(right)));
        public TEnum Ceiling(TEnum value) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).Ceiling(Unsafe.As<TEnum, TUnderlying>(value)));
        public TEnum Clamp(TEnum value, TEnum min, TEnum max) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).Clamp(Unsafe.As<TEnum, TUnderlying>(value), Unsafe.As<TEnum, TUnderlying>(min), Unsafe.As<TEnum, TUnderlying>(max)));
        public int Compare(TEnum left, TEnum right) => default(TUnderlyingOperations).Compare(Unsafe.As<TEnum, TUnderlying>(left), Unsafe.As<TEnum, TUnderlying>(right));
        public TEnum Convert<TFrom>(TFrom value) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).Convert(value));
        public TEnum Divide(TEnum dividend, TEnum divisor) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).Divide(Unsafe.As<TEnum, TUnderlying>(dividend), Unsafe.As<TEnum, TUnderlying>(divisor)));
        public TEnum DivRem(TEnum dividend, TEnum divisor, out TEnum remainder)
        {
            var result = Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).DivRem(Unsafe.As<TEnum, TUnderlying>(dividend), Unsafe.As<TEnum, TUnderlying>(divisor), out TUnderlying r));
            remainder = Unsafe.As<TUnderlying, TEnum>(r);
            return result;
        }
        public bool Equals(TEnum left, TEnum right) => default(TUnderlyingOperations).Equals(Unsafe.As<TEnum, TUnderlying>(left), Unsafe.As<TEnum, TUnderlying>(right));
        public TEnum Floor(TEnum value) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).Floor(Unsafe.As<TEnum, TUnderlying>(value)));
        public bool GreaterThan(TEnum left, TEnum right) => default(TUnderlyingOperations).GreaterThan(Unsafe.As<TEnum, TUnderlying>(left), Unsafe.As<TEnum, TUnderlying>(right));
        public bool GreaterThanOrEqual(TEnum left, TEnum right) => default(TUnderlyingOperations).GreaterThanOrEqual(Unsafe.As<TEnum, TUnderlying>(left), Unsafe.As<TEnum, TUnderlying>(right));
        public bool IsEven(TEnum value) => default(TUnderlyingOperations).IsEven(Unsafe.As<TEnum, TUnderlying>(value));
        public bool IsOdd(TEnum value) => default(TUnderlyingOperations).IsOdd(Unsafe.As<TEnum, TUnderlying>(value));
        public bool IsPowerOfTwo(TEnum value) => default(TUnderlyingOperations).IsPowerOfTwo(Unsafe.As<TEnum, TUnderlying>(value));
        public TEnum LeftShift(TEnum value, int shift) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).LeftShift(Unsafe.As<TEnum, TUnderlying>(value), shift));
        public bool LessThan(TEnum left, TEnum right) => default(TUnderlyingOperations).LessThan(Unsafe.As<TEnum, TUnderlying>(left), Unsafe.As<TEnum, TUnderlying>(right));
        public bool LessThanOrEqual(TEnum left, TEnum right) => default(TUnderlyingOperations).LessThanOrEqual(Unsafe.As<TEnum, TUnderlying>(left), Unsafe.As<TEnum, TUnderlying>(right));
        public TEnum Max(TEnum left, TEnum right) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).Max(Unsafe.As<TEnum, TUnderlying>(left), Unsafe.As<TEnum, TUnderlying>(right)));
        public TEnum Min(TEnum left, TEnum right) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).Min(Unsafe.As<TEnum, TUnderlying>(left), Unsafe.As<TEnum, TUnderlying>(right)));
        public TEnum Multiply(TEnum left, TEnum right) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).Multiply(Unsafe.As<TEnum, TUnderlying>(left), Unsafe.As<TEnum, TUnderlying>(right)));
        public TEnum Negate(TEnum value) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).Negate(Unsafe.As<TEnum, TUnderlying>(value)));
        public TEnum OnesComplement(TEnum value) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).OnesComplement(Unsafe.As<TEnum, TUnderlying>(value)));
        public bool NotEquals(TEnum left, TEnum right) => default(TUnderlyingOperations).NotEquals(Unsafe.As<TEnum, TUnderlying>(left), Unsafe.As<TEnum, TUnderlying>(right));
        public TEnum BitwiseOr(TEnum left, TEnum right) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).BitwiseOr(Unsafe.As<TEnum, TUnderlying>(left), Unsafe.As<TEnum, TUnderlying>(right)));
        public TEnum Parse(string value, NumberStyles? style, IFormatProvider? provider) => style.HasValue ?
            Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).Parse(value, style, provider)) :
#if GENERIC_ENUM_PARSE
            Enum.Parse<TEnum>(value);
#else
            (TEnum)Enum.Parse(typeof(TEnum), value);
#endif
#if SPAN
        public TEnum Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider) => style.HasValue ?
            Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).Parse(value, style, provider)) :
            Enum.Parse<TEnum>(value.ToString());
#endif
        public TEnum Remainder(TEnum dividend, TEnum divisor) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).Remainder(Unsafe.As<TEnum, TUnderlying>(dividend), Unsafe.As<TEnum, TUnderlying>(divisor)));
        public TEnum RightShift(TEnum value, int shift) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).RightShift(Unsafe.As<TEnum, TUnderlying>(value), shift));
        public TEnum Round(TEnum value, int digits, MidpointRounding mode) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).Round(Unsafe.As<TEnum, TUnderlying>(value), digits, mode));
        public int Sign(TEnum value) => default(TUnderlyingOperations).Sign(Unsafe.As<TEnum, TUnderlying>(value));
        public TEnum Subtract(TEnum left, TEnum right) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).Subtract(Unsafe.As<TEnum, TUnderlying>(left), Unsafe.As<TEnum, TUnderlying>(right)));
#if BIG_INTEGER
        public BigInteger ToBigInteger(TEnum value) => default(TUnderlyingOperations).ToBigInteger(Unsafe.As<TEnum, TUnderlying>(value));
#endif
        public byte ToByte(TEnum value) => default(TUnderlyingOperations).ToByte(Unsafe.As<TEnum, TUnderlying>(value));
        public decimal ToDecimal(TEnum value) => default(TUnderlyingOperations).ToDecimal(Unsafe.As<TEnum, TUnderlying>(value));
        public double ToDouble(TEnum value) => default(TUnderlyingOperations).ToDouble(Unsafe.As<TEnum, TUnderlying>(value));
        public short ToInt16(TEnum value) => default(TUnderlyingOperations).ToInt16(Unsafe.As<TEnum, TUnderlying>(value));
        public int ToInt32(TEnum value) => default(TUnderlyingOperations).ToInt32(Unsafe.As<TEnum, TUnderlying>(value));
        public long ToInt64(TEnum value) => default(TUnderlyingOperations).ToInt64(Unsafe.As<TEnum, TUnderlying>(value));
        public sbyte ToSByte(TEnum value) => default(TUnderlyingOperations).ToSByte(Unsafe.As<TEnum, TUnderlying>(value));
        public float ToSingle(TEnum value) => default(TUnderlyingOperations).ToSingle(Unsafe.As<TEnum, TUnderlying>(value));
        public string ToString(TEnum value, string? format, IFormatProvider? provider) => value.ToString(format);
        public ushort ToUInt16(TEnum value) => default(TUnderlyingOperations).ToUInt16(Unsafe.As<TEnum, TUnderlying>(value));
        public uint ToUInt32(TEnum value) => default(TUnderlyingOperations).ToUInt32(Unsafe.As<TEnum, TUnderlying>(value));
        public ulong ToUInt64(TEnum value) => default(TUnderlyingOperations).ToUInt64(Unsafe.As<TEnum, TUnderlying>(value));
        public TEnum Truncate(TEnum value) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).Truncate(Unsafe.As<TEnum, TUnderlying>(value)));
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
                result = Unsafe.As<TUnderlying, TEnum>(r);
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
                result = Unsafe.As<TUnderlying, TEnum>(r);
                return success;
            }
            return Enum.TryParse(value.ToString(), out result);
        }
#endif
        public TEnum Xor(TEnum left, TEnum right) => Unsafe.As<TUnderlying, TEnum>(default(TUnderlyingOperations).Xor(Unsafe.As<TEnum, TUnderlying>(left), Unsafe.As<TEnum, TUnderlying>(right)));
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}