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

#if BIG_INTEGER
using System.Numerics;
#endif

namespace Genumerics
{
    /// <summary>
    /// A number wrapper type that provides numeric operations in the form of convenient type operators.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    public readonly struct Number<T> : IEquatable<Number<T>>, IComparable<Number<T>>, IComparable, IFormattable
#if ICONVERTIBLE
        , IConvertible
#endif
    {
        internal static readonly INumericOperations<T> s_operations = DefaultNumericOperations.Instance as INumericOperations<T> ?? NullableNumericOperationsStore<T>.Instance;

        internal static INumericOperations<T> Operations => s_operations ?? throw new NotSupportedException($"Generic numeric operations on {typeof(T)} are not supported. The only supported types are SByte, Byte, Int16, UInt16, Int32, UInt32, Int64, UInt64, Single, Double, Decimal, and Number<T> as well as the generic versions of each of these types.");

        /// <summary>
        /// The numeric value.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Number constructor.
        /// </summary>
        /// <param name="value">The numeric value.</param>
        public Number(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Returns the hash code for the current object.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode() => Value?.GetHashCode() ?? 0;

        /// <summary>
        /// Converts the numeric value of the current object to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of the current numeric value.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public override string ToString() => Operations.ToString(Value, null, null);

        /// <summary>
        /// Converts the numeric value of the current numeric object to its equivalent string representation by using the specified format.
        /// </summary>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <returns>The string representation of the current numeric value in the format specified by the <paramref name="format"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="FormatException"><paramref name="format"/> is not a valid format string.</exception>
        public string ToString(string format) => Operations.ToString(Value, format, null);

        /// <summary>
        /// Converts the numeric value of the current numeric object to its equivalent string representation by using the specified culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>The string representation of the current numeric value in the format specified by the <paramref name="provider"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public string ToString(IFormatProvider provider) => Operations.ToString(Value, null, provider);

        /// <summary>
        /// Converts the numeric value of the current numeric object to its equivalent string representation by using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>The string representation of the current numeric value as specified by the <paramref name="format"/> and <paramref name="provider"/> parameters.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="FormatException"><paramref name="format"/> is not a valid format string.</exception>
        public string ToString(string format, IFormatProvider provider) => Operations.ToString(Value, format, provider);

        /// <summary>
        /// Returns a value that indicates whether the current instance and a specified object have the same value.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns><c>true</c> if the <paramref name="obj"/> argument is a <see cref="Number{T}"/> object, and its value is equal to the value of the current instance; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public override bool Equals(object obj) => obj is Number<T> n && Equals(n);

        /// <summary>
        /// Returns a value that indicates whether the current instance and a specified <see cref="Number{T}"/> object have the same value.
        /// </summary>
        /// <param name="other">The object to compare.</param>
        /// <returns><c>true</c> if this numeric object and <paramref name="other"/> have the same value; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public bool Equals(Number<T> other) => Operations.Equals(Value, other);

        /// <summary>
        /// Compares this instance to a specified object and returns an integer that indicates
        /// whether the value of this instance is less than, equal to, or greater than the
        /// value of the specified object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>A signed integer that indicates the relative values of the current instance and <paramref name="obj"/>,
        /// less than zero if current instance is less than <paramref name="obj"/>,
        /// zero if current instance equals <paramref name="obj"/>,
        /// and greater than zero if current instance is greater than <paramref name="obj"/> or <paramref name="obj"/> is <c>null</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public int CompareTo(object obj) => obj is Number<T> n ? CompareTo(n) : (Value == null ? 0 : 1);

        /// <summary>
        /// Compares this instance to a specified object and returns an integer that indicates
        /// whether the value of this instance is less than, equal to, or greater than the
        /// value of the specified object.
        /// </summary>
        /// <param name="other">The object to compare.</param>
        /// <returns>A signed integer that indicates the relative values of the current instance and <paramref name="other"/>,
        /// less than zero if current instance is less than <paramref name="other"/>,
        /// zero if current instance equals <paramref name="other"/>,
        /// and greater than zero if current instance is greater than <paramref name="other"/>.</returns>
        public int CompareTo(Number<T> other) => Operations.Compare(Value, other);

        /// <summary>
        /// Converts the number to its <typeparamref name="TTo"/> equivalent.
        /// </summary>
        /// <typeparam name="TTo">The numeric type to convert to.</typeparam>
        /// <returns>A value that is equivalent to the number.</returns>
        /// <exception cref="NotSupportedException">One or both type arguments provided are not supported.</exception>
        /// <exception cref="OverflowException">Number is greater than <typeparamref name="TTo"/>'s MaxValue or less than <typeparamref name="TTo"/>'s MinValue.</exception>
        public TTo To<TTo>()
        {
            var operations = Number<TTo>.Operations;
            if (Value != null)
            {
                return operations.Convert(Value);
            }
            _ = Operations; // Necessary to validate conversion types
            return default;
        }

#if ICONVERTIBLE
        /// <summary>
        /// Returns the <see cref="TypeCode"/> for <typeparamref name="T"/>.
        /// </summary>
        /// <returns>The <see cref="TypeCode"/> for <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public TypeCode GetTypeCode() => Operations.TypeCode;

        bool IConvertible.ToBoolean(IFormatProvider provider) => Convert.ToBoolean(Value, provider);

        byte IConvertible.ToByte(IFormatProvider provider) => Operations.ToByte(Value);

        char IConvertible.ToChar(IFormatProvider provider) => Convert.ToChar(Value, provider);

        DateTime IConvertible.ToDateTime(IFormatProvider provider) => Convert.ToDateTime(Value, provider);

        decimal IConvertible.ToDecimal(IFormatProvider provider) => Operations.ToDecimal(Value);

        double IConvertible.ToDouble(IFormatProvider provider) => Operations.ToDouble(Value);

        short IConvertible.ToInt16(IFormatProvider provider) => Operations.ToInt16(Value);

        int IConvertible.ToInt32(IFormatProvider provider) => Operations.ToInt32(Value);

        long IConvertible.ToInt64(IFormatProvider provider) => Operations.ToInt64(Value);

        sbyte IConvertible.ToSByte(IFormatProvider provider) => Operations.ToSByte(Value);

        float IConvertible.ToSingle(IFormatProvider provider) => Operations.ToSingle(Value);

        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => Convert.ChangeType(Value, conversionType, provider);

        ushort IConvertible.ToUInt16(IFormatProvider provider) => Operations.ToUInt16(Value);

        uint IConvertible.ToUInt32(IFormatProvider provider) => Operations.ToUInt32(Value);

        ulong IConvertible.ToUInt64(IFormatProvider provider) => Operations.ToUInt64(Value);
#endif

        /// <summary>
        /// Defines an implicit conversion of a <typeparamref name="T"/> to a <see cref="Number{T}"/>.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        public static implicit operator Number<T>(T value) => new Number<T>(value);

        /// <summary>
        /// Defines an implicit conversion of a <see cref="Number{T}"/> to a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="value">The value to convert to a <typeparamref name="T"/>.</param>
        public static implicit operator T(Number<T> value) => value.Value;

        /// <summary>
        /// Returns the value of the numeric operand. (The sign of the operand is unchanged.)
        /// </summary>
        /// <param name="value">A numeric value.</param>
        /// <returns>The value of the <paramref name="value"/> operand.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static Number<T> operator +(Number<T> value) => value;

        /// <summary>
        /// Adds the values of two specified numeric objects.
        /// </summary>
        /// <param name="left">The first value to add.</param>
        /// <param name="right">The second value to add.</param>
        /// <returns>The sum of <paramref name="left"/> and <paramref name="right"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static Number<T> operator +(Number<T> left, Number<T> right) => Operations.Add(left, right);

        /// <summary>
        /// Negates a specified numeric value.
        /// </summary>
        /// <param name="value">The value to negate.</param>
        /// <returns>The result of the value parameter multiplied by negative one (-1).</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.
        /// -or-
        /// the numeric type doesn't support negative values.</exception>
        public static Number<T> operator -(Number<T> value) => Operations.Negate(value);

        /// <summary>
        /// Subtracts a numeric value from another numeric value.
        /// </summary>
        /// <param name="left">The value to subtract from (the minuend).</param>
        /// <param name="right">The value to subtract (the subtrahend).</param>
        /// <returns>The result of subtracting <paramref name="right"/> from <paramref name="left"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static Number<T> operator -(Number<T> left, Number<T> right) => Operations.Subtract(left, right);

        /// <summary>
        /// Returns the bitwise one's complement of a numeric value.
        /// </summary>
        /// <param name="value">An integer value.</param>
        /// <returns>The bitwise one's complement of <paramref name="value"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static Number<T> operator ~(Number<T> value) => Operations.Not(value);

        /// <summary>
        /// Increments a numeric value by 1.
        /// </summary>
        /// <param name="value">The value to increment.</param>
        /// <returns>The value of the <paramref name="value"/> parameter incremented by 1.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static Number<T> operator ++(Number<T> value) => Operations.Add(value, Operations.One);

        /// <summary>
        /// Decrements a numeric value by 1.
        /// </summary>
        /// <param name="value">The value to decrement.</param>
        /// <returns>The value of the <paramref name="value"/> parameter decremented by 1.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static Number<T> operator --(Number<T> value) => Operations.Subtract(value, Operations.One);

        /// <summary>
        /// Multiplies two specified numeric values.
        /// </summary>
        /// <param name="left">The first value to multiply.</param>
        /// <param name="right">The second value to multiply.</param>
        /// <returns>The product of <paramref name="left"/> and <paramref name="right"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static Number<T> operator *(Number<T> left, Number<T> right) => Operations.Multiply(left, right);

        /// <summary>
        /// Divides a specified numeric value by another specified numeric value.
        /// </summary>
        /// <param name="dividend">The value to be divided.</param>
        /// <param name="divisor">The value to divide by.</param>
        /// <returns>The result of the division.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="DivideByZeroException"><paramref name="divisor"/> is zero (0).</exception>
        public static Number<T> operator /(Number<T> dividend, Number<T> divisor) => Operations.Divide(dividend, divisor);

        /// <summary>
        /// Returns the remainder that results from division with two specified numeric values.
        /// </summary>
        /// <param name="dividend">The value to be divided.</param>
        /// <param name="divisor">The value to divide by.</param>
        /// <returns>The remainder that results from the division.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="DivideByZeroException"><paramref name="divisor"/> is zero (0).</exception>
        public static Number<T> operator %(Number<T> dividend, Number<T> divisor) => Operations.Remainder(dividend, divisor);

        /// <summary>
        /// Performs a bitwise And operation on two integral values.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The result of the bitwise And operation.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static Number<T> operator &(Number<T> left, Number<T> right) => Operations.And(left, right);

        /// <summary>
        /// Performs a bitwise Or operation on two integral values.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The result of the bitwise Or operation.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static Number<T> operator |(Number<T> left, Number<T> right) => Operations.Or(left, right);

        /// <summary>
        /// Performs a bitwise exclusive Or operation on two integral values.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The result of the bitwise exclusive Or operation.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static Number<T> operator ^(Number<T> left, Number<T> right) => Operations.Xor(left, right);

        /// <summary>
        /// Shifts an integral value a specified number of bits to the left.
        /// </summary>
        /// <param name="value">The value whose bits are to be shifted.</param>
        /// <param name="shift">The number of bits to shift value to the left.</param>
        /// <returns>A value that has been shifted to the left by the specified number of bits.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static Number<T> operator <<(Number<T> value, int shift) => Operations.LeftShift(value, shift);

        /// <summary>
        /// Shifts an integral value a specified number of bits to the right.
        /// </summary>
        /// <param name="value">The value whose bits are to be shifted.</param>
        /// <param name="shift">The number of bits to shift value to the right.</param>
        /// <returns>A value that has been shifted to the right by the specified number of bits.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static Number<T> operator >>(Number<T> value, int shift) => Operations.RightShift(value, shift);

        /// <summary>
        /// Returns a value that indicates whether the values of two numeric objects are equal.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if the <paramref name="left"/> and <paramref name="right"/> parameters have the same value; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static bool operator ==(Number<T> left, Number<T> right) => Operations.Equals(left, right);

        /// <summary>
        /// Returns a value that indicates whether two numeric objects have different values.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static bool operator !=(Number<T> left, Number<T> right) => Operations.NotEquals(left, right);

        /// <summary>
        /// Returns a value that indicates whether a numeric value is less than another numeric value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is less than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static bool operator <(Number<T> left, Number<T> right) => Operations.LessThan(left, right);

        /// <summary>
        /// Returns a value that indicates whether a numeric value is greater than another numeric value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static bool operator >(Number<T> left, Number<T> right) => Operations.GreaterThan(left, right);

        /// <summary>
        /// Returns a value that indicates whether a numeric value is less than or equal to another numeric value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is less than or equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static bool operator <=(Number<T> left, Number<T> right) => Operations.LessThanOrEquals(left, right);

        /// <summary>
        /// Returns a value that indicates whether a numeric value is greater than or equal to another numeric value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static bool operator >=(Number<T> left, Number<T> right) => Operations.GreaterThanOrEquals(left, right);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="byte"/> to a <see cref="Number{T}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T>(byte value) => Operations.Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="sbyte"/> to a <see cref="Number{T}"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator Number<T>(sbyte value) => Operations.Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="short"/> to a <see cref="Number{T}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T>(short value) => Operations.Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="ushort"/> to a <see cref="Number{T}"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator Number<T>(ushort value) => Operations.Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="int"/> to a <see cref="Number{T}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T>(int value) => Operations.Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="uint"/> to a <see cref="Number{T}"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator Number<T>(uint value) => Operations.Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="long"/> to a <see cref="Number{T}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T>(long value) => Operations.Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="ulong"/> to a <see cref="Number{T}"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator Number<T>(ulong value) => Operations.Convert(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="float"/> value to a <see cref="Number{T}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T>(float value) => Operations.Convert(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="double"/> value to a <see cref="Number{T}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T>(double value) => Operations.Convert(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="decimal"/> value to a <see cref="Number{T}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T>(decimal value) => Operations.Convert(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="sbyte"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="sbyte"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="sbyte"/>'s MaxValue or less than <see cref="sbyte"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator sbyte(Number<T> value) => Operations.ToSByte(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="byte"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="byte"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="byte"/>'s MaxValue or less than <see cref="byte"/>'s MinValue.</exception>
        public static explicit operator byte(Number<T> value) => Operations.ToByte(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="short"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="short"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="short"/>'s MaxValue or less than <see cref="short"/>'s MinValue.</exception>
        public static explicit operator short(Number<T> value) => Operations.ToInt16(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="ushort"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="ushort"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="ushort"/>'s MaxValue or less than <see cref="ushort"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator ushort(Number<T> value) => Operations.ToUInt16(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="int"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="int"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="int"/>'s MaxValue or less than <see cref="int"/>'s MinValue.</exception>
        public static explicit operator int(Number<T> value) => Operations.ToInt32(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="uint"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="uint"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="uint"/>'s MaxValue or less than <see cref="uint"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator uint(Number<T> value) => Operations.ToUInt32(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="long"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="long"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="long"/>'s MaxValue or less than <see cref="long"/>'s MinValue.</exception>
        public static explicit operator long(Number<T> value) => Operations.ToInt64(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="ulong"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="ulong"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="ulong"/>'s MaxValue or less than <see cref="ulong"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator ulong(Number<T> value) => Operations.ToUInt64(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="float"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="float"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="float"/>'s MaxValue or less than <see cref="float"/>'s MinValue.</exception>
        public static explicit operator float(Number<T> value) => Operations.ToSingle(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="double"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="double"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="double"/>'s MaxValue or less than <see cref="double"/>'s MinValue.</exception>
        public static explicit operator double(Number<T> value) => Operations.ToDouble(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="decimal"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="decimal"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="decimal"/>'s MaxValue or less than <see cref="decimal"/>'s MinValue.</exception>
        public static explicit operator decimal(Number<T> value) => Operations.ToDecimal(value);

#if BIG_INTEGER
        /// <summary>
        /// Defines an explicit conversion of a <see cref="BigInteger"/> to a <see cref="Number{T}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T>(BigInteger value) => Operations.Convert(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to a <see cref="BigInteger"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="BigInteger"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static explicit operator BigInteger(Number<T> value) => Operations.ToBigInteger(value);
#endif
    }
}