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
    /// A high performance number wrapper type that provides numeric operations in the form of convenient type operators.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    /// <typeparam name="TNumericOperations">The numeric operations type.</typeparam>+
    [CLSCompliant(false)]
    public readonly struct Number<T, TNumericOperations> : IEquatable<Number<T, TNumericOperations>>, IComparable<Number<T, TNumericOperations>>, IComparable, IFormattable
#if ICONVERTIBLE
        , IConvertible
#endif
        where TNumericOperations : struct, INumericOperations<T>
    {
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
        public override string ToString() => default(TNumericOperations).ToString(Value, null, null)!;

        /// <summary>
        /// Converts the numeric value of the current numeric object to its equivalent string representation by using the specified format.
        /// </summary>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <returns>The string representation of the current numeric value in the format specified by the <paramref name="format"/> parameter.</returns>
        /// <exception cref="FormatException"><paramref name="format"/> is not a valid format string.</exception>
        public string ToString(string? format) => default(TNumericOperations).ToString(Value, format, null)!;

        /// <summary>
        /// Converts the numeric value of the current numeric object to its equivalent string representation by using the specified culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>The string representation of the current numeric value in the format specified by the <paramref name="provider"/> parameter.</returns>
        public string ToString(IFormatProvider? provider) => default(TNumericOperations).ToString(Value, null, provider)!;

        /// <summary>
        /// Converts the numeric value of the current numeric object to its equivalent string representation by using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>The string representation of the current numeric value as specified by the <paramref name="format"/> and <paramref name="provider"/> parameters.</returns>
        /// <exception cref="FormatException"><paramref name="format"/> is not a valid format string.</exception>
        public string ToString(string? format, IFormatProvider? provider) => default(TNumericOperations).ToString(Value, format, provider)!;

#if SPAN
        /// <summary>
        /// Tries to convert the specified numeric value to its equivalent string representation into the destination <see cref="Span{T}"/> by using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="destination">The <see cref="Span{T}"/> to write the string representation to.</param>
        /// <param name="charsWritten">The number of characters written to <paramref name="destination"/>.</param>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns><c>true</c> if the value's string representation was successfully written to <paramref name="destination"/>; otherwise, <c>false</c>.</returns>
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => default(TNumericOperations).TryFormat(Value, destination, out charsWritten, format, provider);
#endif

        /// <summary>
        /// Returns a value that indicates whether the current instance and a specified object have the same value.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns><c>true</c> if the <paramref name="obj"/> argument is a <see cref="Number{T, TNumericOperations}"/> object, and its value is equal to the value of the current instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj) => obj is Number<T, TNumericOperations> n && Equals(n);

        /// <summary>
        /// Returns a value that indicates whether the current instance and a specified <see cref="Number{T, TNumericOperations}"/> object have the same value.
        /// </summary>
        /// <param name="other">The object to compare.</param>
        /// <returns><c>true</c> if this numeric object and <paramref name="other"/> have the same value; otherwise, <c>false</c>.</returns>
        public bool Equals(Number<T, TNumericOperations> other) => default(TNumericOperations).Equals(Value, other);

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
        public int CompareTo(object? obj) => obj is Number<T, TNumericOperations> n ? CompareTo(n) : (Value == null ? 0 : 1);

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
        public int CompareTo(Number<T, TNumericOperations> other) => default(TNumericOperations).Compare(Value, other);

        /// <summary>
        /// Converts the number to its <typeparamref name="TTo"/> equivalent.
        /// </summary>
        /// <typeparam name="TTo">The numeric type to convert to.</typeparam>
        /// <returns>A value that is equivalent to the number.</returns>
        /// <exception cref="NotSupportedException">The <typeparamref name="TTo"/> type argument provided is not supported.</exception>
        /// <exception cref="OverflowException">Number is greater than <typeparamref name="TTo"/>'s MaxValue or less than <typeparamref name="TTo"/>'s MinValue.</exception>
        public TTo To<TTo>() => Number.GetOperationsInternal<TTo>().Convert(Value);

#if ICONVERTIBLE
        /// <summary>
        /// Returns the <see cref="TypeCode"/> for <typeparamref name="T"/>.
        /// </summary>
        /// <returns>The <see cref="TypeCode"/> for <typeparamref name="T"/>.</returns>
        public TypeCode GetTypeCode() => default(TNumericOperations).TypeCode;

        bool IConvertible.ToBoolean(IFormatProvider? provider) => Convert.ToBoolean(Value, provider);

        byte IConvertible.ToByte(IFormatProvider? provider) => default(TNumericOperations).ToByte(Value);

        char IConvertible.ToChar(IFormatProvider? provider) => Convert.ToChar(Value, provider);

        DateTime IConvertible.ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(Value, provider);

        decimal IConvertible.ToDecimal(IFormatProvider? provider) => default(TNumericOperations).ToDecimal(Value);

        double IConvertible.ToDouble(IFormatProvider? provider) => default(TNumericOperations).ToDouble(Value);

        short IConvertible.ToInt16(IFormatProvider? provider) => default(TNumericOperations).ToInt16(Value);

        int IConvertible.ToInt32(IFormatProvider? provider) => default(TNumericOperations).ToInt32(Value);

        long IConvertible.ToInt64(IFormatProvider? provider) => default(TNumericOperations).ToInt64(Value);

        sbyte IConvertible.ToSByte(IFormatProvider? provider) => default(TNumericOperations).ToSByte(Value);

        float IConvertible.ToSingle(IFormatProvider? provider) => default(TNumericOperations).ToSingle(Value);

#pragma warning disable CS8616 // Nullability of reference types in return type doesn't match implemented member.
        object? IConvertible.ToType(Type conversionType, IFormatProvider? provider) => Convert.ChangeType(Value, conversionType, provider);
#pragma warning restore CS8616 // Nullability of reference types in return type doesn't match implemented member.

        ushort IConvertible.ToUInt16(IFormatProvider? provider) => default(TNumericOperations).ToUInt16(Value);

        uint IConvertible.ToUInt32(IFormatProvider? provider) => default(TNumericOperations).ToUInt32(Value);

        ulong IConvertible.ToUInt64(IFormatProvider? provider) => default(TNumericOperations).ToUInt64(Value);
#endif

        /// <summary>
        /// Defines an implicit conversion of a <typeparamref name="T"/> to a <see cref="Number{T, TNumericOperations}"/>.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T, TNumericOperations}"/>.</param>
        public static implicit operator Number<T, TNumericOperations>(T value) => new Number<T, TNumericOperations>(value);

        /// <summary>
        /// Defines an implicit conversion of a <see cref="Number{T, TNumericOperations}"/> to a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="value">The value to convert to a <typeparamref name="T"/>.</param>
        public static implicit operator T(Number<T, TNumericOperations> value) => value.Value;

        /// <summary>
        /// Returns the value of the numeric operand. (The sign of the operand is unchanged.)
        /// </summary>
        /// <param name="value">A numeric value.</param>
        /// <returns>The value of the <paramref name="value"/> operand.</returns>
        public static Number<T, TNumericOperations> operator +(Number<T, TNumericOperations> value) => value;

        /// <summary>
        /// Adds the values of two specified numeric objects.
        /// </summary>
        /// <param name="left">The first value to add.</param>
        /// <param name="right">The second value to add.</param>
        /// <returns>The sum of <paramref name="left"/> and <paramref name="right"/>.</returns>
        public static Number<T, TNumericOperations> operator +(Number<T, TNumericOperations> left, Number<T, TNumericOperations> right) => default(TNumericOperations).Add(left, right);

        /// <summary>
        /// Negates a specified numeric value.
        /// </summary>
        /// <param name="value">The value to negate.</param>
        /// <returns>The result of the value parameter multiplied by negative one (-1).</returns>
        /// <exception cref="NotSupportedException">The numeric type doesn't support negative values.</exception>
        public static Number<T, TNumericOperations> operator -(Number<T, TNumericOperations> value) => default(TNumericOperations).Negate(value);

        /// <summary>
        /// Subtracts a numeric value from another numeric value.
        /// </summary>
        /// <param name="left">The value to subtract from (the minuend).</param>
        /// <param name="right">The value to subtract (the subtrahend).</param>
        /// <returns>The result of subtracting <paramref name="right"/> from <paramref name="left"/>.</returns>
        public static Number<T, TNumericOperations> operator -(Number<T, TNumericOperations> left, Number<T, TNumericOperations> right) => default(TNumericOperations).Subtract(left, right);

        /// <summary>
        /// Returns the bitwise one's complement of a numeric value.
        /// </summary>
        /// <param name="value">An integer value.</param>
        /// <returns>The bitwise one's complement of <paramref name="value"/>.</returns>
        /// <exception cref="NotSupportedException">The numeric type is a floating point type.</exception>
        public static Number<T, TNumericOperations> operator ~(Number<T, TNumericOperations> value) => default(TNumericOperations).OnesComplement(value);

        /// <summary>
        /// Increments a numeric value by 1.
        /// </summary>
        /// <param name="value">The value to increment.</param>
        /// <returns>The value of the <paramref name="value"/> parameter incremented by 1.</returns>
        public static Number<T, TNumericOperations> operator ++(Number<T, TNumericOperations> value) => default(TNumericOperations).Add(value, default(TNumericOperations).One);

        /// <summary>
        /// Decrements a numeric value by 1.
        /// </summary>
        /// <param name="value">The value to decrement.</param>
        /// <returns>The value of the <paramref name="value"/> parameter decremented by 1.</returns>
        public static Number<T, TNumericOperations> operator --(Number<T, TNumericOperations> value) => default(TNumericOperations).Subtract(value, default(TNumericOperations).One);

        /// <summary>
        /// Multiplies two specified numeric values.
        /// </summary>
        /// <param name="left">The first value to multiply.</param>
        /// <param name="right">The second value to multiply.</param>
        /// <returns>The product of <paramref name="left"/> and <paramref name="right"/>.</returns>
        public static Number<T, TNumericOperations> operator *(Number<T, TNumericOperations> left, Number<T, TNumericOperations> right) => default(TNumericOperations).Multiply(left, right);

        /// <summary>
        /// Divides a specified numeric value by another specified numeric value.
        /// </summary>
        /// <param name="dividend">The value to be divided.</param>
        /// <param name="divisor">The value to divide by.</param>
        /// <returns>The result of the division.</returns>
        /// <exception cref="DivideByZeroException"><paramref name="divisor"/> is zero (0).</exception>
        public static Number<T, TNumericOperations> operator /(Number<T, TNumericOperations> dividend, Number<T, TNumericOperations> divisor) => default(TNumericOperations).Divide(dividend, divisor);

        /// <summary>
        /// Returns the remainder that results from division with two specified numeric values.
        /// </summary>
        /// <param name="dividend">The value to be divided.</param>
        /// <param name="divisor">The value to divide by.</param>
        /// <returns>The remainder that results from the division.</returns>
        /// <exception cref="DivideByZeroException"><paramref name="divisor"/> is zero (0).</exception>
        public static Number<T, TNumericOperations> operator %(Number<T, TNumericOperations> dividend, Number<T, TNumericOperations> divisor) => default(TNumericOperations).Remainder(dividend, divisor);

        /// <summary>
        /// Performs a bitwise And operation on two integral values.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The result of the bitwise And operation.</returns>
        /// <exception cref="NotSupportedException">The numeric type is a floating point type.</exception>
        public static Number<T, TNumericOperations> operator &(Number<T, TNumericOperations> left, Number<T, TNumericOperations> right) => default(TNumericOperations).BitwiseAnd(left, right);

        /// <summary>
        /// Performs a bitwise Or operation on two integral values.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The result of the bitwise Or operation.</returns>
        /// <exception cref="NotSupportedException">The numeric type is a floating point type.</exception>
        public static Number<T, TNumericOperations> operator |(Number<T, TNumericOperations> left, Number<T, TNumericOperations> right) => default(TNumericOperations).BitwiseOr(left, right);

        /// <summary>
        /// Performs a bitwise exclusive Or operation on two integral values.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The result of the bitwise exclusive Or operation.</returns>
        /// <exception cref="NotSupportedException">The numeric type is a floating point type.</exception>
        public static Number<T, TNumericOperations> operator ^(Number<T, TNumericOperations> left, Number<T, TNumericOperations> right) => default(TNumericOperations).Xor(left, right);

        /// <summary>
        /// Shifts an integral value a specified number of bits to the left.
        /// </summary>
        /// <param name="value">The value whose bits are to be shifted.</param>
        /// <param name="shift">The number of bits to shift value to the left.</param>
        /// <returns>A value that has been shifted to the left by the specified number of bits.</returns>
        /// <exception cref="NotSupportedException">The numeric type is a floating point type.</exception>
        public static Number<T, TNumericOperations> operator <<(Number<T, TNumericOperations> value, int shift) => default(TNumericOperations).LeftShift(value, shift);

        /// <summary>
        /// Shifts an integral value a specified number of bits to the right.
        /// </summary>
        /// <param name="value">The value whose bits are to be shifted.</param>
        /// <param name="shift">The number of bits to shift value to the right.</param>
        /// <returns>A value that has been shifted to the right by the specified number of bits.</returns>
        /// <exception cref="NotSupportedException">The numeric type is a floating point type.</exception>
        public static Number<T, TNumericOperations> operator >>(Number<T, TNumericOperations> value, int shift) => default(TNumericOperations).RightShift(value, shift);

        /// <summary>
        /// Returns a value that indicates whether the values of two numeric objects are equal.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if the <paramref name="left"/> and <paramref name="right"/> parameters have the same value; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Number<T, TNumericOperations> left, Number<T, TNumericOperations> right) => default(TNumericOperations).Equals(left, right);

        /// <summary>
        /// Returns a value that indicates whether two numeric objects have different values.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Number<T, TNumericOperations> left, Number<T, TNumericOperations> right) => default(TNumericOperations).NotEquals(left, right);

        /// <summary>
        /// Returns a value that indicates whether a numeric value is less than another numeric value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is less than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator <(Number<T, TNumericOperations> left, Number<T, TNumericOperations> right) => default(TNumericOperations).LessThan(left, right);

        /// <summary>
        /// Returns a value that indicates whether a numeric value is greater than another numeric value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator >(Number<T, TNumericOperations> left, Number<T, TNumericOperations> right) => default(TNumericOperations).GreaterThan(left, right);

        /// <summary>
        /// Returns a value that indicates whether a numeric value is less than or equal to another numeric value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is less than or equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator <=(Number<T, TNumericOperations> left, Number<T, TNumericOperations> right) => default(TNumericOperations).LessThanOrEqual(left, right);

        /// <summary>
        /// Returns a value that indicates whether a numeric value is greater than or equal to another numeric value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator >=(Number<T, TNumericOperations> left, Number<T, TNumericOperations> right) => default(TNumericOperations).GreaterThanOrEqual(left, right);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="byte"/> to a <see cref="Number{T, TNumericOperations}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T, TNumericOperations}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T, TNumericOperations>(byte value) => default(TNumericOperations).Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="sbyte"/> to a <see cref="Number{T, TNumericOperations}"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T, TNumericOperations}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator Number<T, TNumericOperations>(sbyte value) => default(TNumericOperations).Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="short"/> to a <see cref="Number{T, TNumericOperations}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T, TNumericOperations}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T, TNumericOperations>(short value) => default(TNumericOperations).Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="ushort"/> to a <see cref="Number{T, TNumericOperations}"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T, TNumericOperations}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator Number<T, TNumericOperations>(ushort value) => default(TNumericOperations).Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="int"/> to a <see cref="Number{T, TNumericOperations}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T, TNumericOperations}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T, TNumericOperations>(int value) => default(TNumericOperations).Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="uint"/> to a <see cref="Number{T, TNumericOperations}"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T, TNumericOperations}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator Number<T, TNumericOperations>(uint value) => default(TNumericOperations).Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="long"/> to a <see cref="Number{T, TNumericOperations}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T, TNumericOperations}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T, TNumericOperations>(long value) => default(TNumericOperations).Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="ulong"/> to a <see cref="Number{T, TNumericOperations}"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T, TNumericOperations}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator Number<T, TNumericOperations>(ulong value) => default(TNumericOperations).Convert(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="float"/> value to a <see cref="Number{T, TNumericOperations}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T, TNumericOperations}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T, TNumericOperations>(float value) => default(TNumericOperations).Convert(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="double"/> value to a <see cref="Number{T, TNumericOperations}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T, TNumericOperations}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T, TNumericOperations>(double value) => default(TNumericOperations).Convert(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="decimal"/> value to a <see cref="Number{T, TNumericOperations}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T, TNumericOperations}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T, TNumericOperations>(decimal value) => default(TNumericOperations).Convert(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T, TNumericOperations}"/> object to an <see cref="sbyte"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="sbyte"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="sbyte"/>'s MaxValue or less than <see cref="sbyte"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator sbyte(Number<T, TNumericOperations> value) => default(TNumericOperations).ToSByte(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T, TNumericOperations}"/> object to an <see cref="byte"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="byte"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="byte"/>'s MaxValue or less than <see cref="byte"/>'s MinValue.</exception>
        public static explicit operator byte(Number<T, TNumericOperations> value) => default(TNumericOperations).ToByte(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T, TNumericOperations}"/> object to an <see cref="short"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="short"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="short"/>'s MaxValue or less than <see cref="short"/>'s MinValue.</exception>
        public static explicit operator short(Number<T, TNumericOperations> value) => default(TNumericOperations).ToInt16(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T, TNumericOperations}"/> object to an <see cref="ushort"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="ushort"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="ushort"/>'s MaxValue or less than <see cref="ushort"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator ushort(Number<T, TNumericOperations> value) => default(TNumericOperations).ToUInt16(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T, TNumericOperations}"/> object to an <see cref="int"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="int"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="int"/>'s MaxValue or less than <see cref="int"/>'s MinValue.</exception>
        public static explicit operator int(Number<T, TNumericOperations> value) => default(TNumericOperations).ToInt32(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T, TNumericOperations}"/> object to an <see cref="uint"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="uint"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="uint"/>'s MaxValue or less than <see cref="uint"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator uint(Number<T, TNumericOperations> value) => default(TNumericOperations).ToUInt32(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T, TNumericOperations}"/> object to an <see cref="long"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="long"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="long"/>'s MaxValue or less than <see cref="long"/>'s MinValue.</exception>
        public static explicit operator long(Number<T, TNumericOperations> value) => default(TNumericOperations).ToInt64(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T, TNumericOperations}"/> object to an <see cref="ulong"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="ulong"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="ulong"/>'s MaxValue or less than <see cref="ulong"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator ulong(Number<T, TNumericOperations> value) => default(TNumericOperations).ToUInt64(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T, TNumericOperations}"/> object to an <see cref="float"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="float"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="float"/>'s MaxValue or less than <see cref="float"/>'s MinValue.</exception>
        public static explicit operator float(Number<T, TNumericOperations> value) => default(TNumericOperations).ToSingle(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T, TNumericOperations}"/> object to an <see cref="double"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="double"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="double"/>'s MaxValue or less than <see cref="double"/>'s MinValue.</exception>
        public static explicit operator double(Number<T, TNumericOperations> value) => default(TNumericOperations).ToDouble(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T, TNumericOperations}"/> object to an <see cref="decimal"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="decimal"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="decimal"/>'s MaxValue or less than <see cref="decimal"/>'s MinValue.</exception>
        public static explicit operator decimal(Number<T, TNumericOperations> value) => default(TNumericOperations).ToDecimal(value);

#if BIG_INTEGER
        /// <summary>
        /// Defines an explicit conversion of a <see cref="BigInteger"/> to a <see cref="Number{T, TNumericOperations}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T, TNumericOperations}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T, TNumericOperations>(BigInteger value) => default(TNumericOperations).Convert(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T, TNumericOperations}"/> object to a <see cref="BigInteger"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="BigInteger"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        public static explicit operator BigInteger(Number<T, TNumericOperations> value) => default(TNumericOperations).ToBigInteger(value);
#endif
    }
}