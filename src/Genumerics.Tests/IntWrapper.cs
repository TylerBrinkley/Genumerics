using System;
using System.Globalization;
using System.Numerics;

namespace Genumerics.Tests
{
    public struct IntWrapper
    {
        public int Value { get; }

        public IntWrapper(int value)
        {
            Value = value;
        }

        public static implicit operator IntWrapper(int value) => new IntWrapper(value);

        public static implicit operator int(IntWrapper value) => value.Value;
    }

    public struct IntWrapperOperations : INumericOperations<IntWrapper>
    {
        public IntWrapper Zero => Number.GetOperations<int>().Zero;

        public IntWrapper One => Number.GetOperations<int>().One;

        public IntWrapper MinusOne => Number.GetOperations<int>().MinusOne;

        public IntWrapper MaxValue => Number.GetOperations<int>().MaxValue;

        public IntWrapper MinValue => Number.GetOperations<int>().MinValue;

        public TypeCode TypeCode => Number.GetOperations<int>().TypeCode;

        public IntWrapper Abs(IntWrapper value) => Number.GetOperations<int>().Abs(value);
        public IntWrapper Add(IntWrapper left, IntWrapper right) => Number.GetOperations<int>().Add(left, right);
        public IntWrapper BitwiseAnd(IntWrapper left, IntWrapper right) => Number.GetOperations<int>().BitwiseAnd(left, right);
        public IntWrapper Ceiling(IntWrapper value) => Number.GetOperations<int>().Ceiling(value);
        public IntWrapper Clamp(IntWrapper value, IntWrapper min, IntWrapper max) => Number.GetOperations<int>().Clamp(value, min, max);
        public int Compare(IntWrapper left, IntWrapper right) => Number.GetOperations<int>().Compare(left, right);
        public IntWrapper Convert<TFrom>(TFrom value) => Number.GetOperations<int>().Convert(value);
        public IntWrapper Divide(IntWrapper dividend, IntWrapper divisor) => Number.GetOperations<int>().Divide(dividend, divisor);
        public IntWrapper DivRem(IntWrapper dividend, IntWrapper divisor, out IntWrapper remainder)
        {
            var result = Number.GetOperations<int>().DivRem(dividend, divisor, out var intRemainder);
            remainder = intRemainder;
            return result;
        }
        public bool Equals(IntWrapper left, IntWrapper right) => Number.GetOperations<int>().Equals(left, right);
        public IntWrapper Floor(IntWrapper value) => Number.GetOperations<int>().Floor(value);
        public bool GreaterThan(IntWrapper left, IntWrapper right) => Number.GetOperations<int>().GreaterThan(left, right);
        public bool GreaterThanOrEqual(IntWrapper left, IntWrapper right) => Number.GetOperations<int>().GreaterThanOrEqual(left, right);
        public bool IsEven(IntWrapper value) => Number.GetOperations<int>().IsEven(value);
        public bool IsOdd(IntWrapper value) => Number.GetOperations<int>().IsOdd(value);
        public bool IsPowerOfTwo(IntWrapper value) => Number.GetOperations<int>().IsPowerOfTwo(value);
        public IntWrapper LeftShift(IntWrapper value, int shift) => Number.GetOperations<int>().LeftShift(value, shift);
        public bool LessThan(IntWrapper left, IntWrapper right) => Number.GetOperations<int>().LessThan(left, right);
        public bool LessThanOrEqual(IntWrapper left, IntWrapper right) => Number.GetOperations<int>().LessThanOrEqual(left, right);
        public IntWrapper Max(IntWrapper left, IntWrapper right) => Number.GetOperations<int>().Max(left, right);
        public IntWrapper Min(IntWrapper left, IntWrapper right) => Number.GetOperations<int>().Min(left, right);
        public IntWrapper Multiply(IntWrapper left, IntWrapper right) => Number.GetOperations<int>().Multiply(left, right);
        public IntWrapper Negate(IntWrapper value) => Number.GetOperations<int>().Negate(value);
        public IntWrapper OnesComplement(IntWrapper value) => Number.GetOperations<int>().OnesComplement(value);
        public bool NotEquals(IntWrapper left, IntWrapper right) => Number.GetOperations<int>().NotEquals(left, right);
        public IntWrapper BitwiseOr(IntWrapper left, IntWrapper right) => Number.GetOperations<int>().BitwiseOr(left, right);
        public IntWrapper Parse(string value, NumberStyles? style, IFormatProvider provider) => Number.GetOperations<int>().Parse(value, style, provider);
#if SPAN
        public IntWrapper Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider) => Number.GetOperations<int>().Parse(value, style, provider);
#endif
        public IntWrapper Remainder(IntWrapper dividend, IntWrapper divisor) => Number.GetOperations<int>().Remainder(dividend, divisor);
        public IntWrapper RightShift(IntWrapper value, int shift) => Number.GetOperations<int>().RightShift(value, shift);
        public IntWrapper Round(IntWrapper value, int digits, MidpointRounding mode) => Number.GetOperations<int>().Round(value, digits, mode);
        public int Sign(IntWrapper value) => Number.GetOperations<int>().Sign(value);
        public IntWrapper Subtract(IntWrapper left, IntWrapper right) => Number.GetOperations<int>().Subtract(left, right);
        public BigInteger ToBigInteger(IntWrapper value) => Number.GetOperations<int>().ToBigInteger(value);
        public byte ToByte(IntWrapper value) => Number.GetOperations<int>().ToByte(value);
        public decimal ToDecimal(IntWrapper value) => Number.GetOperations<int>().ToDecimal(value);
        public double ToDouble(IntWrapper value) => Number.GetOperations<int>().ToDouble(value);
        public short ToInt16(IntWrapper value) => Number.GetOperations<int>().ToInt16(value);
        public int ToInt32(IntWrapper value) => Number.GetOperations<int>().ToInt32(value);
        public long ToInt64(IntWrapper value) => Number.GetOperations<int>().ToInt64(value);
        public sbyte ToSByte(IntWrapper value) => Number.GetOperations<int>().ToSByte(value);
        public float ToSingle(IntWrapper value) => Number.GetOperations<int>().ToSingle(value);
        public string ToString(IntWrapper value, string format, IFormatProvider provider) => Number.GetOperations<int>().ToString(value, format, provider);
        public ushort ToUInt16(IntWrapper value) => Number.GetOperations<int>().ToUInt16(value);
        public uint ToUInt32(IntWrapper value) => Number.GetOperations<int>().ToUInt32(value);
        public ulong ToUInt64(IntWrapper value) => Number.GetOperations<int>().ToUInt64(value);
        public IntWrapper Truncate(IntWrapper value) => Number.GetOperations<int>().Truncate(value);
#if SPAN
        public bool TryFormat(IntWrapper value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null) => Number.GetOperations<int>().TryFormat(value, destination, out charsWritten, format, provider);
#endif
        public bool TryParse(string value, NumberStyles? style, IFormatProvider provider, out IntWrapper result)
        {
            var success = Number.GetOperations<int>().TryParse(value, style, provider, out var intResult);
            result = intResult;
            return success;
        }
#if SPAN
        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider, out IntWrapper result)
        {
            var success = Number.GetOperations<int>().TryParse(value, style, provider, out var intResult);
            result = intResult;
            return success;
        }
#endif
        public IntWrapper Xor(IntWrapper left, IntWrapper right) => Number.GetOperations<int>().Xor(left, right);
    }
}
