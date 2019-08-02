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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member, type should only really be used through the interface as a type constraint.
                               // I'd make all the members use explicit interface implementation but that would greatly increase the library's dll size.
    /// <summary>
    /// Defines all the default numeric operations.
    /// </summary>
    [CLSCompliant(false)]
    public struct DefaultNumericOperations : INumericOperations<sbyte>, INumericOperations<byte>, INumericOperations<short>, INumericOperations<ushort>, INumericOperations<int>, INumericOperations<uint>, INumericOperations<long>, INumericOperations<ulong>, INumericOperations<float>, INumericOperations<double>, INumericOperations<decimal>
#if BIG_INTEGER
        , INumericOperations<BigInteger>
#endif
    {
        #region Zero
        sbyte INumericOperations<sbyte>.Zero => 0;

        byte INumericOperations<byte>.Zero => 0;

        short INumericOperations<short>.Zero => 0;

        ushort INumericOperations<ushort>.Zero => 0;

        int INumericOperations<int>.Zero => 0;

        uint INumericOperations<uint>.Zero => 0U;

        long INumericOperations<long>.Zero => 0L;

        ulong INumericOperations<ulong>.Zero => 0UL;

        float INumericOperations<float>.Zero => 0F;

        double INumericOperations<double>.Zero => 0D;

        decimal INumericOperations<decimal>.Zero => 0M;
        #endregion

        #region One
        sbyte INumericOperations<sbyte>.One => 1;

        byte INumericOperations<byte>.One => 1;

        short INumericOperations<short>.One => 1;

        ushort INumericOperations<ushort>.One => 1;

        int INumericOperations<int>.One => 1;

        uint INumericOperations<uint>.One => 1U;

        long INumericOperations<long>.One => 1L;

        ulong INumericOperations<ulong>.One => 1UL;

        float INumericOperations<float>.One => 1F;

        double INumericOperations<double>.One => 1D;

        decimal INumericOperations<decimal>.One => 1M;
        #endregion

        #region MinusOne
        sbyte INumericOperations<sbyte>.MinusOne => -1;

        byte INumericOperations<byte>.MinusOne => throw new NotSupportedException("unsigned integral type cannot be negative");

        short INumericOperations<short>.MinusOne => -1;

        ushort INumericOperations<ushort>.MinusOne => throw new NotSupportedException("unsigned integral type cannot be negative");

        int INumericOperations<int>.MinusOne => -1;

        uint INumericOperations<uint>.MinusOne => throw new NotSupportedException("unsigned integral type cannot be negative");

        long INumericOperations<long>.MinusOne => -1L;

        ulong INumericOperations<ulong>.MinusOne => throw new NotSupportedException("unsigned integral type cannot be negative");

        float INumericOperations<float>.MinusOne => -1F;

        double INumericOperations<double>.MinusOne => -1D;

        decimal INumericOperations<decimal>.MinusOne => -1M;
        #endregion

        #region MaxValue
        sbyte INumericOperations<sbyte>.MaxValue => sbyte.MaxValue;

        byte INumericOperations<byte>.MaxValue => byte.MaxValue;

        short INumericOperations<short>.MaxValue => short.MaxValue;

        ushort INumericOperations<ushort>.MaxValue => ushort.MaxValue;

        int INumericOperations<int>.MaxValue => int.MaxValue;

        uint INumericOperations<uint>.MaxValue => uint.MaxValue;

        long INumericOperations<long>.MaxValue => long.MaxValue;

        ulong INumericOperations<ulong>.MaxValue => ulong.MaxValue;

        float INumericOperations<float>.MaxValue => float.MaxValue;

        double INumericOperations<double>.MaxValue => double.MaxValue;

        decimal INumericOperations<decimal>.MaxValue => decimal.MaxValue;
        #endregion

        #region MinValue
        sbyte INumericOperations<sbyte>.MinValue => sbyte.MinValue;

        byte INumericOperations<byte>.MinValue => byte.MinValue;

        short INumericOperations<short>.MinValue => short.MinValue;

        ushort INumericOperations<ushort>.MinValue => ushort.MinValue;

        int INumericOperations<int>.MinValue => int.MinValue;

        uint INumericOperations<uint>.MinValue => uint.MinValue;

        long INumericOperations<long>.MinValue => long.MinValue;

        ulong INumericOperations<ulong>.MinValue => ulong.MinValue;

        float INumericOperations<float>.MinValue => float.MinValue;

        double INumericOperations<double>.MinValue => double.MinValue;

        decimal INumericOperations<decimal>.MinValue => decimal.MinValue;
        #endregion

        #region TypeCode
#if ICONVERTIBLE
        TypeCode INumericOperations<sbyte>.TypeCode => TypeCode.SByte;

        TypeCode INumericOperations<byte>.TypeCode => TypeCode.Byte;

        TypeCode INumericOperations<short>.TypeCode => TypeCode.Int16;

        TypeCode INumericOperations<ushort>.TypeCode => TypeCode.UInt16;

        TypeCode INumericOperations<int>.TypeCode => TypeCode.Int32;

        TypeCode INumericOperations<uint>.TypeCode => TypeCode.UInt32;

        TypeCode INumericOperations<long>.TypeCode => TypeCode.Int64;

        TypeCode INumericOperations<ulong>.TypeCode => TypeCode.UInt64;

        TypeCode INumericOperations<float>.TypeCode => TypeCode.Single;

        TypeCode INumericOperations<double>.TypeCode => TypeCode.Double;

        TypeCode INumericOperations<decimal>.TypeCode => TypeCode.Decimal;
#endif
        #endregion

        #region Equals
        public bool Equals(sbyte left, sbyte right) => left == right;

        public bool Equals(byte left, byte right) => left == right;

        public bool Equals(short left, short right) => left == right;

        public bool Equals(ushort left, ushort right) => left == right;

        public bool Equals(int left, int right) => left == right;

        public bool Equals(uint left, uint right) => left == right;

        public bool Equals(long left, long right) => left == right;

        public bool Equals(ulong left, ulong right) => left == right;

        public bool Equals(float left, float right) => left == right;

        public bool Equals(double left, double right) => left == right;

        public bool Equals(decimal left, decimal right) => left == right;
        #endregion

        #region NotEquals
        public bool NotEquals(sbyte left, sbyte right) => left != right;

        public bool NotEquals(byte left, byte right) => left != right;

        public bool NotEquals(short left, short right) => left != right;

        public bool NotEquals(ushort left, ushort right) => left != right;

        public bool NotEquals(int left, int right) => left != right;

        public bool NotEquals(uint left, uint right) => left != right;

        public bool NotEquals(long left, long right) => left != right;

        public bool NotEquals(ulong left, ulong right) => left != right;

        public bool NotEquals(float left, float right) => left != right;

        public bool NotEquals(double left, double right) => left != right;

        public bool NotEquals(decimal left, decimal right) => left != right;
        #endregion

        #region LessThan
        public bool LessThan(sbyte left, sbyte right) => left < right;

        public bool LessThan(byte left, byte right) => left < right;

        public bool LessThan(short left, short right) => left < right;

        public bool LessThan(ushort left, ushort right) => left < right;

        public bool LessThan(int left, int right) => left < right;

        public bool LessThan(uint left, uint right) => left < right;

        public bool LessThan(long left, long right) => left < right;

        public bool LessThan(ulong left, ulong right) => left < right;

        public bool LessThan(float left, float right) => left < right;

        public bool LessThan(double left, double right) => left < right;

        public bool LessThan(decimal left, decimal right) => left < right;
        #endregion

        #region LessThanOrEquals
        public bool LessThanOrEquals(sbyte left, sbyte right) => left <= right;

        public bool LessThanOrEquals(byte left, byte right) => left <= right;

        public bool LessThanOrEquals(short left, short right) => left <= right;

        public bool LessThanOrEquals(ushort left, ushort right) => left <= right;

        public bool LessThanOrEquals(int left, int right) => left <= right;

        public bool LessThanOrEquals(uint left, uint right) => left <= right;

        public bool LessThanOrEquals(long left, long right) => left <= right;

        public bool LessThanOrEquals(ulong left, ulong right) => left <= right;

        public bool LessThanOrEquals(float left, float right) => left <= right;

        public bool LessThanOrEquals(double left, double right) => left <= right;

        public bool LessThanOrEquals(decimal left, decimal right) => left <= right;
        #endregion

        #region GreaterThan
        public bool GreaterThan(sbyte left, sbyte right) => left > right;

        public bool GreaterThan(byte left, byte right) => left > right;

        public bool GreaterThan(short left, short right) => left > right;

        public bool GreaterThan(ushort left, ushort right) => left > right;

        public bool GreaterThan(int left, int right) => left > right;

        public bool GreaterThan(uint left, uint right) => left > right;

        public bool GreaterThan(long left, long right) => left > right;

        public bool GreaterThan(ulong left, ulong right) => left > right;

        public bool GreaterThan(float left, float right) => left > right;

        public bool GreaterThan(double left, double right) => left > right;

        public bool GreaterThan(decimal left, decimal right) => left > right;
        #endregion

        #region GreaterThanOrEquals
        public bool GreaterThanOrEquals(sbyte left, sbyte right) => left >= right;

        public bool GreaterThanOrEquals(byte left, byte right) => left >= right;

        public bool GreaterThanOrEquals(short left, short right) => left >= right;

        public bool GreaterThanOrEquals(ushort left, ushort right) => left >= right;

        public bool GreaterThanOrEquals(int left, int right) => left >= right;

        public bool GreaterThanOrEquals(uint left, uint right) => left >= right;

        public bool GreaterThanOrEquals(long left, long right) => left >= right;

        public bool GreaterThanOrEquals(ulong left, ulong right) => left >= right;

        public bool GreaterThanOrEquals(float left, float right) => left >= right;

        public bool GreaterThanOrEquals(double left, double right) => left >= right;

        public bool GreaterThanOrEquals(decimal left, decimal right) => left >= right;
        #endregion

        #region Add
        public sbyte Add(sbyte left, sbyte right) => (sbyte)(left + right);

        public byte Add(byte left, byte right) => (byte)(left + right);

        public short Add(short left, short right) => (short)(left + right);

        public ushort Add(ushort left, ushort right) => (ushort)(left + right);

        public int Add(int left, int right) => left + right;

        public uint Add(uint left, uint right) => left + right;

        public long Add(long left, long right) => left + right;

        public ulong Add(ulong left, ulong right) => left + right;

        public float Add(float left, float right) => left + right;

        public double Add(double left, double right) => left + right;

        public decimal Add(decimal left, decimal right) => left + right;
        #endregion

        #region Subtract
        public sbyte Subtract(sbyte left, sbyte right) => (sbyte)(left - right);

        public byte Subtract(byte left, byte right) => (byte)(left - right);

        public short Subtract(short left, short right) => (short)(left - right);

        public ushort Subtract(ushort left, ushort right) => (ushort)(left - right);

        public int Subtract(int left, int right) => left - right;

        public uint Subtract(uint left, uint right) => left - right;

        public long Subtract(long left, long right) => left - right;

        public ulong Subtract(ulong left, ulong right) => left - right;

        public float Subtract(float left, float right) => left - right;

        public double Subtract(double left, double right) => left - right;

        public decimal Subtract(decimal left, decimal right) => left - right;
        #endregion

        #region Multiply
        public sbyte Multiply(sbyte left, sbyte right) => (sbyte)(left * right);

        public byte Multiply(byte left, byte right) => (byte)(left * right);

        public short Multiply(short left, short right) => (short)(left * right);

        public ushort Multiply(ushort left, ushort right) => (ushort)(left * right);

        public int Multiply(int left, int right) => left * right;

        public uint Multiply(uint left, uint right) => left * right;

        public long Multiply(long left, long right) => left * right;

        public ulong Multiply(ulong left, ulong right) => left * right;

        public float Multiply(float left, float right) => left * right;

        public double Multiply(double left, double right) => left * right;

        public decimal Multiply(decimal left, decimal right) => left * right;
        #endregion

        #region Divide
        public sbyte Divide(sbyte dividend, sbyte divisor) => (sbyte)(dividend / divisor);

        public byte Divide(byte dividend, byte divisor) => (byte)(dividend / divisor);

        public short Divide(short dividend, short divisor) => (short)(dividend / divisor);

        public ushort Divide(ushort dividend, ushort divisor) => (ushort)(dividend / divisor);

        public int Divide(int dividend, int divisor) => dividend / divisor;

        public uint Divide(uint dividend, uint divisor) => dividend / divisor;

        public long Divide(long dividend, long divisor) => dividend / divisor;

        public ulong Divide(ulong dividend, ulong divisor) => dividend / divisor;

        public float Divide(float dividend, float divisor) => dividend / divisor;

        public double Divide(double dividend, double divisor) => dividend / divisor;

        public decimal Divide(decimal dividend, decimal divisor) => dividend / divisor;
        #endregion

        #region Remainder
        public sbyte Remainder(sbyte dividend, sbyte divisor) => (sbyte)(dividend % divisor);

        public byte Remainder(byte dividend, byte divisor) => (byte)(dividend % divisor);

        public short Remainder(short dividend, short divisor) => (short)(dividend % divisor);

        public ushort Remainder(ushort dividend, ushort divisor) => (ushort)(dividend % divisor);

        public int Remainder(int dividend, int divisor) => dividend % divisor;

        public uint Remainder(uint dividend, uint divisor) => dividend % divisor;

        public long Remainder(long dividend, long divisor) => dividend % divisor;

        public ulong Remainder(ulong dividend, ulong divisor) => dividend % divisor;

        public float Remainder(float dividend, float divisor) => dividend % divisor;

        public double Remainder(double dividend, double divisor) => dividend % divisor;

        public decimal Remainder(decimal dividend, decimal divisor) => dividend % divisor;
        #endregion

        #region DivRem
        public sbyte DivRem(sbyte dividend, sbyte divisor, out sbyte remainder)
        {
            remainder = (sbyte)(dividend % divisor);
            return (sbyte)(dividend / divisor);
        }

        public byte DivRem(byte dividend, byte divisor, out byte remainder)
        {
            remainder = (byte)(dividend % divisor);
            return (byte)(dividend / divisor);
        }

        public short DivRem(short dividend, short divisor, out short remainder)
        {
            remainder = (short)(dividend % divisor);
            return (short)(dividend / divisor);
        }

        public ushort DivRem(ushort dividend, ushort divisor, out ushort remainder)
        {
            remainder = (ushort)(dividend % divisor);
            return (ushort)(dividend / divisor);
        }

        public int DivRem(int dividend, int divisor, out int remainder)
        {
#if DIV_REM
            return Math.DivRem(dividend, divisor, out remainder);
#else
            remainder = dividend % divisor;
            return dividend / divisor;
#endif
        }

        public uint DivRem(uint dividend, uint divisor, out uint remainder)
        {
            remainder = dividend % divisor;
            return dividend / divisor;
        }

        public long DivRem(long dividend, long divisor, out long remainder)
        {
#if DIV_REM
            return Math.DivRem(dividend, divisor, out remainder);
#else
            remainder = dividend % divisor;
            return dividend / divisor;
#endif
        }

        public ulong DivRem(ulong dividend, ulong divisor, out ulong remainder)
        {
            remainder = dividend % divisor;
            return dividend / divisor;
        }

        public float DivRem(float dividend, float divisor, out float remainder)
        {
            remainder = dividend % divisor;
            return dividend / divisor;
        }

        public double DivRem(double dividend, double divisor, out double remainder)
        {
            remainder = dividend % divisor;
            return dividend / divisor;
        }

        public decimal DivRem(decimal dividend, decimal divisor, out decimal remainder)
        {
            remainder = dividend % divisor;
            return dividend / divisor;
        }
        #endregion

        #region Negate
        public sbyte Negate(sbyte value) => (sbyte)-value;

        public byte Negate(byte value) => throw new NotSupportedException("cannot negate unsigned integral type");

        public short Negate(short value) => (short)-value;

        public ushort Negate(ushort value) => throw new NotSupportedException("cannot negate unsigned integral type");

        public int Negate(int value) => -value;

        public uint Negate(uint value) => throw new NotSupportedException("cannot negate unsigned integral type");

        public long Negate(long value) => -value;

        public ulong Negate(ulong value) => throw new NotSupportedException("cannot negate unsigned integral type");

        public float Negate(float value) => -value;

        public double Negate(double value) => -value;

        public decimal Negate(decimal value) => -value;
        #endregion

        #region And
        public sbyte And(sbyte left, sbyte right) => (sbyte)(left & right);

        public byte And(byte left, byte right) => (byte)(left & right);

        public short And(short left, short right) => (short)(left & right);

        public ushort And(ushort left, ushort right) => (ushort)(left & right);

        public int And(int left, int right) => left & right;

        public uint And(uint left, uint right) => left & right;

        public long And(long left, long right) => left & right;

        public ulong And(ulong left, ulong right) => left & right;

        public float And(float left, float right) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        public double And(double left, double right) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        public decimal And(decimal left, decimal right) => throw new NotSupportedException("bitwise operations are not supported for floating point types");
        #endregion

        #region Or
        public sbyte Or(sbyte left, sbyte right) => (sbyte)(left | right);

        public byte Or(byte left, byte right) => (byte)(left | right);

        public short Or(short left, short right) => (short)(left | right);

        public ushort Or(ushort left, ushort right) => (ushort)(left | right);

        public int Or(int left, int right) => left | right;

        public uint Or(uint left, uint right) => left | right;

        public long Or(long left, long right) => left | right;

        public ulong Or(ulong left, ulong right) => left | right;

        public float Or(float left, float right) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        public double Or(double left, double right) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        public decimal Or(decimal left, decimal right) => throw new NotSupportedException("bitwise operations are not supported for floating point types");
        #endregion

        #region Xor
        public sbyte Xor(sbyte left, sbyte right) => (sbyte)(left ^ right);

        public byte Xor(byte left, byte right) => (byte)(left ^ right);

        public short Xor(short left, short right) => (short)(left ^ right);

        public ushort Xor(ushort left, ushort right) => (ushort)(left ^ right);

        public int Xor(int left, int right) => left ^ right;

        public uint Xor(uint left, uint right) => left ^ right;

        public long Xor(long left, long right) => left ^ right;

        public ulong Xor(ulong left, ulong right) => left ^ right;

        public float Xor(float left, float right) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        public double Xor(double left, double right) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        public decimal Xor(decimal left, decimal right) => throw new NotSupportedException("bitwise operations are not supported for floating point types");
        #endregion

        #region Not
        public sbyte Not(sbyte value) => (sbyte)~value;

        public byte Not(byte value) => (byte)~value;

        public short Not(short value) => (short)~value;

        public ushort Not(ushort value) => (ushort)~value;

        public int Not(int value) => ~value;

        public uint Not(uint value) => ~value;

        public long Not(long value) => ~value;

        public ulong Not(ulong value) => ~value;

        public float Not(float value) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        public double Not(double value) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        public decimal Not(decimal value) => throw new NotSupportedException("bitwise operations are not supported for floating point types");
        #endregion

        #region LeftShift
        public sbyte LeftShift(sbyte value, int shift) => (sbyte)(value << shift);

        public byte LeftShift(byte value, int shift) => (byte)(value << shift);

        public short LeftShift(short value, int shift) => (short)(value << shift);

        public ushort LeftShift(ushort value, int shift) => (ushort)(value << shift);

        public int LeftShift(int value, int shift) => value << shift;

        public uint LeftShift(uint value, int shift) => value << shift;

        public long LeftShift(long value, int shift) => value << shift;

        public ulong LeftShift(ulong value, int shift) => value << shift;

        public float LeftShift(float value, int shift) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        public double LeftShift(double value, int shift) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        public decimal LeftShift(decimal value, int shift) => throw new NotSupportedException("bitwise operations are not supported for floating point types");
        #endregion

        #region RightShift
        public sbyte RightShift(sbyte value, int shift) => (sbyte)(value >> shift);

        public byte RightShift(byte value, int shift) => (byte)(value >> shift);

        public short RightShift(short value, int shift) => (short)(value >> shift);

        public ushort RightShift(ushort value, int shift) => (ushort)(value >> shift);

        public int RightShift(int value, int shift) => value >> shift;

        public uint RightShift(uint value, int shift) => value >> shift;

        public long RightShift(long value, int shift) => value >> shift;

        public ulong RightShift(ulong value, int shift) => value >> shift;

        public float RightShift(float value, int shift) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        public double RightShift(double value, int shift) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        public decimal RightShift(decimal value, int shift) => throw new NotSupportedException("bitwise operations are not supported for floating point types");
        #endregion

        #region Parse
        sbyte INumericOperations<sbyte>.Parse(string value, NumberStyles? style, IFormatProvider provider) => sbyte.Parse(value, style ?? NumberStyles.Integer, provider);

        byte INumericOperations<byte>.Parse(string value, NumberStyles? style, IFormatProvider provider) => byte.Parse(value, style ?? NumberStyles.Integer, provider);

        short INumericOperations<short>.Parse(string value, NumberStyles? style, IFormatProvider provider) => short.Parse(value, style ?? NumberStyles.Integer, provider);

        ushort INumericOperations<ushort>.Parse(string value, NumberStyles? style, IFormatProvider provider) => ushort.Parse(value, style ?? NumberStyles.Integer, provider);

        int INumericOperations<int>.Parse(string value, NumberStyles? style, IFormatProvider provider) => int.Parse(value, style ?? NumberStyles.Integer, provider);

        uint INumericOperations<uint>.Parse(string value, NumberStyles? style, IFormatProvider provider) => uint.Parse(value, style ?? NumberStyles.Integer, provider);

        long INumericOperations<long>.Parse(string value, NumberStyles? style, IFormatProvider provider) => long.Parse(value, style ?? NumberStyles.Integer, provider);

        ulong INumericOperations<ulong>.Parse(string value, NumberStyles? style, IFormatProvider provider) => ulong.Parse(value, style ?? NumberStyles.Integer, provider);

        float INumericOperations<float>.Parse(string value, NumberStyles? style, IFormatProvider provider) => float.Parse(value, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider);

        double INumericOperations<double>.Parse(string value, NumberStyles? style, IFormatProvider provider) => double.Parse(value, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider);

        decimal INumericOperations<decimal>.Parse(string value, NumberStyles? style, IFormatProvider provider) => decimal.Parse(value, style ?? NumberStyles.Number, provider);
        #endregion

        #region TryParse
        public bool TryParse(string value, NumberStyles? style, IFormatProvider provider, out sbyte result) => sbyte.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        public bool TryParse(string value, NumberStyles? style, IFormatProvider provider, out byte result) => byte.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        public bool TryParse(string value, NumberStyles? style, IFormatProvider provider, out short result) => short.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        public bool TryParse(string value, NumberStyles? style, IFormatProvider provider, out ushort result) => ushort.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        public bool TryParse(string value, NumberStyles? style, IFormatProvider provider, out int result) => int.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        public bool TryParse(string value, NumberStyles? style, IFormatProvider provider, out uint result) => uint.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        public bool TryParse(string value, NumberStyles? style, IFormatProvider provider, out long result) => long.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        public bool TryParse(string value, NumberStyles? style, IFormatProvider provider, out ulong result) => ulong.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        public bool TryParse(string value, NumberStyles? style, IFormatProvider provider, out float result) => float.TryParse(value, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider, out result);

        public bool TryParse(string value, NumberStyles? style, IFormatProvider provider, out double result) => double.TryParse(value, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider, out result);

        public bool TryParse(string value, NumberStyles? style, IFormatProvider provider, out decimal result) => decimal.TryParse(value, style ?? NumberStyles.Number, provider, out result);
        #endregion

#if SPAN
        #region Parse
        sbyte INumericOperations<sbyte>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider) => sbyte.Parse(value, style ?? NumberStyles.Integer, provider);

        byte INumericOperations<byte>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider) => byte.Parse(value, style ?? NumberStyles.Integer, provider);

        short INumericOperations<short>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider) => short.Parse(value, style ?? NumberStyles.Integer, provider);

        ushort INumericOperations<ushort>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider) => ushort.Parse(value, style ?? NumberStyles.Integer, provider);

        int INumericOperations<int>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider) => int.Parse(value, style ?? NumberStyles.Integer, provider);

        uint INumericOperations<uint>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider) => uint.Parse(value, style ?? NumberStyles.Integer, provider);

        long INumericOperations<long>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider) => long.Parse(value, style ?? NumberStyles.Integer, provider);

        ulong INumericOperations<ulong>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider) => ulong.Parse(value, style ?? NumberStyles.Integer, provider);

        float INumericOperations<float>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider) => float.Parse(value, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider);

        double INumericOperations<double>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider) => double.Parse(value, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider);

        decimal INumericOperations<decimal>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider) => decimal.Parse(value, style ?? NumberStyles.Number, provider);
        #endregion

        #region TryParse
        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider, out sbyte result) => sbyte.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider, out byte result) => byte.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider, out short result) => short.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider, out ushort result) => ushort.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider, out int result) => int.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider, out uint result) => uint.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider, out long result) => long.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider, out ulong result) => ulong.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider, out float result) => float.TryParse(value, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider, out result);

        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider, out double result) => double.TryParse(value, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider, out result);

        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider, out decimal result) => decimal.TryParse(value, style ?? NumberStyles.Number, provider, out result);
        #endregion

        #region TryFormat
        public bool TryFormat(sbyte value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        public bool TryFormat(byte value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        public bool TryFormat(short value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        public bool TryFormat(ushort value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        public bool TryFormat(int value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        public bool TryFormat(uint value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        public bool TryFormat(long value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        public bool TryFormat(ulong value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        public bool TryFormat(float value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        public bool TryFormat(double value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        public bool TryFormat(decimal value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null) => value.TryFormat(destination, out charsWritten, format, provider);
        #endregion
#endif

        #region Convert
        sbyte INumericOperations<sbyte>.Convert<TFrom>(TFrom value) => Number<TFrom>.GetOperations()?.ToSByte(value) ?? Convert.ToSByte(value);

        byte INumericOperations<byte>.Convert<TFrom>(TFrom value) => Number<TFrom>.GetOperations()?.ToByte(value) ?? Convert.ToByte(value);

        short INumericOperations<short>.Convert<TFrom>(TFrom value) => Number<TFrom>.GetOperations()?.ToInt16(value) ?? Convert.ToInt16(value);

        ushort INumericOperations<ushort>.Convert<TFrom>(TFrom value) => Number<TFrom>.GetOperations()?.ToUInt16(value) ?? Convert.ToUInt16(value);

        int INumericOperations<int>.Convert<TFrom>(TFrom value) => Number<TFrom>.GetOperations()?.ToInt32(value) ?? Convert.ToInt32(value);

        uint INumericOperations<uint>.Convert<TFrom>(TFrom value) => Number<TFrom>.GetOperations()?.ToUInt32(value) ?? Convert.ToUInt32(value);

        long INumericOperations<long>.Convert<TFrom>(TFrom value) => Number<TFrom>.GetOperations()?.ToInt64(value) ?? Convert.ToInt64(value);

        ulong INumericOperations<ulong>.Convert<TFrom>(TFrom value) => Number<TFrom>.GetOperations()?.ToUInt64(value) ?? Convert.ToUInt64(value);

        float INumericOperations<float>.Convert<TFrom>(TFrom value) => Number<TFrom>.GetOperations()?.ToSingle(value) ?? Convert.ToSingle(value);

        double INumericOperations<double>.Convert<TFrom>(TFrom value) => Number<TFrom>.GetOperations()?.ToDouble(value) ?? Convert.ToDouble(value);

        decimal INumericOperations<decimal>.Convert<TFrom>(TFrom value) => Number<TFrom>.GetOperations()?.ToDecimal(value) ?? Convert.ToDecimal(value);
        #endregion

        #region ToSByte
        public sbyte ToSByte(sbyte value) => Convert.ToSByte(value);

        public sbyte ToSByte(byte value) => Convert.ToSByte(value);

        public sbyte ToSByte(short value) => Convert.ToSByte(value);

        public sbyte ToSByte(ushort value) => Convert.ToSByte(value);

        public sbyte ToSByte(int value) => Convert.ToSByte(value);

        public sbyte ToSByte(uint value) => Convert.ToSByte(value);

        public sbyte ToSByte(long value) => Convert.ToSByte(value);

        public sbyte ToSByte(ulong value) => Convert.ToSByte(value);

        public sbyte ToSByte(float value) => Convert.ToSByte(value);

        public sbyte ToSByte(double value) => Convert.ToSByte(value);

        public sbyte ToSByte(decimal value) => Convert.ToSByte(value);
        #endregion

        #region ToByte
        public byte ToByte(sbyte value) => Convert.ToByte(value);

        public byte ToByte(byte value) => Convert.ToByte(value);

        public byte ToByte(short value) => Convert.ToByte(value);

        public byte ToByte(ushort value) => Convert.ToByte(value);

        public byte ToByte(int value) => Convert.ToByte(value);

        public byte ToByte(uint value) => Convert.ToByte(value);

        public byte ToByte(long value) => Convert.ToByte(value);

        public byte ToByte(ulong value) => Convert.ToByte(value);

        public byte ToByte(float value) => Convert.ToByte(value);

        public byte ToByte(double value) => Convert.ToByte(value);

        public byte ToByte(decimal value) => Convert.ToByte(value);
        #endregion

        #region ToInt16
        public short ToInt16(sbyte value) => Convert.ToInt16(value);

        public short ToInt16(byte value) => Convert.ToInt16(value);

        public short ToInt16(short value) => Convert.ToInt16(value);

        public short ToInt16(ushort value) => Convert.ToInt16(value);

        public short ToInt16(int value) => Convert.ToInt16(value);

        public short ToInt16(uint value) => Convert.ToInt16(value);

        public short ToInt16(long value) => Convert.ToInt16(value);

        public short ToInt16(ulong value) => Convert.ToInt16(value);

        public short ToInt16(float value) => Convert.ToInt16(value);

        public short ToInt16(double value) => Convert.ToInt16(value);

        public short ToInt16(decimal value) => Convert.ToInt16(value);
        #endregion

        #region ToUInt16
        public ushort ToUInt16(sbyte value) => Convert.ToUInt16(value);

        public ushort ToUInt16(byte value) => Convert.ToUInt16(value);

        public ushort ToUInt16(short value) => Convert.ToUInt16(value);

        public ushort ToUInt16(ushort value) => Convert.ToUInt16(value);

        public ushort ToUInt16(int value) => Convert.ToUInt16(value);

        public ushort ToUInt16(uint value) => Convert.ToUInt16(value);

        public ushort ToUInt16(long value) => Convert.ToUInt16(value);

        public ushort ToUInt16(ulong value) => Convert.ToUInt16(value);

        public ushort ToUInt16(float value) => Convert.ToUInt16(value);

        public ushort ToUInt16(double value) => Convert.ToUInt16(value);

        public ushort ToUInt16(decimal value) => Convert.ToUInt16(value);
        #endregion

        #region ToInt32
        public int ToInt32(sbyte value) => Convert.ToInt32(value);

        public int ToInt32(byte value) => Convert.ToInt32(value);

        public int ToInt32(short value) => Convert.ToInt32(value);

        public int ToInt32(ushort value) => Convert.ToInt32(value);

        public int ToInt32(int value) => Convert.ToInt32(value);

        public int ToInt32(uint value) => Convert.ToInt32(value);

        public int ToInt32(long value) => Convert.ToInt32(value);

        public int ToInt32(ulong value) => Convert.ToInt32(value);

        public int ToInt32(float value) => Convert.ToInt32(value);

        public int ToInt32(double value) => Convert.ToInt32(value);

        public int ToInt32(decimal value) => Convert.ToInt32(value);
        #endregion

        #region ToUInt32
        public uint ToUInt32(sbyte value) => Convert.ToUInt32(value);

        public uint ToUInt32(byte value) => Convert.ToUInt32(value);

        public uint ToUInt32(short value) => Convert.ToUInt32(value);

        public uint ToUInt32(ushort value) => Convert.ToUInt32(value);

        public uint ToUInt32(int value) => Convert.ToUInt32(value);

        public uint ToUInt32(uint value) => Convert.ToUInt32(value);

        public uint ToUInt32(long value) => Convert.ToUInt32(value);

        public uint ToUInt32(ulong value) => Convert.ToUInt32(value);

        public uint ToUInt32(float value) => Convert.ToUInt32(value);

        public uint ToUInt32(double value) => Convert.ToUInt32(value);

        public uint ToUInt32(decimal value) => Convert.ToUInt32(value);
        #endregion

        #region ToInt64
        public long ToInt64(sbyte value) => Convert.ToInt64(value);

        public long ToInt64(byte value) => Convert.ToInt64(value);

        public long ToInt64(short value) => Convert.ToInt64(value);

        public long ToInt64(ushort value) => Convert.ToInt64(value);

        public long ToInt64(int value) => Convert.ToInt64(value);

        public long ToInt64(uint value) => Convert.ToInt64(value);

        public long ToInt64(long value) => Convert.ToInt64(value);

        public long ToInt64(ulong value) => Convert.ToInt64(value);

        public long ToInt64(float value) => Convert.ToInt64(value);

        public long ToInt64(double value) => Convert.ToInt64(value);

        public long ToInt64(decimal value) => Convert.ToInt64(value);
        #endregion

        #region ToUInt64
        public ulong ToUInt64(sbyte value) => Convert.ToUInt64(value);

        public ulong ToUInt64(byte value) => Convert.ToUInt64(value);

        public ulong ToUInt64(short value) => Convert.ToUInt64(value);

        public ulong ToUInt64(ushort value) => Convert.ToUInt64(value);

        public ulong ToUInt64(int value) => Convert.ToUInt64(value);

        public ulong ToUInt64(uint value) => Convert.ToUInt64(value);

        public ulong ToUInt64(long value) => Convert.ToUInt64(value);

        public ulong ToUInt64(ulong value) => Convert.ToUInt64(value);

        public ulong ToUInt64(float value) => Convert.ToUInt64(value);

        public ulong ToUInt64(double value) => Convert.ToUInt64(value);

        public ulong ToUInt64(decimal value) => Convert.ToUInt64(value);
        #endregion

        #region ToSingle
        public float ToSingle(sbyte value) => Convert.ToSingle(value);

        public float ToSingle(byte value) => Convert.ToSingle(value);

        public float ToSingle(short value) => Convert.ToSingle(value);

        public float ToSingle(ushort value) => Convert.ToSingle(value);

        public float ToSingle(int value) => Convert.ToSingle(value);

        public float ToSingle(uint value) => Convert.ToSingle(value);

        public float ToSingle(long value) => Convert.ToSingle(value);

        public float ToSingle(ulong value) => Convert.ToSingle(value);

        public float ToSingle(float value) => Convert.ToSingle(value);

        public float ToSingle(double value) => Convert.ToSingle(value);

        public float ToSingle(decimal value) => Convert.ToSingle(value);
        #endregion

        #region ToDouble
        public double ToDouble(sbyte value) => Convert.ToDouble(value);

        public double ToDouble(byte value) => Convert.ToDouble(value);

        public double ToDouble(short value) => Convert.ToDouble(value);

        public double ToDouble(ushort value) => Convert.ToDouble(value);

        public double ToDouble(int value) => Convert.ToDouble(value);

        public double ToDouble(uint value) => Convert.ToDouble(value);

        public double ToDouble(long value) => Convert.ToDouble(value);

        public double ToDouble(ulong value) => Convert.ToDouble(value);

        public double ToDouble(float value) => Convert.ToDouble(value);

        public double ToDouble(double value) => Convert.ToDouble(value);

        public double ToDouble(decimal value) => Convert.ToDouble(value);
        #endregion

        #region ToDecimal
        public decimal ToDecimal(sbyte value) => Convert.ToDecimal(value);

        public decimal ToDecimal(byte value) => Convert.ToDecimal(value);

        public decimal ToDecimal(short value) => Convert.ToDecimal(value);

        public decimal ToDecimal(ushort value) => Convert.ToDecimal(value);

        public decimal ToDecimal(int value) => Convert.ToDecimal(value);

        public decimal ToDecimal(uint value) => Convert.ToDecimal(value);

        public decimal ToDecimal(long value) => Convert.ToDecimal(value);

        public decimal ToDecimal(ulong value) => Convert.ToDecimal(value);

        public decimal ToDecimal(float value) => Convert.ToDecimal(value);

        public decimal ToDecimal(double value) => Convert.ToDecimal(value);

        public decimal ToDecimal(decimal value) => Convert.ToDecimal(value);
        #endregion

        #region Round
        public sbyte Round(sbyte value, int digits, MidpointRounding mode) => value;

        public byte Round(byte value, int digits, MidpointRounding mode) => value;

        public short Round(short value, int digits, MidpointRounding mode) => value;

        public ushort Round(ushort value, int digits, MidpointRounding mode) => value;

        public int Round(int value, int digits, MidpointRounding mode) => value;

        public uint Round(uint value, int digits, MidpointRounding mode) => value;

        public long Round(long value, int digits, MidpointRounding mode) => value;

        public ulong Round(ulong value, int digits, MidpointRounding mode) => value;

        public float Round(float value, int digits, MidpointRounding mode)
        {
#if MATHF
            return MathF.Round(value, digits, mode);
#else
            return (float)Math.Round(value, digits, mode);
#endif
        }

        public double Round(double value, int digits, MidpointRounding mode) => Math.Round(value, digits, mode);

        public decimal Round(decimal value, int digits, MidpointRounding mode) => Math.Round(value, digits, mode);
        #endregion

        #region Floor
        public sbyte Floor(sbyte value) => value;

        public byte Floor(byte value) => value;

        public short Floor(short value) => value;

        public ushort Floor(ushort value) => value;

        public int Floor(int value) => value;

        public uint Floor(uint value) => value;

        public long Floor(long value) => value;

        public ulong Floor(ulong value) => value;

        public float Floor(float value)
        {
#if MATHF
            return MathF.Floor(value);
#else
            return (float)Math.Floor(value);
#endif
        }

        public double Floor(double value) => Math.Floor(value);

        public decimal Floor(decimal value) => Math.Floor(value);
        #endregion

        #region Ceiling
        public sbyte Ceiling(sbyte value) => value;

        public byte Ceiling(byte value) => value;

        public short Ceiling(short value) => value;

        public ushort Ceiling(ushort value) => value;

        public int Ceiling(int value) => value;

        public uint Ceiling(uint value) => value;

        public long Ceiling(long value) => value;

        public ulong Ceiling(ulong value) => value;

        public float Ceiling(float value)
        {
#if MATHF
            return MathF.Ceiling(value);
#else
            return (float)Math.Ceiling(value);
#endif
        }

        public double Ceiling(double value) => Math.Ceiling(value);

        public decimal Ceiling(decimal value) => Math.Ceiling(value);
        #endregion

        #region Truncate
        public sbyte Truncate(sbyte value) => value;

        public byte Truncate(byte value) => value;

        public short Truncate(short value) => value;

        public ushort Truncate(ushort value) => value;

        public int Truncate(int value) => value;

        public uint Truncate(uint value) => value;

        public long Truncate(long value) => value;

        public ulong Truncate(ulong value) => value;

        public float Truncate(float value)
        {
#if MATHF
            return MathF.Truncate(value);
#else
            return (float)Math.Truncate(value);
#endif
        }

        public double Truncate(double value) => Math.Truncate(value);

        public decimal Truncate(decimal value) => Math.Truncate(value);
        #endregion

        #region Compare
        public int Compare(sbyte left, sbyte right) => left.CompareTo(right);

        public int Compare(byte left, byte right) => left.CompareTo(right);

        public int Compare(short left, short right) => left.CompareTo(right);

        public int Compare(ushort left, ushort right) => left.CompareTo(right);

        public int Compare(int left, int right) => left.CompareTo(right);

        public int Compare(uint left, uint right) => left.CompareTo(right);

        public int Compare(long left, long right) => left.CompareTo(right);

        public int Compare(ulong left, ulong right) => left.CompareTo(right);

        public int Compare(float left, float right) => left.CompareTo(right);

        public int Compare(double left, double right) => left.CompareTo(right);

        public int Compare(decimal left, decimal right) => left.CompareTo(right);
        #endregion

        #region Abs
        public sbyte Abs(sbyte value) => Math.Abs(value);

        public byte Abs(byte value) => value;

        public short Abs(short value) => Math.Abs(value);

        public ushort Abs(ushort value) => value;

        public int Abs(int value) => Math.Abs(value);

        public uint Abs(uint value) => value;

        public long Abs(long value) => Math.Abs(value);

        public ulong Abs(ulong value) => value;

        public float Abs(float value) => Math.Abs(value);

        public double Abs(double value) => Math.Abs(value);

        public decimal Abs(decimal value) => Math.Abs(value);
        #endregion

        #region Max
        public sbyte Max(sbyte left, sbyte right) => Math.Max(left, right);

        public byte Max(byte left, byte right) => Math.Max(left, right);

        public short Max(short left, short right) => Math.Max(left, right);

        public ushort Max(ushort left, ushort right) => Math.Max(left, right);

        public int Max(int left, int right) => Math.Max(left, right);

        public uint Max(uint left, uint right) => Math.Max(left, right);

        public long Max(long left, long right) => Math.Max(left, right);

        public ulong Max(ulong left, ulong right) => Math.Max(left, right);

        public float Max(float left, float right) => Math.Max(left, right);

        public double Max(double left, double right) => Math.Max(left, right);

        public decimal Max(decimal left, decimal right) => Math.Max(left, right);
        #endregion

        #region Min
        public sbyte Min(sbyte left, sbyte right) => Math.Min(left, right);

        public byte Min(byte left, byte right) => Math.Min(left, right);

        public short Min(short left, short right) => Math.Min(left, right);

        public ushort Min(ushort left, ushort right) => Math.Min(left, right);

        public int Min(int left, int right) => Math.Min(left, right);

        public uint Min(uint left, uint right) => Math.Min(left, right);

        public long Min(long left, long right) => Math.Min(left, right);

        public ulong Min(ulong left, ulong right) => Math.Min(left, right);

        public float Min(float left, float right) => Math.Min(left, right);

        public double Min(double left, double right) => Math.Min(left, right);

        public decimal Min(decimal left, decimal right) => Math.Min(left, right);
        #endregion

        #region Sign
        public int Sign(sbyte value) => Math.Sign(value);

        public int Sign(byte value) => value == 0U ? 0 : 1;

        public int Sign(short value) => Math.Sign(value);

        public int Sign(ushort value) => value == 0U ? 0 : 1;

        public int Sign(int value) => Math.Sign(value);

        public int Sign(uint value) => value == 0U ? 0 : 1;

        public int Sign(long value) => Math.Sign(value);

        public int Sign(ulong value) => value == 0UL ? 0 : 1;

        public int Sign(float value) => Math.Sign(value);

        public int Sign(double value) => Math.Sign(value);

        public int Sign(decimal value) => Math.Sign(value);
        #endregion

        #region ToString
        public string ToString(sbyte value, string format, IFormatProvider provider) => value.ToString(format, provider);

        public string ToString(byte value, string format, IFormatProvider provider) => value.ToString(format, provider);

        public string ToString(short value, string format, IFormatProvider provider) => value.ToString(format, provider);

        public string ToString(ushort value, string format, IFormatProvider provider) => value.ToString(format, provider);

        public string ToString(int value, string format, IFormatProvider provider) => value.ToString(format, provider);

        public string ToString(uint value, string format, IFormatProvider provider) => value.ToString(format, provider);

        public string ToString(long value, string format, IFormatProvider provider) => value.ToString(format, provider);

        public string ToString(ulong value, string format, IFormatProvider provider) => value.ToString(format, provider);

        public string ToString(float value, string format, IFormatProvider provider) => value.ToString(format, provider);

        public string ToString(double value, string format, IFormatProvider provider) => value.ToString(format, provider);

        public string ToString(decimal value, string format, IFormatProvider provider) => value.ToString(format, provider);
        #endregion

        #region IsEven
        public bool IsEven(sbyte value) => (value % 2) == 0;

        public bool IsEven(byte value) => (value % 2) == 0;

        public bool IsEven(short value) => (value % 2) == 0;

        public bool IsEven(ushort value) => (value % 2) == 0;

        public bool IsEven(int value) => (value % 2) == 0;

        public bool IsEven(uint value) => (value % 2U) == 0U;

        public bool IsEven(long value) => (value % 2L) == 0L;

        public bool IsEven(ulong value) => (value % 2UL) == 0UL;

        public bool IsEven(float value) => throw new NotSupportedException("IsEven is not supported for floating point types");

        public bool IsEven(double value) => throw new NotSupportedException("IsEven is not supported for floating point types");

        public bool IsEven(decimal value) => throw new NotSupportedException("IsEven is not supported for floating point types");
        #endregion

        #region IsOdd
        public bool IsOdd(sbyte value) => (value % 2) == 1;

        public bool IsOdd(byte value) => (value % 2) == 1;

        public bool IsOdd(short value) => (value % 2) == 1;

        public bool IsOdd(ushort value) => (value % 2) == 1;

        public bool IsOdd(int value) => (value % 2) == 1;

        public bool IsOdd(uint value) => (value % 2U) == 1U;

        public bool IsOdd(long value) => (value % 2L) == 1L;

        public bool IsOdd(ulong value) => (value % 2UL) == 1UL;

        public bool IsOdd(float value) => throw new NotSupportedException("IsOdd is not supported for floating point types");

        public bool IsOdd(double value) => throw new NotSupportedException("IsOdd is not supported for floating point types");

        public bool IsOdd(decimal value) => throw new NotSupportedException("IsOdd is not supported for floating point types");
        #endregion

        #region IsPowerOfTwo
        public bool IsPowerOfTwo(sbyte value) => (value & (value - 1)) == 0;

        public bool IsPowerOfTwo(byte value) => (value & (value - 1)) == 0;

        public bool IsPowerOfTwo(short value) => (value & (value - 1)) == 0;

        public bool IsPowerOfTwo(ushort value) => (value & (value - 1)) == 0;

        public bool IsPowerOfTwo(int value) => (value & (value - 1)) == 0;

        public bool IsPowerOfTwo(uint value) => (value & (value - 1U)) == 0U;

        public bool IsPowerOfTwo(long value) => (value & (value - 1L)) == 0L;

        public bool IsPowerOfTwo(ulong value) => (value & (value - 1UL)) == 0UL;

        public bool IsPowerOfTwo(float value) => throw new NotSupportedException("IsPowerOfTwo is not supported for floating point types");

        public bool IsPowerOfTwo(double value) => throw new NotSupportedException("IsPowerOfTwo is not supported for floating point types");

        public bool IsPowerOfTwo(decimal value) => throw new NotSupportedException("IsPowerOfTwo is not supported for floating point types");
        #endregion

        #region Clamp
        public sbyte Clamp(sbyte value, sbyte min, sbyte max)
        {
#if CLAMP
            return Math.Clamp(value, min, max);
#else
            if (min > max)
            {
                ThrowMinMaxException(min, max);
            }

            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }

            return value;
#endif
        }

        public byte Clamp(byte value, byte min, byte max)
        {
#if CLAMP
            return Math.Clamp(value, min, max);
#else
            if (min > max)
            {
                ThrowMinMaxException(min, max);
            }

            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }

            return value;
#endif
        }

        public short Clamp(short value, short min, short max)
        {
#if CLAMP
            return Math.Clamp(value, min, max);
#else
            if (min > max)
            {
                ThrowMinMaxException(min, max);
            }

            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }

            return value;
#endif
        }

        public ushort Clamp(ushort value, ushort min, ushort max)
        {
#if CLAMP
            return Math.Clamp(value, min, max);
#else
            if (min > max)
            {
                ThrowMinMaxException(min, max);
            }

            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }

            return value;
#endif
        }

        public int Clamp(int value, int min, int max)
        {
#if CLAMP
            return Math.Clamp(value, min, max);
#else
            if (min > max)
            {
                ThrowMinMaxException(min, max);
            }

            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }

            return value;
#endif
        }

        public uint Clamp(uint value, uint min, uint max)
        {
#if CLAMP
            return Math.Clamp(value, min, max);
#else
            if (min > max)
            {
                ThrowMinMaxException(min, max);
            }

            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }

            return value;
#endif
        }

        public long Clamp(long value, long min, long max)
        {
#if CLAMP
            return Math.Clamp(value, min, max);
#else
            if (min > max)
            {
                ThrowMinMaxException(min, max);
            }

            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }

            return value;
#endif
        }

        public ulong Clamp(ulong value, ulong min, ulong max)
        {
#if CLAMP
            return Math.Clamp(value, min, max);
#else
            if (min > max)
            {
                ThrowMinMaxException(min, max);
            }

            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }

            return value;
#endif
        }

        public float Clamp(float value, float min, float max)
        {
#if CLAMP
            return Math.Clamp(value, min, max);
#else
            if (min > max)
            {
                ThrowMinMaxException(min, max);
            }

            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }

            return value;
#endif
        }

        public double Clamp(double value, double min, double max)
        {
#if CLAMP
            return Math.Clamp(value, min, max);
#else
            if (min > max)
            {
                ThrowMinMaxException(min, max);
            }

            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }

            return value;
#endif
        }

        public decimal Clamp(decimal value, decimal min, decimal max)
        {
#if CLAMP
            return Math.Clamp(value, min, max);
#else
            if (min > max)
            {
                ThrowMinMaxException(min, max);
            }

            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }

            return value;
#endif
        }

        private static void ThrowMinMaxException<T>(T min, T max) => throw new ArgumentException($"'{min}' cannot be greater than '{max}'.");
        #endregion

#if BIG_INTEGER
        #region BigInteger
        BigInteger INumericOperations<BigInteger>.Zero => BigInteger.Zero;

        BigInteger INumericOperations<BigInteger>.One => BigInteger.One;

        BigInteger INumericOperations<BigInteger>.MinusOne => BigInteger.MinusOne;

        BigInteger INumericOperations<BigInteger>.MaxValue => throw new NotSupportedException("there is no MaxValue for BigInteger");

        BigInteger INumericOperations<BigInteger>.MinValue => throw new NotSupportedException("there is no MinValue for BigInteger");

#if ICONVERTIBLE
        TypeCode INumericOperations<BigInteger>.TypeCode => TypeCode.Object;
#endif

        public bool Equals(BigInteger left, BigInteger right) => left == right;

        public bool NotEquals(BigInteger left, BigInteger right) => left != right;

        public bool LessThan(BigInteger left, BigInteger right) => left < right;

        public bool LessThanOrEquals(BigInteger left, BigInteger right) => left <= right;

        public bool GreaterThan(BigInteger left, BigInteger right) => left > right;

        public bool GreaterThanOrEquals(BigInteger left, BigInteger right) => left >= right;

        public BigInteger Add(BigInteger left, BigInteger right) => left + right;

        public BigInteger Subtract(BigInteger left, BigInteger right) => left - right;

        public BigInteger Multiply(BigInteger left, BigInteger right) => left * right;

        public BigInteger Divide(BigInteger dividend, BigInteger divisor) => dividend / divisor;

        public BigInteger Remainder(BigInteger dividend, BigInteger divisor) => dividend % divisor;

        public BigInteger DivRem(BigInteger dividend, BigInteger divisor, out BigInteger remainder) => BigInteger.DivRem(dividend, divisor, out remainder);

        public BigInteger Negate(BigInteger value) => -value;

        public BigInteger And(BigInteger left, BigInteger right) => left & right;

        public BigInteger Or(BigInteger left, BigInteger right) => left | right;

        public BigInteger Xor(BigInteger left, BigInteger right) => left ^ right;

        public BigInteger Not(BigInteger value) => ~value;

        public BigInteger LeftShift(BigInteger value, int shift) => value << shift;

        public BigInteger RightShift(BigInteger value, int shift) => value >> shift;

        BigInteger INumericOperations<BigInteger>.Parse(string value, NumberStyles? style, IFormatProvider provider) => BigInteger.Parse(value, style ?? NumberStyles.Integer, provider);

        public bool TryParse(string value, NumberStyles? style, IFormatProvider provider, out BigInteger result) => BigInteger.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

#if SPAN
        BigInteger INumericOperations<BigInteger>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider) => BigInteger.Parse(value, style ?? NumberStyles.Integer, provider);

        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider provider, out BigInteger result) => BigInteger.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        public bool TryFormat(BigInteger value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null) => value.TryFormat(destination, out charsWritten, format, provider);
#endif

        BigInteger INumericOperations<BigInteger>.Convert<TFrom>(TFrom value) => Number<TFrom>.GetOperations().ToBigInteger(value);

        public BigInteger Round(BigInteger value, int digits, MidpointRounding mode) => value;

        public BigInteger Floor(BigInteger value) => value;

        public BigInteger Ceiling(BigInteger value) => value;

        public BigInteger Truncate(BigInteger value) => value;

        public int Compare(BigInteger left, BigInteger right) => left.CompareTo(right);

        public BigInteger Abs(BigInteger value) => BigInteger.Abs(value);

        public BigInteger Max(BigInteger left, BigInteger right) => BigInteger.Max(left, right);

        public BigInteger Min(BigInteger left, BigInteger right) => BigInteger.Min(left, right);

        public int Sign(BigInteger value) => value.Sign;

        public string ToString(BigInteger value, string format, IFormatProvider provider) => value.ToString(format, provider);

        public sbyte ToSByte(BigInteger value) => (sbyte)value;

        public byte ToByte(BigInteger value) => (byte)value;

        public short ToInt16(BigInteger value) => (short)value;

        public ushort ToUInt16(BigInteger value) => (ushort)value;

        public int ToInt32(BigInteger value) => (int)value;

        public uint ToUInt32(BigInteger value) => (uint)value;

        public long ToInt64(BigInteger value) => (long)value;

        public ulong ToUInt64(BigInteger value) => (ulong)value;

        public float ToSingle(BigInteger value) => (float)value;

        public double ToDouble(BigInteger value) => (double)value;

        public decimal ToDecimal(BigInteger value) => (decimal)value;

        public BigInteger ToBigInteger(sbyte value) => value;

        public BigInteger ToBigInteger(byte value) => value;

        public BigInteger ToBigInteger(short value) => value;

        public BigInteger ToBigInteger(ushort value) => value;

        public BigInteger ToBigInteger(int value) => value;

        public BigInteger ToBigInteger(uint value) => value;

        public BigInteger ToBigInteger(long value) => value;

        public BigInteger ToBigInteger(ulong value) => value;

        public BigInteger ToBigInteger(float value) => (BigInteger)value;

        public BigInteger ToBigInteger(double value) => (BigInteger)value;

        public BigInteger ToBigInteger(decimal value) => (BigInteger)value;

        public BigInteger ToBigInteger(BigInteger value) => value;

        public bool IsEven(BigInteger value) => value.IsEven;

        public bool IsOdd(BigInteger value) => !value.IsEven;

        public bool IsPowerOfTwo(BigInteger value) => value.IsPowerOfTwo;

        public BigInteger Clamp(BigInteger value, BigInteger min, BigInteger max)
        {
            if (min > max)
            {
                ThrowMinMaxException(min, max);
            }

            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }

            return value;
        }
        #endregion
#endif
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}