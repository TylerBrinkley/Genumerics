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
    /// <summary>
    /// Defines all the default numeric operations.
    /// </summary>
    [CLSCompliant(false)]
    public struct DefaultNumericOperations : INumericOperations<sbyte>, INumericOperations<byte>, INumericOperations<short>, INumericOperations<ushort>, INumericOperations<int>, INumericOperations<uint>, INumericOperations<long>, INumericOperations<ulong>, INumericOperations<float>, INumericOperations<double>, INumericOperations<decimal>, INumericOperations<BigInteger>
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

        BigInteger INumericOperations<BigInteger>.Zero => BigInteger.Zero;
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

        BigInteger INumericOperations<BigInteger>.One => BigInteger.One;
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

        BigInteger INumericOperations<BigInteger>.MinusOne => BigInteger.MinusOne;
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

        BigInteger INumericOperations<BigInteger>.MaxValue => throw new NotSupportedException("there is no MaxValue for BigInteger");
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

        BigInteger INumericOperations<BigInteger>.MinValue => throw new NotSupportedException("there is no MinValue for BigInteger");
        #endregion

        #region TypeCode
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

        TypeCode INumericOperations<BigInteger>.TypeCode => TypeCode.Object;
        #endregion

        #region Equals
        /// <inheritdoc />
        public bool Equals(sbyte left, sbyte right) => left == right;

        /// <inheritdoc />
        public bool Equals(byte left, byte right) => left == right;

        /// <inheritdoc />
        public bool Equals(short left, short right) => left == right;

        /// <inheritdoc />
        public bool Equals(ushort left, ushort right) => left == right;

        /// <inheritdoc />
        public bool Equals(int left, int right) => left == right;

        /// <inheritdoc />
        public bool Equals(uint left, uint right) => left == right;

        /// <inheritdoc />
        public bool Equals(long left, long right) => left == right;

        /// <inheritdoc />
        public bool Equals(ulong left, ulong right) => left == right;

        /// <inheritdoc />
        public bool Equals(float left, float right) => left == right;

        /// <inheritdoc />
        public bool Equals(double left, double right) => left == right;

        /// <inheritdoc />
        public bool Equals(decimal left, decimal right) => left == right;

        /// <inheritdoc />
        public bool Equals(BigInteger left, BigInteger right) => left == right;
        #endregion

        #region NotEquals
        /// <inheritdoc />
        public bool NotEquals(sbyte left, sbyte right) => left != right;

        /// <inheritdoc />
        public bool NotEquals(byte left, byte right) => left != right;

        /// <inheritdoc />
        public bool NotEquals(short left, short right) => left != right;

        /// <inheritdoc />
        public bool NotEquals(ushort left, ushort right) => left != right;

        /// <inheritdoc />
        public bool NotEquals(int left, int right) => left != right;

        /// <inheritdoc />
        public bool NotEquals(uint left, uint right) => left != right;

        /// <inheritdoc />
        public bool NotEquals(long left, long right) => left != right;

        /// <inheritdoc />
        public bool NotEquals(ulong left, ulong right) => left != right;

        /// <inheritdoc />
        public bool NotEquals(float left, float right) => left != right;

        /// <inheritdoc />
        public bool NotEquals(double left, double right) => left != right;

        /// <inheritdoc />
        public bool NotEquals(decimal left, decimal right) => left != right;

        /// <inheritdoc />
        public bool NotEquals(BigInteger left, BigInteger right) => left != right;
        #endregion

        #region LessThan
        /// <inheritdoc />
        public bool LessThan(sbyte left, sbyte right) => left < right;

        /// <inheritdoc />
        public bool LessThan(byte left, byte right) => left < right;

        /// <inheritdoc />
        public bool LessThan(short left, short right) => left < right;

        /// <inheritdoc />
        public bool LessThan(ushort left, ushort right) => left < right;

        /// <inheritdoc />
        public bool LessThan(int left, int right) => left < right;

        /// <inheritdoc />
        public bool LessThan(uint left, uint right) => left < right;

        /// <inheritdoc />
        public bool LessThan(long left, long right) => left < right;

        /// <inheritdoc />
        public bool LessThan(ulong left, ulong right) => left < right;

        /// <inheritdoc />
        public bool LessThan(float left, float right) => left < right;

        /// <inheritdoc />
        public bool LessThan(double left, double right) => left < right;

        /// <inheritdoc />
        public bool LessThan(decimal left, decimal right) => left < right;

        /// <inheritdoc />
        public bool LessThan(BigInteger left, BigInteger right) => left < right;
        #endregion

        #region LessThanOrEqual
        /// <inheritdoc />
        public bool LessThanOrEqual(sbyte left, sbyte right) => left <= right;

        /// <inheritdoc />
        public bool LessThanOrEqual(byte left, byte right) => left <= right;

        /// <inheritdoc />
        public bool LessThanOrEqual(short left, short right) => left <= right;

        /// <inheritdoc />
        public bool LessThanOrEqual(ushort left, ushort right) => left <= right;

        /// <inheritdoc />
        public bool LessThanOrEqual(int left, int right) => left <= right;

        /// <inheritdoc />
        public bool LessThanOrEqual(uint left, uint right) => left <= right;

        /// <inheritdoc />
        public bool LessThanOrEqual(long left, long right) => left <= right;

        /// <inheritdoc />
        public bool LessThanOrEqual(ulong left, ulong right) => left <= right;

        /// <inheritdoc />
        public bool LessThanOrEqual(float left, float right) => left <= right;

        /// <inheritdoc />
        public bool LessThanOrEqual(double left, double right) => left <= right;

        /// <inheritdoc />
        public bool LessThanOrEqual(decimal left, decimal right) => left <= right;

        /// <inheritdoc />
        public bool LessThanOrEqual(BigInteger left, BigInteger right) => left <= right;
        #endregion

        #region GreaterThan
        /// <inheritdoc />
        public bool GreaterThan(sbyte left, sbyte right) => left > right;

        /// <inheritdoc />
        public bool GreaterThan(byte left, byte right) => left > right;

        /// <inheritdoc />
        public bool GreaterThan(short left, short right) => left > right;

        /// <inheritdoc />
        public bool GreaterThan(ushort left, ushort right) => left > right;

        /// <inheritdoc />
        public bool GreaterThan(int left, int right) => left > right;

        /// <inheritdoc />
        public bool GreaterThan(uint left, uint right) => left > right;

        /// <inheritdoc />
        public bool GreaterThan(long left, long right) => left > right;

        /// <inheritdoc />
        public bool GreaterThan(ulong left, ulong right) => left > right;

        /// <inheritdoc />
        public bool GreaterThan(float left, float right) => left > right;

        /// <inheritdoc />
        public bool GreaterThan(double left, double right) => left > right;

        /// <inheritdoc />
        public bool GreaterThan(decimal left, decimal right) => left > right;

        /// <inheritdoc />
        public bool GreaterThan(BigInteger left, BigInteger right) => left > right;
        #endregion

        #region GreaterThanOrEqual
        /// <inheritdoc />
        public bool GreaterThanOrEqual(sbyte left, sbyte right) => left >= right;

        /// <inheritdoc />
        public bool GreaterThanOrEqual(byte left, byte right) => left >= right;

        /// <inheritdoc />
        public bool GreaterThanOrEqual(short left, short right) => left >= right;

        /// <inheritdoc />
        public bool GreaterThanOrEqual(ushort left, ushort right) => left >= right;

        /// <inheritdoc />
        public bool GreaterThanOrEqual(int left, int right) => left >= right;

        /// <inheritdoc />
        public bool GreaterThanOrEqual(uint left, uint right) => left >= right;

        /// <inheritdoc />
        public bool GreaterThanOrEqual(long left, long right) => left >= right;

        /// <inheritdoc />
        public bool GreaterThanOrEqual(ulong left, ulong right) => left >= right;

        /// <inheritdoc />
        public bool GreaterThanOrEqual(float left, float right) => left >= right;

        /// <inheritdoc />
        public bool GreaterThanOrEqual(double left, double right) => left >= right;

        /// <inheritdoc />
        public bool GreaterThanOrEqual(decimal left, decimal right) => left >= right;

        /// <inheritdoc />
        public bool GreaterThanOrEqual(BigInteger left, BigInteger right) => left >= right;
        #endregion

        #region Add
        /// <inheritdoc />
        public sbyte Add(sbyte left, sbyte right) => (sbyte)(left + right);

        /// <inheritdoc />
        public byte Add(byte left, byte right) => (byte)(left + right);

        /// <inheritdoc />
        public short Add(short left, short right) => (short)(left + right);

        /// <inheritdoc />
        public ushort Add(ushort left, ushort right) => (ushort)(left + right);

        /// <inheritdoc />
        public int Add(int left, int right) => left + right;

        /// <inheritdoc />
        public uint Add(uint left, uint right) => left + right;

        /// <inheritdoc />
        public long Add(long left, long right) => left + right;

        /// <inheritdoc />
        public ulong Add(ulong left, ulong right) => left + right;

        /// <inheritdoc />
        public float Add(float left, float right) => left + right;

        /// <inheritdoc />
        public double Add(double left, double right) => left + right;

        /// <inheritdoc />
        public decimal Add(decimal left, decimal right) => left + right;

        /// <inheritdoc />
        public BigInteger Add(BigInteger left, BigInteger right) => left + right;
        #endregion

        #region Subtract
        /// <inheritdoc />
        public sbyte Subtract(sbyte left, sbyte right) => (sbyte)(left - right);

        /// <inheritdoc />
        public byte Subtract(byte left, byte right) => (byte)(left - right);

        /// <inheritdoc />
        public short Subtract(short left, short right) => (short)(left - right);

        /// <inheritdoc />
        public ushort Subtract(ushort left, ushort right) => (ushort)(left - right);

        /// <inheritdoc />
        public int Subtract(int left, int right) => left - right;

        /// <inheritdoc />
        public uint Subtract(uint left, uint right) => left - right;

        /// <inheritdoc />
        public long Subtract(long left, long right) => left - right;

        /// <inheritdoc />
        public ulong Subtract(ulong left, ulong right) => left - right;

        /// <inheritdoc />
        public float Subtract(float left, float right) => left - right;

        /// <inheritdoc />
        public double Subtract(double left, double right) => left - right;

        /// <inheritdoc />
        public decimal Subtract(decimal left, decimal right) => left - right;

        /// <inheritdoc />
        public BigInteger Subtract(BigInteger left, BigInteger right) => left - right;
        #endregion

        #region Multiply
        /// <inheritdoc />
        public sbyte Multiply(sbyte left, sbyte right) => (sbyte)(left * right);

        /// <inheritdoc />
        public byte Multiply(byte left, byte right) => (byte)(left * right);

        /// <inheritdoc />
        public short Multiply(short left, short right) => (short)(left * right);

        /// <inheritdoc />
        public ushort Multiply(ushort left, ushort right) => (ushort)(left * right);

        /// <inheritdoc />
        public int Multiply(int left, int right) => left * right;

        /// <inheritdoc />
        public uint Multiply(uint left, uint right) => left * right;

        /// <inheritdoc />
        public long Multiply(long left, long right) => left * right;

        /// <inheritdoc />
        public ulong Multiply(ulong left, ulong right) => left * right;

        /// <inheritdoc />
        public float Multiply(float left, float right) => left * right;

        /// <inheritdoc />
        public double Multiply(double left, double right) => left * right;

        /// <inheritdoc />
        public decimal Multiply(decimal left, decimal right) => left * right;

        /// <inheritdoc />
        public BigInteger Multiply(BigInteger left, BigInteger right) => left * right;
        #endregion

        #region Divide
        /// <inheritdoc />
        public sbyte Divide(sbyte dividend, sbyte divisor) => (sbyte)(dividend / divisor);

        /// <inheritdoc />
        public byte Divide(byte dividend, byte divisor) => (byte)(dividend / divisor);

        /// <inheritdoc />
        public short Divide(short dividend, short divisor) => (short)(dividend / divisor);

        /// <inheritdoc />
        public ushort Divide(ushort dividend, ushort divisor) => (ushort)(dividend / divisor);

        /// <inheritdoc />
        public int Divide(int dividend, int divisor) => dividend / divisor;

        /// <inheritdoc />
        public uint Divide(uint dividend, uint divisor) => dividend / divisor;

        /// <inheritdoc />
        public long Divide(long dividend, long divisor) => dividend / divisor;

        /// <inheritdoc />
        public ulong Divide(ulong dividend, ulong divisor) => dividend / divisor;

        /// <inheritdoc />
        public float Divide(float dividend, float divisor) => dividend / divisor;

        /// <inheritdoc />
        public double Divide(double dividend, double divisor) => dividend / divisor;

        /// <inheritdoc />
        public decimal Divide(decimal dividend, decimal divisor) => dividend / divisor;

        /// <inheritdoc />
        public BigInteger Divide(BigInteger dividend, BigInteger divisor) => dividend / divisor;
        #endregion

        #region Remainder
        /// <inheritdoc />
        public sbyte Remainder(sbyte dividend, sbyte divisor) => (sbyte)(dividend % divisor);

        /// <inheritdoc />
        public byte Remainder(byte dividend, byte divisor) => (byte)(dividend % divisor);

        /// <inheritdoc />
        public short Remainder(short dividend, short divisor) => (short)(dividend % divisor);

        /// <inheritdoc />
        public ushort Remainder(ushort dividend, ushort divisor) => (ushort)(dividend % divisor);

        /// <inheritdoc />
        public int Remainder(int dividend, int divisor) => dividend % divisor;

        /// <inheritdoc />
        public uint Remainder(uint dividend, uint divisor) => dividend % divisor;

        /// <inheritdoc />
        public long Remainder(long dividend, long divisor) => dividend % divisor;

        /// <inheritdoc />
        public ulong Remainder(ulong dividend, ulong divisor) => dividend % divisor;

        /// <inheritdoc />
        public float Remainder(float dividend, float divisor) => dividend % divisor;

        /// <inheritdoc />
        public double Remainder(double dividend, double divisor) => dividend % divisor;

        /// <inheritdoc />
        public decimal Remainder(decimal dividend, decimal divisor) => dividend % divisor;

        /// <inheritdoc />
        public BigInteger Remainder(BigInteger dividend, BigInteger divisor) => dividend % divisor;
        #endregion

        #region DivRem
        /// <inheritdoc />
        public sbyte DivRem(sbyte dividend, sbyte divisor, out sbyte remainder)
        {
            remainder = (sbyte)(dividend % divisor);
            return (sbyte)(dividend / divisor);
        }

        /// <inheritdoc />
        public byte DivRem(byte dividend, byte divisor, out byte remainder)
        {
            remainder = (byte)(dividend % divisor);
            return (byte)(dividend / divisor);
        }

        /// <inheritdoc />
        public short DivRem(short dividend, short divisor, out short remainder)
        {
            remainder = (short)(dividend % divisor);
            return (short)(dividend / divisor);
        }

        /// <inheritdoc />
        public ushort DivRem(ushort dividend, ushort divisor, out ushort remainder)
        {
            remainder = (ushort)(dividend % divisor);
            return (ushort)(dividend / divisor);
        }

        /// <inheritdoc />
        public int DivRem(int dividend, int divisor, out int remainder) => Math.DivRem(dividend, divisor, out remainder);

        /// <inheritdoc />
        public uint DivRem(uint dividend, uint divisor, out uint remainder)
        {
            remainder = dividend % divisor;
            return dividend / divisor;
        }

        /// <inheritdoc />
        public long DivRem(long dividend, long divisor, out long remainder) => Math.DivRem(dividend, divisor, out remainder);

        /// <inheritdoc />
        public ulong DivRem(ulong dividend, ulong divisor, out ulong remainder)
        {
            remainder = dividend % divisor;
            return dividend / divisor;
        }

        /// <inheritdoc />
        public float DivRem(float dividend, float divisor, out float remainder)
        {
            remainder = dividend % divisor;
            return dividend / divisor;
        }

        /// <inheritdoc />
        public double DivRem(double dividend, double divisor, out double remainder)
        {
            remainder = dividend % divisor;
            return dividend / divisor;
        }

        /// <inheritdoc />
        public decimal DivRem(decimal dividend, decimal divisor, out decimal remainder)
        {
            remainder = dividend % divisor;
            return dividend / divisor;
        }

        /// <inheritdoc />
        public BigInteger DivRem(BigInteger dividend, BigInteger divisor, out BigInteger remainder) => BigInteger.DivRem(dividend, divisor, out remainder);
        #endregion

        #region Negate
        /// <inheritdoc />
        public sbyte Negate(sbyte value) => (sbyte)-value;

        /// <inheritdoc />
        public byte Negate(byte value) => throw new NotSupportedException("cannot negate unsigned integral type");

        /// <inheritdoc />
        public short Negate(short value) => (short)-value;

        /// <inheritdoc />
        public ushort Negate(ushort value) => throw new NotSupportedException("cannot negate unsigned integral type");

        /// <inheritdoc />
        public int Negate(int value) => -value;

        /// <inheritdoc />
        public uint Negate(uint value) => throw new NotSupportedException("cannot negate unsigned integral type");

        /// <inheritdoc />
        public long Negate(long value) => -value;

        /// <inheritdoc />
        public ulong Negate(ulong value) => throw new NotSupportedException("cannot negate unsigned integral type");

        /// <inheritdoc />
        public float Negate(float value) => -value;

        /// <inheritdoc />
        public double Negate(double value) => -value;

        /// <inheritdoc />
        public decimal Negate(decimal value) => -value;

        /// <inheritdoc />
        public BigInteger Negate(BigInteger value) => -value;
        #endregion

        #region BitwiseAnd
        /// <inheritdoc />
        public sbyte BitwiseAnd(sbyte left, sbyte right) => (sbyte)(left & right);

        /// <inheritdoc />
        public byte BitwiseAnd(byte left, byte right) => (byte)(left & right);

        /// <inheritdoc />
        public short BitwiseAnd(short left, short right) => (short)(left & right);

        /// <inheritdoc />
        public ushort BitwiseAnd(ushort left, ushort right) => (ushort)(left & right);

        /// <inheritdoc />
        public int BitwiseAnd(int left, int right) => left & right;

        /// <inheritdoc />
        public uint BitwiseAnd(uint left, uint right) => left & right;

        /// <inheritdoc />
        public long BitwiseAnd(long left, long right) => left & right;

        /// <inheritdoc />
        public ulong BitwiseAnd(ulong left, ulong right) => left & right;

        /// <inheritdoc />
        public float BitwiseAnd(float left, float right) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        /// <inheritdoc />
        public double BitwiseAnd(double left, double right) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        /// <inheritdoc />
        public decimal BitwiseAnd(decimal left, decimal right) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        /// <inheritdoc />
        public BigInteger BitwiseAnd(BigInteger left, BigInteger right) => left & right;
        #endregion

        #region BitwiseOr
        /// <inheritdoc />
        public sbyte BitwiseOr(sbyte left, sbyte right) => (sbyte)(left | right);

        /// <inheritdoc />
        public byte BitwiseOr(byte left, byte right) => (byte)(left | right);

        /// <inheritdoc />
        public short BitwiseOr(short left, short right) => (short)(left | right);

        /// <inheritdoc />
        public ushort BitwiseOr(ushort left, ushort right) => (ushort)(left | right);

        /// <inheritdoc />
        public int BitwiseOr(int left, int right) => left | right;

        /// <inheritdoc />
        public uint BitwiseOr(uint left, uint right) => left | right;

        /// <inheritdoc />
        public long BitwiseOr(long left, long right) => left | right;

        /// <inheritdoc />
        public ulong BitwiseOr(ulong left, ulong right) => left | right;

        /// <inheritdoc />
        public float BitwiseOr(float left, float right) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        /// <inheritdoc />
        public double BitwiseOr(double left, double right) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        /// <inheritdoc />
        public decimal BitwiseOr(decimal left, decimal right) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        /// <inheritdoc />
        public BigInteger BitwiseOr(BigInteger left, BigInteger right) => left | right;
        #endregion

        #region Xor
        /// <inheritdoc />
        public sbyte Xor(sbyte left, sbyte right) => (sbyte)(left ^ right);

        /// <inheritdoc />
        public byte Xor(byte left, byte right) => (byte)(left ^ right);

        /// <inheritdoc />
        public short Xor(short left, short right) => (short)(left ^ right);

        /// <inheritdoc />
        public ushort Xor(ushort left, ushort right) => (ushort)(left ^ right);

        /// <inheritdoc />
        public int Xor(int left, int right) => left ^ right;

        /// <inheritdoc />
        public uint Xor(uint left, uint right) => left ^ right;

        /// <inheritdoc />
        public long Xor(long left, long right) => left ^ right;

        /// <inheritdoc />
        public ulong Xor(ulong left, ulong right) => left ^ right;

        /// <inheritdoc />
        public float Xor(float left, float right) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        /// <inheritdoc />
        public double Xor(double left, double right) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        /// <inheritdoc />
        public decimal Xor(decimal left, decimal right) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        /// <inheritdoc />
        public BigInteger Xor(BigInteger left, BigInteger right) => left ^ right;
        #endregion

        #region OnesComplement
        /// <inheritdoc />
        public sbyte OnesComplement(sbyte value) => (sbyte)~value;

        /// <inheritdoc />
        public byte OnesComplement(byte value) => (byte)~value;

        /// <inheritdoc />
        public short OnesComplement(short value) => (short)~value;

        /// <inheritdoc />
        public ushort OnesComplement(ushort value) => (ushort)~value;

        /// <inheritdoc />
        public int OnesComplement(int value) => ~value;

        /// <inheritdoc />
        public uint OnesComplement(uint value) => ~value;

        /// <inheritdoc />
        public long OnesComplement(long value) => ~value;

        /// <inheritdoc />
        public ulong OnesComplement(ulong value) => ~value;

        /// <inheritdoc />
        public float OnesComplement(float value) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        /// <inheritdoc />
        public double OnesComplement(double value) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        /// <inheritdoc />
        public decimal OnesComplement(decimal value) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        /// <inheritdoc />
        public BigInteger OnesComplement(BigInteger value) => ~value;
        #endregion

        #region LeftShift
        /// <inheritdoc />
        public sbyte LeftShift(sbyte value, int shift) => (sbyte)(value << shift);

        /// <inheritdoc />
        public byte LeftShift(byte value, int shift) => (byte)(value << shift);

        /// <inheritdoc />
        public short LeftShift(short value, int shift) => (short)(value << shift);

        /// <inheritdoc />
        public ushort LeftShift(ushort value, int shift) => (ushort)(value << shift);

        /// <inheritdoc />
        public int LeftShift(int value, int shift) => value << shift;

        /// <inheritdoc />
        public uint LeftShift(uint value, int shift) => value << shift;

        /// <inheritdoc />
        public long LeftShift(long value, int shift) => value << shift;

        /// <inheritdoc />
        public ulong LeftShift(ulong value, int shift) => value << shift;

        /// <inheritdoc />
        public float LeftShift(float value, int shift) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        /// <inheritdoc />
        public double LeftShift(double value, int shift) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        /// <inheritdoc />
        public decimal LeftShift(decimal value, int shift) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        /// <inheritdoc />
        public BigInteger LeftShift(BigInteger value, int shift) => value << shift;
        #endregion

        #region RightShift
        /// <inheritdoc />
        public sbyte RightShift(sbyte value, int shift) => (sbyte)(value >> shift);

        /// <inheritdoc />
        public byte RightShift(byte value, int shift) => (byte)(value >> shift);

        /// <inheritdoc />
        public short RightShift(short value, int shift) => (short)(value >> shift);

        /// <inheritdoc />
        public ushort RightShift(ushort value, int shift) => (ushort)(value >> shift);

        /// <inheritdoc />
        public int RightShift(int value, int shift) => value >> shift;

        /// <inheritdoc />
        public uint RightShift(uint value, int shift) => value >> shift;

        /// <inheritdoc />
        public long RightShift(long value, int shift) => value >> shift;

        /// <inheritdoc />
        public ulong RightShift(ulong value, int shift) => value >> shift;

        /// <inheritdoc />
        public float RightShift(float value, int shift) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        /// <inheritdoc />
        public double RightShift(double value, int shift) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        /// <inheritdoc />
        public decimal RightShift(decimal value, int shift) => throw new NotSupportedException("bitwise operations are not supported for floating point types");

        /// <inheritdoc />
        public BigInteger RightShift(BigInteger value, int shift) => value >> shift;
        #endregion

        #region Parse
        sbyte INumericOperations<sbyte>.Parse(string value, NumberStyles? style, IFormatProvider? provider) => sbyte.Parse(value, style ?? NumberStyles.Integer, provider);

        byte INumericOperations<byte>.Parse(string value, NumberStyles? style, IFormatProvider? provider) => byte.Parse(value, style ?? NumberStyles.Integer, provider);

        short INumericOperations<short>.Parse(string value, NumberStyles? style, IFormatProvider? provider) => short.Parse(value, style ?? NumberStyles.Integer, provider);

        ushort INumericOperations<ushort>.Parse(string value, NumberStyles? style, IFormatProvider? provider) => ushort.Parse(value, style ?? NumberStyles.Integer, provider);

        int INumericOperations<int>.Parse(string value, NumberStyles? style, IFormatProvider? provider) => int.Parse(value, style ?? NumberStyles.Integer, provider);

        uint INumericOperations<uint>.Parse(string value, NumberStyles? style, IFormatProvider? provider) => uint.Parse(value, style ?? NumberStyles.Integer, provider);

        long INumericOperations<long>.Parse(string value, NumberStyles? style, IFormatProvider? provider) => long.Parse(value, style ?? NumberStyles.Integer, provider);

        ulong INumericOperations<ulong>.Parse(string value, NumberStyles? style, IFormatProvider? provider) => ulong.Parse(value, style ?? NumberStyles.Integer, provider);

        float INumericOperations<float>.Parse(string value, NumberStyles? style, IFormatProvider? provider) => float.Parse(value, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider);

        double INumericOperations<double>.Parse(string value, NumberStyles? style, IFormatProvider? provider) => double.Parse(value, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider);

        decimal INumericOperations<decimal>.Parse(string value, NumberStyles? style, IFormatProvider? provider) => decimal.Parse(value, style ?? NumberStyles.Number, provider);

        BigInteger INumericOperations<BigInteger>.Parse(string value, NumberStyles? style, IFormatProvider? provider) => BigInteger.Parse(value, style ?? NumberStyles.Integer, provider);
        #endregion

        #region TryParse
        /// <inheritdoc />
        public bool TryParse(string value, NumberStyles? style, IFormatProvider? provider, out sbyte result) => sbyte.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        /// <inheritdoc />
        public bool TryParse(string value, NumberStyles? style, IFormatProvider? provider, out byte result) => byte.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        /// <inheritdoc />
        public bool TryParse(string value, NumberStyles? style, IFormatProvider? provider, out short result) => short.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        /// <inheritdoc />
        public bool TryParse(string value, NumberStyles? style, IFormatProvider? provider, out ushort result) => ushort.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        /// <inheritdoc />
        public bool TryParse(string value, NumberStyles? style, IFormatProvider? provider, out int result) => int.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        /// <inheritdoc />
        public bool TryParse(string value, NumberStyles? style, IFormatProvider? provider, out uint result) => uint.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        /// <inheritdoc />
        public bool TryParse(string value, NumberStyles? style, IFormatProvider? provider, out long result) => long.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        /// <inheritdoc />
        public bool TryParse(string value, NumberStyles? style, IFormatProvider? provider, out ulong result) => ulong.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        /// <inheritdoc />
        public bool TryParse(string value, NumberStyles? style, IFormatProvider? provider, out float result) => float.TryParse(value, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider, out result);

        /// <inheritdoc />
        public bool TryParse(string value, NumberStyles? style, IFormatProvider? provider, out double result) => double.TryParse(value, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider, out result);

        /// <inheritdoc />
        public bool TryParse(string value, NumberStyles? style, IFormatProvider? provider, out decimal result) => decimal.TryParse(value, style ?? NumberStyles.Number, provider, out result);

        /// <inheritdoc />
        public bool TryParse(string value, NumberStyles? style, IFormatProvider? provider, out BigInteger result) => BigInteger.TryParse(value, style ?? NumberStyles.Integer, provider, out result);
        #endregion

#if SPAN
        #region Parse
        sbyte INumericOperations<sbyte>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider) => sbyte.Parse(value, style ?? NumberStyles.Integer, provider);

        byte INumericOperations<byte>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider) => byte.Parse(value, style ?? NumberStyles.Integer, provider);

        short INumericOperations<short>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider) => short.Parse(value, style ?? NumberStyles.Integer, provider);

        ushort INumericOperations<ushort>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider) => ushort.Parse(value, style ?? NumberStyles.Integer, provider);

        int INumericOperations<int>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider) => int.Parse(value, style ?? NumberStyles.Integer, provider);

        uint INumericOperations<uint>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider) => uint.Parse(value, style ?? NumberStyles.Integer, provider);

        long INumericOperations<long>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider) => long.Parse(value, style ?? NumberStyles.Integer, provider);

        ulong INumericOperations<ulong>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider) => ulong.Parse(value, style ?? NumberStyles.Integer, provider);

        float INumericOperations<float>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider) => float.Parse(value, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider);

        double INumericOperations<double>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider) => double.Parse(value, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider);

        decimal INumericOperations<decimal>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider) => decimal.Parse(value, style ?? NumberStyles.Number, provider);

        BigInteger INumericOperations<BigInteger>.Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider) => BigInteger.Parse(value, style ?? NumberStyles.Integer, provider);
        #endregion

        #region TryParse
        /// <inheritdoc />
        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider, out sbyte result) => sbyte.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        /// <inheritdoc />
        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider, out byte result) => byte.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        /// <inheritdoc />
        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider, out short result) => short.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        /// <inheritdoc />
        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider, out ushort result) => ushort.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        /// <inheritdoc />
        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider, out int result) => int.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        /// <inheritdoc />
        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider, out uint result) => uint.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        /// <inheritdoc />
        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider, out long result) => long.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        /// <inheritdoc />
        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider, out ulong result) => ulong.TryParse(value, style ?? NumberStyles.Integer, provider, out result);

        /// <inheritdoc />
        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider, out float result) => float.TryParse(value, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider, out result);

        /// <inheritdoc />
        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider, out double result) => double.TryParse(value, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider, out result);

        /// <inheritdoc />
        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider, out decimal result) => decimal.TryParse(value, style ?? NumberStyles.Number, provider, out result);

        /// <inheritdoc />
        public bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider, out BigInteger result) => BigInteger.TryParse(value, style ?? NumberStyles.Integer, provider, out result);
        #endregion

        #region TryFormat
        /// <inheritdoc />
        public bool TryFormat(sbyte value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        /// <inheritdoc />
        public bool TryFormat(byte value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        /// <inheritdoc />
        public bool TryFormat(short value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        /// <inheritdoc />
        public bool TryFormat(ushort value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        /// <inheritdoc />
        public bool TryFormat(int value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        /// <inheritdoc />
        public bool TryFormat(uint value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        /// <inheritdoc />
        public bool TryFormat(long value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        /// <inheritdoc />
        public bool TryFormat(ulong value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        /// <inheritdoc />
        public bool TryFormat(float value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        /// <inheritdoc />
        public bool TryFormat(double value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        /// <inheritdoc />
        public bool TryFormat(decimal value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        /// <inheritdoc />
        public bool TryFormat(BigInteger value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => value.TryFormat(destination, out charsWritten, format, provider);
        #endregion
#endif

        #region Convert
        sbyte INumericOperations<sbyte>.Convert<TFrom>(TFrom value) => Number.GetOperations<TFrom>()?.ToSByte(value) ?? Convert.ToSByte(value);

        byte INumericOperations<byte>.Convert<TFrom>(TFrom value) => Number.GetOperations<TFrom>()?.ToByte(value) ?? Convert.ToByte(value);

        short INumericOperations<short>.Convert<TFrom>(TFrom value) => Number.GetOperations<TFrom>()?.ToInt16(value) ?? Convert.ToInt16(value);

        ushort INumericOperations<ushort>.Convert<TFrom>(TFrom value) => Number.GetOperations<TFrom>()?.ToUInt16(value) ?? Convert.ToUInt16(value);

        int INumericOperations<int>.Convert<TFrom>(TFrom value) => Number.GetOperations<TFrom>()?.ToInt32(value) ?? Convert.ToInt32(value);

        uint INumericOperations<uint>.Convert<TFrom>(TFrom value) => Number.GetOperations<TFrom>()?.ToUInt32(value) ?? Convert.ToUInt32(value);

        long INumericOperations<long>.Convert<TFrom>(TFrom value) => Number.GetOperations<TFrom>()?.ToInt64(value) ?? Convert.ToInt64(value);

        ulong INumericOperations<ulong>.Convert<TFrom>(TFrom value) => Number.GetOperations<TFrom>()?.ToUInt64(value) ?? Convert.ToUInt64(value);

        float INumericOperations<float>.Convert<TFrom>(TFrom value) => Number.GetOperations<TFrom>()?.ToSingle(value) ?? Convert.ToSingle(value);

        double INumericOperations<double>.Convert<TFrom>(TFrom value) => Number.GetOperations<TFrom>()?.ToDouble(value) ?? Convert.ToDouble(value);

        decimal INumericOperations<decimal>.Convert<TFrom>(TFrom value) => Number.GetOperations<TFrom>()?.ToDecimal(value) ?? Convert.ToDecimal(value);

        BigInteger INumericOperations<BigInteger>.Convert<TFrom>(TFrom value) => value != null ? Number.GetOperationsInternal<TFrom>().ToBigInteger(value) : default;
        #endregion

        #region ToSByte
        /// <inheritdoc />
        public sbyte ToSByte(sbyte value) => Convert.ToSByte(value);

        /// <inheritdoc />
        public sbyte ToSByte(byte value) => Convert.ToSByte(value);

        /// <inheritdoc />
        public sbyte ToSByte(short value) => Convert.ToSByte(value);

        /// <inheritdoc />
        public sbyte ToSByte(ushort value) => Convert.ToSByte(value);

        /// <inheritdoc />
        public sbyte ToSByte(int value) => Convert.ToSByte(value);

        /// <inheritdoc />
        public sbyte ToSByte(uint value) => Convert.ToSByte(value);

        /// <inheritdoc />
        public sbyte ToSByte(long value) => Convert.ToSByte(value);

        /// <inheritdoc />
        public sbyte ToSByte(ulong value) => Convert.ToSByte(value);

        /// <inheritdoc />
        public sbyte ToSByte(float value) => Convert.ToSByte(value);

        /// <inheritdoc />
        public sbyte ToSByte(double value) => Convert.ToSByte(value);

        /// <inheritdoc />
        public sbyte ToSByte(decimal value) => Convert.ToSByte(value);

        /// <inheritdoc />
        public sbyte ToSByte(BigInteger value) => (sbyte)value;
        #endregion

        #region ToByte
        /// <inheritdoc />
        public byte ToByte(sbyte value) => Convert.ToByte(value);

        /// <inheritdoc />
        public byte ToByte(byte value) => Convert.ToByte(value);

        /// <inheritdoc />
        public byte ToByte(short value) => Convert.ToByte(value);

        /// <inheritdoc />
        public byte ToByte(ushort value) => Convert.ToByte(value);

        /// <inheritdoc />
        public byte ToByte(int value) => Convert.ToByte(value);

        /// <inheritdoc />
        public byte ToByte(uint value) => Convert.ToByte(value);

        /// <inheritdoc />
        public byte ToByte(long value) => Convert.ToByte(value);

        /// <inheritdoc />
        public byte ToByte(ulong value) => Convert.ToByte(value);

        /// <inheritdoc />
        public byte ToByte(float value) => Convert.ToByte(value);

        /// <inheritdoc />
        public byte ToByte(double value) => Convert.ToByte(value);

        /// <inheritdoc />
        public byte ToByte(decimal value) => Convert.ToByte(value);

        /// <inheritdoc />
        public byte ToByte(BigInteger value) => (byte)value;
        #endregion

        #region ToInt16
        /// <inheritdoc />
        public short ToInt16(sbyte value) => Convert.ToInt16(value);

        /// <inheritdoc />
        public short ToInt16(byte value) => Convert.ToInt16(value);

        /// <inheritdoc />
        public short ToInt16(short value) => Convert.ToInt16(value);

        /// <inheritdoc />
        public short ToInt16(ushort value) => Convert.ToInt16(value);

        /// <inheritdoc />
        public short ToInt16(int value) => Convert.ToInt16(value);

        /// <inheritdoc />
        public short ToInt16(uint value) => Convert.ToInt16(value);

        /// <inheritdoc />
        public short ToInt16(long value) => Convert.ToInt16(value);

        /// <inheritdoc />
        public short ToInt16(ulong value) => Convert.ToInt16(value);

        /// <inheritdoc />
        public short ToInt16(float value) => Convert.ToInt16(value);

        /// <inheritdoc />
        public short ToInt16(double value) => Convert.ToInt16(value);

        /// <inheritdoc />
        public short ToInt16(decimal value) => Convert.ToInt16(value);

        /// <inheritdoc />
        public short ToInt16(BigInteger value) => (short)value;
        #endregion

        #region ToUInt16
        /// <inheritdoc />
        public ushort ToUInt16(sbyte value) => Convert.ToUInt16(value);

        /// <inheritdoc />
        public ushort ToUInt16(byte value) => Convert.ToUInt16(value);

        /// <inheritdoc />
        public ushort ToUInt16(short value) => Convert.ToUInt16(value);

        /// <inheritdoc />
        public ushort ToUInt16(ushort value) => Convert.ToUInt16(value);

        /// <inheritdoc />
        public ushort ToUInt16(int value) => Convert.ToUInt16(value);

        /// <inheritdoc />
        public ushort ToUInt16(uint value) => Convert.ToUInt16(value);

        /// <inheritdoc />
        public ushort ToUInt16(long value) => Convert.ToUInt16(value);

        /// <inheritdoc />
        public ushort ToUInt16(ulong value) => Convert.ToUInt16(value);

        /// <inheritdoc />
        public ushort ToUInt16(float value) => Convert.ToUInt16(value);

        /// <inheritdoc />
        public ushort ToUInt16(double value) => Convert.ToUInt16(value);

        /// <inheritdoc />
        public ushort ToUInt16(decimal value) => Convert.ToUInt16(value);

        /// <inheritdoc />
        public ushort ToUInt16(BigInteger value) => (ushort)value;
        #endregion

        #region ToInt32
        /// <inheritdoc />
        public int ToInt32(sbyte value) => Convert.ToInt32(value);

        /// <inheritdoc />
        public int ToInt32(byte value) => Convert.ToInt32(value);

        /// <inheritdoc />
        public int ToInt32(short value) => Convert.ToInt32(value);

        /// <inheritdoc />
        public int ToInt32(ushort value) => Convert.ToInt32(value);

        /// <inheritdoc />
        public int ToInt32(int value) => Convert.ToInt32(value);

        /// <inheritdoc />
        public int ToInt32(uint value) => Convert.ToInt32(value);

        /// <inheritdoc />
        public int ToInt32(long value) => Convert.ToInt32(value);

        /// <inheritdoc />
        public int ToInt32(ulong value) => Convert.ToInt32(value);

        /// <inheritdoc />
        public int ToInt32(float value) => Convert.ToInt32(value);

        /// <inheritdoc />
        public int ToInt32(double value) => Convert.ToInt32(value);

        /// <inheritdoc />
        public int ToInt32(decimal value) => Convert.ToInt32(value);

        /// <inheritdoc />
        public int ToInt32(BigInteger value) => (int)value;
        #endregion

        #region ToUInt32
        /// <inheritdoc />
        public uint ToUInt32(sbyte value) => Convert.ToUInt32(value);

        /// <inheritdoc />
        public uint ToUInt32(byte value) => Convert.ToUInt32(value);

        /// <inheritdoc />
        public uint ToUInt32(short value) => Convert.ToUInt32(value);

        /// <inheritdoc />
        public uint ToUInt32(ushort value) => Convert.ToUInt32(value);

        /// <inheritdoc />
        public uint ToUInt32(int value) => Convert.ToUInt32(value);

        /// <inheritdoc />
        public uint ToUInt32(uint value) => Convert.ToUInt32(value);

        /// <inheritdoc />
        public uint ToUInt32(long value) => Convert.ToUInt32(value);

        /// <inheritdoc />
        public uint ToUInt32(ulong value) => Convert.ToUInt32(value);

        /// <inheritdoc />
        public uint ToUInt32(float value) => Convert.ToUInt32(value);

        /// <inheritdoc />
        public uint ToUInt32(double value) => Convert.ToUInt32(value);

        /// <inheritdoc />
        public uint ToUInt32(decimal value) => Convert.ToUInt32(value);

        /// <inheritdoc />
        public uint ToUInt32(BigInteger value) => (uint)value;
        #endregion

        #region ToInt64
        /// <inheritdoc />
        public long ToInt64(sbyte value) => Convert.ToInt64(value);

        /// <inheritdoc />
        public long ToInt64(byte value) => Convert.ToInt64(value);

        /// <inheritdoc />
        public long ToInt64(short value) => Convert.ToInt64(value);

        /// <inheritdoc />
        public long ToInt64(ushort value) => Convert.ToInt64(value);

        /// <inheritdoc />
        public long ToInt64(int value) => Convert.ToInt64(value);

        /// <inheritdoc />
        public long ToInt64(uint value) => Convert.ToInt64(value);

        /// <inheritdoc />
        public long ToInt64(long value) => Convert.ToInt64(value);

        /// <inheritdoc />
        public long ToInt64(ulong value) => Convert.ToInt64(value);

        /// <inheritdoc />
        public long ToInt64(float value) => Convert.ToInt64(value);

        /// <inheritdoc />
        public long ToInt64(double value) => Convert.ToInt64(value);

        /// <inheritdoc />
        public long ToInt64(decimal value) => Convert.ToInt64(value);

        /// <inheritdoc />
        public long ToInt64(BigInteger value) => (long)value;
        #endregion

        #region ToUInt64
        /// <inheritdoc />
        public ulong ToUInt64(sbyte value) => Convert.ToUInt64(value);

        /// <inheritdoc />
        public ulong ToUInt64(byte value) => Convert.ToUInt64(value);

        /// <inheritdoc />
        public ulong ToUInt64(short value) => Convert.ToUInt64(value);

        /// <inheritdoc />
        public ulong ToUInt64(ushort value) => Convert.ToUInt64(value);

        /// <inheritdoc />
        public ulong ToUInt64(int value) => Convert.ToUInt64(value);

        /// <inheritdoc />
        public ulong ToUInt64(uint value) => Convert.ToUInt64(value);

        /// <inheritdoc />
        public ulong ToUInt64(long value) => Convert.ToUInt64(value);

        /// <inheritdoc />
        public ulong ToUInt64(ulong value) => Convert.ToUInt64(value);

        /// <inheritdoc />
        public ulong ToUInt64(float value) => Convert.ToUInt64(value);

        /// <inheritdoc />
        public ulong ToUInt64(double value) => Convert.ToUInt64(value);

        /// <inheritdoc />
        public ulong ToUInt64(decimal value) => Convert.ToUInt64(value);

        /// <inheritdoc />
        public ulong ToUInt64(BigInteger value) => (ulong)value;
        #endregion

        #region ToSingle
        /// <inheritdoc />
        public float ToSingle(sbyte value) => Convert.ToSingle(value);

        /// <inheritdoc />
        public float ToSingle(byte value) => Convert.ToSingle(value);

        /// <inheritdoc />
        public float ToSingle(short value) => Convert.ToSingle(value);

        /// <inheritdoc />
        public float ToSingle(ushort value) => Convert.ToSingle(value);

        /// <inheritdoc />
        public float ToSingle(int value) => Convert.ToSingle(value);

        /// <inheritdoc />
        public float ToSingle(uint value) => Convert.ToSingle(value);

        /// <inheritdoc />
        public float ToSingle(long value) => Convert.ToSingle(value);

        /// <inheritdoc />
        public float ToSingle(ulong value) => Convert.ToSingle(value);

        /// <inheritdoc />
        public float ToSingle(float value) => Convert.ToSingle(value);

        /// <inheritdoc />
        public float ToSingle(double value) => Convert.ToSingle(value);

        /// <inheritdoc />
        public float ToSingle(decimal value) => Convert.ToSingle(value);

        /// <inheritdoc />
        public float ToSingle(BigInteger value) => (float)value;
        #endregion

        #region ToDouble
        /// <inheritdoc />
        public double ToDouble(sbyte value) => Convert.ToDouble(value);

        /// <inheritdoc />
        public double ToDouble(byte value) => Convert.ToDouble(value);

        /// <inheritdoc />
        public double ToDouble(short value) => Convert.ToDouble(value);

        /// <inheritdoc />
        public double ToDouble(ushort value) => Convert.ToDouble(value);

        /// <inheritdoc />
        public double ToDouble(int value) => Convert.ToDouble(value);

        /// <inheritdoc />
        public double ToDouble(uint value) => Convert.ToDouble(value);

        /// <inheritdoc />
        public double ToDouble(long value) => Convert.ToDouble(value);

        /// <inheritdoc />
        public double ToDouble(ulong value) => Convert.ToDouble(value);

        /// <inheritdoc />
        public double ToDouble(float value) => Convert.ToDouble(value);

        /// <inheritdoc />
        public double ToDouble(double value) => Convert.ToDouble(value);

        /// <inheritdoc />
        public double ToDouble(decimal value) => Convert.ToDouble(value);

        /// <inheritdoc />
        public double ToDouble(BigInteger value) => (double)value;
        #endregion

        #region ToDecimal
        /// <inheritdoc />
        public decimal ToDecimal(sbyte value) => Convert.ToDecimal(value);

        /// <inheritdoc />
        public decimal ToDecimal(byte value) => Convert.ToDecimal(value);

        /// <inheritdoc />
        public decimal ToDecimal(short value) => Convert.ToDecimal(value);

        /// <inheritdoc />
        public decimal ToDecimal(ushort value) => Convert.ToDecimal(value);

        /// <inheritdoc />
        public decimal ToDecimal(int value) => Convert.ToDecimal(value);

        /// <inheritdoc />
        public decimal ToDecimal(uint value) => Convert.ToDecimal(value);

        /// <inheritdoc />
        public decimal ToDecimal(long value) => Convert.ToDecimal(value);

        /// <inheritdoc />
        public decimal ToDecimal(ulong value) => Convert.ToDecimal(value);

        /// <inheritdoc />
        public decimal ToDecimal(float value) => Convert.ToDecimal(value);

        /// <inheritdoc />
        public decimal ToDecimal(double value) => Convert.ToDecimal(value);

        /// <inheritdoc />
        public decimal ToDecimal(decimal value) => Convert.ToDecimal(value);

        /// <inheritdoc />
        public decimal ToDecimal(BigInteger value) => (decimal)value;
        #endregion

        #region ToBigInteger
        /// <inheritdoc />
        public BigInteger ToBigInteger(sbyte value) => value;

        /// <inheritdoc />
        public BigInteger ToBigInteger(byte value) => value;

        /// <inheritdoc />
        public BigInteger ToBigInteger(short value) => value;

        /// <inheritdoc />
        public BigInteger ToBigInteger(ushort value) => value;

        /// <inheritdoc />
        public BigInteger ToBigInteger(int value) => value;

        /// <inheritdoc />
        public BigInteger ToBigInteger(uint value) => value;

        /// <inheritdoc />
        public BigInteger ToBigInteger(long value) => value;

        /// <inheritdoc />
        public BigInteger ToBigInteger(ulong value) => value;

        /// <inheritdoc />
        public BigInteger ToBigInteger(float value) => (BigInteger)value;

        /// <inheritdoc />
        public BigInteger ToBigInteger(double value) => (BigInteger)value;

        /// <inheritdoc />
        public BigInteger ToBigInteger(decimal value) => (BigInteger)value;

        /// <inheritdoc />
        public BigInteger ToBigInteger(BigInteger value) => value;
        #endregion

        #region Round
        /// <inheritdoc />
        public sbyte Round(sbyte value, int digits, MidpointRounding mode) => value;

        /// <inheritdoc />
        public byte Round(byte value, int digits, MidpointRounding mode) => value;

        /// <inheritdoc />
        public short Round(short value, int digits, MidpointRounding mode) => value;

        /// <inheritdoc />
        public ushort Round(ushort value, int digits, MidpointRounding mode) => value;

        /// <inheritdoc />
        public int Round(int value, int digits, MidpointRounding mode) => value;

        /// <inheritdoc />
        public uint Round(uint value, int digits, MidpointRounding mode) => value;

        /// <inheritdoc />
        public long Round(long value, int digits, MidpointRounding mode) => value;

        /// <inheritdoc />
        public ulong Round(ulong value, int digits, MidpointRounding mode) => value;

        /// <inheritdoc />
        public float Round(float value, int digits, MidpointRounding mode)
        {
#if MATHF
            return MathF.Round(value, digits, mode);
#else
            return (float)Math.Round(value, digits, mode);
#endif
        }

        /// <inheritdoc />
        public double Round(double value, int digits, MidpointRounding mode) => Math.Round(value, digits, mode);

        /// <inheritdoc />
        public decimal Round(decimal value, int digits, MidpointRounding mode) => Math.Round(value, digits, mode);

        /// <inheritdoc />
        public BigInteger Round(BigInteger value, int digits, MidpointRounding mode) => value;
        #endregion

        #region Floor
        /// <inheritdoc />
        public sbyte Floor(sbyte value) => value;

        /// <inheritdoc />
        public byte Floor(byte value) => value;

        /// <inheritdoc />
        public short Floor(short value) => value;

        /// <inheritdoc />
        public ushort Floor(ushort value) => value;

        /// <inheritdoc />
        public int Floor(int value) => value;

        /// <inheritdoc />
        public uint Floor(uint value) => value;

        /// <inheritdoc />
        public long Floor(long value) => value;

        /// <inheritdoc />
        public ulong Floor(ulong value) => value;

        /// <inheritdoc />
        public float Floor(float value)
        {
#if MATHF
            return MathF.Floor(value);
#else
            return (float)Math.Floor(value);
#endif
        }

        /// <inheritdoc />
        public double Floor(double value) => Math.Floor(value);

        /// <inheritdoc />
        public decimal Floor(decimal value) => Math.Floor(value);

        /// <inheritdoc />
        public BigInteger Floor(BigInteger value) => value;
        #endregion

        #region Ceiling
        /// <inheritdoc />
        public sbyte Ceiling(sbyte value) => value;

        /// <inheritdoc />
        public byte Ceiling(byte value) => value;

        /// <inheritdoc />
        public short Ceiling(short value) => value;

        /// <inheritdoc />
        public ushort Ceiling(ushort value) => value;

        /// <inheritdoc />
        public int Ceiling(int value) => value;

        /// <inheritdoc />
        public uint Ceiling(uint value) => value;

        /// <inheritdoc />
        public long Ceiling(long value) => value;

        /// <inheritdoc />
        public ulong Ceiling(ulong value) => value;

        /// <inheritdoc />
        public float Ceiling(float value)
        {
#if MATHF
            return MathF.Ceiling(value);
#else
            return (float)Math.Ceiling(value);
#endif
        }

        /// <inheritdoc />
        public double Ceiling(double value) => Math.Ceiling(value);

        /// <inheritdoc />
        public decimal Ceiling(decimal value) => Math.Ceiling(value);

        /// <inheritdoc />
        public BigInteger Ceiling(BigInteger value) => value;
        #endregion

        #region Truncate
        /// <inheritdoc />
        public sbyte Truncate(sbyte value) => value;

        /// <inheritdoc />
        public byte Truncate(byte value) => value;

        /// <inheritdoc />
        public short Truncate(short value) => value;

        /// <inheritdoc />
        public ushort Truncate(ushort value) => value;

        /// <inheritdoc />
        public int Truncate(int value) => value;

        /// <inheritdoc />
        public uint Truncate(uint value) => value;

        /// <inheritdoc />
        public long Truncate(long value) => value;

        /// <inheritdoc />
        public ulong Truncate(ulong value) => value;

        /// <inheritdoc />
        public float Truncate(float value)
        {
#if MATHF
            return MathF.Truncate(value);
#else
            return (float)Math.Truncate(value);
#endif
        }

        /// <inheritdoc />
        public double Truncate(double value) => Math.Truncate(value);

        /// <inheritdoc />
        public decimal Truncate(decimal value) => Math.Truncate(value);

        /// <inheritdoc />
        public BigInteger Truncate(BigInteger value) => value;
        #endregion

        #region Compare
        /// <inheritdoc />
        public int Compare(sbyte left, sbyte right) => left.CompareTo(right);

        /// <inheritdoc />
        public int Compare(byte left, byte right) => left.CompareTo(right);

        /// <inheritdoc />
        public int Compare(short left, short right) => left.CompareTo(right);

        /// <inheritdoc />
        public int Compare(ushort left, ushort right) => left.CompareTo(right);

        /// <inheritdoc />
        public int Compare(int left, int right) => left.CompareTo(right);

        /// <inheritdoc />
        public int Compare(uint left, uint right) => left.CompareTo(right);

        /// <inheritdoc />
        public int Compare(long left, long right) => left.CompareTo(right);

        /// <inheritdoc />
        public int Compare(ulong left, ulong right) => left.CompareTo(right);

        /// <inheritdoc />
        public int Compare(float left, float right) => left.CompareTo(right);

        /// <inheritdoc />
        public int Compare(double left, double right) => left.CompareTo(right);

        /// <inheritdoc />
        public int Compare(decimal left, decimal right) => left.CompareTo(right);

        /// <inheritdoc />
        public int Compare(BigInteger left, BigInteger right) => left.CompareTo(right);
        #endregion

        #region Abs
        /// <inheritdoc />
        public sbyte Abs(sbyte value) => Math.Abs(value);

        /// <inheritdoc />
        public byte Abs(byte value) => value;

        /// <inheritdoc />
        public short Abs(short value) => Math.Abs(value);

        /// <inheritdoc />
        public ushort Abs(ushort value) => value;

        /// <inheritdoc />
        public int Abs(int value) => Math.Abs(value);

        /// <inheritdoc />
        public uint Abs(uint value) => value;

        /// <inheritdoc />
        public long Abs(long value) => Math.Abs(value);

        /// <inheritdoc />
        public ulong Abs(ulong value) => value;

        /// <inheritdoc />
        public float Abs(float value) => Math.Abs(value);

        /// <inheritdoc />
        public double Abs(double value) => Math.Abs(value);

        /// <inheritdoc />
        public decimal Abs(decimal value) => Math.Abs(value);

        /// <inheritdoc />
        public BigInteger Abs(BigInteger value) => BigInteger.Abs(value);
        #endregion

        #region Max
        /// <inheritdoc />
        public sbyte Max(sbyte left, sbyte right) => Math.Max(left, right);

        /// <inheritdoc />
        public byte Max(byte left, byte right) => Math.Max(left, right);

        /// <inheritdoc />
        public short Max(short left, short right) => Math.Max(left, right);

        /// <inheritdoc />
        public ushort Max(ushort left, ushort right) => Math.Max(left, right);

        /// <inheritdoc />
        public int Max(int left, int right) => Math.Max(left, right);

        /// <inheritdoc />
        public uint Max(uint left, uint right) => Math.Max(left, right);

        /// <inheritdoc />
        public long Max(long left, long right) => Math.Max(left, right);

        /// <inheritdoc />
        public ulong Max(ulong left, ulong right) => Math.Max(left, right);

        /// <inheritdoc />
        public float Max(float left, float right) => Math.Max(left, right);

        /// <inheritdoc />
        public double Max(double left, double right) => Math.Max(left, right);

        /// <inheritdoc />
        public decimal Max(decimal left, decimal right) => Math.Max(left, right);

        /// <inheritdoc />
        public BigInteger Max(BigInteger left, BigInteger right) => BigInteger.Max(left, right);
        #endregion

        #region Min
        /// <inheritdoc />
        public sbyte Min(sbyte left, sbyte right) => Math.Min(left, right);

        /// <inheritdoc />
        public byte Min(byte left, byte right) => Math.Min(left, right);

        /// <inheritdoc />
        public short Min(short left, short right) => Math.Min(left, right);

        /// <inheritdoc />
        public ushort Min(ushort left, ushort right) => Math.Min(left, right);

        /// <inheritdoc />
        public int Min(int left, int right) => Math.Min(left, right);

        /// <inheritdoc />
        public uint Min(uint left, uint right) => Math.Min(left, right);

        /// <inheritdoc />
        public long Min(long left, long right) => Math.Min(left, right);

        /// <inheritdoc />
        public ulong Min(ulong left, ulong right) => Math.Min(left, right);

        /// <inheritdoc />
        public float Min(float left, float right) => Math.Min(left, right);

        /// <inheritdoc />
        public double Min(double left, double right) => Math.Min(left, right);

        /// <inheritdoc />
        public decimal Min(decimal left, decimal right) => Math.Min(left, right);

        /// <inheritdoc />
        public BigInteger Min(BigInteger left, BigInteger right) => BigInteger.Min(left, right);
        #endregion

        #region Sign
        /// <inheritdoc />
        public int Sign(sbyte value) => Math.Sign(value);

        /// <inheritdoc />
        public int Sign(byte value) => value == 0U ? 0 : 1;

        /// <inheritdoc />
        public int Sign(short value) => Math.Sign(value);

        /// <inheritdoc />
        public int Sign(ushort value) => value == 0U ? 0 : 1;

        /// <inheritdoc />
        public int Sign(int value) => Math.Sign(value);

        /// <inheritdoc />
        public int Sign(uint value) => value == 0U ? 0 : 1;

        /// <inheritdoc />
        public int Sign(long value) => Math.Sign(value);

        /// <inheritdoc />
        public int Sign(ulong value) => value == 0UL ? 0 : 1;

        /// <inheritdoc />
        public int Sign(float value) => Math.Sign(value);

        /// <inheritdoc />
        public int Sign(double value) => Math.Sign(value);

        /// <inheritdoc />
        public int Sign(decimal value) => Math.Sign(value);

        /// <inheritdoc />
        public int Sign(BigInteger value) => value.Sign;
        #endregion

        #region ToString
        /// <inheritdoc />
        public string ToString(sbyte value, string? format, IFormatProvider? provider) => value.ToString(format, provider);

        /// <inheritdoc />
        public string ToString(byte value, string? format, IFormatProvider? provider) => value.ToString(format, provider);

        /// <inheritdoc />
        public string ToString(short value, string? format, IFormatProvider? provider) => value.ToString(format, provider);

        /// <inheritdoc />
        public string ToString(ushort value, string? format, IFormatProvider? provider) => value.ToString(format, provider);

        /// <inheritdoc />
        public string ToString(int value, string? format, IFormatProvider? provider) => value.ToString(format, provider);

        /// <inheritdoc />
        public string ToString(uint value, string? format, IFormatProvider? provider) => value.ToString(format, provider);

        /// <inheritdoc />
        public string ToString(long value, string? format, IFormatProvider? provider) => value.ToString(format, provider);

        /// <inheritdoc />
        public string ToString(ulong value, string? format, IFormatProvider? provider) => value.ToString(format, provider);

        /// <inheritdoc />
        public string ToString(float value, string? format, IFormatProvider? provider) => value.ToString(format, provider);

        /// <inheritdoc />
        public string ToString(double value, string? format, IFormatProvider? provider) => value.ToString(format, provider);

        /// <inheritdoc />
        public string ToString(decimal value, string? format, IFormatProvider? provider) => value.ToString(format, provider);

        /// <inheritdoc />
        public string ToString(BigInteger value, string? format, IFormatProvider? provider) => value.ToString(format, provider);
        #endregion

        #region IsEven
        /// <inheritdoc />
        public bool IsEven(sbyte value) => (value % 2) == 0;

        /// <inheritdoc />
        public bool IsEven(byte value) => (value % 2) == 0;

        /// <inheritdoc />
        public bool IsEven(short value) => (value % 2) == 0;

        /// <inheritdoc />
        public bool IsEven(ushort value) => (value % 2) == 0;

        /// <inheritdoc />
        public bool IsEven(int value) => (value % 2) == 0;

        /// <inheritdoc />
        public bool IsEven(uint value) => (value % 2U) == 0U;

        /// <inheritdoc />
        public bool IsEven(long value) => (value % 2L) == 0L;

        /// <inheritdoc />
        public bool IsEven(ulong value) => (value % 2UL) == 0UL;

        /// <inheritdoc />
        public bool IsEven(float value) => throw new NotSupportedException("IsEven is not supported for floating point types");

        /// <inheritdoc />
        public bool IsEven(double value) => throw new NotSupportedException("IsEven is not supported for floating point types");

        /// <inheritdoc />
        public bool IsEven(decimal value) => throw new NotSupportedException("IsEven is not supported for floating point types");

        /// <inheritdoc />
        public bool IsEven(BigInteger value) => value.IsEven;
        #endregion

        #region IsOdd
        /// <inheritdoc />
        public bool IsOdd(sbyte value) => (value % 2) == 1;

        /// <inheritdoc />
        public bool IsOdd(byte value) => (value % 2) == 1;

        /// <inheritdoc />
        public bool IsOdd(short value) => (value % 2) == 1;

        /// <inheritdoc />
        public bool IsOdd(ushort value) => (value % 2) == 1;

        /// <inheritdoc />
        public bool IsOdd(int value) => (value % 2) == 1;

        /// <inheritdoc />
        public bool IsOdd(uint value) => (value % 2U) == 1U;

        /// <inheritdoc />
        public bool IsOdd(long value) => (value % 2L) == 1L;

        /// <inheritdoc />
        public bool IsOdd(ulong value) => (value % 2UL) == 1UL;

        /// <inheritdoc />
        public bool IsOdd(float value) => throw new NotSupportedException("IsOdd is not supported for floating point types");

        /// <inheritdoc />
        public bool IsOdd(double value) => throw new NotSupportedException("IsOdd is not supported for floating point types");

        /// <inheritdoc />
        public bool IsOdd(decimal value) => throw new NotSupportedException("IsOdd is not supported for floating point types");

        /// <inheritdoc />
        public bool IsOdd(BigInteger value) => !value.IsEven;
        #endregion

        #region IsPowerOfTwo
        /// <inheritdoc />
        public bool IsPowerOfTwo(sbyte value) => (value & (value - 1)) == 0;

        /// <inheritdoc />
        public bool IsPowerOfTwo(byte value) => (value & (value - 1)) == 0;

        /// <inheritdoc />
        public bool IsPowerOfTwo(short value) => (value & (value - 1)) == 0;

        /// <inheritdoc />
        public bool IsPowerOfTwo(ushort value) => (value & (value - 1)) == 0;

        /// <inheritdoc />
        public bool IsPowerOfTwo(int value) => (value & (value - 1)) == 0;

        /// <inheritdoc />
        public bool IsPowerOfTwo(uint value) => (value & (value - 1U)) == 0U;

        /// <inheritdoc />
        public bool IsPowerOfTwo(long value) => (value & (value - 1L)) == 0L;

        /// <inheritdoc />
        public bool IsPowerOfTwo(ulong value) => (value & (value - 1UL)) == 0UL;

        /// <inheritdoc />
        public bool IsPowerOfTwo(float value) => throw new NotSupportedException("IsPowerOfTwo is not supported for floating point types");

        /// <inheritdoc />
        public bool IsPowerOfTwo(double value) => throw new NotSupportedException("IsPowerOfTwo is not supported for floating point types");

        /// <inheritdoc />
        public bool IsPowerOfTwo(decimal value) => throw new NotSupportedException("IsPowerOfTwo is not supported for floating point types");

        /// <inheritdoc />
        public bool IsPowerOfTwo(BigInteger value) => value.IsPowerOfTwo;
        #endregion

        #region Clamp
        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        private static void ThrowMinMaxException<T>(T min, T max) => throw new ArgumentException($"'{min}' cannot be greater than '{max}'.");
        #endregion

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is DefaultNumericOperations;

        /// <inheritdoc />
        public override int GetHashCode() => nameof(DefaultNumericOperations).GetHashCode();

#pragma warning disable IDE0060 // Remove unused parameter
        /// <inheritdoc />
        public static bool operator ==(DefaultNumericOperations left, DefaultNumericOperations right) => true;

        /// <inheritdoc />
        public static bool operator !=(DefaultNumericOperations left, DefaultNumericOperations right) => false;
#pragma warning restore IDE0060 // Remove unused parameter
    }
}