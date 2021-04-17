using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Medium
{
    /// <summary>
    /// Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer
    /// (similar to C/C++'s atoi function).
    /// The algorithm for myAtoi(string s) is as follows:
    /// 1. Read in and ignore any leading whitespace.
    /// 2. Check if the next character (if not already at the end of the string) is '-' or '+'.
    ///    Read this character in if it is either.
    ///    This determines if the final result is negative or positive respectively.
    ///    Assume the result is positive if neither is present.
    /// 3. Read in next the characters until the next non-digit character or the end of the input is reached.
    ///    The rest of the string is ignored.
    /// 4. Convert these digits into an integer (i.e. "123" -> 123, "0032" -> 32).
    ///    If no digits were read, then the integer is 0. Change the sign as necessary (from step 2).
    /// 5. If the integer is out of the 32-bit signed integer range [-2^31, 2^31 - 1],
    ///    then clamp the integer so that it remains in the range.
    ///    Specifically, integers less than -2^31 should be clamped to -2^31,
    ///    and integers greater than 2^31 - 1 should be clamped to 2^31 - 1.
    /// 5. Return the integer as the final result.
    /// Note:
    /// Only the space character ' ' is considered a whitespace character.
    /// Do not ignore any characters other than the leading whitespace or the rest of the string after the digits.
    /// </summary>
    /// <remarks>
    /// Constraints:
    /// 0 <= s.length <= 200
    /// s consists of English letters (lower-case and upper-case), digits (0-9), ' ', '+', '-', and '.'.
    /// https://leetcode.com/problems/string-to-integer-atoi/
    /// </remarks>
    /// <example>
    /// Input: s = "   -42"
    /// Output: -42
    /// Input: s = "4193 with words"
    /// Output: 4193
    /// Input: s = "words and 987"
    /// Output: 0
    /// Input: s = "-91283472332"
    /// Output: -2147483648
    /// </example>
    class StringToInteger
    {
        public static int MyAtoi(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            var index = 0;
            // skip any leading whitespace
            while ((index < s.Length) && (s[index] == ' '))
                ++index;
            if (index == s.Length)
                return 0;

            // check sign character
            var isPositive = true;
            if ((s[index] == '-') || (s[index] == '+'))
            {
                isPositive = s[index] != '-';
                ++index;
            }
            if (index == s.Length)
                return 0;

            // if non-digit characters return 0
            if (!char.IsDigit(s[index]))
                return 0;

            // read digit characters
            var digitsIndex = index;
            while ((index < s.Length) && (char.IsDigit(s[index])))
                ++index;

            var intLimit = int.MaxValue / 10;
            var intLimitLastDigitPos = int.MaxValue % 10;
            var intLimitLastDigitNeg = -(int.MinValue % 10);

            // convert digits into an integer
            var number = 0;
            for (int i = digitsIndex; i < index; ++i)
            {
                var pop = s[i] - '0';
                if (number > intLimit)
                    return isPositive ? int.MaxValue : int.MinValue;
                if (number == intLimit)
                {
                    if (isPositive && (pop > intLimitLastDigitPos))
                        return int.MaxValue;
                    if (!isPositive && (pop > intLimitLastDigitNeg))
                        return int.MinValue;
                }

                number *= 10;
                number += pop;
            }

            return isPositive ? number : -number;
        }
    }
}
