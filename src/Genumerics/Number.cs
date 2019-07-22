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

namespace Genumerics
{
    /// <summary>
    /// Static class that provides many generic numeric operations and constants.
    /// </summary>
    public static class Number
    {
        /// <summary>
        /// Gets a value that represents the number zero (0).
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <returns>An object whose value is zero (0).</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static T Zero<T>() => GetOperations<T>().Zero;

        /// <summary>
        /// Gets a value that represents the number one (1).
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <returns>An object whose value is one (1).</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static T One<T>() => GetOperations<T>().One;

        /// <summary>
        /// Gets a value that represents the number negative one (-1).
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <returns>An object whose value is negative one (-1).</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.
        /// -or-
        /// the numeric type doesn't support negative values.</exception>
        public static T MinusOne<T>() => GetOperations<T>().MinusOne;

        /// <summary>
        /// Gets the largest possible value of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <returns>An object representing the largest possible value of <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.
        /// -or-
        /// the numeric type isn't bounded.</exception>
        public static T MaxValue<T>() => GetOperations<T>().MaxValue;

        /// <summary>
        /// Gets the smallest possible value of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <returns>An object representing the smallest possible value of <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.
        /// -or-
        /// the numeric type isn't bounded.</exception>
        public static T MinValue<T>() => GetOperations<T>().MinValue;

#if TYPE_CODE
        /// <summary>
        /// Returns the <see cref="TypeCode"/> for <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <returns>The <see cref="TypeCode"/> for <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static TypeCode GetTypeCode<T>() => GetOperations<T>().TypeCode;
#endif

        /// <summary>
        /// Returns a value that indicates whether the values of the two objects are equal.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if the <paramref name="left"/> and <paramref name="right"/> parameters have the same value; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static bool Equals<T>(T left, T right) => GetOperations<T>().Equals(left, right);

        /// <summary>
        /// Returns a value that indicates whether the two objects have different values.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static bool NotEquals<T>(T left, T right) => GetOperations<T>().NotEquals(left, right);

        /// <summary>
        /// Returns a value that indicates whether a value is less than another value.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is less than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static bool LessThan<T>(T left, T right) => GetOperations<T>().LessThan(left, right);

        /// <summary>
        /// Returns a value that indicates whether a value is less than or equal to another value.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is less than or equal to <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static bool LessThanOrEquals<T>(T left, T right) => GetOperations<T>().LessThanOrEquals(left, right);

        /// <summary>
        /// Returns a value that indicates whether a value is greater than another value.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static bool GreaterThan<T>(T left, T right) => GetOperations<T>().GreaterThan(left, right);

        /// <summary>
        /// Returns a value that indicates whether a value is greater than or equal to another value.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static bool GreaterThanOrEquals<T>(T left, T right) => GetOperations<T>().GreaterThanOrEquals(left, right);

        /// <summary>
        /// Adds two values and returns the result.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="left">The first value to add.</param>
        /// <param name="right">The second value to add.</param>
        /// <returns>The sum of <paramref name="left"/> and <paramref name="right"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static T Add<T>(T left, T right) => GetOperations<T>().Add(left, right);

        /// <summary>
        /// Subtracts one value from another and returns the result.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="left">The value to subtract from (the minuend).</param>
        /// <param name="right">The value to subtract (the subtrahend).</param>
        /// <returns>The result of subtracting <paramref name="right"/> from <paramref name="left"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static T Subtract<T>(T left, T right) => GetOperations<T>().Subtract(left, right);

        /// <summary>
        /// Returns the product of two values.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="left">The first number to multiply.</param>
        /// <param name="right">The second number to multiply.</param>
        /// <returns>The product of the <paramref name="left"/> and <paramref name="right"/> parameters.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static T Multiply<T>(T left, T right) => GetOperations<T>().Multiply(left, right);

        /// <summary>
        /// Divides one value by another and returns the result.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="dividend">The value to be divided.</param>
        /// <param name="divisor">The value to divide by.</param>
        /// <returns>The quotient of the division.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        /// <exception cref="DivideByZeroException"><paramref name="divisor"/> is zero (0).</exception>
        public static T Divide<T>(T dividend, T divisor) => GetOperations<T>().Divide(dividend, divisor);

        /// <summary>
        /// Performs division on two values and returns the remainder.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="dividend">The value to be divided.</param>
        /// <param name="divisor">The value to divide by.</param>
        /// <returns>The remainder after dividing <paramref name="dividend"/> by <paramref name="divisor"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        /// <exception cref="DivideByZeroException"><paramref name="divisor"/> is zero (0).</exception>
        public static T Remainder<T>(T dividend, T divisor) => GetOperations<T>().Remainder(dividend, divisor);

        /// <summary>
        /// Negates a specified value.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">The value to negate.</param>
        /// <returns>The result of the <paramref name="value"/> parameter multiplied by negative one (-1).</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.
        /// -or-
        /// the numeric type doesn't support negative values.</exception>
        public static T Negate<T>(T value) => GetOperations<T>().Negate(value);

        /// <summary>
        /// Returns the larger of two values.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>The <paramref name="left"/> or <paramref name="right"/> parameter, whichever is larger.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static T Max<T>(T left, T right) => GetOperations<T>().Max(left, right);

        /// <summary>
        /// Returns the smaller of two values.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>The <paramref name="left"/> or <paramref name="right"/> parameter, whichever is smaller.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static T Min<T>(T left, T right) => GetOperations<T>().Min(left, right);

        /// <summary>
        /// Performs a bitwise And operation on two values.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The result of the bitwise And operation.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static T And<T>(T left, T right) => GetOperations<T>().And(left, right);

        /// <summary>
        /// Performs a bitwise Or operation on two values.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The result of the bitwise Or operation.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static T Or<T>(T left, T right) => GetOperations<T>().Or(left, right);

        /// <summary>
        /// Performs a bitwise exclusive Or operation on two values.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The result of the bitwise exclusive Or operation.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static T Xor<T>(T left, T right) => GetOperations<T>().Xor(left, right);

        /// <summary>
        /// Returns the bitwise one's complement of a value.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">An integer value.</param>
        /// <returns>The bitwise one's complement of value.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static T Not<T>(T value) => GetOperations<T>().Not(value);

        /// <summary>
        /// Shifts a value a specified number of bits to the left.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">The value whose bits are to be shifted.</param>
        /// <param name="shift">The number of bits to shift value to the left.</param>
        /// <returns>A value that has been shifted to the left by the specified number of bits.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static T LeftShift<T>(T value, int shift) => GetOperations<T>().LeftShift(value, shift);

        /// <summary>
        /// Shifts a value a specified number of bits to the right.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">The value whose bits are to be shifted.</param>
        /// <param name="shift">The number of bits to shift value to the right.</param>
        /// <returns>A value that has been shifted to the right by the specified number of bits.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static T RightShift<T>(T value, int shift) => GetOperations<T>().RightShift(value, shift);

        /// <summary>
        /// Converts the string representation of a number to its <typeparamref name="T"/> equivalent.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A string that contains a number to convert.</param>
        /// <returns>A value that is equivalent to the number specified in the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
        /// <exception cref="FormatException"><paramref name="value"/> is not in the correct format.</exception>
        public static T Parse<T>(string value) => GetOperations<T>().Parse(value, null, NumberFormatInfo.CurrentInfo);

        /// <summary>
        /// Converts the string representation of a number in a specified culture-specific format to its <typeparamref name="T"/> equivalent.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A string that contains a number to convert.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="value"/>.</param>
        /// <returns>A value that is equivalent to the number specified in the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
        /// <exception cref="FormatException"><paramref name="value"/> is not in the correct format.</exception>
        public static T Parse<T>(string value, IFormatProvider provider) => GetOperations<T>().Parse(value, null, provider);

        /// <summary>
        /// Converts the string representation of a number in a specified <paramref name="style"/> to its <typeparamref name="T"/> equivalent.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A string that contains a number to convert.</param>
        /// <param name="style">A bitwise combination of the enumeration values that specify the permitted format of <paramref name="value"/>.</param>
        /// <returns>A value that is equivalent to the number specified in the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        /// <exception cref="ArgumentException"><paramref name="style"/> is not a <see cref="NumberStyles"/> value.
        /// -or-
        /// <paramref name="style"/> includes the <see cref="NumberStyles.AllowHexSpecifier"/> or <see cref="NumberStyles.HexNumber"/> flag along with another value.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
        /// <exception cref="FormatException"><paramref name="value"/> is not in the correct format.</exception>
        public static T Parse<T>(string value, NumberStyles style) => GetOperations<T>().Parse(value, style, NumberFormatInfo.CurrentInfo);

        /// <summary>
        /// Converts the string representation of a number in a specified <paramref name="style"/> and culture-specific format to its <typeparamref name="T"/> equivalent.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A string that contains a number to convert.</param>
        /// <param name="style">A bitwise combination of the enumeration values that specify the permitted format of <paramref name="value"/>.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="value"/>.</param>
        /// <returns>A value that is equivalent to the number specified in the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        /// <exception cref="ArgumentException"><paramref name="style"/> is not a <see cref="NumberStyles"/> value.
        /// -or-
        /// <paramref name="style"/> includes the <see cref="NumberStyles.AllowHexSpecifier"/> or <see cref="NumberStyles.HexNumber"/> flag along with another value.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
        /// <exception cref="FormatException"><paramref name="value"/> is not in the correct format.</exception>
        public static T Parse<T>(string value, NumberStyles style, IFormatProvider provider) => GetOperations<T>().Parse(value, style, provider);

#if SPAN
        /// <summary>
        /// Converts the string representation of a number to its <typeparamref name="T"/> equivalent.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A string that contains a number to convert.</param>
        /// <returns>A value that is equivalent to the number specified in the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        /// <exception cref="FormatException"><paramref name="value"/> is not in the correct format.</exception>
        public static T Parse<T>(ReadOnlySpan<char> value) => GetOperations<T>().Parse(value, null, NumberFormatInfo.CurrentInfo);

        /// <summary>
        /// Converts the string representation of a number in a specified culture-specific format to its <typeparamref name="T"/> equivalent.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A string that contains a number to convert.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="value"/>.</param>
        /// <returns>A value that is equivalent to the number specified in the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        /// <exception cref="FormatException"><paramref name="value"/> is not in the correct format.</exception>
        public static T Parse<T>(ReadOnlySpan<char> value, IFormatProvider provider) => GetOperations<T>().Parse(value, null, provider);

        /// <summary>
        /// Converts the string representation of a number in a specified <paramref name="style"/> to its <typeparamref name="T"/> equivalent.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A string that contains a number to convert.</param>
        /// <param name="style">A bitwise combination of the enumeration values that specify the permitted format of <paramref name="value"/>.</param>
        /// <returns>A value that is equivalent to the number specified in the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        /// <exception cref="ArgumentException"><paramref name="style"/> is not a <see cref="NumberStyles"/> value.
        /// -or-
        /// <paramref name="style"/> includes the <see cref="NumberStyles.AllowHexSpecifier"/> or <see cref="NumberStyles.HexNumber"/> flag along with another value.</exception>
        /// <exception cref="FormatException"><paramref name="value"/> is not in the correct format.</exception>
        public static T Parse<T>(ReadOnlySpan<char> value, NumberStyles style) => GetOperations<T>().Parse(value, style, NumberFormatInfo.CurrentInfo);

        /// <summary>
        /// Converts the string representation of a number in a specified <paramref name="style"/> and culture-specific format to its <typeparamref name="T"/> equivalent.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A string that contains a number to convert.</param>
        /// <param name="style">A bitwise combination of the enumeration values that specify the permitted format of <paramref name="value"/>.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="value"/>.</param>
        /// <returns>A value that is equivalent to the number specified in the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        /// <exception cref="ArgumentException"><paramref name="style"/> is not a <see cref="NumberStyles"/> value.
        /// -or-
        /// <paramref name="style"/> includes the <see cref="NumberStyles.AllowHexSpecifier"/> or <see cref="NumberStyles.HexNumber"/> flag along with another value.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
        /// <exception cref="FormatException"><paramref name="value"/> is not in the correct format.</exception>
        public static T Parse<T>(ReadOnlySpan<char> value, NumberStyles style, IFormatProvider provider) => GetOperations<T>().Parse(value, style, provider);
#endif

        /// <summary>
        /// Tries to convert the string representation of a number to its <typeparamref name="T"/> equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">The string representation of a number.</param>
        /// <param name="result">When this method returns, contains the <typeparamref name="T"/> equivalent
        /// to the number that is contained in <paramref name="value"/>, or zero (0) if the conversion fails.
        /// The conversion fails if the <paramref name="value"/> parameter is <c>null</c> or is not of the correct
        /// format. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if value was converted successfully; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static bool TryParse<T>(string value, out T result) => GetOperations<T>().TryParse(value, null, NumberFormatInfo.CurrentInfo, out result);

        /// <summary>
        /// Tries to convert the string representation of a number in a culture-specific format to its <typeparamref name="T"/> equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">The string representation of a number.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="value"/>.</param>
        /// <param name="result">When this method returns, contains the <typeparamref name="T"/> equivalent
        /// to the number that is contained in <paramref name="value"/>, or zero (0) if the conversion fails.
        /// The conversion fails if the <paramref name="value"/> parameter is <c>null</c> or is not of the correct
        /// format. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if value was converted successfully; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static bool TryParse<T>(string value, IFormatProvider provider, out T result) => GetOperations<T>().TryParse(value, null, provider, out result);

        /// <summary>
        /// Tries to convert the string representation of a number in a specified <paramref name="style"/> to its <typeparamref name="T"/> equivalent, and returns
        /// a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">The string representation of a number. The string is interpreted using the style specified by <paramref name="style"/>.</param>
        /// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="value"/>.</param>
        /// <param name="result">When this method returns, contains the <typeparamref name="T"/> equivalent
        /// to the number that is contained in <paramref name="value"/>, or zero (0)
        /// if the conversion failed. The conversion fails if the value parameter is <c>null</c>
        /// or is not in a format that is compliant with <paramref name="style"/>. This parameter is passed
        /// uninitialized.</param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        /// <exception cref="ArgumentException"><paramref name="style"/> is not a <see cref="NumberStyles"/> value.
        /// -or-
        /// <paramref name="style"/> includes the <see cref="NumberStyles.AllowHexSpecifier"/> or <see cref="NumberStyles.HexNumber"/> flag along with another value.</exception>
        public static bool TryParse<T>(string value, NumberStyles style, out T result) => GetOperations<T>().TryParse(value, style, NumberFormatInfo.CurrentInfo, out result);

        /// <summary>
        /// Tries to convert the string representation of a number in a specified <paramref name="style"/> and
        /// culture-specific format to its <typeparamref name="T"/> equivalent, and returns
        /// a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">The string representation of a number. The string is interpreted using the style specified by <paramref name="style"/>.</param>
        /// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="value"/>.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="value"/>.</param>
        /// <param name="result">When this method returns, contains the <typeparamref name="T"/> equivalent
        /// to the number that is contained in <paramref name="value"/>, or zero (0)
        /// if the conversion failed. The conversion fails if the value parameter is <c>null</c>
        /// or is not in a format that is compliant with <paramref name="style"/>. This parameter is passed
        /// uninitialized.</param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        /// <exception cref="ArgumentException"><paramref name="style"/> is not a <see cref="NumberStyles"/> value.
        /// -or-
        /// <paramref name="style"/> includes the <see cref="NumberStyles.AllowHexSpecifier"/> or <see cref="NumberStyles.HexNumber"/> flag along with another value.</exception>
        public static bool TryParse<T>(string value, NumberStyles style, IFormatProvider provider, out T result) => GetOperations<T>().TryParse(value, style, provider, out result);

#if SPAN
        /// <summary>
        /// Tries to convert the string representation of a number to its <typeparamref name="T"/> equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">The string representation of a number.</param>
        /// <param name="result">When this method returns, contains the <typeparamref name="T"/> equivalent
        /// to the number that is contained in <paramref name="value"/>, or zero (0) if the conversion fails.
        /// The conversion fails if the <paramref name="value"/> parameter is <c>null</c> or is not of the correct
        /// format. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if value was converted successfully; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static bool TryParse<T>(ReadOnlySpan<char> value, out T result) => GetOperations<T>().TryParse(value, null, NumberFormatInfo.CurrentInfo, out result);

        /// <summary>
        /// Tries to convert the string representation of a number in a culture-specific format to its <typeparamref name="T"/> equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">The string representation of a number.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="value"/>.</param>
        /// <param name="result">When this method returns, contains the <typeparamref name="T"/> equivalent
        /// to the number that is contained in <paramref name="value"/>, or zero (0) if the conversion fails.
        /// The conversion fails if the <paramref name="value"/> parameter is <c>null</c> or is not of the correct
        /// format. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if value was converted successfully; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static bool TryParse<T>(ReadOnlySpan<char> value, IFormatProvider provider, out T result) => GetOperations<T>().TryParse(value, null, provider, out result);

        /// <summary>
        /// Tries to convert the string representation of a number in a specified <paramref name="style"/> to its <typeparamref name="T"/> equivalent, and returns
        /// a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">The string representation of a number. The string is interpreted using the style specified by <paramref name="style"/>.</param>
        /// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="value"/>.</param>
        /// <param name="result">When this method returns, contains the <typeparamref name="T"/> equivalent
        /// to the number that is contained in <paramref name="value"/>, or zero (0)
        /// if the conversion failed. The conversion fails if the value parameter is <c>null</c>
        /// or is not in a format that is compliant with <paramref name="style"/>. This parameter is passed
        /// uninitialized.</param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        /// <exception cref="ArgumentException"><paramref name="style"/> is not a <see cref="NumberStyles"/> value.
        /// -or-
        /// <paramref name="style"/> includes the <see cref="NumberStyles.AllowHexSpecifier"/> or <see cref="NumberStyles.HexNumber"/> flag along with another value.</exception>
        public static bool TryParse<T>(ReadOnlySpan<char> value, NumberStyles style, out T result) => GetOperations<T>().TryParse(value, style, NumberFormatInfo.CurrentInfo, out result);

        /// <summary>
        /// Tries to convert the string representation of a number in a specified <paramref name="style"/> and
        /// culture-specific format to its <typeparamref name="T"/> equivalent, and returns
        /// a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">The string representation of a number. The string is interpreted using the style specified by <paramref name="style"/>.</param>
        /// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="value"/>.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="value"/>.</param>
        /// <param name="result">When this method returns, contains the <typeparamref name="T"/> equivalent
        /// to the number that is contained in <paramref name="value"/>, or zero (0)
        /// if the conversion failed. The conversion fails if the value parameter is <c>null</c>
        /// or is not in a format that is compliant with <paramref name="style"/>. This parameter is passed
        /// uninitialized.</param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        /// <exception cref="ArgumentException"><paramref name="style"/> is not a <see cref="NumberStyles"/> value.
        /// -or-
        /// <paramref name="style"/> includes the <see cref="NumberStyles.AllowHexSpecifier"/> or <see cref="NumberStyles.HexNumber"/> flag along with another value.</exception>
        public static bool TryParse<T>(ReadOnlySpan<char> value, NumberStyles style, IFormatProvider provider, out T result) => GetOperations<T>().TryParse(value, style, provider, out result);
#endif

        /// <summary>
        /// Converts the specified value to its <typeparamref name="TTo"/> equivalent.
        /// </summary>
        /// <typeparam name="TFrom">The numeric type to convert from.</typeparam>
        /// <typeparam name="TTo">The numeric type to convert to.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <returns>A value that is equivalent to the number specified in the <paramref name="value"/> parameter.</returns>
        /// <exception cref="NotSupportedException">One or both type arguments provided are not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is greater than <typeparamref name="TTo"/>'s MaxValue or less than <typeparamref name="TTo"/>'s MinValue.</exception>
        public static TTo Convert<TFrom, TTo>(TFrom value)
        {
            var operations = GetOperations<TTo>();
            if (value != null)
            {
                return operations.Convert(value);
            }
            GetOperations<TFrom>(); // Necessary to validate conversion types
            return default;
        }

        /// <summary>
        /// Rounds a value to the nearest integral value.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A number to be rounded.</param>
        /// <returns>The integer nearest <paramref name="value"/>. If the fractional component of <paramref name="value"/> is halfway between two
        /// integers, one of which is even and the other odd, then the even number is returned.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static T Round<T>(T value) => GetOperations<T>().Round(value, 0, MidpointRounding.ToEven);

        /// <summary>
        /// Rounds a value to a specified number of fractional digits.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A number to be rounded.</param>
        /// <param name="digits">The number of fractional digits in the return value.</param>
        /// <returns>The number nearest to <paramref name="value"/> that contains a number of fractional digits equal to <paramref name="digits"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="digits"/> is less than 0 or greater than a max value for the numeric type.</exception>
        public static T Round<T>(T value, int digits) => GetOperations<T>().Round(value, digits, MidpointRounding.ToEven);

        /// <summary>
        /// Rounds a value to the nearest integer. A parameter specifies how to round the value if it is midway between two numbers.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A number to be rounded.</param>
        /// <param name="mode">Specification for how to round value if it is midway between two other numbers.</param>
        /// <returns>The integer nearest <paramref name="value"/>. If value is halfway between two integers, one of which is even and the other odd,
        /// then <paramref name="mode"/> determines which of the two is returned.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        /// <exception cref="ArgumentException"><paramref name="mode"/> is not a valid value of <see cref="MidpointRounding"/>.</exception>
        public static T Round<T>(T value, MidpointRounding mode) => GetOperations<T>().Round(value, 0, mode);

        /// <summary>
        /// Rounds a value to a specified number of fractional digits. A parameter specifies how to round the value if it is midway between two numbers.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A number to be rounded.</param>
        /// <param name="digits">The number of fractional digits in the return value.</param>
        /// <param name="mode">Specification for how to round value if it is midway between two other numbers.</param>
        /// <returns>The number nearest to <paramref name="value"/> that has a number of fractional digits equal to <paramref name="digits"/>.
        /// If <paramref name="value"/> has fewer fractional digits than <paramref name="digits"/>, <paramref name="value"/> is returned unchanged.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="digits"/> is less than 0 or greater than a max value for the numeric type.</exception>
        /// <exception cref="ArgumentException"><paramref name="mode"/> is not a valid value of <see cref="MidpointRounding"/>.</exception>
        public static T Round<T>(T value, int digits, MidpointRounding mode) => GetOperations<T>().Round(value, digits, mode);

        /// <summary>
        /// Returns the largest integer less than or equal to the specified number.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A number.</param>
        /// <returns>The largest integer less than or equal to <paramref name="value"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static T Floor<T>(T value) => GetOperations<T>().Floor(value);

        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the specified number.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A number.</param>
        /// <returns>The smallest integral value that is greater than or equal to <paramref name="value"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static T Ceiling<T>(T value) => GetOperations<T>().Ceiling(value);

        /// <summary>
        /// Calculates the integral part of a specified number.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A number to truncate.</param>
        /// <returns>The integral part of <paramref name="value"/>; that is, the number that remains after any fractional digits have been discarded.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static T Truncate<T>(T value) => GetOperations<T>().Truncate(value);

        /// <summary>
        /// Compares two values and returns an integer that indicates whether the first value is less than, equal to, or greater than the second value.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>A signed integer that indicates the relative values of <paramref name="left"/> and <paramref name="right"/>,
        /// less than zero if <paramref name="left"/> is less than <paramref name="right"/>,
        /// zero if <paramref name="left"/> equals <paramref name="right"/>,
        /// and greater than zero if <paramref name="left"/> is greater than <paramref name="right"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static int Compare<T>(T left, T right) => GetOperations<T>().Compare(left, right);

        /// <summary>
        /// Gets a number that indicates the sign (negative, positive, or zero) of the current object.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A number.</param>
        /// <returns>A number that indicates the sign of the object, -1 if the value of this object
        /// is negative, 0 if the value of this object is zero (0), and 1 if the value of this object
        /// is positive.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static int Sign<T>(T value) => GetOperations<T>().Sign(value);

        /// <summary>
        /// Gets the absolute value of a number.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A number.</param>
        /// <returns>The absolute value of <paramref name="value"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static T Abs<T>(T value) => GetOperations<T>().Abs(value);

        /// <summary>
        /// Converts the specified numeric value to its equivalent string representation.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A number.</param>
        /// <returns>The string representation of <paramref name="value"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static string ToString<T>(T value) => GetOperations<T>().ToString(value, null, null);

        /// <summary>
        /// Converts the specified numeric value to its equivalent string representation by using the specified format.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A number.</param>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <returns>The string representation of <paramref name="value"/> in the format specified by the <paramref name="format"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        /// <exception cref="FormatException"><paramref name="format"/> is not a valid format string.</exception>
        public static string ToString<T>(T value, string format) => GetOperations<T>().ToString(value, format, null);

        /// <summary>
        /// Converts the specified numeric value to its equivalent string representation by using the specified culture-specific formatting information.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A number.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>The string representation of <paramref name="value"/> in the format specified by the <paramref name="provider"/> parameter.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        public static string ToString<T>(T value, IFormatProvider provider) => GetOperations<T>().ToString(value, null, provider);

        /// <summary>
        /// Converts the specified numeric value to its equivalent string representation by using the specified format and culture-specific format information.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">A number.</param>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>The string representation of <paramref name="value"/> as specified by the <paramref name="format"/> and <paramref name="provider"/> parameters.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        /// <exception cref="FormatException"><paramref name="format"/> is not a valid format string.</exception>
        public static string ToString<T>(T value, string format, IFormatProvider provider) => GetOperations<T>().ToString(value, format, provider);

        /// <summary>
        /// Indicates whether the specified value is an even number.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">An integral number.</param>
        /// <returns><c>true</c> if <paramref name="value"/> is an even number; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static bool IsEven<T>(T value) => GetOperations<T>().IsEven(value);

        /// <summary>
        /// Indicates whether the specified value is an odd number.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">An integral number.</param>
        /// <returns><c>true</c> if <paramref name="value"/> is an odd number; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static bool IsOdd<T>(T value) => GetOperations<T>().IsOdd(value);

        /// <summary>
        /// Indicates whether the specified integral value is a power of two.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">An integral number.</param>
        /// <returns><c>true</c> if <paramref name="value"/> is a power of two; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.
        /// -or-
        /// the numeric type is a floating point type.</exception>
        public static bool IsPowerOfTwo<T>(T value) => GetOperations<T>().IsPowerOfTwo(value);

        /// <summary>
        /// Returns <paramref name="value"/> clamped to the inclusive range of <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        /// <typeparam name="T">The numeric type.</typeparam>
        /// <param name="value">The value to be clamped.</param>
        /// <param name="min">The lower bound of the result.</param>
        /// <param name="max">The upper bound of the result.</param>
        /// <returns><paramref name="min"/> if <paramref name="value"/> is less than <paramref name="min"/>,
        /// <paramref name="max"/> if <paramref name="value"/> is greater than <paramref name="max"/>,
        /// else <paramref name="value"/>.</returns>
        /// <exception cref="NotSupportedException">The type argument provided is not supported.</exception>
        /// <exception cref="ArgumentException"><paramref name="min"/> is greater than <paramref name="max"/>.</exception>
        public static T Clamp<T>(T value, T min, T max) => GetOperations<T>().Clamp(value, min, max);

        internal static INumericOperations<T> GetOperations<T>() => Number<T>.Operations ?? throw new NotSupportedException($"Generic numeric operations on {typeof(T)} are not supported. The only supported types are SByte, Byte, Int16, UInt16, Int32, UInt32, Int64, UInt64, Single, Double, Decimal, and BigInteger as well as the generic versions of each of these types.");
    }

    internal static class Number<T>
    {
        internal static readonly INumericOperations<T> Operations = DefaultNumericOperations.Instance as INumericOperations<T> ?? NullableNumericOperationsStore<T>.Instance;
    }
}