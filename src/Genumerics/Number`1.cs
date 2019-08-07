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
using System.Threading;
using System.Diagnostics.CodeAnalysis;

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
        private static INumericOperations<T>? s_operations;

        /// <summary>
        /// Gets or sets the operations supported for the numeric type <typeparamref name="T"/>. Cannot overwrite once set.
        /// Cannot set for nullable value types. Nullable types are handled automatically.
        /// </summary>
        [CLSCompliant(false)]
        [DisallowNull]
        public static INumericOperations<T>? Operations
        {
            get => GetOperations(throwErrorWhenNull: false);
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (default(T)! == null && typeof(T).IsValueType())
                {
                    throw new ArgumentException("Cannot explicitly set operations for nullable value types. Nullable value types are handled automatically.");
                }

                if (Operations != null || Interlocked.CompareExchange(ref s_operations, value, null) != null)
                {
                    throw new InvalidOperationException("Cannot overwrite operations once set.");
                }
            }
        }

        internal static INumericOperations<T> GetOperations(bool throwErrorWhenNull = true)
        {
            var operations = s_operations;
            if (operations == null)
            {
                var numericType = typeof(T);
                Type? operationsType = null;
                if (default(DefaultNumericOperations) is INumericOperations<T>)
                {
                    operationsType = typeof(DefaultNumericOperations<,>).MakeGenericType(numericType, typeof(DefaultNumericOperations));
                }
                else if (default(T)! == null && numericType.IsValueType())
                {
                    operationsType = typeof(NullableNumericOperations<>).MakeGenericType(numericType.GetGenericArguments()[0]);
                }
                else if (numericType.IsEnum())
                {
                    operationsType = typeof(EnumOperations<,,>).MakeGenericType(numericType, Enum.GetUnderlyingType(numericType), typeof(DefaultNumericOperations));
                }
                else if (throwErrorWhenNull)
                {
                    throw new NotSupportedException($"Generic numeric operations on {typeof(T)} are not supported. The only supported types are SByte, Byte, Int16, UInt16, Int32, UInt32, Int64, UInt64, Single, Double, Decimal, BigInteger, and enums as well as the nullable versions of each of these types.");
                }

                if (operationsType != null)
                {
                    operations = Interlocked.CompareExchange(ref s_operations, (operations = (INumericOperations<T>)Activator.CreateInstance(operationsType)), null) ?? operations;
                }
            }
            return operations!; // Could be null but only when throwErrorWhenNull = false
        }

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
        public override string? ToString() => GetOperations().ToString(Value, null, null);

        /// <summary>
        /// Converts the numeric value of the current numeric object to its equivalent string representation by using the specified format.
        /// </summary>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <returns>The string representation of the current numeric value in the format specified by the <paramref name="format"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="FormatException"><paramref name="format"/> is not a valid format string.</exception>
        public string? ToString(string? format) => GetOperations().ToString(Value, format, null);

        /// <summary>
        /// Converts the numeric value of the current numeric object to its equivalent string representation by using the specified culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>The string representation of the current numeric value in the format specified by the <paramref name="provider"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public string? ToString(IFormatProvider? provider) => GetOperations().ToString(Value, null, provider);

        /// <summary>
        /// Converts the numeric value of the current numeric object to its equivalent string representation by using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>The string representation of the current numeric value as specified by the <paramref name="format"/> and <paramref name="provider"/> parameters.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="FormatException"><paramref name="format"/> is not a valid format string.</exception>
        public string? ToString(string? format, IFormatProvider? provider) => GetOperations().ToString(Value, format, provider);

#if SPAN
        /// <summary>
        /// Tries to convert the specified numeric value to its equivalent string representation into the destination <see cref="Span{T}"/> by using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="destination">The <see cref="Span{T}"/> to write the string representation to.</param>
        /// <param name="charsWritten">The number of characters written to <paramref name="destination"/>.</param>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns><c>true</c> if the value's string representation was successfully written to <paramref name="destination"/>; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => GetOperations().TryFormat(Value, destination, out charsWritten, format, provider);
#endif

        /// <summary>
        /// Returns a value that indicates whether the current instance and a specified object have the same value.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns><c>true</c> if the <paramref name="obj"/> argument is a <see cref="Number{T}"/> object, and its value is equal to the value of the current instance; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public override bool Equals(object? obj) => obj is Number<T> n && Equals(n);

        /// <summary>
        /// Returns a value that indicates whether the current instance and a specified <see cref="Number{T}"/> object have the same value.
        /// </summary>
        /// <param name="other">The object to compare.</param>
        /// <returns><c>true</c> if this numeric object and <paramref name="other"/> have the same value; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public bool Equals(Number<T> other) => GetOperations().Equals(Value, other);

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
        public int CompareTo(object? obj) => obj is Number<T> n ? CompareTo(n) : (Value == null ? 0 : 1);

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
        public int CompareTo(Number<T> other) => GetOperations().Compare(Value, other);

        /// <summary>
        /// Converts the number to its <typeparamref name="TTo"/> equivalent.
        /// </summary>
        /// <typeparam name="TTo">The numeric type to convert to.</typeparam>
        /// <returns>A value that is equivalent to the number.</returns>
        /// <exception cref="NotSupportedException">One or both type arguments provided are not supported.</exception>
        /// <exception cref="OverflowException">Number is greater than <typeparamref name="TTo"/>'s MaxValue or less than <typeparamref name="TTo"/>'s MinValue.</exception>
        public TTo To<TTo>()
        {
            var operations = Number<TTo>.GetOperations();
            if (Value != null)
            {
                return operations.Convert(Value);
            }
            _ = GetOperations(); // Necessary to validate conversion types
            return default!;
        }

#if ICONVERTIBLE
        /// <summary>
        /// Returns the <see cref="TypeCode"/> for <typeparamref name="T"/>.
        /// </summary>
        /// <returns>The <see cref="TypeCode"/> for <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public TypeCode GetTypeCode() => GetOperations().TypeCode;

        bool IConvertible.ToBoolean(IFormatProvider provider) => Convert.ToBoolean(Value, provider);

        byte IConvertible.ToByte(IFormatProvider provider) => GetOperations().ToByte(Value);

        char IConvertible.ToChar(IFormatProvider provider) => Convert.ToChar(Value, provider);

        DateTime IConvertible.ToDateTime(IFormatProvider provider) => Convert.ToDateTime(Value, provider);

        decimal IConvertible.ToDecimal(IFormatProvider provider) => GetOperations().ToDecimal(Value);

        double IConvertible.ToDouble(IFormatProvider provider) => GetOperations().ToDouble(Value);

        short IConvertible.ToInt16(IFormatProvider provider) => GetOperations().ToInt16(Value);

        int IConvertible.ToInt32(IFormatProvider provider) => GetOperations().ToInt32(Value);

        long IConvertible.ToInt64(IFormatProvider provider) => GetOperations().ToInt64(Value);

        sbyte IConvertible.ToSByte(IFormatProvider provider) => GetOperations().ToSByte(Value);

        float IConvertible.ToSingle(IFormatProvider provider) => GetOperations().ToSingle(Value);

        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => Convert.ChangeType(Value, conversionType, provider);

        ushort IConvertible.ToUInt16(IFormatProvider provider) => GetOperations().ToUInt16(Value);

        uint IConvertible.ToUInt32(IFormatProvider provider) => GetOperations().ToUInt32(Value);

        ulong IConvertible.ToUInt64(IFormatProvider provider) => GetOperations().ToUInt64(Value);
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
        public static Number<T> operator +(Number<T> left, Number<T> right) => GetOperations().Add(left, right);

        /// <summary>
        /// Negates a specified numeric value.
        /// </summary>
        /// <param name="value">The value to negate.</param>
        /// <returns>The result of the value parameter multiplied by negative one (-1).</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.
        /// -or-
        /// the numeric type doesn't support negative values.</exception>
        public static Number<T> operator -(Number<T> value) => GetOperations().Negate(value);

        /// <summary>
        /// Subtracts a numeric value from another numeric value.
        /// </summary>
        /// <param name="left">The value to subtract from (the minuend).</param>
        /// <param name="right">The value to subtract (the subtrahend).</param>
        /// <returns>The result of subtracting <paramref name="right"/> from <paramref name="left"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static Number<T> operator -(Number<T> left, Number<T> right) => GetOperations().Subtract(left, right);

        /// <summary>
        /// Returns the bitwise one's complement of a numeric value.
        /// </summary>
        /// <param name="value">An integer value.</param>
        /// <returns>The bitwise one's complement of <paramref name="value"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static Number<T> operator ~(Number<T> value) => GetOperations().Not(value);

        /// <summary>
        /// Increments a numeric value by 1.
        /// </summary>
        /// <param name="value">The value to increment.</param>
        /// <returns>The value of the <paramref name="value"/> parameter incremented by 1.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static Number<T> operator ++(Number<T> value) => GetOperations().Add(value, GetOperations().One);

        /// <summary>
        /// Decrements a numeric value by 1.
        /// </summary>
        /// <param name="value">The value to decrement.</param>
        /// <returns>The value of the <paramref name="value"/> parameter decremented by 1.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static Number<T> operator --(Number<T> value) => GetOperations().Subtract(value, GetOperations().One);

        /// <summary>
        /// Multiplies two specified numeric values.
        /// </summary>
        /// <param name="left">The first value to multiply.</param>
        /// <param name="right">The second value to multiply.</param>
        /// <returns>The product of <paramref name="left"/> and <paramref name="right"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static Number<T> operator *(Number<T> left, Number<T> right) => GetOperations().Multiply(left, right);

        /// <summary>
        /// Divides a specified numeric value by another specified numeric value.
        /// </summary>
        /// <param name="dividend">The value to be divided.</param>
        /// <param name="divisor">The value to divide by.</param>
        /// <returns>The result of the division.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="DivideByZeroException"><paramref name="divisor"/> is zero (0).</exception>
        public static Number<T> operator /(Number<T> dividend, Number<T> divisor) => GetOperations().Divide(dividend, divisor);

        /// <summary>
        /// Returns the remainder that results from division with two specified numeric values.
        /// </summary>
        /// <param name="dividend">The value to be divided.</param>
        /// <param name="divisor">The value to divide by.</param>
        /// <returns>The remainder that results from the division.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="DivideByZeroException"><paramref name="divisor"/> is zero (0).</exception>
        public static Number<T> operator %(Number<T> dividend, Number<T> divisor) => GetOperations().Remainder(dividend, divisor);

        /// <summary>
        /// Performs a bitwise And operation on two integral values.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The result of the bitwise And operation.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static Number<T> operator &(Number<T> left, Number<T> right) => GetOperations().And(left, right);

        /// <summary>
        /// Performs a bitwise Or operation on two integral values.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The result of the bitwise Or operation.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static Number<T> operator |(Number<T> left, Number<T> right) => GetOperations().Or(left, right);

        /// <summary>
        /// Performs a bitwise exclusive Or operation on two integral values.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The result of the bitwise exclusive Or operation.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static Number<T> operator ^(Number<T> left, Number<T> right) => GetOperations().Xor(left, right);

        /// <summary>
        /// Shifts an integral value a specified number of bits to the left.
        /// </summary>
        /// <param name="value">The value whose bits are to be shifted.</param>
        /// <param name="shift">The number of bits to shift value to the left.</param>
        /// <returns>A value that has been shifted to the left by the specified number of bits.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static Number<T> operator <<(Number<T> value, int shift) => GetOperations().LeftShift(value, shift);

        /// <summary>
        /// Shifts an integral value a specified number of bits to the right.
        /// </summary>
        /// <param name="value">The value whose bits are to be shifted.</param>
        /// <param name="shift">The number of bits to shift value to the right.</param>
        /// <returns>A value that has been shifted to the right by the specified number of bits.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static Number<T> operator >>(Number<T> value, int shift) => GetOperations().RightShift(value, shift);

        /// <summary>
        /// Returns a value that indicates whether the values of two numeric objects are equal.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if the <paramref name="left"/> and <paramref name="right"/> parameters have the same value; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static bool operator ==(Number<T> left, Number<T> right) => GetOperations().Equals(left, right);

        /// <summary>
        /// Returns a value that indicates whether two numeric objects have different values.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static bool operator !=(Number<T> left, Number<T> right) => GetOperations().NotEquals(left, right);

        /// <summary>
        /// Returns a value that indicates whether a numeric value is less than another numeric value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is less than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static bool operator <(Number<T> left, Number<T> right) => GetOperations().LessThan(left, right);

        /// <summary>
        /// Returns a value that indicates whether a numeric value is greater than another numeric value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static bool operator >(Number<T> left, Number<T> right) => GetOperations().GreaterThan(left, right);

        /// <summary>
        /// Returns a value that indicates whether a numeric value is less than or equal to another numeric value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is less than or equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static bool operator <=(Number<T> left, Number<T> right) => GetOperations().LessThanOrEquals(left, right);

        /// <summary>
        /// Returns a value that indicates whether a numeric value is greater than or equal to another numeric value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static bool operator >=(Number<T> left, Number<T> right) => GetOperations().GreaterThanOrEquals(left, right);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="byte"/> to a <see cref="Number{T}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T>(byte value) => GetOperations().Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="sbyte"/> to a <see cref="Number{T}"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator Number<T>(sbyte value) => GetOperations().Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="short"/> to a <see cref="Number{T}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T>(short value) => GetOperations().Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="ushort"/> to a <see cref="Number{T}"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator Number<T>(ushort value) => GetOperations().Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="int"/> to a <see cref="Number{T}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T>(int value) => GetOperations().Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="uint"/> to a <see cref="Number{T}"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator Number<T>(uint value) => GetOperations().Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="long"/> to a <see cref="Number{T}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T>(long value) => GetOperations().Convert(value);

        /// <summary>
        /// Defines an explicit conversion of an <see cref="ulong"/> to a <see cref="Number{T}"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator Number<T>(ulong value) => GetOperations().Convert(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="float"/> value to a <see cref="Number{T}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T>(float value) => GetOperations().Convert(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="double"/> value to a <see cref="Number{T}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T>(double value) => GetOperations().Convert(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="decimal"/> value to a <see cref="Number{T}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T>(decimal value) => GetOperations().Convert(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="sbyte"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="sbyte"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="sbyte"/>'s MaxValue or less than <see cref="sbyte"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator sbyte(Number<T> value) => GetOperations().ToSByte(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="byte"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="byte"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="byte"/>'s MaxValue or less than <see cref="byte"/>'s MinValue.</exception>
        public static explicit operator byte(Number<T> value) => GetOperations().ToByte(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="short"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="short"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="short"/>'s MaxValue or less than <see cref="short"/>'s MinValue.</exception>
        public static explicit operator short(Number<T> value) => GetOperations().ToInt16(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="ushort"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="ushort"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="ushort"/>'s MaxValue or less than <see cref="ushort"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator ushort(Number<T> value) => GetOperations().ToUInt16(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="int"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="int"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="int"/>'s MaxValue or less than <see cref="int"/>'s MinValue.</exception>
        public static explicit operator int(Number<T> value) => GetOperations().ToInt32(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="uint"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="uint"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="uint"/>'s MaxValue or less than <see cref="uint"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator uint(Number<T> value) => GetOperations().ToUInt32(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="long"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="long"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="long"/>'s MaxValue or less than <see cref="long"/>'s MinValue.</exception>
        public static explicit operator long(Number<T> value) => GetOperations().ToInt64(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="ulong"/> value. This API is not CLS-compliant.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="ulong"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="ulong"/>'s MaxValue or less than <see cref="ulong"/>'s MinValue.</exception>
        [CLSCompliant(false)]
        public static explicit operator ulong(Number<T> value) => GetOperations().ToUInt64(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="float"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="float"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="float"/>'s MaxValue or less than <see cref="float"/>'s MinValue.</exception>
        public static explicit operator float(Number<T> value) => GetOperations().ToSingle(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="double"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="double"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="double"/>'s MaxValue or less than <see cref="double"/>'s MinValue.</exception>
        public static explicit operator double(Number<T> value) => GetOperations().ToDouble(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to an <see cref="decimal"/> value.
        /// </summary>
        /// <param name="value">The value to convert to an <see cref="decimal"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <see cref="decimal"/>'s MaxValue or less than <see cref="decimal"/>'s MinValue.</exception>
        public static explicit operator decimal(Number<T> value) => GetOperations().ToDecimal(value);

#if BIG_INTEGER
        /// <summary>
        /// Defines an explicit conversion of a <see cref="BigInteger"/> to a <see cref="Number{T}"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="Number{T}"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="T"/>'s MaxValue or less than <typeparamref name="T"/>'s MinValue.</exception>
        public static explicit operator Number<T>(BigInteger value) => GetOperations().Convert(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Number{T}"/> object to a <see cref="BigInteger"/> value.
        /// </summary>
        /// <param name="value">The value to convert to a <see cref="BigInteger"/>.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument is not supported.</exception>
        public static explicit operator BigInteger(Number<T> value) => GetOperations().ToBigInteger(value);
#endif
    }
}