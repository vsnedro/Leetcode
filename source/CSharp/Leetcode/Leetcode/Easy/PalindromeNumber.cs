using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    /// <summary>
    /// Given an integer x, return true if x is palindrome integer.
    /// An integer is a palindrome when it reads the same backward as forward.
    /// For example, 121 is palindrome while 123 is not.
    /// </summary>
    /// <remarks>
    /// Constraints:
    /// -2^31 <= x <= 2^31 - 1
    /// https://leetcode.com/problems/palindrome-number/
    /// </remarks>
    /// <example>
    /// Input: x = 121
    /// Output: true
    /// Input: x = -121
    /// Output: false
    /// Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
    /// Input: x = 10
    /// Output: false
    /// Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
    /// </example>
    class PalindromeNumber
    {
        public static bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;
            if (x < 10)
                return true;

            var s = x.ToString().ToCharArray();
            int l = 0, r = s.Length - 1;
            while (l < r)
            {
                if (!s[l].Equals(s[r]))
                    return false;
                ++l;
                --r;
            }

            return true;
        }
    }
}
