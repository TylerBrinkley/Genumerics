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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace Genumerics
{
    /// <summary>
    /// Provides the required numeric operations for the numeric type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    [CLSCompliant(false)]
    public interface INumericOperations<T>
    {
        /// <summary>
        /// Gets a value that represents the number zero (0).
        /// </summary>
        T Zero { get; }

        /// <summary>
        /// Gets a value that represents the number one (1).
        /// </summary>
        T One { get; }

        /// <summary>
        /// Gets a value that represents the number negative one (-1).
        /// </summary>
        T MinusOne { get; }

        /// <summary>
        /// Gets the largest possible value of <typeparamref name="T"/>.
        /// </summary>
        T MaxValue { get; }

        /// <summary>
        /// Gets the smallest possible value of <typeparamref name="T"/>.
        /// </summary>
        T MinValue { get; }

        /// <summary>
        /// Returns the <see cref="System.TypeCode"/> for <typeparamref name="T"/>.
        /// </summary>
        TypeCode TypeCode { get; }

        /// <summary>
        /// Returns a value that indicates whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if the <paramref name="left"/> and <paramref name="right"/> parameters have the same value; otherwise, <c>false</c>.</returns>
        bool Equals(T left, T right);

        /// <summary>
        /// Returns a value that indicates whether the two objects have different values.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, <c>false</c>.</returns>
        bool NotEquals(T left, T right);

        /// <summary>
        /// Returns a value that indicates whether a value is less than another value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is less than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        bool LessThan(T left, T right);

        /// <summary>
        /// Returns a value that indicates whether a value is less than or equal to another value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is less than or equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        bool LessThanOrEqual(T left, T right);

        /// <summary>
        /// Returns a value that indicates whether a value is greater than another value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        bool GreaterThan(T left, T right);

        /// <summary>
        /// Returns a value that indicates whether a value is greater than or equal to another value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        bool GreaterThanOrEqual(T left, T right);

        /// <summary>
        /// Adds two values and returns the result.
        /// </summary>
        /// <param name="left">The first value to add.</param>
        /// <param name="right">The second value to add.</param>
        /// <returns>The sum of <paramref name="left"/> and <paramref name="right"/>.</returns>
        T Add(T left, T right);

        /// <summary>
        /// Subtracts one value from another and returns the result.
        /// </summary>
        /// <param name="left">The value to subtract from (the minuend).</param>
        /// <param name="right">The value to subtract (the subtrahend).</param>
        /// <returns>The result of subtracting <paramref name="right"/> from <paramref name="left"/>.</returns>
        T Subtract(T left, T right);

        /// <summary>
        /// Returns the product of two values.
        /// </summary>
        /// <param name="left">The first number to multiply.</param>
        /// <param name="right">The second number to multiply.</param>
        /// <returns>The product of the <paramref name="left"/> and <paramref name="right"/> parameters.</returns>
        T Multiply(T left, T right);

        /// <summary>
        /// Divides one value by another and returns the result.
        /// </summary>
        /// <param name="dividend">The value to be divided.</param>
        /// <param name="divisor">The value to divide by.</param>
        /// <returns>The quotient of the division.</returns>
        T Divide(T dividend, T divisor);

        /// <summary>
        /// Performs division on two values and returns the remainder.
        /// </summary>
        /// <param name="dividend">The value to be divided.</param>
        /// <param name="divisor">The value to divide by.</param>
        /// <returns>The remainder after dividing <paramref name="dividend"/> by <paramref name="divisor"/>.</returns>
        T Remainder(T dividend, T divisor);

        /// <summary>
        /// Calculates the quotient of two values and also returns the remainder in an output parameter.
        /// </summary>
        /// <param name="dividend">The dividend.</param>
        /// <param name="divisor">The divisor.</param>
        /// <param name="remainder">The remainder.</param>
        /// <returns>The quotient of the specified numbers.</returns>
        T DivRem(T dividend, T divisor, out T remainder);

        /// <summary>
        /// Negates a specified value.
        /// </summary>
        /// <param name="value">The value to negate.</param>
        /// <returns>The result of the <paramref name="value"/> parameter multiplied by negative one (-1).</returns>
        T Negate(T value);

        /// <summary>
        /// Performs a bitwise And operation on two values.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The result of the bitwise And operation.</returns>
        T BitwiseAnd(T left, T right);

        /// <summary>
        /// Performs a bitwise Or operation on two values.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The result of the bitwise Or operation.</returns>
        T BitwiseOr(T left, T right);

        /// <summary>
        /// Performs a bitwise exclusive Or operation on two values.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The result of the bitwise exclusive Or operation.</returns>
        T Xor(T left, T right);

        /// <summary>
        /// Returns the bitwise one's complement of a value.
        /// </summary>
        /// <param name="value">An integer value.</param>
        /// <returns>The bitwise one's complement of <paramref name="value"/>.</returns>
        T OnesComplement(T value);

        /// <summary>
        /// Shifts a value a specified number of bits to the left.
        /// </summary>
        /// <param name="value">The value whose bits are to be shifted.</param>
        /// <param name="shift">The number of bits to shift value to the left.</param>
        /// <returns>A value that has been shifted to the left by the specified number of bits.</returns>
        T LeftShift(T value, int shift);

        /// <summary>
        /// Shifts a value a specified number of bits to the right.
        /// </summary>
        /// <param name="value">The value whose bits are to be shifted.</param>
        /// <param name="shift">The number of bits to shift value to the right.</param>
        /// <returns>A value that has been shifted to the right by the specified number of bits.</returns>
        T RightShift(T value, int shift);

        /// <summary>
        /// Converts the string representation of a number in a specified <paramref name="style"/> and culture-specific format to its <typeparamref name="T"/> equivalent.
        /// </summary>
        /// <param name="value">A string that contains a number to convert.</param>
        /// <param name="style">A bitwise combination of the enumeration values that specify the permitted format of <paramref name="value"/>.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="value"/>.</param>
        /// <returns>A value that is equivalent to the number specified in the <paramref name="value"/> parameter.</returns>
        T Parse(string value, NumberStyles? style, IFormatProvider? provider);

        /// <summary>
        /// Tries to convert the string representation of a number in a specified <paramref name="style"/> and
        /// culture-specific format to its <typeparamref name="T"/> equivalent, and returns
        /// a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="value">The string representation of a number. The string is interpreted using the style specified by <paramref name="style"/>.</param>
        /// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="value"/>.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="value"/>.</param>
        /// <param name="result">When this method returns, contains the <typeparamref name="T"/> equivalent
        /// to the number that is contained in <paramref name="value"/>, or zero (0)
        /// if the conversion failed. The conversion fails if the value parameter is <c>null</c>
        /// or is not in a format that is compliant with <paramref name="style"/>. This parameter is passed
        /// uninitialized.</param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        bool TryParse(string value, NumberStyles? style, IFormatProvider? provider, out T result);

#if SPAN
        /// <summary>
        /// Converts the string representation of a number in a specified <paramref name="style"/> and culture-specific format to its <typeparamref name="T"/> equivalent.
        /// </summary>
        /// <param name="value">A string that contains a number to convert.</param>
        /// <param name="style">A bitwise combination of the enumeration values that specify the permitted format of <paramref name="value"/>.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="value"/>.</param>
        /// <returns>A value that is equivalent to the number specified in the <paramref name="value"/> parameter.</returns>
        T Parse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider);

        /// <summary>
        /// Tries to convert the string representation of a number in a specified <paramref name="style"/> and
        /// culture-specific format to its <typeparamref name="T"/> equivalent, and returns
        /// a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="value">The string representation of a number. The string is interpreted using the style specified by <paramref name="style"/>.</param>
        /// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="value"/>.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="value"/>.</param>
        /// <param name="result">When this method returns, contains the <typeparamref name="T"/> equivalent
        /// to the number that is contained in <paramref name="value"/>, or zero (0)
        /// if the conversion failed. The conversion fails if the value parameter is <c>null</c>
        /// or is not in a format that is compliant with <paramref name="style"/>. This parameter is passed
        /// uninitialized.</param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        bool TryParse(ReadOnlySpan<char> value, NumberStyles? style, IFormatProvider? provider, out T result);

        /// <summary>
        /// Tries to convert the specified numeric value to its equivalent string representation into the destination <see cref="Span{T}"/> by using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="value">A number.</param>
        /// <param name="destination">The <see cref="Span{T}"/> to write the string representation to.</param>
        /// <param name="charsWritten">The number of characters written to <paramref name="destination"/>.</param>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns><c>true</c> if the value's string representation was successfully written to <paramref name="destination"/>; otherwise, <c>false</c>.</returns>
        bool TryFormat(T value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null);
#endif

        /// <summary>
        /// Converts the specified value to its <typeparamref name="T"/> equivalent.
        /// </summary>
        /// <typeparam name="TFrom">The numeric type to convert from.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <returns>A value that is equivalent to the number specified in the <paramref name="value"/> parameter.</returns>
        T Convert<TFrom>(TFrom value);

        /// <summary>
        /// Rounds a value to a specified number of fractional digits. A parameter specifies how to round the value if it is midway between two numbers.
        /// </summary>
        /// <param name="value">A number to be rounded.</param>
        /// <param name="digits">The number of fractional digits in the return value.</param>
        /// <param name="mode">Specification for how to round value if it is midway between two other numbers.</param>
        /// <returns>The number nearest to <paramref name="value"/> that has a number of fractional digits equal to <paramref name="digits"/>.
        /// If <paramref name="value"/> has fewer fractional digits than <paramref name="digits"/>, <paramref name="value"/> is returned unchanged.</returns>
        T Round(T value, int digits, MidpointRounding mode);

        /// <summary>
        /// Returns the largest integer less than or equal to the specified number.
        /// </summary>
        /// <param name="value">A number.</param>
        /// <returns>The largest integer less than or equal to <paramref name="value"/>.</returns>
        T Floor(T value);

        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the specified number.
        /// </summary>
        /// <param name="value">A number.</param>
        /// <returns>The smallest integral value that is greater than or equal to <paramref name="value"/>.</returns>
        T Ceiling(T value);

        /// <summary>
        /// Calculates the integral part of a specified number.
        /// </summary>
        /// <param name="value">A number to truncate.</param>
        /// <returns>The integral part of <paramref name="value"/>; that is, the number that remains after any fractional digits have been discarded.</returns>
        T Truncate(T value);

        /// <summary>
        /// Compares two values and returns an integer that indicates whether the first value is less than, equal to, or greater than the second value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>A signed integer that indicates the relative values of <paramref name="left"/> and <paramref name="right"/>,
        /// less than zero if <paramref name="left"/> is less than <paramref name="right"/>,
        /// zero if <paramref name="left"/> equals <paramref name="right"/>,
        /// and greater than zero if <paramref name="left"/> is greater than <paramref name="right"/>.</returns>
        int Compare(T left, T right);

        /// <summary>
        /// Gets the absolute value of a number.
        /// </summary>
        /// <param name="value">A number.</param>
        /// <returns>The absolute value of <paramref name="value"/>.</returns>
        T Abs(T value);

        /// <summary>
        /// Returns the larger of two values.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>The <paramref name="left"/> or <paramref name="right"/> parameter, whichever is larger.</returns>
        T Max(T left, T right);

        /// <summary>
        /// Returns the smaller of two values.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>The <paramref name="left"/> or <paramref name="right"/> parameter, whichever is smaller.</returns>
        T Min(T left, T right);

        /// <summary>
        /// Gets a number that indicates the sign (negative, positive, or zero) of the current object.
        /// </summary>
        /// <param name="value">A number.</param>
        /// <returns>A number that indicates the sign of the object, -1 if the value of this object
        /// is negative, 0 if the value of this object is zero (0), and 1 if the value of this object
        /// is positive.</returns>
        int Sign(T value);

        /// <summary>
        /// Converts the specified numeric value to its equivalent string representation by using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="value">A number.</param>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>The string representation of <paramref name="value"/> as specified by the <paramref name="format"/> and <paramref name="provider"/> parameters.</returns>
        [return: NotNullIfNotNull("value")]
        string? ToString(T value, string? format, IFormatProvider? provider);

        /// <summary>
        /// Converts the specified numeric value to an <see cref="sbyte"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        sbyte ToSByte(T value);

        /// <summary>
        /// Converts the specified numeric value to an <see cref="byte"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        byte ToByte(T value);

        /// <summary>
        /// Converts the specified numeric value to an <see cref="short"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        short ToInt16(T value);

        /// <summary>
        /// Converts the specified numeric value to an <see cref="ushort"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        ushort ToUInt16(T value);

        /// <summary>
        /// Converts the specified numeric value to an <see cref="int"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        int ToInt32(T value);

        /// <summary>
        /// Converts the specified numeric value to an <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        uint ToUInt32(T value);

        /// <summary>
        /// Converts the specified numeric value to an <see cref="long"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        long ToInt64(T value);

        /// <summary>
        /// Converts the specified numeric value to an <see cref="ulong"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        ulong ToUInt64(T value);

        /// <summary>
        /// Converts the specified numeric value to a <see cref="float"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        float ToSingle(T value);

        /// <summary>
        /// Converts the specified numeric value to a <see cref="double"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        double ToDouble(T value);

        /// <summary>
        /// Converts the specified numeric value to a <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        decimal ToDecimal(T value);

        /// <summary>
        /// Converts the specified numeric value to a <see cref="BigInteger"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>An object that contains the value of the <paramref name="value"/> parameter.</returns>
        BigInteger ToBigInteger(T value);

        /// <summary>
        /// Indicates whether the specified value is an even number.
        /// </summary>
        /// <param name="value">An integral number.</param>
        /// <returns><c>true</c> if <paramref name="value"/> is an even number; otherwise, <c>false</c>.</returns>
        bool IsEven(T value);

        /// <summary>
        /// Indicates whether the specified value is an odd number.
        /// </summary>
        /// <param name="value">An integral number.</param>
        /// <returns><c>true</c> if <paramref name="value"/> is an odd number; otherwise, <c>false</c>.</returns>
        bool IsOdd(T value);

        /// <summary>
        /// Indicates whether the specified integral value is a power of two.
        /// </summary>
        /// <param name="value">An integral number.</param>
        /// <returns><c>true</c> if <paramref name="value"/> is a power of two; otherwise, <c>false</c>.</returns>
        bool IsPowerOfTwo(T value);

        /// <summary>
        /// Returns <paramref name="value"/> clamped to the inclusive range of <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        /// <param name="value">The value to be clamped.</param>
        /// <param name="min">The lower bound of the result.</param>
        /// <param name="max">The upper bound of the result.</param>
        /// <returns><paramref name="min"/> if <paramref name="value"/> is less than <paramref name="min"/>,
        /// <paramref name="max"/> if <paramref name="value"/> is greater than <paramref name="max"/>,
        /// else <paramref name="value"/>.</returns>
        T Clamp(T value, T min, T max);
    }
}